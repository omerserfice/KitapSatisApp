using AutoMapper;
using KitapSatisApp.Application.Features.Auth.Dto;
using KitapSatisApp.Domain.Entites;


namespace KitapSatisApp.Application.Features.Auth
{
	public class AuthMappingProfile : Profile 
	{
		public AuthMappingProfile()
		{
			
			CreateMap<RegisterRequestDto, User>();
			CreateMap<LoginRequestDto, User>();
		}
	}
}
