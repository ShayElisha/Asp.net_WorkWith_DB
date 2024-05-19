using BLL;
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
    public partial class CatAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Cid = Request["Cid"] + "";
                if (string.IsNullOrEmpty(Cid))
                {
                    Cid = "-1";
                }
                else
                {
                    int cid = int.Parse(Cid);
                    List<category> lsCategory = (List<category>)Application["categories"];
                    for (int i = 0; i < lsCategory.Count; i++)
                    {
                        if (lsCategory[i].Cid == cid)
                        {
                            TxtCname.Text = lsCategory[i].Cname;
                            TxtDesc.Text = lsCategory[i].CDesc;
                            TxtPic.Text = lsCategory[i].CPic;
                            hidCid.Value = Cid;
                        }
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (hidCid.Value == "-1")
            {
                sql = "insert into T_Categort(Cname,CDesc,CPic) values ";
                sql += $" N'{TxtCname.Text}',N'{TxtDesc.Text}',N'{TxtPic.Text}'";
            }
            else
            {
                sql = "update T_Categort set ";
                sql += $" Cname=N'{TxtCname.Text}',";
                sql += $" CDesc=N'{TxtDesc.Text}',";
                sql += $" CPic=N'{TxtPic.Text}'";
                sql += $" where Cid='{hidCid.Value}'";
            }



            string connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            List<category> cat = new List<category>();
            sql = "select * from T_Categort";
            cmd.CommandText = sql;
            SqlDataReader Dr = cmd.ExecuteReader();
            while (Dr.Read())
            {
                category tmp3 = new category()
                {
                    Cid = int.Parse(Dr["Cid"] + ""),
                    Cname = Dr["Cname"] + "",
                    CDesc= Dr["CDesc"] + "",
                    CPic = Dr["CPic"] + ""
                };
                cat.Add(tmp3);
            }
            conn.Close();

            Application["categories"] = cat;
            Response.Redirect("CategoryList.aspx");
        }
    }
}