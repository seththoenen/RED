using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SeniorProject.Licenses
{
    public partial class AddLicense : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Authenticated"].ToString() != "True")
            {
                Response.Redirect("~/default.aspx");
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
            btnClear.Visible = true;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            btnClear.Visible = false;
            lblMessage.Visible = false;
        }
    }
}