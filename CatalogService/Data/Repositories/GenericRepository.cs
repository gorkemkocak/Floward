using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly CatalogContext _context;
    
    public GenericRepository(CatalogContext context)
    {
        _context = context;
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }
    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }
    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }
}