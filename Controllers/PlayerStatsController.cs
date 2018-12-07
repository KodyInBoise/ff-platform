using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ff_platform.ApiUtil;
using ff_platform.Models;
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
            var players = NflFantasyHelper.GetAllPlayers(2018, 1);

            return View(players);
        }
    }
}