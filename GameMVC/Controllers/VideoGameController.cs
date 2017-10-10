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
        // GET: VideoGame
        public ActionResult Index()
        {
            var videoGames = new List<VideoGame>
            {
                new VideoGame{Name = "Playstation 4"},
                new VideoGame{Name = "Xbox One"}
            };

            var viewModel = new VideoGamesIndexViewModel
            {
                VideoGames = videoGames
            };

            return View(viewModel);
        }
    }
}