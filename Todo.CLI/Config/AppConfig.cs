using Todo.CLI.Services.Trello;

namespace Todo.CLI.Config;

public class AppConfig
{
    public string Service { get; set; }

    public TrelloConfig Trello { get; set; }
}