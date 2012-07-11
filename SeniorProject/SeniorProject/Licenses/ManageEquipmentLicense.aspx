<%@ Page Title="RED - Manage Equipment License" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageEquipmentLicense.aspx.cs" Inherits="SeniorProject.Licenses.ManageEquipmentLicense" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Manage Lilcense</h1>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
            CellPadding="4" DataKeyNames="LicID" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Height="50px" Width="412px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="#999999" />
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <Fields>
                <asp:BoundField DataField="LicID" HeaderText="LicID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="LicID" Visible="False" />
                <asp:BoundField DataField="Software" HeaderText="Software" 
                    SortExpression="Software" />
                <asp:BoundField DataField="OS" HeaderText="OS" SortExpression="OS" />
                <asp:BoundField DataField="LicenseKey" HeaderText="LicenseKey" 
                    SortExpression="LicenseKey" />
                <asp:BoundField DataField="NumOfCopies" HeaderText="NumOfCopies" 
                    SortExpression="NumOfCopies" />
                <asp:BoundField DataField="ExpirationDate" HeaderText="ExpirationDate" 
                    SortExpression="ExpirationDate" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" 
                    Visible="False" />
            </Fields>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
            SelectCommand="SELECT * FROM [Licenses] WHERE ([LicID] = @LicID)">
            <SelectParameters>
                <asp:SessionParameter Name="LicID" SessionField="CurrentLicense" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <h1>
        Equipment with this License</h1>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="InvID" DataSourceID="SqlDataSource2" 
            ForeColor="#333333" GridLines="None" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" Width="1235px" 
            onrowcreated="GridView1_RowCreated" AllowSorting="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="InvID" HeaderText="InvID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="InvID" Visible="False" />
                <asp:BoundField DataField="SerialNo" HeaderText="SerialNo" 
                    SortExpression="SerialNo" />
                <asp:BoundField DataField="EquipmentType" HeaderText="EquipmentType" 
                    SortExpression="EquipmentType" />
                <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" 
                    SortExpression="Manufacturer" />
                <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Building" HeaderText="Building" 
                    SortExpression="Building" />
                <asp:BoundField DataField="Room" HeaderText="Room" SortExpression="Room" />
                <asp:BoundField DataField="PrimaryUser" HeaderText="PrimaryUser" 
                    SortExpression="PrimaryUser" />
                <asp:BoundField DataField="Status" HeaderText="Status" 
                    SortExpression="Status" />
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
            
            SelectCommand="SELECT Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Inventory.Status, Logistics.Room, Logistics.Building, Inventory.InvID, Logistics.PrimaryUser, Logistics.Name, Equipment.EquipmentType FROM Inventory INNER JOIN LicenseInventory ON Inventory.InvID = LicenseInventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID WHERE (Logistics.Status = 'Active') AND (LicenseInventory.LicID = @LicID)">
            <SelectParameters>
                <asp:SessionParameter Name="LicID" SessionField="CurrentLicense" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <br />
</asp:Content>
