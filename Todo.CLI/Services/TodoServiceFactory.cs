using Todo.CLI.Config;
using Todo.CLI.Services.Trello;

namespace Todo.CLI.Services;

public static class TodoServiceFactory
{
    public static ITodoService CreateService(AppConfig config)
    {
        return config.Service.ToLower() switch
        {
            "trello" => new TrelloService(config.Trello),
            _ => throw new ArgumentException($"Service '{config.Service}' is not supported.")
        };
    }
}