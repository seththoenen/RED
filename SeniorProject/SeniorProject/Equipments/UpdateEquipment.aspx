<%@ Page Title="RED - Update Equipment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateEquipment.aspx.cs" Inherits="SeniorProject.Equipments.UpdateEquipment" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">


        .style1
        {
            width: 97%;
        }
        .style9
        {
            width: 200px;
        }
        .style11
    {
        width: 96%;
    }
        .style8
        {
            width: 100%;
        }
        .style7
        {
            width: 100%;
        }
        .style15
        {
            height: 56px;
        }
        .style14
        {
            width: 200px;
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
        .style13
        {
            height: 85px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Mass Update Equipment</h1>
    <div id = "sidebar">
        <span class="page">Serial No.(s):<br />
        <asp:UpdatePanel ID="updatePanelSerialNo" runat="server">
            <ContentTemplate>
                <span class="page">
                <asp:TextBox ID="txtBoxSerialNo" runat="server" AutoPostBack="True" 
                    MaxLength="45" ontextchanged="txtBoxSerialNo_TextChanged" Width="159px" 
                    Height="21px"></asp:TextBox>
                </span>
<br />
                <asp:Label ID="lblSerialNos" runat="server" Visible="False"></asp:Label>
<br />
                <asp:ListBox ID="lstBoxSerialNos" runat="server" Height="400px" 
                    SelectionMode="Multiple" Width="164px"></asp:ListBox>
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
        </span>All Groups:<asp:UpdatePanel ID="updatePanelGroups" runat="server">
            <ContentTemplate>
                <asp:ListBox ID="lstBoxGroups" runat="server" AutoPostBack="True" 
                    Height="300px" onselectedindexchanged="lstBoxGroups_SelectedIndexChanged" 
                    Width="165px" SelectionMode="Multiple"></asp:ListBox>
                <br />
                <asp:Button ID="btnSelectGroup" runat="server" CausesValidation="False" 
                    Enabled="False" onclick="btnSelectGroup_Click" Text="Select Group(s)" 
                    Width="136px" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />

    </div>
    <div id = "maincontent">
    
        <asp:UpdatePanel ID="updatePanelPage" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnToggle" runat="server" CausesValidation="False" 
    onclick="btnToggle_Click" Text="Select With GridView" Width="136px" />

                &nbsp;<asp:Button ID="btnAddWithTextBoxToggle" runat="server" 
                    CausesValidation="False" onclick="btnAddWithTextBoxToggle_Click" 
                    Text="Add With Text Box" Width="136px" />

                <asp:Panel ID="panelGeneral" runat="server">
                    <h2>
                        General</h2>
                    <table class="style1">
                        <tr>
                            <td class="style9">
                                SMSU Tag:</td>
                            <td class="style9" style="margin-left: 40px">
                                <asp:TextBox ID="txtBoxSMSUTag" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            </td>
                            <td class="style9">
                                Type:</td>
                            <td>
                                <asp:DropDownList ID="ddlType" runat="server" Width="142px">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value="Printer">Printer</asp:ListItem>
                                    <asp:ListItem>Projector</asp:ListItem>
                                    <asp:ListItem>PDA</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Manufacturer:</td>
                            <td class="style9">
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
                            <td class="style9">
                                Status:</td>
                            <td>
                                <asp:DropDownList ID="ddlStatus" runat="server" Height="22px" Width="142px">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Active</asp:ListItem>
                                    <asp:ListItem>Storage</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Model:</td>
                            <td class="style9">
                                <asp:TextBox ID="txtBoxModel" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            </td>
                            <td class="style9">
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
                                onclick="btnUpdateLogistics_Click" Text="UpdateLogistics" Width="136px" />
                            <br />
                            <asp:Panel ID="panelUpdateLogistics" runat="server" Visible="False">
                                <table class="style1">
                                    <tr>
                                        <td class="style9">
                                            Building:</td>
                                        <td class="style9" style="margin-left: 80px">
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
                                        <td class="style9">
                                            Room Number:</td>
                                        <td>
                                            <asp:TextBox ID="txtBoxRoomNumber" runat="server" MaxLength="45">136px</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style9">
                                            Primary User:</td>
                                        <td class="style9">
                                            <asp:TextBox ID="txtBoxPrimaryUser" runat="server" MaxLength="45">136px</asp:TextBox>
                                        </td>
                                        <td class="style9">
                                            Name:</td>
                                        <td>
                                            <asp:TextBox ID="txtBoxName" runat="server" MaxLength="45">136px</asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Button ID="btnApplyLogisticsUpdates" runat="server" 
                                    onclick="btnApplyLogisticsUpdates_Click" Text="UpdateLogistics" 
                                    Width="136px" />
                                &nbsp;<asp:Button ID="btnCancelLogistics" runat="server" 
                                    onclick="btnCancelLogistics_Click" Text="Cancel" Width="136px" />
                                <br />
                                <asp:Label ID="lblLogisticsMessage" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="btnClearLogistics" runat="server" Text="Button" Width="136px" />
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <h2>
                        Purchase Info</h2>
                    <table class="style1">
                        <tr>
                            <td class="style9">
                                Purchase Price:</td>
                            <td class="style9">
                                <asp:TextBox ID="txtBoxPurchasePrice" runat="server" MaxLength="15" 
                                    Width="136px"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToValidate="txtBoxPurchasePrice" ErrorMessage="Invalid" ForeColor="Red" 
                                    Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td class="style9" rowspan="2">
                                PO No.</td>
                            <td rowspan="2">
                                <asp:UpdatePanel ID="pdatePanelPO" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnUpdatePO" runat="server" onclick="btnUpdatePO_Click" 
                                            Text="Update PO" Width="136px" />
                                        <br />
                                        <asp:Panel ID="panelPO" runat="server" Visible="False">
                                            <asp:DropDownList ID="ddlPONO" runat="server" AutoPostBack="True" 
                                                DataSourceID="SqlDataSource4" DataTextField="POno" DataValueField="POID" 
                                                Height="20px" Width="142px">
                                                <asp:ListItem>None</asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                                                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                                SelectCommand="SELECT * FROM [PO] ORDER BY [POno]"></asp:SqlDataSource>
                                            <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" 
                                                CellPadding="4" DataSourceID="SqlDataSource5" ForeColor="#333333" 
                                                GridLines="None" Height="50px" Width="125px">
                                                <AlternatingRowStyle BackColor="White" />
                                                <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
                                                <EditRowStyle BackColor="#7C6F57" />
                                                <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
                                                <Fields>
                                                    <asp:BoundField DataField="RequisitionNo" HeaderText="RequisitionNo" 
                                                        SortExpression="RequisitionNo" />
                                                    <asp:BoundField DataField="PurchaseDate" HeaderText="PurchaseDate" 
                                                        SortExpression="PurchaseDate" />
                                                    <asp:BoundField DataField="DeliveryDate" HeaderText="DeliveryDate" 
                                                        SortExpression="DeliveryDate" />
                                                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                                </Fields>
                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#E3EAEB" />
                                            </asp:DetailsView>
                                            <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                                                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                                SelectCommand="SELECT [DeliveryDate], [RequisitionNo], [PurchaseDate], [Title] FROM [PO] WHERE [POID] = @POID">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlPONO" Name="POID" 
                                                        PropertyName="SelectedValue" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <br />
                                            <asp:Button ID="btnDontUpdatePO" runat="server" onclick="btnDontUpdatePO_Click" 
                                                Text="Don't Update PO" Width="136px" />
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                &nbsp;</td>
                            <td class="style9">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <h2>
                        Equipment Info</h2>
                    <table class="style11">
                        <tr>
                            <td class="style9">
                                Connectivity:</td>
                            <td class="style9">
                                <asp:TextBox ID="txtBoxConnectivity" runat="server" MaxLength="45" 
                                    Width="136px"></asp:TextBox>
                            </td>
                            <td class="style9">
                                Network Capable:</td>
                            <td>
                                <asp:DropDownList ID="ddlNetworkCapable" runat="server" Width="50px">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Other:</td>
                            <td class="style9">
                                <asp:TextBox ID="txtBoxOther" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            </td>
                            <td class="style9">
                                Physical Address:</td>
                            <td>
                                <asp:TextBox ID="txtBoxPhysicalAddress" runat="server" MaxLength="20" 
                                    Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <h2>
                        Licensing</h2>
                    <asp:UpdatePanel ID="updatePanelLicensing" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnManageLicensing" runat="server" 
                                onclick="btnManageLicensing_Click" Text="ManageLicensing" Width="136px" />
                            <asp:Panel ID="panelLicensing" runat="server" Visible="False">
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
                                    SelectCommand="SELECT [LicID], [Software], [OS], [LicenseKey] FROM [Licenses] WHERE ([Type] = 'Equipment')">
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
                                    onclick="btnCancelLicensing_Click" Text="Cancel" Width="136px" />
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
                                                    Height="20px" Width="142px">
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
                                                <asp:CalendarExtender ID="txtBoxWarrantyStartDate_CalendarExtender" 
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
                                                <asp:CalendarExtender ID="txtBoxWarrantyEndDate_CalendarExtender" 
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
                                    onclick="brnCancelWarranty_Click" Text="Done" />
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
                            <asp:Panel ID="panelMaintenance" runat="server" Visible="False">
                                <table class="style8">
                                    <tr>
                                        <td class="style9">
                                            Date:</td>
                                        <td>
                                            <asp:TextBox ID="txtboxDate" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
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
                                    onclick="btnCancel_Click" Text="Cancel" Width="136px" />
                                <br />
                                <asp:Label ID="lblMaintenanceMessage" runat="server" Visible="False"></asp:Label>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <h2>
                        Notes</h2>
                    <br />
                    <p>
                        <asp:TextBox ID="txtBoxNotes" runat="server" Height="87px" MaxLength="1000" 
                            TextMode="MultiLine" Width="626px"></asp:TextBox>
                    </p>
                    <asp:UpdatePanel ID="updatePanelMessage" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnUpdateEquipment" runat="server" 
                                onclick="btnUpdateEquipment_Click" Text="Update" Width="136px" />
                            <br />
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            <br />
                            <asp:Button ID="btnClearMessage" runat="server" onclick="btnClearMessage_Click" 
                                Text="Clear" Visible="False" Width="136px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                </asp:Panel>
<br />
                <asp:Panel ID="panelGridView" runat="server" Visible="False">
                    <asp:GridView ID="GridViewEquipment" runat="server" AllowSorting="True" 
                        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="InvID,SerialNo" 
                        DataSourceID="SqlDataSourceEquipment" ForeColor="#333333" GridLines="None" 
                        onrowcreated="GridViewEquipment_RowCreated" 
                        onselectedindexchanged="GridViewEquipment_SelectedIndexChanged" 
                        ShowHeaderWhenEmpty="True" Width="1053px">
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
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Type") %>'></asp:TextBox>
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
                                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                        SelectCommand="SELECT DISTINCT Equipment.EquipmentType as Type FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')">
                                    </asp:SqlDataSource>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
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
                                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                        SelectCommand="SELECT DISTINCT Inventory.Manufacturer FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')">
                                    </asp:SqlDataSource>
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
                                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                        SelectCommand="SELECT DISTINCT Logistics.Building FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')">
                                    </asp:SqlDataSource>
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
                            <asp:TemplateField HeaderText="PrimaryUser">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("PrimaryUser") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="PrimaryUserHeaderLinkButton" runat="server" 
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
                                    <asp:LinkButton ID="StatusHeaderLinkButton" runat="server" 
                                        CausesValidation="False" Text="Status"></asp:LinkButton>
                                    <br />
                                    <asp:DropDownList ID="ddlStatusFilter" runat="server" AutoPostBack="True" 
                                        DataSourceID="SqlDataSourceStatus" DataTextField="Status" 
                                        DataValueField="Status" TabIndex="10" Width="100px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceStatus" runat="server" 
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
        <br />
        <br />
        <br />
    
    </div>
    </asp:Content>
