
using System.Linq.Expressions;

namespace KitapSatisApp.Application.Contracts
{
	public interface IGenericRepository<T,TId> where T : class 	where TId : struct
	{
		Task<bool> AnyAsync(TId id);
		Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllAsync();
		Task<List<T>> GetAllAsync(params string[] includes);
		IQueryable<T> Where(Expression<Func<T, bool>> predicate);
		ValueTask<T?> GetByIdAsync(TId id);
		ValueTask AddAsync(T entity);
		void Update(T entity);
		void Delete(T entity);
	} 
	
}
