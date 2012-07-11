<%@ Page Title="RED - Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="SeniorProject.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Hang on a minute...</h1>
    <h3>
        I don&#39;t know what you did there but you really did something weird and almost 
        caused RED to crash. More details can be found below, but good luck reading that 
        stuff...</h3>
    <p>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </p>
</asp:Content>
