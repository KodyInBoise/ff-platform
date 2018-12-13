using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.Models
{
    public interface IRosterPosition
    {
        string Name { get; set; }
        string Abbreviation { get; set; }
    }
}
