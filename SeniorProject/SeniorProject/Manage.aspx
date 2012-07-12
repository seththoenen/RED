﻿<%@ Page Title="RED - Manage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SeniorProject.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 71%;
            margin-right: 0px;
        }
        .style4
        {
            width: 100px;
        }
        .style5
        {
            width: 100px;
            height: 26px;
        }
        .style6
        {
            width: 326px;
            margin-left: 80px;
            height: 26px;
        }
        .style7
        {
            width: 171px;
            margin-left: 80px;
            height: 26px;
        }
        .style8
        {
            width: 171px;
            margin-left: 80px;
        }
        .style9
        {
            width: 148px;
            margin-left: 80px;
            height: 26px;
        }
        .style10
        {
            width: 100%;
        }
        .style11
        {
            height: 160px;
        }
        .style12
        {
            height: 160px;
            width: 250px;
        }
        .style13
        {
            width: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Monitors    </h2>
    <asp:UpdatePanel ID="updatePanelMonitors" runat="server">
        <ContentTemplate>
            <table class="style1">
                <tr>
                    <td class="style5">
                        Size:</td>
                    <td class="style7">
                        <asp:TextBox ID="txtBoxSize" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                    </td>
                    <td class="style9" rowspan="6">
                        Current Monitors:<br />
                        <asp:ListBox ID="lstBoxMonitor" runat="server" AutoPostBack="True" 
                        DataSourceID="SqlDataSource1" DataTextField="Display" DataValueField="MonID" 
                        Height="156px" Width="202px"></asp:ListBox>
                        <br />
                        <asp:Button ID="btnEdit" runat="server" onclick="btnEdit_Click" 
                        Text="Edit Selected" />
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                        SelectCommand="SELECT [MonID], [Display] FROM [Monitor]"></asp:SqlDataSource>
                    </td>
                    <td class="style6" rowspan="6">
                        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                        CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" 
                        GridLines="None" Height="63px" Width="191px">
                            <AlternatingRowStyle BackColor="White" />
                            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                            <Fields>
                                <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" />
                                <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                                <asp:BoundField DataField="Resolution" HeaderText="Resolution" 
                                SortExpression="Resolution" />
                                <asp:BoundField DataField="Connectors" HeaderText="Connectors" 
                                SortExpression="Connectors" />
                                <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
                            </Fields>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                        </asp:DetailsView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                        
                        
                        
                            SelectCommand="SELECT [Size], [Brand], [Resolution], [Connectors], [Model] FROM [Monitor] WHERE ([MonID] = @MonID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lstBoxMonitor" Name="MonID" 
                                PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Brand:</td>
                    <td class="style8">
                        <asp:TextBox ID="txtBoxBrand" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Model:</td>
                    <td class="style8">
                        <asp:TextBox ID="txtBoxModel" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Resolution:</td>
                    <td class="style8">
                        <asp:TextBox ID="txtBoxResolution" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Connectors:</td>
                    <td class="style8">
                        <asp:TextBox ID="txtBoxConnectors" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Display Text:</td>
                    <td class="style8">
                        <asp:TextBox ID="txtBoxDisplayText" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnAddMonitor" runat="server" onclick="btnAddMonitor_Click" 
                Text="Add Monitor" />
            &nbsp;<asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                Text="Cancel" Visible="False" />
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <h2>
            Buildings</h2>
    <asp:UpdatePanel ID="updatePanelBuilding" runat="server">
        <ContentTemplate>
            <table class="style10">
                <tr>
                    <td class="style12">
                        <asp:ListBox ID="lstBoxBuildings" runat="server" 
                DataSourceID="SqlDataSource3" DataTextField="value" DataValueField="id" 
                Height="200px" Width="200px"></asp:ListBox>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                
                            SelectCommand="SELECT [id], [value] FROM [Settings] WHERE (([type] = @type) AND ([id] &lt;&gt; @id)) ORDER BY [value]">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Building" Name="type" 
                        Type="String" />
                                <asp:Parameter DefaultValue="15" Name="id" 
                        Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:Button ID="btnRemoveBuilding" runat="server" 
                Text="Remove Selected Building" Width="200px" onclick="btnRemoveBuilding_Click" />
                    </td>
                    <td class="style11">
                        <asp:TextBox ID="txtBoxBuilding" runat="server" 
                Width="136px" MaxLength="45"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBoxBuilding" 
                ErrorMessage="Building name is required" ForeColor="Red" 
                ValidationGroup="Building"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Button ID="btnAddBuilding" runat="server" 
                onclick="btnAddBuilding_Click" Text="Add Building" Width="136px" 
                            ValidationGroup="Building" />
                        <br />
                        <asp:Label ID="lblBuildingMessage" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <h2>
        Manufacturers</h2>
    <asp:UpdatePanel ID="updatePanelManufacturers" runat="server">
        <ContentTemplate>
            <table class="style10">
                <tr>
                    <td class="style13">
                        <asp:ListBox ID="lstBoxManufcturers" runat="server" 
                            DataSourceID="SqlDataSource4" DataTextField="value" DataValueField="id" 
                            Height="200px" Width="200px"></asp:ListBox>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                            SelectCommand="SELECT [id], [value] FROM [Settings] WHERE (([type] = @type) AND ([id] &lt;&gt; @id)) ORDER BY [value]">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Manufacturer" Name="type" Type="String" />
                                <asp:Parameter DefaultValue="14" Name="id" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:Button ID="btnRemoveManufacturer" runat="server" 
                            onclick="btnRemoveManufacturer_Click" Text="Remove Selected Manufacturer" 
                            Width="200px" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtBoxManufacturer" runat="server" Width="136px" 
                            MaxLength="45"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtBoxManufacturer" ErrorMessage="Building name is required" 
                            ForeColor="Red" ValidationGroup="Manufacturer"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Button ID="btnAddManufacturer" runat="server" 
                            onclick="btnAddManufacturer_Click" Text="Add Manufacturer" 
                            ValidationGroup="Manufacturer" Width="136px" />
                        <br />
                        <asp:Label ID="lblManufacturerMessage" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        &nbsp;</p>
    
    <br />
</asp:Content>
