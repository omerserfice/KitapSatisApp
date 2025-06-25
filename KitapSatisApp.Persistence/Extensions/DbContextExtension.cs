using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KitapSatisApp.Persistence.Extensions
{
	public static class DbContextExtension
	{
		public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<KitapSatisDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			return services;
		}
	}
}
