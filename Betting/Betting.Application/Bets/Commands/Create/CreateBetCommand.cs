namespace BettingSystem.Application.Betting.Bets.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Contracts;
using Common.Exceptions;
using Domain.Betting.Factories.Bets;
using Domain.Betting.Models.Bets;
using Domain.Betting.Models.Matches;
using Domain.Betting.Repositories;
using Domain.Common.Models;
using MediatR;

public class CreateBetCommand : IRequest<Result<CreateBetResponseModel>>
{
    public int MatchId { get; set; }

    public decimal Amount { get; set; }

    public int Prediction { get; set; }

    public class CreateBetCommandHandler : IRequestHandler<CreateBetCommand, Result<CreateBetResponseModel>>
    {
        private readonly ICurrentUser currentUser;
        private readonly IBetFactory betFactory;
        private readonly IMatchDomainRepository matchRepository;
        private readonly IGamblerDomainRepository gamblerRepository;

        public CreateBetCommandHandler(
            ICurrentUser currentUser,
            IBetFactory betFactory,
            IMatchDomainRepository matchRepository,
            IGamblerDomainRepository gamblerRepository)
        {
            this.currentUser = currentUser;
            this.betFactory = betFactory;
            this.matchRepository = matchRepository;
            this.gamblerRepository = gamblerRepository;
        }

        public async Task<Result<CreateBetResponseModel>> Handle(
            CreateBetCommand request,
            CancellationToken cancellationToken)
        {
            var gambler = await this.gamblerRepository.FindByUser(
                this.currentUser.UserId,
                cancellationToken);

            var match = await this.matchRepository.Find(
                request.MatchId,
                cancellationToken);

            if (match == null)
            {
                throw new NotFoundException(nameof(match), request.MatchId);
            }

            if (match.Status == Status.Finished ||
                match.Status == Status.Cancelled)
            {
                return $"You cannot make bets on {match.Status} match.";
            }

            var bet = this.betFactory
                .WithMatch(match)
                .WithAmount(request.Amount)
                .WithPrediction(Enumeration.FromValue<Prediction>(
                    request.Prediction))
                .Build();

            gambler
                .AddBet(bet)
                .Withdraw(request.Amount);

            await this.gamblerRepository.Save(gambler, cancellationToken);

            return new CreateBetResponseModel(bet.Id);
        }
    }
}