﻿using IntercambioProyect.Models;
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        [HttpPost]
        public ActionResult sendModel(List<Persona> persons)
        {
            Intercambio inter = new Intercambio();
            inter.setPersons(persons);
            List<Asignacion> result = inter.OrganizarIntercambio();

            return Json(result, JsonRequestBehavior.AllowGet); 
        }
    }
}
