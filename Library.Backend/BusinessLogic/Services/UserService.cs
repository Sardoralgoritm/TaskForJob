using Library.Backend.BusinessLogic.Constants;
using Library.Backend.BusinessLogic.DTOs.UserDTOs;
using Library.Backend.BusinessLogic.Interfaces;
using Library.Backend.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Library.Backend.BusinessLogic.Services;

public class UserService(UserManager<User> userManager,
                         IConfiguration configuration) : IUserService
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;

    public async Task<LoginResult> LoginAsync(LoginUser user)
    {
        if (user == null) throw new ArgumentNullException("user");

        var availableUser = await _userManager.FindByEmailAsync(user.Email);

        if (availableUser == null) throw new ArgumentNullException("User not found");

        var result = await _userManager.CheckPasswordAsync(availableUser, user.Password);
        if (!result) throw new CustomException("Invalid password");

        var roles = await _userManager.GetRolesAsync(availableUser);

        var token = JwtHelper.GenerateJwtToken(availableUser, roles, _configuration);

        return new LoginResult
        {
            Id = availableUser!.Id,
            FirstName = availableUser.FirstName,
            LastName = availableUser.LastName!,
            Token = token,
            ExpireAt = DateTime.UtcNow.AddHours(5).AddDays(7)
        };
    }

    public async Task RegisterAsync(RegisterUser user)
    {
        if (user == null) throw new ArgumentNullException("user");

        var newUser = (User)user;

        var request = await _userManager.CreateAsync(newUser, user.Password);
        if (!request.Succeeded) throw new ArgumentException($"User creation failed:\n{request.Errors.Select(e => e.Description)}");

        var role = await _userManager.AddToRoleAsync(newUser, "User");
        if (!role.Succeeded) throw new Exception("User role failed!");
    }
}
