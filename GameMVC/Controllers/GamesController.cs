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
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        
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
            var games = _context.Games.ToList();

            return View(games);
        }
	}
}