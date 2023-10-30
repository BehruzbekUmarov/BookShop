using Book.Web.Data;
using Books.Web.Entities;
using Books.Web.Helper.Exceptions;
using Books.Web.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Books.Web.Repositories
{
    public class BookFileRepository : GenericRepository<BookFile, AppDbContext>, IBookFileRepository
    {
        public BookFileRepository(AppDbContext tContext) : base(tContext)
        {
        }

        public async Task<bool> DeleteBookFileAsync(long id)
        {
            var book = await _tContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book is null) return false;

            var bookFile = await _tContext.BookFiles.FirstOrDefaultAsync(c => c.BookId == id);
            if(bookFile is null) return false;

            bookFile.IsDeleted = true;
            File.Delete(bookFile.Path);

            _tContext.BookFiles.Update(bookFile);
            return await _tContext.SaveChangesAsync() > 0;
        }

        public async Task<BookFile?> GetBookFileAsync(long id)
        {
            var book = await _tContext.Books.FirstOrDefaultAsync(x => x.Id == id) ??
                throw new BookFileNotFoundException(nameof(Book));

            return await _tContext.BookFiles.FirstOrDefaultAsync(c => c.BookId == book.Id);
        }
    }
}
