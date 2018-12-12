using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.NFL_API
{
    public class PlayerDetailsModel : IPlayerModel
    {
        public int ID { get; set; }
        public string EsbID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string TeamAbbr { get; set; }
        public string Status { get; set; }
        public string InjuryGameStatus { get; set; }
        public int JerseyNumber { get; set; }
    }
}
