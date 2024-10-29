using Microsoft.EntityFrameworkCore;
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

		public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
		{
			await DbSet<TEntity>().AddAsync(entity);
		}

		public Task AddRangeAsync<TEntity>(List<TEntity> entities) where TEntity : class
		{
			return DbSet<TEntity>().AddRangeAsync(entities);
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

		public async Task<TEntity?> GetByIdAsync<TEntity>(int id) where TEntity : class
		{
			return await DbSet<TEntity>()
				.FindAsync(id);
		}

		public Task RemoveAsync<TEntity>(TEntity entity) where TEntity : class
		{
			DbSet<TEntity>()
				.Remove(entity);
			return Task.CompletedTask;
		}

		public Task RemoveRangeAsync<TEntity>(ICollection<TEntity> entities) where TEntity : class
		{
			DbSet<TEntity>()
				.RemoveRange(entities);
			return Task.CompletedTask;
		}

		public Task<int> SaveChangesAsync()
		{
			return _context.SaveChangesAsync();
		}

		private DbSet<TEntity> DbSet<TEntity>() where TEntity : class
		{
			return _context.Set<TEntity>();
		}
	}
}
