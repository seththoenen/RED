<%@ Page Title="RED - Issues" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tracker.aspx.cs" Inherits="SeniorProject.Tracker.Tracker" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<link rel="Stylesheet" href="../Styles/PopUp.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updatePanelSubmitNew" runat="server">
    <ContentTemplate>
        <asp:Button ID="btnCreateNewIssue" runat="server" Text="Create New Issue" 
            onclick="btnCreateNewIssue_Click" Width="136px" />
        &nbsp;<asp:Panel ID="panelSubmitNew" runat="server" Visible="False">
            <h2>
                New Issue</h2>
            <table class="style1">
                <tr>
                    <td>
                        Your Name:</td>
                    <td>
                        <asp:DropDownList ID="ddlNewName" runat="server">
                            <asp:ListItem>Please Select</asp:ListItem>
                            <asp:ListItem>Little T</asp:ListItem>
                            <asp:ListItem>Jerry</asp:ListItem>
                            <asp:ListItem>Clyde</asp:ListItem>
                        </asp:DropDownList>
                        <asp:CompareValidator ID="cvName" runat="server" ControlToValidate="ddlNewName" 
                            ErrorMessage="*" ForeColor="Red" Operator="NotEqual" 
                            ValueToCompare="Please Select"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Title:</td>
                    <td>
                        <asp:TextBox ID="txtBoxNewTitle" runat="server" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" 
                            ControlToValidate="txtBoxNewTitle" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Type:</td>
                    <td>
                        <asp:DropDownList ID="ddlNewType" runat="server">
                            <asp:ListItem>Please Select</asp:ListItem>
                            <asp:ListItem>Bug</asp:ListItem>
                            <asp:ListItem>Feature Request</asp:ListItem>
                            <asp:ListItem>Error</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                        <asp:CompareValidator ID="cvType" runat="server" ControlToValidate="ddlNewType" 
                            ErrorMessage="*" ForeColor="Red" Operator="NotEqual" 
                            ValueToCompare="Please Select"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:</td>
                    <td>
                        <asp:TextBox ID="txtBoxNewDescription" runat="server" Height="100px" 
                            TextMode="MultiLine" Width="300px" MaxLength="999"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnSubmitIssue" runat="server" Text="Submit Issue" 
                Width="136px" onclick="btnSubmitIssue_Click" />
            &nbsp;<asp:Button ID="btnCancelSubmitNew" runat="server" CausesValidation="False" 
                onclick="btnCancelSubmitNew_Click" Text="Cancel" Width="136px" />
            <br />
            <asp:Label ID="lblSaveIssueMessage" runat="server" Visible="False"></asp:Label>
            <br />
        </asp:Panel>
        <asp:Panel ID="panelIssues" runat="server">
            <h2>
                Current Issues
            </h2>
            <asp:GridView ID="gvCurretIssues" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="id" DataSourceID="sqldsCurrentIssues" 
                ForeColor="#333333" GridLines="None" onrowcreated="gvCurretIssues_RowCreated" 
                Width="1230px" AllowSorting="True">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                        ReadOnly="True" SortExpression="id" Visible="False" />
                    <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" />
                    <asp:BoundField DataField="type" HeaderText="Type" SortExpression="type" />
                    <asp:BoundField DataField="submittedby" HeaderText="Submitted By" 
                        SortExpression="submittedby" />
                    <asp:BoundField DataField="status" HeaderText="Status" 
                        SortExpression="status" />
                    <asp:BoundField DataField="datecreated" HeaderText="Date Created" 
                        SortExpression="datecreated" DataFormatString="{0:d}" />
                    <asp:TemplateField></asp:TemplateField>
                    <asp:BoundField DataField="description" HeaderText="Description" 
                        SortExpression="description" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkBtnSelect" runat="server" SkinID="Blue" 
                                CommandName="Select" CommandArgument='<%# Container.DataItemIndex %>' 
                                onclick="lnkBtnSelect_Click">Select</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="sqldsCurrentIssues" runat="server" 
                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                
                SelectCommand="SELECT [id], [datecreated], [description], [status], [submittedby], [type], [title] FROM [Issues] WHERE [status] = 'Pending Review' OR [status] = 'Accepted'">
            </asp:SqlDataSource>
            <h2>
                Past Issues</h2>
            <p>
                <asp:GridView ID="gvPastIssues" runat="server" AllowSorting="True" 
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" 
                    DataSourceID="sqldsPastIssues" ForeColor="#333333" GridLines="None" 
                    onrowcreated="gvPastIssues_RowCreated" Width="1219px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                            ReadOnly="True" SortExpression="id" Visible="False" />
                        <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" />
                        <asp:BoundField DataField="type" HeaderText="Type" SortExpression="type" />
                        <asp:BoundField DataField="submittedby" HeaderText="Submitted By" 
                            SortExpression="submittedby" />
                        <asp:BoundField DataField="status" HeaderText="Status" 
                            SortExpression="status" />
                        <asp:BoundField DataField="datecreated" DataFormatString="{0:d}" 
                            HeaderText="Date Created" SortExpression="datecreated" />
                        <asp:BoundField DataField="dateclosed" DataFormatString="{0:d}" 
                            HeaderText="Date Closed" SortExpression="dateclosed" />
                        <asp:BoundField DataField="description" HeaderText="Description" 
                            SortExpression="description" />
                        <asp:BoundField DataField="reply" HeaderText="Reply" SortExpression="reply" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkBtnSelect" runat="server" CommandName="Select" 
                                CommandArgument='<%# Container.DataItemIndex %>' onclick="lnkBtnSelect_Click1" 
                                    SkinID="Blue" >Select</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <asp:SqlDataSource ID="sqldsPastIssues" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                    SelectCommand="SELECT [status], [dateclosed], [type], [reply], [title], [description], [submittedby], [datecreated], [id] FROM [Issues] WHERE [status] = 'finished' OR [status] = 'denied'">
                </asp:SqlDataSource>
            </p>
            <p>
                <asp:Button ID="btnPopUp" runat="server" Text="Button" />
                <asp:ModalPopupExtender ID="btnPopUp_ModalPopUpExtender" runat="server" 
                    DynamicServicePath="" Enabled="True" TargetControlID="btnPopUp" PopupControlID="panelEditIssue" BackgroundCssClass="PopUpBackground" 
                    CancelControlID="btnCancelUpdateIssue">
                </asp:ModalPopupExtender>
            </p>
            <asp:Panel ID="panelEditIssue" runat="server" CssClass="PopUp">
                <h2>Edit Issue</h2>
                <table class="style1">
                    <tr>
                        <td>
                            Title:</td>
                        <td>
                            <asp:TextBox ID="txtBoxTitle" runat="server" MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Type:</td>
                        <td>
                            <asp:DropDownList ID="ddlType" runat="server" Width="142px">
                                <asp:ListItem>Bug</asp:ListItem>
                                <asp:ListItem>Feature Request</asp:ListItem>
                                <asp:ListItem>Error</asp:ListItem>
                                <asp:ListItem>Other</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Submitted By:</td>
                        <td>
                            <asp:DropDownList ID="ddlSubmittedBy" runat="server" Width="142px">
                                <asp:ListItem>Little T</asp:ListItem>
                                <asp:ListItem>Jerry</asp:ListItem>
                                <asp:ListItem>Clyde</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Status:</td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="142px">
                                <asp:ListItem>Pending Review</asp:ListItem>
                                <asp:ListItem>Accepted</asp:ListItem>
                                <asp:ListItem>Denied</asp:ListItem>
                                <asp:ListItem>Finished</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Date Created:</td>
                        <td>
                            <asp:TextBox ID="txtBoxDateCreated" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="txtBoxDateCreated_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtBoxDateCreated">
                            </asp:CalendarExtender>
                            <asp:CompareValidator ID="cvDateCreated" runat="server" 
                                ControlToValidate="txtBoxDateCreated" ErrorMessage="*" ForeColor="Red" 
                                Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Date Closed</td>
                        <td>
                            <asp:TextBox ID="txtBoxDateClosed" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="txtBoxDateClosed_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtBoxDateClosed">
                            </asp:CalendarExtender>
                            <asp:CompareValidator ID="cvDateClosed" runat="server" 
                                ControlToValidate="txtBoxDateClosed" ErrorMessage="*" ForeColor="Red" 
                                Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Description:</td>
                        <td>
                            <asp:TextBox ID="txtBoxDescription" runat="server" Height="100px" TextMode="MultiLine" 
                                Width="300px" MaxLength="1000"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Reply:</td>
                        <td>
                            <asp:TextBox ID="txtBoxReply" runat="server" Height="100px" TextMode="MultiLine" 
                                Width="300px" MaxLength="1000"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnUpdateIssue" runat="server" Text="Update Issue" 
                    Width="136px" onclick="btnUpdateIssue_Click" />
                &nbsp;<asp:Button ID="btnCancelUpdateIssue" runat="server" Text="Cancel" 
                    Width="136px" CausesValidation="False" />
                &nbsp;<asp:HiddenField ID="hfID" runat="server" />
                <asp:HiddenField ID="hfGridView" runat="server" />
            </asp:Panel>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
