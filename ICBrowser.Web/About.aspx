<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="ICBrowser.Web.About" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <%-- <link href="Styles/style.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
        <asp:Panel ID="Panel6" runat="server">
            <table width="100%" border="1" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="headerback">
                        <asp:Label ID="lblHead" runat="server" Text="About Us" CssClass="header"
                            meta:resourcekey="lblHeadResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Img" runat="server" Height="162px" Width="285px" meta:resourcekey="ImgResource1" />
                    </td>
                </tr>
                <tr class="lblInfo">
                    <td>
                        <asp:Label ID="lblInfo" runat="server" CssClass="lblInfo" meta:resourcekey="lblInfoResource1"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Content>
