namespace KitapSatisApp.API.ExceptionHandler.NotFound
{
	public sealed class CategoryNotFoundException : NotFoundException
	{
		public CategoryNotFoundException(int id) : base($"{id} id li kategori bulunamadı.")
		{
		}
	}
}
