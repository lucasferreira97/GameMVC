﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameMVC.Models;
using GameMVC.ViewModels;
using System.Data.Entity;

namespace GameMVC.Controllers
{
    public class CustomersController : Controller
    {
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>{
                
                new Customer() {Name = "Trevor Belmont", Id = 1},
                new Customer() {Name = "Alucard", Id = 2}
        
            };
        }

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c=> c.Id == id);
            
            if(customer == null)          
                return HttpNotFound();
            
            return View(customer);
        }
    }
}