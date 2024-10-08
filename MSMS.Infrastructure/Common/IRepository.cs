using System;

namespace MSMS.Infrastructure.Common
{
    public interface IRepository
    {
        IQueryable<TEntity> All<TEntity>() where TEntity : class;
        IQueryable<TEntity> AllReadOnly<TEntity>() where TEntity : class;
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void AddRange<TEntity>(List<TEntity> entities) where TEntity : class;
        TEntity? GetById<TEntity>(int id) where TEntity : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange<TEntity>(ICollection<TEntity> entities) where TEntity : class;
        int SaveChanges();
    }
}
