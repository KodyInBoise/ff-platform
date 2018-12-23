using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ff_platform.Extensions;

namespace ff_platform.NFL_API
{
    public class PlayerWeeklyStatsModel : IPlayerModel
    {
        public int ID { get; set; }
        public string EsbID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string TeamAbbr { get; set; }
        public Dictionary<int, double> Stats { get; set; }
        public double WeekPts { get; set; }
        public double WeekProjectedPts { get; set; }
    }
}


//"id": "2552374",
//"esbid": "ABD647726",
//"gsisPlayerId": "00-0032104",
//"name": "Ameer Abdullah",
//"position": "RB",
//"teamAbbr": "MIN",
//"stats": {
//    "1": "6",
//    "13": "1",
//    "14": "1",
//    "20": "3",
//    "21": "28",
//    "27": "225",
//    "30": "1",
//    "31": "1"
//},
//"seasonPts": 0.9,
//"seasonProjectedPts": 5.86,
//"weekPts": 0,
//"weekProjectedPts": 1.38