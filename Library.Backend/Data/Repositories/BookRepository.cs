using Library.Backend.Data.Entities;
using Library.Backend.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Backend.Data.Repositories;

public class BookRepository(AppDbContext appDb) : Repository<Book>(appDb), IBookInterface
{
    private readonly AppDbContext _appDb = appDb;

    public async Task<List<Book>> GetPagedAsync(int pageNumber, int pageSize)
    {
        var books = _appDb.Books.AsQueryable();
        books = books.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return await books.AsNoTracking().ToListAsync();
    }
}
