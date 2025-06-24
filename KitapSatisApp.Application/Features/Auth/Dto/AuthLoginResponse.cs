namespace KitapSatisApp.Application.Features.Auth.Dto
{
	public record AuthLoginResponse(int UserId,string Token,string Username,
		string Email, bool IsSuccessful,string Message);
	
}
