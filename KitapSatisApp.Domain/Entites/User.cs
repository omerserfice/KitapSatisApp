using KitapSatisApp.Domain.Entites.Common;

namespace KitapSatisApp.Domain.Entites
{
	public class User : BaseEntity<int> , IAuditEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}
}
