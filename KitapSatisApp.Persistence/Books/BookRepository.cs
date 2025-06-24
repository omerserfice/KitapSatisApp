using KitapSatisApp.Application.Contracts;
using KitapSatisApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatisApp.Persistence.Books
{
	public class BookRepository(KitapSatisDbContext context) :GenericRepository<Book,int>(context), IBookRepository
	{

	}
}
