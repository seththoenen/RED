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

namespace SeniorProject.PO
{ 
    public partial class ManagePO : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CurrentPurchaseOrder"] == null)
                {
                    Response.Redirect("~/PO/ManagePOs.aspx");
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string invID;
            invID = GridView1.SelectedDataKey.Value.ToString();
            Response.Redirect("~/Computer/ViewComputer.aspx?id=" + invID);
        }

        protected void btnEditPurchaseOrder_Click(object sender, EventArgs e)
        {
            DetailsView1.Visible = false;
            panelEditPurchaseOrder.Visible = true;
            btnEditPurchaseOrder.Visible = false;

            PurchaseOrder PO = new PurchaseOrder();
            PO = PurchaseOrder.getPO(Session["CurrentPurchaseOrder"].ToString());

            txtBoxDeliveryDate.Text = PO.DeliveryDate;
            txtBoxPONumber.Text = PO.PONumber;
            txtBoxPurchaseDate.Text = PO.PurchaseDate;
            txtBoxRequisitionNumber.Text = PO.RequisitionNumber;
            txtBoxTitle.Text = PO.Title;
        }

        protected void btnUpdatePO_Click(object sender, EventArgs e)
        {
            PurchaseOrder newPO = new PurchaseOrder();
            newPO.Title = txtBoxTitle.Text;
            newPO.PONumber = txtBoxPONumber.Text;
            newPO.DeliveryDate = txtBoxDeliveryDate.Text;
            newPO.PurchaseDate = txtBoxPurchaseDate.Text;
            newPO.RequisitionNumber = txtBoxRequisitionNumber.Text;

            lblMessage.Text = PurchaseOrder.updatePO(newPO, Convert.ToInt32(Session["CurrentPurchaseOrder"]));

            if (lblMessage.Text == "Purchase Order created successfully<bR>")
            {
                DetailsView1.Visible = true;
                panelEditPurchaseOrder.Visible = false;
                btnEditPurchaseOrder.Visible = true;
                DetailsView1.DataBind();
            }
            else
            {
                lblMessage.Visible = true;
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int invID;
            invID = Convert.ToInt32(GridView2.SelectedDataKey.Value);
            Response.Redirect("~/Equipments/ViewEquipment.aspx?id=" + invID);
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
                    //Get site mode from web.config to determine where to save files on the filesystem
                    System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                    System.Configuration.KeyValueConfigurationElement siteMode = webConfig.AppSettings.Settings["siteMode"];

                    string folder = "";
                    if (siteMode.Value.ToString() == "Release")
                    {
                        folder = "Release";
                    }
                    else if (siteMode.Value.ToString() == "Debug")
                    {
                        folder = "Test";
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                    string licID = Session["CurrentPurchaseOrder"].ToString();
                    string root = Server.MapPath("");
                    string fullPath = root + "/Files/" + folder + "/" + Session["CurrentPurchaseOrder"].ToString() + "-" + AsyncFileUpload.FileName.ToString();

                    lblFileMessage.Text = PurchaseOrder.saveFile(Convert.ToInt32(Session["CurrentPurchaseOrder"]), AsyncFileUpload.FileName, txtboxDescription.Text, fullPath);

                    if (lblFileMessage.Text == "File added successfully")
                    {
                        AsyncFileUpload.SaveAs(fullPath);
                    }
                    lblFileMessage.Visible = true;
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
                //Get site mode from web.config to determine where to save files on the filesystem
                System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                System.Configuration.KeyValueConfigurationElement siteMode = webConfig.AppSettings.Settings["siteMode"];

                string folder = "";
                if (siteMode.Value.ToString() == "Release")
                {
                    folder = "Release";
                }
                else if (siteMode.Value.ToString() == "Debug")
                {
                    folder = "Test";
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                //get the name of the file from the grid view gvFiles
                LinkButton lnkButtonSender = (LinkButton)sender;
                int rowIndex = Convert.ToInt32(lnkButtonSender.CommandArgument);
                GridViewRow row = gvFiles.Rows[rowIndex];
                Label lbl = (Label)row.FindControl("lblFileName");
                string fileName = lbl.Text;

                //begin process of file download
                string root = Server.MapPath("");
                string path = root + "\\Files\\" + folder + "\\";
                string downloadName = Session["CurrentPurchaseOrder"].ToString() + "-" + fileName;
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
                //Get site mode from web.config to determine where to save files on the filesystem
                System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                System.Configuration.KeyValueConfigurationElement siteMode = webConfig.AppSettings.Settings["siteMode"];

                string folder = "";
                if (siteMode.Value.ToString() == "Release")
                {
                    folder = "Release";
                }
                else if (siteMode.Value.ToString() == "Debug")
                {
                    folder = "Test";
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                LinkButton lnkButtonSender = (LinkButton)sender;
                int rowIndex = Convert.ToInt32(lnkButtonSender.CommandArgument);
                gvFiles.SelectedIndex = rowIndex;
                GridViewRow row = gvFiles.Rows[rowIndex];
                Label lbl = (Label)row.FindControl("lblFileName");
                string fileName = lbl.Text;
                int fileID = Convert.ToInt32(gvFiles.SelectedDataKey.Value);

                string root = Server.MapPath("");
                string path = root + "\\Files\\" + folder + "\\";
                string downloadName = Session["CurrentPurchaseOrder"].ToString() + "-" + fileName;
                string fullPath = path + downloadName;

                File.Delete(fullPath);
                PurchaseOrder.deleteFile(fileID);

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