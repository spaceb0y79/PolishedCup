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
    
    public partial class Golf_Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool Active { get; set; }
        public int Status { get; set; }
        public System.DateTime CreatedDateUTC { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDateUTC { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
    }
}