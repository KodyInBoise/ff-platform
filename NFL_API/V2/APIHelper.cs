using System;

namespace ff_platform.NFL_API.V2
{
    public class APIHelper
    {
        static APIHelper _instance { get; set; }


        public static void Startup()
        {
            _instance = new APIHelper();
        }

        public static class Endpoints
        {
            static string _baseUrl = "";
        }
    }
}
