using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace SeniorProject
{
    public partial class ViewEquipments : System.Web.UI.Page
    {
        string serialNoArg = "";
        string typeArg = "";
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
                SqlDataSourceEquipment.SelectParameters.Clear();

                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Equipment.EquipmentType as Type, Logistics.Building, "+
                    "Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Status FROM Equipment INNER JOIN Inventory ON Equipment.InvID = Inventory.InvID "+
                    "INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status <> 'Transferred')");

                populateArgs();

                if (serialNoArg != "")
                {
                    sql.Append(" AND SerialNo LIKE '%'+@SerialNo+'%'");
                    SqlDataSourceEquipment.SelectParameters.Add("SerialNo", serialNoArg);
                }

                if (typeArg != "")
                {
                    sql.Append(" AND EquipmentType LIKE '%'+@Type+'%'");
                    SqlDataSourceEquipment.SelectParameters.Add("Type", typeArg);
                }

                if (manufacturerArg != "")
                {
                    sql.Append(" AND Manufacturer LIKE '%'+@Manufacturer+'%'");
                    SqlDataSourceEquipment.SelectParameters.Add("Manufacturer", manufacturerArg);
                }

                if (modelArg != "")
                {
                    sql.Append(" AND Model LIKE '%'+@Model+'%'");
                    SqlDataSourceEquipment.SelectParameters.Add("Model", modelArg);
                }

                if (nameArg != "")
                {
                    sql.Append(" AND Name LIKE '%'+@Name+'%'");
                    SqlDataSourceEquipment.SelectParameters.Add("Name", nameArg);
                }

                if (buildingArg != "")
                {
                    sql.Append(" AND Building LIKE '%'+@Building+'%'");
                    SqlDataSourceEquipment.SelectParameters.Add("Building", buildingArg);
                }

                if (roomArg != "")
                {
                    sql.Append(" AND Room LIKE '%'+@Room+'%'");
                    SqlDataSourceEquipment.SelectParameters.Add("Room", roomArg);
                }

                if (primaryUserArg != "")
                {
                    sql.Append(" AND PrimaryUser LIKE '%'+@PrimaryUser+'%'");
                    SqlDataSourceEquipment.SelectParameters.Add("PrimaryUser", primaryUserArg);
                }

                if (statusArg != "")
                {
                    sql.Append(" AND Inventory.Status LIKE '%'+@Status+'%'");
                    SqlDataSourceEquipment.SelectParameters.Add("Status", statusArg);
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
                            if (GridViewEquipment.SortExpression == "SerialNo" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                            {
                                GridViewEquipment.Sort("SerialNo", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewEquipment.Sort("SerialNo", SortDirection.Ascending);
                            }
                            break;
                        case "TypeHeaderLinkButton":
                            if (GridViewEquipment.SortExpression == "Type" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                            {
                                GridViewEquipment.Sort("Type", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewEquipment.Sort("Type", SortDirection.Ascending);
                            }
                            break;
                        case "ManufacturerHeaderLinkButton":
                            if (GridViewEquipment.SortExpression == "Manufacturer" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                            {
                                GridViewEquipment.Sort("Manufacturer", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewEquipment.Sort("Manufacturer", SortDirection.Ascending);
                            }
                            break;
                        case "ModelHeaderLinkButton":
                            if (GridViewEquipment.SortExpression == "Model" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                            {
                                GridViewEquipment.Sort("Model", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewEquipment.Sort("Model", SortDirection.Ascending);
                            }
                            break;
                        case "NameHeaderLinkButton":
                            if (GridViewEquipment.SortExpression == "Name" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                            {
                                GridViewEquipment.Sort("Name", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewEquipment.Sort("Name", SortDirection.Ascending);
                            }
                            break;
                        case "BuildingHeaderLinkButton":
                            if (GridViewEquipment.SortExpression == "Building" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                            {
                                GridViewEquipment.Sort("Building", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewEquipment.Sort("Building", SortDirection.Ascending);
                            }
                            break;
                        case "RoomHeaderLinkButton":
                            if (GridViewEquipment.SortExpression == "Room" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                            {
                                GridViewEquipment.Sort("Room", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewEquipment.Sort("Room", SortDirection.Ascending);
                            }
                            break;
                        case "PrimaryUserHeaderLinkButton":
                            if (GridViewEquipment.SortExpression == "PrimaryUser" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                            {
                                GridViewEquipment.Sort("PrimaryUser", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewEquipment.Sort("PrimaryUser", SortDirection.Ascending);
                            }
                            break;
                        case "StatusHeaderLinkButton":
                            if (GridViewEquipment.SortExpression == "Status" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                            {
                                GridViewEquipment.Sort("Status", SortDirection.Descending);
                            }
                            else
                            {
                                GridViewEquipment.Sort("Status", SortDirection.Ascending);
                            }
                            break;
                    }
                }

                sql.Append(" ORDER BY SerialNo ASC");

                SqlDataSourceEquipment.SelectCommand = sql.ToString();

                GridViewEquipment.DataBind();
                //lblSQL.Text = sql.ToString();

                populateDDLs();
                printArgs();
            }
        }

        protected void populateArgs()
        {
            serialNoArg = ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxSerialNoFilter")).Text;
            typeArg = ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlTypeFilter")).Text;
            manufacturerArg = ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlManufacturerFilter")).Text;
            modelArg = ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxModelFilter")).Text;
            nameArg = ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxNameFilter")).Text;
            buildingArg = ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlBuildingFilter")).Text;
            roomArg = ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxRoomFilter")).Text;
            primaryUserArg = ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxPrimaryUserFilter")).Text;
            statusArg = ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlStatusFilter")).Text;
        }

        protected void printArgs()
        {
            ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxSerialNoFilter")).Text = serialNoArg;
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlTypeFilter")).Text = typeArg;
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlManufacturerFilter")).Text = manufacturerArg;
            ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxModelFilter")).Text = modelArg;
            ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxNameFilter")).Text = nameArg;
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlBuildingFilter")).Text = buildingArg;
            ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxRoomFilter")).Text = roomArg;
            ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxPrimaryUserFilter")).Text = primaryUserArg;
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlStatusFilter")).Text = statusArg;
        }

        protected void populateDDLs()
        {
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlTypeFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlTypeFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlManufacturerFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlManufacturerFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlBuildingFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlBuildingFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlStatusFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlStatusFilter")).SelectedIndex = 0;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int invID;
            invID = Convert.ToInt32(GridViewEquipment.SelectedDataKey.Value);
            Response.Redirect("~/Equipments/ViewEquipment.aspx?id="+invID);
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //registers click event to entire grid view row
                e.Row.Attributes["OnClick"] = ClientScript.GetPostBackEventReference(this.GridViewEquipment, "Select$" + e.Row.RowIndex);

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