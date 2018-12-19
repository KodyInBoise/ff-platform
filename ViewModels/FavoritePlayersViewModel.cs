using System.Collections.Generic;
using ff_platform.NFL_API;

namespace ff_platform.ViewModels
{
    public class FavoritePlayersViewModel
    {
        public int Season { get; set; }
        public int Week { get; set; }
        public IEnumerable<PlayerWeeklyStatsModel> Players { get; set; }
        public int CurrentIndex { get; set; }
    }
}