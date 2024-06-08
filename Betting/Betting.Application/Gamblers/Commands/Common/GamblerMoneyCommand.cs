namespace BettingSystem.Application.Betting.Gamblers.Commands.Common;

using Application.Common;

public abstract class GamblerMoneyCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public decimal Amount { get; set; }
}