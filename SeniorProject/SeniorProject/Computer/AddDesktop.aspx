<%@ Page Title="RED - Add Computer" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="AddDesktop.aspx.cs" Inherits="SeniorProject.About" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 97%;
        }
        .style7
        {
            width: 100%;
        }
        .style9
        {
            width: 200px;
        }
        .style10
        {
            width: 199px;
        }
        .style11
        {
            width: 250px;
        }
        .style13
        {
        }
        .style14
        {
            width: 285px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h1>
                Add Computer(s)
                <asp:Button ID="btnAddWithTextBoxToggle" runat="server" 
                    CausesValidation="False" onclick="btnAddWithTextBoxToggle_Click" 
                    Text="Add With Text Box" Width="136px" />
            </h1>
            &nbsp;
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id = "sidebar">
    <span class="page">Service Tag/Serial No.:<br />
        <asp:UpdatePanel ID="updatePanelSerialNo" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtBoxSerialNo" runat="server" AutoPostBack="True" 
                    MaxLength="45" ontextchanged="txtBoxSerialNo_TextChanged" Width="165px"></asp:TextBox>
<br />
                <asp:Label ID="lblSerialNos" runat="server" Visible="False"></asp:Label>
<br />
                <asp:ListBox ID="lstBoxSerialNos" runat="server" Height="400px" Width="165px" 
                    SelectionMode="Multiple">
                </asp:ListBox>
                <br />
                <asp:Button ID="btnRemoveSelected" runat="server" CausesValidation="False" 
                    onclick="btnRemoveSelected_Click" Text="Remove Selected" 
                    Width="136px" />
<br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSerialNo" runat="server" 
                    ControlToValidate="lstBoxSerialNos" 
                    ErrorMessage="You must enter at least 1 service tag" ForeColor="Red"></asp:RequiredFieldValidator>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        </span><br />
    </div>

    <div id = "maincontent">
        <asp:UpdatePanel ID="updatePanelPage" runat="server">
            <ContentTemplate>
                <asp:Panel ID="panelPage" runat="server">
                    <h2>
                        General</h2>
                    <table class="style1">
                        <tr>
                            <td class="style9">
                                SMSU Tag:</td>
                            <td class="style9" style="margin-left: 40px">
                                <asp:TextBox ID="txtBoxSMSUTag" runat="server" MaxLength="45" TabIndex="2" 
                                    Width="136px"></asp:TextBox>
                            </td>
                            <td class="style9">
                                Type:</td>
                            <td>
                                <asp:DropDownList ID="ddlType" runat="server" TabIndex="3" Width="142px">
                                    <asp:ListItem>Please Select</asp:ListItem>
                                    <asp:ListItem>Computer</asp:ListItem>
                                    <asp:ListItem>Laptop</asp:ListItem>
                                    <asp:ListItem>Tablet</asp:ListItem>
                                    <asp:ListItem>Server</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                    ControlToValidate="ddlType" ErrorMessage="Please select" ForeColor="Red" 
                                    Operator="NotEqual" ValueToCompare="Please Select"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Manufacturer:</td>
                            <td class="style9">
                                <asp:DropDownList ID="ddlManufacturer" runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSource9" DataTextField="value" DataValueField="value" 
                                    Height="22px" TabIndex="4" Width="142px">
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
                                <asp:DropDownList ID="ddlStatus" runat="server" Height="22px" TabIndex="5" 
                                    Width="142px">
                                    <asp:ListItem>Active</asp:ListItem>
                                    <asp:ListItem>Storage</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Model:</td>
                            <td class="style9">
                                <asp:TextBox ID="txtBoxModel" runat="server" MaxLength="45" TabIndex="6" 
                                    Width="136px"></asp:TextBox>
                            </td>
                            <td class="style9">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <h2>
                        Logistics</h2>
                    <table class="style1">
                        <tr>
                            <td class="style9">
                                Building:</td>
                            <td class="style9" style="margin-left: 80px">
                                <asp:DropDownList ID="ddlBuilding" runat="server" DataSourceID="SqlDataSource8" 
                                    DataTextField="value" DataValueField="value" Height="21px" TabIndex="7" 
                                    Width="142px">
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
                                <asp:TextBox ID="txtBoxRoomNumber" runat="server" MaxLength="45" TabIndex="8" 
                                    Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Primary User:</td>
                            <td class="style9">
                                <asp:TextBox ID="txtBoxPrimaryUser" runat="server" MaxLength="45" TabIndex="9" 
                                    Width="136px"></asp:TextBox>
                            </td>
                            <td class="style9">
                                Name:</td>
                            <td>
                                <asp:TextBox ID="txtBoxName" runat="server" MaxLength="45" TabIndex="10" 
                                    Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <h2>
                        Purchase Info</h2>
                    <table class="style1">
                        <tr>
                            <td class="style10">
                                Purchase Price:</td>
                            <td class="style9">
                                <asp:TextBox ID="txtBoxPurchasePrice" runat="server" MaxLength="15" 
                                    TabIndex="11" Width="136px"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToValidate="txtBoxPurchasePrice" ErrorMessage="Invalid" ForeColor="Red" 
                                    Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td class="style9" rowspan="2">
                                PO No.</td>
                            <td rowspan="2">
                                <asp:UpdatePanel ID="pdatePanelPO" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlPONO" runat="server" AutoPostBack="True" 
                                            DataSourceID="SqlDataSource4" DataTextField="POno" DataValueField="POID" 
                                            Height="20px" TabIndex="12" Width="142px">
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
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style10">
                                &nbsp;</td>
                            <td class="style9">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <h2>
                        Computer Info</h2>
                    <table class="style1">
                        <tr>
                            <td class="style9">
                                CPU:</td>
                            <td class="style9">
                                <asp:TextBox ID="txtBoxCPU" runat="server" MaxLength="45" TabIndex="13" 
                                    Width="136px"></asp:TextBox>
                            </td>
                            <td class="style9" rowspan="9">
                                <asp:UpdatePanel ID="updatePanelMonitors" runat="server">
                                    <ContentTemplate>
                                        Monitor(s):<asp:ListBox ID="lstBoxMonitors" runat="server" AutoPostBack="True" 
                                            Height="57px" onselectedindexchanged="lstBoxMonitors_SelectedIndexChanged" 
                                            Width="150px"></asp:ListBox>
                                        <br />
                                        <asp:Button ID="btnRemoveMonitors" runat="server" Enabled="False" 
                                            onclick="btnRemoveMonitors_Click" Text="Remove Selected" Width="136px" />
                                        <br />
                                        Monitor Count:
                                        <asp:Label ID="lblMonitorCount" runat="server" Text="0"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnAddMonitor" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td rowspan="9">
                                <asp:UpdatePanel ID="updatePanelSelectMonitor" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlMonitor" runat="server" AutoPostBack="True" 
                                            DataSourceID="SqlDataSource1" DataTextField="Display" DataValueField="MonID" 
                                            TabIndex="22" Width="134px">
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Button ID="btnAddMonitor" runat="server" onclick="btnAddMonitor_Click" 
                                            Text="Add This Monitor" Width="134px" />
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                            SelectCommand="SELECT * FROM [Monitor]"></asp:SqlDataSource>
                                        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                                            CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" 
                                            GridLines="None" Height="50px" Width="125px">
                                            <AlternatingRowStyle BackColor="White" />
                                            <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
                                            <EditRowStyle BackColor="#7C6F57" />
                                            <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
                                            <Fields>
                                                <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" />
                                                <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                                                <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
                                                <asp:BoundField DataField="Resolution" HeaderText="Resolution" 
                                                    SortExpression="Resolution" />
                                                <asp:BoundField DataField="Connectors" HeaderText="Connectors" 
                                                    SortExpression="Connectors" />
                                            </Fields>
                                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#E3EAEB" />
                                        </asp:DetailsView>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                            SelectCommand="SELECT [Size], [Brand], [Resolution], [Connectors], [Model] FROM [Monitor] WHERE ([MonID] = @MonID)">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlMonitor" Name="MonID" 
                                                    PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Video Card:</td>
                            <td class="style9" style="margin-left: 40px">
                                <asp:TextBox ID="txtBoxVideoCard" runat="server" MaxLength="45" TabIndex="14" 
                                    Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Hard Drive:</td>
                            <td class="style9" style="margin-left: 40px">
                                <asp:TextBox ID="txtBoxHardDrive" runat="server" MaxLength="45" TabIndex="15" 
                                    Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Memory:</td>
                            <td class="style9" style="margin-left: 80px">
                                <asp:TextBox ID="txtBoxMemory" runat="server" MaxLength="45" TabIndex="16" 
                                    Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Optical Drive:</td>
                            <td class="style9" style="margin-left: 80px">
                                <asp:TextBox ID="txtBoxOpticalDrive" runat="server" MaxLength="45" 
                                    TabIndex="17" Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Removable Media:</td>
                            <td class="style9" style="margin-left: 120px">
                                <asp:TextBox ID="txtBoxRemovableMedia" runat="server" MaxLength="45" 
                                    TabIndex="18" Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                USB Ports:</td>
                            <td class="style9" style="margin-left: 120px">
                                <asp:DropDownList ID="ddlUSBports" runat="server" TabIndex="19">
                                    <asp:ListItem>0</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
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
                        </tr>
                        <tr>
                            <td class="style9">
                                Other Connectivity:</td>
                            <td class="style9" style="margin-left: 200px">
                                <asp:TextBox ID="txtBoxOtherConnectivity" runat="server" MaxLength="45" 
                                    TabIndex="20" Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Size:</td>
                            <td class="style9" style="margin-left: 200px">
                                <asp:TextBox ID="txtBoxSize" runat="server" MaxLength="45" TabIndex="21" 
                                    Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <h2>
                        Groups</h2>
                    <table class="style7">
                        <tr>
                            <td class="style9">
                                <asp:CheckBoxList ID="chkBoxListGroups1" runat="server">
                                </asp:CheckBoxList>
                            </td>
                            <td class="style9">
                                <asp:CheckBoxList ID="chkBoxListGroups2" runat="server">
                                </asp:CheckBoxList>
                            </td>
                            <td class="style9">
                                <asp:CheckBoxList ID="chkBoxListGroups3" runat="server">
                                </asp:CheckBoxList>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chkBoxListGroups4" runat="server">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="panelLicenses" runat="server">
                        <h2>
                            Licenses</h2>
                            <asp:UpdatePanel ID="updatePanelLicenses" runat="server">
                                <ContentTemplate>
                                    <table class="style7">
                                        <tr>
                                            <td class="style11">
                                                Licenses to be added:<br />
                                                <asp:ListBox ID="lstBoxLicenses" runat="server" Height="90px" Width="200px">
                                                </asp:ListBox>
                                                <br />
                                                <asp:Button ID="btnRemoveLicense" runat="server" 
                                                    onclick="btnRemoveLicense_Click" Text="Remove Selected" Width="136px" />
                                            </td>
                                            <td>
                                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="LicID,Software" 
                                                    DataSourceID="SqlDataSource6" ForeColor="#333333" GridLines="None" 
                                                    onrowcreated="GridView1_RowCreated" 
                                                    onselectedindexchanged="GridView1_SelectedIndexChanged" Width="650px">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:BoundField DataField="LicID" HeaderText="LicID" InsertVisible="False" 
                                                            ReadOnly="True" SortExpression="LicID" Visible="False" />
                                                        <asp:BoundField DataField="Software" HeaderText="Software" 
                                                            SortExpression="Software" />
                                                        <asp:BoundField DataField="OS" HeaderText="OS" SortExpression="OS" />
                                                        <asp:BoundField DataField="LicenseKey" HeaderText="LicenseKey" 
                                                            SortExpression="LicenseKey" />
                                                        <asp:BoundField DataField="NumOfCopies" HeaderText="NumOfCopies" 
                                                            SortExpression="NumOfCopies" />
                                                        <asp:BoundField DataField="ExpirationDate" HeaderText="ExpirationDate" 
                                                            SortExpression="ExpirationDate" />
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
                                                    SelectCommand="SELECT [LicID], [Software], [OS], [LicenseKey], [NumOfCopies], [ExpirationDate] FROM [Licenses] WHERE ([Type] = @Type)">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="Computer" Name="Type" Type="String" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                    </asp:Panel>
                    <h2>
                        Warranties</h2>
                    <asp:UpdatePanel ID="updatePanelWarranty" runat="server">
                        <ContentTemplate>
                            <table class="style7">
                                <tr>
                                    <td class="style11" rowspan="3">
                                        Warranties to be Added:<br />
                                        <asp:ListBox ID="lstBoxWarranties" runat="server" Height="90px" Width="200px">
                                        </asp:ListBox>
                                        <br />
                                        <asp:Button ID="btnRemoveWarranty" runat="server" CausesValidation="False" 
                                            onclick="btnRemoveWarranty_Click" Text="Remove Selected" 
                                            Width="136px" />
                                    </td>
                                    <td class="style13">
                                        Manufacturer:</td>
                                    <td class="style9">
                                        <asp:DropDownList ID="ddlWarrantyCompany" runat="server" AutoPostBack="True" 
                                            DataSourceID="SqlDataSource7" DataTextField="value" DataValueField="value" 
                                            Height="22px" Width="142px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                            SelectCommand="SELECT [value] FROM [Settings] WHERE ([type] = @type) ORDER BY [value]">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="Manufacturer" Name="type" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                    <td class="style13">
                                        Warranty Type:</td>
                                    <td>
                                        <asp:TextBox ID="txtBoxWarrantyType" runat="server" MaxLength="45" 
                                            Width="136px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style13">
                                        Start Date:</td>
                                    <td class="style9">
                                        <asp:TextBox ID="txtBoxWarrantyStartDate" runat="server" MaxLength="45" 
                                            Width="136px"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtBoxWarrantyStartDate_CalendarExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtBoxWarrantyStartDate">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txtBoxWarrantyStartDate" ErrorMessage="*" ForeColor="Red" 
                                            ValidationGroup="warranty"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="style13">
                                        End Date:</td>
                                    <td>
                                        <asp:TextBox ID="txtBoxWarrantyEndDate" runat="server" MaxLength="45" 
                                            Width="136px"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtBoxWarrantyEndDate_CalendarExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtBoxWarrantyEndDate">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
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
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <h2>
                        Notes</h2>
                    <p>
                        <asp:TextBox ID="txtBoxNotes" runat="server" Height="87px" MaxLength="1000" 
                            TextMode="MultiLine" Width="626px"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Button ID="btnAddDesktop" runat="server" onclick="btnAddDesktop_Click" 
                            Text="Add" Width="136px" />
                    </p>
                    <asp:UpdatePanel ID="updatePanelMessage" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            <br />
                            <asp:Button ID="btnClearMessage" runat="server" onclick="btnClearMessage_Click" 
                                Text="Clear" Visible="False" Width="136px" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAddDesktop" />
                        </Triggers>
                    </asp:UpdatePanel>
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
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
           
        
    </div>

</asp:Content>
