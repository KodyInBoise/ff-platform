using System;

namespace ff_platform.Models
{
    public class NFLSeason
    {
        public Guid ID { get; set; }
        public int Year { get; set; }
        public int PreseasonWeekCount { get; set; }
        public int RegularSeasonWeekCount { get; set; }
        public int PostSeasonWeekCount { get; set; }
        public int TotalWeekCount { get; set; }
        public DateTime PreaseasonStart { get; set; }
        public DateTime RegularSeasonStart { get; set; }
        public DateTime PostSeasonStart { get; set; }
    }
}