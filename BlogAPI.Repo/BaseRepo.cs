namespace BlogAPI.BaseRepo;

using BlogAPI.Database;
using BlogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class BaseRepo<T> where T : class
{
    protected readonly DatabaseContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    protected BaseRepo(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public virtual async Task<T> CreateOne(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<List<T>> GetAll()
    {
        var entities = await _dbSet.ToListAsync();
        return entities;
    }

    public virtual async Task<T?> GetOne(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is null)
        {
            return null;
        }
        return entity;
    }

    public virtual async Task<T> UpdateOne(T entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<bool> DeleteOne(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is null)
        {
            return false;
        }
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}