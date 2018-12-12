using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.NFL_API
{
    public interface IPlayerModel
    {
        int ID { get; set; }
        string EsbID { get; set; }
        string Name { get; set; }
        string Position { get; set; }
        string TeamAbbr { get; set; }
    }
}
