<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeBehind="Mailbox.aspx.cs" Inherits="ICBrowser.Web.Mailbox"
    Culture="auto" UICulture="auto" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">

        function ValidateAttachment(Source, args) {
            var UploadControl = document.getElementById('<%= FileAttachmentLoad.ClientID %>');

            var FilePath = UploadControl.value;

            if (FilePath == '') {
                args.IsValid = false;
                alert('No file found'); //
            }
            else {
                var Extension = FilePath.substring(FilePath.lastIndexOf('.') + 1).toLowerCase();
                //                Extension == "txt" || Extension == "pdf" || Extension == "doc" || Extension == "docx" || Extension == "pdf" ||Extension == "ppt" ||
                if (
                Extension == "jpg" || Extension == "bmp" || Extension == "png" || Extension == "jpeg" || Extension == "gif" || Extension == "pdf" || Extension == "doc" || Extension == "docx" || Extension == "ppt" || Extension == "zip" || Extension == "rar") {
                    args.IsValid = true;

                }
                else {
                    args.IsValid = false;
                    alert('Not valid file type'); // 
                }
            }
        }

    </script>
    <style type="text/css">
        .greenmsg
        {
            width: 99%;
            margin: 15px 0 0 0;
            padding: 8px;
            float: left;
            color: #3b8704;
            border: #54de20 solid 1px;
            text-align: left;
            padding: 5px;
            background-color: #dcf9d8;
            font-weight: bold;
        }
        
        .redmsg
        {
            margin: 15px 0 0 0;
            padding: 8px;
            float: left;
            color: #b70606;
            border: #dc6666 solid 1px;
            text-align: left;
            padding: 5px;
            background-color: #fac8bf;
            font-weight: bold;
        }
        .style1
        {
            height: 20px;
        }
        .style2
        {
            width: 94%;
        }
        .style3
        {
            height: 20px;
            width: 94%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td>
                    <asp:Label ID="lblSentMessage" Visible="False" CssClass="greenmsg" runat="server"
                        meta:resourcekey="lblSentMessageResource1"></asp:Label>
                    <asp:Label ID="lblnotSentMessage" Visible="False" CssClass="redmsg" runat="server"
                        meta:resourcekey="lblnotSentMessageResource1"></asp:Label>
                </td>
            </tr>
        </table>
        <div align="left" class="light-blue-bg">
            <asp:Panel ID="Panel1" runat="server" Width="100%" meta:resourcekey="Panel1Resource1">
                <table width="100%">
                    <tr>
                        <td class="headerback">
                            <asp:Label ID="lblReadMessage" runat="server" CssClass="header" Text="Reading Message"
                                meta:resourcekey="lblReadMessageResource1"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table align="center" width="100%">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td colspan="3">
                                        <table cellspacing="0" cellpadding="0" width="100%">
                                            <tr>
                                                <td width="5%" align="left">
                                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="blue_button" meta:resourcekey="btnBackResource1"
                                                        OnClick="btnBack_Click" Width="70px" />
                                                    <%-- <asp:Button ID="btnDelete" runat="server" Text="Back" CssClass="blue_button" OnClick="btnDelete_Click"
                                                        meta:resourcekey="btnDeleteResource1" />--%>
                                                </td>
                                                <td width="10%" align="left">
                                                    <asp:Button ID="btnResponse" runat="server" Text="Response" CssClass="blue_button"
                                                        OnClick="btnResponse_Click" meta:resourcekey="btnResponseResource1" Width="70px" />
                                                </td>
                                                <td width="85%">
                                                    <asp:LinkButton ID="lnkAttachment" Text="Download Attachment" Visible="false" runat="server"
                                                        OnClick="lnkAttachment_Click" meta:resourcekey="lnkAttachmentResource1"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="background-color: #dfedf7">
                                    <td width="10%" align="left">
                                        <asp:Label ID="lblLastUpdate" runat="server" Text="Last Update:" Style="color: #000000;
                                            font-size: small;" meta:resourcekey="lblLastUpdateResource1"></asp:Label>
                                    </td>
                                    <td align="left" class="style2">
                                        <asp:Label ID="lblLastUpdateValue" runat="server" Style="font-size: small; color: #000000;"
                                            meta:resourcekey="lblLastUpdateValueResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="10%" align="left" class="style1">
                                        <asp:Label ID="lblsubject" runat="server" Text="Subject:" Style="font-size: small;
                                            color: #000000; font-family: Verdana" meta:resourcekey="lblsubjectResource1"></asp:Label>
                                    </td>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblsubjectValue" runat="server" Style="font-size: small; color: #000000;
                                            font-family: Verdana" meta:resourcekey="lblsubjectValueResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="background-color: #dfedf7">
                                    <td width="10%" align="left" class="style1">
                                        <asp:Label ID="lblfrom" runat="server" Text="From:" Style="font-size: small; color: #000000;
                                            font-family: Verdana" meta:resourcekey="lblfromResource1"></asp:Label>
                                    </td>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblfromValue" runat="server" Style="font-size: small; color: #000000;
                                            font-family: Verdana" meta:resourcekey="lblfromValueResource1"></asp:Label>
                                        <asp:LinkButton ID="lnkCompanyName" runat="server" Visible="false" OnClick="lnkCompanyName_Click1"> </asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="10%" align="left">
                                        <asp:Label ID="lblTo1" runat="server" Text="To:" Style="font-size: small; color: #000000;
                                            font-family: Verdana" meta:resourcekey="lblTo1Resource1"></asp:Label>
                                    </td>
                                    <td align="left" class="style2">
                                        <asp:Label ID="lblTo1Value" runat="server" Style="font-size: small; color: #000000;
                                            font-family: Verdana" meta:resourcekey="lblTo1ValueResource1"></asp:Label>
                                        <asp:LinkButton ID="lnkToCompanyName" Visible="false" runat="server" OnClick="lnkToCompanyName_Click1"> </asp:LinkButton>
                                    </td>
                                </tr>
                                <tr style="background-color: #dfedf7">
                                    <td valign="top" width="10px">
                                        <asp:Label ID="lblMessage" Text="Message:" runat="server" Style="font-size: small;
                                            color: #000000; vertical-align: top; font-family: Verdana;" meta:resourcekey="lblMessageResource1"></asp:Label>
                                    </td>
                                    <td width="90%" align="left">
                                        <asp:Literal ID="txtMsg" runat="server" meta:resourcekey="txtMsgResource1"></asp:Literal>
                                        <%--<asp:TextBox ID="txtMessageValue" runat="server" Enabled="false" CssClass="input-mailbox700"
                                            Style="font-size: small; color: #000000; font-family: Verdana" TextMode="MultiLine"
                                            meta:resourcekey="txtMessageValueResource1"></asp:TextBox>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" DefaultButton="btnSubmit" Width="100%" Visible="False"
                meta:resourcekey="Panel2Resource1">
                <table width="100%" class="headerback">
                    <tr>
                        <td width="90%" >
                            <asp:Label ID="lblReply" runat="server" CssClass="header" Text="Replying Message"
                                meta:resourcekey="lblReplyResource1"></asp:Label>
                        </td>
                        <td width="5%" class="headerback">
                            <asp:Button ID="btnSubmit" runat="server" Text="Send" CssClass="blue_button" ValidationGroup="a"
                                OnClick="btnSubmit_Click" meta:resourcekey="btnSubmitResource1" Width="70px" />
                        </td>
                        <td width="5%" class="headerback">
                            <asp:Button ID="btnCancel" runat="server" Text="Discard" CssClass="blue_button" OnClick="btnCancel_Click"
                                meta:resourcekey="btnCancelResource1" Width="70px" />
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td width="10%">
                                        <asp:Label ID="lblTo" runat="server" Text="To:" Style="font-size: small; color: #000000;
                                            font-family: Verdana" meta:resourcekey="lblToResource1"></asp:Label>
                                    </td>
                                    <td width="90%">
                                        <asp:TextBox ID="txtTo" runat="server" Height="19px" Enabled="false" Width="475px"
                                            CssClass="smallinput_t" meta:resourcekey="txtToResource1"></asp:TextBox>
                                        <%--   <asp:RequiredFieldValidator ID="rfvtxtTo" runat="server" ControlToValidate="txtTo"
                                        ErrorMessage="Please Enter Contact Name" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                        ValidationGroup="a" meta:resourcekey="rfvtxtToResource1" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSubject1" runat="server" Text="Subject:" Style="font-size: small;
                                            color: #000000;" meta:resourcekey="lblSubject1Resource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReplySubject" runat="server" Height="20px" Width="473px" CssClass="smallinput_t"
                                            meta:resourcekey="txtReplySubjectResource1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtReplySubject" runat="server" ControlToValidate="txtReplySubject"
                                            ErrorMessage="Please Enter Subject" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                            ValidationGroup="a" meta:resourcekey="rfvtxtReplySubjectResource1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblMsg" runat="server" Text="Message:" Style="font-size: small; color: #000000;
                                            font-family: Verdana" meta:resourcekey="lblMsgResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReplyMessage" runat="server" CssClass="smallinput_t_multilinetextbox100"
                                            Font-Names="Calibri" Font-Size="12" TextMode="MultiLine" meta:resourcekey="txtReplyMessageResource1"
                                            OnTextChanged="txtReplyMessage_TextChanged"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvtxtReplyMessage" runat="server" ControlToValidate="txtReplyMessage"
                                            ErrorMessage="Please Enter Message" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                            ValidationGroup="a" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblAttachment" runat="server" Text="Attachment:" CssClass="black"
                                            meta:resourcekey="lblAttachmentResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:FileUpload ID="FileAttachmentLoad" runat="server" Width="250px" />
                                                    <%--   ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.txt|.TXT|.xls|.XLS)$"--%>
                                                    <asp:LinkButton ID="lnkfileAttachment" runat="server" Text="" Visible="false" OnClick="lnkfileAttachment_Click"></asp:LinkButton>
                                                    <%--<asp:HyperLink runat="server" ID="lnkfileAttachment" Text="" Visible="false"></asp:HyperLink>--%>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnUpload" runat="server" BackColor="Transparent" CssClass="blue_button"
                                                        Height="20px" meta:resourcekey="btnUploadResource1" Text="Upload" ValidationGroup="fileattach"
                                                        OnClick="btnUpload_Click" Width="60px" />
                                                    <asp:Button ID="btnDelete" runat="server" BackColor="Transparent" CausesValidation="False"
                                                        CssClass="blue_button" Height="20px" meta:resourcekey="btDeleteResource1" Text="Remove"
                                                        OnClick="btnDelete_Click" Visible="false" Width="60px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblerrormsg" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateAttachment"
                                                        ControlToValidate="FileAttachmentLoad" ErrorMessage=""
                                                        ForeColor="Red" meta:resourcekey="CustomValidator1Resource1" ValidationGroup="fileattach"></asp:CustomValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="lblattachmentMsg" runat="server" Text="Only .jpg, .jpeg, .bmp, .gif, .png, .pdf, .doc, .docx, .ppt, .zip, .rar files are allowed."
                                            CssClass="black" meta:resourcekey="lblattachmentMsgResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblhistory" runat="server" Text="History:" meta:resourcekey="lblhistoryResource2"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr style="background-color: #dfedf7">
                                    <td>
                                    </td>
                                    <td width="85%">
                                        <asp:Literal ID="Lithistory" runat="server" meta:resourcekey="LithistoryResource1"></asp:Literal>
                                        <%--  <asp:TextBox ID="txthistory" runat="server" Enabled="false" CssClass="smallinput_t_multilinetextbox"
                                            Style="font-size: small; color: #000000; font-family: Verdana" TextMode="MultiLine"></asp:TextBox>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
