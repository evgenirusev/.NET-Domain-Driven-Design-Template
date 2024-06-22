public class ChangePasswordRequestModel
{
    public ChangePasswordRequestModel(
        string userId,
        string currentPassword,
        string newPassword)
    {
        UserId = userId;
        CurrentPassword = currentPassword;
        NewPassword = newPassword;
    }

    public string UserId { get; }

    public string CurrentPassword { get; }

    public string NewPassword { get; }
}