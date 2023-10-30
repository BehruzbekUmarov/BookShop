using Book.Web.Data;

namespace Books.Web.Repositories.Abstractions
{
    public interface IBookRepository : IGenericRepository<Entities.Book, AppDbContext>
    {
    }
}
