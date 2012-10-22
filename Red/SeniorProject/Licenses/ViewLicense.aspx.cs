using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using SeniorProjectClassLibrary.Classes;
using System.IO;
using System.Text;

namespace SeniorProject.Licenses
{
    public partial class ViewLicense : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CurrentLicense"] == null)
                {
                    Response.Redirect("~/Licenses/ViewLicenses.aspx");
                }
                if (Session["Authenticated"] == null || Session["Authenticated"].ToString() != "True")
                {
                    Response.Redirect("~/default.aspx");
                }
                License lic = new License();
                lic = License.getLicense(Convert.ToInt32(Session["CurrentLicense"]));

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
            string invID;
            invID = GridView1.SelectedDataKey.Value.ToString();
            Response.Redirect("~/Computer/ViewComputer.aspx?id=" + invID);
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

            License.updateLicense(lic);
            panelUpdateLicense.Visible = false;
            DetailsView1.DataBind();
            DetailsView1.Visible = true;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtboxDescription.Text.Length > 499)
                {
                    lblMessage.Text = "Description has a limit of 500 characters. please shorten your description.";
                    lblMessage.Visible = true;
                }
                else if (AsyncFileUpload.HasFile == true)
                {
                    string licID = Session["CurrentLicense"].ToString();
                    string root = Server.MapPath("");
                    string fullPath = root + "/Files/Test/" + Session["CurrentLicense"].ToString() + "-" + AsyncFileUpload.FileName.ToString();

                    lblMessage.Text = License.saveFile(Convert.ToInt32(Session["CurrentLicense"]), AsyncFileUpload.FileName, txtboxDescription.Text, fullPath);

                    if (lblMessage.Text == "File added successfully")
                    {
                        AsyncFileUpload.SaveAs(fullPath);
                    }
                    lblMessage.Visible = true;
                    gvFiles.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.ToString();
            }
        }

        protected void lnkBtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                //get the name of the file from the grid view gvFiles
                LinkButton lnkButtonSender = (LinkButton)sender;
                int rowIndex = Convert.ToInt32(lnkButtonSender.CommandArgument);
                GridViewRow row = gvFiles.Rows[rowIndex];
                Label lbl = (Label)row.FindControl("lblFileName");
                string fileName = lbl.Text;

                //begin process of file download
                string root = Server.MapPath("");
                string path = root + "\\Files\\Test\\";
                string downloadName = Session["CurrentLicense"].ToString() + "-" + fileName;
                string fullPath = path + downloadName;

                FileInfo info = new FileInfo(fullPath);
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.ContentType = "application/octet-stream";
                Response.TransmitFile(info.FullName);
                //Response.WriteFile(info.FullName);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                Response.Flush();
                
            }
            catch (FileNotFoundException ex)
            {
                ex.ToString();
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('File Not Found!')</SCRIPT>");
            }
            catch (Exception ex)
            {
                Session["Exception"] = ex;
                Response.Redirect("~/Error.aspx");
            }
            Response.End();
        }

        protected void lnkButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkButtonSender = (LinkButton)sender;
                int rowIndex = Convert.ToInt32(lnkButtonSender.CommandArgument);
                gvFiles.SelectedIndex = rowIndex;
                GridViewRow row = gvFiles.Rows[rowIndex];
                Label lbl = (Label)row.FindControl("lblFileName");
                string fileName = lbl.Text;
                int fileID = Convert.ToInt32(gvFiles.SelectedDataKey.Value);

                string root = Server.MapPath("");
                string path = root + "\\Files\\Test\\";
                string downloadName = Session["CurrentLicense"].ToString() + "-" + fileName;
                string fullPath = path + downloadName;

                File.Delete(fullPath);
                License.deleteFile(fileID);

                gvFiles.DataBind();
                gvFiles.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}