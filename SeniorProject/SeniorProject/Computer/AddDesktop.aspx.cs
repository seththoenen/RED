using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;

namespace SeniorProject
{
    public partial class About : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Warranties"] = new ArrayList();    
                ArrayList monList = new ArrayList();
                monList = MonitorDA.getMonitors(connString);
                ddlType.Text = "Please Select";
                ddlPONO.SelectedValue = "28";

                ArrayList groupList = new ArrayList();
                groupList = GroupDA.getAllComputerGroups(connString);
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

            ArrayList groupList = new ArrayList();
            ArrayList computers = new ArrayList();

            for(int i=0; i < chkBoxListGroups1.Items.Count; i++)
            {
                if (chkBoxListGroups1.Items[i].Selected == true)
                {
                    groupList.Add(chkBoxListGroups1.Items[i].ToString());
                }
            }
            for (int i = 0; i < chkBoxListGroups2.Items.Count; i++)
            {
                if (chkBoxListGroups2.Items[i].Selected == true)
                {
                    groupList.Add(chkBoxListGroups2.Items[i].ToString());
                }
            }
            for (int i = 0; i < chkBoxListGroups3.Items.Count; i++)
            {
                if (chkBoxListGroups3.Items[i].Selected == true)
                {
                    groupList.Add(chkBoxListGroups3.Items[i].ToString());
                }
            }
            for (int i = 0; i < chkBoxListGroups4.Items.Count; i++)
            {
                if (chkBoxListGroups4.Items[i].Selected == true)
                {
                    groupList.Add(chkBoxListGroups4.Items[i].ToString());
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
                comp.PO = PODA.getPO(ddlPONO.SelectedValue.ToString(), connString);
                comp.Status = ddlStatus.Text;
                comp.Groups = groupList;

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

                comp.Warranties = (ArrayList)Session["Warranties"];

                computers.Add(comp);
            }

            lblMessage.Text = ComputerDA.saveComputers(computers, connString);
            if (lblMessage.Text == "Operation successfull!<bR>")
            {
                lstBoxSerialNos.Items.Clear();
            }
            btnClearMessage.Visible = true;
        }

        protected void btnClearMessage_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            btnClearMessage.Visible = false;
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
            ArrayList warranties = new ArrayList();
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
                warranties = (ArrayList)Session["Warranties"];
                
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
                ArrayList warranties = new ArrayList();
                warranties = (ArrayList)Session["Warranties"];
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
            bool existDB = false;
            for (int i = 0; i<lstBoxSerialNos.Items.Count; i++)
            {
                if (lstBoxSerialNos.Items[i].Text == txtBoxSerialNo.Text.ToUpper())
                {
                    existLB = true;
                }
            }
            if (ComputerDA.computerExist(txtBoxSerialNo.Text, connString) == true)
            {
                existDB = true;
            }
            if (existLB == false && existDB == false)
            {
                lstBoxSerialNos.Items.Add(txtBoxSerialNo.Text.ToUpper());
                lstBoxSerialNos.Text = txtBoxSerialNo.Text.ToUpper();
            }
            else if (existLB == true)
            {
                lblSerialNos.Visible = true;
                lblSerialNos.Text += txtBoxSerialNo.Text + " is already in queue<bR />";
            }
            else if (existDB == true)
            {
                lblSerialNos.Visible = true;
                lblSerialNos.Text += txtBoxSerialNo.Text + " is already in the database<br />";
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
                btnAddWithTextBoxToggle.Text = "Done Adding With Text Box";
            }
            else if (btnAddWithTextBoxToggle.Text == "Done Adding With Text Box")
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
                if (ComputerDA.computerExist(serialNo, connString) == true)
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
                if (existLB == false && existDB == false && isTooLong == false && isBlank == false)
                {
                    lstBoxSerialNos.Items.Add(serialNo.ToUpper());
                    lstBoxSerialNos.Text = serialNo.ToUpper();
                }
                else if (existLB == true)
                {
                    lblAddTextBoxMessage.Text += serialNo + " is already in queue<bR />";
                }
                else if (existDB == true)
                {
                    lblAddTextBoxMessage.Text += serialNo + " is already in the database<br />";
                }
                else if (isTooLong == true)
                {
                    lblAddTextBoxMessage.Text += serialNo + " is too long<br />";
                }
                else if (isBlank == true)
                {
                    lblAddTextBoxMessage.Text += "A blank entry was found and was ignored, you should be more careful in the future<br />";
                }
            }
        }
    }
}
