using KitapSatisApp.Application.Features.Auth;
using KitapSatisApp.Application.Features.Auth.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KitapSatisApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController(IAuthService authService) : ControllerBase
	{
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
		{
			var response = await authService.RegisterAsync(request);

			if (response is null)
			{
				return BadRequest(new { Message = "Kayıt işlemi başarısız." });

			}
			return StatusCode(response.StatusCode, response);
		}
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
		{
			var response = await authService.LoginAsync(request);
			return Ok(response);
		}
	}

}
