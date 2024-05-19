using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class category
    {
        public int Cid { get; set; }
        public string Cname { get; set; }
        public string CDesc { get; set; }
        public string CPic { get; set; }
        public int ParentCid { get; set; }
        public string status { get; set; }
        public string AddDate { get; set; }
    }
}