using KitapSatisApp.API.ExceptionHandler;
using KitapSatisApp.Application.Features.Books;
using KitapSatisApp.Application.Features.Books.Create;
using KitapSatisApp.Application.Features.Books.Update;
using Microsoft.AspNetCore.Mvc;


namespace KitapSatisApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController(IBookService bookService) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			
			var books = await bookService.GetAllAsyncList();
			return Ok(books);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var book = await bookService.GetByIdAsync(id);
			if (book is null)
			{
				throw new BookNotFoundException(id);
			}
			return Ok(book);


		}
		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateBookRequest request)
		{
			var response = await bookService.CreateAsync(request);
			return StatusCode(response.StatusCode, response);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateBookRequest request)
		{
				await bookService.UpdateAsync(id, request);
				return NoContent();
			
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			
				await bookService.DeleteAsync(id);
				return NoContent();
			
		}
	}
}
