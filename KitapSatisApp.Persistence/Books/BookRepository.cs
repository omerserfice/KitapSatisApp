using KitapSatisApp.Application.Contracts;
using KitapSatisApp.Domain.Entites;

namespace KitapSatisApp.Persistence.Books
{
	public class BookRepository(KitapSatisDbContext context) :GenericRepository<Book,int>(context), IBookRepository
	{

	}
}
