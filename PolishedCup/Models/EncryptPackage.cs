using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolishedCup.Models
{
    public class EncryptPackage
    {
        public string PlainTextPassword { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] Salt { get; set; }
        public int Attempts { get; set; }
    }
}