using System.Collections.Generic;
using ff_platform.NFL_API;
using ff_platform.NFL_API.Models;

namespace ff_platform.ViewModels
{
    public class FavoritePlayersViewModel
    {
        public int Season { get; set; }
        public int Week { get; set; }
        public IEnumerable<PlayerSeasonStatsModel> Players { get; set; }
        public int CurrentIndex { get; set; }
    }
}