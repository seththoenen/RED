<%@ Page Title="RED - Update Computers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateDesktops.aspx.cs" Inherits="SeniorProject.UpdateDesktops" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 95%;
            margin-right: 0px;
        }
        .style6
    {
        width: 150px;
    }
        .style8
        {
            width: 100%;
        }
        .style9
        {
            width: 200px;
        }
        .style12
        {
            width: 150px;
            height: 85px;
        }
        .style13
        {
            height: 85px;
        }
        .style7
        {
            width: 100%;
        }
        .style14
        {
            width: 200px;
            height: 56px;
        }
        .style15
        {
            height: 56px;
        }
        .style16
        {
            height: 52px;
        }
        .style17
        {
            width: 200px;
            height: 52px;
        }
        .style18
        {
            width: 192px;
            height: 85px;
        }
        .style19
        {
            width: 192px;
        }
        .style20
        {
            width: 150px;
            height: 23px;
        }
        .style21
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Mass Update Computers </h1>
    <div id = "sidebar">
    
    <span class="page">Service Tag(s)/Serial No.(s):<br />
        <asp:UpdatePanel ID="updatePanelSerialNo0" runat="server">
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
                    Width="165px" />
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
        <br />
    
    </div>
    <div id = "maincontent">
    
        <asp:UpdatePanel ID="updatePanelContent" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnToggle" runat="server" CausesValidation="False" 
                    onclick="btnToggle_Click" Text="Select With GridView" Width="136px" />
                &nbsp;<asp:Button ID="btnAddWithTextBoxToggle" runat="server" 
                    CausesValidation="False" onclick="btnAddWithTextBoxToggle_Click" 
                    Text="Add With Text Box" Width="136px" />
<br />
                <asp:Panel ID="panelGeneral" runat="server">
                    <h2>
                        General</h2>
                    <table class="style1">
                        <tr>
                            <td class="style6">
                                SMSU Tag:</td>
                            <td class="style6" style="margin-left: 40px">
                                <asp:TextBox ID="txtBoxSMSUTag" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            </td>
                            <td class="style6">
                                Type:</td>
                            <td>
                                <asp:DropDownList ID="ddlType" runat="server" Height="20px" Width="142px">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Computer</asp:ListItem>
                                    <asp:ListItem>Tablet</asp:ListItem>
                                    <asp:ListItem>Laptop</asp:ListItem>
                                    <asp:ListItem>Server</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                Manufacturer:</td>
                            <td class="style6">
                                <asp:DropDownList ID="ddlManufacturer" runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSource9" DataTextField="value" DataValueField="value" 
                                    Height="20px" Width="142px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource9" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                    SelectCommand="SELECT [value] FROM [Settings] WHERE ([type] = @type) ORDER BY [value]">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="Manufacturer" Name="type" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td class="style6">
                                Status:</td>
                            <td>
                                <asp:DropDownList ID="ddlStatus" runat="server" Height="20px" Width="142px">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Active</asp:ListItem>
                                    <asp:ListItem>Storage</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                Model:</td>
                            <td class="style6">
                                <asp:TextBox ID="txtBoxModel" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            </td>
                            <td class="style6">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <h2>
                        Logistics</h2>
                    <asp:UpdatePanel ID="updatePanelLogistics" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnUpdateLogistics" runat="server" 
                                onclick="btnUpdateLogistics_Click" Text="Update Logistics" Width="136px" />
                            <asp:Panel ID="pnlLogistics" runat="server" Visible="False">
                                <table class="style1">
                                    <tr>
                                        <td class="style6">
                                            Building:</td>
                                        <td class="style6" style="margin-left: 80px">
                                            <asp:DropDownList ID="ddlBuilding" runat="server" DataSourceID="SqlDataSource8" 
                                                DataTextField="value" DataValueField="value" Height="22px" Width="142px">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource8" runat="server" 
                                                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                                SelectCommand="SELECT [value] FROM [Settings] WHERE ([type] = @type) ORDER BY [value]">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Building" Name="type" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                        <td class="style6">
                                            Room Number:</td>
                                        <td>
                                            <asp:TextBox ID="txtBoxRoomNumber" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style6">
                                            Primary User:</td>
                                        <td class="style6">
                                            <asp:TextBox ID="txtBoxPrimaryUser" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                                        </td>
                                        <td class="style6">
                                            Name:</td>
                                        <td>
                                            <asp:TextBox ID="txtBoxName" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="btnApplyLogisticsUpdates" runat="server" 
                                    onclick="btnApplyLogisticsUpdates_Click" Text="Update Logistics" 
                                    Width="136px" />
                                &nbsp;<asp:Button ID="btnCancelLogistics" runat="server" CausesValidation="False" 
                                    Height="26px" onclick="btnDontUpdateLogistics_Click" Text="Cancel" 
                                    Width="136px" />
                                <br />
                                <asp:Label ID="lblLogisticsMessage" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="btnClearLogistics" runat="server" 
                                    onclick="btnClearLogistics_Click" Text="Clear" Visible="False" 
                                    Width="136px" />
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnUpdateLogistics" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <h2>
                        Purchase Info</h2>
                    <table class="style1">
                        <tr>
                            <td class="style12">
                                Purchase Price:
                            </td>
                            <td class="style18">
                                <asp:TextBox ID="txtBoxPurchasePrice" runat="server" Columns="15" Width="136px"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToValidate="txtBoxPurchasePrice" ErrorMessage="Invalid" ForeColor="Red" 
                                    Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td class="style12">
                                PO No.</td>
                            <td class="style13">
                                <asp:UpdatePanel ID="updatePanelSelectPO" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlPONO" runat="server" AutoPostBack="True" 
                                            DataSourceID="SqlDataSource4" DataTextField="POno" DataValueField="POID" 
                                            Height="20px" Visible="False" Width="142px">
                                            <asp:ListItem>None</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnUpdatePO" runat="server" onclick="btnUpdatePO_Click" 
                                            Text="Update PO" Width="136px" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                    SelectCommand="SELECT * FROM [PO] ORDER BY [POno]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;</td>
                            <td class="style19">
                                &nbsp;</td>
                            <td class="style6">
                                &nbsp;</td>
                            <td>
                                <asp:UpdatePanel ID="ppdatePanelPODetails" runat="server">
                                    <ContentTemplate>
                                        <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" 
                                            CellPadding="4" DataSourceID="SqlDataSource5" ForeColor="#333333" 
                                            GridLines="None" Height="50px" Visible="False" Width="125px">
                                            <AlternatingRowStyle BackColor="White" />
                                            <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
                                            <EditRowStyle BackColor="#7C6F57" />
                                            <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
                                            <Fields>
                                                <asp:BoundField DataField="DeliveryDate" HeaderText="DeliveryDate" 
                                                    SortExpression="DeliveryDate" />
                                                <asp:BoundField DataField="RequisitionNo" HeaderText="RequisitionNo" 
                                                    SortExpression="RequisitionNo" />
                                                <asp:BoundField DataField="PurchaseDate" HeaderText="PurchaseDate" 
                                                    SortExpression="PurchaseDate" />
                                                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                            </Fields>
                                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#E3EAEB" />
                                        </asp:DetailsView>
                                        <asp:Button ID="btnDontUpdatePO" runat="server" CausesValidation="False" 
                                            onclick="btnDontUpdatePO_Click" Text="Don't Update PO" Visible="False" 
                                            Width="136px" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                    SelectCommand="SELECT [DeliveryDate], [RequisitionNo], [PurchaseDate], [Title] FROM [PO] WHERE ([POID] = @POID)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlPONO" Name="POID" 
                                            PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                    <h2>
                        Computer Info</h2>
                    <table class="style8">
                        <tr>
                            <td class="style6">
                                CPU:</td>
                            <td class="style6">
                                <asp:TextBox ID="txtBoxCPU" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            </td>
                            <td class="style6">
                                Video Card:</td>
                            <td>
                                <asp:TextBox ID="txtBoxVideoCard" runat="server" MaxLength="45" 
                                    style="margin-left: 0px" Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                Hard Drive:</td>
                            <td class="style6">
                                <asp:TextBox ID="txtBoxHardDrive" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            </td>
                            <td class="style6">
                                Memory:</td>
                            <td>
                                <asp:TextBox ID="txtBoxMemory" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                Optical Drive:</td>
                            <td class="style6">
                                <asp:TextBox ID="txtBoxOpticalDrive" runat="server" MaxLength="45" 
                                    Width="136px"></asp:TextBox>
                            </td>
                            <td class="style6">
                                Removable Media:</td>
                            <td>
                                <asp:TextBox ID="txtBoxRemovableMedia" runat="server" MaxLength="45" 
                                    Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                USB Ports:</td>
                            <td class="style6">
                                <asp:DropDownList ID="ddlUSBPorts" runat="server">
                                    <asp:ListItem>0</asp:ListItem>
                                    <asp:ListItem Value="1"></asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style6">
                                Other Connectivity:</td>
                            <td>
                                <asp:TextBox ID="txtBoxOtherConnectivity" runat="server" MaxLength="45" 
                                    Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style20">
                                Size:</td>
                            <td class="style20">
                                <asp:TextBox ID="txtBoxSize" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            </td>
                            <td class="style20">
                                Physical Address:</td>
                            <td class="style21">
                                <asp:TextBox ID="txtBoxPhysicalAddress" runat="server" MaxLength="20" 
                                    Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <h2>
                        Monitors</h2>
                    <asp:UpdatePanel ID="updatePanelMonitors" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnManageMonitors" runat="server" 
                                onclick="btnManageMonitors_Click" Text="Manage Monitors" Width="136px" />
                            <asp:Panel ID="panelMonitors" runat="server" Visible="False">
                                <asp:CheckBox ID="chkBoxRemoveAllMonitors" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="chkBoxRemoveAllMonitors_CheckedChanged" 
                                    Text="Remove all monitors from selected computers" ViewStateMode="Enabled" />
                                <br />
                                <asp:Button ID="btnApplyRemoveAllMonitors" runat="server" 
                                    onclick="btnApplyRemoveAllMonitors_Click" Text="Apply" Visible="False" 
                                    Width="136px" />
                                <br />
                                <asp:CheckBox ID="chkBoxRemoveCertainMonitors" runat="server" 
                                    AutoPostBack="True" 
                                    oncheckedchanged="chkBoxRemoveCertainMonitors_CheckedChanged" 
                                    Text="Remove certain monitors from selected computers" 
                                    ViewStateMode="Enabled" />
                                <br />
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="4" DataKeyNames="MonID" DataSourceID="SqlDataSource7" 
                                    ForeColor="#333333" GridLines="None" onrowcreated="GridView3_RowCreated" 
                                    onselectedindexchanged="GridView3_SelectedIndexChanged" Visible="False" 
                                    Width="760px">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="MonID" HeaderText="MonID" InsertVisible="False" 
                                            ReadOnly="True" SortExpression="MonID" Visible="False" />
                                        <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" />
                                        <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                                        <asp:BoundField DataField="Resolution" HeaderText="Resolution" 
                                            SortExpression="Resolution" />
                                        <asp:BoundField DataField="Connectors" HeaderText="Connectors" 
                                            SortExpression="Connectors" />
                                        <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
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
                                <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                    SelectCommand="SELECT [MonID], [Size], [Brand], [Resolution], [Connectors], [Model] FROM [Monitor]">
                                </asp:SqlDataSource>
                                <br />
                                <asp:CheckBox ID="chkBoxAddMonitors" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="chkBoxAddMonitors_CheckedChanged" 
                                    Text="Add new monitors to selected computers" ViewStateMode="Enabled" />
                                <br />
                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="4" DataKeyNames="MonID" DataSourceID="SqlDataSource7" 
                                    ForeColor="#333333" GridLines="None" onrowcreated="GridView4_RowCreated" 
                                    onselectedindexchanged="GridView4_SelectedIndexChanged" Visible="False" 
                                    Width="760px">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="MonID" HeaderText="MonID" InsertVisible="False" 
                                            ReadOnly="True" SortExpression="MonID" Visible="False" />
                                        <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" />
                                        <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                                        <asp:BoundField DataField="Resolution" HeaderText="Resolution" 
                                            SortExpression="Resolution" />
                                        <asp:BoundField DataField="Connectors" HeaderText="Connectors" 
                                            SortExpression="Connectors" />
                                        <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
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
                                <br />
                                <asp:Button ID="btnCancelLicensing0" runat="server" CausesValidation="False" 
                                    onclick="btnCancelLicensing0_Click" Text="Done" Width="136px" />
                                <br />
                                <asp:Label ID="lblMonitorMessage" runat="server" Visible="False"></asp:Label>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <h2>
                        Licensing</h2>
                    <asp:UpdatePanel ID="updatePanelLicenses" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnManageLicensing" runat="server" 
                                onclick="btnManageLicensing_Click" Text="ManageLicensing" Width="136px" />
                            <asp:Panel ID="pnlLicensing" runat="server" Visible="False">
                                <asp:CheckBox ID="chkBoxRemoveAllLicensing" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="chkBoxRemoveAllLicensing_CheckedChanged" 
                                    Text="Remove all licensing from selected computers." ViewStateMode="Enabled" />
                                <br />
                                <asp:Button ID="btnApplyRemoveAllLicenses" runat="server" 
                                    onclick="btnApplyRemoveAllLicenses_Click" Text="Apply" Visible="False" 
                                    Width="136px" />
                                <br />
                                <asp:CheckBox ID="chkBoxRemoveCertainLicenses" runat="server" 
                                    AutoPostBack="True" 
                                    oncheckedchanged="chkBoxRemoveCertainLicenses_CheckedChanged" 
                                    Text="Remove Certain Licenses" ViewStateMode="Enabled" />
                                <br />
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="4" DataKeyNames="LicID" DataSourceID="SqlDataSource6" 
                                    ForeColor="#333333" GridLines="None" onrowcreated="GridView1_RowCreated" 
                                    onselectedindexchanged="GridView1_SelectedIndexChanged" Visible="False" 
                                    Width="760px">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="LicID" HeaderText="LicID" InsertVisible="False" 
                                            ReadOnly="True" SortExpression="LicID" Visible="False" />
                                        <asp:BoundField DataField="Software" HeaderText="Software" 
                                            SortExpression="Software" />
                                        <asp:BoundField DataField="OS" HeaderText="OS" SortExpression="OS" />
                                        <asp:BoundField DataField="LicenseKey" HeaderText="LicenseKey" 
                                            SortExpression="LicenseKey" />
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
                                <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                    SelectCommand="SELECT [LicID], [Software], [OS], [LicenseKey] FROM [Licenses] WHERE ([Type] = @Type)">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="Computer" Name="Type" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <asp:CheckBox ID="chkBoxAddLicenses" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="chkBoxAddLicenses_CheckedChanged" Text="Add New Licenses" 
                                    ViewStateMode="Enabled" />
                                <br />
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="4" DataKeyNames="LicID" DataSourceID="SqlDataSource6" 
                                    ForeColor="#333333" GridLines="None" onrowcreated="GridView2_RowCreated" 
                                    onselectedindexchanged="GridView2_SelectedIndexChanged" Visible="False" 
                                    Width="760px">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="LicID" HeaderText="LicID" InsertVisible="False" 
                                            ReadOnly="True" SortExpression="LicID" Visible="False" />
                                        <asp:BoundField DataField="Software" HeaderText="Software" 
                                            SortExpression="Software" />
                                        <asp:BoundField DataField="OS" HeaderText="OS" SortExpression="OS" />
                                        <asp:BoundField DataField="LicenseKey" HeaderText="LicenseKey" 
                                            SortExpression="LicenseKey" />
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
                                <br />
                                <asp:Button ID="btnCancelLicensing" runat="server" CausesValidation="False" 
                                    onclick="btnCancelLicensing_Click" Text="Done" />
                                <br />
                                <asp:Label ID="lblLicenseMessage" runat="server" Visible="False"></asp:Label>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <h2>
                        Warranties</h2>
                    <asp:UpdatePanel ID="updatePanelWarranties" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnManageWarranties" runat="server" 
                                onclick="btnManageWarranties_Click" Text="Manage Warranties" 
                                Width="136px" />
                            <br />
                            <asp:Panel ID="panelWarranty" runat="server" Visible="False">
                                <asp:CheckBox ID="chkBoxRemoveAllWarranties" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="chkBoxRemoveAllWarranties_CheckedChanged" 
                                    Text="Remove All Warranties" ViewStateMode="Enabled" />
                                <br />
                                <asp:Button ID="btnApplyRemoveAllWarranties" runat="server" 
                                    onclick="btnApplyRemoveAllWarranties_Click" Text="Apply" Visible="False" 
                                    Width="136px" />
                                <br />
                                <asp:CheckBox ID="chkBoxAddWarranty" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="chkBoxAddWarranty_CheckedChanged" Text="Add a Warranty" 
                                    ViewStateMode="Enabled" />
                                <br />
                                <asp:Panel ID="panelAddWarranty" runat="server" Visible="False">
                                    <table class="style7">
                                        <tr>
                                            <td class="style15">
                                                Company:</td>
                                            <td class="style14">
                                                <asp:DropDownList ID="ddlWarrantyCompany" runat="server" AutoPostBack="True" 
                                                    DataSourceID="SqlDataSource18" DataTextField="value" DataValueField="value" 
                                                    Height="20px" Width="127px">
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource18" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                                    SelectCommand="SELECT [value] FROM [Settings] WHERE ([type] = @type) ORDER BY [value]">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="Manufacturer" Name="type" Type="String" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </td>
                                            <td class="style15">
                                                Warranty Type:</td>
                                            <td class="style15">
                                                <asp:TextBox ID="txtBoxWarrantyType" runat="server" MaxLength="45" 
                                                    Width="136px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style16">
                                                Start Date:</td>
                                            <td class="style17">
                                                <asp:TextBox ID="txtBoxWarrantyStartDate" runat="server" MaxLength="45" 
                                                    Width="136px"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtBoxWarrantyStartDate_CalendarExtender0" 
                                                    runat="server" Enabled="True" TargetControlID="txtBoxWarrantyStartDate">
                                                </asp:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                    ControlToValidate="txtBoxWarrantyStartDate" ErrorMessage="*" ForeColor="Red" 
                                                    ValidationGroup="warranty"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style16">
                                                End Date:</td>
                                            <td class="style16">
                                                <asp:TextBox ID="txtBoxWarrantyEndDate" runat="server" MaxLength="45" 
                                                    Width="136px"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtBoxWarrantyEndDate_CalendarExtender0" 
                                                    runat="server" Enabled="True" TargetControlID="txtBoxWarrantyEndDate">
                                                </asp:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                    ControlToValidate="txtBoxWarrantyEndDate" ErrorMessage="*" ForeColor="Red" 
                                                    ValidationGroup="warranty"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13" colspan="4">
                                                Notes:
                                                <asp:TextBox ID="txtBoxWarrantyNotes" runat="server" Height="50px" 
                                                    MaxLength="1000" TextMode="MultiLine" Width="600px"></asp:TextBox>
                                                <br />
                                                <br />
                                                <asp:Button ID="btnAddWarranty" runat="server" onclick="btnAddWarranty_Click" 
                                                    style="height: 26px" Text="Add Warranty" ValidationGroup="warranty" 
                                                    Width="136px" />
                                                &nbsp;<br />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Label ID="lblWarrantyMessage" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="btnCancelWarranty" runat="server" 
                                    onclick="brnCancelWarranty_Click" Text="Done" Width="136px" />
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <h2>
                        Maintenance</h2>
                    <asp:UpdatePanel ID="updatePanelMaintenance" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnAddMaintenance" runat="server" 
                                onclick="btnAddMaintenance_Click" Text="Add Maintenance" Width="136px" />
                            <br />
                            <asp:Panel ID="Panel1" runat="server" Visible="False">
                                <table class="style8">
                                    <tr>
                                        <td class="style9">
                                            Date:</td>
                                        <td>
                                            <asp:TextBox ID="txtboxDate" runat="server" MaxLength="45"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtboxDate_CalendarExtender" runat="server" 
                                                Enabled="True" TargetControlID="txtboxDate">
                                            </asp:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ControlToValidate="txtBoxDate" ErrorMessage="Date is required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style9">
                                            Maintenance Performed:</td>
                                        <td>
                                            <asp:TextBox ID="txtBoxMaintenance" runat="server" Height="100px" 
                                                MaxLength="1000" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                ControlToValidate="txtBoxMaintenance" ErrorMessage="Maintenance is required" 
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="btnInsertMaintenance" runat="server" 
                                    onclick="btnInsertMaintenance_Click" Text="Add Maintenance" 
                                    Width="136px" />
                                &nbsp;<asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                                    onclick="btnCancel_Click" Text="Done" Width="136px" />
                                <br />
                                <asp:Label ID="lblMaintenanceMessage" runat="server" Visible="False"></asp:Label>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <h2>
                        Notes</h2>
                    <p>
                        <asp:TextBox ID="txtBoxNotes" runat="server" Height="87px" MaxLength="1000" 
                            TextMode="MultiLine" Width="626px"></asp:TextBox>
                    </p>
                    <asp:UpdatePanel ID="updatePanelMessage" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnUpdateDesktop" runat="server" onclick="btnAddDesktop_Click" 
                                Text="Update" Width="136px" />
                            <br />
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            <br />
                            <asp:Button ID="btnClearMessage" runat="server" onclick="btnClearMessage_Click" 
                                Text="Clear" Visible="False" Width="136px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
<br />
                <asp:Panel ID="PanelGridView" runat="server" Visible="False">
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
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("SerialNo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="SerialNoHeaderLinkButton" runat="server" 
                                        CausesValidation="False" Text="SerialNo"></asp:LinkButton>
                                    <br />
                                    <asp:TextBox ID="txtBoxSerialNoFilter" runat="server" AutoPostBack="True" 
                                        TabIndex="1" Width="100px"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Type") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="TypeHeaderLinkButton" runat="server" 
                                        CausesValidation="False" Text="Type"></asp:LinkButton>
                                    <br />
                                    <asp:DropDownList ID="ddlTypeFilter" runat="server" AutoPostBack="True" 
                                        DataSourceID="SqlDataSourceType" DataTextField="Type" DataValueField="Type" 
                                        TabIndex="2" Width="100px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceType" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Computer.Type FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')
        ORDER BY Computer.Type ASC"></asp:SqlDataSource>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FormFactor">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("FormFactor") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="FormFactorHeaderLinkButton" runat="server" 
                                        CausesValidation="False" Text="FormFactor"></asp:LinkButton>
                                    <br />
                                    <asp:DropDownList ID="ddlFormFactorFilter" runat="server" AutoPostBack="True" 
                                        DataSourceID="SqlDataSourceFormFactor" DataTextField="FormFactor" 
                                        DataValueField="FormFactor" TabIndex="3" Width="100px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceFormFactor" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Computer.FormFactor FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')
        ORDER BY Computer.FormFactor ASC"></asp:SqlDataSource>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("FormFactor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Manufacturer">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Manufacturer") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="ManufacturerHeaderLinkButton" runat="server" 
                                        CausesValidation="False" Text="Manufacturer"></asp:LinkButton>
                                    <br />
                                    <asp:DropDownList ID="ddlManufacturerFilter" runat="server" AutoPostBack="True" 
                                        DataSourceID="SqlDataSourceManufacturer" DataTextField="Manufacturer" 
                                        DataValueField="Manufacturer" TabIndex="4" Width="100px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceManufacturer" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Inventory.Manufacturer FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')
        ORDER BY Inventory.Manufacturer ASC"></asp:SqlDataSource>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Manufacturer") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Model">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Model") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="ModelHeaderLinkButton" runat="server" 
                                        CausesValidation="False" Text="Model"></asp:LinkButton>
                                    <br />
                                    <asp:TextBox ID="txtBoxModelFilter" runat="server" AutoPostBack="True" 
                                        TabIndex="5" Width="100px"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Model") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="NameHeaderLinkButton" runat="server" 
                                        CausesValidation="False" Text="Name"></asp:LinkButton>
                                    <br />
                                    <asp:TextBox ID="txtBoxNameFilter" runat="server" AutoPostBack="True" 
                                        TabIndex="6" Width="100px"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Building">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Building") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="BuildingHeaderLinkButton" runat="server" 
                                        CausesValidation="False" Text="Building"></asp:LinkButton>
                                    <br />
                                    <asp:DropDownList ID="ddlBuildingFilter" runat="server" AutoPostBack="True" 
                                        DataSourceID="SqlDataSourceBuilding" DataTextField="Building" 
                                        DataValueField="Building" TabIndex="7" Width="100px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceBuilding" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Logistics.Building FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')
        ORDER BY Logistics.Building ASC"></asp:SqlDataSource>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Building") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Room">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Room") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="RoomHeaderLinkButton" runat="server" 
                                        CausesValidation="False" Text="Room"></asp:LinkButton>
                                    <br />
                                    <asp:TextBox ID="txtBoxRoomFilter" runat="server" AutoPostBack="True" 
                                        TabIndex="8" Width="100px"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Room") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="StatusHeaderLinkButton" runat="server" 
                                        CausesValidation="False" Text="Status"></asp:LinkButton>
                                    <br />
                                    <asp:DropDownList ID="ddlStatusFilter" runat="server" AutoPostBack="True" 
                                        DataSourceID="SqlDataSourceStatus" DataTextField="Status" 
                                        DataValueField="Status" TabIndex="10" Width="100px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceStatus" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                        SelectCommand="SELECT DISTINCT Inventory.Status FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred') ORDER BY Inventory.Status">
                                    </asp:SqlDataSource>
                                </HeaderTemplate>
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
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceComputers" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                        SelectCommand="SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Model, Inventory.Status, Computer.FormFactor, Computer.Type FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred') ORDER BY Inventory.SerialNo">
                    </asp:SqlDataSource>
                </asp:Panel>
                <br />
                <asp:Panel ID="panelTextBox" runat="server" Visible="False">
                    <table class="style7">
                        <tr>
                            <td class="style14">
                                <asp:TextBox ID="txtBoxSerialNos" runat="server" Height="450px" 
                                    TextMode="MultiLine" Width="250px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblAddTextBoxMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style14">
                                <asp:Button ID="btnAddWithTextBox" runat="server" CausesValidation="False" 
                                    onclick="btnAddWithTextBox_Click" Text="Add" Width="136px" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </asp:Panel>
                <br />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <p>
            &nbsp;</p>
           
        
    </div>
</asp:Content>
