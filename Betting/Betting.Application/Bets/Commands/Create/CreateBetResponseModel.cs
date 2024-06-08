namespace BettingSystem.Application.Betting.Bets.Commands.Create;

public class CreateBetResponseModel
{
    internal CreateBetResponseModel(int id) => this.Id = id;

    public int Id { get; }
}