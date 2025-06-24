
using KitapSatisApp.Application.Contracts;
using KitapSatisApp.Domain.Entites;

namespace KitapSatisApp.Persistence.Auth
{
	public class AuthRepository(KitapSatisDbContext context) : GenericRepository<User,int>(context), IAuthRepository	
	{
	}
}
