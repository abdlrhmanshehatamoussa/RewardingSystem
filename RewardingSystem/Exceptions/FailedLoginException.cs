using RewardingSystem.Helpers;

namespace RewardingSystem.Exceptions
{
    [System.Serializable]
    public class FailedLoginException : System.Exception
    {
        public FailedLoginException() { }
        public FailedLoginException(string message) : base(message) { }
        public FailedLoginException(string message, System.Exception inner) : base(message, inner) { }
        protected FailedLoginException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}