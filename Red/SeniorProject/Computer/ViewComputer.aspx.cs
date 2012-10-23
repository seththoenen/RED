using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProject
{
    public partial class ViewComputer : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        Computer oComp = new Computer();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int invID = 0;
                string invIDstr = Request.QueryString["id"];
                try
                {
                    invID = Convert.ToInt32(invIDstr);
                    Session["CurrentComputer"] = invID;
                }
                catch (System.FormatException ex)
                {
                    Session["Exception"] = "Input is in improper format.<bR><bR>" + ex.ToString();
                    Response.Redirect("~/Error.aspx");
                }
                catch (Exception ex)
                {
                    Session["Exception"] = ex.ToString();
                    Response.Redirect("~/Error.aspx");
                }

                Computer comp = new Computer();
                comp = Computer.getComputer(invID);

                if (comp.InvID == 0 || comp.InvID == null)
                {
                    Response.Redirect("~/PageNotFound.aspx");
                }

                Session["CurrentComputerID"] = comp.CompID;

                txtBoxDate.Text = DateTime.Now.ToShortDateString();

                txtBoxServiceTag.Text = comp.SerialNo;
                txtBoxSMSUTag.Text = comp.SMSUtag;
                bool containsManufacturer = false;
                ddlManufacturer.DataBind();
                for (int i = 0; i < ddlManufacturer.Items.Count; i++)
                {
                    if (ddlManufacturer.Items[i].Text == comp.Manufacturer)
                    {
                        containsManufacturer = true;
                    }
                }
                if (containsManufacturer == false)
                {
                    ddlManufacturer.Items.Add(comp.Manufacturer);
                    ddlManufacturer.Text = comp.Manufacturer;
                }
                else
                {
                    ddlManufacturer.Text = comp.Manufacturer;
                }
                txtBoxModel.Text = comp.Model;

                ddlBuilding.DataBind();
                bool containsBuilding = false;
                for (int i = 0; i < ddlBuilding.Items.Count; i++)
                {
                    if (ddlBuilding.Items[i].Text == comp.CurrentLocation.Building)
                    {
                        containsBuilding = true;
                    }
                }
                if (containsBuilding == false)
                {
                    ddlBuilding.Items.Add(comp.CurrentLocation.Building);
                    ddlBuilding.Text = comp.CurrentLocation.Building;
                }
                else
                {
                    ddlBuilding.Text = comp.CurrentLocation.Building;
                }

                txtBoxRoomNumber.Text = comp.CurrentLocation.Room;
                txtBoxPrimaryUser.Text = comp.CurrentLocation.PrimaryUser;
                txtBoxName.Text = comp.CurrentLocation.Name;
                txtBoxPurchasePrice.Text = comp.PurchasePrice.ToString();
                txtBoxCPU.Text = comp.CPU;
                txtBoxVideoCard.Text = comp.VideoCard;
                txtBoxHardDrive.Text = comp.HardDrive;
                txtBoxMemory.Text = comp.Memory;
                txtBoxOpticalDrive.Text = comp.OpticalDrive;
                txtBoxRemovableMedia.Text = comp.RemovableMedia;
                ddlUSBPorts.SelectedValue = comp.USBports.ToString();
                txtBoxOtherConnectivity.Text = comp.OtherConnectivity;
                txtBoxSize.Text = comp.Size;
                txtBoxPhysicalAddress.Text = comp.PhysicalAddress;
                txtBoxNotes.Text = comp.Notes;
                ddlType.Text = comp.Type;
                ddlPONO.SelectedValue = comp.PO.ID.ToString();

                if (comp.Status != "Transferred")
                {
                    ddlStatus.Text = comp.Status;
                }
                else
                {
                    ddlStatus.Items.Add("Transferred");
                    ddlStatus.Text = "Transferred";
                    ddlStatus.Enabled = false;
                }

                List<Group> groups = new List<Group>();
                groups = Group.getAllComputerGroups();
                int nextGroup = 1;

                //populates chkBoxList
                for (int i = 0; i < groups.Count; i++)
                {
                    Group group = new Group();
                    group = (Group)groups[i];
                    if (nextGroup == 1)
                    {
                        chkBoxLstGroups1.Items.Add(group.Name);
                        nextGroup = 2;
                        for (int j = 0; j < comp.Groups.Count; j++)
                        {
                            Group compGroup = new Group();
                            compGroup = (Group)comp.Groups[j];
                            if (compGroup.Name == group.Name)
                            {
                                chkBoxLstGroups1.Items[chkBoxLstGroups1.Items.Count - 1].Selected = true;
                            }
                        }
                    }
                    else if (nextGroup == 2)
                    {
                        chkBoxLstGroups2.Items.Add(group.Name);
                        nextGroup = 3;
                        for (int j = 0; j < comp.Groups.Count; j++)
                        {
                            Group compGroup = new Group();
                            compGroup = (Group)comp.Groups[j];
                            if (compGroup.Name == group.Name)
                            {
                                chkBoxLstGroups2.Items[chkBoxLstGroups1.Items.Count - 1].Selected = true;
                            }
                        }
                    }
                    else if (nextGroup == 3)
                    {
                        chkBoxLstGroups3.Items.Add(group.Name);
                        nextGroup = 4;
                        for (int j = 0; j < comp.Groups.Count; j++)
                        {
                            Group compGroup = new Group();
                            compGroup = (Group)comp.Groups[j];
                            if (compGroup.Name == group.Name)
                            {
                                chkBoxLstGroups3.Items[chkBoxLstGroups1.Items.Count - 1].Selected = true;
                            }
                        }
                    }
                    else if (nextGroup == 4)
                    {
                        chkBoxLstGroups4.Items.Add(group.Name);
                        nextGroup = 1;
                        for (int j = 0; j < comp.Groups.Count; j++)
                        {
                            Group compGroup = new Group();
                            compGroup = (Group)comp.Groups[j];
                            if (compGroup.Name == group.Name)
                            {
                                chkBoxLstGroups4.Items[chkBoxLstGroups1.Items.Count - 1].Selected = true;
                            }
                        }
                    }
                }
                if (comp.Status == "Transferred")
                {
                    btnAddMonitor.Enabled = false;
                    btnRemoveMonitor.Enabled = false;
                    btnEditGroups.Enabled = false;
                    btnAddLicense.Enabled = false;
                    btnRemoveLicense.Enabled = false;
                    btnAddMaintenance.Enabled = false;
                    btnAddWarranty.Enabled = false;
                    btnUpdateDesktop.Enabled = false;
                    gvWarranties.Enabled = false;
                }
                if (Session["Authenticated"].ToString() != "True")
                {
                    panelLicenses.Visible = false;
                }              
            }
        }

        protected void btnUpdateDesktop_Click(object sender, EventArgs e)
        {
            int compID = Convert.ToInt32(Session["CurrentComputer"]);
            
            oComp = Computer.getComputer(compID);
            
            Computer comp = new Computer();
            comp.InvID = Convert.ToInt32(compID);
            comp.SerialNo = txtBoxServiceTag.Text.ToUpper();
            comp.SMSUtag = txtBoxSMSUTag.Text;
            comp.Manufacturer = ddlManufacturer.Text;
            comp.Model = txtBoxModel.Text;
            comp.CurrentLocation.Building = ddlBuilding.Text;
            comp.CurrentLocation.Room = txtBoxRoomNumber.Text;
            comp.CurrentLocation.PrimaryUser = txtBoxPrimaryUser.Text;
            comp.CurrentLocation.Name = txtBoxName.Text;
            comp.PurchasePrice = Convert.ToDouble(txtBoxPurchasePrice.Text);
            comp.CPU = txtBoxCPU.Text;
            comp.VideoCard = txtBoxVideoCard.Text;
            comp.HardDrive = txtBoxHardDrive.Text;
            comp.Memory = txtBoxMemory.Text;
            comp.OpticalDrive = txtBoxOpticalDrive.Text;
            comp.RemovableMedia = txtBoxRemovableMedia.Text;
            comp.USBports = Convert.ToInt32(ddlUSBPorts.SelectedValue);
            comp.OtherConnectivity = txtBoxOtherConnectivity.Text;
            comp.Size = txtBoxSize.Text;
            comp.Status = ddlStatus.Text;
            comp.Notes = txtBoxNotes.Text;
            comp.Type = ddlType.Text;
            comp.PhysicalAddress = txtBoxPhysicalAddress.Text.ToUpper();

            if (ddlStatus.Enabled == false)
            {
                comp.Status = "Transferred";
            }
            else
            {
                comp.Status = ddlStatus.Text;
            }
            

            comp.PO = new PurchaseOrder();
            comp.PO.ID = Convert.ToInt32(ddlPONO.SelectedValue);

            for (int i = 0; i<lstBoxMonitors.Items.Count; i++)
            {
                Monitor mon = new Monitor();
                mon.ID = Convert.ToInt32(lstBoxMonitors.Items[i].Value);
                comp.Monitors.Add(mon);
            }
            
            lblMessage.Text = Computer.updateComputer(oComp ,comp);
            btnClear.Visible = true;

            GridView2.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            btnClear.Visible = false;
        }

        protected void btnEditGroups_Click(object sender, EventArgs e)
        {
            lstBoxGroups.Visible = false;
            btnUpdateGroups.Visible = true;
            chkBoxLstGroups1.Visible = true;
            chkBoxLstGroups2.Visible = true;
            chkBoxLstGroups3.Visible = true;
            chkBoxLstGroups4.Visible = true;
            btnEditGroups.Visible = false;
            btnGoToGroup.Visible = false;
            btnCancelEditGroups.Visible = true;
        }

        protected void btnUpdateGroups_Click(object sender, EventArgs e)
        {

            int invID = Convert.ToInt32(Session["CurrentComputer"]);
            List<string> currentGroups = new List<string>();
            for (int i = 0; i < chkBoxLstGroups1.Items.Count; i++)
            {
                if (chkBoxLstGroups1.Items[i].Selected == true)
                {
                    currentGroups.Add(chkBoxLstGroups1.Items[i].Text);
                }
            }
            for (int i = 0; i < chkBoxLstGroups2.Items.Count; i++)
            {
                if (chkBoxLstGroups2.Items[i].Selected == true)
                {
                    currentGroups.Add(chkBoxLstGroups2.Items[i].Text);
                }
            }
            for (int i = 0; i < chkBoxLstGroups3.Items.Count; i++)
            {
                if (chkBoxLstGroups3.Items[i].Selected == true)
                {
                    currentGroups.Add(chkBoxLstGroups3.Items[i].Text);
                }
            }
            for (int i = 0; i < chkBoxLstGroups4.Items.Count; i++)
            {
                if (chkBoxLstGroups4.Items[i].Selected == true)
                {
                    currentGroups.Add(chkBoxLstGroups4.Items[i].Text);
                }
            }

            lblMessage2.Visible = true;
            lblMessage2.Text = Group.updateGroups(currentGroups, invID);


            lstBoxGroups.Visible = true;
            btnUpdateGroups.Visible = false;
            chkBoxLstGroups1.Visible = false;
            chkBoxLstGroups2.Visible = false;
            chkBoxLstGroups3.Visible = false;
            chkBoxLstGroups4.Visible = false;
            btnEditGroups.Visible = true;
            btnGoToGroup.Visible = true;
            btnCancelEditGroups.Visible = false;

            lstBoxGroups.DataBind();

        }

        protected void btnGoToGroup_Click(object sender, EventArgs e)
        {
            string selectedGroup = lstBoxGroups.SelectedItem.ToString();
            int groupID = Group.getGroupID(selectedGroup);

            Session["CurrentGroup"] = groupID;
            Response.Redirect("~/Groups/ManageGroup.aspx");
        }

        protected void btnAddMaintenance_Click(object sender, EventArgs e)
        {
            btnAddMaintenance.Visible = false;
            Panel1.Visible = true;
            GridView1.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            btnAddMaintenance.Visible = true;
            GridView1.Visible = true;
            txtBoxMaintenance.Text = "";
        }

        protected void btnInsertMaintenance_Click(object sender, EventArgs e)
        {
            Maintenance maint = new Maintenance();
            maint.InvID = Convert.ToInt32(Session["CurrentComputer"]);
            maint.Date = txtBoxDate.Text;
            maint.Description = txtBoxMaintenance.Text;

            lblMaintenanceMessage.Text = Maintenance.addMaintenance(maint);

            if (lblMaintenanceMessage.Text == "Maintenance added successfully<bR>")
            {
                Panel1.Visible = false;
                btnAddMaintenance.Visible = true;
                GridView1.Visible = true;
                GridView1.DataBind();
            }
        }

        protected void btnCancelEditGroups_Click(object sender, EventArgs e)
        {
            lstBoxGroups.Visible = true;
            btnUpdateGroups.Visible = false;
            chkBoxLstGroups1.Visible = false;
            chkBoxLstGroups2.Visible = false;
            chkBoxLstGroups3.Visible = false;
            chkBoxLstGroups4.Visible = false;
            btnEditGroups.Visible = true;
            btnGoToGroup.Visible = true;
            btnCancelEditGroups.Visible = false;
        }

        protected void btnLogistics_Click(object sender, EventArgs e)
        {
            if (GridView2.Visible == true)
                GridView2.Visible = false;
            else
                GridView2.Visible = true;
        }

        protected void btnAddLicense_Click(object sender, EventArgs e)
        {
            pnlSelectLicense.Visible = true;
        }

        protected void btnCancelLicense_Click(object sender, EventArgs e)
        {
            pnlSelectLicense.Visible = false;
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int licenseID;
            licenseID = Convert.ToInt32(GridView3.SelectedDataKey.Value);
            int invID = Convert.ToInt32(Session["CurrentComputer"]);
            lblLicenseMessage.Text = License.addLicense(licenseID, invID);
            lblLicenseMessage.Visible = true;
            lstBoxLicenses.DataBind();
        }

        protected void lstBoxLicenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveLicense.Enabled = true;
        }

        protected void btnRemoveLicense_Click(object sender, EventArgs e)
        {
            int licenseID = Convert.ToInt32(lstBoxLicenses.SelectedValue);
            int invID = Convert.ToInt32(Session["CurrentComputer"]);
            lblLicenseMessage.Text = License.removeLicense(licenseID, invID);
            lblLicenseMessage.Visible = true;
            lstBoxLicenses.DataBind();
            btnRemoveLicense.Enabled = false;
        }

        protected void btnAddMonitor_Click(object sender, EventArgs e)
        {
            if (btnAddMonitor.Text == "Add a Monitor")
            {
                ddlMonitor.Visible = true;
                btnAddMonitor.Text = "Add Monitor";
                btnCancelAddMonitor.Visible = true;
            }
            else if (btnAddMonitor.Text == "Add Monitor")
            {
                btnCancelAddMonitor.Visible = false;
                int monID = Convert.ToInt32(ddlMonitor.SelectedValue);
                int compID = Convert.ToInt32(Session["CurrentComputerID"]);
                lblMonitorMessage.Visible = true;
                lblMonitorMessage.Text = Monitor.addMonitor(monID, compID);
                if (lblMonitorMessage.Text == "Monitor added successfully<bR>")
                {
                    ddlMonitor.Visible = false;
                    btnAddMonitor.Text = "Add a Monitor";
                }
                lstBoxMonitors.DataBind();
            }
        }

        protected void lstBoxMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveMonitor.Enabled = true;
        }

        protected void btnRemoveMonitor_Click(object sender, EventArgs e)
        {
            int monID = Convert.ToInt32(lstBoxMonitors.SelectedValue);
            int compID = Convert.ToInt32(Session["CurrentComputerID"]);
            lblMonitorMessage.Visible = true;
            lblMonitorMessage.Text = Monitor.deleteMonitor(monID, compID);
            btnRemoveMonitor.Enabled = false;
            lstBoxMonitors.DataBind();
        }

        protected void lstBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGoToGroup.Enabled = true;
        }

        protected void btnCancelAddMonitor_Click(object sender, EventArgs e)
        {
            btnCancelAddMonitor.Visible = false;
            btnAddMonitor.Text = "Add a Monitor";
            ddlMonitor.Visible = false;
        }

        protected void btnAddWarranty_Click(object sender, EventArgs e)
        {
            Page.Validate("warranty");
            Warranty war = new Warranty();
            war.Company = ddlWarrantyCompany.SelectedItem.ToString();
            war.WarrantyType = txtBoxWarrantyType.Text;
            war.StartDate = txtBoxWarrantyStartDate.Text;
            war.EndDate = txtBoxWarrantyEndDate.Text;
            war.Notes = txtBoxWarrantyNotes.Text;

            lblWarrantyMessage.Text = Warranty.addWarranty(Convert.ToInt32(Session["CurrentComputer"]), war);
            lblWarrantyMessage.Visible = true;

            if (lblWarrantyMessage.Text == "Warranty added successfully!")
            {
                panelWarranty.Visible = false;
                btnAddWarranty.Visible = true;
                gvWarranties.Visible = true;
                gvWarranties.DataBind();
            }

        }

        protected void btnAddWarranty_Click1(object sender, EventArgs e)
        {
            panelWarranty.Visible = true;
            btnAddWarranty.Visible = false;
            gvWarranties.Visible = false;
        }

        protected void brnCancelWarranty_Click(object sender, EventArgs e)
        {
            panelWarranty.Visible = false;
            btnAddWarranty.Visible = true;
            gvWarranties.Visible = true;
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
                //e.Row.Attributes["OnClick"] = ClientScript.GetPostBackEventReference(this.GridView4, "Select$" + e.Row.RowIndex);

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
    }
}