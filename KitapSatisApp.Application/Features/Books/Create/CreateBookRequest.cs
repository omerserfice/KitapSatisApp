
namespace KitapSatisApp.Application.Features.Books.Create
{
	public record  CreateBookRequest(string BookName,decimal Price, string Writer,DateTime PublicationYear);
}
