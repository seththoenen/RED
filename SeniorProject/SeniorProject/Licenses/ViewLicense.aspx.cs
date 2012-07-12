using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SeniorProject.Licenses
{
    public partial class ViewLicense : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Authenticated"].ToString() != "True")
                {
                    Response.Redirect("~/default.aspx");
                }
                License lic = new License();
                lic = LicenseDA.getLicense(Convert.ToInt32(Session["CurrentLicense"]), connString);

                txtBoxExpirationDate.Text = lic.ExpirationDate;
                txtBoxKey.Text = lic.Key;
                txtBoxNotes.Text = lic.Notes;
                txtBoxNumOfCopies.Text = lic.NumOfCopies.ToString();
                txtBoxOperatingSystem.Text = lic.OS;
                txtBoxSoftware.Text = lic.Software;
            }            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string compID;
            compID = GridView1.SelectedDataKey.Value.ToString();
            Session["CurrentComputer"] = compID;
            Response.Redirect("~/Computer/ViewDesktop.aspx");
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

        protected void btnUpdateLicense_Click(object sender, EventArgs e)
        {
            if (btnUpdateLicense.Text == "Update License")
            {
                panelUpdateLicense.Visible = true;
                DetailsView1.Visible = false;
                btnUpdateLicense.Text = "Cancel";
            }
            else if (btnUpdateLicense.Text == "Cancel")
            {
                panelUpdateLicense.Visible = false;
                DetailsView1.Visible = true;
                btnUpdateLicense.Text = "Update License";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            License lic = new License();
            lic.ID = Convert.ToInt32(Session["CurrentLicense"]);
            lic.Software = txtBoxSoftware.Text;
            lic.OS = txtBoxOperatingSystem.Text;
            lic.NumOfCopies = Convert.ToInt32(txtBoxNumOfCopies.Text);
            lic.Notes = txtBoxNotes.Text;
            lic.ExpirationDate = txtBoxExpirationDate.Text;
            lic.Key = txtBoxKey.Text;

            LicenseDA.updateLicense(lic, connString);
            panelUpdateLicense.Visible = false;
            DetailsView1.DataBind();
            DetailsView1.Visible = true;
        }
    }
}