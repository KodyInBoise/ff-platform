﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ff_platform.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateTeam(Guid leagueID)
        {

            return View();
        }
    }
}