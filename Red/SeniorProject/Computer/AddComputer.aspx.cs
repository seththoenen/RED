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
    public partial class About : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Warranties"] = new List<Warranty>();
                List<Monitor> monList = new List<Monitor>();
                monList = Monitor.getMonitors();
                ddlType.Text = "Please Select";
                ddlPONO.SelectedValue = "28";

                List<Group> groupList = new List<Group>();
                groupList = Group.getAllComputerGroups();
                int nextGroup = 1;

                for (int i = 0; i < groupList.Count; i++)
                {
                    Group group = new Group();
                    group = (Group)groupList[i];
                    if (nextGroup == 1)
                    {
                        chkBoxListGroups1.Items.Add(group.Name);
                        nextGroup = 2;
                    }
                    else if (nextGroup == 2)
                    {
                        chkBoxListGroups2.Items.Add(group.Name);
                        nextGroup = 3;
                    }
                    else if (nextGroup == 3)
                    {
                        chkBoxListGroups3.Items.Add(group.Name);
                        nextGroup = 4;
                    }
                    else if (nextGroup == 4)
                    {
                        chkBoxListGroups4.Items.Add(group.Name);
                        nextGroup = 1;
                    }
                }
                if (Session["Authenticated"].ToString() != "True")
                {
                    panelLicenses.Visible = false;
                }

                txtBoxSerialNo.Focus();
            }
        }

        protected void btnAddDesktop_Click(object sender, EventArgs e)
        {

            List<Group> groupList = new List<Group>();
            List<Computer> computers = new List<Computer>();

            for(int i=0; i < chkBoxListGroups1.Items.Count; i++)
            {
                if (chkBoxListGroups1.Items[i].Selected == true)
                {
                    Group group = new Group();
                    group.Name = chkBoxListGroups1.Items[i].ToString();
                    groupList.Add(group);
                }
            }
            for (int i = 0; i < chkBoxListGroups2.Items.Count; i++)
            {
                if (chkBoxListGroups2.Items[i].Selected == true)
                {
                    Group group = new Group();
                    group.Name = chkBoxListGroups1.Items[i].ToString();
                    groupList.Add(group);
                }
            }
            for (int i = 0; i < chkBoxListGroups3.Items.Count; i++)
            {
                if (chkBoxListGroups3.Items[i].Selected == true)
                {
                    Group group = new Group();
                    group.Name = chkBoxListGroups1.Items[i].ToString();
                    groupList.Add(group);
                }
            }
            for (int i = 0; i < chkBoxListGroups4.Items.Count; i++)
            {
                if (chkBoxListGroups4.Items[i].Selected == true)
                {
                    Group group = new Group();
                    group.Name = chkBoxListGroups1.Items[i].ToString();
                    groupList.Add(group);
                }
            }

            for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
            {
                Computer comp = new Computer();
                comp.SerialNo = lstBoxSerialNos.Items[i].Text.ToUpper();
                comp.SMSUtag = txtBoxSMSUTag.Text;
                comp.Manufacturer = ddlManufacturer.Text;
                comp.Model = txtBoxModel.Text;
                comp.CurrentLocation.Building = ddlBuilding.Text;
                comp.CurrentLocation.Room = txtBoxRoomNumber.Text;
                comp.CurrentLocation.PrimaryUser = txtBoxPrimaryUser.Text;

                if (txtBoxPurchasePrice.Text == "")
                    comp.PurchasePrice = 0;
                else
                    comp.PurchasePrice = Convert.ToDouble(txtBoxPurchasePrice.Text);

                comp.CurrentLocation.Name = txtBoxName.Text;
                comp.CPU = txtBoxCPU.Text;
                comp.VideoCard = txtBoxVideoCard.Text;
                comp.HardDrive = txtBoxHardDrive.Text;
                comp.Memory = txtBoxMemory.Text;
                comp.OpticalDrive = txtBoxOpticalDrive.Text;
                comp.RemovableMedia = txtBoxRemovableMedia.Text;
                comp.USBports = Convert.ToInt32(ddlUSBports.Text);
                comp.OtherConnectivity = txtBoxOtherConnectivity.Text;
                comp.Size = txtBoxSize.Text;
                comp.Notes = txtBoxNotes.Text;
                comp.Type = ddlType.Text;
                comp.PO = PurchaseOrder.getPO(ddlPONO.SelectedValue.ToString());
                comp.Status = ddlStatus.Text;
                comp.Groups = groupList;
                comp.PhysicalAddress = txtBoxPhysicalAddress.Text.ToUpper();

                for (int j = 0; j < lstBoxMonitors.Items.Count; j++)
                { 
                    Monitor mon = new Monitor();
                    mon.ID = Convert.ToInt32(lstBoxMonitors.Items[j].Value);
                    comp.Monitors.Add(mon);
                }

                for (int j = 0; j < lstBoxLicenses.Items.Count; j++)
                { 
                    License lic = new License();
                    lic.ID = Convert.ToInt32(lstBoxLicenses.Items[j].Value);
                    comp.Licenses.Add(lic);
                }

                comp.Warranties = (List<Warranty>)Session["Warranties"];

                computers.Add(comp);
            }

            lblMessage.Text = Computer.saveComputers(computers);
            if (lblMessage.Text == "Operation successfull!<bR>")
            {
                lstBoxSerialNos.Items.Clear();
            }
            btnClearMessage.Visible = true;

            btnPopUpExtender_ModalPopupExtender.Show();
            
        }

        protected void btnClearMessage_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            btnClearMessage.Visible = false;
            pnlModalOperation.Visible = false;
        }

        protected void btnAddMonitor_Click(object sender, EventArgs e)
        {
            lstBoxMonitors.Items.Add(new ListItem(ddlMonitor.SelectedItem.ToString(), ddlMonitor.SelectedValue.ToString()));
            int monCount = Convert.ToInt32(lblMonitorCount.Text);
            monCount++;
            lblMonitorCount.Text = monCount.ToString();
        }

        protected void btnRemoveMonitors_Click(object sender, EventArgs e)
        {
            try
            {
                lstBoxMonitors.Items.RemoveAt(lstBoxMonitors.SelectedIndex);
                int monCount = Convert.ToInt32(lblMonitorCount.Text);
                monCount--;
                lblMonitorCount.Text = monCount.ToString();
            }
            catch
            { }
        }

        protected void lstBoxMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveMonitors.Enabled = true;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int licenseID;
            licenseID = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            string licenseName = "";
            licenseName = GridView1.DataKeys[GridView1.SelectedIndex].Values["Software"].ToString();
            ListItem li = new ListItem(licenseName, licenseID.ToString());

            bool hasLicense = false;
            for (int i = 0; i < lstBoxLicenses.Items.Count; i++)
            {
                if (lstBoxLicenses.Items[i].Value == li.Value)
                {
                    hasLicense = true;
                }
            }
            if (hasLicense == false)
            {
                lstBoxLicenses.Items.Add(li);
            }
        }

        protected void btnRemoveLicense_Click(object sender, EventArgs e)
        {
            try
            {
                lstBoxLicenses.Items.RemoveAt(lstBoxLicenses.SelectedIndex);
            }
            catch { }
        }

        protected void btnAddWarranty_Click(object sender, EventArgs e)
        {
            Page.Validate("warranty");
            List<Warranty> warranties = new List<Warranty>();
            Warranty war = new Warranty();
            war.Company = ddlWarrantyCompany.SelectedItem.ToString();
            war.WarrantyType = txtBoxWarrantyType.Text;
            war.StartDate = txtBoxWarrantyStartDate.Text;
            war.EndDate = txtBoxWarrantyEndDate.Text;
            war.Notes = txtBoxWarrantyNotes.Text;

            if (lstBoxWarranties.Items.Count == 0)
            {
                warranties.Clear();
            }
            else
            {
                warranties = (List<Warranty>)Session["Warranties"];
                
            }
            warranties.Add(war);

            lstBoxWarranties.Items.Clear();
            for (int i = 0; i < warranties.Count; i++)
            {
                Warranty warranty = new Warranty();
                warranty = (Warranty)warranties[i];
                lstBoxWarranties.Items.Add(warranty.Company + ": " + warranty.StartDate + "-" + warranty.EndDate);
            }
            Session["Warranties"] = warranties;
        }

        protected void btnRemoveWarranty_Click(object sender, EventArgs e)
        {
            try
            {
                List<Warranty> warranties = new List<Warranty>();
                warranties = (List<Warranty>)Session["Warranties"];
                warranties.RemoveAt(lstBoxWarranties.SelectedIndex);

                lstBoxWarranties.Items.Clear();
                for (int i = 0; i < warranties.Count; i++)
                {
                    Warranty warranty = new Warranty();
                    warranty = (Warranty)warranties[i];
                    lstBoxWarranties.Items.Add(warranty.Company + ": " + warranty.StartDate + "-" + warranty.EndDate);
                }
                Session["Warranties"] = warranties;
            }
            catch { }
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

        protected void txtBoxSerialNo_TextChanged(object sender, EventArgs e)
        {
            bool existLB = false;
            //bool existDB = false;
            for (int i = 0; i<lstBoxSerialNos.Items.Count; i++)
            {
                if (lstBoxSerialNos.Items[i].Text.ToUpper() == txtBoxSerialNo.Text.ToUpper())
                {
                    existLB = true;
                    lblSerialNos.Visible = true;
                    lblSerialNos.Text += txtBoxSerialNo.Text + " is already in queue<bR />";
                    break;
                }
            }
            if (existLB == false)
            {
                if (Computer.computerExist(txtBoxSerialNo.Text) == true)
                {
                    //existDB = true;
                    lblSerialNos.Visible = true;
                    lblSerialNos.Text += txtBoxSerialNo.Text + " is already in the database<br />";
                }
                else
                {
                    lstBoxSerialNos.Items.Add(txtBoxSerialNo.Text.ToUpper());
                    lstBoxSerialNos.Text = txtBoxSerialNo.Text.ToUpper();
                }
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

        protected void btnAddWithTextBoxToggle_Click(object sender, EventArgs e)
        {
            if (btnAddWithTextBoxToggle.Text == "Add With Text Box")
            {
                panelPage.Visible = false;
                panelTextBox.Visible = true;
                btnAddWithTextBoxToggle.Text = "Done";
            }
            else if (btnAddWithTextBoxToggle.Text == "Done")
            {
                panelPage.Visible = true;
                panelTextBox.Visible = false;
                btnAddWithTextBoxToggle.Text = "Add With Text Box";
            }
        }

        protected void btnAddWithTextBox_Click(object sender, EventArgs e)
        {
            string[] serialNos = txtBoxSerialNos.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string serialNo in serialNos)
            {
                bool existLB = false;

                for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
                {
                    if (lstBoxSerialNos.Items[i].Text == serialNo.ToUpper())
                    {
                        existLB = true;
                        lblAddTextBoxMessage.Text += serialNo + " is already in queue<bR />";
                        break;
                    }
                }
                if (existLB == false)
                {
                    if (serialNo.Length > 45)
                    {
                        lblAddTextBoxMessage.Text += serialNo + " is too long<br />";
                    }
                    else if (serialNo == "")
                    {
                        lblAddTextBoxMessage.Text += "A blank entry was found and was ignored, you should be more careful in the future<br />";
                    }
                    else if (Computer.computerExist(serialNo) == true)
                    {
                        lblAddTextBoxMessage.Text += serialNo + " is already in the database<br />";
                    }
                    else
                    {
                        lstBoxSerialNos.Items.Add(serialNo.ToUpper());
                        lstBoxSerialNos.Text = serialNo.ToUpper();
                    }
                }
            }
        }
    }
}
