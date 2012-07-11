<%@ Page Title="RED - Home" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SeniorProject._Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 21px;
        }
        .style3
        {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="search">
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h3>
                    Quick Search</h3>
                <table class="style1">
                    <tr>
                        <td class="style2">
                            Serial No:</td>
                        <td class="style2">
                            <asp:TextBox ID="txtBoxSerialNo" runat="server" MaxLength="45"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            SMSU Tag:</td>
                        <td>
                            <asp:TextBox ID="txtBoxSMSUTag" runat="server" MaxLength="45"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Building:</td>
                        <td>
                            <asp:TextBox ID="txtBoxBuilding" runat="server" MaxLength="45"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Room:</td>
                        <td>
                            <asp:TextBox ID="txtBoxRoom" runat="server" MaxLength="45"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Name:</td>
                        <td>
                            <asp:TextBox ID="txtBoxName" runat="server" MaxLength="45"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" 
                                onclick="btnSearch_Click" />
                        </td>
                        <td class="style3">
                            </td>
                    </tr>
                </table>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div>
    <h2>
        Welcome to the ResNet Equipment Database! (RED)</h2>
    <p>
        
        Version: 1.1.0</p>
        <asp:UpdatePanel ID="updatePanelPage" runat="server">
            <ContentTemplate>
                <asp:Panel ID="panelAuthenticated" runat="server" Visible="False">
                    You are currently authenticated.
                    <br />
                    <asp:Button ID="btnLogOut" runat="server" Text="Log Out" 
                        onclick="btnLogOut_Click" />
                </asp:Panel>
                <asp:Panel ID="panelNotAuthenticated" runat="server" Visible="False">
                    You are currently not authenticated.<br /> Password:
                    <asp:TextBox ID="txtBoxPassword" runat="server" AutoPostBack="True" 
                        ontextchanged="txtBoxPassword_TextChanged" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblAuthMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </asp:Panel>
             </ContentTemplate>
        </asp:UpdatePanel>
    <p>
        Written by Seth Thoenen.</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        
    </div>
</asp:Content>
