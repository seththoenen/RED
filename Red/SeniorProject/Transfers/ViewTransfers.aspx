<%@ Page Title="RED - View Transfers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTransfers.aspx.cs" Inherits="SeniorProject.Transfers.View_Transfers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
    Transfers</h1>
<p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="TransID" DataSourceID="SqlDataSource1" 
        ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" Width="1235px" 
        onrowcreated="GridView1_RowCreated" style="margin-bottom: 1px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="TransID" HeaderText="TransID" InsertVisible="False" 
                ReadOnly="True" SortExpression="TransID" Visible="False" />
            <asp:BoundField DataField="Whereto" HeaderText="Transferred To" 
                SortExpression="Whereto" >
            <ItemStyle Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" >
            <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="InvCount" HeaderText="Inventory Count" 
                ReadOnly="True" SortExpression="InvCount">
            <ItemStyle Width="15%" />
            </asp:BoundField>
            <asp:BoundField DataField="Notes" HeaderText="Notes" 
                SortExpression="Notes" >
            <ItemStyle Width="50%" />
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
        
        SelectCommand="SELECT Transfers.TransID, Transfers.Date, Transfers.Whereto, Transfers.Notes, COUNT(Transfers.TransID) AS InvCount FROM Transfers INNER JOIN TransferInventory ON Transfers.TransID = TransferInventory.TransID GROUP BY Transfers.TransID, Transfers.Date, Transfers.Whereto, Transfers.Notes"></asp:SqlDataSource>
</p>
</asp:Content>
