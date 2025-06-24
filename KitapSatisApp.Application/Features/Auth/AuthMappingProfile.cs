using AutoMapper;
using KitapSatisApp.Application.Features.Auth.Dto;
using KitapSatisApp.Application.Features.Books.Create;
using KitapSatisApp.Application.Features.Books.Dto;
using KitapSatisApp.Application.Features.Books.Update;
using KitapSatisApp.Domain.Entites;
using Microsoft.AspNetCore.Identity.Data;

namespace KitapSatisApp.Application.Features.Auth
{
	public class AuthMappingProfile : Profile 
	{
		public AuthMappingProfile()
		{
			//CreateMap<User, BookDto>().ReverseMap();
			CreateMap<RegisterRequestDto, User>();
			CreateMap<LoginRequestDto, User>();
		}
	}
}
