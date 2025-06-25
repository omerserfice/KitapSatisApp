
using KitapSatisApp.Application.Contracts;
using KitapSatisApp.Application.Features.Auth;
using KitapSatisApp.Application.Features.Books;
using KitapSatisApp.Application.Features.Categories;
using KitapSatisApp.Persistence.Auth;
using KitapSatisApp.Persistence.Books;
using KitapSatisApp.Persistence.Categories;
using Microsoft.Extensions.DependencyInjection;

namespace KitapSatisApp.Persistence.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddProjectServices(this IServiceCollection services)
		{
		
			services.AddScoped<IBookRepository, BookRepository>();
			services.AddScoped<IAuthRepository, AuthRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();

		
			services.AddScoped<IBookService, BookService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IAuthService, AuthService>();

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<JwtService>();
			

			return services;
		}
	}
}
