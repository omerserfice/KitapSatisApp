namespace KitapSatisApp.Application.Features.Auth.Dto
{
	public record RegisterRequestDto(string FirstName,string LastName,string UserName,string Email,string Password);
}
