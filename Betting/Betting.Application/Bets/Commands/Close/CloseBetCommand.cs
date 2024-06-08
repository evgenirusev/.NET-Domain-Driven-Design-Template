namespace BettingSystem.Application.Betting.Bets.Commands.Close;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Contracts;
using Common.Exceptions;
using Domain.Betting.Models.Matches;
using Domain.Betting.Repositories;
using MediatR;

public class CloseBetCommand : EntityCommand<int>, IRequest<Result>
{
    public class CloseBetCommandHandler : IRequestHandler<CloseBetCommand, Result>
    {
        private const string InvalidErrorMessage = "You cannot close this bet.";

        private readonly ICurrentUser currentUser;
        private readonly IBetDomainRepository betRepository;
        private readonly IGamblerDomainRepository gamblerRepository;

        public CloseBetCommandHandler(
            ICurrentUser currentUser,
            IBetDomainRepository betRepository,
            IGamblerDomainRepository gamblerRepository)
        {
            this.currentUser = currentUser;
            this.betRepository = betRepository;
            this.gamblerRepository = gamblerRepository;
        }

        public async Task<Result> Handle(
            CloseBetCommand request,
            CancellationToken cancellationToken)
        {
            var gamblerId = await this.gamblerRepository.GetGamblerId(
                this.currentUser.UserId,
                cancellationToken);

            var gamblerHasBet = await this.gamblerRepository.HasBet(
                gamblerId,
                request.Id,
                cancellationToken);

            if (!gamblerHasBet)
            {
                return InvalidErrorMessage;
            }

            var bet = await this.betRepository.Find(
                request.Id,
                cancellationToken);

            if (bet == null)
            {
                throw new NotFoundException(nameof(bet), request.Id);
            }

            var matchStatus = bet.Match.Status;

            if (matchStatus != Status.NotStarted ||
                matchStatus != Status.Cancelled)
            {
                return InvalidErrorMessage;
            }

            return await this.betRepository.Delete(
                request.Id,
                cancellationToken);
        }
    }
}