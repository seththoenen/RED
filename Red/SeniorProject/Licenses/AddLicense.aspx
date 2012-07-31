<%@ Page Title="RED - Create New License" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddLicense.aspx.cs" Inherits="SeniorProject.Licenses.AddLicense" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
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
        .style3
        {
            width: 150px;
            height: 29px;
        }
        .style4
        {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
        <tr>
            <td class="style3">
                Software:</td>
            <td class="style4">
                <asp:TextBox ID="txtBoxSoftware" runat="server" style="margin-left: 0px" 
                    Width="200px" MaxLength="45"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtBoxSoftware" ErrorMessage="Software is required" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Operating System:</td>
            <td>
                <asp:TextBox ID="txtBoxOperatingSystem" runat="server" Width="200px" 
                    MaxLength="45"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtBoxOperatingSystem" 
                    ErrorMessage="Operating System is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Key:</td>
            <td class="style4">
                <asp:TextBox ID="txtBoxKey" runat="server" Width="200px" MaxLength="45"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtBoxKey" ErrorMessage="Key is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Number of Copies:</td>
            <td class="style4">
                <asp:TextBox ID="txtBoxNumOfCopies" runat="server" Width="200px" MaxLength="45"></asp:TextBox>
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
                <asp:TextBox ID="txtBoxExpirationDate" runat="server" Width="200px" 
                    MaxLength="45"></asp:TextBox>
                <asp:CalendarExtender ID="txtBoxExpirationDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtBoxExpirationDate">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Type:</td>
            <td>
                <asp:DropDownList ID="ddlType" runat="server" Height="20px" Width="149px">
                    <asp:ListItem>Computer</asp:ListItem>
                    <asp:ListItem>Equipment</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Notes:</td>
            <td>
                <asp:TextBox ID="txtBoxNotes" runat="server" Height="100px" Width="300px" 
                    TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
            </td>
        </tr>
    </table>
    <p>
        <asp:Button ID="btnAddLicense" runat="server" Text="Add License" 
            onclick="btnAddLicense_Click" />
</p>

        <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="btnClear" runat="server" Text="Clear" 
        onclick="btnClear_Click" Visible="False" />

</asp:Content>
