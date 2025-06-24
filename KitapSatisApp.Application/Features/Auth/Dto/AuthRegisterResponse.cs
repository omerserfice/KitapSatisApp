namespace KitapSatisApp.Application.Features.Auth.Dto
{
	public record AuthRegisterResponse(bool IsSuccessful,int StatusCode, string Message);
}
