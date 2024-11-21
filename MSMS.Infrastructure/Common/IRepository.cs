using System;
using System.Linq.Expressions;

namespace MSMS.Infrastructure.Common
{
    public interface IRepository
    {
        IQueryable<TEntity> All<TEntity>() where TEntity : class;
        IQueryable<TEntity> AllReadOnly<TEntity>() where TEntity : class;
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
        Task AddRangeAsync<TEntity>(List<TEntity> entities) where TEntity : class;
        Task <TEntity?> GetByIdAsync<TEntity>(int id) where TEntity : class;
        Task RemoveAsync<TEntity>(TEntity entity) where TEntity : class;
        Task RemoveRangeAsync<TEntity>(ICollection<TEntity> entities) where TEntity : class;
        Task<int> SaveChangesAsync();
        Task LoadReferenceAsync<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty?>> property) where TEntity : class where TProperty : class;
        Task LoadCollectionAsync<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty?>>> property) where TEntity : class where TProperty : class;

    }
}
