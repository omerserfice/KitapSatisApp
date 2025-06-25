namespace KitapSatisApp.API.ExceptionHandler.NotFound
{
	public class CategoriesNotFoundException : NotFoundException
	{
		public CategoriesNotFoundException() : base("Kategori listesi bulunamadı.")
		{
		}
	}
}
