using System;

namespace ff_platform.NFL_API
{
    public class WeekModel
    {
        public int season { get; set; }
        public int weekOrder { get; set; }
        public int week { get; set; }
        public string name { get; set; }
    }


    public enum TypeEnum
    {
        HOF,
        PRE,
        REG,
        WC,
        DIV,
        CONF,
        SB,
        PRO
    }
}
