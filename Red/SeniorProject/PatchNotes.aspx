<%@ Page Title="RED - Patch Notes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatchNotes.aspx.cs" Inherits="SeniorProject.PatchNotes" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
    Patch Notes</h2>
    <asp:Accordion ID="Accordion1" runat="server" Height="637px" Width="1227px" 
        HeaderCssClass="accordionHeader" ContentCssClass="accordionContent">
        <Panes>
        <asp:AccordionPane ID="AccordionPane115" runat="server" ContentCssClass="" 
                HeaderCssClass="">
            <Header><a>Release 1.1.5 - Release Date Here</a></Header>
            <Content>
                -Created "Page Not Found" Page
                -Fixed a bug where errors would occur when working with grid views.
            </Content>
        </asp:AccordionPane>
            <asp:AccordionPane ID="AccordionPane114" runat="server" ContentCssClass="" 
                HeaderCssClass="">
            <Header><a>Release 1.1.4 - September 18, 2012</a></Header>
            <Content>
                -Performance changes, lots of them
            </Content>
        </asp:AccordionPane>
        <asp:AccordionPane ID="AccordionPane113" runat="server" ContentCssClass="" 
                HeaderCssClass="">
            <Header><a>Release 1.1.3 - August 1, 2012</a></Header>
            <Content>
                -All physical address and serial number fields will now convert all characters to upper case<br />
                -Fixed a bug where adding inventory items to a group would not do anything<br />
                -Added instant search to the home page<br />
                -Renamed computer pages to have the word "Computer" instead of "Desktop"<br />
            </Content>
        </asp:AccordionPane>
        <asp:AccordionPane ID="AccordionPane112" runat="server" ContentCssClass="" 
                HeaderCssClass="">
            <Header><a>Release 1.1.2 - July 27, 2012</a></Header>
            <Content>
                -Added a field for physical address to all inventory items<br />
                -Fixed an issue where the pixel length was showing up as the value for a few fields in update equipment<br />
                -Re-enabled the global.asax error page<br />
                -Update computers page now shows a message when updating<br />
            </Content>
        </asp:AccordionPane>
        <asp:AccordionPane ID="AccordionPane111" runat="server" ContentCssClass="" 
                HeaderCssClass="">
            <Header><a>Release 1.1.1 - July 18, 2012</a></Header>
            <Content>
                -Added ajax to main menu bar (for mobile device viewing)<br />
                -Added title to Patch Notes page<br />
                -When intentory items are added to groups they no longer remain in queue to be added<br />
                -When inserting inventory items to the system, inventory items no longer remain in queue to be added<br />
                -Added accordion ajax to Patch Notes<br />
                -Fixed a bug where groups wouldn't show up in manage groups if the group had no inventory assigned to it<br />
                -Added an update panel to view computer page for the PO section to cause partial post backs instead of full post backs<br />
                -Changed the color of details views<br />
                -Added update abilities for licenses<br />
                -Removed margins from inputs and made text boxes the same width<br />
                -Made buttons a universal size and changed text accordingly<br />
                -Added filters fo all transferred inventory page<br />
            </Content>
        </asp:AccordionPane>
        <asp:AccordionPane ID="AccordionPane110" runat="server" ContentCssClass="" 
                HeaderCssClass="">
            <Header><a>Release 1.1.0 - June 20, 2012</a></Header>
            <Content>
                -Added a BA header to the entire system (thanks to Kendra!)<br />
                -Added GridView filters to View Computers and View Equipment pages<br />
                -Serial Numbers can now be added with a filtered gridview on the Update Computer and Update Equipment pages<br />
                -Add Computers, Update Computers, Add Equipment, and Update Equipment pages all have new ways to handle serial numbers<br />
                -View Groups, View Purchase Orders, View Licenses, and View Transfers pages have aggregate functions to show the number of inventory items per object<br />
                -Restricted licenses functionalities unless the user is authenticated.<br />
                -Integrated purchase order pages<br />
                -Integrated group pages<br />
                -Integrated license pages<br />
                -Removed transfer names from transfers (name isn't necessary)<br />
                -Menu items will no longer take you back to the home page (unless you click on the home button)<br />
                -Widened GridViews across the system<br />
                -Switched Licenses and Transfers on the main menu<br />
                -Removed "Check back for more updates" from the front page<br />
                -Code maintenance for data access layer<br />
                -Created test database (for testing purposes only)<br />
            </Content>
        </asp:AccordionPane>
        <asp:AccordionPane ID="AccordionPane101" runat="server" ContentCssClass="" 
                HeaderCssClass="">
            <Header><a>Release 1.0.1 - May 24, 2012</a></Header>
            <Content>
                -Changed PO.ID from String to Int (May cause some issues)<br />
                -Added Patch Notes Page<br />
                -Made changes to accept data from database migration from RICS<br />
                -Widened DataGrids across the system<br />
                -Modified Search to only serch "Active" and "Storage" inventory items<br />
                -Enabled sorting on GridViews<br />
                -Modified reports slightly<br />
            </Content>
        </asp:AccordionPane>
        <asp:AccordionPane ID="AccordionPane100" runat="server" ContentCssClass="" 
                HeaderCssClass="">
            <Header><a>Release 1.0.0 - May 15, 2012</a></Header>
            <Content>
                -Senior Project Version Presented<br />
            </Content>
        </asp:AccordionPane>
    </Panes>
    </asp:Accordion>
</asp:Content>
