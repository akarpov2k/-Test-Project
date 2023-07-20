using System.Runtime.Serialization;

namespace Spargo_Technology_Test_Project.Models.Errors
{
    public class EntityNotFound : Exception
    {
        public EntityNotFound()
        {
        }

        public EntityNotFound(string? message) : base(message)
        {
        }

        public EntityNotFound(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
