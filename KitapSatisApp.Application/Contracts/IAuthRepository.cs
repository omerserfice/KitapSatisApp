
using KitapSatisApp.Domain.Entites;

namespace KitapSatisApp.Application.Contracts
{
	public interface IAuthRepository : IGenericRepository<User, int>
	{
		Task<User> GetUserByEmail(string email);
	}
}
