using Book.Web.Data;
using Books.Web.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Books.Web.Repositories
{
    public class BookRepository : GenericRepository<Entities.Book, AppDbContext>, IBookRepository
    {
        private readonly IBookFileRepository _bookFileRepository;

        public BookRepository(AppDbContext dbContext,
            IBookFileRepository bookFileRepository) : base(dbContext)
        {
            _bookFileRepository = bookFileRepository;
        }

        public override async Task<bool> DeleteAsync(long id)
        {
            var book = await _tContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book is null) return false;
            book.IsDeleted = true;

            return await _bookFileRepository.DeleteBookFileAsync(id);
        }

        public Task<bool> CheckAllAsync(List<int> modelBookIds)
        => Task.FromResult(modelBookIds.All(id => _tContext.Books.Any(entity => entity.Id == id)));
    }
}
