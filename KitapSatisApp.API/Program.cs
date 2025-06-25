using KitapSatisApp.API.ExceptionHandler.NotFound;
using KitapSatisApp.API.ExceptionHandler.UnAuthorized;
using KitapSatisApp.Domain.Entites.Common;
using KitapSatisApp.Persistence.Extensions;
using Microsoft.AspNetCore.Authorization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddProjectServices();
builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, CustomAuthorizationHandler>();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddAutoMapperProfiles();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseHsts();
}

app.UseExceptionHandler(appError =>
{
	appError.Run(async context =>
	{
		
		var contextFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();

		if (contextFeature is not null)
		{
			var exception = contextFeature.Error;

			context.Response.ContentType = "application/json";

			if (exception is NotFoundException)
			{
				context.Response.StatusCode = StatusCodes.Status404NotFound;
				await context.Response.WriteAsync(new ErrorDetails
				{
					StatusCode = context.Response.StatusCode,
					Message = exception.Message
				}.ToString());
			} 
			else
			{
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;
				await context.Response.WriteAsync(new ErrorDetails
				{
					StatusCode = context.Response.StatusCode,
					Message = "Internal Server Error"
				}.ToString());
			}
		}
	});
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
