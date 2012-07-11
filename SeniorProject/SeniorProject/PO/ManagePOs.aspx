<%@ Page Title="RED - Manage Purchase Orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagePOs.aspx.cs" Inherits="SeniorProject.PO.ManagePOs" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

    .style1
    {
        width: 32%;
    }
    .style2
    {
        width: 200px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
    All Purchase Orders</h1>
    <asp:UpdatePanel ID="updatePanelNewPO" runat="server">
        <ContentTemplate>
            <asp:Button ID="btnCreateNewPO" runat="server" Text="Create PO" 
                onclick="btnCreateNewPO_Click" />
            <br />
            <asp:Panel ID="panelCreateNewPO" runat="server" Visible="False">
                <table class="style1">
                    <tr>
                        <td class="style2">
                            Purchase Order Number:</td>
                        <td style="margin-left: 40px">
                            <asp:TextBox ID="txtBoxPoNo" runat="server" MaxLength="45"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Requisition Number:</td>
                        <td>
                            <asp:TextBox ID="txtBoxRequisitionNo" runat="server" MaxLength="45"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Purchase Date:</td>
                        <td>
                            <asp:TextBox ID="txtBoxPurchaseDate" runat="server" MaxLength="45"></asp:TextBox>
                            <asp:CalendarExtender ID="txtBoxPurchaseDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtBoxPurchaseDate">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Delivery Date:</td>
                        <td>
                            <asp:TextBox ID="txtBoxDeliveryDate" runat="server" Height="22px" 
                                MaxLength="45"></asp:TextBox>
                            <asp:CalendarExtender ID="txtBoxDeliveryDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtBoxDeliveryDate">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Title:</td>
                        <td>
                            <asp:TextBox ID="txtBoxTitle" runat="server" MaxLength="45"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnAddPO" runat="server" onclick="btnAddPO_Click" 
                Text="Add Purchase Order" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                    Text="Cancel" />
            </asp:Panel>
            
            <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
            
<br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="updatePanelDataGrid" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="POID" DataSourceID="SqlDataSource1" 
        ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" Width="1235px" 
        onrowcreated="GridView1_RowCreated">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="POID" HeaderText="POID" InsertVisible="False" 
                ReadOnly="True" SortExpression="POID" Visible="False" />
                    <asp:BoundField DataField="POno" HeaderText="POno" SortExpression="POno" />
                    <asp:BoundField DataField="Count" HeaderText="Inventory Count" 
                SortExpression="Count" ReadOnly="True" />
                    <asp:BoundField DataField="DeliveryDate" HeaderText="DeliveryDate" 
                SortExpression="DeliveryDate" />
                    <asp:BoundField DataField="RequisitionNo" HeaderText="RequisitionNo" 
                SortExpression="RequisitionNo" />
                    <asp:BoundField DataField="PurchaseDate" HeaderText="PurchaseDate" 
                        SortExpression="PurchaseDate" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
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
                
                SelectCommand="SELECT PO.POID, PO.POno, PO.DeliveryDate, PO.RequisitionNo, PO.PurchaseDate, PO.Title, COUNT(PO.POno) AS Count FROM PO INNER JOIN POInventory ON PO.POID = POInventory.POID GROUP BY PO.POID, PO.POno, PO.DeliveryDate, PO.RequisitionNo, PO.PurchaseDate, PO.Title ORDER BY PO.POno"></asp:SqlDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
