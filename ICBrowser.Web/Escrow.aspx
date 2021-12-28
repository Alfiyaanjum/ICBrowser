<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Escrow.aspx.cs" Inherits="ICBrowser.Web.Escrow" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel5" runat="server" meta:resourcekey="Panel5Resource1">
        <table width="100%" border="1" cellpadding="0" cellspacing="0">
            <tr >
                <td class="headerback">
               <asp:Label ID="lblHeading2" runat="server" Text="ICBrowser Transaction Guideline"
                        CssClass="header" meta:resourcekey="lblHeading2Resource1"></asp:Label>                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="Img" runat="server" Height="162px" Width="285px" meta:resourcekey="ImgResource1" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEscrow" CssClass="lblInfo" runat="server" meta:resourcekey="lblEscrowResource1"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
