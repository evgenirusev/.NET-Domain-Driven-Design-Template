namespace BettingSystem.Application.Betting.Bets.Queries.Mine;

using AutoMapper;
using Details;
using Domain.Betting.Models.Bets;

public class MineBetResponseModel : BetDetailsResponseModel
{
    public override void Mapping(Profile mapper)
        => mapper
            .CreateMap<Bet, MineBetResponseModel>()
            .IncludeBase<Bet, BetDetailsResponseModel>();
}