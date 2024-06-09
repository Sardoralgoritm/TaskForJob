using Library.Backend.Data.Entities;
using Library.Backend.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Backend.Data.Repositories;

public class Repository<T>(AppDbContext appDb) : IRepositoryInterface<T> where T : BaseEntity
{
    private readonly AppDbContext _appDb = appDb;
    private readonly DbSet<T> _dbSet = appDb.Set<T>();

    public async Task Create(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _appDb.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(string Id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(i => i.Id == Id);
        _dbSet.Remove(entity!);
        await _appDb.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
        => await _dbSet.AsNoTracking().ToListAsync();

    public async Task<T> GetByIdAsync(string Id)
        => await _dbSet.AsNoTracking().FirstOrDefaultAsync(i => i.Id == Id);

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await _appDb.SaveChangesAsync();
    }
}
