using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Configuration;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProject
{
    public partial class _Default : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            lblMessage.Text = "";


            if (txtBoxBuilding.Text == "" && txtBoxName.Text == "" && txtBoxRoom.Text == "" && txtBoxSerialNo.Text == "" && txtBoxSMSUTag.Text == "")
            {
                lblMessage.Text = "You gotta put in some search critera!";
                lblMessage.Visible = true;
            }
            else 
            {
                string[,] args =  {
                                    {"SerialNo", txtBoxSerialNo.Text}, 
                                    {"SMSUTag", txtBoxSMSUTag.Text},
                                    {"Building", txtBoxBuilding.Text},
                                    {"Room", txtBoxRoom.Text},
                                    {"Name", txtBoxName.Text}
                                  };
                Session["SearchArgs"] = args;
                Response.Redirect("~/Search.aspx");
            }
        }

        protected void btnInstantSearch_Click(object sender, EventArgs e)
        {
            List<int> results = new List<int>();
            results = Inventory.instantSearch(txtBoxSerialNoInstant.Text);

            if (results == null)
            {
                lblMessageInstant.Visible = true;
                lblMessageInstant.Text = "No results found";
            }
            else if (results[1] == 1)
            {
                Response.Redirect("~/Computer/ViewComputer.aspx?id="+results[0].ToString());
            }
            else if (results[1] == 2)
            {
                Response.Redirect("~/Equipments/ViewEquipment.aspx?id="+results[0].ToString());
            }
        }
    }
}
