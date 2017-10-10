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
        private ApplicationDbContext _context;

        public ComputadorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Computador
        public ActionResult Index()
        {
            var computadores = _context.Computadores.ToList();
            return View(computadores);
        }
    }
}