<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SellerProfile.aspx.cs" Inherits="ICBrowser.Web.SellerProfile" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 198px;
        }
        .style5
        {
            width: 148px;
        }
        .style17
        {
            width: 423px;
            border-left: 1px solid #ccc;
        }
        .style18
        {
            width: 148px;
            height: 76px;
        }
        .style19
        {
            height: 76px;
            border-left: 1px solid #ccc;
        }
        .style20
        {
            height: 76px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
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
    <asp:Panel ID="Panel1" runat="server" meta:resourcekey="Panel1Resource1">
        <div style="height: 540px; width: 100%">
            <table width="100%" style="height: 100%" border="0" cellspacing="0" class="table_border">
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style18">
                        <%-- <table width="100%" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="left" style="width: 25%;">--%>
                        <asp:Label ID="lblCompnyName" Text="Company Name:" runat="server" CssClass="black"
                            meta:resourcekey="lblCompnyNameResource1" Font-Bold="True" />
                    </td>
                    <td align="left" colspan="2" class="style19">
                        <asp:Label ID="lblCompanyName" runat="server" meta:resourcekey="lblCompanyNameResource1"></asp:Label>
                    </td>
                    <%--  </tr>
                        </table>--%>
                    <td width="30%" class="style20">
                        <table width="100%" cellspacing="0" cellpadding="2">
                            <tr>
                                <td align="center" style="width: 65%;">
                                    <asp:Label ID="lblAddFavoriteText" runat="server" Text="Add to favorite :" CssClass="black"
                                        Font-Bold="True" meta:resourcekey="lblAddFavoriteTextResource1"></asp:Label>
                                </td>
                                <td align="left" style="width: 35%;">
                                    <asp:ImageButton ID="imgbtnaddFav" runat="server" ImageUrl="Images/star.png" ToolTip="Add Favourite"
                                        OnClick="imgbtnaddFav_Click" meta:resourcekey="imgbtnaddFavResource1" />
                                </td>
                            </tr>
                            <tr id="trCurrntrate" runat="server">
                                <td align="center" style="width: 10%">
                                    <asp:Label ID="lblCurentRating" CssClass="black" runat="server" Font-Bold="True"
                                        meta:resourcekey="lblCurentRatingTextResource2" Text="Current Rating :"></asp:Label>
                                </td>
                                <td align="center" valign="middle" style="width: 25%;">
                                    <asp:Rating ID="ratingSeller" runat="server" Height="20px" Visible="true" StarCssClass="ratingStar"
                                        BackColor=" #dfedf7" Width="100%" ReadOnly="true" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar">
                                    </asp:Rating>
                                </td>
                            </tr>
                            <tr id="trratelink" runat="server">
                                <td width="35%" colspan="2" align="right">
                                    <asp:LinkButton ID="lnkRate" runat="server" Text="Give Ratings" OnClick="lnkRate_Click"
                                        meta:resourcekey="lnkRateResource2"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="Label1" Text="Owner Name:" runat="server" meta:resourcekey="Label1Resource1"
                            CssClass="black" Font-Bold="True" />
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblOwnerName" runat="server" meta:resourcekey="lblOwnerNameResource1"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="lblSpecial" Text="Specialization:" runat="server" CssClass="black" Font-Bold="True" meta:resourcekey="lblSpecialResource1" />
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblSpecialization" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="Label2" Text="Contact Name :" runat="server" meta:resourcekey="Label2Resource1"
                            CssClass="black" Font-Bold="True" />
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblContactName" runat="server" meta:resourcekey="lblContactNameResource1"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="Label3" Text="Address :" runat="server" meta:resourcekey="Label3Resource1"
                            CssClass="black" Font-Bold="True" />
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblPrimaryAddress" runat="server" meta:resourcekey="lblPrimaryAddressResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="Label4" Text="Country :" runat="server" meta:resourcekey="Label4Resource1"
                            CssClass="black" Font-Bold="True" />
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblPrimaryCountry" runat="server" meta:resourcekey="lblPrimaryCountryResource1"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="Label5" Text="State :" runat="server" meta:resourcekey="Label5Resource1"
                            CssClass="black" Font-Bold="True" />
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblPrimaryState" runat="server" meta:resourcekey="lblPrimaryStateResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="Label6" Text="City :" runat="server" meta:resourcekey="Label6Resource1"
                            CssClass="black" Font-Bold="True" />
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblPrimaryCity" runat="server" meta:resourcekey="lblPrimaryCityResource1"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="Label7" Text="Zip-Code :" runat="server" meta:resourcekey="Label7Resource1"
                            CssClass="black" Font-Bold="True" />
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblPrimaryZip" runat="server" meta:resourcekey="lblPrimaryZipResource1"></asp:Label>
                    </td>
                </tr>
            
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="Label13" Text="Currency Type :" runat="server" meta:resourcekey="Label13Resource1"
                            CssClass="black" Font-Bold="True" />
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblCurrency" runat="server" meta:resourcekey="lblCurrencyResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="Label14" Text="Extension :" runat="server" meta:resourcekey="Label14Resource1"
                            CssClass="black" Font-Bold="True" />
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblExtension" runat="server" meta:resourcekey="lblExtensionResource1"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="Label15" Text="Phone Number :" runat="server" meta:resourcekey="Label15Resource1"
                            CssClass="black" Font-Bold="True" />
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblPhoneNumber" runat="server" meta:resourcekey="lblPhoneNumberResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="Label16" Text="Fax Number :" runat="server" meta:resourcekey="Label16Resource1"
                            CssClass="black" Font-Bold="True" />
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblFaxNumber" runat="server" meta:resourcekey="lblFaxNumberResource1"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="Label17" Text="Email Address :" runat="server" meta:resourcekey="Label17Resource1"
                            CssClass="black" Font-Bold="True" />
                    </td>
                    <td valign="middle" class="style17" colspan="3">
                        <asp:Label ID="lnkEmilAddress" runat="server" meta:resourceKey="lnkEmilAddressResource1">
                        </asp:Label>
                        <asp:Button ID="btnEmilAddress" runat="server" CssClass="blue_button" OnClick="btnEmailAddress"
                            Style="width: 95px" Text="Send Message" meta:resourcekey="btnEmilAddressResource1" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label18" Text="Website :" runat="server" meta:resourcekey="Label18Resource1"
                            Font-Bold="True" />
                    </td>
                    <td colspan="3" class="table_border_left">
                        <%--<asp:Label ID="lblWebsite" runat="server" meta:resourcekey="lblWebsiteResource1"></asp:Label>--%>
                        <asp:HyperLink ID="lnkWebSite" runat="server" Target="_blank"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" meta:resourcekey="LinkButton1Resource1">
    </asp:LinkButton>
    <asp:ModalPopupExtender ID="ModalPopupExtenderSendEmail" runat="server" BackgroundCssClass="modalBackground"
        TargetControlID="LinkButton1" PopupControlID="Panel2" DropShadow="True" DynamicServicePath=""
        Enabled="True">
    </asp:ModalPopupExtender>
    <asp:Panel ID="Panel2" runat="server" meta:resourcekey="Panel2Resource1">
        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
            <ContentTemplate>
                <div style="height: 70%; width: 510px;" class="popupbox">
                    <table style="height: 100%;" width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="popupbox-lefttop-corner">
                            </td>
                            <td class="popupbox-topbg">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="97%" align="left" class="popupbox-header">
                                            <asp:Label ID="lblSendMessageheading" runat="server" Text="Send Message" meta:resourcekey="lblSendMessageheadingResource1"></asp:Label>
                                        </td>
                                        <td width="3%" align="right" valign="middle" class="popupbox-header">
                                            <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Images/cross.png" meta:resourcekey="imgCancelResource1"
                                                OnClick="imgCancel_Click" ToolTip="Close" />
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
                            <td align="left" valign="top" class="popupbox-content">
                                <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="width: 20%;">
                                        </td>
                                        <td align="left" style="width: 80%;" colspan="2">
                                            <asp:Label ID="lblError" runat="server" meta:resourcekey="lblErrorResource1" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;">
                                            <asp:Label ID="lblto" CssClass="black" runat="server" Text="To" meta:resourcekey="Label19Resource1"></asp:Label><span
                                                class="errormsg">*</span><span class="black">:</span>
                                        </td>
                                        <td style="width: 70%;" colspan="2">
                                            <asp:TextBox ID="txtTo" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                Enabled="False" Height="22px" MaxLength="50" meta:resourcekey="txtToResource1"
                                                ValidationGroup="WithoutTemplate" Width="97%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;">
                                            <asp:Label ID="lblSubject" runat="server" Text="Subject" CssClass="black" meta:resourcekey="Label23Resource1"></asp:Label>
                                            <span class="errormsg">*</span><span class="black">:</span>
                                        </td>
                                        <td style="width: 80%;" colspan="2">
                                            <asp:TextBox ID="txtSubject" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                Height="22px" Width="97%" MaxLength="100" ValidationGroup="WithoutTemplate"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="height: 20px">
                                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtSubject"
                                                Display="Dynamic" ErrorMessage="Enter Subject" Text="Enter Subject" ForeColor="Red"
                                                SetFocusOnError="True" ValidationGroup="WithoutTemplate" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;" valign="top">
                                            <asp:Label ID="lblMessage" runat="server" Text="Message" CssClass="black" meta:resourcekey="Label25Resource1"></asp:Label>
                                            <span class="errormsg">*</span><span class="black">:</span>
                                        </td>
                                        <td style="width: 80%;" colspan="2">
                                            <asp:TextBox ID="txtContent" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                Height="100px" meta:resourcekey="txtContentResource1" TextMode="MultiLine" ValidationGroup="WithoutTemplate"
                                                onkeyup="return ismaxlength(this,500)" Width="99%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left" style="height: 20px;">
                                            <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtContent"
                                                Display="Dynamic" Text="Enter Message" ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="WithoutTemplate" meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right" style="height: 20px;">
                                            <label id='lblCaption' style="font-family: Tahoma; font-size: 1em; font-weight: bold">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">
                                        </td>
                                        <td align="right" style="width: 80%;" colspan="2">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="blue_button" Style="width: 80px"
                                                Text="Send" OnClick="btnSubmit_Click1" ValidationGroup="WithoutTemplate" meta:resourcekey="btnSubmitResource1" />
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
                <%-- <div style="background-color: White; height: 100%;">
                    <div id="div3" class="chart_bgmodalpopup">
                        <div class="chart_heading">
                            <table width="99%">
                                <tr>
                                    <td style="width: 95%" align="left">
                                        <asp:Label ID="Label30" Text="Send Message:-" runat="server" class="black" meta:resourceKey="Label30Resource1" />
                                    </td>
                                    <td style="width: 5%" align="left">
                                        <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Images/cross.png" meta:resourcekey="imgCancelResource1"
                                            OnClick="imgCancel_Click" ToolTip="Close" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="padding-left: 13px">
                            <table border="0" cellpadding="0" cellspacing="0" width="99%" align="right">
                                <tr>
                                    <td align="left" class="greenmsg" colspan="2">
                                        <asp:Label ID="lblError" runat="server" meta:resourcekey="lblErrorResource1" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 15%">
                                        <asp:Label ID="Label19" runat="server" class="black" meta:resourceKey="Label19Resource1"
                                            Text="To" />
                                        <asp:Label ID="Label20" runat="server" class="errormsg" meta:resourceKey="Label20Resource1"
                                            Text="*" />
                                    </td>
                                    <td style="width: 84%">
                                        <asp:TextBox ID="txtTo" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                            Enabled="False" Height="22px" MaxLength="50" meta:resourcekey="txtToResource1"
                                            ValidationGroup="WithoutTemplate" Width="97%"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CssClass="blue" meta:resourcekey="LinkButton4Resource1"
                                                    OnClick="lnkAddTo_Click" Text="Add" Visible="False"></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3">
                                        <asp:Label ID="Label21" Text="From" runat="server" class="black" meta:resourceKey="Label21Resource1"
                                            Visible="False" />
                                        <asp:Label ID="Label22" Text="*" runat="server" class="errormsg" meta:resourceKey="Label22Resource1"
                                            Visible="False" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFrom" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                            Enabled="False" Height="22px" meta:resourcekey="txtFromResource1" ValidationGroup="WithoutTemplate"
                                            Width="180px" Visible="False"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFrom"
                                            Display="Dynamic" ErrorMessage="Please Enter Sender Address" ForeColor="Red"
                                            meta:resourcekey="RequiredFieldValidator1Resource1" SetFocusOnError="True" ValidationGroup="WithoutTemplate"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style6">
                                        <asp:Label ID="Label23" Text="Subject" runat="server" class="black" meta:resourceKey="Label23Resource1" />
                                        <span class="errormsg">*</span>
                                    </td>
                                    <td class="style7">
                                        <asp:TextBox ID="txtSubject" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                            Height="22px" Width="97%" MaxLength="100" meta:resourcekey="txtSubjectResource1"
                                            ValidationGroup="WithoutTemplate"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="refSubject" runat="server" ControlToValidate="txtSubject"
                                            Display="Dynamic" ErrorMessage="Enter Subject" ForeColor="Red" meta:resourcekey="RequiredFieldValidator2Resource1"
                                            SetFocusOnError="True" ValidationGroup="WithoutTemplate"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style8" valign="top">
                                        <asp:Label ID="Label25" Text="Message" runat="server" class="black" meta:resourceKey="Label25Resource1" />
                                        <span class="errormsg">*</span>
                                    </td>
                                    <td class="style9">
                                        <asp:TextBox ID="txtContent" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                            Height="150px" meta:resourcekey="txtContentResource1" TextMode="MultiLine" ValidationGroup="WithoutTemplate"
                                            Width="97%" onkeyup="return ismaxlength(this,500)"></asp:TextBox>
                                        <label id='lblCaption' style="font-family: Tahoma; font-size: 1em; font-weight: bold">
                                        </label>
                                        <asp:RequiredFieldValidator ID="rfvMsg" runat="server" ControlToValidate="txtContent"
                                            Height="15px" Display="Dynamic" ErrorMessage="Please Enter Message" ForeColor="Red"
                                            meta:resourcekey="RequiredFieldValidator3Resource1" SetFocusOnError="True" ValidationGroup="WithoutTemplate"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3" align="right">
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                        <div style="padding: 5px 8px 0px 0px">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="blue_button" meta:resourcekey="btnSubmitResource1"
                                                OnClick="btnSubmit_Click1" Style="width: 50px" Text="Send" ValidationGroup="WithoutTemplate" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>--%>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="imgCancel" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
    <!-- Modal-Popup for adding to -->
    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" meta:resourcekey="LinkButton3Resource1"></asp:LinkButton>
    <asp:ModalPopupExtender ID="ModalPopupExtenderAddReceipient" runat="server" BackgroundCssClass="modalBackground"
        TargetControlID="LinkButton3" PopupControlID="Panel3" DropShadow="True" DynamicServicePath=""
        Enabled="True">
    </asp:ModalPopupExtender>
    <asp:Panel ID="Panel3" runat="server" meta:resourcekey="Panel3Resource1">
        <asp:UpdatePanel runat="server" ID="UpdatePanel4">
            <ContentTemplate>
                <div style="background-color: White; height: 110px; width: 375px">
                    <div id="div4" class="chart_bgmodalpopupEmail">
                        <div class="chart_heading">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 100%">
                                        <asp:Label ID="Label29" Text="Add Recipient:-" runat="server" class="black" meta:resourceKey="Label29Resource1" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imgAddPopUp" runat="server" ImageUrl="~/Images/cross.png" meta:resourcekey="imgAddPopUpResource1"
                                            OnClick="imgAddPopUp_Click" ToolTip="Close" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <table border="0" cellpadding="5" cellspacing="0">
                            <tr>
                                <td align="left" class="style3">
                                    <asp:Label ID="Label27" Text="To" runat="server" class="black" meta:resourceKey="Label27Resource1" />
                                    <asp:Label ID="Label28" Text="*" runat="server" class="errormsg" meta:resourceKey="Label28Resource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAddTo" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                        Height="22px" MaxLength="50" meta:resourcekey="txtAddToResource1" ValidationGroup="WithoutTemplate"
                                        Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvComponent" runat="server" ControlToValidate="txtAddTo"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" meta:resourcekey="rfvComponentResource1"
                                        SetFocusOnError="True" ValidationGroup="AddTo"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="revEmailToValidate" runat="server" ControlToValidate="txtAddTo"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" meta:resourcekey="revEmailToValidateResource1"
                                        SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="AddTo"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                </td>
                                <td>
                                    <asp:Button ID="btnAddTo" runat="server" CssClass="blue_button" meta:resourcekey="btnAddToResource1"
                                        OnClick="btnAddTo_Click1" Style="width: 61px" Text="Add" ValidationGroup="AddReceipeient" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="imgAddPopUp" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
