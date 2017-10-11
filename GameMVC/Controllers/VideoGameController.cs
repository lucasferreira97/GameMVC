using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameMVC.Models;
using GameMVC.ViewModels;

namespace GameMVC.Controllers
{
    public class VideoGameController : Controller
    {
        private ApplicationDbContext _context;

        public VideoGameController()
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
    }
}