using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public static List<PlayerWeeklyStatsModel> GetPlayerWeeklyStats(int season, int week)
        {
            if (_lastWeeklyPlayerStats?.Season == season && _lastWeeklyPlayerStats?.Week == week)
            {
                return _lastWeeklyPlayerStats.Players;
            }

            _lastWeeklyPlayerStats = new WeeklyPlayerStatsModel(season, week);

            try
            {
                var response = "";
                var url = EndpointHelper.Players.WeeklyPlayerStats(season, week);

                response = Instance.GetResponseString(url);

                if (!string.IsNullOrEmpty(response))
                {
                    var responseObject = JObject.Parse(response);
                    var playerTokens = responseObject["players"].Children();

                    foreach (var token in playerTokens)
                    {
                        var player = Deserializer.TryGetValue<PlayerWeeklyStatsModel>(token);

                        if (player != null)
                        {
                            _lastWeeklyPlayerStats.Players.Add(player);
                        }
                    }

                    _lastWeeklyPlayerStats.StatType = Deserializer.TryGetValue<string>(responseObject, "statType");
                }

                return _lastWeeklyPlayerStats.Players;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PlayerDetailsModel GetPlayerDetails(string playerID)
        {
            try
            {
                var url = EndpointHelper.Players.Details(playerID);

                var response = Instance.GetResponseString(url);

                if (!string.IsNullOrEmpty(response))
                {
                    var responseObject = JObject.Parse(response);
                    var details = responseObject["players"].FirstOrDefault();

                    return Deserializer.ConvertToken<PlayerDetailsModel>(details);
                }

                return new PlayerDetailsModel();
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

            public static string Details(string playerID)
            {
                var queryParams = new Dictionary<string, object>();
                queryParams.Add("playerId", playerID);
                queryParams.Add("statType", "seasonStats");
                queryParams.Add("format", "json");

                return Path.Combine(_endpoint, $"details{GetQueryString(queryParams)}");
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
