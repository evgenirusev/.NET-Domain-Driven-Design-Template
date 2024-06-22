using Microsoft.AspNetCore.Identity;

internal class IdentityService : IIdentity
{
    private const string InvalidErrorMessage = "Invalid credentials.";

    private readonly UserManager<User> userManager;
    private readonly IJwtGenerator jwtGenerator;

    public IdentityService(
        UserManager<User> userManager,
        IJwtGenerator jwtGenerator)
    {
        this.userManager = userManager;
        this.jwtGenerator = jwtGenerator;
    }

    public async Task<Result<IUser>> Register(UserRequestModel userRequest)
    {
        var user = new User(userRequest.Email);

        var identityResult = await userManager.CreateAsync(
            user,
            userRequest.Password);

        var errors = identityResult.Errors.Select(e => e.Description);

        return identityResult.Succeeded
            ? Result<IUser>.SuccessWith(user)
            : Result<IUser>.Failure(errors);
    }

    public async Task<Result<UserResponseModel>> Login(UserRequestModel userRequest)
    {
        var user = await userManager.FindByEmailAsync(userRequest.Email);
        if (user == null)
        {
            return InvalidErrorMessage;
        }

        var passwordValid = await userManager.CheckPasswordAsync(
            user,
            userRequest.Password);

        if (!passwordValid)
        {
            return InvalidErrorMessage;
        }

        var token = await jwtGenerator.GenerateToken(user);

        return new UserResponseModel(token);
    }

    public async Task<Result> ChangePassword(ChangePasswordRequestModel changePasswordRequest)
    {
        var user = await userManager.FindByIdAsync(changePasswordRequest.UserId);

        if (user == null)
        {
            return InvalidErrorMessage;
        }

        var identityResult = await userManager.ChangePasswordAsync(
            user,
            changePasswordRequest.CurrentPassword,
            changePasswordRequest.NewPassword);

        var errors = identityResult.Errors.Select(e => e.Description);

        return identityResult.Succeeded
            ? Result.Success
            : Result.Failure(errors);
    }
}