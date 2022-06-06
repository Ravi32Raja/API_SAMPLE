using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Fulcro_api.Models
{

    public class Address
    {
        public int statusCode { get; set; }
        public string isNegativePincode { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {        
        public string city { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int pincode { get; set; }

     }
}