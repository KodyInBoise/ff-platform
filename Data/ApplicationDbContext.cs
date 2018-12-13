using System;
using System.Collections.Generic;
using System.Text;
using ff_platform.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ff_platform.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<LeagueModel> Leagues { get; set; }
        public DbSet<TeamModel> Teams { get; set; }

        static ApplicationDbContext _instance { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _instance = this;
        }

        public static void AddTeam(TeamModel team)
        {
            _instance.Teams.Add(team);
            _instance.SaveChanges();
        }
    }
}
