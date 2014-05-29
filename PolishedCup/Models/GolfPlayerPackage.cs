using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolishedCup.Models
{
    public class GolfPlayerPackage : Golf_Player
    {
        public string NewPasswordPlainText { get; set; }
        public string OldPasswordPlainText { get; set; }
    }
}