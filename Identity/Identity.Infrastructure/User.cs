using Microsoft.AspNetCore.Identity;

public class User : IdentityUser, IUser
{
    internal User(string email)
        : base(email)
        => Email = email;
}