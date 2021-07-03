using RewardingSystem.Helpers;

namespace RewardingSystem.Exceptions
{
    [System.Serializable]
    public class NotAuthorizedException : System.Exception
    {
        public NotAuthorizedException() { }
        public NotAuthorizedException(string message) : base(message) { }
        public NotAuthorizedException(string message, System.Exception inner) : base(message, inner) { }
        protected NotAuthorizedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}