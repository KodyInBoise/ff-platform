using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ff_platform.Models;

namespace ff_platform.Data
{
    public class DataUtil
    {
        public class FantasyTeams
        {
            public static List<TeamModel> GetAll()
            {
                try
                {
                    var teams = ApplicationDbContext.GetAllTeams();

                    return teams;
                }
                catch
                {
                    return new List<TeamModel>();
                }
            }
        }
    }
}