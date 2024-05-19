using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web09052024.App_Code.BLL;

namespace web09052024.AdminMenage
{
    public partial class prodAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string Pid = Request["Pid"] + "";
                if (string.IsNullOrEmpty(Pid))
                {
                    Pid = "-1";
                }
                else
                {
                    int pid= int.Parse(Pid);
                    List<product> LstProduct = (List<product>)Application["Prods"] ;
                    for(int i = 0; i < LstProduct.Count; i++)
                    {
                        if (LstProduct[i].Pid == pid)
                        {
                            TxtPname.Text = LstProduct[i].pName;
                            TxtPrice.Text = LstProduct[i].price+"";
                            TxtDesc.Text = LstProduct[i].pDesc;
                            TxtPic.Text = LstProduct[i].PicName;
                            hidPid.Value = Pid; 
                        }
                    }
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (hidPid.Value == "-1")
            {
                sql = "insert into T_Product(pName,price,pDesc,PicName) values ";
                sql += $" N'{TxtPname.Text}',N'{TxtPrice.Text}',N'{TxtDesc.Text}',N'{TxtPic.Text}'";
            }
            else
            {
                sql = "update T_Product set ";
                sql += $" pName=N'{TxtPname.Text}',";
                sql += $" price='{TxtPrice.Text}',";
                sql += $" pDesc=N'{TxtDesc.Text}',";
                sql += $" PicName=N'{TxtPic.Text}'";
                sql += $" where Pid='{hidPid.Value}'";
            }
            
            

            string connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            List<product> products = new List<product>();
            sql = "select * from T_Product";
            cmd.CommandText = sql;
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

            Application["Prods"] = products;
            Response.Redirect("productsList.aspx");
        }
    }
}