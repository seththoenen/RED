<%@ Page Title="RED - View Equipment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewEquipments.aspx.cs" Inherits="SeniorProject.ViewEquipments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewEquipment" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="InvID" DataSourceID="SqlDataSourceEquipment" 
        ForeColor="#333333" GridLines="None" Width="1245px" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" 
        onrowcreated="GridView1_RowCreated" AllowSorting="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
                            <asp:BoundField DataField="InvID" HeaderText="InvID" InsertVisible="False" 
                                ReadOnly="True" SortExpression="InvID" Visible="False" />
                            <asp:TemplateField HeaderText="SerialNo">
		                        <EditItemTemplate>
			                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("SerialNo") %>'></asp:TextBox>
		                        </EditItemTemplate>
		                        <HeaderTemplate>
			                        <asp:LinkButton id="SerialNoHeaderLinkButton" runat="server" Text="SerialNo" 
				                        ></asp:LinkButton>
			                        <br />
			                        <asp:TextBox ID="txtBoxSerialNoFilter" runat="server" Width="100px" 
				                        AutoPostBack="True" TabIndex="1"></asp:TextBox>
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
				                         Text="Type" ></asp:LinkButton>
			                        <br />
			                        <asp:DropDownList ID="ddlTypeFilter" runat="server" AutoPostBack="True" 
				                        DataSourceID="SqlDataSourceType" DataTextField="Type" DataValueField="Type" 
				                        TabIndex="2" Width="100px">
			                        </asp:DropDownList>
			                        <asp:SqlDataSource ID="SqlDataSourceType" runat="server" 
				                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
				                        SelectCommand="SELECT DISTINCT Equipment.EquipmentType as Type FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')"></asp:SqlDataSource>
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
				                        Text="Manufacturer" ></asp:LinkButton>
			                        <br />
			                        <asp:DropDownList ID="ddlManufacturerFilter" runat="server" 
				                        DataSourceID="SqlDataSourceManufacturer" DataTextField="Manufacturer" 
				                        DataValueField="Manufacturer" TabIndex="4" Width="100px" 
				                        AutoPostBack="True">
			                        </asp:DropDownList>
			                        <asp:SqlDataSource ID="SqlDataSourceManufacturer" runat="server" 
				                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
				                        SelectCommand="SELECT DISTINCT Inventory.Manufacturer FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')"></asp:SqlDataSource>
		                        </HeaderTemplate>
		                        <ItemTemplate>
			                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Manufacturer") %>'></asp:Label>
		                        </ItemTemplate>
	                        </asp:TemplateField>
	                        <asp:TemplateField HeaderText="Model" >
		                        <EditItemTemplate>
			                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Model") %>'></asp:TextBox>
		                        </EditItemTemplate>
		                        <HeaderTemplate>
			                        <asp:LinkButton ID="ModelHeaderLinkButton" runat="server" 
				                         Text="Model"></asp:LinkButton>
			                        <br />
			                        <asp:TextBox ID="txtBoxModelFilter" runat="server" TabIndex="5" Width="100px" 
				                        AutoPostBack="True"></asp:TextBox>
		                        </HeaderTemplate>
		                        <ItemTemplate>
			                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Model") %>'></asp:Label>
		                        </ItemTemplate>
	                        </asp:TemplateField>
	                        <asp:TemplateField HeaderText="Name" >
		                        <EditItemTemplate>
			                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
		                        </EditItemTemplate>
		                        <HeaderTemplate>
			                        <asp:LinkButton ID="NameHeaderLinkButton" runat="server" 
				                        Text="Name"></asp:LinkButton>
			                        <br />
			                        <asp:TextBox ID="txtBoxNameFilter" runat="server" TabIndex="6" Width="100px" 
				                        AutoPostBack="True"></asp:TextBox>
		                        </HeaderTemplate>
		                        <ItemTemplate>
			                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
		                        </ItemTemplate>
	                        </asp:TemplateField>
	                        <asp:TemplateField HeaderText="Building" >
		                        <EditItemTemplate>
			                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Building") %>'></asp:TextBox>
		                        </EditItemTemplate>
		                        <HeaderTemplate>
			                        <asp:LinkButton ID="BuildingHeaderLinkButton" runat="server" 
				                        Text="Building"></asp:LinkButton>
			                        <br />
			                        <asp:DropDownList ID="ddlBuildingFilter" runat="server" 
				                        DataSourceID="SqlDataSourceBuilding" DataTextField="Building" 
				                        DataValueField="Building" TabIndex="7" Width="100px" AutoPostBack="True">
			                        </asp:DropDownList>
			                        <asp:SqlDataSource ID="SqlDataSourceBuilding" runat="server" 
				                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
				                        SelectCommand="SELECT DISTINCT Logistics.Building FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')"></asp:SqlDataSource>
		                        </HeaderTemplate>
		                        <ItemTemplate>
			                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Building") %>'></asp:Label>
		                        </ItemTemplate>
	                        </asp:TemplateField>
	                        <asp:TemplateField HeaderText="Room" >
		                        <EditItemTemplate>
			                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Room") %>'></asp:TextBox>
		                        </EditItemTemplate>
		                        <HeaderTemplate>
			                        <asp:LinkButton ID="RoomHeaderLinkButton" runat="server" 
				                        Text="Room"></asp:LinkButton>
			                        <br />
			                        <asp:TextBox ID="txtBoxRoomFilter" runat="server" TabIndex="8" Width="100px" 
				                        AutoPostBack="True"></asp:TextBox>
		                        </HeaderTemplate>
		                        <ItemTemplate>
			                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Room") %>'></asp:Label>
		                        </ItemTemplate>
	                        </asp:TemplateField>
	                        <asp:TemplateField HeaderText="PrimaryUser" >
		                        <EditItemTemplate>
			                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("PrimaryUser") %>'></asp:TextBox>
		                        </EditItemTemplate>
		                        <HeaderTemplate>
			                        <asp:LinkButton ID="PrimaryUserHeaderLinkButton" runat="server" 
				                        Text="PrimaryUser"></asp:LinkButton>
			                        <br />
			                        <asp:TextBox ID="txtBoxPrimaryUserFilter" runat="server" Width="100px" 
				                        TabIndex="9" AutoPostBack="True"></asp:TextBox>
		                        </HeaderTemplate>
		                        <ItemTemplate>
			                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("PrimaryUser") %>'></asp:Label>
		                        </ItemTemplate>
	                        </asp:TemplateField>
	                        <asp:TemplateField HeaderText="Status" >
		                        <EditItemTemplate>
			                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
		                        </EditItemTemplate>
		                        <HeaderTemplate>
			                        <asp:LinkButton ID="StatusHeaderLinkButton" runat="server" 
				                        Text="Status"></asp:LinkButton>
			                        <br />
			                        <asp:DropDownList ID="ddlStatusFilter" runat="server" Width="100px" 
				                        DataSourceID="SqlDataSourceStatus" DataTextField="Status" 
				                        DataValueField="Status" TabIndex="10" AutoPostBack="True">
			                        </asp:DropDownList>
			                        <asp:SqlDataSource ID="SqlDataSourceStatus" runat="server" 
				                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
				
				
				                        SelectCommand="SELECT DISTINCT Inventory.Status FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred')">
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
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourceEquipment" runat="server" 
        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
        
        
        
        
        
        
        SelectCommand="SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Equipment.EquipmentType as Type, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Status FROM Equipment INNER JOIN Inventory ON Equipment.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status &lt;&gt; 'Transferred') ORDER BY Inventory.SerialNo">
    </asp:SqlDataSource>
</asp:Content>
