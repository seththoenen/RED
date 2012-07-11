<%@ Page Title="RED - View Transfer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTransfer.aspx.cs" Inherits="SeniorProject.Transfers.ViewTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Manage Transfer</h1>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
            CellPadding="4" DataKeyNames="TransID" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Height="50px" Width="300px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="#999999" />
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <Fields>
                <asp:BoundField DataField="Whereto" HeaderText="Transfer To" 
                    SortExpression="Whereto" />
                <asp:BoundField DataField="TransID" HeaderText="TransID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="TransID" Visible="False" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" 
                    SortExpression="Notes" />
            </Fields>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
            
            SelectCommand="SELECT TransID, Date, Whereto, Notes FROM Transfers WHERE (TransID = @TransID)">
            <SelectParameters>
                <asp:SessionParameter Name="TransID" SessionField="CurrentTransfer" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <h2>
        Computers in this Transfer</h2>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="InvID" DataSourceID="SqlDataSource2" 
            ForeColor="#333333" GridLines="None" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" Width="1234px" 
            onrowcreated="GridView1_RowCreated">
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
            
            
            SelectCommand="SELECT Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.InvID, Inventory.Status, Computer.FormFactor, Computer.Type FROM Inventory INNER JOIN Computer ON Inventory.InvID = Computer.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID INNER JOIN TransferInventory ON Inventory.InvID = TransferInventory.InvID WHERE (Logistics.Status = 'Active') AND (TransferInventory.TransID = @TransID)">
            <SelectParameters>
                <asp:SessionParameter Name="TransID" SessionField="CurrentTransfer" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <h2>
        Equipment in this Transfer</h2>
    <p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="InvID" DataSourceID="SqlDataSource3" 
            ForeColor="#333333" GridLines="None" 
            onselectedindexchanged="GridView2_SelectedIndexChanged" Width="1235px" 
            onrowcreated="GridView2_RowCreated">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="InvID" HeaderText="InvID" SortExpression="InvID" 
                    InsertVisible="False" ReadOnly="True" Visible="False" />
                <asp:BoundField DataField="SerialNo" HeaderText="SerialNo" 
                    SortExpression="SerialNo" />
                <asp:BoundField DataField="EquipmentType" HeaderText="EquipmentType" 
                    SortExpression="EquipmentType" />
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
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
            
            SelectCommand="SELECT Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.InvID, Inventory.Status, Equipment.EquipmentType FROM Inventory INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID INNER JOIN TransferInventory ON Inventory.InvID = TransferInventory.InvID INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID WHERE (Logistics.Status = 'Active') AND (TransferInventory.TransID = @TransID)">
            <SelectParameters>
                <asp:SessionParameter Name="TransID" SessionField="CurrentTransfer" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
