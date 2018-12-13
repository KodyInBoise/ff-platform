using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.Models
{
    public class LeagueModel
    {
        public Guid ID { get; set; }
        public string AdminID { get; set; }
        public string Name { get; set; }
        public RosterLimitModel RosterLimits { get; set; }

        public void Copy(LeagueModel league)
        {
            AdminID = league.AdminID;
            Name = league.Name;
            RosterLimits = league.RosterLimits;
        }
    }
}