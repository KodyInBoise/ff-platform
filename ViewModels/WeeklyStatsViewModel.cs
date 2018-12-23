using ff_platform.NFL_API;
using ff_platform.NFL_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.ViewModels
{
    // This is used for displaying a list of player stats for a given week
    public class WeeklyStatsViewModel
    { 
        public int CurrentIndex { get; set; }
        public int Season { get; set; }
        public int Week { get; set; }
        public IEnumerable<PlayerSeasonStatsModel> Players { get; set; }
    }
}
