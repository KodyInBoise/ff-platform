using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ff_platform.Data;
using ff_platform.Models;
using ff_platform.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ff_platform.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            var userID = DataUtil.Users.GetUserID(User);

            if (userID != null)
            {
                var profile = DataUtil.Users.GetUserProfile(userID);
                var vm = new UserProfileViewModel(profile);

                return View(vm);
            }

            return RedirectToAction("Login", "Account");
        }
    }
}