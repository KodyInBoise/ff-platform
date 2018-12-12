using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ff_platform.NFL_API
{
    public class WeeklyPlayerStatsModel
    {
        public string StatType { get; set; }
        public int Season { get; set; }
        public int Week { get; set; }
        public List<PlayerWeeklyStatsModel> Players { get; set; }

        public WeeklyPlayerStatsModel()
        {
            Players = new List<PlayerWeeklyStatsModel>();
        }

        public WeeklyPlayerStatsModel(int season, int week)
        {
            Season = season;
            Week = week;
            Players = new List<PlayerWeeklyStatsModel>();
        }
    }
}
