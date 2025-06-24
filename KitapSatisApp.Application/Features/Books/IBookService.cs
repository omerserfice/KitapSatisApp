using KitapSatisApp.Application.Features.Books.Create;
using KitapSatisApp.Application.Features.Books.Dto;
using KitapSatisApp.Application.Features.Books.Update;

namespace KitapSatisApp.Application.Features.Books
{
	public interface IBookService
	{
		Task<List<BookDto>> GetAllAsyncList();
		Task<BookDto?> GetByIdAsync(int id);	
		Task<CreateBookResponse> CreateAsync(CreateBookRequest request);
		Task UpdateAsync(int id,UpdateBookRequest request);
		Task DeleteAsync(int id);
	}
}
