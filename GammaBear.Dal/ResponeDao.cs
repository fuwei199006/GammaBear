using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GammarBear.Model.Models;

namespace GammaBear.Dal
{
    public class ResponeDao : BaseDao
    {
        
        public AICore GetReplyByRequest(string request)
        {
                var list = AiGammaBearContext.AICores.Where(r => r.AIInfomation == request).ToList();
                var count = list.Count();
                if (count > 0)
                {
                    var index = new Random().Next(count);
                    return list[index];
                }
            return new AICore();
            
        }

        public void AddAICores(string request,string response)
        {
            AiGammaBearContext.AICores.Add(new AICore() {
                AIInfomation = request,
                AIRespone = response,
                AIInfoType = "text"
            });
            AiGammaBearContext.SaveChanges();
        }

        public bool IsAISession(string SessionID)
        {
            var list = AiGammaBearContext.AISession.Where(r => r.SessionID == SessionID).ToList();
            var count = list.Count();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
