using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Project.Models;

namespace Web_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult SelectData()
        {
            try
            {
                SQLData _SQLData = new SQLData();
                List<MyWeb> _MyWebs = _SQLData.GetDatas();
                ViewBag.MyWeb = _MyWebs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
            return View();
        }

        public ActionResult CreateData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateData(MyWeb _MyWeb)
        {           
            try
            {
                SQLData _SQLData = new SQLData();
                _SQLData.AddData(_MyWeb);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("SelectData");
        }      

        public ActionResult FormLogin()
        {

            return View();
        }

        public ActionResult FormRegister()
        {

            return View();
        }
    }
}