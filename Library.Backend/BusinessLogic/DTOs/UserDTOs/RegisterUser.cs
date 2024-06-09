using Library.Backend.Data.Entities;

namespace Library.Backend.BusinessLogic.DTOs.UserDTOs;

public class RegisterUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;


    public static implicit operator User(RegisterUser user)
        => new User()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            EmailConfirmed = true,
            UserName = user.Email
        };
}
