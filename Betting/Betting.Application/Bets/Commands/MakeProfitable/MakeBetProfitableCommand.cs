namespace BettingSystem.Application.Betting.Bets.Commands.MakeProfitable;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Exceptions;
using Domain.Betting.Repositories;
using MediatR;

public class MakeBetProfitableCommand : EntityCommand<int>, IRequest<Result>
{
    public class MakeBetProfitableCommandHandler : IRequestHandler<MakeBetProfitableCommand, Result>
    {
        private readonly IBetDomainRepository betRepository;

        public MakeBetProfitableCommandHandler(IBetDomainRepository betRepository)
            => this.betRepository = betRepository;

        public async Task<Result> Handle(
            MakeBetProfitableCommand request,
            CancellationToken cancellationToken)
        {
            var bet = await this.betRepository.Find(
                request.Id,
                cancellationToken);

            if (bet == null)
            {
                throw new NotFoundException(nameof(bet), request.Id);
            }

            bet.MakeProfitable();

            await this.betRepository.Save(bet, cancellationToken);

            return Result.Success;
        }
    }
}