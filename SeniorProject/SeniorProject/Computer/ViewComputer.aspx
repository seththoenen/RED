<%@ Page Title="RED - View Computer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewComputer.aspx.cs" Inherits="SeniorProject.ViewComputer" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style1
        {
            width: 92%;
        }
        .style6
    {
        width: 150px;
    }
        .style8
        {
            width: 97%;
        }
        .style9
        {
            width: 200px;
        }
    .style12
    {
        width: 79%;
    }
    .style13
    {
        width: 267px;
    }
        .style14
        {
            width: 150px;
            height: 26px;
        }
        .style19
        {
            width: 144px;
            height: 26px;
        }
        .style7
        {
            width: 98%;
        }
        .style20
        {
            width: 183px;
        }
        .style21
        {
            width: 144px;
        }
        .style23
        {
            width: 112px;
        }
        .style24
        {
            width: 87px;
        }
        .style25
        {
            width: 315px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
            <asp:Label ID="lblMessage2" runat="server" Visible="False"></asp:Label>
    </p>
    <div id="left">
    <h2>
            General</h2>
    <table class="style1">
        <tr>
            <td width="150px">
                    Service Tag:</td>
            <td width="150px">
                <asp:TextBox ID="txtBoxServiceTag" runat="server" MaxLength="45" Height="20px" 
                    Width="136px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtBoxServiceTag" ErrorMessage="*" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td width="150px">
                    SMSU Tag:</td>
            <td width="150px">
                <asp:TextBox ID="txtBoxSMSUTag" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                    Manufacturer:</td>
            <td>
                            <asp:DropDownList ID="ddlManufacturer" runat="server" AutoPostBack="True" 
                                DataSourceID="SqlDataSource19" DataTextField="value" 
                                DataValueField="value" Height="20px" Width="142px">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource19" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                
                                
                                
                    SelectCommand="SELECT [value] FROM [Settings] WHERE ([type] = @type) ORDER BY [value]">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="Manufacturer" Name="type" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
            </td>
            <td>
                    Model:</td>
            <td>
                <asp:TextBox ID="txtBoxModel" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                    Type:</td>
            <td>
                <asp:DropDownList ID="ddlType" runat="server" Width="142px">
                    <asp:ListItem>Computer</asp:ListItem>
                    <asp:ListItem>Tablet</asp:ListItem>
                    <asp:ListItem>Laptop</asp:ListItem>
                    <asp:ListItem>Server</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                    Status:</td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" Height="22px" Width="142px">
                    <asp:ListItem>Active</asp:ListItem>
                    <asp:ListItem>Storage</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />


    </div>

    <div id="right">
        <h2>
            Purchase Info</h2>
    <table class="style1">
        <tr>
            <td class="style24">
                    Purchase Price:</td>
            <td class="style20">
                <asp:TextBox ID="txtBoxPurchasePrice" runat="server" MaxLength="15" 
                    Width="136px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtBoxPurchasePrice" ErrorMessage="Invalid" ForeColor="Red" 
                        Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style24">
                    PO No.</td>
            <td class="style20">
                <asp:UpdatePanel ID="updatePanelPO" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPONO" runat="server" DataSourceID="SqlDataSource4" 
                    DataTextField="POno" DataValueField="POID" Height="20px" Width="142px" 
                    AutoPostBack="True">
                            <asp:ListItem>None</asp:ListItem>
                        </asp:DropDownList>
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
                    
                    
    
                            SelectCommand="SELECT [DeliveryDate], [RequisitionNo], [PurchaseDate], [Title] FROM [PO] WHERE ([POID] = @POID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlPONO" Name="POID" 
                            PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
        <h2>
            Monitors</h2>
    <br />
        <table class="style7">
            <tr>
                <td class="style23">
                    Attached Monitors:</td>
                <td class="style25">
                    <asp:UpdatePanel ID="updatePanelSelectMonitor" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnAddMonitor" runat="server" CausesValidation="False" 
                                onclick="btnAddMonitor_Click" Text="Add a Monitor" Width="136px" />
                    <br />
                            <asp:DropDownList ID="ddlMonitor" runat="server" DataSourceID="SqlDataSource13" 
                                DataTextField="Display" DataValueField="MonID" Visible="False" 
                                Width="142px">
                            </asp:DropDownList>
                            <br />
                            <asp:Button ID="btnCancelAddMonitor" runat="server" 
                                onclick="btnCancelAddMonitor_Click" Text="Cancel" Visible="False" 
                                Width="136px" />
                            <br />
                            <asp:SqlDataSource ID="SqlDataSource13" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                SelectCommand="SELECT [MonID], [Display] FROM [Monitor]">
                            </asp:SqlDataSource>
                            <asp:ListBox ID="lstBoxMonitors" runat="server" AutoPostBack="True" 
                                DataSourceID="SqlDataSource11" DataTextField="Display" DataValueField="MonID" 
                                onselectedindexchanged="lstBoxMonitors_SelectedIndexChanged" Width="150px">
                            </asp:ListBox>
                            <br />
                            <asp:Button ID="btnRemoveMonitor" runat="server" Enabled="False" 
                                onclick="btnRemoveMonitor_Click" Text="Remove Selected" Width="136px" />
                            <br />
                            <asp:Label ID="lblMonitorMessage" runat="server" Visible="False"></asp:Label>
                            <br />
                            <asp:SqlDataSource ID="SqlDataSource11" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                SelectCommand="SELECT Monitor.Display, Monitor.MonID FROM Monitor INNER JOIN MonitorComputer ON Monitor.MonID = MonitorComputer.MonID INNER JOIN Computer ON MonitorComputer.CompID = Computer.CompID WHERE (Computer.InvID = @InvID)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="InvID" SessionField="CurrentComputer" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:DetailsView ID="DetailsView4" runat="server" AutoGenerateRows="False" 
                                CellPadding="4" DataSourceID="SqlDataSource12" ForeColor="#333333" 
                                GridLines="None" Height="50px" Width="125px">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                                <EditRowStyle BackColor="#999999" />
                                <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                                <Fields>
                                    <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" />
                                    <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                                    <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
                                    <asp:BoundField DataField="Resolution" HeaderText="Resolution" 
                                        SortExpression="Resolution" />
                                    <asp:BoundField DataField="Connectors" HeaderText="Connectors" 
                                        SortExpression="Connectors" />
                                </Fields>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            </asp:DetailsView>
                            <asp:SqlDataSource ID="SqlDataSource12" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                SelectCommand="SELECT [Size], [Brand], [Resolution], [Connectors], [Model] FROM [Monitor] WHERE ([MonID] = @MonID)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lstBoxMonitors" Name="MonID" 
                                        PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:Panel ID="panelLicenses" runat="server">
            <h2>
                Licenses</h2>
            <p>
                <table class="style12">
                    <tr>
                        <td class="style13">
                            <asp:UpdatePanel ID="updatePanelSelectLicense" runat="server">
                                <ContentTemplate>
                                    <asp:ListBox ID="lstBoxLicenses" runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSource8" DataTextField="Software" DataValueField="LicID" 
                                    Height="100px" onselectedindexchanged="lstBoxLicenses_SelectedIndexChanged" 
                                    Width="170px"></asp:ListBox>
                                    <asp:SqlDataSource ID="SqlDataSource8" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                    
                                    
                                        SelectCommand="SELECT Licenses.LicID, Licenses.Software FROM LicenseInventory INNER JOIN Licenses ON LicenseInventory.LicID = Licenses.LicID WHERE (LicenseInventory.InvID = @InvID)">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="InvID" SessionField="CurrentComputer" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:Button ID="btnAddLicense" runat="server" onclick="btnAddLicense_Click" 
                                    Text="Add a License" Width="136px" />
                                    <br />
                                    <asp:Button ID="btnRemoveLicense" runat="server" Enabled="False" 
                                    onclick="btnRemoveLicense_Click" Text="Remove Selected License" 
                                    Width="136px" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                        </td>
                        <td>
                            <asp:UpdatePanel ID="updatePanelLicenseDetails" runat="server">
                                <ContentTemplate>
                                    <asp:DetailsView ID="DetailsView3" runat="server" AutoGenerateRows="False" 
                                    CellPadding="4" DataSourceID="SqlDataSource9" ForeColor="#333333" 
                                    GridLines="None" Height="50px" Width="329px">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                                        <EditRowStyle BackColor="#999999" />
                                        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                                        <Fields>
                                            <asp:BoundField DataField="Software" HeaderText="Software" 
                                            SortExpression="Software" />
                                            <asp:BoundField DataField="OS" HeaderText="OS" SortExpression="OS" />
                                            <asp:BoundField DataField="LicenseKey" HeaderText="LicenseKey" 
                                            SortExpression="LicenseKey" />
                                            <asp:BoundField DataField="NumOfCopies" HeaderText="NumOfCopies" 
                                            SortExpression="NumOfCopies" />
                                            <asp:BoundField DataField="ExpirationDate" HeaderText="ExpirationDate" 
                                            SortExpression="ExpirationDate" />
                                            <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                                        </Fields>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    </asp:DetailsView>
                                    <asp:SqlDataSource ID="SqlDataSource9" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                    
                                    
                                        SelectCommand="SELECT [Software], [OS], [LicenseKey], [NumOfCopies], [ExpirationDate], [Notes] FROM [Licenses] WHERE LicID = @LicID">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="lstBoxLicenses" Name="LicID" 
                                            PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <asp:Panel ID="Panel2" runat="server">
                    </asp:Panel>
                </table>
            </p>
            <asp:UpdatePanel ID="ppdatePanelSelLicense" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlSelectLicense" runat="server" Visible="False">
                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataKeyNames="LicID" DataSourceID="SqlDataSource10" 
                        ForeColor="#333333" GridLines="None" onrowcreated="GridView3_RowCreated" 
                        onselectedindexchanged="GridView3_SelectedIndexChanged" Width="524px">
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
                        <asp:SqlDataSource ID="SqlDataSource10" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                        
                        
                            SelectCommand="SELECT [LicID], [Software], [OS], [LicenseKey] FROM [Licenses] WHERE ([Type] = @Type)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Computer" Name="Type" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:Button ID="btnCancelLicense" runat="server" 
                        onclick="btnCancelLicense_Click" Text="Cancel" Width="136px" />
                        <br />
                        <asp:Label ID="lblLicenseMessage" runat="server" Text="Label" Visible="False"></asp:Label>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <h2>
            Maintenance</h2>
        <asp:UpdatePanel ID="updatePanelMaintenance" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnAddMaintenance" runat="server" CausesValidation="False" 
                    onclick="btnAddMaintenance_Click" Text="Add Maintenance" Width="136px" />
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <table class="style8">
                        <tr>
                            <td class="style9">
                                Date:</td>
                            <td>
                                <asp:TextBox ID="txtBoxDate" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtBoxDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtBoxDate">
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
                                    TextMode="MultiLine" Width="300px" MaxLength="1000"></asp:TextBox>
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
        <asp:UpdatePanel ID="updatePanelMaintDetail" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MaintID" 
                    DataSourceID="SqlDataSource6" ForeColor="#333333" GridLines="None" 
                    onrowcreated="GridView1_RowCreated" style="margin-top: 19px" Width="531px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="MaintID" HeaderText="MaintID" InsertVisible="False" 
                            ReadOnly="True" SortExpression="MaintID" Visible="False" />
                        <asp:BoundField DataField="InvID" HeaderText="InvID" SortExpression="InvID" 
                            Visible="False" />
                        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                        <asp:BoundField DataField="Maintenance" HeaderText="Maintenance" 
                            SortExpression="Maintenance" />
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
                    ConflictDetection="CompareAllValues" 
                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                    DeleteCommand="DELETE FROM [Maintenance] WHERE [id] = @original_id AND [CompID] = @original_CompID AND [Date] = @original_Date AND [Maintenance] = @original_Maintenance" 
                    InsertCommand="INSERT INTO [Maintenance] ([CompID], [Date], [Maintenance]) VALUES (@CompID, @Date, @Maintenance)" 
                    OldValuesParameterFormatString="original_{0}" 
                    SelectCommand="SELECT * FROM [Maintenance] WHERE ([InvID] = @InvID) ORDER BY [MaintID] DESC" 
                    UpdateCommand="UPDATE [Maintenance] SET [CompID] = @CompID, [Date] = @Date, [Maintenance] = @Maintenance WHERE [id] = @original_id AND [CompID] = @original_CompID AND [Date] = @original_Date AND [Maintenance] = @original_Maintenance">
                    <DeleteParameters>
                        <asp:Parameter Name="original_id" Type="Int32" />
                        <asp:Parameter Name="original_CompID" Type="Int32" />
                        <asp:Parameter Name="original_Date" Type="String" />
                        <asp:Parameter Name="original_Maintenance" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CompID" Type="Int32" />
                        <asp:Parameter Name="Date" Type="String" />
                        <asp:Parameter Name="Maintenance" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:SessionParameter Name="InvID" SessionField="CurrentComputer" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CompID" Type="Int32" />
                        <asp:Parameter Name="Date" Type="String" />
                        <asp:Parameter Name="Maintenance" Type="String" />
                        <asp:Parameter Name="original_id" Type="Int32" />
                        <asp:Parameter Name="original_CompID" Type="Int32" />
                        <asp:Parameter Name="original_Date" Type="String" />
                        <asp:Parameter Name="original_Maintenance" Type="String" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    <br />
    </div>
    <div id ="left">
    
    <h2>
        Logistics</h2>
    <table class="style1">
        <tr>
            <td class="style6">
                    Building:</td>
            <td style="margin-left: 80px" class="style6">
                <asp:DropDownList ID="ddlBuilding" runat="server" 
                    datasourceid="SqlDataSource17" DataTextField="value" DataValueField="value" 
                    Height="22px" Width="142px">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource17" runat="server" 
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
                Computer
                Name:</td>
            <td>
                <asp:TextBox ID="txtBoxName" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="updatePanelHistory" runat="server">
        <ContentTemplate>
            <asp:Button ID="btnLogistics" runat="server" onclick="btnLogistics_Click" 
                Text="Show/Hide History" Width="136px" />
    <br />
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource7" 
                ForeColor="#333333" GridLines="None" Visible="False" Width="680px" 
                onrowcreated="GridView2_RowCreated">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Building" HeaderText="Building" 
                        SortExpression="Building" />
                    <asp:BoundField DataField="Room" HeaderText="Room" SortExpression="Room" />
                    <asp:BoundField DataField="PrimaryUser" HeaderText="PrimaryUser" 
                        SortExpression="PrimaryUser" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="StartDate" HeaderText="StartDate" 
                        SortExpression="StartDate" />
                    <asp:BoundField DataField="EndDate" HeaderText="EndDate" 
                        SortExpression="EndDate" />
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
                SelectCommand="SELECT [Building], [Room], [PrimaryUser], [Name], [StartDate], [EndDate] FROM [Logistics] WHERE (([Status] = 'Inactive') AND ([InvID] = @InvID)) ORDER BY [LogID] DESC">
                <SelectParameters>
                    <asp:SessionParameter Name="InvID" SessionField="CurrentComputer" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <h2>
                Computer Info</h2>
            <table class="style1">
                <tr>
                    <td class="style6">
                        CPU:</td>
                    <td class="style21">
                        <asp:TextBox ID="txtBoxCPU" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                    </td>
                    <td class="style21">
                        Hard Drive:</td>
                    <td class="style21">
                        <asp:TextBox ID="txtBoxHardDrive" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        Optical Drive:</td>
                    <td class="style21" style="margin-left: 40px">
                        <asp:TextBox ID="txtBoxOpticalDrive" runat="server" MaxLength="45" 
                            Width="136px"></asp:TextBox>
                    </td>
                    <td class="style21" style="margin-left: 40px">
                        USB Ports:</td>
                    <td class="style21" style="margin-left: 40px">
                        <asp:DropDownList ID="ddlUSBPorts" runat="server">
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
                    <td class="style14">
                        Size:</td>
                    <td class="style19" style="margin-left: 80px">
                        <asp:TextBox ID="txtBoxSize" runat="server" Width="136px"></asp:TextBox>
                    </td>
                    <td class="style19" style="margin-left: 80px">
                        Video Card:</td>
                    <td class="style19" style="margin-left: 80px">
                        <asp:TextBox ID="txtBoxVideoCard" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        Memory:</td>
                    <td class="style21" style="margin-left: 120px">
                        <asp:TextBox ID="txtBoxMemory" runat="server" Width="136px"></asp:TextBox>
                    </td>
                    <td class="style21" style="margin-left: 120px">
                        Removable Media:</td>
                    <td class="style21" style="margin-left: 120px">
                        <asp:TextBox ID="txtBoxRemovableMedia" runat="server" Width="136px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style14">
                        Other Connectivity:</td>
                    <td class="style19" style="margin-left: 200px">
                        <asp:TextBox ID="txtBoxOtherConnectivity" runat="server" MaxLength="45" 
                            Width="136px"></asp:TextBox>
                    </td>
                    <td class="style19" style="margin-left: 200px">
                        Physical Address:</td>
                    <td class="style19" style="margin-left: 200px">
                        <asp:TextBox ID="txtBoxPhysicalAddress" runat="server" MaxLength="20" 
                            Width="136px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
        <h2>
            Groups&nbsp;
        </h2>
        <table class="style8" style="vertical-align:top">
            <tr>
                <td class="style9">
                    <asp:UpdatePanel ID="pdatePanelGroups" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnGoToGroup" runat="server" Enabled="False" 
                                onclick="btnGoToGroup_Click" Text="Go To Group" Width="136px" />
                <br />
                            <asp:ListBox ID="lstBoxGroups" runat="server" AutoPostBack="True" 
                                DataSourceID="SqlDataSource14" DataTextField="Name" DataValueField="GroupId" 
                                Height="134px" onselectedindexchanged="lstBoxGroups_SelectedIndexChanged" 
                                Width="136px"></asp:ListBox>
                        <br />
                            <asp:SqlDataSource ID="SqlDataSource14" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                SelectCommand="SELECT Groups.Name, Groups.GroupId FROM GroupInventory INNER JOIN Groups ON GroupInventory.GroupID = Groups.GroupId WHERE (GroupInventory.InvID = @InvID)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="InvID" SessionField="CurrentComputer" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:Button ID="btnEditGroups" runat="server" onclick="btnEditGroups_Click" 
                                Text="Edit Groups" Width="136px" />
                        <br />
                            <asp:Button ID="btnUpdateGroups" runat="server" onclick="btnUpdateGroups_Click" 
                                Text="Update Groups" Visible="False" Width="136px" />
                            <asp:Button ID="btnCancelEditGroups" runat="server" CausesValidation="False" 
                                onclick="btnCancelEditGroups_Click" Text="Cancel" Visible="False" 
                                Height="26px" Width="136px" />
                        <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style6">
                    <asp:UpdatePanel ID="updatePanelGroups1" runat="server">
                        <ContentTemplate>
                            <asp:CheckBoxList ID="chkBoxLstGroups1" runat="server" Visible="False">
                            </asp:CheckBoxList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style6">
                    <asp:UpdatePanel ID="updatePanelGroups2" runat="server">
                        <ContentTemplate>
                            <asp:CheckBoxList ID="chkBoxLstGroups2" runat="server" Visible="False">
                            </asp:CheckBoxList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style6">
                    <asp:UpdatePanel ID="updatePanelGroups3" runat="server">
                        <ContentTemplate>
                            <asp:CheckBoxList ID="chkBoxLstGroups3" runat="server" Visible="False">
                            </asp:CheckBoxList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style6">
                    <asp:UpdatePanel ID="updatePanelGroups4" runat="server">
                        <ContentTemplate>
                            <asp:CheckBoxList ID="chkBoxLstGroups4" runat="server" Visible="False">
                            </asp:CheckBoxList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <h2>
            Warranties</h2>
        <asp:UpdatePanel ID="updatePanelWarranty" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnAddWarranty" runat="server" onclick="btnAddWarranty_Click1" 
                    Text="Add a Warranty" Width="136px" />
            <br />
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataKeyNames="WarID,InvID" DataSourceID="SqlDataSource15" 
                    ForeColor="#333333" GridLines="None" onrowcreated="GridView4_RowCreated" 
                    Width="680px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="WarID" HeaderText="WarID" InsertVisible="False" 
                            ReadOnly="True" SortExpression="WarID" Visible="False" />
                        <asp:BoundField DataField="InvID" HeaderText="InvID" SortExpression="InvID" 
                            Visible="False" />
                        <asp:TemplateField HeaderText="Company" SortExpression="Company">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Company") %>' 
                                    Width="100px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Company") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="StartDate" SortExpression="StartDate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("StartDate") %>' 
                                    Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="TextBox1">
                                </asp:CalendarExtender>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("StartDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EndDate" SortExpression="EndDate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("EndDate") %>' 
                                    Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="TextBox2">
                                </asp:CalendarExtender>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("EndDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WarrantyType" SortExpression="WarrantyType">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("WarrantyType") %>' 
                                    Width="100px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("WarrantyType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Notes" SortExpression="Notes">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Notes") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Notes") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
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
                <asp:SqlDataSource ID="SqlDataSource15" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                    DeleteCommand="DELETE FROM [Warranty] WHERE [WarID] = @WarID" 
                    InsertCommand="INSERT INTO [Warranty] ([InvID], [Company], [StartDate], [EndDate], [WarrantyType], [Notes]) VALUES (@InvID, @Company, @StartDate, @EndDate, @WarrantyType, @Notes)" 
                    SelectCommand="SELECT * FROM [Warranty] WHERE ([InvID] = @InvID)" 
                    UpdateCommand="UPDATE [Warranty] SET [InvID] = @InvID, [Company] = @Company, [StartDate] = @StartDate, [EndDate] = @EndDate, [WarrantyType] = @WarrantyType, [Notes] = @Notes WHERE [WarID] = @WarID">
                    <DeleteParameters>
                        <asp:Parameter Name="WarID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="InvID" Type="Int32" />
                        <asp:Parameter Name="Company" Type="String" />
                        <asp:Parameter Name="StartDate" Type="String" />
                        <asp:Parameter Name="EndDate" Type="String" />
                        <asp:Parameter Name="WarrantyType" Type="String" />
                        <asp:Parameter Name="Notes" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:SessionParameter Name="InvID" SessionField="CurrentComputer" 
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="InvID" Type="Int32" />
                        <asp:Parameter Name="Company" Type="String" />
                        <asp:Parameter Name="StartDate" Type="String" />
                        <asp:Parameter Name="EndDate" Type="String" />
                        <asp:Parameter Name="WarrantyType" Type="String" />
                        <asp:Parameter Name="Notes" Type="String" />
                        <asp:Parameter Name="WarID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            <br />
                <asp:Panel ID="panelWarranty" runat="server" Visible="False">
                    <table class="style7">
                        <tr>
                            <td class="style13">
                                Company:</td>
                            <td class="style9">
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="txtBoxWarrantyEndDate" ErrorMessage="*" ForeColor="Red" 
                                    ValidationGroup="warranty"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13" colspan="4">
                                Notes:
                                <asp:TextBox ID="txtBoxWarrantyNotes" runat="server" Height="50px" 
                                    TextMode="MultiLine" Width="600px"></asp:TextBox>
                            <br />
                            <br />
                                <asp:Button ID="btnAddWarranty0" runat="server" onclick="btnAddWarranty_Click" 
                                    style="height: 26px" Text="Add Warranty" ValidationGroup="warranty" 
                                    Width="136px" />
                                &nbsp;<asp:Button ID="brnCancelWarranty" runat="server" 
                                    onclick="brnCancelWarranty_Click" Text="Cancel" Width="136px" />
                            <br />
                                <asp:Label ID="lblWarrantyMessage" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <h2>
                    Notes</h2>
                <p>
                    <asp:TextBox ID="txtBoxNotes" runat="server" Height="87px" TextMode="MultiLine" 
                        Width="626px"></asp:TextBox>
                </p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnUpdateDesktop" runat="server" 
                            onclick="btnUpdateDesktop_Click" Text="Update" Width="136px" />
                        <br />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        <br />
                        <asp:Button ID="btnClear" runat="server" onclick="btnClear_Click" Text="Clear" 
                            Visible="False" Width="136px" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUpdateDesktop" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
<br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    <br />
    </div>





    </asp:Content>
