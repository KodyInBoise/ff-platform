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


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
