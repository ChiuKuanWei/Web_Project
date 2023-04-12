using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
                TempData["ErrorMessage"] = "新增錯誤：" + ex.Message;
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
                TempData["ErrorMessage"] = "編輯錯誤：" + ex.Message;
            }

            return RedirectToAction("SelectData");
        }

        public ActionResult DeleteData(string sUser_CreateTime)
        {
            try
            {
                SQLData _SQLData = new SQLData();
                _SQLData.DeleteData(sUser_CreateTime);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "刪除錯誤：" + ex.Message;
            }
           
            return RedirectToAction("SelectData");
        }

        public ActionResult LineNotify_View()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Push(string sMsg)
        {
            try
            {
                string url = "https://notify-api.line.me/api/notify";
                //要傳送的文字內容
                string postData = "message=" + WebUtility.HtmlEncode("\r\n" + sMsg);
                //string postData = "imageFile=" + WebUtility.HtmlEncode("\r\n" + message);            
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                Uri target = new Uri(url);
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                //System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebRequest request = WebRequest.Create(target);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                request.Headers.Add("Authorization", "Bearer " + "V2dpYJeveQ3WZt4M9GTIPM8OtizbZmeWFY1pZlMPZCr");

                using (var dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                //取得響應
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();//回傳JSON
                responseString = "[" + responseString + "]";
                //取得目前剩餘發送數量
                String str = string.Empty;
                for (int i = 0; i < response.Headers.Keys.Count; i++)
                {
                    str += response.Headers.Keys[i] + ":" + response.Headers.Get(i) + "\n";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "推播錯誤：" + ex.Message;
            }

            return RedirectToAction("LineNotify_View");
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