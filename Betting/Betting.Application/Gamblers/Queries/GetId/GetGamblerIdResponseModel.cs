namespace BettingSystem.Application.Betting.Gamblers.Queries.GetId;

public class GetGamblerIdResponseModel
{
    internal GetGamblerIdResponseModel(int id) => this.Id = id;

    public int Id { get; }
}