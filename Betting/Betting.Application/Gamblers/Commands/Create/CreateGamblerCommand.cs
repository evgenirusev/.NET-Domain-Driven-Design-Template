namespace BettingSystem.Application.Betting.Gamblers.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Contracts;
using Common;
using Domain.Betting.Factories.Gamblers;
using Domain.Betting.Repositories;
using MediatR;

public class CreateGamblerCommand : GamblerCommand<CreateGamblerCommand>, IRequest<CreateGamblerResponseModel>
{
    public class CreateGamblerCommandHandler : IRequestHandler<CreateGamblerCommand, CreateGamblerResponseModel>
    {
        private readonly ICurrentUser currentUser;
        private readonly IGamblerFactory gamblerFactory;
        private readonly IGamblerDomainRepository gamblerRepository;

        public CreateGamblerCommandHandler(
            ICurrentUser currentUser,
            IGamblerFactory gamblerFactory,
            IGamblerDomainRepository gamblerRepository)
        {
            this.currentUser = currentUser;
            this.gamblerFactory = gamblerFactory;
            this.gamblerRepository = gamblerRepository;
        }

        public async Task<CreateGamblerResponseModel> Handle(
            CreateGamblerCommand request,
            CancellationToken cancellationToken)
        {
            var gambler = this.gamblerFactory
                .WithName(request.Name)
                .FromUser(this.currentUser.UserId)
                .Build();

            await this.gamblerRepository.Save(gambler, cancellationToken);

            return new CreateGamblerResponseModel(gambler.Id);
        }
    }
}