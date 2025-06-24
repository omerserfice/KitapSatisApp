namespace KitapSatisApp.Application.Features.Books.Update
{
	public record UpdateBookRequest(string BookName,decimal Price,string Writer, int PublicationYear, int CategoryId);
}
