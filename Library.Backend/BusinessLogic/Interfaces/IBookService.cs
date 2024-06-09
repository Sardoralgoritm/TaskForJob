using Library.Backend.BusinessLogic.DTOs.BookDTOs;

namespace Library.Backend.BusinessLogic.Interfaces;

public interface IBookService
{
    Task CreateBookAsync(AddBookDTO addBook);
    Task<List<BookDTO>> GetAllBooksAsync();
    Task<List<BookDTO>> GetBooksWithPage(int pageNumber, int pageSize);
    Task<BookDTO> GetBookById(string id);
    Task UpdateBookAsync(UpdateBookDTO updateBook);
    Task DeleteBookAsync(string id);
}
