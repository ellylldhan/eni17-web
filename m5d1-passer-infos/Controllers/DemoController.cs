using m5d1_passer_infos.Models;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using System.Web.Mvc;

namespace m5d1_passer_infos.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            // Marche que pour le contexte courant
            ViewBag.Message = "Ceci est un message porté par le ViewBag.";
            var vm = new MessageViewModel
            {
                Message1 = "Ceci est un message porté par le ViewModel",
                Message2 = "Et ça c'est un autre message porté aussi par le même ViewModel"
            };
            return View(vm);
        }

        public ActionResult GetTempData()
        {
            // Peut être rediriger, existera dans la page suivante
            TempData["Message"] = "Ceci est un message porté par le TempData";
            return View();
        }

        public ActionResult GetTempData2()
        {
            // Peut être rediriger, existera dans la page suivante
            TempData["Message2"] = "Ceci est un message porté par le TempData et redirigé vers Index (existe tjs!)";
            return RedirectToAction("Index");
        }

        public ActionResult GetMessageVM()
        {
            var vm = new MessageViewModel 
            { 
                Message1 = "Ceci est un message porté par le ViewModel", 
                Message2 = "Et ça c'est un autre message porté aussi par le même ViewModel" 
            };
            return View(vm);
        }
    }
}