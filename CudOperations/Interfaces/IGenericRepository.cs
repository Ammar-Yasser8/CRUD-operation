using System.Linq.Expressions;

namespace CudOperations.Interfaces;

public interface IGenericRepository<T> where T : class
{
    ICollection<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? include = null);
    T? GetOne(Expression<Func<T, bool>>? predicate, string? include = null);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    int Save(); 
}
