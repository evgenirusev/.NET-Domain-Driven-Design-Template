namespace BettingSystem.Application.Betting.Gamblers.Commands.Common;

using Application.Common;

public abstract class GamblerCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public string Name { get; set; } = default!;
}