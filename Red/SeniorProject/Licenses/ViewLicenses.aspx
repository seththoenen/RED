<%@ Page Title="RED - Manage Licenses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewLicenses.aspx.cs" Inherits="SeniorProject.Licenses.ViewLicenses" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 150px;
            height: 29px;
        }
        .style4
        {
            height: 29px;
        }
        .style2
        {
            width: 150px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Licenses</h1>
<asp:UpdatePanel ID="updatePanelNewLicense" runat="server">
    <ContentTemplate>
        <asp:Button ID="btnCreateLicense" runat="server" 
            onclick="btnCreateLicense_Click" Text="Create License" Width="136px" />
<br />
        <asp:Panel ID="panelCreateLicense" runat="server" Visible="False">
            <table class="style1">
                <tr>
                    <td class="style3">
                        Software:</td>
                    <td class="style4">
                        <asp:TextBox ID="txtBoxSoftware" runat="server" MaxLength="45" 
                            style="margin-left: 0px" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtBoxSoftware" ErrorMessage="Software is required" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Operating System:</td>
                    <td>
                        <asp:TextBox ID="txtBoxOperatingSystem" runat="server" MaxLength="45" 
                            Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtBoxOperatingSystem" 
                            ErrorMessage="Operating System is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        Key:</td>
                    <td class="style4">
                        <asp:TextBox ID="txtBoxKey" runat="server" MaxLength="45" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtBoxKey" ErrorMessage="Key is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        Number of Copies:</td>
                    <td class="style4">
                        <asp:TextBox ID="txtBoxNumOfCopies" runat="server" MaxLength="45" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtBoxNumOfCopies" 
                            ErrorMessage="Number of Copies is required" ForeColor="Red"></asp:RequiredFieldValidator>
                        &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" 
                            ControlToValidate="txtBoxNumOfCopies" 
                            ErrorMessage="Number of Copies must be a positive integer" ForeColor="Red" 
                            MaximumValue="99999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Expiration Date:</td>
                    <td>
                        <asp:TextBox ID="txtBoxExpirationDate" runat="server" MaxLength="45" 
                            Width="200px"></asp:TextBox>
                        <asp:CalendarExtender ID="txtBoxExpirationDate_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txtBoxExpirationDate">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Type:</td>
                    <td>
                        <asp:DropDownList ID="ddlType" runat="server" Height="20px" Width="149px">
                            <asp:ListItem>Computer</asp:ListItem>
                            <asp:ListItem>Equipment</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Notes:</td>
                    <td>
                        <asp:TextBox ID="txtBoxNotes" runat="server" Height="100px" MaxLength="1000" 
                            TextMode="MultiLine" Width="300px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnAddLicense" runat="server" onclick="btnAddLicense_Click" 
                Text="Add License" Width="136px" />
            &nbsp;<asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                onclick="btnCancel_Click" Text="Cancel" Width="136px" />
        </asp:Panel>
        <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="updatePanelGridViews" runat="server">
    <ContentTemplate>
        <h3>
            Computer Licenses</h3>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="LicID" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" onrowcreated="GridView1_RowCreated" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" Width="1234px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="LicID" HeaderText="LicID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="LicID" Visible="False" />
                <asp:BoundField DataField="Software" HeaderText="Software" 
                    SortExpression="Software" />
                <asp:BoundField DataField="OS" HeaderText="OS" SortExpression="OS" />
                <asp:BoundField DataField="LicenseKey" HeaderText="License Key" 
                    SortExpression="LicenseKey" />
                <asp:BoundField DataField="ExpirationDate" HeaderText="Expiration Date" 
                    SortExpression="ExpirationDate" />
                <asp:BoundField DataField="NumOfCopies" HeaderText="Number of Copies" 
                    SortExpression="NumOfCopies" />
                <asp:BoundField DataField="InstalledCount" HeaderText="Instances Installed" 
                    ReadOnly="True" SortExpression="InstalledCount" />
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
            
            
            SelectCommand="SELECT Licenses.LicID, Licenses.Software, Licenses.OS, Licenses.LicenseKey, Licenses.NumOfCopies, Licenses.ExpirationDate, COUNT(LicenseInventory.InvID) AS InstalledCount FROM Licenses LEFT OUTER JOIN LicenseInventory ON Licenses.LicID = LicenseInventory.LicID WHERE (Licenses.Type = 'Computer') GROUP BY Licenses.LicID, Licenses.Software, Licenses.OS, Licenses.LicenseKey, Licenses.NumOfCopies, Licenses.ExpirationDate ORDER BY Licenses.Software">
        </asp:SqlDataSource>
        <h3>
            Equipment Licenses</h3>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="LicID" DataSourceID="SqlDataSource2" 
            ForeColor="#333333" GridLines="None" onrowcreated="GridView2_RowCreated" 
            onselectedindexchanged="GridView2_SelectedIndexChanged" Width="1235px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="LicID" HeaderText="LicID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="LicID" Visible="False" />
                <asp:BoundField DataField="Software" HeaderText="Software" 
                    SortExpression="Software" />
                <asp:BoundField DataField="OS" HeaderText="OS" SortExpression="OS" />
                <asp:BoundField DataField="LicenseKey" HeaderText="LicenseKey" 
                    SortExpression="LicenseKey" />
                <asp:BoundField DataField="ExpirationDate" HeaderText="Expiration Date" 
                    SortExpression="ExpirationDate" />
                <asp:BoundField DataField="NumOfCopies" HeaderText="Number of Copies" 
                    SortExpression="NumOfCopies" />
                <asp:BoundField DataField="InstalledCount" HeaderText="Instances Installed" 
                    SortExpression="InstalledCount" ReadOnly="True" />
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
            
            
            SelectCommand="SELECT Licenses.LicID, Licenses.Software, Licenses.OS, Licenses.LicenseKey, Licenses.NumOfCopies, Licenses.ExpirationDate, COUNT(LicenseInventory.InvID) AS InstalledCount FROM Licenses LEFT OUTER JOIN LicenseInventory ON Licenses.LicID = LicenseInventory.LicID WHERE (Licenses.Type = 'Equipment') GROUP BY Licenses.LicID, Licenses.Software, Licenses.OS, Licenses.LicenseKey, Licenses.NumOfCopies, Licenses.ExpirationDate ORDER BY Licenses.Software">
        </asp:SqlDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
