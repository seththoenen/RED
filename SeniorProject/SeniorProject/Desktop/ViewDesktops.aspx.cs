using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeniorProject
{
    public partial class ViewDesktops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string compID;
            compID = GridView1.SelectedDataKey.Value.ToString();
            Session["CurrentComputer"] = compID;
            Response.Redirect("~/Desktop/ViewDesktop.aspx");
        }
    }
}