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
        public List<PlayerNoteModel> Notes { get; set; }
    }

    public class PlayerNoteModel
    {
        public long ID { get; set; }
        public DateTime Timestamp { get; set; }
        public string Source { get; set; }
        public string Headline { get; set; }
        public string Body { get; set; }
        public string Analysis { get; set; }
    }
}
