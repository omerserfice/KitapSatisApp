using Microsoft.OpenApi.Models;


namespace KitapSatisApp.Persistence.Extensions
{
	public static class SwaggerExtension
	{
		public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "KitapSatisApp",
					Version = "v1",
					Description = "Kitap Satış Uygulaması API",
					Contact = new OpenApiContact
					{
						Name = "Ömer Serfice",
						Email = "srfcomr@gmail.com",
						Url = new Uri("https://www.omerserfice.com.tr")
					}
				});

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "JWT Authorization header using the Bearer scheme.",
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						Array.Empty<string>()
					}
				});
			});

			return services;
		}
	}
}
