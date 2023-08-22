﻿using System.Linq.Expressions;

namespace MGenericRepository;
public interface IGenericRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Get all entities from db
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="orderBy"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    List<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        params Expression<Func<TEntity, object>>[] includes);

    /// <summary>
    /// Get query for entity
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="orderBy"></param>
    /// <returns></returns>
    IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

    /// <summary>
    /// Get single entity by primary key
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    TEntity GetById(object id);

    /// <summary>
    /// Get first or default entity by filter
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    TEntity GetFirstOrDefault(
        Expression<Func<TEntity, bool>> filter = null,
        params Expression<Func<TEntity, object>>[] includes);

    /// <summary>
    /// Insert entity to db
    /// </summary>
    /// <param name="entity"></param>
    bool Insert(TEntity entity);

    /// <summary>
    /// Update entity in db
    /// </summary>
    /// <param name="entity"></param>
    bool Update(TEntity entity);

    /// <summary>
    /// Delete entity from db by primary key
    /// </summary>
    /// <param name="id"></param>
    bool Delete(TEntity entity);

    IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
    IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

}