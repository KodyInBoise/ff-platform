using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ff_platform.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ff_platform.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<LeagueModel> Leagues { get; set; }
        public DbSet<LeagueRulesModel> LeagueRules { get; set; }
        public DbSet<TeamModel> Teams { get; set; }
        public DbSet<UserPrefsModel> UserPreferences { get; set; }
        public DbSet<NFLSeasonModel> NFLSeasons { get; set; }

        static ApplicationDbContext _instance { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _instance = this;
        }

        public static List<LeagueModel> GetAllLeagues()
        {
            return _instance.Leagues.ToListAsync().Result;
        }

        public static void AddLeague(LeagueModel league)
        {
            _instance.Leagues.Add(league);
            _instance.SaveChanges();
        }

        public static void UpdateLeague(LeagueModel league)
        {
            _instance.Leagues.Update(league);
            _instance.SaveChanges();
        }

        public static LeagueModel GetLeague(Guid id)
        {
            var leagues = GetAllLeagues();

            return leagues.Find(x => x.ID == id);
        }

        public static void AddLeagueRules(LeagueRulesModel rules)
        {
            _instance.LeagueRules.Add(rules);
            _instance.SaveChanges();
        }

        public static void UpdateLeagueRules(LeagueRulesModel rules)
        {
            _instance.LeagueRules.Update(rules);
            _instance.SaveChanges();
        }

        public static LeagueRulesModel GetLeagueRules(int id)
        {
            var leagueRules = GetAllLeagueRules();

            return leagueRules.Find(x => x.ID == id);
        }

        public static List<LeagueRulesModel> GetAllLeagueRules()
        {
            return _instance.LeagueRules.ToListAsync().Result;
        }

        public static List<UserPrefsModel> GetAllUserPrefs()
        {
            return _instance.UserPreferences.ToListAsync().Result;
        }

        public static UserPrefsModel GetUserPrefs(Guid userID)
        {
            var userPrefs = GetAllUserPrefs();

            return userPrefs.Find(x => x.ID == userID);
        }

        public static void AddUserPrefs(UserPrefsModel prefs)
        {
            _instance.UserPreferences.Add(prefs);
            _instance.SaveChanges();
        }

        public static void UpdateUserPrefs(UserPrefsModel prefs)
        {
            _instance.UserPreferences.Update(prefs);
            _instance.SaveChanges();
        }

        public static void AddTeam(TeamModel team)
        {
            _instance.Teams.Add(team);
            _instance.SaveChanges();
        }

        public static List<TeamModel> GetAllTeams()
        {
            //var teams = new List<TeamModel>();
            //var t = _instance.Teams.ToListAsync().Result;

            //foreach (var team in _instance.Teams)
            //{
            //    teams.Add(team);
            //}

            return _instance.Teams.ToListAsync().Result;
        }


    }
}
