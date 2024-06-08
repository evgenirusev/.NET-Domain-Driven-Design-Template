namespace BettingSystem.Application.Betting.Gamblers.Queries.GetId;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Contracts;
using Domain.Betting.Repositories;
using MediatR;

public class GetGamblerIdQuery : IRequest<Result<GetGamblerIdResponseModel>>
{
    public class GetGamblerIdQueryHandler : IRequestHandler<GetGamblerIdQuery, Result<GetGamblerIdResponseModel>>
    {
        private readonly ICurrentUser currentUser;
        private readonly IGamblerDomainRepository gamblerRepository;

        public GetGamblerIdQueryHandler(
            ICurrentUser currentUser,
            IGamblerDomainRepository gamblerRepository)
        {
            this.currentUser = currentUser;
            this.gamblerRepository = gamblerRepository;
        }

        public async Task<Result<GetGamblerIdResponseModel>> Handle(
            GetGamblerIdQuery request,
            CancellationToken cancellationToken)
        {
            var gamblerId = await this.gamblerRepository.GetGamblerId(
                this.currentUser.UserId,
                cancellationToken);

            return new GetGamblerIdResponseModel(gamblerId);
        }
    }
}