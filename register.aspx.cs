using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web09052024.App_Code.BLL;

namespace web09052024
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }
        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            bool check = true;
            List<client> clients = (List<client>)Application["Clients"];
            if (!string.IsNullOrEmpty(UserName.Text) &&
                !string.IsNullOrEmpty(UserPass.Text) &&
                !string.IsNullOrEmpty(validPass.Text) &&
                !string.IsNullOrEmpty(DDlCity.Text))
            {
                if (UserPass.Text == validPass.Text)
                {
                    // בדיקה האם קיים לקוח עם אותה כתובת אימייל כבר ברשימה
                    if (clients.Exists(c => c.cusMail == Email.Text))
                    {
                        check = false;
                        Warning.Text = "המשתמש קיים במערכת";
                    }
                    if (check)
                    {
                        client tmp;
                        tmp = new client()
                        {
                            CusFullName = UserName.Text,
                            cusMail = Email.Text,
                            cusPassword = UserPass.Text,
                            cusCityCode = int.Parse(DDlCity.SelectedValue),
                            cusAddress = DDlCity.Text
                        };
                        clients.Add(tmp);
                        Application["Clients"] = clients;
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    Warning.Text = "הסיסמאות לא תואמות";
                }
            }
            else
            {
                Warning.Text = "מלא את כל השדות ";
            }
        }
    }
}