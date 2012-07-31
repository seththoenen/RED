<%@ Page Title="RED - Add Group" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGroup.aspx.cs" Inherits="SeniorProject.Groups.AddGroup" %>
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
        height: 26px;
    }
    .style4
    {
        height: 26px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Add New Group</h1>
    <table class="style1">
        <tr>
            <td class="style2">
                Name:</td>
            <td>
                <asp:TextBox ID="txtBoxName" runat="server" Width="301px" MaxLength="45"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtBoxName" ErrorMessage="Name is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Group Type:</td>
            <td class="style4">
                <asp:DropDownList ID="ddlType" runat="server" Height="20px" Width="150px">
                    <asp:ListItem>Computer</asp:ListItem>
                    <asp:ListItem Value="Equipment"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Notes:</td>
            <td>
                <asp:TextBox ID="txtBoxNotes" runat="server" Height="86px" Width="300px" 
                    TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
            </td>
        </tr>
    </table>
        <asp:Button ID="btnAddGroup" runat="server" Text="Add Group" 
    onclick="btnAddGroup_Click" />
    <br />
    <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
</asp:Content>
