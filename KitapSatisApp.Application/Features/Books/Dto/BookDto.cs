
namespace KitapSatisApp.Application.Features.Books.Dto
{
	public class BookDto
	{
		public int Id { get; set; }
		public string BookName { get; set; }
		public decimal Price { get; set; }
		public string Writer { get; set; }
		public int PublicationYear { get; set; }
		public string CategoryName { get; set; }
	}

}
