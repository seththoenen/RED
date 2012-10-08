using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace SeniorProject
{
    public partial class ViewComputers : System.Web.UI.Page
    {
        string serialNoArg = "";
        string typeArg = "";
        string formFactorArg = "";
        string manufacturerArg = "";
        string modelArg = "";
        string nameArg = "";
        string buildingArg = "";
        string roomArg = "";
        string primaryUserArg = "";
        string statusArg = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               populateDDLs();
            }
            else if (Page.IsPostBack)
            {
                SqlDataSourceComputers.SelectParameters.Clear();
                lblMessage.Visible = false;

                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, " +
                    "Logistics.Name, Inventory.Model, Inventory.Status, Computer.FormFactor, Computer.Type FROM Computer INNER JOIN Inventory ON Computer.InvID = " +
                    "Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status <> 'Transferred')");
           
                populateArgs();

                if (serialNoArg != "")
                {
                    sql.Append(" AND SerialNo LIKE '%'+@SerialNo+'%'");
                    SqlDataSourceComputers.SelectParameters.Add("SerialNo", serialNoArg);
                }

                if (typeArg != "")
                {
                    sql.Append(" AND Type LIKE '%'+@Type+'%'");
                    SqlDataSourceComputers.SelectParameters.Add("Type", typeArg);
                }

                if (formFactorArg != "")
                {
                    sql.Append(" AND FormFactor LIKE '%'+@FormFactor+'%'");
                    SqlDataSourceComputers.SelectParameters.Add("FormFactor", formFactorArg);
                }

                if (manufacturerArg != "")
                {
                    sql.Append(" AND Manufacturer LIKE '%'+@Manufacturer+'%'");
                    SqlDataSourceComputers.SelectParameters.Add("Manufacturer", manufacturerArg);
                }

                if (modelArg != "")
                {
                    sql.Append(" AND Model LIKE '%'+@Model+'%'");
                    SqlDataSourceComputers.SelectParameters.Add("Model", modelArg);
                }

                if (nameArg != "")
                {
                    sql.Append(" AND Name LIKE '%'+@Name+'%'");
                    SqlDataSourceComputers.SelectParameters.Add("Name", nameArg);
                }

                if (buildingArg != "")
                {
                    sql.Append(" AND Building LIKE '%'+@Building+'%'");
                    SqlDataSourceComputers.SelectParameters.Add("Building", buildingArg);
                }

                if (roomArg != "")
                {
                    sql.Append(" AND Room LIKE '%'+@Room+'%'");
                    SqlDataSourceComputers.SelectParameters.Add("Room", roomArg);
                }

                if (primaryUserArg != "")
                {
                    sql.Append(" AND PrimaryUser LIKE '%'+@PrimaryUser+'%'");
                    SqlDataSourceComputers.SelectParameters.Add("PrimaryUser", primaryUserArg);
                }

                if (statusArg != "")
                {
                    sql.Append(" AND Inventory.Status LIKE '%'+@Status+'%'");
                    SqlDataSourceComputers.SelectParameters.Add("Status", statusArg);
                }

                string controlID = string.Empty;
                Control control = null;
                if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EventTarget"] != string.Empty)
                {
                    controlID = Request.Form["__EVENTTARGET"];
                    control = Page.FindControl(controlID);
                    //lblControlId.Text = control.ID;

                    switch (control.ID.ToString())
                    {
                        case "SerialNoHeaderLinkButton":
                            if (GridViewComputers.SortExpression == "SerialNo" && GridViewComputers.SortDirection == SortDirection.Ascending)
                            {
                                GridViewComputers.Sort("SerialNo", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewComputers.Sort("SerialNo", SortDirection.Ascending);
                            }
                            break;
                        case "TypeHeaderLinkButton":
                            if (GridViewComputers.SortExpression == "Type" && GridViewComputers.SortDirection == SortDirection.Ascending)
                            {
                                GridViewComputers.Sort("Type", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewComputers.Sort("Type", SortDirection.Ascending);
                            }
                            break;
                        case "FormFactorHeaderLinkButton":
                            if (GridViewComputers.SortExpression == "FormFactor" && GridViewComputers.SortDirection == SortDirection.Ascending)
                            {
                                GridViewComputers.Sort("FormFactor", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewComputers.Sort("FormFactor", SortDirection.Ascending);
                            }
                            break;
                        case "ManufacturerHeaderLinkButton":
                            if (GridViewComputers.SortExpression == "Manufacturer" && GridViewComputers.SortDirection == SortDirection.Ascending)
                            {
                                GridViewComputers.Sort("Manufacturer", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewComputers.Sort("Manufacturer", SortDirection.Ascending);
                            }
                            break;
                        case "ModelHeaderLinkButton":
                            if (GridViewComputers.SortExpression == "Model" && GridViewComputers.SortDirection == SortDirection.Ascending)
                            {
                                GridViewComputers.Sort("Model", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewComputers.Sort("Model", SortDirection.Ascending);
                            }
                            break;
                        case "NameHeaderLinkButton":
                            if (GridViewComputers.SortExpression == "Name" && GridViewComputers.SortDirection == SortDirection.Ascending)
                            {
                                GridViewComputers.Sort("Name", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewComputers.Sort("Name", SortDirection.Ascending);
                            }
                            break;
                        case "BuildingHeaderLinkButton":
                            if (GridViewComputers.SortExpression == "Building" && GridViewComputers.SortDirection == SortDirection.Ascending)
                            {
                                GridViewComputers.Sort("Building", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewComputers.Sort("Building", SortDirection.Ascending);
                            }
                            break;
                        case "RoomHeaderLinkButton":
                            if (GridViewComputers.SortExpression == "Room" && GridViewComputers.SortDirection == SortDirection.Ascending)
                            {
                                GridViewComputers.Sort("Room", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewComputers.Sort("Room", SortDirection.Ascending);
                            }
                            break;
                        case "PrimaryUserHeaderLinkButton":
                            if (GridViewComputers.SortExpression == "PrimaryUser" && GridViewComputers.SortDirection == SortDirection.Ascending)
                            {
                                GridViewComputers.Sort("PrimaryUser", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewComputers.Sort("PrimaryUser", SortDirection.Ascending);
                            }
                            break;
                        case "StatusHeaderLinkButton":
                            if (GridViewComputers.SortExpression == "Status" && GridViewComputers.SortDirection == SortDirection.Ascending)
                            {
                                GridViewComputers.Sort("Status", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewComputers.Sort("Status", SortDirection.Ascending);
                            }
                            break;
                    }
                }

                sql.Append(" ORDER BY SerialNo ASC");

                SqlDataSourceComputers.SelectCommand = sql.ToString();

                GridViewComputers.DataBind();
                lblSQL.Text = sql.ToString();

                populateDDLs();
                printArgs();

            }
        }

        protected void populateArgs()
        {
            serialNoArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxSerialNoFilter")).Text;
            typeArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlTypeFilter")).Text;
            formFactorArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlFormFactorFilter")).Text;
            manufacturerArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlManufacturerFilter")).Text;
            modelArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxModelFilter")).Text;
            nameArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxNameFilter")).Text;
            buildingArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlBuildingFilter")).Text;
            roomArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxRoomFilter")).Text;
            primaryUserArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxPrimaryUserFilter")).Text;
            statusArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).Text;
        }

        protected void printArgs()
        {
            ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxSerialNoFilter")).Text = serialNoArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlTypeFilter")).Text = typeArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlFormFactorFilter")).Text = formFactorArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlManufacturerFilter")).Text = manufacturerArg;
            ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxModelFilter")).Text = modelArg;
            ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxNameFilter")).Text = nameArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlBuildingFilter")).Text = buildingArg;
            ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxRoomFilter")).Text = roomArg;
            ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxPrimaryUserFilter")).Text = primaryUserArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).Text = statusArg;
        }

        protected void populateDDLs()
        {
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlTypeFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlTypeFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlFormFactorFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlFormFactorFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlManufacturerFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlManufacturerFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlBuildingFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlBuildingFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).SelectedIndex = 0;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int invID;
                invID = Convert.ToInt32(GridViewComputers.SelectedDataKey.Value);
                Response.Redirect("~/Computer/ViewComputer.aspx?id="+invID);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //registers click event to entire grid view row
                e.Row.Attributes["OnClick"] = ClientScript.GetPostBackEventReference(this.GridViewComputers, "Select$" + e.Row.RowIndex);

                //handles on hover events
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor = '#B0B0B0';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = this.originalstyle;");           
            }
        }

        protected void GridView1_Sorted(object sender, EventArgs e)
        {

        }
    }
}