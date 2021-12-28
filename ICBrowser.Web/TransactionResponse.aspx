<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="TransactionResponse.aspx.cs" Inherits="ICBrowser.Web.TransactionResponse"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
    <div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="2">
                    <center>
                        <div runat="server" id="divStatus">
                            <table cellpadding="0" cellspacing="0" border="0" id="table_border" width="100%">
                                <tr style="background-color: #dfedf7">
                                    <td align="center" class="style2" colspan="2">
                                        <asp:Label ID="Label6" Text="Transaction Successfull" runat="server" Font-Bold="True"
                                            meta:resourcekey="Label6Resource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="background-color: #dfedf7">
                                    <td align="center" class="style2">
                                        <asp:Label ID="Label1" runat="server" Text="Order No.:" meta:resourcekey="Label1Resource1"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblOrderId" runat="server" meta:resourcekey="lblOrderIdResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="style2">
                                        <asp:Label ID="Label2" runat="server" Text="Status:" meta:resourcekey="Label2Resource1"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblStatus" runat="server" meta:resourcekey="lblStatusResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="background-color: #dfedf7">
                                    <td align="center" class="style2">
                                        <asp:Label ID="Label3" runat="server" Text="Amount:" meta:resourcekey="Label3Resource1"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblAmount" runat="server" meta:resourcekey="lblAmountResource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </center>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <center>
                        <asp:Panel ID="pnlCompDet" runat="server" meta:resourcekey="pnlCompDetResource1">
                            <div runat="server" class="Company" id="grid">
                                <table cellpadding="0" cellspacing="0" border="0" id="table_border" width="100%">
                                    <tr style="background-color: #dfedf7">
                                        <td align="center" class="style2" colspan="2">
                                            <asp:Label ID="Label8" Text="Error occured:" runat="server" meta:resourcekey="Label8Resource1"
                                                Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="style2">
                                            <asp:Label ID="Label4" runat="server" Text="Reference Id:" meta:resourcekey="Label4Resource1"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblReferenceId" runat="server" meta:resourcekey="lblReferenceIdResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #dfedf7">
                                        <td align="center" class="style2">
                                            <asp:Label ID="Label5" runat="server" Text="Error details:" meta:resourcekey="Label5Resource1"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblError" runat="server" meta:resourcekey="lblErrorResource1"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </center>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnOkay" runat="server" Text="Okay" CssClass="signinbutt" OnClick="btnOkay_Click"
                        meta:resourcekey="btnOkayResource1" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
