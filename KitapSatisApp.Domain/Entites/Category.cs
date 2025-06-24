using KitapSatisApp.Domain.Entites.Common;

namespace KitapSatisApp.Domain.Entites
{
	public class Category : BaseEntity<int>, IAuditEntity
	{
		public string CategoryName { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }

		public ICollection<Book> Books { get; set; }
	}
}
