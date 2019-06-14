using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ff_platform.Models;
using ff_platform.Extensions;
using ff_platform.NFL_API;
using ff_platform.Data;
using Microsoft.AspNetCore.Identity;

namespace ff_platform.Controllers
{
    public class HomeController : Controller
    {
        readonly ApplicationDbContext _database;
        readonly SignInManager<IdentityUser> _signInManager;
        readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext db,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _database = db;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Profile");
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Test()
        {
            var league = TestingUtil.League.GetDefaultLeague();

            //DataUtil.FantasyLeagues.AddOrUpdate(league);

            return RedirectToAction("AllStats", "PlayerStats");
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
