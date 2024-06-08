namespace BettingSystem.Application.Betting.Gamblers.Commands.Create;

public class CreateGamblerResponseModel
{
    internal CreateGamblerResponseModel(int gamblerId)
        => this.GamblerId = gamblerId;

    public int GamblerId { get; }
}