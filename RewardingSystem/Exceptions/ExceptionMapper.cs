using System;
using System.Collections.Generic;

namespace RewardingSystem.Exceptions
{
    public static class ExceptionMapper
    {
        public static int MapException(Exception exception)
        {
            Dictionary<Type, int> map = new Dictionary<Type, int>();
            map.Add(typeof(FailedLoginException), 498);
            Type t = exception.GetType();
            if (map.ContainsKey(t))
            {
                return map[t];
            }
            return 500;
        }
    }
}