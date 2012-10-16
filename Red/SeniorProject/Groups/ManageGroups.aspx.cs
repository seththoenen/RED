using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProject.Groups
{
    public partial class ManageGroups : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string groupID;
            groupID = GridView1.SelectedDataKey.Value.ToString();
            Session["CurrentGroup"] = groupID;
            Response.Redirect("~/Groups/ManageGroup.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string groupID;
            groupID = GridView2.SelectedDataKey.Value.ToString();
            Session["CurrentGroup"] = groupID;
            Response.Redirect("~/Groups/ManageEquipmentGroup.aspx");
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

        protected void btnAddGroup_Click(object sender, EventArgs e)
        {
            Group group = new Group();
            group.Name = txtBoxName.Text;
            group.Notes = txtBoxNotes.Text;
            group.Type = ddlType.Text;

            lblMessage.Text = Group.saveGroup(group);
            lblMessage.Visible = true;

            if (lblMessage.Text == "Group created successfully<bR>")
            {
                GridView1.DataBind();
                GridView2.DataBind();
                panelAddGroup.Visible = false;
                btnAddNewGroup.Visible = true;
                txtBoxName.Text = "";
                txtBoxNotes.Text = "";
            }
        }

        protected void btnAddNewGroup_Click(object sender, EventArgs e)
        {
            panelAddGroup.Visible = true;
            btnAddNewGroup.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            panelAddGroup.Visible = false;
            btnAddNewGroup.Visible = true;

            txtBoxName.Text = "";
            txtBoxNotes.Text = "";
        }
    }
}