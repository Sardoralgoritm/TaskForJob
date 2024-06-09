using Library.Backend.Data.Entities;

namespace Library.Backend.BusinessLogic.DTOs.BookDTOs;

public class UpdateBookDTO
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;


    public static implicit operator Book(UpdateBookDTO updateBookDTO)
        => new Book()
        {
            Id = updateBookDTO.Id,
            Title = updateBookDTO.Title,
            Author = updateBookDTO.Author,
            CategoryName = updateBookDTO.CategoryName
        };
}
