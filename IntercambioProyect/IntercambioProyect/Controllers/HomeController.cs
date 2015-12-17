using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntercambioProyect.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

<<<<<<< HEAD
=======
            return View();
        }
        public ActionResult HolaSoyRamiro()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
>>>>>>> 262fdc2594c6d614403e7ebdb0eb8ade23496c4a
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
