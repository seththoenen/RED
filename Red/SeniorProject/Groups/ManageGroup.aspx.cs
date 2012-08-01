using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Collections;

namespace SeniorProject.Groups
{
    public partial class ManageGroup : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;

        string serialNoArg = "";
        string typeArg = "";
        string formFactorArg = "";
        string manufacturerArg = "";
        string modelArg = "";
        string nameArg = "";
        string buildingArg = "";
        string roomArg = "";
        string primaryUserArg = "";
        string statusArg = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CurrentGroup"] == null)
                {
                    Response.Redirect("~Groups/ManageGroups.aspx");
                }
                int groupID;
                groupID = Convert.ToInt16(Session["CurrentGroup"]);

                Group group = new Group();
                group = GroupDA.getGroup(groupID);
                txtBoxName.Text = group.Name;
                txtBoxNotes.Text = group.Notes;

                populateDDLs();
            }
            else
            {
                handleGridView();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string compID;
            compID = GridView2.SelectedDataKey.Value.ToString();
            Session["CurrentComputer"] = compID;
            Response.Redirect("~/Computer/ViewComputer.aspx");
        }

        protected void btnUpdateGroup_Click(object sender, EventArgs e)
        {
            Group group = new Group();
            group.Name = txtBoxName.Text;
            group.Notes = txtBoxNotes.Text;

            lblMessage.Visible = true;
            lblMessage.Text = GroupDA.updateGroup(group, Convert.ToInt32(Session["CurrentGroup"]));

            if (lblMessage.Text == "Group updated successfully<bR>")
            {
                Panel1.Visible = false;
                DetailsView1.Visible = true;
                btnEditGroup.Visible = true;
                btnUpdateGroup.Visible = false;
                DetailsView1.DataBind();
            }
        }

        protected void btnEditGroup_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            DetailsView1.Visible = false;
            btnEditGroup.Visible = false;
            btnUpdateGroup.Visible = true;

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
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

        protected void txtBoxSerialNo_TextChanged(object sender, EventArgs e)
        {
            bool existLB = false;
            bool existDB = false;
            bool isTransferred = false;
            bool isInGroup = false;

            isInGroup = GroupDA.invInGroup(txtBoxSerialNo.Text, Convert.ToInt32(Session["CurrentGroup"]));

            for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
            {
                if (lstBoxSerialNos.Items[i].Text == txtBoxSerialNo.Text.ToUpper())
                {
                    existLB = true;
                }
            }
            if (ComputerDA.computerExist(txtBoxSerialNo.Text) == true)
            {
                existDB = true;
                if(ComputerDA.computerTransferred(txtBoxSerialNo.Text) == true)
                {
                    isTransferred = true;
                }
            }
            if (existLB == false && existDB == true && isTransferred == false && isInGroup == false)
            {
                lstBoxSerialNos.Items.Add(txtBoxSerialNo.Text.ToUpper());
                lstBoxSerialNos.Text = txtBoxSerialNo.Text.ToUpper();
            }
            else if (existLB == true)
            {
                lblSerialNos.Visible = true;
                lblSerialNos.Text += txtBoxSerialNo.Text + " is already in queue<bR />";
            }
            else if (existDB == false)
            {
                lblSerialNos.Visible = true;
                lblSerialNos.Text += txtBoxSerialNo.Text + " is not in the database<br />";
            }
            else if (isTransferred == true)
            {
                lblSerialNos.Visible = true;
                lblSerialNos.Text += txtBoxSerialNo.Text + " is transferred<br />";
            }

            else if (isInGroup == true)
            {
                lblSerialNos.Visible = true;
                lblSerialNos.Text += txtBoxSerialNo.Text + " is already in this group<br />";
            }
            txtBoxSerialNo.Text = "";
            txtBoxSerialNo.Focus();
        }

        protected void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            foreach (int i in lstBoxSerialNos.GetSelectedIndices())
            {
                lstBoxSerialNos.Items.RemoveAt(lstBoxSerialNos.SelectedIndex);
            }
        }

        protected void btnAddComputers_Click(object sender, EventArgs e)
        {
            if (btnAddComputers.Text == "Add to Group")
            {
                panelComputers.Visible = false;
                panelAddComputers.Visible = true;
                btnCalcelAddComputers.Visible = true;
                btnAddComputers.Text = "Add Selected";
            }
            else if (btnAddComputers.Text == "Add Selected")
            {
                ArrayList serialNos = new ArrayList();
                for (int i=0; i<lstBoxSerialNos.Items.Count; i++)
                {
                    serialNos.Add(lstBoxSerialNos.Items[i].Text);
                }
                lblMessage.Visible = true;
                lblMessage.Text = GroupDA.addInvToGroup(serialNos, Convert.ToInt32(Session["CurrentGroup"]));
                if (lblMessage.Text == "Inventory added successfully!<bR>")
                {
                    panelComputers.Visible = true;
                    panelAddComputers.Visible = false;
                    btnCalcelAddComputers.Visible = false;
                    btnAddComputers.Text = "Add to Group";
                    GridView2.DataBind();
                    lstBoxSerialNos.Items.Clear();
                }
            }
        }

        protected void GridViewComputers_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //registers click event to entire grid view row
                e.Row.Attributes["OnClick"] = ClientScript.GetPostBackEventReference(this.GridViewComputers, "Select$" + e.Row.RowIndex);

                //handles on hover events
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor = '#B0B0B0';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = this.originalstyle;");
            }
        }

        protected void GridViewComputers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string serialNo = GridViewComputers.SelectedDataKey["SerialNo"].ToString();

            bool existLB = false;
            for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
            {
                if (lstBoxSerialNos.Items[i].Text == serialNo || lstBoxSerialNos.Items[i].Text == serialNo.ToUpper())
                {
                    existLB = true;
                }
            }
            if (existLB == false)
            {
                lstBoxSerialNos.Items.Add(serialNo.ToUpper());
                lstBoxSerialNos.Text = serialNo.ToUpper();
            }
        }

        protected void btnCalcelAddComputers_Click(object sender, EventArgs e)
        {
            panelComputers.Visible = true;
            panelAddComputers.Visible = false;
            btnCalcelAddComputers.Visible = false;
            btnAddComputers.Text = "Add to Group";
        }

        protected void handleGridView()
        {
            SqlDataSourceComputers.SelectParameters.Clear();
            SqlDataSourceComputers.SelectParameters.Add("GroupID", Session["CurrentGroup"].ToString());
            lblMessage.Visible = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Inventory.InvID, Inventory.SerialNo,  Inventory.Manufacturer, Logistics.Building, Logistics.Room, Logistics.PrimaryUser,"+
                "Logistics.Name, Inventory.Model, Inventory.Status, Computer.FormFactor, Computer.Type FROM Computer INNER JOIN Inventory ON Computer.InvID = "+
                "Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status <> "+
                "'Transferred') AND (Inventory.InvID NOT IN (SELECT Inventory_1.InvID FROM Inventory AS Inventory_1 INNER JOIN GroupInventory ON Inventory_1.InvID "+
                "= GroupInventory.InvID WHERE (GroupInventory.GroupID = @GroupID)))");

            populateArgs();

            if (serialNoArg != "")
            {
                sql.Append(" AND SerialNo LIKE '%'+@SerialNo+'%'");
                SqlDataSourceComputers.SelectParameters.Add("SerialNo", serialNoArg);
            }

            if (typeArg != "")
            {
                sql.Append(" AND Type LIKE '%'+@Type+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Type", typeArg);
            }

            if (formFactorArg != "")
            {
                sql.Append(" AND FormFactor LIKE '%'+@FormFactor+'%'");
                SqlDataSourceComputers.SelectParameters.Add("FormFactor", formFactorArg);
            }

            if (manufacturerArg != "")
            {
                sql.Append(" AND Manufacturer LIKE '%'+@Manufacturer+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Manufacturer", manufacturerArg);
            }

            if (modelArg != "")
            {
                sql.Append(" AND Model LIKE '%'+@Model+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Model", modelArg);
            }

            if (nameArg != "")
            {
                sql.Append(" AND Name LIKE '%'+@Name+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Name", nameArg);
            }

            if (buildingArg != "")
            {
                sql.Append(" AND Building LIKE '%'+@Building+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Building", buildingArg);
            }

            if (roomArg != "")
            {
                sql.Append(" AND Room LIKE '%'+@Room+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Room", roomArg);
            }

            if (primaryUserArg != "")
            {
                sql.Append(" AND PrimaryUser LIKE '%'+@PrimaryUser+'%'");
                SqlDataSourceComputers.SelectParameters.Add("PrimaryUser", primaryUserArg);
            }

            if (statusArg != "")
            {
                sql.Append(" AND Inventory.Status LIKE '%'+@Status+'%'");
                SqlDataSourceComputers.SelectParameters.Add("Status", statusArg);
            }

            string controlID = string.Empty;
            Control control = null;
            if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EventTarget"] != string.Empty)
            {
                controlID = Request.Form["__EVENTTARGET"];
                control = Page.FindControl(controlID);
                //lblControlId.Text = control.ID;

                switch (control.ID.ToString())
                {
                    case "SerialNoHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "SerialNo" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("SerialNo", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("SerialNo", SortDirection.Ascending);
                        }
                        break;
                    case "TypeHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "Type" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("Type", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("Type", SortDirection.Ascending);
                        }
                        break;
                    case "FormFactorHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "FormFactor" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("FormFactor", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("FormFactor", SortDirection.Ascending);
                        }
                        break;
                    case "ManufacturerHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "Manufacturer" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("Manufacturer", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("Manufacturer", SortDirection.Ascending);
                        }
                        break;
                    case "ModelHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "Model" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("Model", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("Model", SortDirection.Ascending);
                        }
                        break;
                    case "NameHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "Name" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("Name", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("Name", SortDirection.Ascending);
                        }
                        break;
                    case "BuildingHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "Building" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("Building", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("Building", SortDirection.Ascending);
                        }
                        break;
                    case "RoomHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "Room" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("Room", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("Room", SortDirection.Ascending);
                        }
                        break;
                    case "PrimaryUserHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "PrimaryUser" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("PrimaryUser", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("PrimaryUser", SortDirection.Ascending);
                        }
                        break;
                    case "StatusHeaderLinkButton":
                        if (GridViewComputers.SortExpression == "Status" && GridViewComputers.SortDirection == SortDirection.Ascending)
                        {
                            GridViewComputers.Sort("Status", SortDirection.Descending);
                        }
                        else
                        {
                            GridViewComputers.Sort("Status", SortDirection.Ascending);
                        }
                        break;
                }
            }

            sql.Append(" ORDER BY SerialNo ASC");

            SqlDataSourceComputers.SelectCommand = sql.ToString();

            GridViewComputers.DataBind();
            //lblSQL.Text = sql.ToString();

            populateDDLs();
            printArgs();
        }

        protected void populateArgs()
        {
            serialNoArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxSerialNoFilter")).Text;
            typeArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlTypeFilter")).Text;
            formFactorArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlFormFactorFilter")).Text;
            manufacturerArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlManufacturerFilter")).Text;
            modelArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxModelFilter")).Text;
            nameArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxNameFilter")).Text;
            buildingArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlBuildingFilter")).Text;
            roomArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxRoomFilter")).Text;
            //primaryUserArg = ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxPrimaryUserFilter")).Text;
            statusArg = ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).Text;
        }

        protected void printArgs()
        {
            ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxSerialNoFilter")).Text = serialNoArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlTypeFilter")).Text = typeArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlFormFactorFilter")).Text = formFactorArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlManufacturerFilter")).Text = manufacturerArg;
            ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxModelFilter")).Text = modelArg;
            ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxNameFilter")).Text = nameArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlBuildingFilter")).Text = buildingArg;
            ((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxRoomFilter")).Text = roomArg;
            //((TextBox)GridViewComputers.HeaderRow.FindControl("txtBoxPrimaryUserFilter")).Text = primaryUserArg;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).Text = statusArg;
        }

        protected void populateDDLs()
        {
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlTypeFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlTypeFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlFormFactorFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlFormFactorFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlManufacturerFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlManufacturerFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlBuildingFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlBuildingFilter")).SelectedIndex = 0;
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).Items.Insert(0, "");
            ((DropDownList)GridViewComputers.HeaderRow.FindControl("ddlStatusFilter")).SelectedIndex = 0;
        }

        protected void btnToggle_Click(object sender, EventArgs e)
        {
            if (btnToggle.Text == "Add With Text Box")
            {
                panelGridView.Visible = false;
                panelTextBox.Visible = true;
                btnToggle.Text = "Add With GridView";
            }
            else if (btnToggle.Text == "Add With GridView")
            {
                panelGridView.Visible = true;
                panelTextBox.Visible = false;
                btnToggle.Text = "Add With Text Box";
            }
        }

        protected void btnAddWithTextBox_Click(object sender, EventArgs e)
        {
            string[] serialNos = txtBoxSerialNos.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string serialNo in serialNos)
            {
                bool existLB = false;
                bool existDB = false;
                bool isTooLong = false;
                bool isBlank = false;
                bool isInGroup = false;

                if (GroupDA.invInGroup(serialNo, Convert.ToInt32(Session["CurrentGroup"])) == true)
                {
                    isInGroup = true;
                }

                for (int i = 0; i < lstBoxSerialNos.Items.Count; i++)
                {
                    if (lstBoxSerialNos.Items[i].Text == serialNo.ToUpper())
                    {
                        existLB = true;
                    }
                }
                if (ComputerDA.computerExist(serialNo) == true)
                {
                    existDB = true;
                }
                if (serialNo.Length > 45)
                {
                    isTooLong = true;
                }
                if (serialNo == "")
                {
                    isBlank = true;
                }
                if (existLB == false && existDB == true && isTooLong == false && isBlank == false && isInGroup == false)
                {
                    lstBoxSerialNos.Items.Add(serialNo.ToUpper());
                    lstBoxSerialNos.Text = serialNo.ToUpper();
                }
                else if (existLB == true)
                {
                    lblAddTextBoxMessage.Text += serialNo + " is already in queue<bR />";
                }
                else if (isBlank == true)
                {
                    lblAddTextBoxMessage.Text += "A blank entry was found and was ignored, you should be more careful in the future<br />";
                }
                else if (existDB == false)
                {
                    lblAddTextBoxMessage.Text += serialNo + " is not in the database<br />";
                }
                else if (isTooLong == true)
                {
                    lblAddTextBoxMessage.Text += serialNo + " is too long<br />";
                }
                else if (isInGroup == true)
                {
                    lblAddTextBoxMessage.Text += serialNo + " is already in this group<br />";
                }
            }
        }
    }
}