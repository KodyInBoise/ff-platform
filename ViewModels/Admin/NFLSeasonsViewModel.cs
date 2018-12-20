using System.Collections.Generic;
using ff_platform.Models;

namespace ff_platform.ViewModels
{
    public class NFLSeasonsViewModel
    {
        public List<NFLSeasonModel> Seasons { get; set; }

        public NFLSeasonsViewModel()
        {
            Seasons = new List<NFLSeasonModel>();
        }
    }
}