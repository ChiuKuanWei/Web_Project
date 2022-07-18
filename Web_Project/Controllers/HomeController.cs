using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Project.Controllers
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

        public ActionResult DataTable_Create()
        {
            return View();
        }

        public ActionResult MyCardPage()
        {
            return View();
        }

        public ActionResult CssPosition()
        {
            return View();
        }

        public ActionResult MyCard_HW1()
        {
            return View();
        }
    }
}