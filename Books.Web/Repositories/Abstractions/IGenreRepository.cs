using Book.Web.Data;
using Books.Web.Entities;

namespace Books.Web.Repositories.Abstractions
{
    public interface IGenreRepository : IGenericRepository<Genre, AppDbContext>
    {
    }
}
