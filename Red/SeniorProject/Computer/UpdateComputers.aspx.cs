using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;
using System.Text;

namespace SeniorProject
{
    public partial class UpdateComputers : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;

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
                ddlPONO.SelectedValue = "4";

                ddlManufacturer.DataBind();
                ddlManufacturer.Items.Insert(0, "");
                ddlManufacturer.SelectedIndex = 0;

                ddlBuilding.DataBind();
                ddlBuilding.Items.Insert(0, "");
                ddlBuilding.SelectedIndex = 0;

                ddlUSBPorts.Items.Insert(0, "");
                ddlUSBPorts.SelectedIndex = 0;

                ArrayList groupList = new ArrayList();
                groupList = GroupDA.getAllComputerGroups();

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

        protected void btnAddDesktop_Click(object sender, EventArgs e)
        {
            ArrayList computers = new ArrayList();            

            for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
            {
                Computer comp = new Computer();
                comp.SerialNo = lstBoxSerialNos.Items[i].Text;
                comp.SMSUtag = txtBoxSMSUTag.Text;
                comp.Manufacturer = ddlManufacturer.Text;
                comp.Model = txtBoxModel.Text;

                if (txtBoxPurchasePrice.Text != "")
                    comp.PurchasePrice = Convert.ToDouble(txtBoxPurchasePrice.Text);
                comp.CPU = txtBoxCPU.Text;
                comp.VideoCard = txtBoxVideoCard.Text;
                comp.HardDrive = txtBoxHardDrive.Text;
                comp.Memory = txtBoxMemory.Text;
                comp.OpticalDrive = txtBoxOpticalDrive.Text;
                comp.RemovableMedia = txtBoxRemovableMedia.Text;

                if (ddlUSBPorts.Text == "")
                {
                    comp.USBports = null;
                }
                else
                {
                    comp.USBports = Convert.ToInt32(ddlUSBPorts.SelectedValue);
                }

                comp.OtherConnectivity = txtBoxOtherConnectivity.Text;
                comp.Size = txtBoxSize.Text;
                comp.PhysicalAddress = txtBoxPhysicalAddress.Text.ToUpper();

                comp.Notes = txtBoxNotes.Text;
                comp.Type = ddlType.Text;
                comp.Status = ddlStatus.Text;

                if (ddlPONO.Visible == true)
                {
                    comp.PO.ID = Convert.ToInt32(ddlPONO.SelectedValue);
                }
                else
                {
                    comp.PO.ID = null;
                }


                computers.Add(comp);
            }
            
            lblMessage.Text = ComputerDA.updateComputers(computers);
            lblMessage.Visible = true;
            btnClearMessage.Visible = true;
        }

        protected void btnClearMessage_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            btnClearMessage.Visible = false;
        }

        protected void btnUpdatePO_Click(object sender, EventArgs e)
        {
            ddlPONO.Visible = true;
            DetailsView2.Visible = true;
            btnUpdatePO.Visible = false;
            btnDontUpdatePO.Visible = true;
        }

        protected void btnDontUpdatePO_Click(object sender, EventArgs e)
        {
            ddlPONO.Visible = false;
            DetailsView2.Visible = false;
            btnUpdatePO.Visible = true;
            btnDontUpdatePO.Visible = false;
        }

        protected void btnSelectGroup_Click(object sender, EventArgs e)
        {
            foreach (int i in lstBoxGroups.GetSelectedIndices())
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
            lblMaintenanceMessage.Text = MaintenanceDA.addMassMaintenanceComputer(tags, maint);

        }

        protected void btnAddMaintenance_Click(object sender, EventArgs e)
        {
            btnAddMaintenance.Visible = false;
            Panel1.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddMaintenance.Visible = true;
            Panel1.Visible = false;
        }

        protected void btnUpdateLogistics_Click(object sender, EventArgs e)
        {
            pnlLogistics.Visible = true;
            btnUpdateLogistics.Visible = false;
        }

        protected void btnDontUpdateLogistics_Click(object sender, EventArgs e)
        {
            pnlLogistics.Visible = false;
            btnUpdateLogistics.Visible = true;
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

            lblLogisticsMessage.Visible = true;
            lblLogisticsMessage.Text = LogisticsDA.massUpdateLogisticsComputer(tags, logs);
            btnClearLogistics.Visible = true;
        }

        protected void btnClearLogistics_Click(object sender, EventArgs e)
        {
            lblLogisticsMessage.Text = "";
            btnClearLogistics.Visible = false;
        }

        protected void btnManageLicensing_Click(object sender, EventArgs e)
        {
            pnlLicensing.Visible = true;
            btnManageLicensing.Visible = false;
        }

        protected void btnCancelLicensing_Click(object sender, EventArgs e)
        {
            pnlLicensing.Visible = false;
            btnManageLicensing.Visible = true;
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

            lblLicenseMessage.Text = LicenseDA.removeAllLicensesComputer(tags);
            lblLicenseMessage.Visible = true;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList tags = new ArrayList();
            tags = getTags();

            int licenseID = Convert.ToInt32(GridView1.SelectedDataKey.Value);

            lblLicenseMessage.Text = LicenseDA.removeSelectLicenseComputer(tags ,licenseID);
            lblLicenseMessage.Visible = true;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList tags = new ArrayList();
            tags = getTags();

            int licenseID = Convert.ToInt32(GridView2.SelectedDataKey.Value);

            lblLicenseMessage.Text = LicenseDA.addLicensesComputer(tags, licenseID);
            lblLicenseMessage.Visible = true;
        }

        protected void lstBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelectGroup.Enabled = true;
        }

        protected void btnManageMonitors_Click(object sender, EventArgs e)
        {
            panelMonitors.Visible = true;
            btnManageMonitors.Visible = false;
        }

        protected void btnCancelLicensing0_Click(object sender, EventArgs e)
        {
            btnManageMonitors.Visible = true;
            panelMonitors.Visible = false;
        }

        protected void chkBoxRemoveAllMonitors_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxRemoveAllMonitors.Checked == true)
            {
                chkBoxRemoveCertainMonitors.Checked = false;
                chkBoxAddMonitors.Checked = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
                btnApplyRemoveAllMonitors.Visible = true;
            }
            else
            {
                btnApplyRemoveAllMonitors.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
            }
        }

        protected void chkBoxRemoveCertainMonitors_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxRemoveCertainMonitors.Checked == true)
            {
                chkBoxRemoveAllMonitors.Checked = false;
                chkBoxAddMonitors.Checked = false;
                GridView3.Visible = true;
                GridView4.Visible = false;
                btnApplyRemoveAllMonitors.Visible = false;
            }
            else
            {
                btnApplyRemoveAllMonitors.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
            }
        }

        protected void chkBoxAddMonitors_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxAddMonitors.Checked == true)
            {
                chkBoxRemoveCertainMonitors.Checked = false;
                chkBoxRemoveAllMonitors.Checked = false;
                GridView3.Visible = false;
                GridView4.Visible = true;
                btnApplyRemoveAllMonitors.Visible = false;
            }
            else
            {
                btnApplyRemoveAllMonitors.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
            }
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList tags = new ArrayList();
            tags = getTags();

            int monId = Convert.ToInt32(GridView3.SelectedDataKey.Value);

            lblMonitorMessage.Text = MonitorDA.removeSelectMonitor(tags, monId);
            lblMonitorMessage.Visible = true;
        }

        protected void btnApplyRemoveAllMonitors_Click(object sender, EventArgs e)
        {
            ArrayList tags = new ArrayList();
            tags = getTags();

            lblMonitorMessage.Text = MonitorDA.deleteMonitors(tags);
            lblMonitorMessage.Visible = true;
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList tags = new ArrayList();
            tags = getTags();

            int monID = Convert.ToInt32(GridView4.SelectedDataKey.Value);

            lblMonitorMessage.Text = MonitorDA.addMonitorsComputer(tags, monID);
            lblMonitorMessage.Visible = true;
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

            lblWarrantyMessage.Text = WarrantyDA.addWarrantysComputer(tags, war);
            lblWarrantyMessage.Visible = true;
        }

        protected void brnCancelWarranty_Click(object sender, EventArgs e)
        {
            panelWarranty.Visible = false;
            btnManageWarranties.Visible = true;
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

        protected void btnManageWarranties_Click(object sender, EventArgs e)
        {
            panelWarranty.Visible = true;
            btnManageWarranties.Visible = false;
        }

        protected void btnApplyRemoveAllWarranties_Click(object sender, EventArgs e)
        {
            ArrayList tags = new ArrayList();
            tags = getTags();

            lblWarrantyMessage.Text = WarrantyDA.deleteWarrantyComputer(tags);
            lblWarrantyMessage.Visible = true;
        }

        protected void GridView3_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //registers click event to entire grid view row
                e.Row.Attributes["OnClick"] = ClientScript.GetPostBackEventReference(this.GridView3, "Select$" + e.Row.RowIndex);

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

        protected void GridView4_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //registers click event to entire grid view row
                e.Row.Attributes["OnClick"] = ClientScript.GetPostBackEventReference(this.GridView4, "Select$" + e.Row.RowIndex);

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

        protected ArrayList getTags()
        {
            ArrayList tags = new ArrayList();
            for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
            {
                tags.Add(lstBoxSerialNos.Items[i].Text);
            }
            return tags;
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

        protected void btnToggle_Click(object sender, EventArgs e)
        {
            if (btnToggle.Text == "Select With GridView")
            {
                panelGeneral.Visible = false;
                PanelGridView.Visible = true;
                panelTextBox.Visible = false;
                btnToggle.Text = "Done";
                btnAddWithTextBoxToggle.Text = "Add With Text Box";
            }
            else if (btnToggle.Text == "Done")
            {
                panelGeneral.Visible = true;
                PanelGridView.Visible = false;
                panelTextBox.Visible = false;
                btnToggle.Text = "Select With GridView";
                btnAddWithTextBoxToggle.Text = "Add With Text Box";
            }
        }

        protected void handleGridView()
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
            //lblSQL.Text = sql.ToString();

            populateDDLs();
            printArgs();
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
            //primaryUserArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxPrimaryUserFilter")).Text;
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
            //((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxPrimaryUserFilter")).Text = primaryUserArg;
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
                if (ComputerDA.computerExist(serialNo) == true)
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

        protected void btnAddWithTextBoxToggle_Click(object sender, EventArgs e)
        {
            if (btnAddWithTextBoxToggle.Text == "Add With Text Box")
            {
                panelGeneral.Visible = false;
                PanelGridView.Visible = false;
                panelTextBox.Visible = true;
                btnAddWithTextBoxToggle.Text = "Done";
                btnToggle.Text = "Select With GridView";
            }
            else if (btnAddWithTextBoxToggle.Text == "Done")
            {
                panelGeneral.Visible = true;
                PanelGridView.Visible = false;
                panelTextBox.Visible = false;
                btnAddWithTextBoxToggle.Text = "Add With Text Box";
                btnToggle.Text = "Select With GridView";
            }            
        }
    }
}