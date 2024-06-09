namespace Library.Backend.BusinessLogic.DTOs.UserDTOs;

public class LoginResult
{
    public string Id { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime ExpireAt { get; set; }
}