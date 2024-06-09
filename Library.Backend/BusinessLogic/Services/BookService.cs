using Library.Backend.BusinessLogic.Constants;
using Library.Backend.BusinessLogic.DTOs.BookDTOs;
using Library.Backend.BusinessLogic.Interfaces;
using Library.Backend.Data.Entities;
using Library.Backend.Data.Interfaces;

namespace Library.Backend.BusinessLogic.Services;

public class BookService(IBookInterface bookInterface) : IBookService
{
    private readonly IBookInterface _bookInterface = bookInterface;

    public async Task CreateBookAsync(AddBookDTO addBook)
    {
        if (addBook == null) throw new CustomException("Book was null");

        var book = (Book)addBook;
        await _bookInterface.Create(book);
    }

    public async Task DeleteBookAsync(string id)
    {
        var book = await _bookInterface.GetByIdAsync(id);
        if (book is null) throw new CustomException("Book not found!");

        await _bookInterface.DeleteByIdAsync(id);
    }

    public async Task<List<BookDTO>> GetAllBooksAsync()
    {
        var books = await _bookInterface.GetAllAsync();
        return books.Select(i => (BookDTO)i).ToList();
    }

    public async Task<BookDTO> GetBookById(string id)
    {
        var book = await _bookInterface.GetByIdAsync(id);
        if (book is null) throw new CustomException("Book not found!");

        return (BookDTO)book;
    }

    public async Task<List<BookDTO>> GetBooksWithPage(int pageNumber, int pageSize)
    {
        var books = await _bookInterface.GetPagedAsync(pageNumber, pageSize);
        return books.Select(i => (BookDTO)i).ToList();
    }

    public async Task UpdateBookAsync(UpdateBookDTO updateBook)
    {
        var book = await _bookInterface.GetByIdAsync(updateBook.Id);
        if (book is null) throw new CustomException("Book not found!");

        var updBook = (Book)updateBook;
        await _bookInterface.Update(updBook);
    }
}
