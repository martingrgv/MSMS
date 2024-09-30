using System;

namespace MSMS.Infrastructure.Data.Common
{
    public interface IRepository
    {
        ICollection<TEntity> All<TEntity>() where TEntity : class;
        IEnumerable<TEntity> AllReadOnly<TEntity>() where TEntity : class;
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void AddRange<TEntity>(List<TEntity> entities) where TEntity : class;
        TEntity? GetById <TEntity>(int id) where TEntity : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange<TEntity>(ICollection<TEntity> entities) where TEntity : class;
        int SaveChanges();
    }
}
