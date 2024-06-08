namespace BettingSystem.Application.Betting.Bets.Queries.Common;

using Application.Common.Mapping;
using AutoMapper;
using Domain.Betting.Models.Bets;
using Domain.Common.Models;

public class BetResponseModel : IMapFrom<Bet>
{
    public int Id { get; private set; }

    public decimal Amount { get; private set; }

    public int MatchId { get; private set; }

    public string Prediction { get; private set; } = default!;

    public virtual void Mapping(Profile mapper)
        => mapper
            .CreateMap<Bet, BetResponseModel>()
            .ForMember(b => b.Prediction, cfg => cfg
                .MapFrom(b => Enumeration.NameFromValue<Prediction>(
                    b.Prediction.Value)));
}