<%@ Page Title="RED - Create New Transfer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewTransfer.aspx.cs" Inherits="SeniorProject.Transfers.NewTransfer" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
    New Transfer</h1>
<br />
    <div id="sidebar">
    
    <span class="page">Service Tag(s)/Serial No.(s):<br />
        <asp:UpdatePanel ID="updatePanelSerialNo" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtBoxSerialNo" runat="server" AutoPostBack="True" 
                    MaxLength="45" ontextchanged="txtBoxSerialNo_TextChanged" Width="152px"></asp:TextBox>
<br />
                <asp:Label ID="lblSerialNos" runat="server" Visible="False"></asp:Label>
<br />
                <asp:ListBox ID="lstBoxSerialNos" runat="server" Height="400px" 
                    SelectionMode="Multiple" Width="162px"></asp:ListBox>
                <br />
                <asp:Button ID="btnRemoveSelected" runat="server" CausesValidation="False" 
                    onclick="btnRemoveSelected_Click" Text="Remove Selected" 
                    Width="136px" />
<br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSerialNo0" runat="server" 
                    ControlToValidate="lstBoxSerialNos" 
                    ErrorMessage="You must enter at least 1 service tag" ForeColor="Red"></asp:RequiredFieldValidator>
            </ContentTemplate>
        </asp:UpdatePanel>
        </span>All Groups:<br />
        <asp:UpdatePanel ID="updatePanelGroups" runat="server">
            <ContentTemplate>
                <asp:ListBox ID="lstBoxGroups" runat="server" AutoPostBack="True" 
                    Height="300px" onselectedindexchanged="lstBoxGroups_SelectedIndexChanged" 
                    Width="156px" SelectionMode="Multiple"></asp:ListBox>
                <br />
                <asp:Button ID="btnSelectGroup" runat="server" CausesValidation="False" 
                    Enabled="False" onclick="btnSelectGroup_Click" Text="Select Group(s)" 
                    Width="136px" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
<div id="maincontent">
    <asp:UpdatePanel ID="updatePanelPage" runat="server">
        <ContentTemplate>
            <asp:Button ID="btnAddComputers" runat="server" CausesValidation="False" 
                onclick="btnAddComputers_Click" Text="Add Computers" 
                Width="136px" />
            &nbsp;<asp:Button ID="btnAddEquipment" runat="server" CausesValidation="False" 
                onclick="btnAddEquipment_Click" Text="Add Equipment" 
                Width="136px" />
<br />
            <asp:Panel ID="panelTransfer" runat="server">
                <table class="style1">
                    <tr>
                        <td class="style2">
                            Transfer To:</td>
                        <td>
                            <asp:TextBox ID="txtBoxWhere" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtBoxWhere" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Date:</td>
                        <td style="margin-left: 40px">
                            <asp:TextBox ID="txtBoxDate" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            <asp:CalendarExtender ID="txtBoxDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtBoxDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtBoxDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Notes:</td>
                        <td style="margin-left: 80px">
                            <asp:TextBox ID="txtBoxNotes" runat="server" Height="150px" 
                                TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnCreateTransfer" runat="server" 
                    onclick="btnCreateTransfer_Click" Text="Create Transfer" Width="136px" />
                <br />
                <asp:Label ID="lblTransferMessage" runat="server" Visible="False"></asp:Label>
                <br />
                <asp:Button ID="btnClearMessage" runat="server" onclick="btnClearMessage_Click" 
                    Text="Clear" Visible="False" Width="136px" />
            </asp:Panel>
<br />
            <asp:Panel ID="panelComputers" runat="server" Visible="False">
                <asp:GridView ID="GridViewComputers" runat="server" AllowSorting="True" 
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="InvID,SerialNo" 
                    DataSourceID="SqlDataSourceComputers" ForeColor="#333333" GridLines="None" 
                    onrowcreated="GridViewComputers_RowCreated" 
                    onselectedindexchanged="GridViewComputers_SelectedIndexChanged" 
                    ShowHeaderWhenEmpty="True" Width="1020px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="InvID" HeaderText="InvID" InsertVisible="False" 
                            ReadOnly="True" SortExpression="InvID" Visible="False" />
                        <asp:TemplateField HeaderText="SerialNo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("SerialNo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="computerSerialNoHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="SerialNo"></asp:LinkButton>
                                <br />
                                <asp:TextBox ID="txtBoxSerialNoFilter" runat="server" AutoPostBack="True" 
                                    TabIndex="1" Width="100px"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label19" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("Type") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="computerTypeHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Type"></asp:LinkButton>
                                <br />
                                <asp:DropDownList ID="ddlTypeFilter" runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSourceType1" DataTextField="Type" DataValueField="Type" 
                                    TabIndex="2" Width="100px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceType1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Computer.Type FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')
        ORDER BY Computer.Type ASC"></asp:SqlDataSource>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label20" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FormFactor">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox21" runat="server" Text='<%# Bind("FormFactor") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="computerFormFactorHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="FormFactor"></asp:LinkButton>
                                <br />
                                <asp:DropDownList ID="ddlFormFactorFilter" runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSourceFormFactor0" DataTextField="FormFactor" 
                                    DataValueField="FormFactor" TabIndex="3" Width="100px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceFormFactor0" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Computer.FormFactor FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')
        ORDER BY Computer.FormFactor ASC"></asp:SqlDataSource>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# Bind("FormFactor") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Manufacturer">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox22" runat="server" Text='<%# Bind("Manufacturer") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="computerManufacturerHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Manufacturer"></asp:LinkButton>
                                <br />
                                <asp:DropDownList ID="ddlManufacturerFilter" runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSourceManufacturer1" DataTextField="Manufacturer" 
                                    DataValueField="Manufacturer" TabIndex="4" Width="100px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceManufacturer1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Inventory.Manufacturer FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')
        ORDER BY Inventory.Manufacturer ASC"></asp:SqlDataSource>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label22" runat="server" Text='<%# Bind("Manufacturer") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Model">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox23" runat="server" Text='<%# Bind("Model") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="computerModelHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Model"></asp:LinkButton>
                                <br />
                                <asp:TextBox ID="txtBoxModelFilter" runat="server" AutoPostBack="True" 
                                    TabIndex="5" Width="100px"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label23" runat="server" Text='<%# Bind("Model") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox24" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="computerNameHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Name"></asp:LinkButton>
                                <br />
                                <asp:TextBox ID="txtBoxNameFilter" runat="server" AutoPostBack="True" 
                                    TabIndex="6" Width="100px"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label24" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Building">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox25" runat="server" Text='<%# Bind("Building") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="computerBuildingHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Building"></asp:LinkButton>
                                <br />
                                <asp:DropDownList ID="ddlBuildingFilter" runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSourceBuilding1" DataTextField="Building" 
                                    DataValueField="Building" TabIndex="7" Width="100px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceBuilding1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Logistics.Building FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')
        ORDER BY Logistics.Building ASC"></asp:SqlDataSource>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label25" runat="server" Text='<%# Bind("Building") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Room">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox26" runat="server" Text='<%# Bind("Room") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="computerRoomHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Room"></asp:LinkButton>
                                <br />
                                <asp:TextBox ID="txtBoxRoomFilter" runat="server" AutoPostBack="True" 
                                    TabIndex="8" Width="100px"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label26" runat="server" Text='<%# Bind("Room") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox27" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="computerStatusHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Status"></asp:LinkButton>
                                <br />
                                <asp:DropDownList ID="ddlStatusFilter" runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSourceStatus1" DataTextField="Status" 
                                    DataValueField="Status" TabIndex="10" Width="100px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceStatus1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                    SelectCommand="SELECT DISTINCT Inventory.Status FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred') ORDER BY Inventory.Status">
                                </asp:SqlDataSource>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label27" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceComputers" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                    SelectCommand="SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Model, Inventory.Status, Computer.FormFactor, Computer.Type FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred') ORDER BY Inventory.SerialNo">
                </asp:SqlDataSource>
                <br />
                <br />
                <br />
            </asp:Panel>
            <br />
            <asp:Panel ID="panelEquipment" runat="server" Visible="False">
                <asp:GridView ID="GridViewEquipment" runat="server" AllowSorting="True" 
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="InvID,SerialNo" 
                    DataSourceID="SqlDataSourceEquipment" ForeColor="#333333" GridLines="None" 
                    onrowcreated="GridViewEquipment_RowCreated" 
                    onselectedindexchanged="GridViewEquipment_SelectedIndexChanged" 
                    ShowHeaderWhenEmpty="True" Width="1022px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="InvID" HeaderText="InvID" InsertVisible="False" 
                            ReadOnly="True" SortExpression="InvID" Visible="False" />
                        <asp:TemplateField HeaderText="SerialNo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("SerialNo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="equipmentSerialNoHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="SerialNo"></asp:LinkButton>
                                <br />
                                <asp:TextBox ID="txtBoxSerialNoFilter" runat="server" AutoPostBack="True" 
                                    TabIndex="1" Width="100px"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("Type") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="equipmentTypeHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Type"></asp:LinkButton>
                                <br />
                                <asp:DropDownList ID="ddlTypeFilter" runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSourceType0" DataTextField="Type" DataValueField="Type" 
                                    TabIndex="2" Width="100px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceType0" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                    SelectCommand="SELECT DISTINCT Equipment.EquipmentType as Type FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')">
                                </asp:SqlDataSource>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Manufacturer">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("Manufacturer") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="equipmentManufacturerHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Manufacturer"></asp:LinkButton>
                                <br />
                                <asp:DropDownList ID="ddlManufacturerFilter" runat="server" 
                                    AutoPostBack="True" DataSourceID="SqlDataSourceManufacturer0" 
                                    DataTextField="Manufacturer" DataValueField="Manufacturer" TabIndex="4" 
                                    Width="100px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceManufacturer0" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                    SelectCommand="SELECT DISTINCT Inventory.Manufacturer FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')">
                                </asp:SqlDataSource>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("Manufacturer") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Model">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("Model") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="equipmentModelHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Model"></asp:LinkButton>
                                <br />
                                <asp:TextBox ID="txtBoxModelFilter" runat="server" AutoPostBack="True" 
                                    TabIndex="5" Width="100px"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label15" runat="server" Text='<%# Bind("Model") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="equipmentNameHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Name"></asp:LinkButton>
                                <br />
                                <asp:TextBox ID="txtBoxNameFilter" runat="server" AutoPostBack="True" 
                                    TabIndex="6" Width="100px"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label16" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Building">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("Building") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="equipmentBuildingHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Building"></asp:LinkButton>
                                <br />
                                <asp:DropDownList ID="ddlBuildingFilter" runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSourceBuilding0" DataTextField="Building" 
                                    DataValueField="Building" TabIndex="7" Width="100px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceBuilding0" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                    SelectCommand="SELECT DISTINCT Logistics.Building FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')">
                                </asp:SqlDataSource>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label17" runat="server" Text='<%# Bind("Building") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Room">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("Room") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="equipmentRoomHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Room"></asp:LinkButton>
                                <br />
                                <asp:TextBox ID="txtBoxRoomFilter" runat="server" AutoPostBack="True" 
                                    TabIndex="8" Width="100px"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label18" runat="server" Text='<%# Bind("Room") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PrimaryUser">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("PrimaryUser") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="equipmentPrimaryUserHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="PrimaryUser"></asp:LinkButton>
                                <br />
                                <asp:TextBox ID="txtBoxPrimaryUserFilter" runat="server" AutoPostBack="True" 
                                    TabIndex="9" Width="100px"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("PrimaryUser") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="equipmentStatusHeaderLinkButton" runat="server" 
                                    CausesValidation="False" Text="Status"></asp:LinkButton>
                                <br />
                                <asp:DropDownList ID="ddlStatusFilter" runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSourceStatus0" DataTextField="Status" 
                                    DataValueField="Status" TabIndex="10" Width="100px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceStatus0" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                    SelectCommand="SELECT DISTINCT Inventory.Status FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')">
                                </asp:SqlDataSource>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
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
                <asp:SqlDataSource ID="SqlDataSourceEquipment" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                    SelectCommand="SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Equipment.EquipmentType as Type, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Status FROM Equipment INNER JOIN Inventory ON Equipment.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred') ORDER BY Inventory.SerialNo">
                </asp:SqlDataSource>
                <br />
                <br />
            </asp:Panel>
            <br />
<br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
<br />
</div>
</asp:Content>
