using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ff_platform.Data;
using ff_platform.Extensions;
using ff_platform.Models;
using ff_platform.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ff_platform.Controllers
{
    public class ProfileController : Controller
    {
        readonly ApplicationDbContext _database;
        readonly SignInManager<IdentityUser> _signInManager;
        readonly UserManager<IdentityUser> _userManager;
        readonly LoggingUtil _logger;

        public ProfileController(ApplicationDbContext db,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            LoggingUtil logger)
        {
            _database = db;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            var userProfile = UserProfileHelper.GetUserProfile(_database, _userManager.GetUserId(User));

            if (userProfile == null)
            {
                return RedirectToAction("Setup");
            }

            return View();
        }

        [HttpGet]
        [Route("Profile/Setup")]
        public IActionResult Setup(Guid id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Setup(UserProfileModel profile)
        {
            profile.ID = Guid.Parse(_userManager.GetUserId(User));

            UserProfileHelper.AddOrUpdate(_database, profile, out var newProfile);

            if (newProfile)
            {
                _logger.Info($"New Profile Created: {profile.ID}, {profile.Name}");
            }

            return RedirectToAction("Index");
        }
    }
}