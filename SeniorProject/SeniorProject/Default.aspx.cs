using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Configuration;

namespace SeniorProject
{
    public partial class _Default : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["Authenticated"].ToString() == "True")
                    {
                        panelAuthenticated.Visible = true;
                    }
                    else
                    {
                        panelNotAuthenticated.Visible = true;
                    }
                }
                catch 
                {
                    Session["Authenticated"] = "False";
                    panelNotAuthenticated.Visible = true;
                }
            }
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

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["Authenticated"] = "False";
            panelNotAuthenticated.Visible = true;
            panelAuthenticated.Visible = false;
        }

        protected void authenticate()
        {
            if (SettingsDA.authenticatePassword(txtBoxPassword.Text, connString) == true)
            {
                Session["Authenticated"] = "True";
                panelAuthenticated.Visible = true;
                panelNotAuthenticated.Visible = false;
            }
            else
            {
                lblAuthMessage.Visible = true;
                lblAuthMessage.Text = "Incorrect Password";
            }
        }

        protected void txtBoxPassword_TextChanged(object sender, EventArgs e)
        {
            authenticate();
        }

        protected void btnInstantSearch_Click(object sender, EventArgs e)
        {
            List<int> results = new List<int>();
            results = InventoryDA.instantSearch(txtBoxSerialNoInstant.Text, connString);

            if (results == null)
            {
                lblMessageInstant.Visible = true;
                lblMessageInstant.Text = "No results found";
            }
            else if (results[1] == 1)
            {
                Session["CurrentComputer"] = results[0];
                Response.Redirect("~/Computer/ViewDesktop.aspx");
            }
            else if (results[1] == 2)
            {
                Session["CurrentEquipment"] = results[0];
                Response.Redirect("~/Equipments/ViewEquipment.aspx");
            }
        }
    }
}
