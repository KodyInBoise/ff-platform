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
            return RedirectToAction("AllPlayers");
        }

        public IActionResult AllPlayers()
        {
            var players = APIHelper.GetPlayerWeeklyStats(2018, 2);

            return View(players);
        }
    }
}