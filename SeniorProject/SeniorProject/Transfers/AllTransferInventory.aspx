<%@ Page Title="RED - All Transferred Inventory" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllTransferInventory.aspx.cs" Inherits="SeniorProject.Transfers.AllTransferInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
    Transferred Computers</h2>
    <asp:UpdatePanel ID="UpdatePanelPage" runat="server">
    <ContentTemplate>
<p>
    
    <asp:GridView ID="GridViewComputers" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="InvID" DataSourceID="SqlDataSourceComputers" 
        ForeColor="#333333" GridLines="None" onrowcreated="GridView1_RowCreated" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" Width="1233px" 
        AllowSorting="True">
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
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Computer.Type FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status = 'Transferred')
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
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Computer.FormFactor FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status = 'Transferred')
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
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Inventory.Manufacturer FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status = 'Transferred')
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
                                    ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" SelectCommand="SELECT DISTINCT Logistics.Building FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status = 'Transferred')
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
    <asp:SqlDataSource ID="SqlDataSourceComputers" runat="server" 
        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
        
        
        
        SelectCommand="SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Model, Inventory.Status, Computer.FormFactor, Computer.Type FROM Computer INNER JOIN Inventory ON Computer.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status = 'Transferred') ORDER BY Inventory.SerialNo">
    </asp:SqlDataSource>
</p>
    <h2>
        Transferred Equipment</h2>
    <p>
        <asp:GridView ID="GridViewEquipment" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="InvID" DataSourceID="SqlDataSourceEquipment" 
            ForeColor="#333333" GridLines="None" onrowcreated="GridView2_RowCreated" 
            onselectedindexchanged="GridView2_SelectedIndexChanged" Width="1235px" 
            AllowSorting="True">
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
                                    
                                    SelectCommand="SELECT DISTINCT Equipment.EquipmentType as Type FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status = 'Transferred')">
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
                                    
                                    SelectCommand="SELECT DISTINCT Inventory.Manufacturer FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status = 'Transferred')">
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
                                    
                                    SelectCommand="SELECT DISTINCT Logistics.Building FROM Inventory INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status = 'Transferred')">
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
            
            
            
            SelectCommand="SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Equipment.EquipmentType as Type, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Status FROM Equipment INNER JOIN Inventory ON Equipment.InvID = Inventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID WHERE (Logistics.Status = 'Active') AND (Inventory.Status = 'Transferred') ORDER BY Inventory.SerialNo">
        </asp:SqlDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</p>
</asp:Content>
