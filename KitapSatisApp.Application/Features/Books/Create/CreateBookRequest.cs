
namespace KitapSatisApp.Application.Features.Books.Create
{
	public record  CreateBookRequest(string BookName,decimal Price, string Writer,int PublicationYear,int CategoryId);
}
