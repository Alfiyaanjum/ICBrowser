<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master"
    AutoEventWireup="true" CodeBehind="UploadBulkOffers.aspx.cs" Inherits="ICBrowser.Web.UploadBulkOffers"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="Controls/SellerInventories.ascx" TagName="SellerInventories" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <div id="Header">
        <table style="width: 100%" cellspacing="0" cellpadding="0">
            <tr style="height: 8px">
                <td style="width: 100%" align="left">
                    <asp:Label ID="lblSuccess" runat="server" CssClass="greenmsg"></asp:Label>
                    <asp:Label ID="lblError" runat="server" CssClass="redmsg"></asp:Label>
                </td>
            </tr>
        </table>
        <table width="100%" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <table width="100%" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="left">
                                <div class="headerback">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblHeading" runat="server" CssClass="header" Text="Post your offer in the given form"
                                                    meta:resourcekey="lblHeadingResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" class="headerback">
                                                <span style="color: Red">*</span>
                                                <asp:Label ID="lbloffermesg3" runat="server" Text="fields are mandatory.  Note: Do not leave any space while entering part numbers."
                                                    Style="font-size: medium; font-weight: 700" meta:resourcekey="lbloffermesg3Resource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table width="100%" cellspacing="0" cellpadding="0">
                                    <tr class="tablerow">
                                        <td width="12%" align="center">
                                            <span style="color: Red">*</span>
                                            <asp:Label ID="lblPartNumber" runat="server" Text="Part #" ForeColor="White" meta:resourcekey="lblPartNumberResource1"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                        <td width="10%" align="center">
                                            <span style="color: Red">*</span>
                                            <asp:Label ID="lblQuantity" runat="server" ForeColor="White" Text="Qty" meta:resourcekey="lblQuantityResource1"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                        <td width="13%" align="center">
                                            <span style="color: Red">*</span>
                                            <asp:Label ID="lblStockStatus" runat="server" ForeColor="White" Text="Stock Status"
                                                Font-Bold="true" meta:resourcekey="lblStockStatusResource1"></asp:Label>
                                        </td>
                                        <td width="13%" align="center">
                                            <asp:Label ID="lblMake" runat="server" Text="Make" ForeColor="White" meta:resourcekey="lblMakeResource1"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                        <td width="13%" align="center">
                                            <asp:Label ID="lbldateCode" runat="server" ForeColor="White" Text="Date Code" meta:resourcekey="lbldateCodeResource1"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                        <td width="13%" align="center">
                                            <asp:Label ID="lblPackage" runat="server" ForeColor="White" Text="Package" meta:resourcekey="lblPackageResource1"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                        <td width="13%" align="center">
                                            <asp:Label ID="lblDescription" runat="server" ForeColor="White" Text="Comment" meta:resourcekey="lblDescriptionResource1"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                        <%-- <td width="10%">
                                            <asp:Label ID="lblStockInHand" runat="server" ForeColor="White" Text="Stock In Hand"
                                                meta:resourcekey="lblStockInHandResource1"></asp:Label>
                                        </td>--%>
                                        <%--<td width="7%">
                                            <asp:Label ID="lblPriceInINR" runat="server" ForeColor="White" Text="Price In INR"
                                                meta:resourcekey="lblPriceInINRResource1"></asp:Label>
                                        </td>--%>
                                        <td width="13%" align="center">
                                            <asp:Label ID="lblPriceInUSD" runat="server" ForeColor="White" Text="Unit Price in USD"
                                                meta:resourcekey="lblPriceInUSDResource1" Font-Bold="true"></asp:Label>
                                        </td>
                                        <%--<td width="6%">
                                            <asp:Label ID="lblPriceInCNY" runat="server" ForeColor="White" Text="Price IN CNY"
                                                meta:resourcekey="lblPriceInCNYResource1"></asp:Label>
                                        </td>--%>
                                        <%-- <td width="10%">
                                            <asp:Label ID="lblCountry" runat="server" ForeColor="White" Text="Country" meta:resourcekey="lblCountryResource1"></asp:Label>
                                        </td>--%>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Repeater ID="rptOffers" runat="server">
                                    <ItemTemplate>
                                        <uc1:SellerInventories ID="SellerInventories1" runat="server" />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="text-align: center; width: 100%">
                        <tr>
                            <td align="right" style="padding-bottom: 5px; padding-top: 5px">
                                <asp:Button ID="btnSave" runat="server" CssClass="blue_button" Style="width: 90px"
                                    Text="Post" ValidationGroup="VgOne" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                            </td>
                            <td align="left">
                                <asp:Button ID="btnback" runat="server" CssClass="blue_button" Style="width: 90px;"
                                    Text="Back" ValidationGroup="VgOne" meta:resourcekey="btnbackResource1" OnClick="btnback_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
