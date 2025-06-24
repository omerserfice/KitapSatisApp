using KitapSatisApp.Application.Features.Categories.Create;
using KitapSatisApp.Application.Features.Categories.Dto;
using KitapSatisApp.Application.Features.Categories.Update;

namespace KitapSatisApp.Application.Features.Categories
{
	public interface ICategoryService
	{
		Task<List<CategoryDto>> GetAllAsyncList();
		Task<CategoryDto?> GetByIdAsync(int id);
		Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request);
		Task UpdateAsync(int id, UpdateCategoryRequest request);
		Task DeleteAsync(int id);
	}
}
