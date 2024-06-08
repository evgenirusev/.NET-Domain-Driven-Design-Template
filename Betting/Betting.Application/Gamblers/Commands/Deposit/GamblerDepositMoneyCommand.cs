namespace BettingSystem.Application.Betting.Gamblers.Commands.Deposit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Contracts;
using Common;
using Domain.Betting.Repositories;
using MediatR;

public class GamblerDepositMoneyCommand : GamblerMoneyCommand<GamblerDepositMoneyCommand>, IRequest<Result>
{
    public class GamblerDepositMoneyCommandHandler : IRequestHandler<GamblerDepositMoneyCommand, Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly IGamblerDomainRepository gamblerRepository;

        public GamblerDepositMoneyCommandHandler(
            ICurrentUser currentUser, 
            IGamblerDomainRepository gamblerRepository)
        {
            this.currentUser = currentUser;
            this.gamblerRepository = gamblerRepository;
        }

        public async Task<Result> Handle(
            GamblerDepositMoneyCommand request, 
            CancellationToken cancellationToken)
        {
            var gambler = await this.gamblerRepository.FindByUser(
                this.currentUser.UserId,
                cancellationToken);

            if (request.Id != gambler.Id)
            {
                return "You cannot edit this profile.";
            }

            gambler.Deposit(request.Amount);

            await this.gamblerRepository.Save(gambler, cancellationToken);

            return Result.Success;
        }
    }
}