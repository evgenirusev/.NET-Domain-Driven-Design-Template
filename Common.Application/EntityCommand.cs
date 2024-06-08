namespace BettingSystem.Application.Common;

public class EntityCommand<TId>
{
    public TId Id { get; set; } = default!;
}

public static class EntityCommandExtensions
{
    public static TCommand SetId<TCommand, TId>(this TCommand command, TId id)
        where TCommand : EntityCommand<TId>
    {
        command.Id = id;
        return command;
    }
}