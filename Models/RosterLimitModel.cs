﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.Models
{
    public class RosterLimitModel
    {
        public int ID { get; set; }
        public int QuarterbackLimit { get; set; }
        public int RunningbackLimit { get; set; }
        public int WideReceiverLimit { get; set; }
        public int TightEndLimit { get; set; }
        public int FullbackLimit { get; set; }
        public int KickerLimit { get; set; }
    }
}
