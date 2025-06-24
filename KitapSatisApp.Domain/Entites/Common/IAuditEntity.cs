
namespace KitapSatisApp.Domain.Entites.Common
{
	public interface IAuditEntity
	{
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}
}
