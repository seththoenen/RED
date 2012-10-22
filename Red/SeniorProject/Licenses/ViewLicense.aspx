<%@ Page Title="RED - Manage Computer License" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewLicense.aspx.cs" Inherits="SeniorProject.Licenses.ViewLicense" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
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
        Manage License</h1>
    <asp:UpdatePanel ID="updatePanelLicense" runat="server">
        <ContentTemplate>
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
            GridLines="None" Height="50px" Width="300px">
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                SelectCommand="SELECT  [Software], [OS], [LicenseKey], [NumOfCopies], [ExpirationDate], [Notes] FROM [Licenses] WHERE ([LicID] = @LicID)">
                <SelectParameters>
                    <asp:SessionParameter Name="LicID" SessionField="CurrentLicense" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Button ID="btnUpdateLicense" runat="server" CausesValidation="False" 
                onclick="btnUpdateLicense_Click" Text="Update License" Width="136px" />
            <br />
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
                            <asp:CalendarExtender ID="txtBoxExpirationDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtBoxExpirationDate">
                            </asp:CalendarExtender>
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
                    Text="Update" Width="136px" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <h1>
        Files</h1>
            <p>
        <asp:GridView ID="gvFiles" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" 
            DataKeyNames="FileID" DataSourceID="sqldsLicenseFiles" Width="900px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="LicID" HeaderText="LicID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="LicID" Visible="False" />
                <asp:BoundField DataField="FileID" HeaderText="FileID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="FileID" Visible="False" />
                <asp:TemplateField HeaderText="Filename" SortExpression="filename">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("filename") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("filename") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="description" HeaderText="Description" 
                    SortExpression="description" />
                <asp:TemplateField HeaderText="Download">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkBtnDownload" runat="server" CommandName="Select" 
                            onclick="lnkBtnDownload_Click" 
                            CommandArgument='<%# Container.DataItemIndex %>' SkinID="Blue">Download</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkButtonDelete" runat="server" 
                            onclick="lnkButtonDelete_Click" CommandName="Select" 
                            CommandArgument='<%# Container.DataItemIndex %>' SkinID="Blue">Delete</asp:LinkButton>
                        <asp:ConfirmButtonExtender ID="lnkButtonDelete_ConfirmButtonExtender" 
                            runat="server" TargetControlID="lnkButtonDelete" ConfirmText="Are you sure you want to delete this file?" ConfirmOnFormSubmit="True">
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
        <asp:SqlDataSource ID="sqldsLicenseFiles" runat="server" 
            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
            
                    SelectCommand="SELECT Licenses.LicID, LicenseFiles.FileID, LicenseFiles.filename, LicenseFiles.description FROM Licenses INNER JOIN LicenseFiles ON Licenses.LicID = LicenseFiles.LicID WHERE (Licenses.LicID = @LicID)">
            <SelectParameters>
                <asp:SessionParameter Name="LicID" SessionField="CurrentLicense" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        Add New File</p>

    <table>
        <tr>
            <td>File:</td> 
            <td><asp:AsyncFileUpload ID="AsyncFileUpload" runat="server" Width="250px" /></td>
        </tr>
        <tr>
            <td>Description:</td>
            <td><asp:TextBox ID="txtboxDescription" runat="server" MaxLength="499" 
                    Width="250px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" 
        Text="Upload" Width="136px" />
    &nbsp;&nbsp;<br />
    <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
    <br />
    

    <h1>
        Computers with this license</h1>
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
            
            
            SelectCommand="SELECT Inventory.InvID, Inventory.SerialNo, Inventory.Manufacturer, Inventory.Model, Logistics.Building, Logistics.Room, Logistics.PrimaryUser, Logistics.Name, Inventory.Status, Computer.FormFactor, Computer.Type FROM Inventory INNER JOIN LicenseInventory ON Inventory.InvID = LicenseInventory.InvID INNER JOIN Logistics ON Inventory.InvID = Logistics.InvID INNER JOIN Computer ON Inventory.InvID = Computer.InvID WHERE (LicenseInventory.LicID = @LicID) AND (Logistics.Status = 'Active')">
            <SelectParameters>
                <asp:SessionParameter Name="LicID" SessionField="CurrentLicense" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
