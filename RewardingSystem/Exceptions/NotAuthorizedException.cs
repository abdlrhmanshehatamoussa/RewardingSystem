using RewardingSystem.Helpers;

namespace RewardingSystem.Exceptions
{
    [System.Serializable]
    public class NotAuthorizedException : System.Exception
    {
        public NotAuthorizedException(string message = "Not Authorized") : base(message) { }
        public NotAuthorizedException(string message, System.Exception inner) : base(message, inner) { }
        protected NotAuthorizedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}