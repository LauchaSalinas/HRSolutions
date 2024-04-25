using HRSolutions.UseCases.Interfaces;
using HRSolutions.DataAccess.Persistence;
using HRSolutions.Domain.Entities;
using HRSolutions.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRSolutions.DataAccess.Implementations
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        protected readonly HRSolutionsContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(HRSolutionsContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = (await DbSet.AddAsync(entity)).Entity;
            await Context.SaveChangesAsync();

            return addedEntity;
        }

        public async Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var removedEntity = DbSet.Remove(DbSet.Where(predicate).First()).Entity;
            await Context.SaveChangesAsync();

            return removedEntity;
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await DbSet.Where(predicate).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();

            return entity;
        }
    }
}
