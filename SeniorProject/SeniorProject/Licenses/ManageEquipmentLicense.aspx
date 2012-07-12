<%@ Page Title="RED - Manage Equipment License" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageEquipmentLicense.aspx.cs" Inherits="SeniorProject.Licenses.ManageEquipmentLicense" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 158px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Manage Lilcense</h1>
    <asp:UpdatePanel ID="updatePanelLicense" runat="server">
        <ContentTemplate>
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                CellPadding="4" DataKeyNames="LicID" DataSourceID="SqlDataSource1" 
                ForeColor="#333333" GridLines="None" Height="50px" Width="412px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                <EditRowStyle BackColor="#999999" />
                <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                <Fields>
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
                    <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" 
                        Visible="False" />
                </Fields>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            </asp:DetailsView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                SelectCommand="SELECT * FROM [Licenses] WHERE ([LicID] = @LicID)">
                <SelectParameters>
                    <asp:SessionParameter Name="LicID" SessionField="CurrentLicense" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Button ID="btnUpdateLicense" runat="server" CausesValidation="False" 
                onclick="btnUpdateLicense_Click" Text="Update License" />
            <asp:Panel ID="panelUpdateLicense" runat="server" Visible="False" Width="830px">
                <table class="style1">
                    <tr>
                        <td class="style2">
                            Software:</td>
                        <td>
                            <asp:TextBox ID="txtBoxSoftware" runat="server" Width="136px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtBoxSoftware" ErrorMessage="Software is required" 
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            OS:</td>
                        <td>
                            <asp:TextBox ID="txtBoxOperatingSystem" runat="server" Width="136px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtBoxOperatingSystem" 
                                ErrorMessage="Operating System is required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            License Key:</td>
                        <td>
                            <asp:TextBox ID="txtBoxKey" runat="server" Width="136px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtBoxKey" ErrorMessage="Key is required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Number of Copies:</td>
                        <td>
                            <asp:TextBox ID="txtBoxNumOfCopies" runat="server" Width="136px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtBoxNumOfCopies" 
                                ErrorMessage="Number of Copies is required" ForeColor="Red"></asp:RequiredFieldValidator>
                            &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" 
                                ControlToValidate="txtBoxNumOfCopies" 
                                ErrorMessage="Number of Copies must be a positive integer" ForeColor="Red" 
                                MaximumValue="99999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Expiration Date:</td>
                        <td>
                            <asp:TextBox ID="txtBoxExpirationDate" runat="server" Width="136px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="txtBoxExpirationDate_CalendarExtender" 
                                runat="server" Enabled="True" TargetControlID="txtBoxExpirationDate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Notes:</td>
                        <td>
                            <asp:TextBox ID="txtBoxNotes" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
                    Text="Update" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        &nbsp;</p>
    <h1>
        Equipment with this License</h1>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="InvID" DataSourceID="SqlDataSource2" 
            ForeColor="#333333" GridLines="None" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" Width="1235px" 
            onrowcreated="GridView1_RowCreated" AllowSorting="True">
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
            
            SelectCommand="SELECT Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Inventory.Status, Logistics.Room, Logistics.Building, Inventory.InvID, Logistics.PrimaryUser, Logistics.Name, Equipment.EquipmentType FROM Inventory INNER JOIN LicenseInventory ON Inventory.InvID = LicenseInventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID INNER JOIN Equipment ON Inventory.InvID = Equipment.InvID WHERE (Logistics.Status = 'Active') AND (LicenseInventory.LicID = @LicID)">
            <SelectParameters>
                <asp:SessionParameter Name="LicID" SessionField="CurrentLicense" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <br />
</asp:Content>
