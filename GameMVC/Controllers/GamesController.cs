using GameMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            
            var game = new Game() { Name = "Call of Duty World War II" };

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

        public ActionResult New()
        {
            var viewModel = new GamesFormViewModel
            {
                Game = new Game()
            };

            return View("GameForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Game game)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GamesFormViewModel
                {
                    Game = game
                };
                return View("GameForm", viewModel);
            }

            if (game.Id == 0)
            {
                _context.Games.Add(game);
            }
            else
            {
                var gameInDb = _context.Games.Single(c => c.Id == game.Id);

                gameInDb.Name = game.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);

            if (game == null)
                return HttpNotFound();

            var viewModel = new GamesFormViewModel
            {
                Game = game
            };

            return View("GamesForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);

            if (game == null)
                return HttpNotFound();

            _context.Games.Remove(game);

            return new HttpStatusCodeResult(200);
        }
	}
}