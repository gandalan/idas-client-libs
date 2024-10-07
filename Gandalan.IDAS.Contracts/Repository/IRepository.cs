using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Contracts.Repositories;

public interface IRepository<T> where T : class
{
    void Add(T entity, bool saveImmediately = true);
    void AddOrUpdate(T entity, bool saveImmediately = true);
    void AddOrUpdateRange(IEnumerable<T> range, bool saveImmediately = true);
    IQueryable<T> Query();
    void Replace(T oldEntity, T newEntity, bool saveImmediately = true);
    T Create();
    void Remove(T entity, bool saveImmediately = true);
    void RemoveAll(bool saveImmediately = true);
    void RemoveRange(IEnumerable<T> range, bool saveImmediately = true);
    bool Exists(T entity);
    bool Save();
    void Update(T entity, bool saveImmediately = true);
    T Get(long id);
    Task<T> GetAsync(long id);
    T GetOrCreate(long id);
    IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
    IQueryable<T> GetAllForRead();
    IQueryable<T> GetAll();
    void CancelChanges(T entity);
}
