using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ff_platform.NFL_API
{
    public class Deserializer
    {
        public static T TryGetValue<T>(JToken token)
        {
            try
            {
                return token.ToObject<T>();
            }
            catch
            {
                return default(T);
            }
        }

        public static T TryGetValue<T>(JToken token, string key)
        {
            try
            {
                return token[key].ToObject<T>();
            }
            catch
            {
                return default(T);
            }
        }

        public static T FromJson<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default(T);
            }
        }

        public static T ConvertToken<T>(JToken token)
        {
            try
            {
                return token.ToObject<T>();
            }
            catch
            {
                return default(T);
            }
        }
    }

    public class APIHelper
    {
        public static APIHelper Instance { get; private set; }

        public EndpointHelper Endpoints { get; private set; }


        public static void Startup()
        {
            Instance = new APIHelper();
        }

        static WeeklyPlayerStatsModel _lastWeeklyPlayerStats { get; set; }
        public static List<PlayerModel> GetPlayerWeeklyStats(int season, int week)
        {
            var players = new List<PlayerModel>();
            var response = "";

            try
            {
                var url = EndpointHelper.Players.WeeklyPlayerStats(season, week);

                response = Instance.GetResponseString(url);

                if (!String.IsNullOrEmpty(response))
                {
                    var responseObject = JObject.Parse(response);
                    var playerTokens = responseObject["players"].Children();

                    foreach (var token in playerTokens)
                    {
                        var player = Deserializer.TryGetValue<PlayerModel>(token);

                        if (player != null)
                        {
                            players.Add(player);
                        }
                    }
                }

                return players;
            }
            catch (Exception ex)
            {
                throw ex;
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

        public static int GetCurrentSeason()
        {
            return DateTime.Now.Year;
        }

        public static int GetCurrentWeek()
        {
            return 14;
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
