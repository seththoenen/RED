using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SeniorProjectClassLibrary.Classes;

namespace SeniorProject.Tracker
{
    public partial class Tracker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnSubmitIssue_Click(object sender, EventArgs e)
        {
            //Create a new Issue object and assign necessary values
            Issue issue = new Issue();
            issue.SubmittedBy = ddlNewName.SelectedItem.Text;
            issue.Title = txtBoxNewTitle.Text;
            issue.Type = ddlNewType.SelectedItem.Text;
            issue.Description = txtBoxNewDescription.Text;
            issue.DateCreated = DateTime.Now;
            issue.Status = "Pending Review";

            //save issue
            string message = Issue.saveIssue(issue);
            if (message == "Issue created successfully")
            {
                gvCurretIssues.DataBind();
                ddlNewName.Text = "Please Select";
                txtBoxNewTitle.Text = "";
                ddlNewType.Text = "Please Select";
                txtBoxNewDescription.Text = "";
                panelSubmitNew.Visible = false;
                btnCreateNewIssue.Visible = true;
            }
            else
            {
                lblSaveIssueMessage.Text = message;
                lblSaveIssueMessage.Visible = true;
            }          
        }

        protected void gvCurretIssues_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //hide header cells that are for authenticated users
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (Session["Authenticated"].ToString() != "True")
                {
                    TableCell cell = e.Row.Cells[8];
                    cell.Visible = false;
                }
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
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
                //hide cells that are for authenticated users
                if (Session["Authenticated"].ToString() != "True")
                {
                    e.Row.Cells[8].Visible = false;
                }
            }
        }

        protected void gvPastIssues_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //hide header cells that are for authenticated users
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (Session["Authenticated"].ToString() != "True")
                {
                    TableCell cell = e.Row.Cells[9];
                    cell.Visible = false;
                }
            }
            //handles on hover events
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor = '#B0B0B0';");
                if (e.Row.RowState == DataControlRowState.Normal)
                {
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = '#F7F6F3';");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = 'White';");
                }
                //hide cells that are for authenticated users
                if (Session["Authenticated"].ToString() != "True")
                {
                    e.Row.Cells[9].Visible = false;
                }
            }            
        }

        protected void btnCreateNewIssue_Click(object sender, EventArgs e)
        {
            btnCreateNewIssue.Visible = false;
            panelSubmitNew.Visible = true;
        }

        protected void btnCancelSubmitNew_Click(object sender, EventArgs e)
        {
            btnCreateNewIssue.Visible = true;
            panelSubmitNew.Visible = false;
        }

        protected void lnkBtnSelect_Click(object sender, EventArgs e)
        {    
            //clear out any old data in modal popup
            txtBoxTitle.Text = "";
            txtBoxDateCreated.Text = "";
            txtBoxDateClosed.Text = "";
            txtBoxDescription.Text = "";
            txtBoxReply.Text = "";

            //get primary key from datagrid to get issue from DB
            LinkButton lnkButton = (LinkButton)sender;
            gvCurretIssues.SelectedIndex = Convert.ToInt32(lnkButton.CommandArgument);
            int issueID = Convert.ToInt32(gvCurretIssues.SelectedDataKey.Value);
            Issue issue = new Issue();
            issue = Issue.getIssue(issueID);

            //populate modial popup
            txtBoxTitle.Text = issue.Title;
            ddlType.Text = issue.Type;
            ddlSubmittedBy.Text = issue.SubmittedBy;
            ddlStatus.Text = issue.Status;
            txtBoxDateCreated.Text = issue.DateCreated.ToShortDateString();
            if (issue.DateClosed != null)
            { 
                txtBoxDateClosed.Text = Convert.ToDateTime(issue.DateClosed).ToShortDateString();
            }
            txtBoxDescription.Text = issue.Description;
            txtBoxReply.Text = issue.Reply;

            hfID.Value = issueID.ToString();

            btnPopUp_ModalPopUpExtender.Show();
        }

        protected void btnUpdateIssue_Click(object sender, EventArgs e)
        {
            //get values from popup
            Issue issue = new Issue();
            issue.Title = txtBoxTitle.Text;
            issue.Type = ddlType.Text;
            issue.SubmittedBy = ddlSubmittedBy.Text;
            issue.Status = ddlStatus.Text;
            issue.DateCreated = Convert.ToDateTime(txtBoxDateCreated.Text);
            if (txtBoxDateClosed.Text == "")
            {
                issue.DateClosed = null;
            }
            else
            {
                issue.DateClosed = Convert.ToDateTime(txtBoxDateClosed.Text);
            }
            issue.Description = txtBoxDescription.Text;
            issue.Reply = txtBoxReply.Text;

            issue.ID = Convert.ToInt32(hfID.Value);

            //update issue
            Issue.updateIssue(issue);

            //refresh both gridviews
            gvCurretIssues.DataBind();
            gvPastIssues.DataBind();

            //clear out any old data in modal popup
            txtBoxTitle.Text = "";
            txtBoxDateCreated.Text = "";
            txtBoxDateClosed.Text = "";
            txtBoxDescription.Text = "";
            txtBoxReply.Text = "";
        }

        protected void lnkBtnSelect_Click1(object sender, EventArgs e)
        {
            //clear out any old data in modal popup
            txtBoxTitle.Text = "";
            txtBoxDateCreated.Text = "";
            txtBoxDateClosed.Text = "";
            txtBoxDescription.Text = "";
            txtBoxReply.Text = "";

            //get primary key from datagrid to get issue from DB
            LinkButton lnkButton = (LinkButton)sender;
            gvPastIssues.SelectedIndex = Convert.ToInt32(lnkButton.CommandArgument);
            int issueID = Convert.ToInt32(gvPastIssues.SelectedDataKey.Value);
            Issue issue = new Issue();
            issue = Issue.getIssue(issueID);

            //populate modial popup
            txtBoxTitle.Text = issue.Title;
            ddlType.Text = issue.Type;
            ddlSubmittedBy.Text = issue.SubmittedBy;
            ddlStatus.Text = issue.Status;
            txtBoxDateCreated.Text = issue.DateCreated.ToShortDateString();
            if (issue.DateClosed != null)
            {
                txtBoxDateClosed.Text = Convert.ToDateTime(issue.DateClosed).ToShortDateString();
            }
            txtBoxDescription.Text = issue.Description;
            txtBoxReply.Text = issue.Reply;

            hfID.Value = issueID.ToString();

            btnPopUp_ModalPopUpExtender.Show();
        }
    }
}