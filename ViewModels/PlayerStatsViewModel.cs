using ff_platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.ViewModels
{
    public class PlayerStatsViewModel
    {
        public string StatType { get; set; }
        public string Season { get; set; }
        public string Week { get; set; }
        public List<PlayerModelOLD
> Players { get; set; }
    }
}
