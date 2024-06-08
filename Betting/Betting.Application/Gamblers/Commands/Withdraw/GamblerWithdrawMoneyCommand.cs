namespace BettingSystem.Application.Betting.Gamblers.Commands.Withdraw;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Contracts;
using Common;
using Domain.Betting.Repositories;
using MediatR;

public class GamblerWithdrawMoneyCommand : GamblerMoneyCommand<GamblerWithdrawMoneyCommand>, IRequest<Result>
{
    public class GamblerWithdrawMoneyCommandHandler : IRequestHandler<GamblerWithdrawMoneyCommand, Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly IGamblerDomainRepository gamblerRepository;

        public GamblerWithdrawMoneyCommandHandler(
            ICurrentUser currentUser,
            IGamblerDomainRepository gamblerRepository)
        {
            this.currentUser = currentUser;
            this.gamblerRepository = gamblerRepository;
        }

        public async Task<Result> Handle(
            GamblerWithdrawMoneyCommand request,
            CancellationToken cancellationToken)
        {
            var gambler = await this.gamblerRepository.FindByUser(
                this.currentUser.UserId,
                cancellationToken);

            if (request.Id != gambler.Id)
            {
                return "You cannot edit this profile.";
            }

            gambler.Withdraw(request.Amount);

            await this.gamblerRepository.Save(gambler, cancellationToken);

            return Result.Success;
        }
    }
}