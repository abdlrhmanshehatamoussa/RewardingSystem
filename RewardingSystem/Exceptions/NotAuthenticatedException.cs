using System;
using System.Runtime.Serialization;

namespace RewardingSystem.Exceptions
{
    [Serializable]
    internal class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException(string message = "Not Authenticated") : base(message)
        {
        }

        public NotAuthenticatedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotAuthenticatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}