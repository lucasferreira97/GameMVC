using System.Linq;
using System.Web.Mvc;
using GameMVC.Models;
using GameMVC.ViewModels;
using System.Data.Entity;

namespace GameMVC.Controllers
{
    public class CustomersController : Controller
    {
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
            var customers = _context.Customers.Include(c => c.SignatureCustomer).ToList();
            if (User.IsInRole(RoleName.CanManageCustomers))
                return View(customers);

            return View("ReadOnlyIndex", customers);
        }


        [Authorize(Roles = RoleName.CanManageCustomers)]
        public ActionResult New()
        {
            var signatureCustomer = _context.SignatureCustomer.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                SignatureCustomer = signatureCustomer
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageCustomers)]
        public ActionResult Save(Customer customer) 
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    SignatureCustomer = _context.SignatureCustomer.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                 _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                
                customerInDb.Name = customer.Name;
                customerInDb.SignatureCustomerId = customer.SignatureCustomerId;
                customerInDb.isPremium = customer.isPremium;
                customerInDb.Birthdate = customer.Birthdate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleName.CanManageCustomers)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                SignatureCustomer = _context.SignatureCustomer.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageCustomers)]
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
           
            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }

    }
}