﻿using System;
using System.Collections.Generic;

namespace ff_platform.Models
{
    public class TeamModel
    {
        public int ID { get; set; }
        public string OwnerID { get; set; }
        public int LeagueID { get; set; }
        public List<string> PlayerIDs { get; set; }
    }
}