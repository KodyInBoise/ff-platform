using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ff_platform.ApiUtil;
using ff_platform.Models;
using ff_platform.NFL_API;
using Microsoft.AspNetCore.Mvc;

namespace ff_platform.Controllers
{
    public class PlayerStatsController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("AllPlayers", new { season = APIHelper.GetCurrentSeason(), 
                week = APIHelper.GetCurrentWeek() });
        }

        public IActionResult AllPlayers(int season, int week)
        {
            var players = APIHelper.GetPlayerWeeklyStats(season, week);

            return View(players);
        }
    }
}