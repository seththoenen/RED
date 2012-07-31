<%@ Page Title="RED - Create New Purchase Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPO.aspx.cs" Inherits="SeniorProject.PO.AddPO" %>
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
        Add Purchase Order</h1>
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
<p>
        <asp:Button ID="btnAddPO" runat="server" onclick="btnAddPO_Click" 
            Text="Add Purchase Order" />
</p>
<p>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
</p>
<p>
        <asp:Button ID="btnClear" runat="server" onclick="btnClear_Click" Text="Clear" 
            Visible="False" />
</p>
</asp:Content>
