using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace ff_platform.NFL_API
{
    public class APIHelper
    {
        public static APIHelper Instance { get; private set; }

        public EndpointHelper Endpoints { get; private set; }


        static string _apiKey = "a842a98c-6b69-4efe-8482-a85471";
        static string _password = "MYSPORTSFEEDS";


        public static void Startup()
        {
            Instance = new APIHelper();
        }

        static WeeklyPlayerStatsModel _lastWeeklyPlayerStats { get; set; }
        public static List<PlayerModel> GetPlayerWeeklyStats(int season, int week)
        {
            var players = new List<PlayerModel>();

            try
            {
                var url = EndpointHelper.Players.WeeklyPlayerStats(season, week);

                var response = Instance.GetResponseString(url);

                if (!String.IsNullOrEmpty(response))
                {
                    _lastWeeklyPlayerStats = JsonConvert.DeserializeObject<WeeklyPlayerStatsModel>(response);
                }

                return _lastWeeklyPlayerStats.players;
            }
            catch
            {
                return players;
            }
        }

        string GetResponseString(string url)
        {
            var content = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            //request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{_apiKey}:{_password}"));
            //request.PreAuthenticate = true;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                content = reader.ReadToEnd();
            }

            return content;
        }
    }


    public class EndpointHelper
    {
        static string _baseUrl = "https://api.fantasy.nfl.com/v1/";


        public static class Players
        {
            static string _endpoint => Path.Combine(_baseUrl, "players");

            public static string WeeklyPlayerStats(int season, int week)
            {
                var queryParams = new Dictionary<string, object>();
                queryParams.Add("statType", "seasonStats");
                queryParams.Add("season", season);
                queryParams.Add("week", week);
                queryParams.Add("format", "json");

                return Path.Combine(_endpoint, $"stats{GetQueryString(queryParams)}");
            }
        }

        public class Games
        {
            // https://api.mysportsfeeds.com/v2.0/pull/nfl/{season}/week/{week}/games.{format}
            //public static string WeeklyGames => GetWeeklyGames();

            //strin
        }

        public class Stats
        {
            // http://api.fantasy.nfl.com/v1/game/stats?format=json

            string _endpoint = Path.Combine(_baseUrl, "game");
        }

        static string GetQueryString(Dictionary<string, object> parameters)
        {
            var query = "?";

            foreach (var parameter in parameters.Keys)
            {
                if (parameters.TryGetValue(parameter, out var value))
                {
                    query += $"{parameter}={value}&";
                }
            }

            return query.TrimEnd('&');
        }
    }
}
