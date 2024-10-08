using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MSMS.Infrastructure.Data;

namespace MSMS.Infrastructure.Common
{
    public class Repository : IRepository
    {
        private MSMSDbContext _context;

        public Repository(MSMSDbContext context)
        {
            _context = context;
        }

        private DbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            DbSet<TEntity>().Add(entity);
        }

        public void AddRange<TEntity>(List<TEntity> entities) where TEntity : class
        {
            DbSet<TEntity>().AddRange(entities);
        }

        public IQueryable<TEntity> All<TEntity>() where TEntity : class
        {
            return DbSet<TEntity>();
        }

        public IQueryable<TEntity> AllReadOnly<TEntity>() where TEntity : class
        {
            return DbSet<TEntity>()
                .AsNoTracking();
        }

        public TEntity? GetById<TEntity>(int id) where TEntity : class
        {
            return DbSet<TEntity>()
                .Find(id);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            DbSet<TEntity>()
                .Remove(entity);
        }

        public void RemoveRange<TEntity>(ICollection<TEntity> entities) where TEntity : class
        {
            DbSet<TEntity>()
                .RemoveRange(entities);
        }

        int IRepository.SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
