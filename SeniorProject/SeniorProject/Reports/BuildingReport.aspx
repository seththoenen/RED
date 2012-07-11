<%@ Page Title="RED - Building Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuildingReport.aspx.cs" Inherits="SeniorProject.Reports.BuildingReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Building Report</h1>
<p>Note: Only Active Inventory Items Shown</p>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" Height="800px" InteractiveDeviceInfos="(Collection)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1199px">
    <LocalReport ReportPath="Reports\BuildingReport.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
        SelectCommand="SELECT Inventory.SMSUTag, Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, ISNULL(Computer.Type, Equipment.EquipmentType) AS InvType, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Status FROM Inventory INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID LEFT OUTER JOIN Computer ON Inventory.InvID = Computer.InvID LEFT OUTER JOIN Equipment ON Inventory.InvID = Equipment.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status = 'Active') ORDER BY Inventory.SerialNo">
    </asp:SqlDataSource>
</asp:Content>
