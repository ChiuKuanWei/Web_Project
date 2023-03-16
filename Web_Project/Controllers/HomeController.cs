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

            SQLData _SQLData = new SQLData();
            List<MyWeb> _MyWebs = _SQLData.GetDatas();
            if (_MyWebs.Count == 0)
            {
                ViewBag.Message = "查無資料!";
            }

            ViewBag.MyWeb = _MyWebs;

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
                
            }
            return RedirectToAction("SelectData");
        }

        public ActionResult EditData(string sUser_CreateTime)
        {
            SQLData _SQLData = new SQLData();
            MyWeb _myweb = _SQLData.GetData(sUser_CreateTime);
            //將回傳的 MyWeb 用傳遞 model 的方式傳到 View
            return View(_myweb);
        }

        [HttpPost]
        public ActionResult EditData(MyWeb _MyWeb)
        {
            try
            {
                SQLData _SQLData = new SQLData();
                _SQLData.UpdateData(_MyWeb);

            }
            catch (Exception ex)
            {
                
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