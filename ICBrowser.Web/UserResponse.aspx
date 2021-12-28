<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="UserResponse.aspx.cs" Inherits="ICBrowser.Web.UserResponse"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function ismaxlength(objTxtCtrl, nLength) {
            if (objTxtCtrl.getAttribute && objTxtCtrl.value.length > nLength)
                objTxtCtrl.value = objTxtCtrl.value.substring(0, nLength)

            if (document.all)
                document.getElementById('lblCaption').innerText = objTxtCtrl.value.length + ' Out Of ' + nLength;
            else
                document.getElementById('lblCaption').textContent = objTxtCtrl.value.length + ' Out Of ' + nLength;
        }

    </script>
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
        .style1
        {
            color: red;
        }
        .style3
        {
            height: 10px;
            width: 1%;
        }
        .style4
        {
            height: 20px;
            width: 1%;
        }
        .style5
        {
            width: 1%;
        }
        
        .style8
        {
            width: 6px;
        }
        .style10
        {
            width: 10%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hfToUserDetails" runat="server" />
    <asp:HiddenField ID="hfFromUserDetails" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel ID="pnlMessagePopupss" runat="server" BackColor="#EFFBFE" meta:resourcekey="Panel2Resource1">
        <div id="divtoprint">
            <table style="height: 100%;" width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="left" colspan="3">
                        <asp:Label ID="lblError" runat="server" CssClass="redmsg" meta:resourcekey="lblErrorResource1"
                            Visible="False"></asp:Label>
                        <asp:Label ID="lblSend" runat="server" CssClass="greenmsg" Visible="False" meta:resourcekey="lblSendResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="3">
                        <div class="headerback">
                            <asp:Label ID="lblHeading" runat="server" Text="Send Message" CssClass="header" meta:resourcekey="lblSendResHead1"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="height: 5px;">
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 10%;">
                        <asp:Label ID="lbltextto" runat="server" Text="To:" CssClass="black"></asp:Label>
                    </td>
                    <%--<td align="center" style="width:5%">
                    </td>--%>
                    <td align="right" class="style5">
                        &nbsp;
                    </td>
                    <td style="width: 80%;">
                        <asp:TextBox ID="txtbxTo" runat="server" CssClass="smallinput_t" Height="22px" MaxLength="100"
                            ReadOnly="true" ValidationGroup="WithoutTemplate" Width="100%"></asp:TextBox>
                        <%--<asp:Label ID="lblTo" runat="server" Text="" CssClass="black"></asp:Label>--%>
                    </td>
                </tr>
                <tr>
                    <td style="height: 5px;">
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 10%;">
                        <asp:Label ID="LblFrom" runat="server" Text="From:" CssClass="black" meta:resourcekey="LblFromResource1"></asp:Label>
                    </td>
                    <%--<td align="center" style="width:5%">
                    </td>--%>
                    <td align="right" class="style5">
                        &nbsp;
                    </td>
                    <td style="width: 80%;">
                        <asp:TextBox ID="txtFrom" runat="server" CssClass="smallinput_t" Height="22px" MaxLength="100"
                            meta:resourcekey="txtFromResource1" ReadOnly="true" ValidationGroup="WithoutTemplate"
                            Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td class="style3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 10%;">
                        <span class="style1">*</span>
                        <asp:Label ID="lblSubject" runat="server" Text="Subject:" CssClass="black" meta:resourcekey="Label23Resource1"></asp:Label>
                    </td>
                    <td align="right" class="style5">
                        &nbsp;
                    </td>
                    <td style="width: 80%;">
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="smallinput_t" Height="22px"
                            MaxLength="100" meta:resourcekey="txtSubjectResource1" ValidationGroup="WithoutTemplate"
                            Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="style5">
                        &nbsp;
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtSubject"
                                        Display="Dynamic" ErrorMessage="Enter Subject" Text="Enter Subject" ForeColor="Red"
                                        SetFocusOnError="True" ValidationGroup="WithoutTemplate" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                </td>
                                <%-- <td>
                                    <asp:Image ID="load_img" runat="server" Height="30px" Width="30px" ImageUrl="~/Images/Processing.gif"
                                        Visible="false" />
                                </td>--%>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblAttachment" runat="server" Text="Attachment:" CssClass="black"
                            meta:resourcekey="lblAttachmentResource1"></asp:Label>
                    </td>
                    <td align="right" class="style5">
                        &nbsp;
                    </td>
                    <td>
                        <table style="margin-left: -5px">
                            <tr>
                                <td>
                                    <asp:FileUpload ID="FileAttachmentLoad" runat="server" Width="250px" />
                                    <%--   ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.txt|.TXT|.xls|.XLS)$"--%>
                                    <asp:LinkButton ID="lnkfileAttachment" runat="server" Text="" OnClick="lnkfileAttachment_Click"></asp:LinkButton>
                                    <%--<asp:HyperLink runat="server" ID="lnkfileAttachment" Text="" Visible="false"></asp:HyperLink>--%>
                                </td>
                                <td>
                                    <asp:Button ID="btnUpload" runat="server" BackColor="Transparent" CssClass="blue_button"
                                        Height="20px" meta:resourcekey="btnUploadResource1" OnClick="btnUpload_Click"
                                        Text="Upload" ValidationGroup="fileattach" Width="60px" />
                                    <asp:Button ID="btnDelete" runat="server" BackColor="Transparent" CausesValidation="False"
                                        CssClass="blue_button" Height="20px" meta:resourcekey="btDeleteResource1" OnClick="btnDelete_Click"
                                        Text="Remove" Visible="false" Width="60px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblerrormsg" runat="server" Visible="false" ForeColor="Red" Text=""></asp:Label>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateAttachment"
                                        ControlToValidate="FileAttachmentLoad" ErrorMessage="" ForeColor="Red" meta:resourcekey="CustomValidator1Resource1"
                                        ValidationGroup="fileattach"></asp:CustomValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="style5">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblattachmentMsg" runat="server" Text="Only .jpg, .jpeg, .bmp, .gif, .png, .pdf, .doc, .docx, .ppt, .zip, .rar files are allowed."
                            CssClass="black" meta:resourcekey="lblattachmentMsgResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td class="style4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="10%">
                    </td>
                    <td class="style5">
                        &nbsp;
                    </td>
                    <td width="90%">
                        <asp:Panel ID="RepPanels" runat="server" smartnavigation="true" meta:resourcekey="RepPanelsResource1">
                            <asp:Repeater ID="RepSendMsg" runat="server" OnItemDataBound="RepSendMsg_ItemDataBound"
                                OnItemCommand="RepSendMsg_ItemCommand">
                                <HeaderTemplate>
                                    <table border="1" width="100%">
                                        <tr style="background-color: #dfedf7">
                                            <td width="10%">
                                            </td>
                                            <td width="15%">
                                                <span style="color: Red">*</span>
                                                <asp:Label ID="lblPtno" runat="server" Text="Part #" Style="color: #000000; font-family: Verdana;
                                                    font-size: small; font-weight: bold;" meta:resourcekey="lblPtnoResource1"></asp:Label>
                                            </td>
                                            <td width="15%">
                                                <span style="color: Red">*</span>
                                                <asp:Label ID="lblQtity" runat="server" Text="Quantity" Style="color: #000000; font-family: Verdana;
                                                    font-size: small; font-weight: bold;" meta:resourcekey="lblQtityResource1"></asp:Label>
                                            </td>
                                            <td width="15%">
                                                <asp:Label ID="lblMake" runat="server" Text="Make" Style="color: #000000; font-family: Verdana;
                                                    font-size: small; font-weight: bold;" meta:resourcekey="lblMakeResource1"></asp:Label>
                                            </td>
                                            <td width="15%">
                                                <asp:Label ID="lblPackage" runat="server" Text="Package" Style="color: #000000; font-family: Verdana;
                                                    font-size: small; font-weight: bold;"></asp:Label>
                                            </td>
                                            <td width="15%">
                                                <asp:Label ID="lblDtcode" runat="server" Text="DateCode" Style="color: #000000; font-family: Verdana;
                                                    font-size: small; font-weight: bold;" meta:resourcekey="lblDtcodeResource1"></asp:Label>
                                            </td>
                                            <td width="15%" id="headUntPrcUSD" runat="server">
                                                <asp:Label ID="LblUntPrcUSD" runat="server" Text="Unit Price(USD)" Style="color: #000000;
                                                    font-family: Verdana; font-size: small; font-weight: bold;" meta:resourcekey="LblUntPrcUSDResource1"></asp:Label>
                                            </td>
                                            <td width="15%" id="headHeadDescription" runat="server">
                                                <asp:Label ID="LblHeadDescription" runat="server" Text="Comments" Style="color: #000000;
                                                    font-family: Verdana; font-size: small; font-weight: bold;" meta:resourcekey="LblHeadDescriptionResource1"></asp:Label>
                                            </td>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td width="10%">
                                                <asp:Label ID="lblshow" runat="server" Style="font-family: Verdana; font-size: small;"
                                                    CssClass="black" meta:resourcekey="lblshowResource1"></asp:Label>
                                            </td>
                                            <td width="15%">
                                                <asp:Label ID="lblpartNo" runat="server" Style="font-family: Verdana; font-size: small;"
                                                    CssClass="black" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentName") %>'
                                                    meta:resourcekey="lblpartNoResource1"></asp:Label>
                                            </td>
                                            <td width="15%">
                                                <asp:Label ID="lblQuantity" runat="server" Style="font-family: Verdana; font-size: small;"
                                                    CssClass="black" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>'
                                                    meta:resourcekey="lblQuantityResource1"></asp:Label>
                                            </td>
                                            <td width="15%">
                                                <asp:Label ID="lblMake" runat="server" CssClass="black" Style="font-family: Verdana;
                                                    font-size: small;" Text='<%# DataBinder.Eval(Container.DataItem, "BrandName") %>'
                                                    meta:resourcekey="lblMakeResource2"></asp:Label>
                                            </td>
                                            <td width="15%">
                                                <asp:Label ID="lblPackage" runat="server" CssClass="black" Style="font-family: Verdana;
                                                    font-size: small;" Text='<%# DataBinder.Eval(Container.DataItem, "Package") %>'></asp:Label>
                                            </td>
                                            <td width="15%">
                                                <asp:Label ID="lblDateCode" runat="server" CssClass="black" Style="font-family: Verdana;
                                                    font-size: small;" Text='<%# DataBinder.Eval(Container.DataItem, "DateCode") %>'
                                                    meta:resourcekey="lblDateCodeResource1"></asp:Label>
                                            </td>
                                            <td width="15%" id="lblUnitPrce" runat="server">
                                                <asp:Label ID="lblUnitPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PriceInUSD") %>'
                                                    Style="font-family: Verdana; font-size: small;" CssClass="black" meta:resourcekey="lblUnitPriceResource1"></asp:Label>
                                            </td>
                                            <td id="lblComnt" width="15%" runat="server">
                                                <asp:Label ID="lblComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'
                                                    Style="font-family: Verdana; font-size: small;" CssClass="black" meta:resourcekey="lblCommentsResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                <asp:CheckBox ID="chckbx" runat="server" ToolTip="Select the user" />
                                                <asp:Label ID="lblNeed" runat="server" Style="font-family: Verdana; font-size: small;"
                                                    CssClass="black" meta:resourcekey="lblNeedResource1">
                                                </asp:Label>
                                            </td>
                                            <td width="15%">
                                                <asp:TextBox ID="txtpartNo" runat="server" CssClass="black" Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentName") %>'
                                                    meta:resourcekey="txtpartNoResource1" MaxLength="50" ValidationGroup="WithoutTemplate"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtpartNo" runat="server" ControlToValidate="txtpartNo"
                                                    Display="Dynamic" Text="Enter Part No" ForeColor="Red" SetFocusOnError="True"
                                                    ValidationGroup="WithoutTemplate" meta:resourcekey="rfvtxtpartNoResource1"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rgvtxtpartNo" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                    Display="Dynamic" ValidationGroup="WithoutTemplate" ControlToValidate="txtpartNo"
                                                    ForeColor="Red" ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtpartNoResource1"></asp:RegularExpressionValidator>
                                            </td>
                                            <td width="15%">
                                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="black" Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>'
                                                    meta:resourcekey="txtQuantityResource1" MaxLength="9" ValidationGroup="WithoutTemplate"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtQuantity" runat="server" ControlToValidate="txtQuantity"
                                                    Display="Dynamic" Text="Enter Quantity" ForeColor="Red" SetFocusOnError="True"
                                                    ValidationGroup="WithoutTemplate" meta:resourcekey="rfvtxtQuantityResource1"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rgvQuantity" runat="server" ControlToValidate="txtQuantity"
                                                    ErrorMessage="Enter Integer Only." ValidationExpression="^[0-9]+$" ForeColor="Red"
                                                    Display="Dynamic" ValidationGroup="WithoutTemplate" meta:resourcekey="rgvQuantityResource1"></asp:RegularExpressionValidator>
                                            </td>
                                            <td width="15%">
                                                <asp:TextBox ID="txtMake" runat="server" MaxLength="30" CssClass="black" Width="100px"
                                                    Text='<%# DataBinder.Eval(Container.DataItem, "BrandName") %>' meta:resourcekey="txtMakeResource1"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rgvtxtMake" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                    Display="Dynamic" ValidationGroup="WithoutTemplate" ControlToValidate="txtMake"
                                                    ForeColor="Red" ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtMakeResource1"></asp:RegularExpressionValidator>
                                            </td>
                                            <td width="15%">
                                                <asp:TextBox ID="txtPackage" runat="server" MaxLength="30" CssClass="black" Width="100px"
                                                    Text='<%# DataBinder.Eval(Container.DataItem, "Package") %>'></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rgvtxtPackage" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                    Display="Dynamic" ValidationGroup="WithoutTemplate" ControlToValidate="txtPackage"
                                                    ForeColor="Red" ValidationExpression="^((?![<>]).)*$"></asp:RegularExpressionValidator>
                                            </td>
                                            <td width="15%">
                                                <asp:TextBox ID="txtDateCode" runat="server" CssClass="black" MaxLength="30" Width="100px"
                                                    Text='<%# DataBinder.Eval(Container.DataItem, "DateCode") %>' meta:resourcekey="txtDateCodeResource1"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rgvtxtDateCode" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                    Display="Dynamic" ValidationGroup="WithoutTemplate" ControlToValidate="txtDateCode"
                                                    ForeColor="Red" ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtDateCodeResource1"></asp:RegularExpressionValidator>
                                            </td>
                                            <td width="16%" id="txtUSD" runat="server">
                                                <asp:TextBox ID="txtUnitPriceUSD" runat="server" MaxLength="18" CssClass="black"
                                                    Width="100px" ValidationGroup="WithoutTemplate" meta:resourcekey="txtUnitPriceUSDResource1"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revpriceusd" ControlToValidate="txtUnitPriceUSD"
                                                    ValidationGroup="WithoutTemplate" runat="server" ErrorMessage="Enter Numeric Value Upto 3 Decimal"
                                                    ForeColor="Red" Display="Dynamic" ValidationExpression="^\d{0,9}(\.\d{1,3})?$"
                                                    meta:resourcekey="revpriceusdResource1"></asp:RegularExpressionValidator>
                                            </td>
                                            <td width="14%" id="txtCommnt" runat="server">
                                                <asp:TextBox ID="txtComments" runat="server" MaxLength="500" CssClass="black" Width="80px"
                                                    Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>' meta:resourcekey="txtCommentsResource1"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rgvtxtComments" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                    Display="Dynamic" ValidationGroup="WithoutTemplate" ControlToValidate="txtComments"
                                                    ForeColor="Red" ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtCommentsResource1"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 10%;" valign="top">
                        <span class="style1">*</span>
                        <asp:Label ID="lblMessage" runat="server" Text="Message:" CssClass="black" meta:resourcekey="Label25Resource1"></asp:Label>
                    </td>
                    <td valign="top" align="right" class="style5">
                        &nbsp;
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtContent" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_multilinetextbox"
                            Height="100px" meta:resourcekey="txtContentResource1" onkeyup="return ismaxlength(this,500)"
                            Font-Names="Calibri" Font-Size="12" TextMode="MultiLine" ValidationGroup="WithoutTemplate"
                            Width="99%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="style5">
                        &nbsp;
                    </td>
                    <td>
                        <label id='lblCaption' style="font-family: Tahoma; font-size: 1em; font-weight: bold">
                        </label>
                        <table width="100%">
                            <tr>
                                <td align="left" colspan="3">
                                    <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtContent"
                                        Display="Dynamic" ForeColor="Red" meta:resourcekey="RequiredFieldValidator3Resource1"
                                        SetFocusOnError="True" Text="Enter Message" ValidationGroup="WithoutTemplate"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style10">
                                    <asp:Button ID="btnPrintPreview" runat="server" CssClass="blue_button" Style="width: 110px;"
                                        Text="View Message" meta:resourcekey="btnPrintPreviewResource1" OnClick="btnPrintPreview_Click"
                                        ValidationGroup="WithoutTemplate" />
                                </td>
                                <td width="90%">
                                    <asp:Button ID="btnCancelMessage" runat="server" CssClass="blue_button" Style="width: 110px;"
                                        Text="Cancel Message" meta:resourcekey="btnCancelMessageResource1" OnClick="btnCancelMessage_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="3">
                                    <asp:Label ID="lblErMessage" runat="server" Text="*Note:-Please allow pop-up to preview and send message."
                                        Font-Size="Smaller" meta:resourcekey="lblErMessageResource1"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <%-- <table width="100%">
            <tr>
                <td width="10%">
                </td>
                <td width="10%" align="right">
                    <asp:Button ID="btnPrintPreview" runat="server" CssClass="blue_button" Style="width: 110px;"
                        Text="Preview Message" meta:resourcekey="btnPrintPreviewResource1" OnClick="btnPrintPreview_Click"
                        ValidationGroup="WithoutTemplate" />
                </td>
                <td width="10%" align="right">
                    <asp:Button ID="btnCancelMessage" runat="server" CssClass="blue_button" Style="width: 110px;"
                        Text="Cancel Message" meta:resourcekey="btnCancelMessageResource1" ValidationGroup="WithoutTemplate"
                        OnClick="btnCancelMessage_Click" />
                </td>
                <td width="70%">
                </td>
            </tr>
        </table>--%>
        <div id="divOffer" runat="server" visible="false">
            <table width="100%" align="center">
                <tr>
                    <td align="right" style="width: 10%;" valign="top">
                        <asp:Label ID="Label1" runat="server" Text="Message Template:" meta:resourcekey="lblMessagesResource1"></asp:Label>
                    </td>
                    <td class="style8">
                    </td>
                    <td>
                        <table border="1" width="100%">
                            <tr>
                                <td>
                                    <p>
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="HandleLinkClick" Text="Quote your best price and delivery."></asp:LinkButton>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>
                                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="HandleLinkClick" Text="Part should be new /unused."></asp:LinkButton>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>
                                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="HandleLinkClick" Text="Send your quotation."></asp:LinkButton>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>
                                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="HandleLinkClick" Text="Do you still have parts?"></asp:LinkButton>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>
                                        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="HandleLinkClick" Text="Send PI."></asp:LinkButton>
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divRequirement" runat="server" visible="false">
            <table width="100%" align="center">
                <tr>
                    <td align="right" style="width: 10%;" valign="top">
                        <asp:Label ID="lblMessages" runat="server" Text="Message Template:" meta:resourcekey="lblMessagesResource1"></asp:Label>
                    </td>
                    <td class="style8">
                    </td>
                    <td>
                        <table border="1" width="100%">
                            <tr>
                                <td>
                                    <p>
                                        <asp:LinkButton ID="lnk1" runat="server" OnClick="HandleLinkClick" Text="My best offer is."></asp:LinkButton>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>
                                        <asp:LinkButton ID="lnk2" runat="server" OnClick="HandleLinkClick" Text="Give your target price."></asp:LinkButton>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>
                                        <asp:LinkButton ID="lnk3" runat="server" OnClick="HandleLinkClick" Text="Delivery period."></asp:LinkButton>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>
                                        <asp:LinkButton ID="lnk4" runat="server" OnClick="HandleLinkClick" Text="Please call."></asp:LinkButton>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>
                                        <asp:LinkButton ID="lnk5" runat="server" OnClick="HandleLinkClick" Text="My trade references."></asp:LinkButton>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>
                                        <asp:LinkButton ID="lnk6" runat="server" OnClick="HandleLinkClick" Text="My bank details."></asp:LinkButton>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>
                                        <asp:LinkButton ID="lnk7" runat="server" OnClick="HandleLinkClick" Text="Send PO."></asp:LinkButton>
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- <asp:Button ID="Button1" runat="server" Text="Button" Visible="false" />
   
    <asp:ModalPopupExtender ID="modpopPreview" runat="server"   PopupControlID="pnlPreview"   
        TargetControlID="Button1" BackgroundCssClass="modalBackground"   DynamicServicePath="" CancelControlID="btnCancelMessage"
        Enabled="True" >
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPreview" runat="server" Height="50%" Width="100%">
   <iframe id="frame1"   runat="server" src="MessagePreview.aspx" scrolling="auto" 
            style="vertical-align:middle; padding-left:10px; width: 100%;" ></iframe>
</asp:Panel>--%>
    <div>
        <table>
            <tr>
                <td align="center">
                    <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" meta:resourcekey="LinkButton6Resource1"></asp:LinkButton>
                    <asp:ModalPopupExtender ID="modpopPreview" runat="server" PopupControlID="pnlPreview"
                        TargetControlID="LinkButton6" BackgroundCssClass="modalBackground" DynamicServicePath=""
                        Enabled="True">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlPreview" runat="server" meta:resourcekey="pnlPreviewResource1">
                        <asp:UpdatePanel runat="server" ID="upnlPreview">
                            <ContentTemplate>
                                <div style="width: 100%;" class="popupbox">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="popupbox-lefttop-corner">
                                            </td>
                                            <td class="popupbox-topbg">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="97%" align="left" class="popupbox-header">
                                                            <asp:Label ID="lblPreview" runat="server" Text="Message Preview" CssClass="title"></asp:Label>
                                                        </td>
                                                        <td width="3%" align="center" valign="middle" class="popupbox-header">
                                                            <asp:ImageButton ID="ImgbtnCancel" ImageUrl="~/Images/cross.png" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="popupbox-righttop-corner">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="popupbox-leftbg">
                                            </td>
                                            <td align="center" valign="top" class="popupbox-content">
                                                <table width="100%" style="height: 100%;" border="0" cellpadding="5" cellspacing="0">
                                                    <tr id="trUploadedFile" runat="server">
                                                        <td id="Td1" align="left" runat="server">
                                                            <iframe id="frame1" runat="server" src="MessagePreview.aspx" frameborder="0" scrolling="auto"
                                                                style="vertical-align: middle; width: 800px; height: 300px;"></iframe>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="btnPreviewClose" runat="server" Text="Close" Width="60px" CausesValidation="False"
                                                                CssClass="blue_button" meta:resourcekey="btnPreviewCloseResource1" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="popupbox-rightbg">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="popupbox-leftbtm-corner">
                                            </td>
                                            <td class="popupbox-bottombg">
                                            </td>
                                            <td class="popupbox-rightbtm-corner">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnPreviewClose" />
                                <asp:PostBackTrigger ControlID="ImgbtnCancel" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
