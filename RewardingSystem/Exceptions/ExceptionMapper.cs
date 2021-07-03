using System;
using System.Collections.Generic;

namespace RewardingSystem.Exceptions
{
    public static class ExceptionMapper
    {
        public static int MapException(Exception exception)
        {
            Type t = exception.GetType();
            Dictionary<Type, int> map = BuildMap();
            if (map.ContainsKey(t))
            {
                return map[t];
            }
            return 500;
        }

        private static Dictionary<Type, int> BuildMap()
        {
            Dictionary<Type, int> map = new Dictionary<Type, int>();
            map.Add(typeof(FailedLoginException), 498);
            map.Add(typeof(NotAuthorizedException), 496);
            return map;
        }
    }
}