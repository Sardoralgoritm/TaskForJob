using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Library.Backend.Data.Entities;

public class User : IdentityUser
{
    [Required, StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;
    [StringLength(200)]
    public string Address { get; set; } = string.Empty;
}
