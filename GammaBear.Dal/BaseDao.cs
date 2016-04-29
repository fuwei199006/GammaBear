using System.Configuration;
using GammarBear.Model.Models;

namespace GammaBear.Dal
{
   public class BaseDao
    {
       protected readonly AIGammaBearContext AiGammaBearContext;
       public BaseDao( )
       {
           AiGammaBearContext = new AIGammaBearContext();
        
       }
    }
}
