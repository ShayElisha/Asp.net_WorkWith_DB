using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web09052024.App_Code.BLL
{
    public class product
    {
        public int Pid { get; set; }
        public string pName { get; set; }
        public string pDesc { get; set; }
        public float price { get; set; }
        public string PicName { get; set; }
        public int Cid { get; set; }
        public int status { get; set; }
        public string addDate { get; set; }
    }
}