using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProject
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //checks to see who is logged into the system based upon the active directory to manage permissions to the site
            if (!IsPostBack)
            {
                string user = HttpContext.Current.Request.ServerVariables["AUTH_USER"].ToString().Substring(4);
                lblADUser.Text = user;

                if (Session["AuthUsers"] == null)
                {
                    Session["AuthUsers"] = Settings.getAuthUsers();
                    List<string> authUsers = (List<string>)(Session["AuthUsers"]);
                    for (int i = 0; i < authUsers.Count; i++)
                    {
                        if (user == authUsers[i])
                        {
                            Session["Authenticated"] = "True";
                            break;
                        }
                    }
                    if (Session["Authenticated"] == null)
                    {
                        Session["Authenticated"] = "False";
                    }
                }
                else
                {
                    List<string> authUsers = (List<string>)(Session["AuthUsers"]);
                    for (int i = 0; i < authUsers.Count; i++)
                    {
                        if (user == authUsers[i])
                        {
                            Session["Authenticated"] = "True";
                            break;
                        }
                    }
                    if (Session["Authenticated"] == null)
                    {
                        Session["Authenticated"] = "False";
                    }
                }
                //uncomment the following line to disable authentication for development purposes
                //Session["Authenticated"] = "True";
            }
        }
    }
}
