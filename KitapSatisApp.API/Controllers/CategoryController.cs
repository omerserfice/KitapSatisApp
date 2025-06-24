using KitapSatisApp.API.ExceptionHandler;
using KitapSatisApp.Application.Features.Categories;
using KitapSatisApp.Application.Features.Categories.Create;
using KitapSatisApp.Application.Features.Categories.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KitapSatisApp.API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController(ICategoryService categoryService) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var categories = await categoryService.GetAllAsyncList();
			return Ok(categories);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var category = await categoryService.GetByIdAsync(id);
			if (category is null)
			{
				throw new CategoryNotFoundException(id);
			}
			return Ok(category);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryRequest request)
		{
			var response = await categoryService.CreateAsync(request);
			return StatusCode(response.StatusCode, response);
		}
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateCategoryRequest request)
		{
			await categoryService.UpdateAsync(id, request);
			return NoContent();
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var category = await categoryService.GetByIdAsync(id);
			if (category is null)
			{
				throw new CategoryNotFoundException(id);
			}
			await categoryService.DeleteAsync(id);
			return NoContent();
		}
	}
}
