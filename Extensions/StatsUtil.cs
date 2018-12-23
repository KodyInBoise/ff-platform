using System;
using System.Collections.Generic;
using ff_platform.NFL_API;
using ff_platform.NFL_API.Models;

namespace ff_platform.Extensions
{
    public class StatsUtil
    {
        public static StatsUtil Instance { get; set; }


        public static void Initialize()
        {
            Instance = new StatsUtil();
        }

        public static List<PlayerSeasonStatsModel> GetPlayerSeasonStats(int season, bool refresh = false)
        {
            var players = new List<PlayerSeasonStatsModel>();

            var cached = CacheUtil.PlayerSeasonStats.GetBySeason(NFLHelper.GetCurrentSeason());

            if (cached != null)
            {
                return cached;
            }

            //players = APIHelper.get

            return players;
        }

        public static List<PlayerWeeklyStatsModel> GetPlayerWeeklyStats(int season, int week, bool refresh = false)
        {
            var players = new List<PlayerWeeklyStatsModel>();

            // check cache

            players = APIHelper.GetPlayerWeeklyStats(season, week);
            return players;
        }
    }
}
