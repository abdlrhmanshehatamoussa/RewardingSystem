using System;
using System.Collections.Generic;
using RewardingSystem.Helpers;

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
            map.Add(typeof(FailedLoginException), Globals.ERROR_CODE_FAILED_LOGIN);
            map.Add(typeof(NotAuthorizedException), Globals.ERROR_CODE_NOT_AUTHORIZED);
            map.Add(typeof(VoucherForbiddenException), Globals.ERROR_CODE_VOUCHER_FORBIDDEN);
            map.Add(typeof(VoucherUsageLimitException), Globals.ERROR_CODE_VOUCHER_USAGE_LIMIT);
            return map;
        }
    }
}