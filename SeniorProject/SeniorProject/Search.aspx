<%@ Page Title="RED - Search Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SeniorProject.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Search Results</h1>
    <h2>
        Computers </h2>
    <asp:UpdatePanel ID="updatePanelComputers" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="InvID" 
                DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                onrowcreated="GridView1_RowCreated" 
                onselectedindexchanged="GridView1_SelectedIndexChanged" Width="1235px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="InvID" HeaderText="InvID" InsertVisible="False" 
                        ReadOnly="True" SortExpression="InvID" Visible="False" />
                    <asp:BoundField DataField="SerialNo" HeaderText="SerialNo" 
                        SortExpression="SerialNo" />
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                    <asp:BoundField DataField="FormFactor" HeaderText="FormFactor" 
                        SortExpression="FormFactor" />
                    <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" 
                        SortExpression="Manufacturer" />
                    <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Building" HeaderText="Building" 
                        SortExpression="Building" />
                    <asp:BoundField DataField="Room" HeaderText="Room" SortExpression="Room" />
                    <asp:BoundField DataField="PrimaryUser" HeaderText="PrimaryUser" 
                        SortExpression="PrimaryUser" />
                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
            
            SelectCommand="SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Model, Inventory.Status, Computer.FormFactor, Computer.Type FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status = 'Active') OR (Inventory.Status = 'Storage') ORDER BY Inventory.SerialNo">
        </asp:SqlDataSource>
        <asp:Label ID="lblComputers" runat="server" 
            Text="There doesn't seem to be anything here." Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblComputerSQL" runat="server" Visible="False"></asp:Label>
    </p>
    <h2>
        Equipment </h2>
    <asp:UpdatePanel ID="updatePanelEquipment" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="InvID" DataSourceID="SqlDataSource2" 
            ForeColor="#333333" GridLines="None" Width="1235px" 
            onselectedindexchanged="GridView2_SelectedIndexChanged" 
            onrowcreated="GridView2_RowCreated" 
    AllowSorting="True">
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
                <HeaderStyle BackColor="#680000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
            
            SelectCommand="SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Equipment.EquipmentType, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Status FROM Equipment INNER JOIN Inventory ON Equipment.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status = 'Active') OR (Inventory.Status = 'Storage') ORDER BY Inventory.SerialNo">
        </asp:SqlDataSource>
        <asp:Label ID="lblEquipment" runat="server" 
            Text="There doesn't seem to be anything here." Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblEquipmentSQL" runat="server" Visible="False"></asp:Label>
    </p>
    <p>
    </p>
</asp:Content>
