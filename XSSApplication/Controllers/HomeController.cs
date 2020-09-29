using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCSEPAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            //test
        }

        [ValidateInput(false)]
        public ActionResult Persistent()
        {


            return View();
        }

        [ValidateInput(false)]
        public ActionResult UnPersistent()
        {


            return View();
        }

        [ValidateInput(false)]
        public ActionResult Admin()
        {


            return View();
        }
    }
}