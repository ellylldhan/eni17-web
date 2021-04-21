using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace m5d1_info_ctlr_vers_vue.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Route("welcome/{nom}/{prenom}")]
        public ActionResult Welcome(string nom, string prenom)
        {
            ViewBag.Nom = nom;
            ViewBag.Prenom = prenom;
            return View();
        }
    }
}