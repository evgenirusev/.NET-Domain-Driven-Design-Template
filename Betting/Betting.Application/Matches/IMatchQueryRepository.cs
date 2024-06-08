namespace BettingSystem.Application.Betting.Matches;

using Common.Contracts;
using Domain.Betting.Models.Matches;

public interface IMatchQueryRepository : IQueryRepository<Match>
{
}