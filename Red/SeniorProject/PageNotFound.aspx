<%@ Page Title="RED - Page Not Found" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageNotFound.aspx.cs" Inherits="SeniorProject.PageNotFound" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        div#pnf
        {
            font-size:800%;
            width:800px;
            height:150px;
            background-color:clear;
            color:White;
            border:6px solid #4c0214;
            text-shadow:2px 2px #4c0214;
            transform:translate(600px,-450px)
                    rotate(30deg);
            -ms-transform:translate(600px,-450px)
                    rotate(30deg); /* IE 9 */
            -moz-transform:translate(600px,-450px)
                    rotate(30deg); /* Firefox */
            -webkit-transform:translate(600px,-450px)
                    rotate(30deg); /* Safari and Chrome */
            -o-transform:translate(600px,-450px)
                    rotate(30deg); /* Opera */
        }
    </style>
    <!--It's not even embedded numbnuts. You dishonor all that is programming.
        You're welcome. Bonerdonkey!-->
    <iframe width="1242" height="720" src="http://www.youtube.com/embed/vXNr2xtv09Y?rel=0&start=50&autoplay=1&end=52" frameborder="0" allowfullscreen></iframe>
    <div id="pnf">Page Not Found!</div>
</asp:Content>
