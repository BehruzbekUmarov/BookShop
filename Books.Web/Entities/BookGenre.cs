using Books.Web.Entities.Abstraction;

namespace Books.Web.Entities
{
    public class BookGenre : BaseEntity
    {
        public int BookId { get; set; }
        public virtual Book? Books { get; set; }
        public int GenreId { get; set; }
        public virtual Genre? Genres { get; set; }
    }
}
