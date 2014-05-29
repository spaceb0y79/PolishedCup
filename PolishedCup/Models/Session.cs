using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolishedCup.Models
{
    public class Session
    {
        public int UserID { get; set; }
        public string IPAddress { get; set; }
        public string OperatingSystem { get; set; }
        public string Password { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int SessionDuration { get; set; }
    }
}