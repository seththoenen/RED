<%@ Page Title="RED - Add Equipment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEquipment.aspx.cs" Inherits="SeniorProject.AddEquipment" %>
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
        .style12
        {
            width: 100%;
        }
        .style13
        {
            width: 250px;
        }
        .style7
        {
            width: 100%;
        }
        .style16
        {
            width: 150px;
        }
        .style20
        {
            width: 149px;
        }
        .style22
        {
            width: 237px;
        }
        .style14
        {
            width: 285px;
        }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updatePanelTop" runat="server">
        <ContentTemplate>
            <h1>
                Add Equipment
                <asp:Button ID="btnAddWithTextBoxToggle" runat="server" 
                    CausesValidation="False" onclick="btnAddWithTextBoxToggle_Click" 
                    Text="Add With Text Box" Width="136px" />
            </h1>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="sidebar">
    
        <asp:UpdatePanel ID="updatePanelSerialNo" runat="server">
            <ContentTemplate>
                Serial No:<br />
                <asp:TextBox ID="txtBoxSerialNo" runat="server" AutoPostBack="True" 
                    MaxLength="45" ontextchanged="txtBoxSerialNo_TextChanged" Width="164px" 
                    Height="19px"></asp:TextBox>
<br />
                <asp:Label ID="lblSerialNos" runat="server" Visible="False"></asp:Label>
<br />
                <asp:ListBox ID="lstBoxSerialNos" runat="server" Height="400px" 
                    SelectionMode="Multiple" Width="165px"></asp:ListBox>
                <br />
                <span class="page">
                <asp:Button ID="btnRemoveSelected" runat="server" CausesValidation="False" 
                    onclick="btnRemoveSelected_Click" Text="Remove Selected" 
                    Width="136px" />
                </span>
<br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSerialNo" runat="server" 
                    ControlToValidate="lstBoxSerialNos" 
                    ErrorMessage="You must enter at least 1 serial no" ForeColor="Red"></asp:RequiredFieldValidator>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    
    </div>

    <div id="maincontent">
    
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
                                <asp:TextBox ID="txtBoxSMSUTag" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            </td>
                            <td class="style9">
                                Type:</td>
                            <td>
                                <asp:DropDownList ID="ddlType" runat="server" Width="142px">
                                    <asp:ListItem>Please Select</asp:ListItem>
                                    <asp:ListItem Value="Printer">Printer</asp:ListItem>
                                    <asp:ListItem>Projector</asp:ListItem>
                                    <asp:ListItem>PDA</asp:ListItem>
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
                                <asp:TextBox ID="txtBoxRoomNumber" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Primary User:</td>
                            <td class="style9">
                                <asp:TextBox ID="txtBoxPrimaryUser" runat="server" MaxLength="45"></asp:TextBox>
                            </td>
                            <td class="style9">
                                Name:</td>
                            <td>
                                <asp:TextBox ID="txtBoxName" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
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
                                <asp:TextBox ID="txtBoxConnectivity" runat="server" Height="20px" 
                                    MaxLength="45" Width="136px"></asp:TextBox>
                            </td>
                            <td class="style9">
                                Network Capable:</td>
                            <td>
                                <asp:DropDownList ID="ddlNetworkCapable" runat="server" Width="50px">
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
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <h2>
                        Groups</h2>
                    <table class="style12">
                        <tr>
                            <td>
                                <asp:CheckBoxList ID="chkBoxListGroups1" runat="server">
                                </asp:CheckBoxList>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chkBoxListGroups2" runat="server">
                                </asp:CheckBoxList>
                            </td>
                            <td>
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
                                <table class="style12">
                                    <tr>
                                        <td class="style13">
                                            Licenses to be added:<br />
                                            <asp:ListBox ID="lstBoxLicenses" runat="server" Height="100px" Width="200px">
                                            </asp:ListBox>
                                            <br />
                                            <asp:Button ID="btnRemoveLicense" runat="server" CausesValidation="False" 
                                                onclick="btnRemoveLicense_Click" Text="Remove Selected" Width="136px" />
                                        </td>
                                        <td>
                                            <asp:GridView ID="GridView4" runat="server" AllowPaging="True" 
                                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="LicID,Software" 
                                                DataSourceID="SqlDataSource11" ForeColor="#333333" GridLines="None" 
                                                onrowcreated="GridView4_RowCreated" 
                                                onselectedindexchanged="GridView4_SelectedIndexChanged" Width="701px">
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
                                                    <asp:CommandField ShowSelectButton="True" Visible="False" />
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
                                            <asp:SqlDataSource ID="SqlDataSource11" runat="server" 
                                                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                                SelectCommand="SELECT [LicID], [Software], [OS], [LicenseKey], [NumOfCopies], [ExpirationDate] FROM [Licenses] WHERE ([Type] = @Type)">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Equipment" Name="Type" Type="String" />
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
                                    <td class="style22" rowspan="3">
                                        Warranties to be Added:<br />
                                        <asp:ListBox ID="lstBoxWarranties" runat="server" Height="90px" Width="200px">
                                        </asp:ListBox>
                                        <br />
                                        <asp:Button ID="btnRemoveWarranty" runat="server" CausesValidation="False" 
                                            onclick="btnRemoveWarranty_Click" Text="Remove Selected" 
                                            Width="136px" />
                                    </td>
                                    <td class="style16">
                                        Company:</td>
                                    <td class="style16">
                                        <asp:DropDownList ID="ddlWarrantyCompany" runat="server" AutoPostBack="True" 
                                            DataSourceID="SqlDataSource12" DataTextField="value" DataValueField="value" 
                                            Height="20px" Width="142px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource12" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                            SelectCommand="SELECT [value] FROM [Settings] WHERE ([type] = @type) ORDER BY [value]">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="Manufacturer" Name="type" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                    <td class="style20">
                                        Warranty Type:</td>
                                    <td class="style9">
                                        <asp:TextBox ID="txtBoxWarrantyType" runat="server" MaxLength="45" 
                                            Width="136px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style16">
                                        Start Date:</td>
                                    <td class="style16">
                                        <asp:TextBox ID="txtBoxWarrantyStartDate" runat="server" MaxLength="45" 
                                            Width="136px"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtBoxWarrantyStartDate_CalendarExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtBoxWarrantyStartDate">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txtBoxWarrantyStartDate" ErrorMessage="*" ForeColor="Red" 
                                            ValidationGroup="warranty"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="style20">
                                        End Date:</td>
                                    <td class="style9">
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
                                            MaxLength="1000" Width="600px"></asp:TextBox>
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
                    <br />
                    <asp:TextBox ID="txtBoxNotes" runat="server" Height="100px" MaxLength="1000" 
                        TextMode="MultiLine" Width="760px"></asp:TextBox>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnAddEquipment" runat="server" onclick="btnAddEquipment_Click" 
                                Text="Add" Width="136px" />
                            <br />
                            <br />
                            <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="btnClearMessage" runat="server" onclick="btnClearMessage_Click" 
                                Text="Clear" Visible="False" Width="136px" />
                            <br />
                        </ContentTemplate>
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
<br />
<br />
<br />
<br />
<br />
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
</asp:Content>
