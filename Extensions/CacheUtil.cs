using System;
using System.Collections.Generic;
using System.Linq;
using ff_platform.NFL_API;

namespace ff_platform.Extensions
{
    public class CacheUtil
    {
        public static CacheUtil Instance { get; set; }
        
        StatsCache _stats { get; set; }


        public CacheUtil()
        {
            _stats = new StatsCache();
        }

        public static void Initialize()
        {
            Instance = new CacheUtil();
        }
    }

    public class StatsCache
    {
        static List<StatModel> _statsList { get; set; }

        static object _lock { get; set; }


        public StatsCache()
        {
            _statsList = new List<StatModel>();
        }

        public static List<StatModel> GetAllStatsCache()
        {
            return _statsList;
        }

        public static void SetAllStatsCache(List<StatModel> stats)
        {
            _statsList = stats;
        }
    }
}
