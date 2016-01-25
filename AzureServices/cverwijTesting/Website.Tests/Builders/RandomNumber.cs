using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.WebSite.Tests
{
    /// <summary>
    /// Thread safe implementation of a pseudo random number generator for testing purposes
    /// </summary>
    public class RandomNumber
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public static int Get(int min, int max)
        {
            lock (syncLock)
            {
                return random.Next(min, max);
            }
        }

        public static int Get()
        {
            lock (syncLock)
            {
                return Get(0, 1000000);
            }
        }
    }
}
