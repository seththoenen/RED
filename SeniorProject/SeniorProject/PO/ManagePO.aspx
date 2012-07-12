<%@ Page Title="RED - Manage Purchase Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagePO.aspx.cs" Inherits="SeniorProject.PO.ManagePO" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Purchase Order Details</h1>
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataSourceID="SqlDataSource2" Height="50px" Width="351px" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
        <EditRowStyle BackColor="#7C6F57" />
        <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="POno" HeaderText="POno" 
                SortExpression="POno" />
            <asp:BoundField DataField="DeliveryDate" HeaderText="DeliveryDate" 
                SortExpression="DeliveryDate" />
            <asp:BoundField DataField="RequisitionNo" HeaderText="RequisitionNo" 
                SortExpression="RequisitionNo" />
            <asp:BoundField DataField="PurchaseDate" HeaderText="PurchaseDate" 
                SortExpression="PurchaseDate" />
            <asp:BoundField DataField="Title" HeaderText="Title" 
                SortExpression="Title" />
        </Fields>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
        
        SelectCommand="SELECT [POno], [DeliveryDate], [RequisitionNo], [PurchaseDate], [Title] FROM [PO] WHERE ([POID] = @POID)">
        <SelectParameters>
            <asp:SessionParameter Name="POID" SessionField="CurrentPurchaseOrder" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Button ID="btnEditPurchaseOrder" runat="server" 
        Text="Edit Purchas Order" onclick="btnEditPurchaseOrder_Click" />
    <asp:Panel ID="panelEditPurchaseOrder" runat="server" Visible="False">
        <table class="style1">
            <tr>
                <td class="style2">
                    PO Number:</td>
                <td>
                    <asp:TextBox ID="txtBoxPONumber" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtBoxPONumber" ErrorMessage="PO Number is required." 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Title:</td>
                <td>
                    <asp:TextBox ID="txtBoxTitle" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Purchase Date:</td>
                <td>
                    <asp:TextBox ID="txtBoxPurchaseDate" runat="server" MaxLength="45" 
                        Width="136px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtBoxPurchaseDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtBoxPurchaseDate">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Delivery Date:</td>
                <td>
                    <asp:TextBox ID="txtBoxDeliveryDate" runat="server" MaxLength="45" 
                        Width="136px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtBoxDeliveryDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtBoxDeliveryDate">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Requisition Number:</td>
                <td>
                    <asp:TextBox ID="txtBoxRequisitionNumber" runat="server" MaxLength="45" 
                        Width="136px"></asp:TextBox>
                </td>
            </tr>
        </table>
            <asp:Button ID="btnUpdatePO" runat="server" Text="Update PO" 
            onclick="btnUpdatePO_Click" />
        <br />
        <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    <h1>
        Computers in this Purchase Order</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="InvID" DataSourceID="SqlDataSource1" 
        ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" Width="1235px" 
        onrowcreated="GridView1_RowCreated" AllowSorting="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="InvID" HeaderText="InvID" SortExpression="InvID" 
                InsertVisible="False" ReadOnly="True" Visible="False" />
            <asp:BoundField DataField="SerialNo" HeaderText="SerialNo" 
                SortExpression="SerialNo" />
            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
            <asp:BoundField DataField="FormFactor" HeaderText="FormFactor" 
                SortExpression="FormFactor" />
            <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" 
                SortExpression="Manufacturer" />
            <asp:BoundField DataField="Model" HeaderText="Model" 
                SortExpression="Model" />
            <asp:BoundField DataField="Name" HeaderText="Name" 
                SortExpression="Name" />
            <asp:BoundField DataField="Building" HeaderText="Building" 
                SortExpression="Building" />
            <asp:BoundField DataField="Room" HeaderText="Room" 
                SortExpression="Room" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
        
        
        
        SelectCommand="SELECT Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.InvID, Computer.FormFactor, Computer.Type, Inventory.Status FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN POInventory ON Inventory.InvID = POInventory.InvID INNER JOIN PO ON POInventory.POID = PO.POID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (PO.POID = @POID)">
        <SelectParameters>
            <asp:SessionParameter Name="POID" SessionField="CurrentPurchaseOrder" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
<h1>
    Equipment in this Purchase Order</h1>
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" DataKeyNames="InvID" DataSourceID="SqlDataSource3" 
    ForeColor="#333333" GridLines="None" Width="1235px" 
        onselectedindexchanged="GridView2_SelectedIndexChanged" 
        onrowcreated="GridView2_RowCreated">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="InvID" HeaderText="InvID" SortExpression="InvID" 
            InsertVisible="False" ReadOnly="True" />
        <asp:BoundField DataField="SerialNo" HeaderText="SerialNo" 
            SortExpression="SerialNo" />
        <asp:BoundField DataField="EquipmentType" HeaderText="EquipmentType" 
            SortExpression="EquipmentType" />
        <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" 
            SortExpression="Manufacturer" />
        <asp:BoundField DataField="Model" HeaderText="Model" 
            SortExpression="Model" />
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
<asp:SqlDataSource ID="SqlDataSource3" runat="server" 
    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
    
        SelectCommand="SELECT Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Equipment.EquipmentType, Inventory.InvID, Inventory.Status FROM Equipment INNER JOIN Inventory ON Equipment.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID INNER JOIN POInventory ON Inventory.InvID = POInventory.InvID WHERE (Logistics.Status = 'Active') AND (POInventory.POID = @POID)">
    <SelectParameters>
        <asp:SessionParameter Name="POID" SessionField="CurrentPurchaseOrder" />
    </SelectParameters>
</asp:SqlDataSource>
    <br />
</asp:Content>
