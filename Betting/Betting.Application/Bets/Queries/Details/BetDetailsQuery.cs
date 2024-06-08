namespace BettingSystem.Application.Betting.Bets.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class BetDetailsQuery : IRequest<BetDetailsResponseModel?>
{
    public int Id { get; set; }

    public class BetDetailsQueryHandler : IRequestHandler<BetDetailsQuery, BetDetailsResponseModel?>
    {
        private readonly IBetQueryRepository betRepository;

        public BetDetailsQueryHandler(IBetQueryRepository betRepository)
            => this.betRepository = betRepository;

        public async Task<BetDetailsResponseModel?> Handle(
            BetDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.betRepository.GetDetails(
                request.Id,
                cancellationToken);
    }
}