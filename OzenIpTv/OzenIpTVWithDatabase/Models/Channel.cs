using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OzenIpTVWithDatabase.Models
{
    public class Channel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}