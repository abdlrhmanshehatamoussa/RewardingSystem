using System;
using System.Runtime.Serialization;

namespace RewardingSystem.Exceptions
{
    [Serializable]
    internal class VoucherUsageLimitException : Exception
    {
        public VoucherUsageLimitException()
        {
        }

        public VoucherUsageLimitException(string message) : base(message)
        {
        }

        public VoucherUsageLimitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VoucherUsageLimitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}