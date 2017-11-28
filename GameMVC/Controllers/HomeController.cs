using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameMVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Uma Lan House online, aqui você pode adicionar ou remover quaisquer games, video games e computadores que quiser.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Email: lucas97.silva@catolicasc.org.br";

            return View();
        }
    }
}