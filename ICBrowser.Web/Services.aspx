<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Services.aspx.cs" Inherits="ICBrowser.Web.Services" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 680px">
        <asp:Panel ID="Panel5" runat="server" ScrollBars="Vertical" Height="530px" meta:resourcekey="Panel5Resource1">
            <table width="100%">
                <tr class="headerback">
                    <td>
                        <asp:Label ID="lblHeading1" runat="server" Text="Services:" CssClass="header" meta:resourcekey="lblHeading1Resource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Img" Height="162px" Width="285px" runat="server" meta:resourcekey="ImgResource1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblServices" CssClass="lblInfo" runat="server" meta:resourcekey="lblServicesResource1"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
