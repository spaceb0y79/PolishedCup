using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PolishedCup.Enum;

namespace PolishedCup.Models
{
    public class Response
    {
        public string ErrorMessage { get; set; }
        //public string ErrorCode { get; set; }
        public ErrorCode ErrorCode { get; set; }
    }
}