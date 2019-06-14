using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ff_platform.Data;
using ff_platform.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ff_platform.Controllers
{
    public class UploadsController : Controller
    {
        private readonly ApplicationDbContext _database;
        private readonly UploadUtil _updateUtil;

        public UploadsController(ApplicationDbContext db, UploadUtil util)
        {
            _database = db;
            _updateUtil = util;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}