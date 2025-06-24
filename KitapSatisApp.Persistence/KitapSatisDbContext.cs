using KitapSatisApp.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace KitapSatisApp.Persistence
{
	public class KitapSatisDbContext(DbContextOptions<KitapSatisDbContext> options): DbContext(options) 
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<User> Users { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
	}
	
	
}
