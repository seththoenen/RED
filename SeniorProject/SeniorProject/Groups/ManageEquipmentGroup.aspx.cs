using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Collections;

namespace SeniorProject.Groups
{
    public partial class ManageEquipmentGroup : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;

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
                if (Session["CurrentGroup"] == null)
                {
                    Response.Redirect("~/Groups/ManageGroups.aspx");
                }
                txtBoxSerialNo.Focus();

                populateDDLs();
            }
            else
            {
                handleGridView();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int equipID;
            equipID = Convert.ToInt32(GridView2.SelectedDataKey.Value);
            Session["CurrentEquipment"] = equipID;
            Response.Redirect("~/Equipments/ViewEquipment.aspx");
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
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

        protected void btnAddEquipment_Click(object sender, EventArgs e)
        {
            if (btnAddEquipment.Text == "Add Equipment to Group")
            {
                panelAddEquipment.Visible = true;
                panelEquipment.Visible = false;
                btnCancelAddEquipment.Visible = true;
                btnAddEquipment.Text = "Add Selected Equipment";
            }
            else if (btnAddEquipment.Text == "Add Selected Equipment")
            {
                ArrayList serialNos = new ArrayList();
                for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
                {
                    serialNos.Add(lstBoxSerialNos.Items[i].Text);
                }
                lblMessage.Visible = true;
                lblMessage.Text = GroupDA.addInvToGroup(serialNos, Convert.ToInt32(Session["CurrentGroup"]), connString);
                if (lblMessage.Text == "Inventory added successfully!<bR>")
                {
                    panelAddEquipment.Visible = false;
                    panelEquipment.Visible = true;
                    btnCancelAddEquipment.Visible = false;
                    btnAddEquipment.Text = "Add Equipment to Group";
                    GridView2.DataBind();
                    lstBoxSerialNos.Items.Clear();
                }               
            }
        }

        protected void btnCancelAddEquipment_Click(object sender, EventArgs e)
        {
            panelAddEquipment.Visible = false;
            panelEquipment.Visible = true;
            btnCancelAddEquipment.Visible = false;
            btnAddEquipment.Text = "Add Equipment to Group";
        }

        protected void GridViewEquipment_RowCreated(object sender, GridViewRowEventArgs e)
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

        protected void GridViewEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string serialNo = GridViewEquipment.SelectedDataKey["SerialNo"].ToString();

            bool existLB = false;
            for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
            {
                if (lstBoxSerialNos.Items[i].Text == serialNo || lstBoxSerialNos.Items[i].Text == serialNo.ToUpper())
                {
                    existLB = true;
                }
            }
            if (existLB == false)
            {
                lstBoxSerialNos.Items.Add(serialNo.ToUpper());
                lstBoxSerialNos.Text = serialNo.ToUpper();
            }
        }

        protected void txtBoxSerialNo_TextChanged(object sender, EventArgs e)
        {
            bool existLB = false;
            bool existDB = false;
            bool isTransferred = false;
            bool isInGroup = false;

            isInGroup = GroupDA.invInGroup(txtBoxSerialNo.Text, Convert.ToInt32(Session["CurrentGroup"]), connString);

            for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
            {
                if (lstBoxSerialNos.Items[i].Text == txtBoxSerialNo.Text.ToUpper())
                {
                    existLB = true;
                }
            }
            if (EquipmentDA.equipmentExist(txtBoxSerialNo.Text, connString) == true)
            {
                existDB = true;
                if (ComputerDA.computerTransferred(txtBoxSerialNo.Text, connString) == true)
                {
                    isTransferred = true;
                }
            }
            if (existLB == false && existDB == true && isTransferred == false && isInGroup == false)
            {
                lstBoxSerialNos.Items.Add(txtBoxSerialNo.Text.ToUpper());
                lstBoxSerialNos.Text = txtBoxSerialNo.Text.ToUpper();
            }
            else if (existLB == true)
            {
                lblSerialNos.Visible = true;
                lblSerialNos.Text += txtBoxSerialNo.Text + " is already in queue<bR />";
            }
            else if (existDB == false)
            {
                lblSerialNos.Visible = true;
                lblSerialNos.Text += txtBoxSerialNo.Text + " is not in the database<br />";
            }
            else if (isTransferred == true)
            {
                lblSerialNos.Visible = true;
                lblSerialNos.Text += txtBoxSerialNo.Text + " is transferred<br />";
            }
            else if (isInGroup == true)
            {
                lblSerialNos.Visible = true;
                lblSerialNos.Text += txtBoxSerialNo.Text + " is already in this group<br />";
            }
            txtBoxSerialNo.Text = "";
            txtBoxSerialNo.Focus();
        }

        protected void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            foreach (int i in lstBoxSerialNos.GetSelectedIndices())
            {
                lstBoxSerialNos.Items.RemoveAt(lstBoxSerialNos.SelectedIndex);
            }
        }

        protected void handleGridView()
        {
            SqlDataSourceEquipment.SelectParameters.Clear();
            SqlDataSourceEquipment.SelectParameters.Add("GroupID", Session["CurrentGroup"].ToString());

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Equipment.EquipmentType as Type, Logistics.Building, " +
                "Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Status FROM Equipment INNER JOIN Inventory ON Equipment.InvID = Inventory.InvID " +
                "INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status <> 'Transferred') AND (Inventory.InvID NOT IN (SELECT Inventory_1.InvID FROM Inventory AS Inventory_1 INNER JOIN GroupInventory ON Inventory_1.InvID " +
                "= GroupInventory.InvID WHERE (GroupInventory.GroupID = @GroupID)))");

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

        protected void btnToggle_Click(object sender, EventArgs e)
        {
            if (btnToggle.Text == "Add With Text Box")
            {
                panelGridView.Visible = false;
                panelTextBox.Visible = true;
                btnToggle.Text = "Add With GridView";
            }
            else if (btnToggle.Text == "Add With GridView")
            {
                panelGridView.Visible = true;
                panelTextBox.Visible = false;
                btnToggle.Text = "Add With Text Box";
            }
        }

        protected void btnAddWithTextBox_Click(object sender, EventArgs e)
        {
            string[] serialNos = txtBoxSerialNos.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string serialNo in serialNos)
            {
                bool existLB = false;
                bool existDB = false;
                bool isTooLong = false;
                bool isBlank = false;
                bool isInGroup = false;

                if (GroupDA.invInGroup(serialNo, Convert.ToInt32(Session["CurrentGroup"]), connString) == true)
                {
                    isInGroup = true;
                }

                for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
                {
                    if (lstBoxSerialNos.Items[i].Text == serialNo.ToUpper())
                    {
                        existLB = true;
                    }
                }
                if (EquipmentDA.equipmentExist(serialNo, connString) == true)
                {
                    existDB = true;
                }
                if (serialNo.Length > 45)
                {
                    isTooLong = true;
                }
                if (serialNo == "")
                {
                    isBlank = true;
                }
                if (existLB == false && existDB == true && isTooLong == false && isBlank == false && isInGroup == false)
                {
                    lstBoxSerialNos.Items.Add(serialNo.ToUpper());
                    lstBoxSerialNos.Text = serialNo.ToUpper();
                }
                else if (existLB == true)
                {
                    lblAddTextBoxMessage.Text += serialNo + " is already in queue<bR />";
                }
                else if (isBlank == true)
                {
                    lblAddTextBoxMessage.Text += "A blank entry was found and was ignored, you should be more careful in the future<br />";
                }
                else if (existDB == false)
                {
                    lblAddTextBoxMessage.Text += serialNo + " is not in the database<br />";
                }
                else if (isTooLong == true)
                {
                    lblAddTextBoxMessage.Text += serialNo + " is too long<br />";
                }
                else if (isInGroup == true)
                {
                    lblAddTextBoxMessage.Text += serialNo + " is already in this group<br />";
                }
            }
        }
    }
}