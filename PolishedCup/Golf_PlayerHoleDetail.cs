//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PolishedCup
{
    using System;
    using System.Collections.Generic;
    
    public partial class Golf_PlayerHoleDetail
    {
        public int PlayerHoleDetailID { get; set; }
        public int PlayerID { get; set; }
        public int EventID { get; set; }
        public int HoleID { get; set; }
        public int CourseID { get; set; }
        public int Score { get; set; }
        public Nullable<int> Putts { get; set; }
        public int ScoreTypeID { get; set; }
        public Nullable<bool> FairWayHit { get; set; }
        public Nullable<bool> SandSave { get; set; }
        public Nullable<bool> GIR { get; set; }
        public Nullable<bool> LostBall { get; set; }
    }
}
