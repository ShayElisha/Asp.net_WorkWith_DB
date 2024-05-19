using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web09052024.App_Code.BLL;

namespace web09052024
{
    public partial class productList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<product> lstProduct;
                lstProduct = (List<product>)Application["products"];
                rptProd.DataSource = lstProduct;
                rptProd.DataBind();
            }
        }
    }
}