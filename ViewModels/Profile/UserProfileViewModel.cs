using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ff_platform.Extensions;
using ff_platform.Models;
using ff_platform.NFL_API;
using ff_platform.NFL_API.Models;

namespace ff_platform.ViewModels
{
    public class UserProfileViewModel
    {
        public UserProfileModel Profile { get; private set; }
        public IEnumerable<PlayerSeasonStatsModel> FavoritePlayers { get; set; }


        public UserProfileViewModel(UserProfileModel profile)
        {
            Profile = profile;
            FavoritePlayers = APIHelper.GetPlayerSeasonStatsByIDs(profile.FavoritePlayers, NFLHelper.GetCurrentSeason(), NFLHelper.GetCurrentWeek());
        }
    }
}
