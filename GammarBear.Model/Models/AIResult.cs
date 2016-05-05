using System;
using System.Collections.Generic;

namespace GammarBear.Model.Models
{
    public partial class AIResult
    {
        public int Id { get; set; }
        public string Request { get; set; }
        public string Respsone { get; set; }
        public string RequestClinetInfo { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsReply { get; set; }
        
    }
}
