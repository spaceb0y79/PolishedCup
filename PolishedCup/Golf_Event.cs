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
    
    public partial class Golf_Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public Nullable<int> EventGroupID { get; set; }
        public int CourseID { get; set; }
        public int TeeBoxID { get; set; }
        public Nullable<System.DateTime> EventPlayedDate { get; set; }
        public Nullable<int> TotalPlayers { get; set; }
        public Nullable<int> LowestNetScorePlayerID { get; set; }
        public Nullable<int> LowestNetScore { get; set; }
        public Nullable<int> LowestGrossScorePlayerID { get; set; }
        public Nullable<int> LowestGrossScore { get; set; }
        public Nullable<int> ScoreTypeID { get; set; }
    }
}