namespace KitapSatisApp.Application.Features.Auth.Dto
{
	public record AuthLoginResponse(string Token,string Username,
		string Email, bool IsSuccessful,string Message);
	
}
