using Todo.CLI.Config;
using Todo.CLI.Services;
using YamlDotNet.Serialization;

namespace Todo.CLI;

class Program
{
    const string AppConfigFileName = "todo.yaml";

    public static async Task Main(string[] args)
    {
        if (args.Length < 1 || string.IsNullOrWhiteSpace(args[0]))
        {
            Console.Error.WriteLine("error: no description provided");
            Console.Error.WriteLine("usage: Todo.CLI.exe \"get food\"");
            return;
        }

        var description = args[0].Trim();

        var config = MustLoadConfiguration();
        var todoService = TodoServiceFactory.CreateService(config);
        
        await todoService.CreateTodo(description);
        Console.WriteLine(description);
    }

    private static AppConfig MustLoadConfiguration()
    {
        try
        {
            var homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var configFilePath = Path.Combine(homePath, AppConfigFileName);

            if (!File.Exists(configFilePath))
            {
                Console.Error.WriteLine("error: could not find config file at {0}", configFilePath);
            }
            
            var yaml = File.ReadAllText(configFilePath);

            var deserializer = new DeserializerBuilder().Build();
            return deserializer.Deserialize<AppConfig>(yaml);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"error: could not load configuration: {ex.Message}");
            Environment.Exit(1);
            return null;
        }
    }
}