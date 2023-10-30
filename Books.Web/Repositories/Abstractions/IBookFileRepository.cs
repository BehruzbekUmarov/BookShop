using Book.Web.Data;
using Books.Web.Entities;

namespace Books.Web.Repositories.Abstractions
{
    public interface IBookFileRepository : IGenericRepository<BookFile, AppDbContext>
    { 
        Task<BookFile?> GetBookFileAsync(long id);
        Task<bool> DeleteBookFileAsync(long id);
    }
}
