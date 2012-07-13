<%@ Page Title="RED - Manage Groups" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageGroups.aspx.cs" Inherits="SeniorProject.Groups.ManageGroups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 150px;
        }
    .style3
    {
        width: 150px;
        height: 26px;
    }
    .style4
    {
        height: 26px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
    Manage Groups</h1>
    <asp:UpdatePanel ID="updatePanelAddGroup" runat="server">
        <ContentTemplate>
            <asp:Button ID="btnAddNewGroup" runat="server" onclick="btnAddNewGroup_Click" 
                Text="Create Group" Width="136px" />
            <asp:Panel ID="panelAddGroup" runat="server" Visible="False">
                <table class="style1">
                    <tr>
                        <td class="style2">
                            Name:</td>
                        <td>
                            <asp:TextBox ID="txtBoxName" runat="server" MaxLength="45" Width="301px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtBoxName" ErrorMessage="Name is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            Group Type:</td>
                        <td class="style4">
                            <asp:DropDownList ID="ddlType" runat="server" Height="20px" Width="150px">
                                <asp:ListItem>Computer</asp:ListItem>
                                <asp:ListItem Value="Equipment"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Notes:</td>
                        <td>
                            <asp:TextBox ID="txtBoxNotes" runat="server" Height="86px" MaxLength="1000" 
                                TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnAddGroup" runat="server" onclick="btnAddGroup_Click" 
                    Text="Add Group" Width="136px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                    Text="Cancel" CausesValidation="False" Width="136px" />
                <br />
            </asp:Panel>
            <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="updatePanelGridViews" runat="server">
        <ContentTemplate>
            <h3>
                Computer Groups</h3>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="GroupId" DataSourceID="SqlDataSource1" 
                ForeColor="#333333" GridLines="None" onrowcreated="GridView1_RowCreated" 
                onselectedindexchanged="GridView1_SelectedIndexChanged" Width="1235px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="GroupId" HeaderText="GroupId" InsertVisible="False" 
                        ReadOnly="True" SortExpression="GroupId" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" >
                    <ItemStyle Width="25%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Count" HeaderText="Computer Count" 
                        SortExpression="Count" ReadOnly="True" >
                    <ItemStyle Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" >
                    <ItemStyle Width="60%" />
                    </asp:BoundField>
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                
                
                SelectCommand="SELECT Groups.GroupId, Groups.Name, Groups.Notes, COUNT(GroupInventory.InvID) AS Count FROM Groups LEFT OUTER JOIN GroupInventory ON Groups.GroupId = GroupInventory.GroupID WHERE (Groups.Type = 'Computer') GROUP BY Groups.GroupId, Groups.Name, Groups.Notes">
            </asp:SqlDataSource>
            <h3>
                Equipment Groups</h3>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="GroupId" DataSourceID="SqlDataSource2" 
                ForeColor="#333333" GridLines="None" onrowcreated="GridView2_RowCreated" 
                onselectedindexchanged="GridView2_SelectedIndexChanged" Width="1235px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="GroupId" HeaderText="GroupId" InsertVisible="False" 
                        ReadOnly="True" SortExpression="GroupId" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" >
                    <ItemStyle Width="25%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Count" HeaderText="Equipment Count" 
                        SortExpression="Count" ReadOnly="True" >
                    <ItemStyle Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes">
                    <ItemStyle Width="60%" />
                    </asp:BoundField>
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
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                
                
                SelectCommand="SELECT Groups.GroupId, Groups.Name, Groups.Notes, COUNT(GroupInventory.InvID) AS Count FROM Groups LEFT OUTER JOIN GroupInventory ON Groups.GroupId = GroupInventory.GroupID WHERE (Groups.Type = 'Equipment') GROUP BY Groups.GroupId, Groups.Name, Groups.Notes">
            </asp:SqlDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
    <h3>
        &nbsp;</h3>
<p>
    &nbsp;</p>
<h3>
    &nbsp;</h3>
<p>
    &nbsp;</p>
</asp:Content>
