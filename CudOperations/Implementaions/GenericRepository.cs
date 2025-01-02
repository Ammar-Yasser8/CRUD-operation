using System.Linq.Expressions;
using CudOperations.Data;
using CudOperations.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CudOperations.Implementaions;

public class GenericRepository<T> : IGenericRepository<T> where T : class   
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context; 
        _dbSet = _context.Set<T>();
    }

    public ICollection<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? include =null)
    {
        var query = _dbSet.AsQueryable();
        if (predicate != null)
        {
            return query.Where(predicate).ToList(); 
        }
        if (include != null)
        {
            include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(entity =>
                {
                    query = query.Include(entity);
                });
        }
        return query.ToList();  
    }

    public T GetOne(Expression<Func<T, bool>>? predicate, string? include)
    {
        var query = _dbSet.AsQueryable();
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        if (include != null)
        {
            include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(entity =>
                {
                    query = query.Include(entity);
                });
        }
        return query.SingleOrDefault();
    
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity); 
    }

    public void Update(T entity)
    {
       _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);  
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);   
    }

    public int Save()
    {
       return _context.SaveChanges(); 
    }
}