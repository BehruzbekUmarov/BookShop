using System.Runtime.Serialization;

namespace Books.Web.Helper.Exceptions
{
    [Serializable]
    internal class BookFileNotFoundException : Exception
    {
        public BookFileNotFoundException()
        {
        }

        public BookFileNotFoundException(string? message) : base(message)
        {
        }

        public BookFileNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BookFileNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}