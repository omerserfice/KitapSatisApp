using KitapSatisApp.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitapSatisApp.Persistence.Books
{
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			

			builder.ToTable("Books");
			builder.HasKey(b => b.Id);
			builder.Property(b => b.BookName).IsRequired().HasMaxLength(100);
			builder.Property(b => b.Price).IsRequired().HasColumnType("decimal(18,2)");
			builder.Property(b => b.Writer).IsRequired().HasMaxLength(100);
			builder.Property(b => b.PublicationYear).IsRequired().HasMaxLength(4);

			builder.HasOne(b => b.Category)
				.WithMany(c => c.Books)
				.HasForeignKey(b => b.CategoryId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
