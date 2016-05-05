using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using GammaBear.Dal;
using GammarBear.Model.Models;

namespace WebApplication.Controllers
{

    public class HomeController : Controller
    {
        public Dictionary<string, List<AISessionTemp>> tempSession;
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
            request = request.Replace("\n", "");

            SemanticAnalysis(request);
            return null;

            var responseDao = new ResponeDao();
            var response = responseDao.GetReplyByRequest(request);
            int qaState = 0;
            if (string.IsNullOrEmpty(response.AIInfomation))
            {
                response.AIRespone = "什么意思？";
                qaState = 112233499;
            }
            //判断是复存在会话
            if (Session["tempSession"] != null)
            {
                tempSession = (Dictionary<string, List<AISessionTemp>>)Session["tempSession"];
                var lastSortID = tempSession[Session.SessionID].Last().SortID;
                if (request.Contains("good"))
                {
                    tempSession[Session.SessionID].Last().State++;
                }
                if (request.Contains("bad"))
                {
                    tempSession[Session.SessionID].Last().State--;
                }
                if (tempSession[Session.SessionID].Last().State == 112233499)
                {
                    responseDao.AddAICores(tempSession[Session.SessionID].Last().RequestText, request);
                    response.AIRespone = "哦，我知道了。";
                    qaState = 0;
                }
                tempSession[Session.SessionID].Add(new AISessionTemp()
                {
                    SessionID = Session.SessionID,
                    RequestText = request,
                    ResponseText = response.AIRespone,
                    State = qaState,
                    SortID = lastSortID++
                });
                Session["tempSession"] = tempSession;
            }
            else
            {
                tempSession = new Dictionary<string, List<AISessionTemp>>();
                var tempList = new List<AISessionTemp>();
                tempList.Add(new AISessionTemp()
                {
                    SessionID = Session.SessionID,
                    RequestText = request,
                    ResponseText = response.AIRespone,
                    State = qaState,
                    SortID = 0
                });
                tempSession.Add(Session.SessionID, tempList);
                Session["tempSession"] = tempSession;
            }

            return Json(response.AIRespone);
        }

        string[] stringarray = { "南京", "南京市" , "市长", "长江", "大桥" };

        public void SemanticAnalysis(string requestStr)
        {
            char[] strArray = requestStr.ToArray();
            string tempstr = "";
            string tempstr2 = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                tempstr += strArray[i] + ",";
                for (int j = (i+1); j < strArray.Length; j++)
                {
                    tempstr = tempstr.TrimEnd(',') + strArray[j];
                    if (!stringarray.Contains(tempstr))
                    {
                        tempstr = "";
                        break;
                    }
                    else
                    {
                        tempstr2 += tempstr + ",";
                    }
                }
            }
        }


    }


    public class AISessionTemp
    {
        public int Id { get; set; }
        public string SessionID { get; set; }
        public string RequestText { get; set; }
        public string ResponseText { get; set; }
        public int State { get; set; }
        public int SortID { get; set; }
    }
}