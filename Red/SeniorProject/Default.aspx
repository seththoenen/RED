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
        .style4
        {
            height: 21px;
            width: 144px;
        }
        .style5
        {
            width: 144px;
        }
        .style6
        {
            height: 30px;
            width: 144px;
        }
    .style7
    {
        width: 191px;
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
                        <td class="style4">
                            Serial No:</td>
                        <td class="style2">
                            <asp:TextBox ID="txtBoxSerialNo" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            SMSU Tag:</td>
                        <td>
                            <asp:TextBox ID="txtBoxSMSUTag" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Building:</td>
                        <td>
                            <asp:TextBox ID="txtBoxBuilding" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Room:</td>
                        <td>
                            <asp:TextBox ID="txtBoxRoom" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Name:</td>
                        <td>
                            <asp:TextBox ID="txtBoxName" runat="server" MaxLength="45" Width="136px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" 
                                onclick="btnSearch_Click" Width="136px" />
                        </td>
                        <td class="style3">
                            </td>
                    </tr>
                </table>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                <asp:Panel ID="panelInstantSearch" runat="server" 
                    DefaultButton="btnInstantSearch">
                    <h3>
                        Instant Search</h3>
                    <table>
                        <tr>
                            <td class="style5">
                                Serial No:
                            </td>
                            <td class="style7">
                                <asp:TextBox ID="txtBoxSerialNoInstant" runat="server" MaxLength="45" 
                                    Width="136px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="btnInstantSearch" runat="server" 
                        onclick="btnInstantSearch_Click" Text="Search" Width="136px" />
                    <br />
                    <asp:Label ID="lblMessageInstant" runat="server" ForeColor="Red" 
                        Visible="False"></asp:Label>
                </asp:Panel>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div>
    <h2>
        Welcome to the ResNet Equipment Database! (RED)</h2>
    <p>
        
        Version: 1.2.0</p>
        <asp:UpdatePanel ID="updatePanelPage" runat="server">
            <ContentTemplate>
                <asp:Panel ID="panelAuthenticated" runat="server" Visible="False">
                    You are currently authenticated.
                    <br />
                    <asp:Button ID="btnLogOut" runat="server" Text="Log Out" 
                        onclick="btnLogOut_Click" Width="136px" />
                </asp:Panel>
                <asp:Panel ID="panelNotAuthenticated" runat="server" Visible="False">
                    You are currently not authenticated.<br /> Password:
                    <asp:TextBox ID="txtBoxPassword" runat="server" AutoPostBack="True" 
                        ontextchanged="txtBoxPassword_TextChanged" TextMode="Password" 
                        Width="136px"></asp:TextBox>
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
