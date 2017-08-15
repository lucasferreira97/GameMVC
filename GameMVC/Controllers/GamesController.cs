using GameMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameMVC.Controllers
{
    public class GamesController : Controller
    {
        //
        // GET: /Games/
        public ActionResult Index()
        {
            var game = new Game() { nome = "Battlefield 1" };
            return View();
        }
	}
}