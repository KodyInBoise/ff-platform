using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ff_platform.Data;
using ff_platform.Extensions;
using ff_platform.Models;
using ff_platform.NFL_API;
using ff_platform.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ff_platform.Controllers
{
    public class StatsController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("SeasonStats", new { season = NFLHelper.GetCurrentSeason() });
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

        public IActionResult SeasonStats(int season)
        {
            var players = APIHelper.GetPlayerSeasonStats(season, out var index);

            var playerStatsVM = new SeasonStatsViewModel()
            {
                CurrentIndex = index,
                Season = season,
                Players = players
            };

            return View(playerStatsVM);
        }

        public IActionResult FavoritePlayer(string playerID)
        {
            //var userID = DataUtil.Users.GetUserID(User);

            //if (userID != null)
            //{
            //    DataUtil.Users.AddFavoritePlayer(userID, playerID);
            //}

            //return RedirectToAction("FavoritePlayers", new
            //{
            //    season = NFLHelper.GetCurrentSeason(),
            //    week = NFLHelper.GetCurrentWeek()
            //});
            return View();
        }

        public IActionResult UnfavoritePlayer(string playerID)
        {
            //var userID = DataUtil.Users.GetUserID(User);

            //if (userID != null)
            //{
            //    DataUtil.Users.RemoveFavoritePlayer(userID, playerID);
            //}

            //return RedirectToAction("FavoritePlayers", new
            //{
            //    season = NFLHelper.GetCurrentSeason(),
            //    week = NFLHelper.GetCurrentWeek()
            //});
            return View();
        }

        public IActionResult FavoritePlayers(int season, int week)
        {
            //var userID = DataUtil.Users.GetUserID(User);
            //var playerIDs = DataUtil.Users.GetFavoritePlayerIDs(userID);

            //var viewModel = new FavoritePlayersViewModel()
            //{
            //    Season = season,
            //    Week = week
            //};

            //viewModel.Players = APIHelper.GetPlayerSeasonStatsByIDs(playerIDs, season, week);

            //return View(viewModel);
            return View();
        }

        public IActionResult WeekStats(int season, int week)
        {
            var stats = StatsUtil.GetPlayerWeeklyStats(season, week);
            return View();
        }
    }
}