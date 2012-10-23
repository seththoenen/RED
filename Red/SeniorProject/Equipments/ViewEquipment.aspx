<%@ Page Title="RED - View Equipment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewEquipment.aspx.cs" Inherits="SeniorProject.Equipments.ViewEquipment" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">


        .style1
        {
            width: 98%;
        }
        .style11
    {
        width: 96%;
    }
        .style12
        {
            width: 97%;
        }
        .style13
        {
            width: 290px;
        }
        .style14
        {
            width: 150px;
        }
        .style7
        {
            width: 100%;
        }
        .style16
        {
            width: 100px;
        }
        .style17
        {
            width: 130px;
        }
        .style18
        {
            width: 140px;
        }
        .style19
        {
            width: 154px;
        }
        .style20
        {
            width: 127px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="left">
    
        <h2>
            General</h2>
    <table class="style1">
        <tr>
            <td class="style14">
                    Serial Number:</td>
            <td class="style14" style="margin-left: 40px">
                <asp:TextBox ID="txtBoxSerialNo" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
            </td>
            <td class="style14">
                    SMSU Tag:</td>
            <td class="style14">
                <asp:TextBox ID="txtBoxSMSUTag" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style14">
                    Manufacturer:</td>
            <td class="style14">
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
            <td class="style14">
                    Type:</td>
            <td class="style14">
                <asp:DropDownList ID="ddlType" runat="server" Width="142px">
                    <asp:ListItem Value="Printer">Printer</asp:ListItem>
                    <asp:ListItem>Projector</asp:ListItem>
                    <asp:ListItem>PDA</asp:ListItem>
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                        ControlToValidate="ddlType" ErrorMessage="*" ForeColor="Red" 
                        Operator="NotEqual" ValueToCompare="Please Select"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style14">
                    Model:</td>
            <td class="style14">
                <asp:TextBox ID="txtBoxModel" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
            </td>
            <td class="style14">
                    Status:</td>
            <td class="style14">
                <asp:DropDownList ID="ddlStatus" runat="server" Height="22px" Width="142px">
                    <asp:ListItem>Active</asp:ListItem>
                    <asp:ListItem>Storage</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    
        <h2>
            Logistics</h2>
        <table class="style1">
            <tr>
                <td class="style14">
                    Building:</td>
                <td class="style14" style="margin-left: 80px">
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
                <td class="style14">
                    Room Number:</td>
                <td class="style14">
                    <asp:TextBox ID="txtBoxRoomNumber" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style14">
                    Primary User:</td>
                <td class="style14">
                    <asp:TextBox ID="txtBoxPrimaryUser" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                </td>
                <td class="style14">
                    Name:</td>
                <td class="style14">
                    <asp:TextBox ID="txtBoxName" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="updatePanelLogistics" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnShowHideLogistics" runat="server" 
                    onclick="btnShowHideLogistics_Click" Text="Show/Hide Logistics" 
                    Width="136px" />
            <br />
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource6" 
                    ForeColor="#333333" GridLines="None" onrowcreated="GridView1_RowCreated" 
                    Visible="False" Width="683px">
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
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                    SelectCommand="SELECT [Building], [Room], [PrimaryUser], [Name], [StartDate], [EndDate] FROM [Logistics] WHERE (([Status] = @Status) AND ([InvID] = @InvID))">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Inactive" Name="Status" Type="String" />
                        <asp:SessionParameter Name="InvID" SessionField="CurrentEquipment" 
                            Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    
        <h2>
            Equipment Info</h2>
        <table class="style11">
            <tr>
                <td class="style14">
                    Connectivity:</td>
                <td class="style14">
                    <asp:TextBox ID="txtBoxConnectivity" runat="server" MaxLength="45" 
                        Width="136px"></asp:TextBox>
                </td>
                <td class="style14">
                    Network Capable:</td>
                <td class="style20">
                    <asp:DropDownList ID="ddlNetworkCapable" runat="server" 
                        Width="50px">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style14">
                    Other:</td>
                <td class="style14">
                    <asp:TextBox ID="txtBoxOther" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                </td>
                <td class="style14">
                    Physical Address:</td>
                <td class="style20">
                    <asp:TextBox ID="txtBoxPhysicalAddress" runat="server" MaxLength="20" 
                        Width="136px"></asp:TextBox>
                </td>
            </tr>
        </table>
    
        <h2>
            Groups</h2>
        <asp:UpdatePanel ID="updatePanelGroups" runat="server">
            <ContentTemplate>
                <table class="style12">
                    <tr>
                        <td class="style17">
                            <asp:Button ID="btnGoToGroup" runat="server" Enabled="False" 
                                Text="Go To Group" Width="136px" />
                        <br />
                            <asp:ListBox ID="lstBoxGroups" runat="server" DataSourceID="SqlDataSource11" 
                                DataTextField="Name" DataValueField="GroupId" Height="150px" Width="125px">
                            </asp:ListBox>
                            <asp:SqlDataSource ID="SqlDataSource11" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                SelectCommand="SELECT Groups.GroupId, Groups.Name FROM GroupInventory INNER JOIN Groups ON GroupInventory.GroupID = Groups.GroupId WHERE (GroupInventory.InvID = @InvID)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="InvID" SessionField="CurrentEquipment" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:Button ID="btnEditGroups" runat="server" onclick="btnEditGroups_Click" 
                                Text="Edit Groups" Width="136px" />
                        <br />
                            <asp:Button ID="btnUpdateGroups" runat="server" onclick="btnUpdateGroups_Click" 
                                Text="Update Groups" Visible="False" Width="136px" />
                            &nbsp;<asp:Button ID="btnUpdateGroupsCancel" runat="server" 
                                onclick="btnUpdateGroupsCancel_Click" Text="Cancel" Visible="False" 
                                Width="136px" />
                        <br />
                            <asp:Label ID="lblGroupMessage" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td class="style18">
                            <asp:CheckBoxList ID="chkBoxLstGroups1" runat="server" Visible="False">
                            </asp:CheckBoxList>
                        </td>
                        <td class="style18">
                            <asp:CheckBoxList ID="chkBoxLstGroups2" runat="server" Visible="False">
                            </asp:CheckBoxList>
                        </td>
                        <td class="style18">
                            <asp:CheckBoxList ID="chkBoxLstGroups3" runat="server" Visible="False">
                            </asp:CheckBoxList>
                        </td>
                        <td>
                            <asp:CheckBoxList ID="chkBoxLstGroups4" runat="server" Visible="False">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    
        <h2>
            Warranties</h2>
        <asp:UpdatePanel ID="updatePanelWarranty" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnAddWarranty" runat="server" onclick="btnAddWarranty_Click1" 
                    Text="Add a Warranty" Width="136px" />
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataKeyNames="WarID,InvID" DataSourceID="SqlDataSource15" 
                    ForeColor="#333333" GridLines="None" Width="680px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="WarID" HeaderText="WarID" InsertVisible="False" 
                            ReadOnly="True" SortExpression="WarID" Visible="False" />
                        <asp:BoundField DataField="InvID" HeaderText="InvID" SortExpression="InvID" 
                            Visible="False" />
                        <asp:TemplateField HeaderText="Company" SortExpression="Company">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" MaxLength="49" 
                                    Text='<%# Bind("Company") %>' Width="65px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Company") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="StartDate" SortExpression="StartDate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" MaxLength="49" 
                                    Text='<%# Bind("StartDate") %>' Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="TextBox2">
                                </asp:CalendarExtender>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("StartDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EndDate" SortExpression="EndDate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" MaxLength="49" 
                                    Text='<%# Bind("EndDate") %>' Width="75px"></asp:TextBox>
                                <asp:CalendarExtender ID="TextBox3_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="TextBox3">
                                </asp:CalendarExtender>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("EndDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WarrantyType" SortExpression="WarrantyType">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" MaxLength="49" 
                                    Text='<%# Bind("WarrantyType") %>' Width="100px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("WarrantyType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Notes" SortExpression="Notes">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" MaxLength="1000" 
                                    Text='<%# Bind("Notes") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Notes") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Update" ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="lnkBtnUpdate" runat="server" CausesValidation="True" 
                                    CommandName="Update" SkinID="Blue" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="lnkBtnCancel" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" SkinID="Blue" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkBtnEdit" runat="server" CausesValidation="False" 
                                    CommandName="Edit" SkinID="Blue" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkBtnDelete" runat="server" CausesValidation="False" 
                                    CommandName="Delete" SkinID="Blue" Text="Delete"></asp:LinkButton>
                                <asp:ConfirmButtonExtender ID="lnkBtnDelete_ConfirmButtonExtender" 
                                    runat="server" ConfirmText="Are you sure you want to delete this warranty?" Enabled="True" TargetControlID="lnkBtnDelete">
                                </asp:ConfirmButtonExtender>
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
            <br />
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
                        <asp:SessionParameter Name="InvID" SessionField="CurrentEquipment" 
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
                            <td class="style16">
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
                            <td class="style14">
                                Warranty Type:</td>
                            <td>
                                <asp:TextBox ID="txtBoxWarrantyType" runat="server" MaxLength="45" 
                                    Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style16">
                                Start Date:</td>
                            <td class="style14">
                                <asp:TextBox ID="txtBoxWarrantyStartDate" runat="server" MaxLength="45" 
                                    Width="136px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtBoxWarrantyStartDate_CalendarExtender" 
                                    runat="server" Enabled="True" TargetControlID="txtBoxWarrantyStartDate">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtBoxWarrantyStartDate" ErrorMessage="*" ForeColor="Red" 
                                    ValidationGroup="warranty"></asp:RequiredFieldValidator>
                            </td>
                            <td class="style14">
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
                                    TextMode="MultiLine" Width="502px" MaxLength="1000"></asp:TextBox>
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
<br />
            
                <asp:TextBox ID="txtBoxNotes" runat="server" Height="100px" 
                    TextMode="MultiLine" Width="671px" MaxLength="1000"></asp:TextBox>
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnUpdateEquipment" runat="server" 
                            onclick="btnUpdateEquipment_Click" Text="Update" Width="136px" />
                        <br />
                        <br />
                        <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="btnClearMessage" runat="server" Text="Clear" Visible="False" 
                            Width="136px" />
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
<br />
            </ContentTemplate>
        </asp:UpdatePanel>
    
        <br />
        <br />
    
    
    
    </div>

    <div id="right">
    
    
        <h2>
        Purchase Info              <td class="style14">
                   Purchase Price</td>
              <td>
              <asp:TextBox ID="txtBoxPurchasePrice" runat="server" MaxLength="15" Width="136px"></asp:TextBox>

                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtBoxPurchasePrice" ErrorMessage="Invalid" ForeColor="Red" 
                        Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style14">
                    PO No.</td>
                <td>
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
        </table>
    
    
        <asp:Panel ID="panelLicenses" runat="server">
            <h2>
                Licenses</h2>
            <asp:UpdatePanel ID="updatePanelLicenses" runat="server">
                <ContentTemplate>
                    <table class="style12">
                        <tr>
                            <td class="style13">
                                <asp:ListBox ID="lstBoxLicenses" runat="server" AutoPostBack="True" 
                                DataSourceID="SqlDataSource8" DataTextField="Software" DataValueField="LicID" 
                                Height="100px" onselectedindexchanged="lstBoxLicenses_SelectedIndexChanged" 
                                Width="200px"></asp:ListBox>
                                <asp:SqlDataSource ID="SqlDataSource8" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                
                                
                                    SelectCommand="SELECT Licenses.Software, Licenses.LicID FROM LicenseInventory INNER JOIN Licenses ON LicenseInventory.LicID = Licenses.LicID WHERE (LicenseInventory.InvID = @InvID)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="InvID" SessionField="CurrentEquipment" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:Button ID="btnAddLicense" runat="server" onclick="btnAddLicense_Click" 
                                Text="Add a License" Width="136px" />
                                <br />
                                <asp:Button ID="btnRemoveSelectedLicense" runat="server" Enabled="False" 
                                onclick="btnRemoveSelectedLicense_Click" Text="Remove Selected" 
                                Width="136px" />
                            </td>
                            <td>
                                <asp:DetailsView ID="DetailsView3" runat="server" AutoGenerateRows="False" 
                                CellPadding="4" DataSourceID="SqlDataSource9" ForeColor="#333333" 
                                GridLines="None" Height="50px" Width="307px">
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
                                
                                
                                    SelectCommand="SELECT [Software], [OS], [LicenseKey], [NumOfCopies], [ExpirationDate], [Notes] FROM [Licenses] WHERE ([LicID] = @LicID)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lstBoxLicenses" Name="LicID" 
                                        PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataKeyNames="LicID" DataSourceID="SqlDataSource10" 
                    ForeColor="#333333" GridLines="None" onrowcreated="GridView3_RowCreated" 
                    onselectedindexchanged="GridView3_SelectedIndexChanged" Visible="False" 
                    Width="532px">
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
                            <asp:Parameter DefaultValue="Equipment" Name="Type" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:Button ID="btnLicenseCancel" runat="server" CausesValidation="False" 
                    onclick="btnLicenseCancel_Click" Text="Cancel" Visible="False" Width="136px" />
                    <br />
                    <asp:Label ID="lblLicenseMessage" runat="server" Visible="False"></asp:Label>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    
    
        
    
    
        <h2>
            Maintenance</h2>
        <asp:UpdatePanel ID="updatePanelMaintenance" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnAddMaintenance" runat="server" 
                    onclick="btnAddMaintenance_Click" Text="Add Maintenance" Width="136px" />
            <br />
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource7" 
                    ForeColor="#333333" GridLines="None" onrowcreated="GridView2_RowCreated" 
                    Width="528px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
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
                <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                    SelectCommand="SELECT [Date], [Maintenance] FROM [Maintenance] WHERE ([InvID] = @InvID) ORDER BY [MaintID] DESC">
                    <SelectParameters>
                        <asp:SessionParameter Name="InvID" SessionField="CurrentEquipment" 
                            Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            <br />
                <asp:Panel ID="panelAddMaintenance" runat="server" Visible="False" 
                    Width="517px">
                    <table class="style12">
                        <tr>
                            <td class="style19">
                                Date:</td>
                            <td>
                                <asp:TextBox ID="txtBoxMaintDate" runat="server" Width="136px" MaxLength="45"></asp:TextBox>
                                <asp:CalendarExtender ID="txtBoxMaintDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtBoxMaintDate">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="style19">
                                Maintenance Perfromed:</td>
                            <td>
                                <asp:TextBox ID="txtBoxMaintDescription" runat="server" Height="100px" 
                                    TextMode="MultiLine" Width="300px" MaxLength="1000"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="btnInsertMaintenance" runat="server" 
                        onclick="btnInsertMaintenance_Click" Text="Add Maintenance" 
                        Width="136px" />
                    &nbsp;<asp:Button ID="btnDoneMaintenance" runat="server" 
                        onclick="btnDoneMaintenance_Click" Text="Done" Width="136px" />
                <br />
                    <asp:Label ID="lblMaintenanceMessage" runat="server" Visible="False"></asp:Label>
                <br />
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    
        
    
    
        <br />
        <br />
    
    
    </div>

    
    
    
    
    
    
    
</asp:Content>
