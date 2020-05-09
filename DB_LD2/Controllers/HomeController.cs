using DB_LD2.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_LD2.Controllers
{
    public class HomeController : Controller
    {
        ArenaRepository arenaRepo = new ArenaRepository();
        public ActionResult Index()
        {
            return View(arenaRepo.getArenos());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}