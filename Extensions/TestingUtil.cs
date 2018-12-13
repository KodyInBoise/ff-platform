﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ff_platform.Models;

namespace ff_platform.Extensions
{
    public class TestingUtil
    {
        public class Exceptions
        {
            public static void ThrowTestException()
            {
                throw new Exception("A test exception has occurred!");
            }
        }


        public class Players
        {
            public static List<string> GetDefaultTeamPlayerIDs()
            {
                return new List<string>()
                {
                    PatrickMahomes.PlayerID,
                    ToddGurley.PlayerID,
                    SaquonBarkley.PlayerID,
                    AntonioBrown.PlayerID,
                    DevanteAdams.PlayerID,
                    TyreekHill.PlayerID,
                    TravisKelce.PlayerID,
                    HarrisonButker.PlayerID
                };
            }

            public class PatrickMahomes
            {
                public static string PlayerID = "2558125";
            }

            public class ToddGurley
            {
                public static string PlayerID = "2552475";
            }

            public class SaquonBarkley
            {
                public static string PlayerID = "2560968";
            }

            public class AntonioBrown
            {
                public static string PlayerID = "2508061";
            }

            public class DevanteAdams
            {
                public static string PlayerID = "2543495";
            }

            public class TravisKelce
            {
                public static string PlayerID = "2540258";
            }

            public class TyreekHill
            {
                public static string PlayerID = "2556214";
            }

            public class HarrisonButker
            {
                public static string PlayerID = "2558245";
            }
        }

        public class League
        {
            public static Guid DefaultLeagueID = Guid.Parse("90ba2933-0c27-4203-9760-e948d4076bf3");

            public static LeagueModel GetDefaultLeague()
            {
                return new LeagueModel()
                {
                    ID = DefaultLeagueID,
                    Name = "Default League",
                    RosterLimits = RosterLimitModel.GetDefaults()
                };
            }
        }

        public class Team
        {
            public static int DefaultTeamID = 1;

            public static TeamModel GetDefaultTeam()
            {
                return new TeamModel()
                {
                    ID = DefaultTeamID,
                    LeagueID = League.DefaultLeagueID,
                    OwnerID = "90ba2933-0c27-4203-9760-e948d4076bf3",
                    PlayerIDs = Players.GetDefaultTeamPlayerIDs()
                };
            }
        }
    }
}
