using MediatR;

public class LoginUserCommand : UserRequestModel, IRequest<Result<UserResponseModel>>
{
    public LoginUserCommand(string email, string password)
        : base(email, password)
    {
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<UserResponseModel>>
    {
        private readonly IIdentity identity;

        public LoginUserCommandHandler(IIdentity identity)
            => this.identity = identity;

        public async Task<Result<UserResponseModel>> Handle(
            LoginUserCommand request,
            CancellationToken cancellationToken)
            => await this.identity.Login(request);
    }
}