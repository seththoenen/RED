﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProject
{
    public partial class Manage : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstBoxMonitor.SelectedIndex = 0;
                if (Session["Authenticated"].ToString() == "True")
                {
                    updatePanelSiteMode.Visible = true;
                }
            }

            try
            {
                System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                System.Configuration.KeyValueConfigurationElement siteMode = webConfig.AppSettings.Settings["siteMode"];
                lblSiteMode.Text = siteMode.Value.ToString();

                if (siteMode.Value.ToString() == "Release")
                {
                    lblChangeSiteMode.Text = "DEBUG";
                }
                else if (siteMode.Value.ToString() == "Debug")
                {
                    lblChangeSiteMode.Text = "RELEASE";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnAddMonitor_Click(object sender, EventArgs e)
        {
            if (btnAddMonitor.Text == "Add Monitor")
            {
                Monitor mon = new Monitor();
                mon.Brand = txtBoxBrand.Text;
                mon.Connectors = txtBoxConnectors.Text;
                mon.DisplayText = txtBoxDisplayText.Text;
                mon.Model = txtBoxModel.Text;
                mon.Resolution = txtBoxResolution.Text;
                mon.Size = txtBoxResolution.Text;

                
                lblMessage.Text = Monitor.saveMonitor(mon);

                refresh();

            }
            else if (btnAddMonitor.Text == "Update Monitor")
            {
                Monitor mon = new Monitor();
                mon = (Monitor)Session["SelectedMonitor"];
                mon.Brand = txtBoxBrand.Text;
                mon.Connectors = txtBoxConnectors.Text;
                mon.DisplayText = txtBoxDisplayText.Text;
                mon.Model = txtBoxModel.Text;
                mon.Resolution = txtBoxResolution.Text;
                mon.Size = txtBoxResolution.Text;
                lblMessage.Text = Monitor.updateMonitor(mon);

                btnAddMonitor.Text = "Add Monitor";
                btnCancel.Visible = false;

                refresh();

                txtBoxSize.Text = "";
                txtBoxBrand.Text = "";
                txtBoxModel.Text = "";
                txtBoxResolution.Text = "";
                txtBoxConnectors.Text = "";
                txtBoxDisplayText.Text = "";

                lstBoxMonitor.SelectedIndex = 0;
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Monitor mon = new Monitor();
                mon = Monitor.getMonitor(Convert.ToInt32(lstBoxMonitor.SelectedValue));
                mon.ID = Convert.ToInt32(lstBoxMonitor.SelectedValue);
                txtBoxSize.Text = mon.Size;
                txtBoxBrand.Text = mon.Brand;
                txtBoxModel.Text = mon.Model;
                txtBoxResolution.Text = mon.Resolution;
                txtBoxConnectors.Text = mon.Connectors;
                txtBoxDisplayText.Text = mon.DisplayText;

                Session["SelectedMonitor"] = mon;

                btnAddMonitor.Text = "Update Monitor";
                btnCancel.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtBoxSize.Text = "";
            txtBoxBrand.Text = "";
            txtBoxModel.Text = "";
            txtBoxResolution.Text = "";
            txtBoxConnectors.Text = "";
            txtBoxDisplayText.Text = "";

            btnAddMonitor.Text = "Add Monitor";
            btnCancel.Visible = false;
        }

        protected void refresh()
        {
            lstBoxMonitor.DataBind();
            DetailsView1.DataBind();
        }

        protected void btnAddBuilding_Click(object sender, EventArgs e)
        {
            lblBuildingMessage.Text = Settings.saveSetting(txtBoxBuilding.Text, "Building");
            lblBuildingMessage.Visible = true;
            lstBoxBuildings.DataBind();
        }

        protected void btnRemoveBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.deleteSetting(Convert.ToInt32(lstBoxBuildings.SelectedValue));
                lstBoxBuildings.DataBind();
            }
            catch { }
        }

        protected void btnAddManufacturer_Click(object sender, EventArgs e)
        {
            lblManufacturerMessage.Text = Settings.saveSetting(txtBoxManufacturer.Text, "Manufacturer");
            lblManufacturerMessage.Visible = true;
            lstBoxManufcturers.DataBind();
        }

        protected void btnRemoveManufacturer_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.deleteSetting(Convert.ToInt32(lstBoxManufcturers.SelectedValue));
                lstBoxManufcturers.DataBind();
            }
            catch { }
        }

        protected void btnExecuteChangeSiteMode_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBoxChange.Text.ToUpper() == "CHANGE")
                {
                    System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                    System.Configuration.KeyValueConfigurationElement siteMode = webConfig.AppSettings.Settings["siteMode"];
                    ConnectionStringsSection section = webConfig.GetSection("connectionStrings") as ConnectionStringsSection;
                    lblSiteMode.Text = siteMode.Value.ToString();

                    if (siteMode.Value.ToString() == "Release")
                    {
                        webConfig.AppSettings.Settings["siteMode"].Value = "Debug";
                        section.ConnectionStrings["EquipmentConnectionString"].ConnectionString = "Data Source=RLSRESNET\\SQLEXPRESS2012;Initial Catalog=EquipmentTest;User ID=thoenen;Password=Sisemen1";
                        webConfig.Save();
                    }
                    else if (siteMode.Value.ToString() == "Debug")
                    {
                        webConfig.AppSettings.Settings["siteMode"].Value = "Release";
                        section.ConnectionStrings["EquipmentConnectionString"].ConnectionString = "Data Source=RLSRESNET\\SQLEXPRESS2012;Initial Catalog=Equipment;User ID=thoenen;Password=Sisemen1";
                        webConfig.Save();
                    }

                    Response.Redirect("~/Default.aspx");

                }
                else
                {
                    lblChangeMessage.Visible = true;
                    lblChangeMessage.Text = "That doesn't say \"Change\".";
                    this.btnChangeSiteMode_ModalPopupExtender.Show();                                       
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}