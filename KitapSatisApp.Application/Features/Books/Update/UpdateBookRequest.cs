

namespace KitapSatisApp.Application.Features.Books.Update
{
	public record UpdateBookRequest(string BookName,decimal Price,string Writer, DateTime PublicationYear);
}
