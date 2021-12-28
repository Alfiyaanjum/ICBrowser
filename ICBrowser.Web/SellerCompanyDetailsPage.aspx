<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SellerCompanyDetailsPage.aspx.cs" Inherits="ICBrowser.Web.SellerCompanyDetailsPage" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnMessage" runat="server" Text="Send Message" 
                        meta:resourcekey="btnMessageResource1" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td align="center">
                    <asp:Label ID="lblCompanyName" runat="server" Font-Size="X-Large" 
                        Font-Bold="True" meta:resourcekey="lblCompanyNameResource1"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlCompDet" runat="server" 
        meta:resourcekey="pnlCompDetResource1">
        <div class="Company" id="grid" style="width:500px">
           <table width="680px" border="2" cellspacing="0" cellpadding="0"  id="ch_table">
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label1" runat="server" Text="Contact Person" Font-Bold="True" 
                            meta:resourcekey="Label1Resource1"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblContactName" runat="server" 
                            meta:resourcekey="lblContactNameResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label2" runat="server" Text="Phone Number" Font-Bold="True" 
                            meta:resourcekey="Label2Resource1"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblPhoneNumber" runat="server" 
                            meta:resourcekey="lblPhoneNumberResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label3" runat="server" Text="Fax" Font-Bold="True" 
                            meta:resourcekey="Label3Resource1"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblFax" runat="server" meta:resourcekey="lblFaxResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label4" runat="server" Text="E-Mail" Font-Bold="True" 
                            meta:resourcekey="Label4Resource1"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmailResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label5" runat="server" Text="Website" Font-Bold="True" 
                            meta:resourcekey="Label5Resource1"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblWebsite" runat="server" 
                            meta:resourcekey="lblWebsiteResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label6" runat="server" Text="Address" Font-Bold="True" 
                            meta:resourcekey="Label6Resource1"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblAddress" runat="server" 
                            meta:resourcekey="lblAddressResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label7" runat="server" Text="Zip-Code" Font-Bold="True" 
                            meta:resourcekey="Label7Resource1"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblZip" runat="server" meta:resourcekey="lblZipResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label8" runat="server" Text="Country" Font-Bold="True" 
                            meta:resourcekey="Label8Resource1"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblCountry" runat="server" 
                            meta:resourcekey="lblCountryResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" class="popupbox-header" align="center">
                        <asp:Label ID="Label9" runat="server" Text="Company Info" Font-Bold="True" 
                            meta:resourcekey="Label9Resource1"></asp:Label>
                    </td>
                    <td width="70%" align="center" valign="middle" class="popupbox-header">
                        <asp:Label ID="lblCompanyInfo" runat="server" 
                            meta:resourcekey="lblCompanyInfoResource1"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
