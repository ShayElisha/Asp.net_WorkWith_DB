using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using web09052024.App_Code.BLL;
using System.Configuration;

namespace web09052024
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            List<product> products = new List<product>();
            string connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            string sql = "select * from T_Product";
            SqlConnection conn= new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader Dr = cmd.ExecuteReader();
            while (Dr.Read())
            {
                product Tmp3 = new product()
                {
                    Pid = int.Parse(Dr["Pid"] + ""),
                    pName = Dr["pName"] + "",
                    price = float.Parse(Dr["price"] + ""),
                    pDesc = Dr["pDesc"] + "",
                    PicName = Dr["PicName"] + ""
                };
                products.Add(Tmp3);
            }
            conn.Close();
            Application["Prods"]=products;

            List<category> categories = new List<category>();
            connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            sql = "select * from T_Categort";
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            SqlDataReader Dr1 = cmd1.ExecuteReader();
            while (Dr1.Read())
            {
                category Tmp3 = new category()
                {
                    Cid = int.Parse(Dr1["Cid"] + ""),
                    Cname = Dr1["Cname"] + "",
                    CDesc = Dr1["CDesc"] + "",
                    CPic = Dr1["CPic"] + ""
                };
                categories.Add(Tmp3);
            }
            conn.Close();
            Application["categories"] = categories;

            List<client> LsClient = new List<client>();// הגדרת רשימה עבור לקוחות
            client Tmp;
            Tmp = new client()
            {
                CusFullName = "shay",
                cusMail = "shayelisha2312@gmail.com",
                cusPassword = "shay1234"
            };
            LsClient.Add(Tmp);
            Tmp = new client()
            {
                CusFullName = "nati",
                cusMail = "nati@gmail.com",
                cusPassword = "nati1234"
            };
            LsClient.Add(Tmp);
            Tmp = new client()
            {
                CusFullName = "vered",
                cusMail = "vered@gmail.com",
                cusPassword = "vered1234"
            };
            LsClient.Add(Tmp);
            Tmp = new client()
            {
                CusFullName = "orel",
                cusMail = "orel@gmail.com",
                cusPassword = "orel1234"
            };
            LsClient.Add(Tmp);
            Tmp = new client()
            {
                CusFullName = "yaron",
                cusMail = "yaron@gmail.com",
                cusPassword = "yaron1234"
            };
            LsClient.Add(Tmp);
            Application["Clients"] = LsClient;

            List<city> Cities = new List<city>();
            city tmp;
            tmp = new city();
            tmp = new city()
            {
                CityId = 1,
                CityName = "Ashkelon",
            };
            Cities.Add(tmp);
            tmp = new city()
            {
                CityId = 2,
                CityName = "hifa",
            };
            Cities.Add(tmp);
            tmp = new city()
            {
                CityId = 3,
                CityName = "Ashdod",
            };
            Cities.Add(tmp);
            tmp = new city()
            {
                CityId = 4,
                CityName = "Tel Aviv",
            };
            Cities.Add(tmp);
            Application["cities"] = Cities;

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}