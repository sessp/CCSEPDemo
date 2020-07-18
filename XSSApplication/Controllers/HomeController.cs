using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XSSApplication.Controllers
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

        [ValidateInput(false)]
        public ActionResult Reflective(string username)
        {
            ViewBag.user = username;

            return View();
        }

        [ValidateInput(false)]
        public ActionResult DOM()
        {
           

            return View();
        }

        [ValidateInput(false)]
        public ActionResult Persistent()
        {


            return View();
        }

        [ValidateInput(false)]
        public ActionResult UnReflective()
        {


            return View();
        }

        [ValidateInput(false)]
        public ActionResult UnPersistent()
        {


            return View();
        }

        [ValidateInput(false)]
        public ActionResult UnDOM()
        {


            return View();
        }
    }
}