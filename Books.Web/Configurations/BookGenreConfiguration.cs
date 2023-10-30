using Books.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Web.Configurations;

public class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
{
    public void Configure(EntityTypeBuilder<BookGenre> builder)
    {
        builder.HasKey(pc => new { pc.BookId, pc.GenreId });
        builder.HasQueryFilter(b => !b.IsDeleted);
    }
}
