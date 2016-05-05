using System;
using System.Collections.Generic;

namespace GammarBear.Model.Models
{
    public partial class AISession
    {
        public int Id { get; set; }
        public string SessionID { get; set; }
        public string RequestText { get; set; }
        public string ResponseText { get; set; }
        public int State { get; set; }
    }
}
