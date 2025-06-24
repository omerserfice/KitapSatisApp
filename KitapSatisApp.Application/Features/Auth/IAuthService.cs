using KitapSatisApp.Application.Features.Auth.Dto;

namespace KitapSatisApp.Application.Features.Auth
{
	public interface IAuthService
	{
		Task<bool> RegisterAsync(RegisterRequestDto request);
		Task<AuthLoginResponse> LoginAsync(LoginRequestDto request);
	}
}
