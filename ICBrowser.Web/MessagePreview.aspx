<%@ Page Language="C#" Title="ICBrowser.com buy and sell electronic components" AutoEventWireup="true" CodeBehind="MessagePreview.aspx.cs"
    Inherits="ICBrowser.Web.MessagePreview" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>
    <%@ PreviousPageType VirtualPath="~/UserResponse.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ClickHereToPrint() {
            var panel = document.getElementById('divtoprint');
            var printWindow = window.open('', '', 'height = 1000, width = 1000');
            printWindow.document.write('<html><head><title>Print Preview</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 1000);
            return false;
        }
    </script>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
    <div id="divtoprint">
        <table width="100%">
            <tr>
                <td width="50%" align="left">
                    <asp:Literal ID="LitTos" runat="server" meta:resourcekey="LitTosResource1"></asp:Literal>
                </td>
                <td width="50%" align="right">
                    <asp:Literal ID="LitFroms" runat="server" meta:resourcekey="LitFromsResource1"></asp:Literal>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="0">
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td width="10%" align="right">
                                <asp:Label ID="lblSubject" runat="server" Text="Subject:" CssClass="black" meta:resourcekey="lblSubjectResource1"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:Label ID="lblSubjectValue" runat="server" Text="" CssClass="black" meta:resourcekey="lblSubjectValueResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10%" align="right">
                                <asp:Label ID="lblAttachment" runat="server" Text="Attachment:" CssClass="black"
                                    meta:resourcekey="lblAttachmentResource1"></asp:Label>
                            </td>
                            <td colspan="2">
                                <%--<asp:Label ID="lblAttachmentValue" runat="server" Text="" CssClass="black" meta:resourcekey="lblAttachmentValueResource1"></asp:Label>--%>
                                <asp:LinkButton ID="lblAttachmentValue" runat="server" Text="" CssClass="black" meta:resourcekey="lblAttachmentValueResource1"
                                    OnClick="lblAttachmentValue_Click"></asp:LinkButton>
                                <asp:Label ID="lblAttachmentURL" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="vertical-align:top;">
                                <asp:Label ID="lblMessage" runat="server" Text="Message" CssClass="black" meta:resourcekey="Label25Resource1"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:Literal ID="LiteralMessage" runat="server" meta:resourcekey="LiteralMessageResource1"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td colspan="3">
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="100%">            
            <tr>
            <td width="5%">
            </td>
                <td width="43%" align="right">
                    <%--<asp:ImageButton ID="print" runat="server" ImageUrl="~/Images/print_btn.png" OnClientClick="" />--%>
                    <asp:Button ID="print" runat="server" Text="Print" OnClientClick="ClickHereToPrint()"
                        CssClass="blue_button" />
                </td>
                <td width="10%" align="right">
                    <%--<asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Images/submit_btn.png"
                    OnClick="btnSubmit_Click" meta:resourcekey="btnSubmitResource1" />--%>
                    <asp:Button ID="btnSubmit" runat="server" Text="Send" OnClick="btnSubmit_Click" meta:resourcekey="btnSubmitResource1"
                        CssClass="blue_button" />
                </td>
                <td width="45%" align="left">
                    <%--<asp:ImageButton ID="BtnBack" runat="server" ImageUrl="~/Images/back_btn.png" meta:resourcekey="BtnBackResource1"
                    OnClick="BtnBack_Click1" />--%>
                  <%--  <asp:Button ID="BtnBack" runat="server" meta:resourcekey="BtnBackResource1" OnClick="BtnBack_Click1"
                        Text="Close" CssClass="blue_button" />--%>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
