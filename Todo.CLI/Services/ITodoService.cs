namespace Todo.CLI.Services;

public interface ITodoService
{
    Task CreateTodo(string description);
}