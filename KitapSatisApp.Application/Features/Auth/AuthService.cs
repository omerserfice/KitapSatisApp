using AutoMapper;
using KitapSatisApp.Application.Contracts;
using KitapSatisApp.Application.Features.Auth.Dto;
using KitapSatisApp.Domain.Entites;
using System.Net;

namespace KitapSatisApp.Application.Features.Auth
{
	public class AuthService(IAuthRepository authRepository, IUnitOfWork unitOfWork,IMapper mapper,JwtService jwtService) : IAuthService
	{
		public async Task<AuthLoginResponse> LoginAsync(LoginRequestDto request)
		{
			var user = await authRepository.GetUserByEmail(request.Email);

			if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
			{
				throw new Exception("Kullanıcı bulunamadı veya şifre yanlış.");	
			}

			var token = jwtService.GenerateToken(user);

			return new AuthLoginResponse
			(
				Token: token,
				Username: user.UserName,
				Email: user.Email,
				IsSuccessful: true,
				Message: "Giriş başarılı."
			);

		}

		public async Task<AuthRegisterResponse> RegisterAsync(RegisterRequestDto request)
		{
			var anyUser = authRepository.AnyAsync(x => x.Email == request.Email);
			if (anyUser.Result)
			{
				throw new Exception("Bu email ile kayıtlı bir kullanıcı zaten mevcut.");
			}
			var user = mapper.Map<User>(request);
			user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
			await authRepository.AddAsync(user);
			await unitOfWork.SaveChangesAsync();
			return new AuthRegisterResponse
			(
				IsSuccessful: true,
				StatusCode: (int)HttpStatusCode.Created,
				Message: "Kayıt işlemi başarılı."
			);
		}
	}
}
