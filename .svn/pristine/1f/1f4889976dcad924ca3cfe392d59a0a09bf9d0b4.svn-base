<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BuyerProfile.aspx.cs" Inherits="ICBrowser.Web.BuyerProfile" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
    <asp:Panel ID="pnlCompDet" runat="server" meta:resourcekey="pnlCompDetResource1"
        CssClass="blue" ScrollBars="Vertical">
        <div style="height: 540px; width: 100%">
            <table width="100%" style="height: 100%" border="0" cellspacing="0" class="table_border">
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style18">
                        <asp:Label ID="lblCName" runat="server" Text="Company Name :" CssClass="black" meta:resourcekey="lblCNameResource1"
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="2" class="style19">
                        <asp:Label ID="lblCompanyName" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                    <td width="30%" class="style20">
                        <table width="100%" cellspacing="0" cellpadding="2">
                            <tr>
                                <td align="center" style="width: 65%;">
                                    <asp:Label ID="lblAddFavoriteText" runat="server" Text="Add to favorite :" CssClass="black"
                                        Font-Bold="True" meta:resourcekey="lblAddFavoriteTextResource1"></asp:Label>
                                </td>
                                <td align="left" style="width: 35%;">
                                    <asp:ImageButton ID="imgbtnaddFav" runat="server" ImageUrl="Images/star.png" OnClick="imgbtnaddFav_Click"
                                        ToolTip="Add Favourite" Width="16px" meta:resourcekey="imgbtnaddFavResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 10%">
                                    <asp:Label ID="lblCurentRating" CssClass="black" runat="server" Font-Bold="True"
                                        meta:resourcekey="lblCurentRatingTextResource2" Text="Current Rating :"></asp:Label>
                                </td>
                                <td align="center" valign="middle" style="width: 25%;">
                                    <asp:Rating ID="ratingBuyer" runat="server" Height="20px" Visible="true" StarCssClass="ratingStar"
                                        BackColor=" #dfedf7" Width="100%" ReadOnly="true" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar">
                                    </asp:Rating>
                                </td>
                            </tr>
                            <tr>
                                <td width="35%" colspan="2" align="right">
                                    <asp:LinkButton ID="lnkRate" runat="server" Text="Give Ratings" meta:resourcekey="lnkRateResource2"
                                        OnClick="lnkRate_Click"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="lblowner" runat="server" Text="Owner Name :" CssClass="black" meta:resourcekey="lblownerResource1"
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblOwnerName" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="lblSpecial" runat="server" Text="Specialization :" CssClass="black"
                            Font-Bold="True" meta:resourcekey="lblSpecialResource1"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblSpecialization" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="lblContact" runat="server" Text="Contact Name :" CssClass="black"
                            meta:resourcekey="lblContactResource1" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblContactName" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="lblPAddress" runat="server" Text="Address :" CssClass="black"
                            meta:resourcekey="lblPAddressResource1" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblPrimaryAddress" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="lblPCountry" runat="server" Text="Country :" CssClass="black"
                            meta:resourcekey="lblPCountryResource1" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblPrimaryCountry" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="lblPState" runat="server" Text="State :" CssClass="black"
                            meta:resourcekey="lblPStateResource1" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblPrimaryState" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="lblPCity" runat="server" Text="City :" CssClass="black" meta:resourcekey="lblPCityResource1"
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblPrimaryCity" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="lblPZipCode" runat="server" Text="Zip-Code :" CssClass="black"
                            meta:resourcekey="lblPZipCodeResource1" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblPrimaryZip" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
              <%--  <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="lblSAddress" runat="server" Text="Secondary Address :" CssClass="black"
                            meta:resourcekey="lblSAddressResource1" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblSecondaryAddress" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="lblSCountry" runat="server" Text="Secondary Country :" CssClass="black"
                            meta:resourcekey="lblSCountryResource1" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblSecondaryCountry" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="lblSState" runat="server" Text="Secondary State :" CssClass="black"
                            meta:resourcekey="lblSStateResource1" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblSecondaryState" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="lblSCity" runat="server" Text="Secondary City :" CssClass="black"
                            meta:resourcekey="lblSCityResource1" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblSecondaryCity" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="lblSZipCode" runat="server" Text="Secondary Zip-Code :" CssClass="black"
                            meta:resourcekey="lblSZipCodeResource1" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblSecondaryZip" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>--%>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="lblCType" runat="server" Text="Currency Type :" CssClass="black" meta:resourcekey="lblCTypeResource1"
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblCurrency" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="lblExten" runat="server" Text="Extension :" CssClass="black" meta:resourcekey="lblExtenResource1"
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblExtension" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="lblPhn" runat="server" Text="Phone Number :" CssClass="black" meta:resourcekey="lblPhnResource1"
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblPhoneNumber" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="lblFaxNum" runat="server" Text="Fax Number :" CssClass="black" meta:resourcekey="lblFaxNumResource1"
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:Label ID="lblFaxNumber" runat="server" CssClass="Gray"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #dfedf7">
                    <td align="left" class="style5">
                        <asp:Label ID="lblEmailAdress" runat="server" Text="Email Address :" CssClass="black"
                            meta:resourcekey="lblEmailAdressResource1" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <asp:LinkButton ID="lnkEmailAddress" runat="server" CausesValidation="False" OnClick="lnkEmailAddress_Click"
                            Visible="False" CssClass="blue" meta:resourcekey="lnkEmailAddressResource1"></asp:LinkButton>
                        <asp:Button ID="btnEmilAddress" runat="server" CssClass="blue_button" Style="width: 120px"
                            Text="Send Message" OnClick="btnEmilAddress_Click" meta:resourcekey="btnEmilAddressResource1" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="lblWSite" runat="server" Text="Web Site :" CssClass="black" meta:resourcekey="lblWSiteResource1"
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="table_border_left">
                        <%--<asp:Label ID="lblWebsite" runat="server" meta:resourcekey="lblWebsiteResource1"></asp:Label>--%>
                        <asp:HyperLink ID="lnkWebSite" runat="server" Target="_blank"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
    <asp:ModalPopupExtender ID="ModalPopupExtenderSendEmail" runat="server" BackgroundCssClass="modalBackground"
        TargetControlID="LinkButton1" PopupControlID="pnlMessagePopup" DynamicServicePath=""
        Enabled="True">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlMessagePopup" runat="server" Height="325px" meta:resourcekey="pnldisplayResource1">
        <asp:UpdatePanel runat="server" ID="upnlMessagePopup">
            <ContentTemplate>
                <div style="height: 100%; width: 510px;" class="popupbox">
                    <table style="height: 100%;" width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="popupbox-lefttop-corner">
                            </td>
                            <td class="popupbox-topbg">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="97%" align="left" class="popupbox-header">
                                            <asp:Label ID="lblSendMessageheading" runat="server" Text=" Send Message" meta:resourcekey="lblSendMessageheadingResource1"></asp:Label>
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
                                <table border="0" cellpadding="5" cellspacing="0">
                                    <tr>
                                        <td style="width: 20%;">
                                        </td>
                                        <td align="left" style="width: 80%;" colspan="2">
                                            <asp:Label ID="lblError" ForeColor="Red" runat="server" meta:resourcekey="lblErrorResource1"
                                                Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;">
                                            <asp:Label ID="lblto" CssClass="text" runat="server" Text="To" meta:resourcekey="lbltoResource1"></asp:Label>
                                        </td>
                                        <td style="width: 70%;" colspan="2">
                                            <asp:TextBox ID="txtTo" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                Enabled="False" Height="22px" MaxLength="50" meta:resourcekey="txtToResource1"
                                                ValidationGroup="vgOne" Width="99%"></asp:TextBox>
                                        </td>
                                        <td style="width: 10%;">
                                            <asp:LinkButton ID="lnkAddTo" runat="server" CssClass="blue" Visible="False" meta:resourcekey="lnkAddToResource1"
                                                OnClick="lnkAddTo_Click" Text="Add"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="lblToDisable" runat="server" CssClass="black" meta:resourcekey="lblToDisableResource1"
                                                Height="22px" Text="Not Disclose" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;">
                                            <asp:Label ID="lblSubject" runat="server" Text="Subject" CssClass="text" meta:resourcekey="lblSubjectResource1"></asp:Label>
                                            <span class="errormsg">*</span><span> :</span>
                                        </td>
                                        <td style="width: 80%;" colspan="2">
                                            <asp:TextBox ID="txtSubject" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                Height="22px" meta:resourcekey="txtSubjectResource1" ValidationGroup="vgOne"
                                                Width="99%" MaxLength="100"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="height: 20px" colspan="2">
                                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtSubject"
                                                Display="Dynamic" ErrorMessage="Enter Subject" Text="Enter Subject" ForeColor="Red"
                                                SetFocusOnError="True" ValidationGroup="vgOne" meta:resourcekey="rfvDescriptionResource1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;" valign="top">
                                            <asp:Label ID="lblMessage" runat="server" Text="Message" CssClass="text" meta:resourcekey="lblMessageResource1"></asp:Label>
                                            <span class="errormsg">*</span><span> :</span>
                                        </td>
                                        <td style="width: 80%;" colspan="2">
                                            <asp:TextBox ID="txtContent" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                Height="100px" meta:resourcekey="txtContentResource1" TextMode="MultiLine" ValidationGroup="vgOne"
                                                onkeyup="return ismaxlength(this,500)" Width="99%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left" style="height: 20px;">
                                            <asp:RequiredFieldValidator ID="rfvBrandName" runat="server" ControlToValidate="txtContent"
                                                Display="Dynamic" ErrorMessage="Enter Message" Text="Enter Message" ForeColor="Red"
                                                SetFocusOnError="True" ValidationGroup="vgOne" meta:resourcekey="rfvBrandNameResource1"></asp:RequiredFieldValidator>
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
                                                Text="Send" OnClick="btnSubmit_Click1" ValidationGroup="vgOne" meta:resourcekey="btnSubmitResource1" />
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
                <asp:PostBackTrigger ControlID="btnSubmit" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
    <!-- Modal-Popup for adding to -->
    <%--<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" meta:resourcekey="LinkButton3Resource1"></asp:LinkButton>
    <asp:ModalPopupExtender ID="ModalPopupExtenderAddReceipient" runat="server" BackgroundCssClass="modalBackground"
        TargetControlID="LinkButton3" PopupControlID="pnlAddTo" DropShadow="True" DynamicServicePath=""
        Enabled="True">
    </asp:ModalPopupExtender>--%>
    <%--<asp:Panel ID="pnlAddTo" runat="server" meta:resourcekey="pnlAddToResource1">
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                <div style="background-color: White; height: 110px; width: 375px">
                    <div id="div2" class="chart_bgmodalpopupEmail">
                        <div class="chart_heading">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 90%; font-size: medium; color: Black" class="bold">
                                        <asp:Label ID="lblAddRecipent" runat="server" Text="  Add Recipient" CssClass="header"
                                            meta:resourcekey="lblAddRecipentResource1"></asp:Label>
                                    </td>
                                    <td width="10%" align="center">
                                        <asp:ImageButton ID="imgAddPopUp" runat="server" ImageUrl="~/Images/cross.png" meta:resourcekey="imgAddPopUpResource1"
                                            OnClick="imgAddPopUp_Click" ToolTip="Close" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <table border="0" cellpadding="5" cellspacing="0">
                            <tr>
                                <td align="right" class="style3">
                                    <asp:Label ID="lblrecipentto" runat="server" Text="To" meta:resourcekey="lblrecipenttoResource1"></asp:Label>
                                    <span class="errormsg">*</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAddTo" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                        Height="22px" MaxLength="50" meta:resourcekey="txtAddToResource1" ValidationGroup="AddTo"
                                        Width="250px"></asp:TextBox>
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
                                        OnClick="btnAddTo_Click1" Style="width: 61px" Text="Add" ValidationGroup="AddTo" />
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
    </asp:Panel>--%>
</asp:Content>
