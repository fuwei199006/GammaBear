using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using GammaBear.Dal;

namespace WebApplication.Controllers
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


        public JsonResult GetReply(string request)
        {
            
            var responseDao = new ResponeDao();
            var response = responseDao.GetReplyByRequest(request);
            if (string.IsNullOrEmpty(response.AIInfomation))
                response.AIRespone = "......";
            return Json(response.AIRespone);
        }
    }
}