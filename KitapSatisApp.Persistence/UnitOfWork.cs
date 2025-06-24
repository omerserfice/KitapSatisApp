
using KitapSatisApp.Application.Contracts;

namespace KitapSatisApp.Persistence
{
	public class UnitOfWork(KitapSatisDbContext context) : IUnitOfWork
	{
		public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
	}
	
}
