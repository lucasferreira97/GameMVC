using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using GameMVC.Models;
using GameMVC.ViewModels;

namespace GameMVC.Controllers
{
    public class VideoGamesController : Controller
    {
        private ApplicationDbContext _context;

        public VideoGamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: VideoGame
        public ActionResult Index()
        {
            var videoGames = _context.VideoGames.ToList();
            return View(videoGames);
        }

        public ActionResult New()
        {
            var viewModel = new VideoGamesFormViewModel
            {
                VideoGame = new VideoGame()
            };

            return View("VideoGamesForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(VideoGame videoGame)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VideoGamesFormViewModel
                {
                    VideoGame = videoGame
                };
                return View("VideoGamesForm", viewModel);
            }

            if (videoGame.Id == 0)
            {
                _context.VideoGames.Add(videoGame);
            }
            else
            {
                var videoGameInDb = _context.VideoGames.Single(c => c.Id == videoGame.Id);

                videoGameInDb.Name = videoGame.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var videoGame = _context.VideoGames.SingleOrDefault(c => c.Id == id);

            if (videoGame == null)
                return HttpNotFound();

            var viewModel = new VideoGamesFormViewModel
            {
                VideoGame = videoGame
            };

            return View("VideoGamesForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var videoGame = _context.VideoGames.SingleOrDefault(c => c.Id == id);

            if (videoGame == null)
                return HttpNotFound();

            _context.VideoGames.Remove(videoGame);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}