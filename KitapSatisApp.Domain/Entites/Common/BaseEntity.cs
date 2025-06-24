
namespace KitapSatisApp.Domain.Entites.Common
{
	public class BaseEntity<T>
	{
		public T Id { get; set; } = default!;
	}
}
