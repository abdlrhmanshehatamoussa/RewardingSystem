using System;
using System.Runtime.Serialization;

namespace RewardingSystem.Exceptions
{
    [Serializable]
    internal class VoucherForbiddenException : Exception
    {
        public VoucherForbiddenException()
        {
        }

        public VoucherForbiddenException(string message) : base(message)
        {
        }

        public VoucherForbiddenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VoucherForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}