<%@ Page Title="RED - Inventory Type Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InventoryTypeReport.aspx.cs" Inherits="SeniorProject.Reports.EquipmentReport" %><%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
    Equipment Report</h1>
<p>
    Note: Only Active Inventory Items Shown</p>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
    
        SelectCommand="SELECT Inventory.SMSUTag, Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, ISNULL(Computer.Type, Equipment.EquipmentType) AS InvType, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Status FROM Inventory INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID LEFT OUTER JOIN Computer ON Inventory.InvID = Computer.InvID LEFT OUTER JOIN Equipment ON Inventory.InvID = Equipment.InvID WHERE (Logistics.Status = 'Active') AND ((Inventory.Status = 'Active') OR (Inventory.Status = 'Storage')) ORDER BY Inventory.SerialNo">
</asp:SqlDataSource>
<rsweb:reportviewer ID="ReportViewer1" runat="server" Height="800px" 
    Width="1200px" Font-Names="Verdana" Font-Size="8pt" 
    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
    WaitMessageFont-Size="14pt">
    <LocalReport ReportPath="Reports\InventoryReport.rdlc">
        <DataSources>
            <rsweb:reportdatasource DataSourceId="SqlDataSource1" Name="InventoryData" />
        </DataSources>
    </LocalReport>
</rsweb:reportviewer>
</asp:Content>
