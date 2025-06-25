namespace KitapSatisApp.API.ExceptionHandler.NotFound
{
	public class BooksNotFoundException : NotFoundException
	{
		public BooksNotFoundException() : base("Kitap listesi bulunamadı.")
		{
		}
	}

}
