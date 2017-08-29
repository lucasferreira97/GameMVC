using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameMVC.Models;
using GameMVC.ViewModels;

namespace GameMVC.Controllers
{
    public class CustomersController : Controller
    {
        public List<Customer> Customers = new List<Customer>
        {
            new Customer {Name = "Trevor Belmont", Id = 1},
            new Customer {Name = "Alucard", Id = 2}
        };

        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new CustomersIndexViewModel
            {
                Customers = Customers
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            if(Customers.Count < id)
            {
                return HttpNotFound();
            }

            var customer = Customers[id - 1];

            return View(customer);
        }
    }
}