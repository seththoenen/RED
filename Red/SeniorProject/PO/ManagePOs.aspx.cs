using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProject.PO
{
   public partial class ManagePOs : System.Web.UI.Page
    {
       string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString; 
       
       protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string poID;
            poID = GridView1.SelectedDataKey.Value.ToString();
            Session["CurrentPurchaseOrder"] = poID;
            Response.Redirect("~/PO/ManagePO.aspx");
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

        protected void btnCreateNewPO_Click(object sender, EventArgs e)
        {
            panelCreateNewPO.Visible = true;
            btnCreateNewPO.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCreateNewPO.Visible = true;
            panelCreateNewPO.Visible = false;
            txtBoxPoNo.Text = "";
            txtBoxRequisitionNo.Text = "";
            txtBoxPurchaseDate.Text = "";
            txtBoxDeliveryDate.Text = "";
            txtBoxTitle.Text = "";
        }

        protected void btnAddPO_Click(object sender, EventArgs e)
        {
            PurchaseOrder PO = new PurchaseOrder();
            PO.PONumber = txtBoxPoNo.Text;
            PO.DeliveryDate = txtBoxDeliveryDate.Text;
            PO.RequisitionNumber = txtBoxRequisitionNo.Text;
            PO.PurchaseDate = txtBoxPurchaseDate.Text;
            PO.Title = txtBoxTitle.Text;

            lblMessage.Text = PurchaseOrder.savePO(PO);
            lblMessage.Visible = true;

            if (lblMessage.Text == "Purchase Order created successfully<bR>")
            {
                GridView1.DataBind();
                panelCreateNewPO.Visible = false;
                btnCreateNewPO.Visible = true;

                txtBoxPoNo.Text = "";
                txtBoxRequisitionNo.Text = "";
                txtBoxPurchaseDate.Text = "";
                txtBoxDeliveryDate.Text = "";
                txtBoxTitle.Text = "";
            }
            
        }
    }
}