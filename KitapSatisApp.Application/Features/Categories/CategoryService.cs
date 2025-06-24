using AutoMapper;
using KitapSatisApp.Application.Contracts;
using KitapSatisApp.Application.Features.Categories.Create;
using KitapSatisApp.Application.Features.Categories.Dto;
using KitapSatisApp.Application.Features.Categories.Update;
using KitapSatisApp.Domain.Entites;
using System.Net;

namespace KitapSatisApp.Application.Features.Categories
{
	public class CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper) : ICategoryService
	{
		public async Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request)
		{
			var anyCategory = categoryRepository.AnyAsync(x => x.CategoryName == request.CategoryName);
			if (anyCategory.Result)
			{


			}
			var category = mapper.Map<Category>(request);
			await categoryRepository.AddAsync(category);
			await unitOfWork.SaveChangesAsync();

			return new CreateCategoryResponse
				(
				Id: category.Id,
				CategoryName: category.CategoryName,
				StatusCode: (int)HttpStatusCode.Created,
				Message: "Kategori başarıyla eklendi."
				);
		}

		public async Task DeleteAsync(int id)
		{
			var category = await categoryRepository.GetByIdAsync(id);
			categoryRepository.Delete(category!);
			await unitOfWork.SaveChangesAsync();
			return;

		}

		public async Task<List<CategoryDto>> GetAllAsyncList()
		{
			var categories = await categoryRepository.GetAllAsync();
			if (categories is null)
			{
				throw new Exception("kategori bulunamadı.");
			}
			var categoriesDto = mapper.Map<List<CategoryDto>>(categories);
			return categoriesDto;

		}

		public async Task<CategoryDto?> GetByIdAsync(int id)
		{
			var category = await categoryRepository.GetByIdAsync(id);
			var categoryDto = mapper.Map<CategoryDto>(category);
			return categoryDto;
		}

		public async Task UpdateAsync(int id, UpdateCategoryRequest request)
		{
			var categoryResponse = await categoryRepository.AnyAsync(x => x.CategoryName == request.CategoryName && x.Id != id);
			var category = mapper.Map<Category>(request);
			category.Id = id;
			categoryRepository.Update(category);
			await unitOfWork.SaveChangesAsync();
			return;
		}
	}
}
