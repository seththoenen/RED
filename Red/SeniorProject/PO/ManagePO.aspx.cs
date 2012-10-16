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
    }
}