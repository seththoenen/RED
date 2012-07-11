using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace SeniorProject
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[,] args = (string[,])Session["SearchArgs"];

                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, " +
                    "Logistics.Name, Inventory.Model, Inventory.Status, Computer.FormFactor, Computer.Type FROM Computer INNER JOIN Inventory ON " +
                    "Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active')");
                for (int i = 0; i < args.GetLength(0); i++)
                {
                    if (args[i, 1] != "")
                    {
                        sql.Append(" AND " + args[i, 0] + " LIKE '%'+@arg" + i + "+'%'");
                        SqlDataSource1.SelectParameters.Add(("arg" + i), args[i, 1].ToString());
                    }
                }
                sql.Append(" AND ((Inventory.Status = 'Active') OR (Inventory.Status = 'Storage')) ORDER BY Inventory.SerialNo ASC");
                SqlDataSource1.SelectCommand = sql.ToString();
                lblComputerSQL.Text = sql.ToString();
                sql.Clear();

                sql.Append("SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Equipment.EquipmentType, " +
                    "Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Status FROM Equipment INNER JOIN Inventory ON " +
                    "Equipment.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') " +
                    "AND ((Inventory.Status = 'Active') OR (Inventory.Status = 'Storage'))");
                for (int i = 0; i < args.GetLength(0); i++)
                {
                    if (args[i, 1] != "")
                    {
                        sql.Append(" AND " + args[i, 0] + " LIKE '%'+@arg" + i + "+'%'");
                        SqlDataSource2.SelectParameters.Add(("arg" + i), args[i, 1].ToString());
                    }
                }
                sql.Append(" ORDER BY Inventory.SerialNo ASC");
                lblEquipmentSQL.Text = sql.ToString();
                SqlDataSource2.SelectCommand = sql.ToString();
                GridView1.DataBind();
                GridView2.DataBind();

                if (GridView1.Rows.Count == 0)
                {
                    lblComputers.Visible = true;
                }
                if (GridView2.Rows.Count == 0)
                {
                    lblEquipment.Visible = true;
                }
            }
            else
            {
                SqlDataSource1.SelectCommand = lblComputerSQL.Text;
                SqlDataSource2.SelectCommand = lblEquipmentSQL.Text;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int invID;
            invID = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            Session["CurrentComputer"] = invID;
            Response.Redirect("~/Computer/ViewDesktop.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int invID;
            invID = Convert.ToInt32(GridView2.SelectedDataKey.Value);
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

        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //registers click event to entire grid view row
                e.Row.Attributes["OnClick"] = ClientScript.GetPostBackEventReference(this.GridView2, "Select$" + e.Row.RowIndex);

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