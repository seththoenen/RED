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
    public partial class AddEquipment : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Warranties"] = new ArrayList();  
            
                ArrayList groups = new ArrayList();
                groups = GroupDA.getAllEquipmentGroups();

                int counter = 0;
                for (int i = 0; i < groups.Count; i++)
                {
                    if (counter == 0)
                    {
                        Group group = new Group();
                        group = (Group)groups[i];
                        ListItem li = new ListItem(group.Name, group.ID.ToString());
                        chkBoxListGroups1.Items.Add(li);
                        counter = 1;
                    }
                    else if (counter == 1)
                    {
                        Group group = new Group();
                        group = (Group)groups[i];
                        ListItem li = new ListItem(group.Name, group.ID.ToString());
                        chkBoxListGroups2.Items.Add(li);
                        counter = 2;
                    }
                    else if (counter == 2)
                    {
                        Group group = new Group();
                        group = (Group)groups[i];
                        ListItem li = new ListItem(group.Name, group.ID.ToString());
                        chkBoxListGroups3.Items.Add(li);
                        counter = 3;
                    }
                    else if (counter == 3)
                    {
                        Group group = new Group();
                        group = (Group)groups[i];
                        ListItem li = new ListItem(group.Name, group.ID.ToString());
                        chkBoxListGroups4.Items.Add(li);
                        counter = 0;
                    }
                }
                if (Session["Authenticated"].ToString() != "True")
                {
                    panelLicenses.Visible = false;
                }
                txtBoxSerialNo.Focus();
            }
        }

        protected void btnAddEquipment_Click(object sender, EventArgs e)
        {
            ArrayList equipList = new ArrayList();
            ArrayList groupList = new ArrayList();
            for (int i = 0; i < chkBoxListGroups1.Items.Count; i++)
            {
                if (chkBoxListGroups1.Items[i].Selected == true)
                {
                    Group group = new Group();
                    group.ID = Convert.ToInt32(chkBoxListGroups1.Items[i].Value);
                    group.Name = chkBoxListGroups1.Items[i].Text;
                    groupList.Add(group);
                }
            }
            for (int i = 0; i < chkBoxListGroups2.Items.Count; i++)
            {
                if (chkBoxListGroups2.Items[i].Selected == true)
                {
                    Group group = new Group();
                    group.ID = Convert.ToInt32(chkBoxListGroups2.Items[i].Value);
                    group.Name = chkBoxListGroups2.Items[i].Text;
                    groupList.Add(group);
                }
            }
            for (int i = 0; i < chkBoxListGroups3.Items.Count; i++)
            {
                if (chkBoxListGroups3.Items[i].Selected == true)
                {
                    Group group = new Group();
                    group.ID = Convert.ToInt32(chkBoxListGroups3.Items[i].Value);
                    group.Name = chkBoxListGroups3.Items[i].Text;
                    groupList.Add(group);
                }
            }
            for (int i = 0; i < chkBoxListGroups4.Items.Count; i++)
            {
                if (chkBoxListGroups4.Items[i].Selected == true)
                {
                    Group group = new Group();
                    group.ID = Convert.ToInt32(chkBoxListGroups4.Items[i].Value);
                    group.Name = chkBoxListGroups4.Items[i].Text;
                    groupList.Add(group);
                }
            }

            for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
            {
                Equipment equip = new Equipment();

                equip.SerialNo = lstBoxSerialNos.Items[i].Text;
                equip.SMSUtag = txtBoxSMSUTag.Text;
                equip.EquipmentType = ddlType.Text;
                equip.Manufacturer = ddlManufacturer.Text;
                equip.Status = ddlStatus.Text;
                equip.Model = txtBoxModel.Text;
                if (txtBoxPurchasePrice.Text == "")
                {
                    equip.PurchasePrice = 0;
                }
                else
                {
                    equip.PurchasePrice = Convert.ToDouble(txtBoxPurchasePrice.Text);
                }
                equip.Connectivity = txtBoxConnectivity.Text;
                equip.Other = txtBoxOther.Text;
                equip.Notes = txtBoxNotes.Text;
                equip.CurrentLocation.Building = ddlBuilding.Text;
                equip.CurrentLocation.Room = txtBoxRoomNumber.Text;
                equip.CurrentLocation.PrimaryUser = txtBoxPrimaryUser.Text;
                equip.CurrentLocation.Name = txtBoxName.Text;
                equip.NetworkCapable = ddlNetworkCapable.Text;
                equip.PhysicalAddress = txtBoxPhysicalAddress.Text.ToUpper();

                equip.PO.ID = Convert.ToInt32(ddlPONO.SelectedValue);
                equip.Groups = groupList;
                
                equipList.Add(equip);

                for (int j = 0; j < lstBoxLicenses.Items.Count; j++)
                {
                    License lic = new License();
                    lic.ID = Convert.ToInt32(lstBoxLicenses.Items[j].Value);
                    equip.Licenses.Add(lic);
                }

                equip.Warranties = (ArrayList)Session["Warranties"];

            }

            lblMessage.Text = EquipmentDA.saveEquipment(equipList);
            if (lblMessage.Text == "Operation successfull!<bR>")
            {
                lstBoxSerialNos.Items.Clear();
            }
            lblMessage.Visible = true;
            btnClearMessage.Visible = true;
        }

        protected void btnClearMessage_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            btnClearMessage.Visible = false;
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int licenseID;
            licenseID = Convert.ToInt32(GridView4.SelectedDataKey.Value);
            string licenseName = "";
            licenseName = GridView4.DataKeys[GridView4.SelectedIndex].Values["Software"].ToString();
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

        protected void GridView4_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //registers click event to entire grid view row
                e.Row.Attributes.Add("OnClick", ClientScript.GetPostBackEventReference(this.GridView4, "Select$" + e.Row.RowIndex));

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
                lblSerialNos.Text += txtBoxSerialNo.Text + " is already in the database<bR />";
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
                if (EquipmentDA.equipmentExist(serialNo) == true)
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