using Manatee.Trello;

namespace Todo.CLI.Services.Trello;

public class TrelloService : ITodoService
{
    private readonly TrelloConfig _config;

    public TrelloService(TrelloConfig config)
    {
        _config = config;

        TrelloAuthorization.Default.AppKey = _config.AppKey;
        TrelloAuthorization.Default.UserToken = _config.UserToken;
    }

    public async Task CreateTodo(string description)
    {
        var factory = new TrelloFactory();
        var list = factory.List(_config.ListId);
        await list.Cards.Add(description);
    }
}