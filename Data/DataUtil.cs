using System;
using System.Collections.Generic;
using System.Security.Claims;
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


        public class FantasyLeagues
        {
            public static List<LeagueModel> GetAll()
            {
                try
                {
                    var leagues = ApplicationDbContext.GetAllLeagues();

                    return leagues;
                }
                catch
                {
                    return new List<LeagueModel>();
                }
            }

            public static void AddOrUpdate(LeagueModel league)
            {
                try
                {
                    var match = ApplicationDbContext.GetLeague(league.ID);

                    if (match != null)
                    {
                        match.Copy(league);

                        ApplicationDbContext.UpdateLeague(match);
                    }
                    else
                    {
                        ApplicationDbContext.AddLeague(league);
                    }
                }
                catch (Exception ex)
                {
#if DEBUG
                    throw ex;
#endif
                }
            }
        }


        public class FantasyLeagueRules
        {
            public static void AddOrUpdateRules(LeagueRulesModel rules)
            {
                var match = GetRules(rules.ID);

                if (match != null)
                {
                    match.Copy(rules);
                }
                else
                {
                    ApplicationDbContext.AddLeagueRules(rules);
                }
            }

            public static LeagueRulesModel GetRules(int id)
            {
                try
                {
                    return ApplicationDbContext.GetLeagueRules(id);
                }
                catch
                {
                    return null;
                }
            }
        }

        
        public class Users
        {
            public static Guid GetUserID(ClaimsPrincipal user)
            {
                return Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
            }

            public static UserPrefsModel GetUserPrefs(Guid userID)
            {
                return ApplicationDbContext.GetUserPrefs(userID);
            }
        }
    }
}