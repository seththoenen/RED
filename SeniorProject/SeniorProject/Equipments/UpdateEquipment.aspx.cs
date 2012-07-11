using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;
using System.Text;

namespace SeniorProject.Equipments
{
    public partial class UpdateEquipment : System.Web.UI.Page
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
                ddlBuilding.DataBind();
                ddlBuilding.Items.Insert(0, "");
                ddlBuilding.SelectedIndex = 0;

                ddlManufacturer.DataBind();
                ddlManufacturer.Items.Insert(0, "");
                ddlManufacturer.SelectedIndex = 0;

                ArrayList groupList = new ArrayList();
                groupList = GroupDA.getAllEquipmentGroups(connString);

                for (int i = 0; i < groupList.Count; i++)
                {
                    Group group = new Group();
                    group = (Group)groupList[i];
                    lstBoxGroups.Items.Add(group.Name);
                }
                if (Session["Authenticated"].ToString() != "True")
                {
                    btnManageLicensing.Enabled = false;
                }
                txtBoxSerialNo.Focus();

                populateDDLs();
            }
            else
            {
                handleGridView();
            }
        }

        protected void chkBoxRemoveAllLicensing_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxRemoveAllLicensing.Checked == true)
            {
                chkBoxRemoveCertainLicenses.Checked = false;
                chkBoxAddLicenses.Checked = false;
                btnApplyRemoveAllLicenses.Visible = true;
                GridView1.Visible = false;
                GridView2.Visible = false;
            }
            else
            {
                btnApplyRemoveAllLicenses.Visible = false;
                GridView1.Visible = false;
                GridView2.Visible = false;
            }
        }

        protected void chkBoxRemoveCertainLicenses_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxRemoveCertainLicenses.Checked == true)
            {
                chkBoxRemoveAllLicensing.Checked = false;
                chkBoxAddLicenses.Checked = false;
                btnApplyRemoveAllLicenses.Visible = false;
                GridView1.Visible = true;
                GridView2.Visible = false;
            }
            else
            {
                btnApplyRemoveAllLicenses.Visible = false;
                GridView1.Visible = false;
                GridView2.Visible = false;
            }
        }

        protected void chkBoxAddLicenses_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxAddLicenses.Checked == true)
            {
                chkBoxRemoveCertainLicenses.Checked = false;
                chkBoxRemoveAllLicensing.Checked = false;
                btnApplyRemoveAllLicenses.Visible = false;
                GridView1.Visible = false;
                GridView2.Visible = true;
            }
            else
            {
                btnApplyRemoveAllLicenses.Visible = false;
                GridView1.Visible = false;
                GridView2.Visible = false;
            }
        }

        protected void btnApplyRemoveAllLicenses_Click(object sender, EventArgs e)
        {
            ArrayList tags = new ArrayList();
            tags = getTags();

            lblLicenseMessage.Text = LicenseDA.removeAllLicensesEquipment(tags, connString);
            lblLicenseMessage.Visible = true;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList tags = new ArrayList();
            tags = getTags();

            int licenseID = Convert.ToInt32(GridView1.SelectedDataKey.Value);

            lblLicenseMessage.Text = LicenseDA.removeSelectLicenseEquipment(tags, licenseID, connString);
            lblLicenseMessage.Visible = true;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList tags = new ArrayList();
            tags = getTags();

            int licenseID = Convert.ToInt32(GridView2.SelectedDataKey.Value);

            lblLicenseMessage.Text = LicenseDA.addLicensesEquipment(tags, licenseID, connString);
            lblLicenseMessage.Visible = true;
        }

        protected void btnCancelLicensing_Click(object sender, EventArgs e)
        {
            panelLicensing.Visible = false;
            btnManageLicensing.Visible = true;
        }

        protected void btnAddMaintenance_Click(object sender, EventArgs e)
        {
            btnAddMaintenance.Visible = false;
            panelMaintenance.Visible = true;
        }

        protected void btnInsertMaintenance_Click(object sender, EventArgs e)
        {
            ArrayList tags = new ArrayList();
            tags = getTags();

            ArrayList newMaintenance = new ArrayList();

            Maintenance maint = new Maintenance();
            maint.Date = txtboxDate.Text;
            maint.Description = txtBoxMaintenance.Text;

            lblMaintenanceMessage.Visible = true;
            lblMaintenanceMessage.Text = MaintenanceDA.addMassMaintenanceEquipment(tags, maint, connString);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddMaintenance.Visible = true;
            panelMaintenance.Visible = false;
        }

        protected void btnUpdateLogistics_Click(object sender, EventArgs e)
        {
            panelUpdateLogistics.Visible = true;
            btnUpdateLogistics.Visible = false;
        }

        protected void btnCancelLogistics_Click(object sender, EventArgs e)
        {
            panelUpdateLogistics.Visible = false;
            btnUpdateLogistics.Visible = true;
        }

        protected void btnUpdatePO_Click(object sender, EventArgs e)
        {
            panelPO.Visible = true;
            btnUpdatePO.Visible = false;
        }

        protected void btnDontUpdatePO_Click(object sender, EventArgs e)
        {
            panelPO.Visible = false;
            btnUpdatePO.Visible = true;
        }

        protected void btnManageLicensing_Click(object sender, EventArgs e)
        {
            panelLicensing.Visible = true;
            btnManageLicensing.Visible = false;
        }

        protected void btnClearMessage_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateEquipment_Click(object sender, EventArgs e)
        {
            ArrayList tags = new ArrayList();
            tags = getTags();

            ArrayList equipment = new ArrayList();

            for (int i = 0; i < tags.Count  ; i++)
            {
                Equipment equip = new Equipment();
                equip.SerialNo = (string)tags[i];
                equip.SMSUtag = txtBoxSMSUTag.Text;
                equip.Manufacturer = ddlManufacturer.Text;
                equip.Model = txtBoxModel.Text;
                equip.EquipmentType = ddlType.Text;
                equip.Status = ddlStatus.Text;

                if (txtBoxPurchasePrice.Text != "")
                    equip.PurchasePrice = Convert.ToDouble(txtBoxPurchasePrice.Text);

                equip.Connectivity = txtBoxConnectivity.Text;
                equip.NetworkCapable = ddlNetworkCapable.Text;
                equip.Other = txtBoxOther.Text;
                equip.Notes = txtBoxNotes.Text;


                if (ddlPONO.Visible == true)
                {
                    equip.PO.ID = Convert.ToInt32(ddlPONO.SelectedValue);
                }
                else
                {
                    equip.PO.ID = null;
                }


                equipment.Add(equip);
            }
            lblMessage.Text = EquipmentDA.updateEquipment(equipment, connString);
            lblMessage.Visible = true;

        }

        protected void btnApplyLogisticsUpdates_Click(object sender, EventArgs e)
        {
            ArrayList tags = new ArrayList();
            tags = getTags();

            Logistics logs = new Logistics();
            logs.Building = ddlBuilding.Text;
            logs.Room = txtBoxRoomNumber.Text;
            logs.PrimaryUser = txtBoxPrimaryUser.Text;
            logs.Name = txtBoxName.Text;

            lblLogisticsMessage.Text = LogisticsDA.massUpdateLogisticsEquipment(tags, logs, connString);
            lblLogisticsMessage.Visible = true;
            btnClearLogistics.Visible = true;
        }

        protected void btnSelectGroup_Click(object sender, EventArgs e)
        {
            foreach (int i in lstBoxGroups.GetSelectedIndices())
            {
                Group selectedGroup = new Group();
                selectedGroup = GroupDA.getGroupEquipment(lstBoxGroups.Items[i].Text, connString);

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

        protected void btnManageWarranties_Click(object sender, EventArgs e)
        {
            panelWarranty.Visible = true;
            btnManageWarranties.Visible = false;
        }

        protected void chkBoxRemoveAllWarranties_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxRemoveAllWarranties.Checked == true)
            {
                chkBoxAddWarranty.Checked = false;
                panelAddWarranty.Visible = false;
                btnApplyRemoveAllWarranties.Visible = true;
            }
            else
            {
                btnApplyRemoveAllWarranties.Visible = false;
            }

        }

        protected void btnApplyRemoveAllWarranties_Click(object sender, EventArgs e)
        {
            ArrayList tags = new ArrayList();
            tags = getTags();

            lblWarrantyMessage.Text = WarrantyDA.deleteWarrantyEquipment(tags, connString);
            lblWarrantyMessage.Visible = true;
        }

        protected void chkBoxAddWarranty_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxAddWarranty.Checked == true)
            {
                chkBoxRemoveAllWarranties.Checked = false;
                panelAddWarranty.Visible = true;
                btnApplyRemoveAllWarranties.Visible = false;
            }
            else
            {
                panelAddWarranty.Visible = false;
            }

        }

        protected void btnAddWarranty_Click(object sender, EventArgs e)
        {
            Page.Validate("warranty");

            ArrayList tags = new ArrayList();
            tags = getTags();

            Warranty war = new Warranty();
            war.Company = ddlWarrantyCompany.SelectedItem.ToString();
            war.WarrantyType = txtBoxWarrantyType.Text;
            war.StartDate = txtBoxWarrantyStartDate.Text;
            war.EndDate = txtBoxWarrantyEndDate.Text;
            war.Notes = txtBoxWarrantyNotes.Text;

            lblWarrantyMessage.Text = WarrantyDA.addWarrantysEquipment(tags, war, connString);
            lblWarrantyMessage.Visible = true;
        }

        protected void brnCancelWarranty_Click(object sender, EventArgs e)
        {
            panelWarranty.Visible = false;
            btnManageWarranties.Visible = true;
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
            if (EquipmentDA.equipmentExist(txtBoxSerialNo.Text, connString) == true)
            {
                existDB = true;
                if (ComputerDA.computerTransferred(txtBoxSerialNo.Text, connString) == true)
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

        protected ArrayList getTags()
        {
            ArrayList tags = new ArrayList();
            for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
            {
                tags.Add(lstBoxSerialNos.Items[i].Text);
            }
            return tags;
        }

        protected void lstBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelectGroup.Enabled = true;
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

        protected void handleGridView()
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
            if (btnToggle.Text == "Select With GridView")
            {
                panelGeneral.Visible = false;
                panelGridView.Visible = true;
                panelTextBox.Visible = false;
                btnToggle.Text = "Back To Normal Mode";
            }
            else if (btnToggle.Text == "Back To Normal Mode")
            {
                panelGeneral.Visible = true;
                panelGridView.Visible = false;
                panelTextBox.Visible = false;
                btnToggle.Text = "Select With GridView";
            }
        }

        protected void btnAddWithTextBoxToggle_Click(object sender, EventArgs e)
        {
            if (btnAddWithTextBoxToggle.Text == "Add With Text Box")
            {
                panelGeneral.Visible = false;
                panelGridView.Visible = false;
                panelTextBox.Visible = true;
                btnAddWithTextBoxToggle.Text = "Done Adding With Text Box";
                btnToggle.Text = "Select With GridView";
            }
            else if (btnAddWithTextBoxToggle.Text == "Done Adding With Text Box")
            {
                panelGeneral.Visible = true;
                panelGridView.Visible = false;
                panelTextBox.Visible = false;
                btnAddWithTextBoxToggle.Text = "Add With Text Box";
                btnToggle.Text = "Select With GridView";
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
                if (existLB == false && existDB == true && isTooLong == false && isBlank == false)
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
            }
        }
    }
}