namespace KitapSatisApp.API.ExceptionHandler
{
	public sealed class BookNotFoundException : NotFoundException
	{
		public BookNotFoundException(int id) : base($"{id} id ye ait kitap bulunamadı.")
		{

		}
		
	}
}
