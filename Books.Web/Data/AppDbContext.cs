using Book.Web.Configurations;
using Books.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.Web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Books.Web.Entities.Book> Books { get; set; }
    public DbSet<Writer> Writers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<BookFile> BookFiles { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new BookGenreConfiguration().Configure(modelBuilder.Entity<BookGenre>());
    }
}
