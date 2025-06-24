
using KitapSatisApp.Domain.Entites;
using System.Linq.Expressions;

namespace KitapSatisApp.Application.Contracts
{
	public interface IBookRepository : IGenericRepository<Book, int>
	{
		
	}
}
