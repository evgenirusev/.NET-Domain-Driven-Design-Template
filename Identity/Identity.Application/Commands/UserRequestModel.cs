public abstract class UserRequestModel
{
    protected UserRequestModel(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; }

    public string Password { get; }
}