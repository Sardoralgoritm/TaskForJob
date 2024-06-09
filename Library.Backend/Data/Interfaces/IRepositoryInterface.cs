namespace Library.Backend.Data.Interfaces;

public interface IRepositoryInterface<T> where T : class
{
    Task Create(T entity);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(string Id);
    Task Update(T entity);
    Task DeleteByIdAsync(string Id);
}
