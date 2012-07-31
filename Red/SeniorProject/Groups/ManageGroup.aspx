<%@ Page Title="RED - Manage Computer Group" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageGroup.aspx.cs" Inherits="SeniorProject.Groups.ManageGroup" %>
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
        .style7
        {
            width: 100%;
        }
        .style14
        {
            width: 200px;
            height: 56px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updatePanelPage" runat="server">
        <ContentTemplate>
            <h1>
                Group Details</h1>
            <p>
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                    CellPadding="4" DataKeyNames="GroupId" DataSourceID="SqlDataSource2" 
                    ForeColor="#333333" GridLines="None" Height="50px" Width="349px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                    <EditRowStyle BackColor="#999999" />
                    <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                    <Fields>
                        <asp:BoundField DataField="GroupId" HeaderText="GroupId" InsertVisible="False" 
                            ReadOnly="True" SortExpression="GroupId" Visible="False" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                    </Fields>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                </asp:DetailsView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                    SelectCommand="SELECT * FROM [Groups] WHERE ([GroupID] = @GroupID)">
                    <SelectParameters>
                        <asp:SessionParameter Name="GroupID" SessionField="CurrentGroup" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:Button ID="btnEditGroup" runat="server" onclick="btnEditGroup_Click" 
                    Text="Edit Group" Width="136px" />
                &nbsp;<asp:Button ID="btnAddComputers" runat="server" 
                    Text="Add to Group" onclick="btnAddComputers_Click" Width="136px" />
                &nbsp;<asp:Button ID="btnCalcelAddComputers" runat="server" CausesValidation="False" 
                    onclick="btnCalcelAddComputers_Click" Text="Cancel" Visible="False" 
                    Width="136px" />
            </p>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <table class="style1">
                    <tr>
                        <td class="style2">
                            Name:</td>
                        <td>
                            <asp:TextBox ID="txtBoxName" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtBoxName" ErrorMessage="Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Notes</td>
                        <td>
                            <asp:TextBox ID="txtBoxNotes" runat="server" Height="100px" MaxLength="1000" 
                                TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnUpdateGroup" runat="server" onclick="btnUpdateGroup_Click" 
                    Text="Update Group" Width="136px" />
            </asp:Panel>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <asp:Panel ID="panelComputers" runat="server">
                <h1>
                    Computers in this Group</h1>
                <p>
                    <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
                        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="InvID" 
                        DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None" 
                        onrowcreated="GridView1_RowCreated" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" Width="1235px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="InvID" HeaderText="InvID" SortExpression="InvID" 
                                Visible="False" />
                            <asp:BoundField DataField="SerialNo" HeaderText="SerialNo" 
                                SortExpression="SerialNo" />
                            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                            <asp:BoundField DataField="FormFactor" HeaderText="FormFactor" 
                                SortExpression="FormFactor" />
                            <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" 
                                SortExpression="Manufacturer" />
                            <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Building" HeaderText="Building" 
                                SortExpression="Building" />
                            <asp:BoundField DataField="Room" HeaderText="Room" SortExpression="Room" />
                            <asp:BoundField DataField="PrimaryUser" HeaderText="PrimaryUser" 
                                SortExpression="PrimaryUser" />
                            <asp:BoundField DataField="Status" HeaderText="Status" 
                                SortExpression="Status" />
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
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                        SelectCommand="SELECT Inventory.Manufacturer, Inventory.Model, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Computer.InvID, Computer.FormFactor, Inventory.Status, Computer.Type, Inventory.SerialNo FROM Inventory INNER JOIN Computer ON Inventory.InvID = Computer.InvID INNER JOIN GroupInventory ON Inventory.InvID = GroupInventory.InvID INNER JOIN Groups ON GroupInventory.GroupID = Groups.GroupId INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Groups.GroupId = @GroupID) AND (Logistics.Status = 'Active')">
                        <SelectParameters>
                            <asp:SessionParameter Name="GroupID" SessionField="CurrentGroup" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </p>
            </asp:Panel>
            <asp:Panel ID="panelAddComputers" runat="server" Height="56px" Visible="False">
                <br />
                <div id="sidebar">
                    <asp:Button ID="btnToggle" runat="server" CausesValidation="False" 
                        onclick="btnToggle_Click" Text="Add With Text Box" Width="136px" />
                    <span class="page">
                    <br />
                    Service Tag(s)/Serial No.(s):<br />
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
                                Width="136px" />
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSerialNo0" runat="server" 
                                ControlToValidate="lstBoxSerialNos" 
                                ErrorMessage="You must enter at least 1 service tag" ForeColor="Red"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </span>
                </div>

                <div id="maincontent">
                    <asp:Panel ID="panelGridView" runat="server">
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
                                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("SerialNo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="SerialNoHeaderLinkButton" runat="server" 
                                            CausesValidation="False" Text="SerialNo"></asp:LinkButton>
                                        <br />
                                        <asp:TextBox ID="txtBoxSerialNoFilter" runat="server" AutoPostBack="True" 
                                            TabIndex="1" Width="100px"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Type") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="TypeHeaderLinkButton" runat="server" 
                                            CausesValidation="False" Text="Type"></asp:LinkButton>
                                        <br />
                                        <asp:DropDownList ID="ddlTypeFilter" runat="server" AutoPostBack="True" 
                                            DataSourceID="SqlDataSourceType0" DataTextField="Type" DataValueField="Type" 
                                            TabIndex="2" Width="100px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceType0" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Computer.Type FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')
        ORDER BY Computer.Type ASC"></asp:SqlDataSource>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FormFactor">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("FormFactor") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="FormFactorHeaderLinkButton" runat="server" 
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
                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("FormFactor") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Manufacturer">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("Manufacturer") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="ManufacturerHeaderLinkButton" runat="server" 
                                            CausesValidation="False" Text="Manufacturer"></asp:LinkButton>
                                        <br />
                                        <asp:DropDownList ID="ddlManufacturerFilter" runat="server" AutoPostBack="True" 
                                            DataSourceID="SqlDataSourceManufacturer0" DataTextField="Manufacturer" 
                                            DataValueField="Manufacturer" TabIndex="4" Width="100px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceManufacturer0" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Inventory.Manufacturer FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')
        ORDER BY Inventory.Manufacturer ASC"></asp:SqlDataSource>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("Manufacturer") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Model">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("Model") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="ModelHeaderLinkButton" runat="server" 
                                            CausesValidation="False" Text="Model"></asp:LinkButton>
                                        <br />
                                        <asp:TextBox ID="txtBoxModelFilter" runat="server" AutoPostBack="True" 
                                            TabIndex="5" Width="100px"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("Model") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="NameHeaderLinkButton" runat="server" 
                                            CausesValidation="False" Text="Name"></asp:LinkButton>
                                        <br />
                                        <asp:TextBox ID="txtBoxNameFilter" runat="server" AutoPostBack="True" 
                                            TabIndex="6" Width="100px"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Building">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("Building") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="BuildingHeaderLinkButton" runat="server" 
                                            CausesValidation="False" Text="Building"></asp:LinkButton>
                                        <br />
                                        <asp:DropDownList ID="ddlBuildingFilter" runat="server" AutoPostBack="True" 
                                            DataSourceID="SqlDataSourceBuilding0" DataTextField="Building" 
                                            DataValueField="Building" TabIndex="7" Width="100px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceBuilding0" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Logistics.Building FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')
        ORDER BY Logistics.Building ASC"></asp:SqlDataSource>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label16" runat="server" Text='<%# Bind("Building") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Room">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("Room") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="RoomHeaderLinkButton" runat="server" 
                                            CausesValidation="False" Text="Room"></asp:LinkButton>
                                        <br />
                                        <asp:TextBox ID="txtBoxRoomFilter" runat="server" AutoPostBack="True" 
                                            TabIndex="8" Width="100px"></asp:TextBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label17" runat="server" Text='<%# Bind("Room") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="StatusHeaderLinkButton" runat="server" 
                                            CausesValidation="False" Text="Status"></asp:LinkButton>
                                        <br />
                                        <asp:DropDownList ID="ddlStatusFilter" runat="server" AutoPostBack="True" 
                                            DataSourceID="SqlDataSourceStatus0" DataTextField="Status" 
                                            DataValueField="Status" TabIndex="10" Width="100px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceStatus0" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                                            SelectCommand="SELECT DISTINCT Inventory.Status FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred') ORDER BY Inventory.Status">
                                        </asp:SqlDataSource>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label18" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
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
                            SelectCommand="SELECT Inventory.InvID, Inventory.SerialNo,  Inventory.Manufacturer, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Model, Inventory.Status, Computer.FormFactor, Computer.Type FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred') AND (Inventory.InvID NOT IN (SELECT Inventory_1.InvID FROM Inventory AS Inventory_1 INNER JOIN GroupInventory ON Inventory_1.InvID = GroupInventory.InvID WHERE (GroupInventory.GroupID = @GroupID))) ORDER BY Inventory.SerialNo">
                            <SelectParameters>
                                <asp:SessionParameter DbType="String" DefaultValue="2" Name="GroupID" 
                                    SessionField="CurrentGroup" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <br />
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
                    </asp:Panel>
                    <br />
                    <br />
                </div>
                <br />
            </asp:Panel>
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>&nbsp;</p>
</asp:Content>
