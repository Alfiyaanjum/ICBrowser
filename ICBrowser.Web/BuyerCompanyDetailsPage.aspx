<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuyerCompanyDetailsPage.aspx.cs" Inherits="ICBrowser.Web.BuyerCompanyDetailsPage" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnMessage" runat="server" Text="Send Message" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td align="center">
                    <asp:Label ID="lblCompanyName" runat="server" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlCompDet" runat="server">
        <div class="Company" id="grid" style="width:500px">
            <table width="680px" border="2" cellspacing="0" cellpadding="0"  id="ch_table">
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label1" runat="server" Text="Contact Person" Font-Bold="true"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblContactName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label2" runat="server" Text="Phone Number" Font-Bold="true"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label3" runat="server" Text="Fax" Font-Bold="true"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblFax" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label4" runat="server" Text="E-Mail" Font-Bold="true"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label5" runat="server" Text="Website" Font-Bold="true"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblWebsite" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label6" runat="server" Text="Address" Font-Bold="true"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label7" runat="server" Text="Zip-Code" Font-Bold="true"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblZip" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label8" runat="server" Text="Country" Font-Bold="true"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblCountry" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label9" runat="server" Text="Company Info" Font-Bold="true"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblCompanyInfo" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
