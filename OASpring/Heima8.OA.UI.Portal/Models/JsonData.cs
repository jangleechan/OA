using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heima8.OA.UI.Portal.Models
{
    public class JsonData<T>
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public List<T> data { get; set; }
    }
}