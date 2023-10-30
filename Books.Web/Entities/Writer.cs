using Books.Web.Entities.Abstraction;

namespace Books.Web.Entities
{
    public class Writer : BaseEntity
    {
        public required string FullName { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
