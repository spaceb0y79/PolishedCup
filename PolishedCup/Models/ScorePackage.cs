using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolishedCup.Models
{
    public class ScorePackage
    {
        public int PlayerHoleDetailID { get; set; }
        public int PlayerID { get; set; }
        public int CourseID { get; set; }
        public int HoleID { get; set; }
        public int Score { get; set; }
        public Nullable<int> Putts { get; set; }
        public Nullable<bool> FairWayHit { get; set; }
        public Nullable<bool> SandSave { get; set; }
        public Nullable<bool> GIR { get; set; }
        public Nullable<bool> LostBall { get; set; }
    }
}