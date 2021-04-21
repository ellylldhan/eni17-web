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
            ViewBag.Message = "Ceci est un message porté par le ViewBag.";
            return View();
        }

        public ActionResult GetTempData()
        {
            TempData["Message"] = "Ceci est un message porté par le TempData";
            return RedirectToAction("Index");
        }

        public ActionResult GetMessageVM()
        {
            var vm = new MessageVM { Message = "Ceci est un message porté par le ViewModel" };
            return View("Index", vm);
        }
    }
}