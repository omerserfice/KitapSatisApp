using AutoMapper;
using KitapSatisApp.Application.Features.Categories.Create;
using KitapSatisApp.Application.Features.Categories.Dto;
using KitapSatisApp.Application.Features.Categories.Update;
using KitapSatisApp.Domain.Entites;

namespace KitapSatisApp.Application.Features.Categories
{
	public class CategoryMappingProfile : Profile
	{
		public CategoryMappingProfile()
		{
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<CreateCategoryRequest, Category>();
			CreateMap<UpdateCategoryRequest, Category>();
		}
	}
}
