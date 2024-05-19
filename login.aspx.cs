using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web09052024
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            List<client> LsClient = (List<client>)Application["clients"];

            for (int i = 0; i < LsClient.Count; i++)
            {
                if (LsClient[i].cusMail == UserEmail.Text && LsClient[i].cusPassword == UserPass.Text)
                {
                    // ניצור סשן ונשמור את האובייקט של המשתמש 
                    Session["Login"] = LsClient[i];
                    // נעביר את המשתמש לעמוד מוצרים
                    Response.Redirect("profile.aspx");
                }
            }
            LtlMsg.Text = "מייל או סיסמה אינם תקינים";
        }
    }
}