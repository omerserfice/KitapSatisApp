using KitapSatisApp.API.ExceptionHandler;
using KitapSatisApp.Application.Contracts;
using KitapSatisApp.Application.Features.Books;
using KitapSatisApp.Domain.Entites.Common;
using KitapSatisApp.Persistence;
using KitapSatisApp.Persistence.Auth;
using KitapSatisApp.Persistence.Books;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<KitapSatisDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthRepository,AuthRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(BookMappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
			}else
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

app.UseAuthorization();

app.MapControllers();

app.Run();
