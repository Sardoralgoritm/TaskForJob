using Library.Backend.Data.Entities;

namespace Library.Backend.BusinessLogic.DTOs.BookDTOs;

public class BookDTO
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;


    public static implicit operator BookDTO(Book book)
        => new BookDTO()
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            CategoryName = book.CategoryName
        };
}