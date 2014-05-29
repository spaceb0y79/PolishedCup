
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PolishedCup.Models
{
    [DataContract]
    public class ActionResponse
    {
        [DataMember]
        public bool Success { get; set; }

        protected List<Response> messages;
        [DataMember]
        public IList<Response> Messages { get { return messages; } }

        public ActionResponse()
        {
            messages = new List<Response>();
        }
    }
}

