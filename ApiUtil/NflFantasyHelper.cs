using ff_platform.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ff_platform.ViewModels;
using ff_platform.ApiUtil.ResponseModels;

namespace ff_platform.ApiUtil
{
    public class NflFantasyHelper
    {
        public static NflFantasyHelper Instance { get; private set; }


        public NflFantasyHelper()
        {

        }

        public static void Startup()
        {
            Instance = new NflFantasyHelper();
        }


        static WeeklyStatsModel _lastWeeklyStatsResponse;
        public static void GetWeeklyStats(int season, int week)
        {
            var url = FantasyApiEndpoints.Players.WeeklyStats(season, week);

            var response = GetResponseString(url);
            _lastWeeklyStatsResponse = WeeklyStatsModel.ParseResponse(response);


            var test = _lastWeeklyStatsResponse.games;
            //_lastWeeklyStatsResponse = WeeklyStatsModel.ParseResponse(response);
        }

        public static string GetResponseString(string url)
        {
            string content = "";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/json; charset=utf-8";
                //request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("username:password"));
                //request.PreAuthenticate = true;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    content = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                content = ex.Message;
            }

            return content;
        }

        public static int GetCurrentYear()
        {
            return DateTime.Now.Year;
        }

        public static int GetCurrentWeek()
        {
            return 14;
        }
    }


    // http://api.fantasy.nfl.com/v2/players/weekstats?statUpdateId=250
    public class FantasyApiEndpoints
    {
        static string _baseUrl = @"https://api.fantasy.nfl.com/v2/";

        public static class Players
        {
            static int _updateID = 1;

            static string _baseEndpoint = Path.Combine(_baseUrl, "players");

            public static string WeeklyStats(int? season = null, int? week = null)
            {
                var parameters = NewParamDictionary();
                parameters.Add("season", season ?? DateTime.Now.Year);
                parameters.Add("week", week ?? 1);

                var query = GetQueryString(parameters);

                return Path.Combine(_baseEndpoint, $"weekstats{query}");
            }
        }

        public static Dictionary<string, object> NewParamDictionary()
        {
            return new Dictionary<string, object>();
        }

        public static string GetQueryString(Dictionary<string, object> parameters)
        {
            var paramString = "?";

            foreach(var parameter in parameters.Keys)
            {
                if (parameters.TryGetValue(parameter, out var value))
                {
                    paramString += $"{parameter}={value}&";
                }
            }

            return paramString.TrimEnd('&');
        }
    }
}
