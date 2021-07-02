using System;
using System.Linq;

namespace RewardingSystem.Helpers
{
    public static class Utils
    {
        private static Random random = new Random();

        public static string GenerateToken()
        {
            int length = 30;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}