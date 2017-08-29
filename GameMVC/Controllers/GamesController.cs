using GameMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameMVC.Models;
using GameMVC.ViewModels;

namespace GameMVC.Controllers
{
    public class GamesController : Controller
    {
        // GET: /Games/Random
        public ActionResult Random()
        {
            var game = new Game() { nome = "Call of Duty World War II" };

            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                new Customer{Name = "Customer 2"}
            };

            var viewModel = new RandomGameViewModel
            {
                Game = game,
                Customers = customers
            };

            return View(viewModel);
        }



        public ActionResult Index()
        {
            var games = new List<Game>()
            {
                new Game {nome = "Call of Duty World War II" },
                new Game {nome = "Battlefield 1"}
            };

            var viewModel = new GamesIndexViewModel
            {
                Games = games
            };

            return View(viewModel);
        }
	}
}