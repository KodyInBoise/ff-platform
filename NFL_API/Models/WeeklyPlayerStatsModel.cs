using System;
using System.Collections.Generic;

namespace ff_platform.NFL_API
{
    public class WeeklyPlayerStatsModel
    {
        public string statType { get; set; }
        public int season { get; set; }
        public int week { get; set; }
        public List<PlayerModel> players { get; set; }
    }
}
