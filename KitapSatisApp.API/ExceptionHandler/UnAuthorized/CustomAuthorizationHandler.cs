using KitapSatisApp.Domain.Entites.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using System.Text.Json;

namespace KitapSatisApp.API.ExceptionHandler.UnAuthorized
{
	public class CustomAuthorizationHandler : IAuthorizationMiddlewareResultHandler
	{
		private readonly AuthorizationMiddlewareResultHandler amr = new();
		public async Task HandleAsync(
		RequestDelegate next,
		HttpContext context,
		AuthorizationPolicy policy,
		PolicyAuthorizationResult authorizeResult)
		{
			if (authorizeResult.Forbidden || authorizeResult.Challenged)
			{
				context.Response.StatusCode = StatusCodes.Status401Unauthorized;
				context.Response.ContentType = "application/json";

				var errorDetails = new ErrorDetails
				{
					StatusCode = 401,
					Message = "Bu işlemi gerçekleştirmek için giriş yapmanız gerekmektedir."
				};

				await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
				return;
			}

			await amr.HandleAsync(next, context, policy, authorizeResult);
		}
	}
}
