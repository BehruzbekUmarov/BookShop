using Books.Web.Entities.Abstraction;

namespace Books.Web.Entities
{
    public class Book : BaseEntity
    {
        public required string Name { get; set; }
        public int WriterId { get; set; }
        public virtual Writer? Writers { get; set; }
        public required string BodyFileSrc { get; set; }
        public required string CoverImageSrc { get; set; }
        public string? Description { get; set; }
        public decimal Prize { get; set; }
    }
}
