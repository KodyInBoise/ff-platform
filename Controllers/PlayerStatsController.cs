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
            var userID = DataUtil.Users.GetUserID(User);

            if (userID != null)
            {
                DataUtil.Users.AddFavoritePlayer(userID, playerID);
            }

            return RedirectToAction("FavoritePlayers", new
            {
                season = APIHelper.GetCurrentSeason(),
                week = APIHelper.GetCurrentWeek()
            });
        }

        public IActionResult UnfavoritePlayer(string playerID)
        {
            var userID = DataUtil.Users.GetUserID(User);

            if (userID != null)
            {
                DataUtil.Users.RemoveFavoritePlayer(userID, playerID);
            }

            return RedirectToAction("FavoritePlayers", new
            {
                season = APIHelper.GetCurrentSeason(),
                week = APIHelper.GetCurrentWeek()
            });
        }

        public IActionResult FavoritePlayers(int season, int week)
        {
            var userID = DataUtil.Users.GetUserID(User);
            var playerIDs = DataUtil.Users.GetFavoritePlayerIDs(userID);

            var viewModel = new FavoritePlayersViewModel()
            {
                Season = season,
                Week = week
            };

            viewModel.Players = APIHelper.GetPlayersWeeklyStats(playerIDs, season, week);

            return View(viewModel);
        }
    }
}