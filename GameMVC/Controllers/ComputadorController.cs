using GameMVC.Models;
using GameMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameMVC.Controllers
{
    public class ComputadorController : Controller
    {
        // GET: Computador
        public ActionResult Index()
        {
           var computadores = new List<Computador>
            {
                new Computador{Name = "PCNET1"},
                new Computador{Name = "PCGAME1"}
            };

            var viewModel = new ComputadoresIndexViewModel
            {
                Computadores = computadores
            };

            return View(viewModel);
            
        }
    }
}