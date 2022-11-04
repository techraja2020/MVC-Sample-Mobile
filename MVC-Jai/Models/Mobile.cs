using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Jai.Models
{
    public class Mobile
    {
        public string ModelNumber { get; set; }
        public Int32 Price { get; set; }
        public string Brand { get; set; }

        public Int32 Discount { get; set; }
    }
}