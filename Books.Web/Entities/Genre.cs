using Books.Web.Entities.Abstraction;

namespace Books.Web.Entities
{
    public class Genre : BaseEntity
    {
        public required string Name { get; set; }
    }
}
