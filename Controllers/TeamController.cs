using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ff_platform.Data;
using ff_platform.Extensions;
using ff_platform.Models;
using ff_platform.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ff_platform.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateTeam(Guid? leagueID = null)
        {
            var userID = DataUtil.Users.GetUserID(User);

            if (userID != null)
            {
                var viewModel = new EditTeamViewModel();
                viewModel.SetTeam(new TeamModel(userID, leagueID ?? NFLHelper.Leagues.WildcardLeagueID));

                return View(viewModel);
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public IActionResult CreateTeam(EditTeamViewModel viewModel)
        {
            DataUtil.FantasyTeams.AddOrUpdate(viewModel.Team);

            return RedirectToAction("Index", "Profile");
        }
    }
}