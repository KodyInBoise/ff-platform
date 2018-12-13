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
    }
}
