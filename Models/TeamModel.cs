using System;
using System.Collections.Generic;

namespace ff_platform.Models
{
    public class TeamModel
    {
        public Guid ID { get; set; }
        public Guid OwnerID { get; set; }
        public Guid LeagueID { get; set; }
        public string Name { get; set; }
        public List<string> PlayerIDs { get; set; }
    }
}