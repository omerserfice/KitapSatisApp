using AutoMapper;
using KitapSatisApp.Application.Features.Books.Create;
using KitapSatisApp.Application.Features.Books.Dto;
using KitapSatisApp.Application.Features.Books.Update;
using KitapSatisApp.Domain.Entites;

namespace KitapSatisApp.Application.Features.Books
{
	public class BookMappingProfile : Profile
	{
		public BookMappingProfile() {

			CreateMap<Book, BookDto>()
				.ForMember(dest => dest.CategoryName,
			opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : string.Empty));
			CreateMap<CreateBookRequest, Book>();
			CreateMap<UpdateBookRequest, Book>();
		}
	}
}
