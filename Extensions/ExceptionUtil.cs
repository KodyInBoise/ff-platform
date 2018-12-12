using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.Extensions
{
    public class FantasyException : Exception
    {
        public DateTime Timestamp { get; private set; }
            

        public FantasyException(string message) : base(message)
        {
            Timestamp = DateTime.Now;
        }
    }


    public class ExceptionUtil
    {
        public static ExceptionUtil Instance { get; private set; }


        public static void Initialize()
        {
            Instance = new ExceptionUtil();
        }
    }
}
