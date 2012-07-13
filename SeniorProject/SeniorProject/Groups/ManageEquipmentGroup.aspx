<%@ Page Title="RED - Manage Equipment Group" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageEquipmentGroup.aspx.cs" Inherits="SeniorProject.Groups.ManageEquipmentGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 83%;
        }
        .style2
        {
            width: 263px;
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
                    CellPadding="4" DataKeyNames="GroupId" DataSourceID="SqlDataSource1" 
                    ForeColor="#333333" GridLines="None" Height="50px" Width="125px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                    <EditRowStyle BackColor="#999999" />
                    <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                    <Fields>
                        <asp:BoundField DataField="GroupId" HeaderText="GroupId" InsertVisible="False" 
                            ReadOnly="True" SortExpression="GroupId" Visible="False" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                    </Fields>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                </asp:DetailsView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                    SelectCommand="SELECT * FROM [Groups] WHERE ([GroupId] = @GroupId)">
                    <SelectParameters>
                        <asp:SessionParameter Name="GroupId" SessionField="CurrentGroup" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </p>
            <asp:Button ID="btnAddEquipment" runat="server" onclick="btnAddEquipment_Click" 
                Text="Add to Group" Width="136px" />
            &nbsp;<asp:Button ID="btnCancelAddEquipment" runat="server" CausesValidation="False" 
                onclick="btnCancelAddEquipment_Click" Text="Cancel" Visible="False" 
                Width="136px" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <asp:Panel ID="panelEquipment" runat="server">
                <h1>
                    Equipment in this Group</h1>
                <p>
                    <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
                        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="InvID" 
                        DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None" 
                        onrowcreated="GridView1_RowCreated" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" Width="1235px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="InvID" HeaderText="InvID" InsertVisible="False" 
                                ReadOnly="True" SortExpression="InvID" Visible="False" />
                            <asp:BoundField DataField="SerialNo" HeaderText="SerialNo" 
                                SortExpression="SerialNo" />
                            <asp:BoundField DataField="EquipmentType" HeaderText="EquipmentType" 
                                SortExpression="EquipmentType" />
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
                        SelectCommand="SELECT Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Inventory.Status, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.InvID, Equipment.EquipmentType FROM Inventory INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID INNER JOIN GroupInventory ON Inventory.InvID = GroupInventory.InvID INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID WHERE (Logistics.Status = 'Active') AND (GroupInventory.GroupID = @GroupID)">
                        <SelectParameters>
                            <asp:SessionParameter Name="GroupID" SessionField="CurrentGroup" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </p>
            </asp:Panel>
            <asp:Panel ID="panelAddEquipment" runat="server" Visible="False">
                <br />
                <div ID="sidebar">
                    <span class="page">
                    <asp:Button ID="btnToggle" runat="server" CausesValidation="False" 
                        onclick="btnToggle_Click" Text="Add With Text Box" Width="136px" />
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
                <div ID="maincontent0">
                    <asp:Panel ID="panelGridView" runat="server">

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
                        
                        SelectCommand="SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Equipment.EquipmentType as Type, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Status FROM Equipment INNER JOIN Inventory ON Equipment.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred') AND (Inventory.InvID NOT IN (SELECT Inventory_1.InvID FROM Inventory AS Inventory_1 INNER JOIN GroupInventory ON Inventory_1.InvID = GroupInventory.InvID WHERE (GroupInventory.GroupID = @GroupID)))">
                        <SelectParameters>
                            <asp:SessionParameter Name="GroupID" SessionField="CurrentGroup" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </asp:Panel>
                <br />
                <asp:Panel ID="panelTextBox" runat="server" Visible="False">
                    <br />
                    <table class="style1">
                        <tr>
                            <td class="style2">
                                <asp:TextBox ID="txtBoxSerialNos" runat="server" Height="450px" 
                                    TextMode="MultiLine" Width="250px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblAddTextBoxMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Button ID="btnAddWithTextBox" runat="server" CausesValidation="False" 
                                    onclick="btnAddWithTextBox_Click" Text="Add" Width="136px" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <br />
                </asp:Panel>
                </div>
            </asp:Panel>
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
