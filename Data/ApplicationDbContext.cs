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
        public DbSet<UserProfileModel> UserProfiles { get; set; }
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

        public static List<UserProfileModel> GetAllUserProfiles()
        {
            return _instance.UserProfiles.ToListAsync().Result;
        }

        public static UserProfileModel GetUserProfile(Guid userID)
        {
            var profiles = GetAllUserProfiles();

            return profiles.Find(x => x.ID == userID);
        }

        public static void AddUserProfile(UserProfileModel profile)
        {
            _instance.UserProfiles.Add(profile);
            _instance.SaveChanges();
        }

        public static void UpdateUserProfile(UserProfileModel profile)
        {
            _instance.UserProfiles.Update(profile);
            _instance.SaveChanges();
        }

        public static void AddTeam(TeamModel team)
        {
            _instance.Teams.Add(team);
            _instance.SaveChanges();
        }

        public static void UpdateTeam(TeamModel team)
        {
            _instance.Teams.Update(team);
            _instance.SaveChanges();
        }

        public static TeamModel GetTeam(Guid id)
        {
            var teams = GetAllTeams();

            return teams.Find(x => x.ID == id);
        }

        public static List<TeamModel> GetAllTeams()
        {
            return _instance.Teams.ToListAsync().Result;
        }

        #region NFL Seasons
        public static List<NFLSeasonModel> GetNFLSeasons()
        {
            return _instance.NFLSeasons.ToListAsync().Result;
        }

        public static void AddNFLSeason(NFLSeasonModel season)
        {
            _instance.NFLSeasons.Add(season);
            _instance.SaveChanges();
        }

        public static void UpdateNFLSeason(NFLSeasonModel season)
        {
            _instance.NFLSeasons.Update(season);
            _instance.SaveChanges();
        }

        public static void RemoveNFLSeason(NFLSeasonModel season)
        {
            _instance.NFLSeasons.Remove(season);
            _instance.SaveChanges();
        }
        #endregion
    }
}
