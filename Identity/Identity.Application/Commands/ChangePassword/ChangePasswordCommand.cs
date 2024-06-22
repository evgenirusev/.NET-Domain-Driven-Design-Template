using MediatR;

public class ChangePasswordCommand : IRequest<Result>
{
    public string CurrentPassword { get; set; } = default!;

    public string NewPassword { get; set; } = default!;

    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result>
    {
        private readonly IIdentity identity;
        private readonly ICurrentUser currentUser;

        public ChangePasswordCommandHandler(
            IIdentity identity,
            ICurrentUser currentUser)
        {
            this.identity = identity;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(
            ChangePasswordCommand request,
            CancellationToken cancellationToken)
            => await identity.ChangePassword(new ChangePasswordRequestModel(
                currentUser.UserId,
                request.CurrentPassword,
                request.NewPassword));
    }
}