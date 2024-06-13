using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gandalan.IDAS.Contracts.Repositories;

public interface IRepository<T> where T : class
{
    void Add(T entity, bool saveImmediately);
    void AddOrUpdate(T entity, bool saveImmediately);
    void AddOrUpdateRange(IEnumerable<T> range, bool saveImmediately);
    IQueryable<T> Query();
    void Replace(T oldEntity, T newEntity, bool saveImmediately);
    T Create();
    void Remove(T entity, bool saveImmediately);
    void RemoveAll(bool saveImmediately);
    void RemoveRange(IEnumerable<T> range, bool saveImmediately);
    bool Exists(T entity);
    bool Save();
    void Update(T entity, bool saveImmediately);
    T Get(long id);
    T GetOrCreate(long id);
    IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
    IQueryable<T> GetAllForRead();
    IQueryable<T> GetAll();
    void CancelChanges(T entity);
}