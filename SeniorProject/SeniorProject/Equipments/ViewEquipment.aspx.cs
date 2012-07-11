using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;

namespace SeniorProject.Equipments
{
    public partial class ViewEquipment : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Equipment equip = new Equipment();
                equip = EquipmentDA.getEquipment(Convert.ToInt32(Session["CurrentEquipment"]), connString);

                txtBoxSMSUTag.Text = equip.SMSUtag;
                ddlType.Text = equip.EquipmentType;

                bool containsManufacturer = false;
                ddlManufacturer.DataBind();
                for (int i = 0; i < ddlManufacturer.Items.Count; i++)
                {
                    if (ddlManufacturer.Items[i].Text == equip.Manufacturer)
                    {
                        containsManufacturer = true;
                    }
                }
                if (containsManufacturer == false)
                {
                    ddlManufacturer.Items.Add(equip.Manufacturer);
                    ddlManufacturer.Text = equip.Manufacturer;
                }
                else
                {
                    ddlManufacturer.Text = equip.Manufacturer;
                } 
                if (equip.Status != "Transferred")
                {
                    ddlStatus.Text = equip.Status;
                }
                else
                {
                    ddlStatus.Items.Add("Transferred");
                    ddlStatus.Text = "Transferred";
                    ddlStatus.Enabled = false;
                }
                
                txtBoxModel.Text = equip.Model;
                txtBoxSerialNo.Text = equip.SerialNo;

                ddlBuilding.DataBind();
                bool containsBuilding = false;
                for (int i = 0; i < ddlBuilding.Items.Count; i++)
                {
                    if (ddlBuilding.Items[i].Text == equip.CurrentLocation.Building)
                    {
                        containsBuilding = true;
                    }
                }
                if (containsBuilding == false)
                {
                    ddlBuilding.Items.Add(equip.CurrentLocation.Building);
                    ddlBuilding.Text = equip.CurrentLocation.Building;
                }
                else
                {
                    ddlBuilding.Text = equip.CurrentLocation.Building;
                }

                txtBoxRoomNumber.Text = equip.CurrentLocation.Room;
                txtBoxPrimaryUser.Text = equip.CurrentLocation.PrimaryUser;
                txtBoxName.Text = equip.CurrentLocation.Name;

                txtBoxPurchasePrice.Text = equip.PurchasePrice.ToString();
                ddlPONO.SelectedValue = equip.PO.ID.ToString();

                txtBoxConnectivity.Text = equip.Connectivity;
                ddlNetworkCapable.Text = equip.NetworkCapable;
                txtBoxOther.Text = equip.Other;

                txtBoxNotes.Text = equip.Notes;

                txtBoxMaintDate.Text = DateTime.Now.ToShortDateString();

                ArrayList groups = new ArrayList();
                groups = GroupDA.getAllEquipmentGroups(connString);
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
                        for (int j = 0; j < equip.Groups.Count; j++)
                        {
                            Group compGroup = new Group();
                            compGroup = (Group)equip.Groups[j];
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
                        for (int j = 0; j < equip.Groups.Count; j++)
                        {
                            Group compGroup = new Group();
                            compGroup = (Group)equip.Groups[j];
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
                        for (int j = 0; j < equip.Groups.Count; j++)
                        {
                            Group compGroup = new Group();
                            compGroup = (Group)equip.Groups[j];
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
                        for (int j = 0; j < equip.Groups.Count; j++)
                        {
                            Group compGroup = new Group();
                            compGroup = (Group)equip.Groups[j];
                            if (compGroup.Name == group.Name)
                            {
                                chkBoxLstGroups4.Items[chkBoxLstGroups1.Items.Count - 1].Selected = true;
                            }
                        }
                    }
                    if (Session["Authenticated"].ToString() != "True")
                    {
                        panelLicenses.Visible = false;
                    }
                }

            if (equip.Status == "Transferred")
            {
                btnEditGroups.Enabled = false;
                btnAddLicense.Enabled = false;
                btnRemoveSelectedLicense.Enabled = false;
                btnAddMaintenance.Enabled = false;
                btnAddWarranty.Enabled = false;
                btnUpdateEquipment.Enabled = false;
                GridView4.Enabled = false;
            }

            }
        }

        protected void btnUpdateEquipment_Click(object sender, EventArgs e)
        {
            Equipment equip = new Equipment();
            Equipment oEquip = new Equipment();

            oEquip = EquipmentDA.getEquipment(Convert.ToInt32(Session["CurrentEquipment"]), connString);

            equip.InvID = Convert.ToInt32(Session["CurrentEquipment"]);
            equip.SMSUtag = txtBoxSMSUTag.Text;
            equip.EquipmentType = ddlType.Text;
            equip.Manufacturer = ddlManufacturer.Text;
            if (ddlStatus.Enabled == true)
            {
                equip.Status = ddlStatus.Text;
            }
            else
            {
                equip.Status = null;
            }
            
            equip.Model = txtBoxModel.Text;
            equip.SerialNo = txtBoxSerialNo.Text;

            equip.CurrentLocation.Building = ddlBuilding.Text;
            equip.CurrentLocation.Room = txtBoxRoomNumber.Text;
            equip.CurrentLocation.PrimaryUser = txtBoxPrimaryUser.Text;
            equip.CurrentLocation.Name = txtBoxName.Text;

            equip.PurchasePrice = Convert.ToDouble(txtBoxPurchasePrice.Text);
            equip.PO.ID = Convert.ToInt32(ddlPONO.SelectedValue);

            equip.Connectivity = txtBoxConnectivity.Text;
            equip.NetworkCapable = ddlNetworkCapable.Text;
            equip.Other = txtBoxOther.Text;

            equip.Notes = txtBoxNotes.Text;

            lblMessage.Text = EquipmentDA.updateEquipment(oEquip, equip, connString);
            lblMessage.Visible = true;
            btnClearMessage.Visible = true;

        }

        protected void btnShowHideLogistics_Click(object sender, EventArgs e)
        {
            if (GridView1.Visible == false)
            {
                GridView1.Visible = true;
            }
            else
            {
                GridView1.Visible = false;
            }
        }

        protected void btnAddMaintenance_Click(object sender, EventArgs e)
        {
            GridView2.Visible = false;
            panelAddMaintenance.Visible = true;
            btnAddMaintenance.Visible = false;
        }

        protected void btnDoneMaintenance_Click(object sender, EventArgs e)
        {
            GridView2.Visible = true;
            panelAddMaintenance.Visible = false;
            btnAddMaintenance.Visible = true;
        }

        protected void btnInsertMaintenance_Click(object sender, EventArgs e)
        {
            Maintenance maint = new Maintenance();
            maint.InvID = Convert.ToInt32(Session["CurrentEquipment"]);
            maint.Date = txtBoxMaintDate.Text;
            maint.Description = txtBoxMaintDescription.Text;

            lblMaintenanceMessage.Text = MaintenanceDA.addMaintenance(maint, connString);

            if (lblMaintenanceMessage.Text == "Maintenance added successfully<bR>")
            {
                GridView2.Visible = true;
                panelAddMaintenance.Visible = false;
                btnAddMaintenance.Visible = true;
                GridView2.DataBind();
            }
        }

        protected void btnAddLicense_Click(object sender, EventArgs e)
        {
            GridView3.Visible = true;
            btnLicenseCancel.Visible = true;
        }

        protected void lstBoxLicenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveSelectedLicense.Enabled = true;
        }

        protected void btnLicenseCancel_Click(object sender, EventArgs e)
        {
            GridView3.Visible = false;
            btnLicenseCancel.Visible = false;
            lblLicenseMessage.Visible = false;
        }

        protected void btnRemoveSelectedLicense_Click(object sender, EventArgs e)
        {
            int licenseID = Convert.ToInt32(lstBoxLicenses.SelectedValue);
            int invID = Convert.ToInt32(Session["CurrentEquipment"]);
            lblLicenseMessage.Text = LicenseDA.removeLicense(licenseID, invID, connString);
            lblLicenseMessage.Visible = true;
            lstBoxLicenses.DataBind();
            btnRemoveSelectedLicense.Enabled = false;
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int licenseID;
            licenseID = Convert.ToInt32(GridView3.SelectedDataKey.Value);
            int invID = Convert.ToInt32(Session["CurrentEquipment"]);
            lblLicenseMessage.Text = LicenseDA.addLicense(licenseID, invID, connString);
            lblLicenseMessage.Visible = true;
            lstBoxLicenses.DataBind();
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
            btnUpdateGroupsCancel.Visible = true;
        }

        protected void btnUpdateGroupsCancel_Click(object sender, EventArgs e)
        {
            lstBoxGroups.Visible = true;
            btnUpdateGroups.Visible = false;
            chkBoxLstGroups1.Visible = false;
            chkBoxLstGroups2.Visible = false;
            chkBoxLstGroups3.Visible = false;
            chkBoxLstGroups4.Visible = false;
            btnEditGroups.Visible = true;
            btnGoToGroup.Visible = true;
            btnUpdateGroupsCancel.Visible = false;
        }

        protected void btnUpdateGroups_Click(object sender, EventArgs e)
        {
            int invID = Convert.ToInt32(Session["CurrentEquipment"]);
            ArrayList currentGroups = new ArrayList();
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

            lblGroupMessage.Visible = true;
            lblGroupMessage.Text = GroupDA.updateGroups(currentGroups, invID, connString);


            lstBoxGroups.Visible = true;
            btnUpdateGroups.Visible = false;
            chkBoxLstGroups1.Visible = false;
            chkBoxLstGroups2.Visible = false;
            chkBoxLstGroups3.Visible = false;
            chkBoxLstGroups4.Visible = false;
            btnEditGroups.Visible = true;
            btnGoToGroup.Visible = true;
            btnUpdateGroupsCancel.Visible = false;

            lstBoxGroups.DataBind();
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

            lblWarrantyMessage.Text = WarrantyDA.addWarranty(Convert.ToInt32(Session["CurrentEquipment"]), war, connString);
            lblWarrantyMessage.Visible = true;

            if (lblWarrantyMessage.Text == "Warranty added successfully!")
            {
                panelWarranty.Visible = false;
                btnAddWarranty.Visible = true;
                GridView4.Visible = true;
                GridView4.DataBind();
            }

        }

        protected void btnAddWarranty_Click1(object sender, EventArgs e)
        {
            panelWarranty.Visible = true;
            btnAddWarranty.Visible = false;
            GridView4.Visible = false;
        }

        protected void brnCancelWarranty_Click(object sender, EventArgs e)
        {
            panelWarranty.Visible = false;
            btnAddWarranty.Visible = true;
            GridView4.Visible = true;
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

        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //registers click event to entire grid view row
                //e.Row.Attributes["OnClick"] = ClientScript.GetPostBackEventReference(this.GridView2, "Select$" + e.Row.RowIndex);

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