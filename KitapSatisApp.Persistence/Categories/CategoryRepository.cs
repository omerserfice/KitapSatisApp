
using KitapSatisApp.Application.Contracts;
using KitapSatisApp.Domain.Entites;

namespace KitapSatisApp.Persistence.Categories
{
	public class CategoryRepository(KitapSatisDbContext context) : GenericRepository<Category, int>(context), ICategoryRepository
	{
	}
}
