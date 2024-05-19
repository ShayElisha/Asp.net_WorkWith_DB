using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class client
    {
        public int CusId { get; set; }
        public string CusFullName { get; set; }
        public string cusAddress { get; set; }
        public int cusCityCode { get; set; }
        public string cusPhone { get; set; }
        public string cusMail { get; set; }
        public string cusPassword { get; set; }
        public string status { get; set; }
        public string AddDate { get; set; }
    }
}