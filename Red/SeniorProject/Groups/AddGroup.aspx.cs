using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SeniorProject.Groups
{
    public partial class AddGroup : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddGroup_Click(object sender, EventArgs e)
        {
            Group group = new Group();
            group.Name = txtBoxName.Text;
            group.Notes = txtBoxNotes.Text;
            group.Type = ddlType.Text;

            lblMessage.Text = GroupDA.saveGroup(group);
            lblMessage.Visible = true;
        }
    }
}