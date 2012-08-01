using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SeniorProject.Licenses
{
    public partial class ViewLicenses : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Authenticated"] == null || Session["Authenticated"].ToString() != "True")
            {
                Response.Redirect("~/default.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int licenseID;
            licenseID = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            Session["CurrentLicense"] = licenseID;
            Response.Redirect("~/Licenses/ViewLicense.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int licenseID;
            licenseID = Convert.ToInt32(GridView2.SelectedDataKey.Value);
            Session["CurrentLicense"] = licenseID;
            Response.Redirect("~/Licenses/ManageEquipmentLicense.aspx");
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

        protected void btnAddLicense_Click(object sender, EventArgs e)
        {
            License license = new License();
            license.Software = txtBoxSoftware.Text;
            license.OS = txtBoxOperatingSystem.Text;
            license.Key = txtBoxKey.Text;
            license.NumOfCopies = Convert.ToInt32(txtBoxNumOfCopies.Text);
            license.ExpirationDate = txtBoxNumOfCopies.Text;
            license.ExpirationDate = txtBoxExpirationDate.Text;
            license.Notes = txtBoxNotes.Text;
            license.Type = ddlType.SelectedValue;

            lblMessage.Text = LicenseDA.saveLicense(license);
            lblMessage.Visible = true;

            if (lblMessage.Text == "License created successfully!<bR>")
            {
                GridView1.DataBind();
                GridView2.DataBind();

                panelCreateLicense.Visible = false;
                btnCreateLicense.Visible = true;

                txtBoxSoftware.Text = "";
                txtBoxOperatingSystem.Text = "";
                txtBoxKey.Text = "";
                txtBoxNumOfCopies.Text = "";
                txtBoxExpirationDate.Text = "";
                txtBoxNotes.Text = "";
            }
        }

        protected void btnCreateLicense_Click(object sender, EventArgs e)
        {
            panelCreateLicense.Visible = true;
            btnCreateLicense.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCreateLicense.Visible = true;
            panelCreateLicense.Visible = false;

            txtBoxSoftware.Text = "";
            txtBoxOperatingSystem.Text = "";
            txtBoxKey.Text = "";
            txtBoxNumOfCopies.Text = "";
            txtBoxExpirationDate.Text = "";
            txtBoxNotes.Text = "";
        }
    }
}