namespace KitapSatisApp.API.ExceptionHandler
{
	public sealed class CategoryNotFoundException : NotFoundException
	{
		public CategoryNotFoundException(int id) : base($"{id} id li kategori bulunamadı.")
		{
		}
	}
}
