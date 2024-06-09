using Library.Backend.Data.Entities;

namespace Library.Backend.BusinessLogic.DTOs.BookDTOs;

public class AddBookDTO
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;


    public static implicit operator Book(AddBookDTO dto)
        => new Book()
        {
            Id = Guid.NewGuid().ToString(),
            Title = dto.Title,
            Author = dto.Author,
            CategoryName = dto.CategoryName
        };
}