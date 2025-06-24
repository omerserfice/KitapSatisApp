
using KitapSatisApp.Application.Contracts;
using KitapSatisApp.Domain.Entites.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KitapSatisApp.Persistence
{
	public class GenericRepository<T, TId>(KitapSatisDbContext context) : IGenericRepository<T, TId> where T : BaseEntity<TId>
		where TId : struct
	{

		protected KitapSatisDbContext Context = context;

		private readonly DbSet<T> _dbSet = context.Set<T>();	
		public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);

		public Task<bool> AnyAsync(TId id) => _dbSet.AnyAsync(x => x.Id.Equals(id));

		public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) => _dbSet.AnyAsync(predicate);	

		public void Delete(T entity) => _dbSet.Remove(entity);

		public Task<List<T>> GetAllAsync() => _dbSet.ToListAsync();

		public ValueTask<T?> GetByIdAsync(TId id) => _dbSet.FindAsync(id);

		public void Update(T entity) => _dbSet.Update(entity);

		public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);	
	}
}
