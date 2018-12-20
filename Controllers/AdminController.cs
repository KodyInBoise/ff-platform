﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ff_platform.Data;
using ff_platform.Extensions;
using ff_platform.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ff_platform.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return RedirectToAction("NFLSeasons");
        }

        public IActionResult NFLSeasons(int season = 2018)
        {
            var vm = new NFLSeasonsViewModel();
            vm.Seasons.Add(TestingUtil.NFLSeasons.GetCurrentNFLSeason());

            vm.Seasons[0].PreaseasonStart = NFLWeekHelper.GetPreseasonStartDate(season);

            return View(vm);
        }

        public IActionResult EditNFLSeason(Guid seasonID)
        {
            return View();
        }
    }
}
