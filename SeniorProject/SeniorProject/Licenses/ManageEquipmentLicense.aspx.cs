using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeniorProject.Licenses
{
    public partial class ManageEquipmentLicense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Authenticated"].ToString() != "True")
            {
                Response.Redirect("~/default.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int invID;
            invID = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            Session["CurrentEquipment"] = invID;
            Response.Redirect("~/Equipments/ViewEquipment.aspx");
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //registers click event to entire grid view row
                e.Row.Attributes["OnClick"] = ClientScript.GetPostBackEventReference(this.GridView1, "Select$" + e.Row.RowIndex);

                //handles on hover events
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor = '#B0B0B0';");
                if (e.Row.RowState == DataControlRowState.Normal)
                {
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = '#F7F6F3';");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = 'White';");
                }
            }
        }
    }
}