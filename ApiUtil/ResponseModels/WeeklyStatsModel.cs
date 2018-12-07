using ff_platform.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.ApiUtil.ResponseModels
{
    public class WeeklyStatsModel
    {
        public SystemConfigModel systemConfig { get; set; }
        public GameModel[] games { get; set; }


        public static WeeklyStatsModel ParseResponse(string json)
        {
            var newWeeklyStats = new WeeklyStatsModel();

            var jsonObject = JObject.Parse(json);

            var games = jsonObject["games"];
            var firstGame = games.Children().FirstOrDefault();

            return newWeeklyStats;
        }
    }

    public class SystemConfigModel
    {
        public int currentGameId { get; set; }
        public int pollingIntervalPlayersWeekStats { get; set; }
        public int pollingIntervalLeagueTeamMatchup { get; set; }
        public bool overridePollingPlayersWeekStats { get; set; }
    }
}