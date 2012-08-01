using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SeniorProject.PO
{
    public partial class AddPO : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddPO_Click(object sender, EventArgs e)
        {
            PurchaseOrder PO = new PurchaseOrder();
            PO.PONumber = txtBoxPoNo.Text;
            PO.DeliveryDate = txtBoxDeliveryDate.Text; 
            PO.RequisitionNumber = txtBoxRequisitionNo.Text;
            PO.PurchaseDate = txtBoxPurchaseDate.Text;
            PO.Title = txtBoxTitle.Text;

            lblMessage.Text = PODA.savePO(PO);
            btnClear.Visible = true;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            btnClear.Visible = false;
        }
    }
}