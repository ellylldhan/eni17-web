using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace m5d1_info_ctlr_vers_vue.Controllers
{
    public class DemoController : Controller
    {
        [Route("demo")]
        public ActionResult Index()
        {
            ViewBag.Message = "Ceci est un message porté par le ViewBag";
            return View();
        }
    }
}