public class EntityCommand
{
    public Guid Id { get; set; } = default!;
}

public static class EntityCommandExtensions
{
    public static TCommand SetId<TCommand>(this TCommand command, Guid id)
        where TCommand : EntityCommand
    {
        command.Id = id;
        return command;
    }
}