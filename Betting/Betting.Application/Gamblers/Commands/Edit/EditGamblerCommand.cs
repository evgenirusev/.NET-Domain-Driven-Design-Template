namespace BettingSystem.Application.Betting.Gamblers.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Contracts;
using Common;
using Domain.Betting.Repositories;
using MediatR;

public class EditGamblerCommand : GamblerCommand<EditGamblerCommand>, IRequest<Result>
{
    public class EditGamblerCommandHandler : IRequestHandler<EditGamblerCommand, Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly IGamblerDomainRepository gamblerRepository;

        public EditGamblerCommandHandler(
            ICurrentUser currentUser,
            IGamblerDomainRepository gamblerRepository)
        {
            this.currentUser = currentUser;
            this.gamblerRepository = gamblerRepository;
        }

        public async Task<Result> Handle(
            EditGamblerCommand request,
            CancellationToken cancellationToken)
        {
            var gambler = await this.gamblerRepository.FindByUser(
                this.currentUser.UserId,
                cancellationToken);

            if (request.Id != gambler.Id)
            {
                return "You cannot edit this profile.";
            }

            gambler.UpdateName(request.Name);

            await this.gamblerRepository.Save(gambler, cancellationToken);

            return Result.Success;
        }
    }
}