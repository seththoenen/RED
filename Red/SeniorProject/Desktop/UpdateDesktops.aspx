<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateDesktops.aspx.cs" Inherits="SeniorProject.UpdateDesktops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 79%;
            margin-right: 0px;
        }
        .style6
    {
        width: 150px;
    }
        .style11
        {
            width: 151px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Mass Update Desktops</h2>
    <div id = "sidebar">
    
    <span class="page">Service Tag(s)/Serial No.(s):<br />
        One per line:</span><br />
    <asp:TextBox ID="txtBoxServiceTags" runat="server" Height="304px" Width="179px" 
            TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSerialNo" runat="server" 
            ControlToValidate="txtBoxServiceTags" 
            ErrorMessage="You must enter at least 1 service tag" ForeColor="Red"></asp:RequiredFieldValidator>
    
    </div>
    <div id = "maincontent">
    
        <h2>
            General</h2>
        <table class="style1">
            <tr>
                <td class="style6">
                    SMSU Tag:</td>
                <td class="style6" style="margin-left: 40px">
                    <asp:TextBox ID="txtBoxSMSUTag" runat="server"></asp:TextBox>
                </td>
                <td class="style6">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    Manufacturer:</td>
                <td class="style6">
                    <asp:TextBox ID="txtBoxManufacturer" runat="server"></asp:TextBox>
                </td>
                <td class="style6">
                    Model:</td>
                <td>
                    <asp:TextBox ID="txtBoxModel" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <h2>Logistics</h2>
        <table class="style1">
            <tr>
                <td class="style6">
                    Building:</td>
                <td style="margin-left: 80px" class="style6">
                    <asp:TextBox ID="txtBoxBuilding" runat="server"></asp:TextBox>
                </td>
                <td class="style6">
                    Room Number:</td>
                <td>
                    <asp:TextBox ID="txtBoxRoomNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Primary User:</td>
                <td class="style6">
                    <asp:TextBox ID="txtBoxPrimaryUser" runat="server"></asp:TextBox>
                </td>
                <td class="style6">
                    Name:</td>
                <td>
                    <asp:TextBox ID="txtBoxName" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <h2>
            Purchase Info</h2>
        <table class="style1">
            <tr>
                <td class="style6">
                    Purchase Date:</td>
                <td class="style6">
                    <asp:TextBox ID="txtBoxPurchaseDate" runat="server"></asp:TextBox>
                </td>
                <td class="style6">
                    Purchase Price:</td>
                <td>
                    <asp:TextBox ID="txtBoxPurchasePrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Warranty Expires:</td>
                <td class="style6">
                    <asp:TextBox ID="txtBoxWarrantyExpires" runat="server"></asp:TextBox>
                </td>
                <td class="style6">
                    PO No.</td>
                <td>
                    <asp:TextBox ID="txtBoxPoNo" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <h2>
            Desktop Info</h2>
        <table class="style1">
            <tr>
                <td class="style6">
                    CPU:</td>
                <td class="style11">
                    <asp:TextBox ID="txtBoxCPU" runat="server"></asp:TextBox>
                </td>
                <td class="style6">
                    Video Card:</td>
                <td class="style6">
                    <asp:TextBox ID="txtBoxVideoCard" runat="server" style="margin-left: 0px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Hard Drive:</td>
                <td class="style11" style="margin-left: 40px">
                    <asp:TextBox ID="txtBoxHardDrive" runat="server"></asp:TextBox>
                </td>
                <td class="style6" style="margin-left: 40px">
                    Memory:</td>
                <td style="margin-left: 40px" class="style6">
                    <asp:TextBox ID="txtBoxMemory" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Optical Drive:</td>
                <td class="style11" style="margin-left: 80px">
                    <asp:TextBox ID="txtBoxOpticalDrive" runat="server"></asp:TextBox>
                </td>
                <td class="style6" style="margin-left: 40px">
                    Removable Media:</td>
                <td style="margin-left: 40px" class="style6">
                    <asp:TextBox ID="txtBoxRemovableMedia" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    USB Ports:</td>
                <td class="style11" style="margin-left: 120px">
                    <asp:TextBox ID="txtBoxUSBPorts" runat="server"></asp:TextBox>
                </td>
                <td class="style6" style="margin-left: 40px">
                    Other Connectivity:</td>
                <td style="margin-left: 40px" class="style6">
                    <asp:TextBox ID="txtBoxOtherConnectivity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Size:</td>
                <td class="style11" style="margin-left: 200px">
                    <asp:TextBox ID="txtBoxSize" runat="server"></asp:TextBox>
                </td>
                <td class="style6" style="margin-left: 40px">
                    Attached Monitor:</td>
                <td style="margin-left: 40px" class="style6">
                    <asp:DropDownList ID="ddlMonitor" runat="server" AutoPostBack="True" 
                        DataSourceID="SqlDataSource1" DataTextField="Display" DataValueField="id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:EquipmentConnectionString %>" 
                        SelectCommand="SELECT * FROM [Monitor]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style11" style="margin-left: 200px">
                    &nbsp;</td>
                <td class="style6" style="margin-left: 40px">
                    &nbsp;</td>
                <td style="margin-left: 40px" class="style6">
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
                        SelectCommand="SELECT [Size], [Brand], [Resolution], [Connectors], [Model] FROM [Monitor] WHERE ([id] = @id)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlMonitor" Name="id" 
                                PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
        <h2>Notes</h2>
        <p>
            <asp:TextBox ID="txtBoxNotes" runat="server" Height="87px" TextMode="MultiLine" 
                Width="626px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnUpdateDesktop" runat="server" Text="Update" Width="100px" 
                onclick="btnAddDesktop_Click" />
        </p>
        <p>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </p>
           
        
    </div>
</asp:Content>
