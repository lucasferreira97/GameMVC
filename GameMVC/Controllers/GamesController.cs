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

        public ActionResult Index()
        {
            var games = _context.Games.ToList();
            if (User.IsInRole(RoleName.CanManageGames))
                return View(games);
            return View("ReadOnlyIndex", games);
        }

        [Authorize(Roles = RoleName.CanManageGames)]
        public ActionResult New()
        {
            var viewModel = new GamesFormViewModel
            {
                Game = new Game()
            };

            return View("GameForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageGames)]
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

        [Authorize(Roles = RoleName.CanManageGames)]
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

        [Authorize(Roles = RoleName.CanManageGames)]
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