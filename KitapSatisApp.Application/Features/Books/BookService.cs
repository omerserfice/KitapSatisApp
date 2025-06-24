
using AutoMapper;
using KitapSatisApp.Application.Contracts;
using KitapSatisApp.Application.Features.Books.Create;
using KitapSatisApp.Application.Features.Books.Dto;
using KitapSatisApp.Application.Features.Books.Update;
using KitapSatisApp.Domain.Entites;
using System.Net;

namespace KitapSatisApp.Application.Features.Books
{
	public class BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork, IMapper mapper) : IBookService
	{
		public async Task<CreateBookResponse> CreateAsync(CreateBookRequest request)
		{
			var anyBook = bookRepository.AnyAsync(x => x.BookName == request.BookName);
			if (anyBook.Result)
			{
				throw new Exception("veritabanında bu kitap mevcut.");
			}

			var book = mapper.Map<Book>(request);

			await bookRepository.AddAsync(book);
			await unitOfWork.SaveChangesAsync();
			return new CreateBookResponse
			(
			  Id: book.Id,
			  BookName: book.BookName,
			  StatusCode: (int)HttpStatusCode.Created,
			  Message: "Kitap başarıyla eklendi."

			);

		}

		public async Task DeleteAsync(int id)
		{
			var book = await bookRepository.GetByIdAsync(id);
			if (book is null)
			{
				throw new Exception("Bu id'ye sahip kitap bulunamadı.");
			}
			bookRepository.Delete(book!);
			await unitOfWork.SaveChangesAsync();
			return;
		}

		public async Task<List<BookDto>> GetAllAsyncList()
		{
			var books = await bookRepository.GetAllAsync();
			if (books is null)
			{
				throw new Exception("Veritabanında kitap bulunamadı.");
			}
			var booksDto = mapper.Map<List<BookDto>>(books.ToList());
			return booksDto;

		}

		public async Task<BookDto?> GetByIdAsync(int id)
		{
			var book = await bookRepository.GetByIdAsync(id);
			var booksDto = mapper.Map<BookDto>(book);	
			return booksDto;
		}

		public async Task UpdateAsync(int id, UpdateBookRequest request)
		{
			 var isBookExist = await bookRepository.AnyAsync(x => x.BookName == request.BookName && x.Id == id);

			 if (isBookExist)
			 {
				 throw new Exception("Kitap bulunamadı.");
			}
			 var book = mapper.Map<Book>(request);
			book.Id = id;
			bookRepository.Update(book);
			await unitOfWork.SaveChangesAsync();
			return;

		}
	}
}
