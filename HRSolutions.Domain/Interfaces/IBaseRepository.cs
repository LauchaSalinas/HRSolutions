using System.Linq.Expressions;
using HRSolutions.Domain.Entities;
using HRSolutions.Domain.Interfaces;

namespace HRSolutions.UseCases.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class, IAggregateRoot
{
    Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
}
