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
        public List<NflGameModel> games { get; set; }


        public static WeeklyStatsModel ParseResponse(string json)
        {
            var newWeeklyStats = new WeeklyStatsModel();

            var result = JObject.Parse(json).Children().ToList();

            var nflGames = result[2].Children().Children().ToList();
            //nflGames.ForEach(x =>
            //{
            //    var game = x.ToObject<NflGameModel>();
            //    newWeeklyStats.games.Add(game);
            //});
            var g = NflGameModel.ParseObject(nflGames[0]);

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