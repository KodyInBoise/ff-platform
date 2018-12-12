﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ff_platform.Extensions;

namespace ff_platform.NFL_API
{
    public class APIHelper
    {
        public static APIHelper Instance { get; private set; }

        public EndpointHelper Endpoints { get; private set; }


        #region Public Fields
        public static void Initialize()
        {
            Instance = new APIHelper();
        }

        static WeeklyPlayerStatsModel _lastWeeklyPlayerStats { get; set; }
        public static List<PlayerWeeklyStatsModel> GetAllPlayerWeeklyStats(int season, int week)
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

        public static PlayerWeeklyStatsModel GetPlayerWeeklyStats(int playerID, int season, int week)
        {
            //TODO: Update this to not always get all players first
            var allPlayerStats = GetAllPlayerWeeklyStats(season, week);

            var player = allPlayerStats.Find(x => x.ID == playerID);
            if (player != null)
            {
                player.ParsedStats = PlayerWeeklyStatsModel.ParseStatsDictionary(player.Stats);
            }

            return player;
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

                // eventually need a redirect page
                return new PlayerDetailsModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<StatModel> GetAllAvailableStats(bool refresh = false, bool overwriteCache = true)
        {
            if (!refresh)
            {
                var cachedStats = StatsCache.GetAllStatsCache();

                if (cachedStats.Any())
                {
                    return cachedStats;
                }
            }

            var stats = new List<StatModel>();

            try
            {
                var url = EndpointHelper.Stats.AllAvailableStats();

                var response = Instance.GetResponseString(url);

                if (!string.IsNullOrEmpty(response))
                {
                    var responseObject = JObject.Parse(response);

                    stats = Deserializer.TryGetValue<List<StatModel>>(responseObject, "stats");
                }

                if (overwriteCache && stats.Any())
                {
                    StatsCache.SetAllStatsCache(stats);
                }

                return stats;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static List<StatModel> _allAvailableStats { get; set; }
        public static StatModel ParseStatModel(int id, int value)
        {
            try
            {
                if (_allAvailableStats == null || !_allAvailableStats.Any())
                {
                    _allAvailableStats = GetAllAvailableStats();
                }

                var match = _allAvailableStats.FirstOrDefault(x => x.ID == id);
                if (match == null)
                {
                    return null;
                }

                return StatModel.Copy(match, value);
            }
            catch
            {
                return null;
            }
        }

        public static int GetCurrentSeason()
        {
            return DateTime.Now.Year;
        }

        public static int GetCurrentWeek()
        {
            return 14;
        }
        #endregion

        #region Private Fields
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
        #endregion
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
            static string _endpoint => Path.Combine(_baseUrl, "game");

            public static string AllAvailableStats()
            {
                var queryParams = new Dictionary<string, object>();
                queryParams.Add("format", "json");

                return Path.Combine(_endpoint, $"stats{GetQueryString(queryParams)}");
            }
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
