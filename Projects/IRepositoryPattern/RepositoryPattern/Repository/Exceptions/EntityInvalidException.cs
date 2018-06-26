namespace RepositoryPattern.Repository.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class EntityInvalidException : Exception
    {
        public EntityInvalidException(string message)
            : base(message)
        {
        }

        public EntityInvalidException(string message, int id)
            : base(message)
        {
            this.Id = id;
        }

        public EntityInvalidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected EntityInvalidException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public virtual int? Id { get; }
    }
}
