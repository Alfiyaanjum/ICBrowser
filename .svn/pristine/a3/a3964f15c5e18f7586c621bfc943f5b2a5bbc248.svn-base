<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FAQ.aspx.cs" Inherits="ICBrowser.Web.FAQ" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .accordionContent
        {
            padding: 10px 5px;
        }
        .accordionHeaderSelected
        {
            background-color: #eeeeee;
            color: #111E61;
            cursor: pointer;
            font-weight: bold;
            margin-top: 3px;
            padding: 3px 5px;
        }
        .accordionHeader
        {
            background-color: #eeeeee;
            color: #5078B3;
            cursor: pointer;
            font-weight: bold;
            margin-top: 3px;
            padding: 3px 5px;
        }
        .accordionHeader a
        {
            color: #5078B3;
            font-weight: bold;
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="headerback">
<span class="header" style="padding:5px">FAQ</span>
</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Accordion ID="UserAccordion" runat="server" SelectedIndex="-1" HeaderCssClass="accordionHeader"
        HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent"
        FadeTransitions="true" SuppressHeaderPostbacks="true" TransitionDuration="100"
        FramesPerSecond="40" RequireOpenedPane="false">
    </asp:Accordion>
</asp:Content>
