using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Text;

namespace SeniorProject.Transfers
{
      
    public partial class NewTransfer : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;

        string computerSerialNoArg = "";
        string computerTypeArg = "";
        string computerFormFactorArg = "";
        string computerManufacturerArg = "";
        string computerModelArg = "";
        string computerNameArg = "";
        string computerBuildingArg = "";
        string computerRoomArg = "";
        //string computerPrimaryUserArg = "";
        string computerStatusArg = "";

        string equipmentSerialNoArg = "";
        string equipmentTypeArg = "";
        string equipmentManufacturerArg = "";
        string equipmentModelArg = "";
        string equipmentBuildingArg = "";
        string equipmentNameArg = "";
        string equipmentRoomArg = "";
        string equipmentPrimaryUserArg = "";
        string equipmentStatusArg = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrayList groupList = new ArrayList();
                groupList = GroupDA.getAllGroups();

                for (int i = 0; i < groupList.Count; i++)
                {
                    Group group = new Group();
                    group = (Group)groupList[i];
                    lstBoxGroups.Items.Add(group.Name);
                }
                txtBoxSerialNo.Focus();

                populateComputerDDLs();
                populateEquipmentDDLs();
            }
            else
            {
                handleComputerGridView();
                handleEquipmentGridView();
            }
        }

        protected void btnCreateTransfer_Click(object sender, EventArgs e)
        {
            Transfer transfer = new Transfer();
            //transfer.Name = txtBoxTransferName.Text;
            transfer.Date = txtBoxDate.Text;
            transfer.Notes = txtBoxNotes.Text;
            transfer.Where = txtBoxWhere.Text;

            for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
            {
                transfer.Inventory.Add(lstBoxSerialNos.Items[i].Text);
            }

            lblTransferMessage.Text = TransferDA.saveTransfer(transfer);
            lblTransferMessage.Visible = true;
            btnClearMessage.Visible = true;

        }

        protected void btnClearMessage_Click(object sender, EventArgs e)
        {
            lblTransferMessage.Visible = false;
            btnClearMessage.Visible = false;
        }

        protected void lstBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelectGroup.Enabled = true;
        }

        protected void txtBoxSerialNo_TextChanged(object sender, EventArgs e)
        {
            bool existLB = false;
            bool existDB = false;
            bool isTransferred = false;
            for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
            {
                if (lstBoxSerialNos.Items[i].Text == txtBoxSerialNo.Text.ToUpper())
                {
                    existLB = true;
                }
            }
            if (EquipmentDA.equipmentExist(txtBoxSerialNo.Text) == true)
            {
                existDB = true;
                if (ComputerDA.computerTransferred(txtBoxSerialNo.Text) == true)
                {
                    isTransferred = true;
                }
            }
            if (ComputerDA.computerExist(txtBoxSerialNo.Text) == true)
            {
                existDB = true;
                if (ComputerDA.computerTransferred(txtBoxSerialNo.Text) == true)
                {
                    isTransferred = true;
                }
            }
            if (existLB == false && existDB == true && isTransferred == false)
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

        protected void GridViewComputers_RowCreated(object sender, GridViewRowEventArgs e)
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

        protected void GridViewComputers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string serialNo = GridViewComputers.SelectedDataKey["SerialNo"].ToString();

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

        protected void GridViewEquipment_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //registers click event to entire grid view row
                e.Row.Attributes["OnClick"] = ClientScript.GetPostBackEventReference(this.GridViewEquipment, "Select$" + e.Row.RowIndex);

                //handles on hover events
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor = '#B0B0B0';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = this.originalstyle;");
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

        protected void btnAddComputers_Click(object sender, EventArgs e)
        {
            if (btnAddComputers.Text == "Add Computers")
            {
                panelTransfer.Visible = false;
                panelComputers.Visible = true;
                panelEquipment.Visible = false;
                btnAddComputers.Text = "Done";
                btnAddEquipment.Text = "Add Equipment";
            }
            else if (btnAddComputers.Text == "Done")
            {
                panelTransfer.Visible = true;
                panelComputers.Visible = false;
                panelEquipment.Visible = false;
                btnAddComputers.Text = "Add Computers";
            }
            
        }

        protected void btnAddEquipment_Click(object sender, EventArgs e)
        {
            if (btnAddEquipment.Text == "Add Equipment")
            {
                panelTransfer.Visible = false;
                panelComputers.Visible = false;
                panelEquipment.Visible = true;
                btnAddEquipment.Text = "Done";
                btnAddComputers.Text = "Add Computers";
            }
            else if (btnAddEquipment.Text == "Done")
            {
                panelTransfer.Visible = true;
                panelComputers.Visible = false;
                panelEquipment.Visible = false;
                btnAddEquipment.Text = "Add Equipment";
            }
        }

        protected void btnSelectGroup_Click(object sender, EventArgs e)
        {
            ArrayList computerGroups = new ArrayList();
            computerGroups = GroupDA.getAllComputerGroups();
            ArrayList equipmentGroups = new ArrayList();
            equipmentGroups = GroupDA.getAllEquipmentGroups();
            
            foreach (int i in lstBoxGroups.GetSelectedIndices())
            {
                bool isComputerGroup = false;
                bool isEquipmentGroup = false;

                for (int j = 0; j < computerGroups.Count; j++)
                {
                    Group group = new Group();
                    group = (Group)computerGroups[j];
                    if (group.Name == lstBoxGroups.Items[i].Text)
                    {
                        isComputerGroup = true;
                    }
                }

                for (int j = 0; j < equipmentGroups.Count; j++)
                {
                    Group group = new Group();
                    group = (Group)equipmentGroups[j];
                    if (group.Name == lstBoxGroups.Items[i].Text)
                    {
                        isEquipmentGroup = true;
                    }
                }

                if (isComputerGroup == true)
                {
                    Group selectedGroup = new Group();
                    selectedGroup = GroupDA.getGroupComputers(lstBoxGroups.Items[i].Text);

                    for (int j = 0; j < selectedGroup.Computers.Count; j++)
                    {
                        Computer comp = new Computer();
                        comp = (Computer)selectedGroup.Computers[j];
                        //txtBoxServiceTags.Text += comp.SerialNo + "\r\n";

                        bool existsLB = false;
                        for (int k = 0; k < lstBoxSerialNos.Items.Count; k++)
                        {
                            if (lstBoxSerialNos.Items[k].Text == comp.SerialNo.ToUpper())
                            {
                                existsLB = true;
                            }
                        }
                        if (existsLB == false)
                        {
                            lstBoxSerialNos.Items.Add(comp.SerialNo.ToUpper());
                            lstBoxSerialNos.Text = comp.SerialNo.ToUpper();
                        }
                    }
                }
                else if (isEquipmentGroup == true)
                {
                    Group selectedGroup = new Group();
                    selectedGroup = GroupDA.getGroupEquipment(lstBoxGroups.Items[i].Text);

                    for (int j = 0; j < selectedGroup.Equipment.Count; j++)
                    {
                        Equipment equip = new Equipment();
                        equip = (Equipment)selectedGroup.Equipment[j];
                        //txtBoxServiceTags.Text += comp.SerialNo + "\r\n";

                        bool existsLB = false;
                        for (int k = 0; k < lstBoxSerialNos.Items.Count; k++)
                        {
                            if (lstBoxSerialNos.Items[k].Text == equip.SerialNo.ToUpper())
                            {
                                existsLB = true;
                            }
                        }
                        if (existsLB == false)
                        {
                            lstBoxSerialNos.Items.Add(equip.SerialNo.ToUpper());
                            lstBoxSerialNos.Text = equip.SerialNo.ToUpper();
                        }
                    }
                }
            }
        }

        protected void handleComputerGridView()
        {
            SqlDataSourceComputers.SelectParameters.Clear();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, " +
                "Logistics.Name, Inventory.Model, Inventory.Status, Computer.FormFactor, Computer.Type FROM Computer INNER JOIN Inventory ON Computer.InvID = " +
                "Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status <> 'Transferred')");

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

            if (computerStatusArg != "")
            {
                sql.Append(" AND Inventory.Status LIKE '%'+@Status+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Status", computerStatusArg);
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
                    case "computerStatusHeaderLinkButton":
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
            computerStatusArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).Text;
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
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).Text = computerStatusArg;
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
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).SelectedIndex = 0;
        }

        protected void handleEquipmentGridView()
        {
            SqlDataSourceEquipment.SelectParameters.Clear();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Equipment.EquipmentType as Type, Logistics.Building, " +
                "Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Status FROM Equipment INNER JOIN Inventory ON Equipment.InvID = Inventory.InvID " +
                "INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status <> 'Transferred')");

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

            if (equipmentStatusArg != "")
            {
                sql.Append(" AND Inventory.Status LIKE '%'+@Status+'%'");
                SqlDataSourceEquipment.SelectParameters.Add("Status", equipmentStatusArg);
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
                    case "equipmentStatusHeaderLinkButton":
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
            equipmentStatusArg = ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlStatusFilter")).Text;
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
            ((DropDownList)GridViewEquipment.HeaderRow.FindControl("ddlStatusFilter")).Text = equipmentStatusArg;
        }

        protected void populateEquipmentDDLs()
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
    }
}