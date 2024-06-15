public class EntityCommand
{
    public int Id { get; set; } = default!;
}

public static class EntityCommandExtensions
{
    public static TCommand SetId<TCommand>(this TCommand command, int id)
        where TCommand : EntityCommand
    {
        command.Id = id;
        return command;
    }
}