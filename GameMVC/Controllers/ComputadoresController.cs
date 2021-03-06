﻿using GameMVC.Models;
using GameMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameMVC.Controllers
{
    public class ComputadoresController : Controller
    {
        private ApplicationDbContext _context;

        public ComputadoresController()
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
            if (User.IsInRole(RoleName.CanManageComputers))
                return View(computadores);

            return View("ReadOnlyIndex",computadores);
            
        }

        [Authorize(Roles =RoleName.CanManageComputers)]
        public ActionResult New()
        {
            var viewModel = new ComputadoresFormViewModel
            {
                Computador = new Computador()
            };

            return View("ComputadorForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageComputers)]
        public ActionResult Save(Computador computador)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ComputadoresFormViewModel
                {
                    Computador = computador
                };
                return View("ComputadorForm", viewModel);
            }

            if (computador.Id == 0)
            {
                _context.Computadores.Add(computador);
            }
            else
            {
                var computadorInDb = _context.Computadores.Single(c => c.Id == computador.Id);

                computadorInDb.Name = computador.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleName.CanManageComputers)]
        public ActionResult Edit(int id)
        {
            var computador = _context.Computadores.SingleOrDefault(c => c.Id == id);

            if (computador == null)
                return HttpNotFound();

            var viewModel = new ComputadoresFormViewModel
            {
                Computador = computador
            };

            return View("ComputadorForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageComputers)]
        public ActionResult Delete(int id)
        {
            var computador = _context.Computadores.SingleOrDefault(c => c.Id == id);

            if (computador == null)
                return HttpNotFound();

            _context.Computadores.Remove(computador);
            _context.SaveChanges();


            return new HttpStatusCodeResult(200);
        }
    }
}