using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MGenericRepository;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    DbContext context;
    DbSet<TEntity> dbSet;

    public GenericRepository(DbContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }
    public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = dbSet;

        foreach (Expression<Func<TEntity, object>> include in includes)
            query = query.Include(include);

        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            query = orderBy(query);

        return query.ToList();
    }
    public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            query = orderBy(query);

        return query;
    }
    public virtual TEntity GetById(object id)
    {
        return dbSet.Find(id);
    }
    public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = dbSet;

        foreach (Expression<Func<TEntity, object>> include in includes)
            query = query.Include(include);

        return query.FirstOrDefault(filter);
    }
    public virtual bool Insert(TEntity entity)
    {
        dbSet.Add(entity);
        context.Entry(entity).State = EntityState.Added;
        return Convert.ToBoolean(context.SaveChanges());
    }
    public virtual bool Update(TEntity entity)
    {
        dbSet.Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
        return Convert.ToBoolean(context.SaveChanges());
    }
    public virtual bool Delete(TEntity entity)
    {
        dbSet.Attach(entity);
        context.Entry(entity).State = EntityState.Deleted;
        return Convert.ToBoolean(context.SaveChanges());
    }
    public virtual IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }
    public virtual IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }
    private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}