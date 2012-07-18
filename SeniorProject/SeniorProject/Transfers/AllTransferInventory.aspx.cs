using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace SeniorProject.Transfers
{
    public partial class AllTransferInventory : System.Web.UI.Page
    {
        string computerSerialNoArg = "";
        string computerTypeArg = "";
        string computerFormFactorArg = "";
        string computerManufacturerArg = "";
        string computerModelArg = "";
        string computerNameArg = "";
        string computerBuildingArg = "";
        string computerRoomArg = "";
        //string computerPrimaryUserArg = "";
        //string computerStatusArg = "";

        string equipmentSerialNoArg = "";
        string equipmentTypeArg = "";
        string equipmentManufacturerArg = "";
        string equipmentModelArg = "";
        string equipmentBuildingArg = "";
        string equipmentNameArg = "";
        string equipmentRoomArg = "";
        string equipmentPrimaryUserArg = "";
        //string equipmentStatusArg = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateComputerDDLs();
                populateEquipmentDDLs();
            }
            else
            {
                handleComputerGridView();
                handleEquipmentGridView();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int invID;
            invID = Convert.ToInt32(GridViewComputers.SelectedDataKey.Value);
            Session["CurrentComputer"] = invID;
            Response.Redirect("~/Computer/ViewDesktop.aspx");
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //registers click event to entire grid view row
                e.Row.Attributes["OnClick"] = ClientScript.GetPostBackEventReference(this.GridViewComputers, "Select$" + e.Row.RowIndex);

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

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int invID;
            invID = Convert.ToInt32(GridViewComputers.SelectedDataKey.Value);
            Session["CurrentEquipment"] = invID;
            Response.Redirect("~/Equipments/ViewEquipment.aspx");
        }

        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //registers click event to entire grid view row
                e.Row.Attributes["OnClick"] = ClientScript.GetPostBackEventReference(this.GridViewComputers, "Select$" + e.Row.RowIndex);

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

        protected void populateComputerDDLs()
        {
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlTypeFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlTypeFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlFormFactorFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlFormFactorFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlManufacturerFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlManufacturerFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlBuildingFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlBuildingFilter")).SelectedIndex = 0;
            //((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).Items.Insert(0, "");
            //((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).SelectedIndex = 0;
        }

        protected void handleComputerGridView()
        {
            SqlDataSourceComputers.SelectParameters.Clear();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, "+
                "Logistics.Name, Inventory.Model, Inventory.Status, Computer.FormFactor, Computer.Type FROM Computer INNER JOIN Inventory ON "+
                "Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') "+
                "AND (Inventory.Status = 'Transferred')");

            populateComputerArgs();

            if (computerSerialNoArg != "")
            {
                sql.Append(" AND SerialNo LIKE '%'+@SerialNo+'%'");
                SqlDataSourceComputers.SelectParameters.Add("SerialNo", computerSerialNoArg);
            }

            if (computerTypeArg != "")
            {
                sql.Append(" AND Type LIKE '%'+@Type+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Type", computerTypeArg);
            }

            if (computerFormFactorArg != "")
            {
                sql.Append(" AND FormFactor LIKE '%'+@FormFactor+'%'");
                SqlDataSourceComputers.SelectParameters.Add("FormFactor", computerFormFactorArg);
            }

            if (computerManufacturerArg != "")
            {
                sql.Append(" AND Manufacturer LIKE '%'+@Manufacturer+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Manufacturer", computerManufacturerArg);
            }

            if (computerModelArg != "")
            {
                sql.Append(" AND Model LIKE '%'+@Model+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Model", computerModelArg);
            }

            if (computerNameArg != "")
            {
                sql.Append(" AND Name LIKE '%'+@Name+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Name", computerNameArg);
            }

            if (computerBuildingArg != "")
            {
                sql.Append(" AND Building LIKE '%'+@Building+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Building", computerBuildingArg);
            }

            if (computerRoomArg != "")
            {
                sql.Append(" AND Room LIKE '%'+@Room+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Room", computerRoomArg);
            }

            //if (computerPrimaryUserArg != "")
            //{
            //    sql.Append(" AND PrimaryUser LIKE '%'+@PrimaryUser+'%'");
            //    SqlDataSourceEquipment.SelectParameters.Add("PrimaryUser", computerPrimaryUserArg);
            //}

            //if (computerStatusArg != "")
            //{
            //    sql.Append(" AND Inventory.Status LIKE '%'+@Status+'%'");
            //    SqlDataSourceComputers.SelectParameters.Add("Status", computerStatusArg);
            //}

            string controlID = string.Empty;
            Control control = null;
            if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EventTarget"] != string.Empty)
            {
                controlID = Request.Form["__EVENTTARGET"];
                control = Page.FindControl(controlID);
                //lblControlId.Text = control.ID;

                switch (control.ID.ToString())
                {
                    case "computerSerialNoHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "SerialNo" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("SerialNo", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("SerialNo", SortDirection.Ascending);
                        }
                        break;
                    case "computerTypeHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "Type" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("Type", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("Type", SortDirection.Ascending);
                        }
                        break;
                    case "computerFormFactorHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "FormFactor" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("FormFactor", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("FormFactor", SortDirection.Ascending);
                        }
                        break;
                    case "computerManufacturerHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "Manufacturer" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("Manufacturer", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("Manufacturer", SortDirection.Ascending);
                        }
                        break;
                    case "computerModelHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "Model" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("Model", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("Model", SortDirection.Ascending);
                        }
                        break;
                    case "computerNameHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "Name" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("Name", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("Name", SortDirection.Ascending);
                        }
                        break;
                    case "computerBuildingHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "Building" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("Building", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("Building", SortDirection.Ascending);
                        }
                        break;
                    case "computerRoomHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "Room" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("Room", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("Room", SortDirection.Ascending);
                        }
                        break;
                    case "computerPrimaryUserHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "PrimaryUser" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("PrimaryUser", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("PrimaryUser", SortDirection.Ascending);
                        }
                        break;
                    //case "computerStatusHeaderLinkButton":
                    //    if (GridViewComputers.SortExpression == "Status" && GridViewComputers.SortDirection == SortDirection.Ascending)
                    //    {
                    //        GridViewComputers.Sort("Status", SortDirection.Descending);
                    //    }
                    //    else
                    //    {
                    //        GridViewComputers.Sort("Status", SortDirection.Ascending);
                    //    }
                    //    break;
                }
            }

            sql.Append(" ORDER BY SerialNo ASC");

            SqlDataSourceComputers.SelectCommand = sql.ToString();

            GridViewComputers.DataBind();
            //lblSQL.Text = sql.ToString();

            populateComputerDDLs();
            printComputerArgs();
        }

        protected void populateComputerArgs()
        {
            computerSerialNoArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxSerialNoFilter")).Text;
            computerTypeArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlTypeFilter")).Text;
            computerFormFactorArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlFormFactorFilter")).Text;
            computerManufacturerArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlManufacturerFilter")).Text;
            computerModelArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxModelFilter")).Text;
            computerNameArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxNameFilter")).Text;
            computerBuildingArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlBuildingFilter")).Text;
            computerRoomArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxRoomFilter")).Text;
            //computerPrimaryUserArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxPrimaryUserFilter")).Text;
            //computerStatusArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).Text;
        }

        protected void printComputerArgs()
        {
            ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxSerialNoFilter")).Text = computerSerialNoArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlTypeFilter")).Text = computerTypeArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlFormFactorFilter")).Text = computerFormFactorArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlManufacturerFilter")).Text = computerManufacturerArg;
            ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxModelFilter")).Text = computerModelArg;
            ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxNameFilter")).Text = computerNameArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlBuildingFilter")).Text = computerBuildingArg;
            ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxRoomFilter")).Text = computerRoomArg;
            //((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxPrimaryUserFilter")).Text = computerPrimaryUserArg;
            //((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).Text = computerStatusArg;
        }

        protected void handleEquipmentGridView()
        {
            SqlDataSourceEquipment.SelectParameters.Clear();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Equipment.EquipmentType as Type, "+
                "Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Status FROM Equipment INNER JOIN "+
                "Inventory ON Equipment.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE "+
                "(Logistics.Status = 'Active') AND (Inventory.Status = 'Transferred')");

            populateEquipmentArgs();

            if (equipmentSerialNoArg != "")
            {
                sql.Append(" AND SerialNo LIKE '%'+@SerialNo+'%'");
                SqlDataSourceEquipment.SelectParameters.Add("SerialNo", equipmentSerialNoArg);
            }

            if (equipmentTypeArg != "")
            {
                sql.Append(" AND EquipmentType LIKE '%'+@Type+'%'");
                SqlDataSourceEquipment.SelectParameters.Add("Type", equipmentTypeArg);
            }

            if (equipmentManufacturerArg != "")
            {
                sql.Append(" AND Manufacturer LIKE '%'+@Manufacturer+'%'");
                SqlDataSourceEquipment.SelectParameters.Add("Manufacturer", equipmentManufacturerArg);
            }

            if (equipmentModelArg != "")
            {
                sql.Append(" AND Model LIKE '%'+@Model+'%'");
                SqlDataSourceEquipment.SelectParameters.Add("Model", equipmentModelArg);
            }

            if (equipmentNameArg != "")
            {
                sql.Append(" AND Name LIKE '%'+@Name+'%'");
                SqlDataSourceEquipment.SelectParameters.Add("Name", equipmentNameArg);
            }

            if (equipmentBuildingArg != "")
            {
                sql.Append(" AND Building LIKE '%'+@Building+'%'");
                SqlDataSourceEquipment.SelectParameters.Add("Building", equipmentBuildingArg);
            }

            if (equipmentRoomArg != "")
            {
                sql.Append(" AND Room LIKE '%'+@Room+'%'");
                SqlDataSourceEquipment.SelectParameters.Add("Room", equipmentRoomArg);
            }

            if (equipmentPrimaryUserArg != "")
            {
                sql.Append(" AND PrimaryUser LIKE '%'+@PrimaryUser+'%'");
                SqlDataSourceEquipment.SelectParameters.Add("PrimaryUser", equipmentPrimaryUserArg);
            }

            //if (equipmentStatusArg != "")
            //{
            //    sql.Append(" AND Inventory.Status LIKE '%'+@Status+'%'");
            //    SqlDataSourceEquipment.SelectParameters.Add("Status", equipmentStatusArg);
            //}

            string controlID = string.Empty;
            Control control = null;
            if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EventTarget"] != string.Empty)
            {
                controlID = Request.Form["__EVENTTARGET"];
                control = Page.FindControl(controlID);
                //lblControlId.Text = control.ID;

                switch (control.ID.ToString())
                {
                    case "equipmentSerialNoHeaderLinkButton":
                        if (GridViewEquipment.SortExpression == "SerialNo" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                        {
                            GridViewEquipment.Sort("SerialNo", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewEquipment.Sort("SerialNo", SortDirection.Ascending);
                        }
                        break;
                    case "equipmentTypeHeaderLinkButton":
                        if (GridViewEquipment.SortExpression == "Type" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                        {
                            GridViewEquipment.Sort("Type", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewEquipment.Sort("Type", SortDirection.Ascending);
                        }
                        break;
                    case "equipmentManufacturerHeaderLinkButton":
                        if (GridViewEquipment.SortExpression == "Manufacturer" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                        {
                            GridViewEquipment.Sort("Manufacturer", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewEquipment.Sort("Manufacturer", SortDirection.Ascending);
                        }
                        break;
                    case "equipmentModelHeaderLinkButton":
                        if (GridViewEquipment.SortExpression == "Model" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                        {
                            GridViewEquipment.Sort("Model", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewEquipment.Sort("Model", SortDirection.Ascending);
                        }
                        break;
                    case "equipmentNameHeaderLinkButton":
                        if (GridViewEquipment.SortExpression == "Name" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                        {
                            GridViewEquipment.Sort("Name", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewEquipment.Sort("Name", SortDirection.Ascending);
                        }
                        break;
                    case "equipmentBuildingHeaderLinkButton":
                        if (GridViewEquipment.SortExpression == "Building" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                        {
                            GridViewEquipment.Sort("Building", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewEquipment.Sort("Building", SortDirection.Ascending);
                        }
                        break;
                    case "equipmentRoomHeaderLinkButton":
                        if (GridViewEquipment.SortExpression == "Room" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                        {
                            GridViewEquipment.Sort("Room", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewEquipment.Sort("Room", SortDirection.Ascending);
                        }
                        break;
                    case "equipmentPrimaryUserHeaderLinkButton":
                        if (GridViewEquipment.SortExpression == "PrimaryUser" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                        {
                            GridViewEquipment.Sort("PrimaryUser", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewEquipment.Sort("PrimaryUser", SortDirection.Ascending);
                        }
                        break;
                    //case "equipmentStatusHeaderLinkButton":
                    //    if (GridViewEquipment.SortExpression == "Status" && GridViewEquipment.SortDirection == SortDirection.Ascending)
                    //    {
                    //        GridViewEquipment.Sort("Status", SortDirection.Descending);
                    //    }
                    //    else
                    //    {
                    //        GridViewEquipment.Sort("Status", SortDirection.Ascending);
                    //    }
                    //    break;
                }
            }

            sql.Append(" ORDER BY SerialNo ASC");

            SqlDataSourceEquipment.SelectCommand = sql.ToString();

            GridViewEquipment.DataBind();
            //lblSQL.Text = sql.ToString();

            populateEquipmentDDLs();
            printEquipmentArgs();
        }

        protected void populateEquipmentArgs()
        {
            equipmentSerialNoArg = ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxSerialNoFilter")).Text;
            equipmentTypeArg = ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlTypeFilter")).Text;
            equipmentManufacturerArg = ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlManufacturerFilter")).Text;
            equipmentModelArg = ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxModelFilter")).Text;
            equipmentNameArg = ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxNameFilter")).Text;
            equipmentBuildingArg = ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlBuildingFilter")).Text;
            equipmentRoomArg = ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxRoomFilter")).Text;
            equipmentPrimaryUserArg = ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxPrimaryUserFilter")).Text;
            //equipmentStatusArg = ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlStatusFilter")).Text;
        }

        protected void printEquipmentArgs()
        {
            ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxSerialNoFilter")).Text = equipmentSerialNoArg;
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlTypeFilter")).Text = equipmentTypeArg;
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlManufacturerFilter")).Text = equipmentManufacturerArg;
            ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxModelFilter")).Text = equipmentModelArg;
            ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxNameFilter")).Text = equipmentNameArg;
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlBuildingFilter")).Text = equipmentBuildingArg;
            ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxRoomFilter")).Text = equipmentRoomArg;
            ((TextBox)GridViewEquipment.HeaderRow.FindControl("txtBoxPrimaryUserFilter")).Text = equipmentPrimaryUserArg;
            //((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlStatusFilter")).Text = equipmentStatusArg;
        }

        protected void populateEquipmentDDLs()
        {
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlTypeFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlTypeFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlManufacturerFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlManufacturerFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlBuildingFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlBuildingFilter")).SelectedIndex = 0;
            //((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlStatusFilter")).Items.Insert(0, "");
            //((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlStatusFilter")).SelectedIndex = 0;
        }
    }
}