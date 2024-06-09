using System.ComponentModel.DataAnnotations;

namespace Library.Backend.Data.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}
