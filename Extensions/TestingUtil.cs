using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.Extensions
{
    public class TestingUtil
    {
        public class Exceptions
        {
            public static void ThrowTestException()
            {
                throw new Exception("A test exception has occurred!");
            }
        }


        public class Players
        {
            public class DevanteAdams
            {
                public static string PlayerID = "2543495";
            }
        }
    }
}
