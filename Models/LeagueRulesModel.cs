using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.Models
{
    public class LeagueRulesModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public RosterLimitModel RosterLimits { get; set; }


        public void Copy(LeagueRulesModel rules)
        {
            Name = rules.Name;
            RosterLimits = rules.RosterLimits;
        }
    }
}
