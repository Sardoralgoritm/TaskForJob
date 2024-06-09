using Library.Backend.BusinessLogic.DTOs.UserDTOs;

namespace Library.Backend.BusinessLogic.Interfaces;

public interface IUserService
{
    Task RegisterAsync(RegisterUser user);
    Task<LoginResult> LoginAsync(LoginUser user);
}
