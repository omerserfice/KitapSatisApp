
using KitapSatisApp.Application.Contracts;
using KitapSatisApp.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace KitapSatisApp.Persistence.Auth
{
	public class AuthRepository(KitapSatisDbContext context) : GenericRepository<User, int>(context), IAuthRepository
	{
		public async Task<User> GetUserByEmail(string email)
		{
			return await context.Users.FirstOrDefaultAsync(x => x.Email == email);

		}
	}
}
