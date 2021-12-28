<%@ Page Language="C#" Title="ICBrowser.com buy and sell electronic components" AutoEventWireup="true"
    MasterPageFile="~/Site.Master" CodeBehind="ContactUs.aspx.cs" Inherits="ICBrowser.Web.ContactUs"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table width="100%" border="1">
        <tr>
            <td colspan="2" class="headerback">
                <asp:Label ID="lblHead" runat="server" Text="Contact Us" CssClass="header" meta:resourcekey="lblHeadResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="290px" align="left" valign="top">
                <asp:Image ID="Img" runat="server" Height="162px" Width="285px" meta:resourcekey="ImgResource1" />
            </td>
            <td align="left" valign="top">
                <asp:Label ID="CorporateOffice" Text="Corporate Office:" Font-Bold="False" ForeColor="#6699FF"
                    Font-Size="Large" runat="server" meta:resourcekey="CorporateOfficeResource1"></asp:Label>
                <br />
                <asp:Label ID="lblInfo" runat="server" CssClass="lblInfo" Font-Size="Small" meta:resourcekey="lblInfoResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="chart_bg">
                    <div class="headerback">
                        <asp:Label ID="lblHeader" runat="server" Text="E-mail Aliases" CssClass="header"
                            meta:resourcekey="lblHeaderResource1"></asp:Label>
                    </div>
                    <table width="100%">
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblCustService" runat="server" Text="Customer Service:" Font-Bold="True"
                                    CssClass="chart_contact_bg" meta:resourcekey="lblCustServiceResource1"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblAdvertisement" runat="server" Text="Advertisement:" Font-Bold="True"
                                    CssClass="chart_contact_bg" meta:resourcekey="lblAdvertisementResource1"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblSales" runat="server" Text="Sales Office:" Font-Bold="True" CssClass="chart_contact_bg"
                                    meta:resourcekey="lblSalesResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="22px">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/gv-mobile-icon.png" Height="22px"
                                    Width="22px" meta:resourcekey="Image1Resource1" />
                            </td>
                            <td>
                                <asp:Label ID="lblCustServcPno" runat="server" Font-Size="Small" meta:resourcekey="lblCustServcPnoResource1"></asp:Label>
                            </td>
                            <td width="22px">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/gv-mobile-icon.png" Height="22px"
                                    Width="22px" meta:resourcekey="Image3Resource1" />
                            </td>
                            <td>
                                <asp:Label ID="lblAddPno" runat="server" Font-Size="Small" meta:resourcekey="lblAddPnoResource1"></asp:Label>
                            </td>
                            <td width="22px">
                                <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/gv-mobile-icon.png" Height="22px"
                                    Width="22px" meta:resourcekey="Image5Resource1" />
                            </td>
                            <td>
                                <asp:Label ID="lblSalesofcPno" runat="server" Font-Size="Small" meta:resourcekey="lblSalesofcPnoResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/email_icon.gif" Height="22px"
                                    Width="22px" meta:resourcekey="Image2Resource1" />
                            </td>
                            <td>
                                <%--<asp:Label ID="lblCustServcEmailId" runat="server" Font-Size="Small" meta:resourcekey="lblCustServcEmailIdResource1"></asp:Label>--%>
                                <asp:LinkButton ID="LnkCustServcEmailId" runat="server" OnClick="LnkCustServcEmailId_Click" />
                            </td>
                            <td>
                                <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/email_icon.gif" Height="22px"
                                    Width="22px" meta:resourcekey="Image4Resource1" />
                            </td>
                            <td>
                                <%--<asp:Label ID="lblAddEmailId" runat="server" Font-Size="Small" meta:resourcekey="lblAddEmailIdResource1"></asp:Label>--%>
                                <asp:LinkButton ID="lnkbtnAddEmailId" runat="server" OnClick="lnkbtnAddEmailId_Click" />
                            </td>
                            <td>
                                <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/email_icon.gif" Height="22px"
                                    Width="22px" meta:resourcekey="Image6Resource1" />
                            </td>
                            <td>
                                <%--<asp:Label ID="lblSalesofcEmail" runat="server" Font-Size="Small" meta:resourcekey="lblSalesofcEmailResource1"></asp:Label>--%>
                                <asp:LinkButton ID="lnkbtnSalesofcEmail" runat="server" OnClick="lnkbtnSalesofcEmail_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
