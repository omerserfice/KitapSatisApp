
using KitapSatisApp.Application.Features.Auth;
using KitapSatisApp.Application.Features.Books;
using KitapSatisApp.Application.Features.Categories;
using Microsoft.Extensions.DependencyInjection;

namespace KitapSatisApp.Persistence.Extensions
{
	public static class AutoMapperExtension
	{
		public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
		{
			services.AddAutoMapper(
				typeof(BookMappingProfile),
				typeof(AuthMappingProfile),
				typeof(CategoryMappingProfile)
			);

			return services;
		}
	}
}
