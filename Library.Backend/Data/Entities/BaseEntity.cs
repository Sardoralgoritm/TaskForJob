using System.ComponentModel.DataAnnotations;

namespace Library.Backend.Data.Entities;

public class BaseEntity
{
    [Required, Key]
    public string Id { get; set; } = string.Empty;
}
