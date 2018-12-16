using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ff_platform.Data;
using ff_platform.Models;
using ff_platform.NFL_API;
using ff_platform.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ff_platform.Controllers
{
    public class PlayerStatsController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("WeeklyStats", new { season = APIHelper.GetCurrentSeason(), 
                week = APIHelper.GetCurrentWeek() });
        }

        public IActionResult PlayerDetails(string playerID)
        {
            var player = APIHelper.GetPlayerDetails(playerID);

            return View(player);
        }

        public IActionResult AllStats()
        {
            var stats = APIHelper.GetAllAvailableStats();

            return View(stats);
        }

        public IActionResult WeeklyStats(int season, int week)
        {
            var players = APIHelper.GetAllPlayerWeeklyStats(season, week, out var index);

            var playerStatsVM = new WeeklyStatsViewModel()
            {
                CurrentIndex = index,
                Season = season,
                Week = week,
                Players = players
            };

            return View(playerStatsVM);
        }

        public IActionResult FavoritePlayer(string playerID)
        {
            var userid = DataUtil.Users.GetUserID(User);

            return WeeklyStats(2018, 15);
        }
    }
}