

using KitapSatisApp.Domain.Entites.Common;

namespace KitapSatisApp.Domain.Entites
{
	public class Book : BaseEntity<int> , IAuditEntity
	{
		public string BookName { get; set; }
		public decimal Price { get; set; }
		public string Writer { get; set; }
		public DateTime PublicationYear { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}
}
