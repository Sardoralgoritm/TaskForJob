using Library.Backend.Data.Entities;

namespace Library.Backend.Data.Interfaces;

public interface IBookInterface : IRepositoryInterface<Book>
{
    Task<List<Book>> GetPagedAsync(int pageNumber, int pageSize);
}
