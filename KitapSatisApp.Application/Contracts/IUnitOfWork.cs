
namespace KitapSatisApp.Application.Contracts
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync();
	}
}
