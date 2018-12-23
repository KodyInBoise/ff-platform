using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ff_platform.NFL_API.Models
{
    public class PlayerSeasonStatsModel : IPlayerModel
    {
        public int ID { get; set; }
        public string EsbID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string TeamAbbr { get; set; }

        public double SeasonPts { get; set; }
        public double SeasonProjectedPts { get; set; }
        public Dictionary<int, double> Stats { get; set; }


        [JsonIgnore]
        public List<StatModel> ParsedStats { get; set; }
        public static List<StatModel> ParseStatsDictionary(Dictionary<int, int> stats)
        {
            var parsedStats = new List<StatModel>();

            foreach (var key in stats.Keys)
            {
                var stat = APIHelper.ParseStatModel(key, stats[key]);

                if (stat != null)
                {
                    parsedStats.Add(stat);
                }
            }

            return parsedStats;
        }
    }
}
