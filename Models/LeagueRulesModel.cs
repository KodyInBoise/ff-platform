using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.Models
{
    public class LeagueRulesModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int RosterLimit { get; set; }
    }
}
