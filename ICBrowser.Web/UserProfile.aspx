<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserProfile.aspx.cs" Inherits="ICBrowser.Web.UserProfile" Culture="auto"
 UICulture="auto" meta:resourcekey="PageResource2" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/ToggleComments.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 153px;
        }
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
    <script type="text/javascript" language="javascript">
        function confirmDelete(source, args) {
            if (confirm('Are you sure you want to delete ?')) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
            return;
        }
    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $("#scroller").simplyScroll({ orientation: 'vertical', direction: 'backwards', customClass: 'vert' });
            $('#div2').show();
            $('#div1').hide();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="scptmgr" runat="server">
    </asp:ScriptManager>
    <div style="width: 100%" id="divcomment" runat="server">
        <table width="100%">
            <tr>
                <td>
                    <div id="divcomment1" runat="server" visible="false" style="width: 100%">
                        <table width="100%">
                            <tr>
                                <td>
                                    <a id="aTag" class="mine-button" style="padding-left: 0px; font-size: small; color: #2C79BE;
                                        font-weight: bold;" href="javascript:togglecomments();">View Comments</a>
                                    <div id="div1" style="width: 100%">
                                        <div style="width: 100%">
                                            <table style="width: 100%;" border="0" cellspacing="0" class="table_border">
                                                <tr>
                                                    <td>
                                                        <div>
                                                            <asp:Repeater ID="RepDetailed" runat="server" OnItemDataBound="RepDetailed_ItemDataBound"
                                                                OnItemCommand="RepDetailed_ItemCommand">
                                                                <HeaderTemplate>
                                                                    <table border="1" width="100%">
                                                                        <tr style="background-color: #dfedf7">
                                                                            <td width="40%">
                                                                                <asp:Label ID="lblComment" runat="server" Text="Comments" Style="color: #000000;
                                                                                    font-weight: bold;" meta:resourcekey="lblCommentResource2"></asp:Label>
                                                                            </td>
                                                                            <td width="30%">
                                                                                <asp:Label ID="lblIssuedBy" runat="server" Text="Issued By" Style="color: #000000;
                                                                                    font-weight: bold;" meta:resourcekey="lblIssuedByResource2" ></asp:Label>
                                                                            </td>
                                                                            <td width="20%">
                                                                                <asp:Label ID="lblDelete" runat="server" Text="Delete" 
                                                                                    Style="color: #000000; font-weight: bold;" meta:resourcekey="lblDeleteResource2"
                                                                                    ></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="40%">
                                                                                <asp:LinkButton ID="lnkDetails" runat="server" CommandArgument='<%# Eval("FromUserId") %>'
                                                                                    Style="color: #000000;" Text='<%# DataBinder.Eval(Container.DataItem, "ShortComment") %>'
                                                                                    CommandName="MyUpdate" ToolTip="Delete" 
                                                                                    meta:resourcekey="lnkDetailsResource2" ></asp:LinkButton>
                                                                            </td>
                                                                            <td width="30%">
                                                                                <asp:Label ID="lblCompanyName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CompanyName") %>'
                                                                                    Style="color: #000000;" meta:resourcekey="lblCompanyNameResource3"></asp:Label>
                                                                            </td>
                                                                            <td width="20%">
                                                                                <asp:ImageButton ID="btnDelete" runat="server" Text="Delete" ValidationGroup="deleteConfirmation"
                                                                                    CommandArgument='<%# Eval("FromUserId") %>' ImageUrl="~/Images/deletet_btn.png"
                                                                                    OnCommand="btnDelete_Command" CommandName="MyDelete" 
                                                                                    meta:resourcekey="btnDeleteResource2" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            <asp:CustomValidator ID="CustomValidator1" ClientValidationFunction="confirmDelete"
                                                                ValidationGroup="deleteConfirmation" runat="server" 
                                                                meta:resourcekey="CustomValidator1Resource2" ></asp:CustomValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <a id="a1" class="mine-button" runat="server" style="padding-left: 0px; font-size: small;
                        color: #2C79BE; font-weight: bold;" href="javascript:togglecomments();">View Profile</a>
                    <div id="div2">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblSentMessage" runat="server" Visible="False" 
                                        CssClass="greenmsg" meta:resourcekey="lblSentMessageResource2"
                                        ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNotSentMessage" runat="server" Visible="False" 
                                        CssClass="redmsg" meta:resourcekey="lblNotSentMessageResource2"
                                        ></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:LinkButton ID="hyplnkBack" runat="server" Text="Back" Font-Bold="True" 
                                        Font-Underline="False" onclick="hyplnkBack_Click" 
                                        meta:resourcekey="hyplnkBackResource1"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="Panel1" runat="server" meta:resourcekey="Panel1Resource2" >
                            <div style="height: 540px; width: 100%">
                                <table width="100%" style="height: 100%" border="0" cellspacing="0" class="table_border">
                                    <tr style="background-color: #dfedf7">
                                        <td align="left" class="style1" valign="bottom">
                                            <asp:Label ID="lblCompnyName" Text="Company Name:" runat="server" CssClass="black"
                                                Font-Bold="True" Font-Size="Small" 
                                                meta:resourceKey="lblCompnyNameResource2"  />
                                        </td>
                                        <td align="left" colspan="2" class="style19" valign="bottom">
                                            <asp:Label ID="lblCompanyName" runat="server" 
                                                meta:resourceKey="lblCompanyNameResource4" ></asp:Label>
                                        </td>
                                        <td width="33%">
                                            <table width="100%" cellspacing="0" cellpadding="2">
                                                <tr>
                                                    <td align="right" width="60%">
                                                        <asp:Label ID="lblAddFavoriteText" runat="server" Text="Add to favorite :" CssClass="black"
                                                            Font-Bold="True" Visible="False" 
                                                            meta:resourceKey="lblAddFavoriteTextResource2" ></asp:Label>
                                                    </td>
                                                    <td align="left" width="40%">
                                                        <asp:ImageButton ID="imgbtnaddFav" runat="server" ImageUrl="Images/star.png" ToolTip="Add Favourite"
                                                            OnClick="imgbtnaddFav_Click" Visible="False" 
                                                            meta:resourceKey="imgbtnaddFavResource2"  />
                                                    </td>
                                                </tr>
                                                <tr id="trCurrntrate" runat="server" visible="False">
                                                    <td id="Td1" align="right" runat="server">
                                                        <asp:Label ID="lblCurentRating" CssClass="black" runat="server" Font-Bold="True"
                                                            Text="Current Rating :"></asp:Label>
                                                    </td>
                                                    <td id="Td2" align="center" valign="middle" runat="server">
                                                        <asp:Rating ID="ratingSeller" runat="server" Height="20px" StarCssClass="ratingStar"
                                                            BackColor="#DFEDF7" Width="100%" ReadOnly="True" WaitingStarCssClass="savedRatingStar"
                                                            FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" BehaviorID="ratingSeller_RatingExtender"
                                                            CurrentRating="0">
                                                        </asp:Rating>
                                                    </td>
                                                </tr>
                                                <tr id="trRatingAsBuyer" runat="server" visible="False">
                                                    <td id="Td3" runat="server" align="right" valign="middle">
                                                        <asp:Label ID="lblRatingAsBuyer" CssClass="black" runat="server" Font-Bold="True"
                                                            Text="Current Rating as Buyer :"></asp:Label>
                                                    </td>
                                                    <td id="Td4" runat="server" valign="middle">
                                                        <asp:Rating ID="ratingAsBuyer" runat="server" Height="20px" StarCssClass="ratingStar"
                                                            BackColor="#DFEDF7" Width="100%" ReadOnly="True" WaitingStarCssClass="savedRatingStar"
                                                            FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" BehaviorID="ratingAsBuyer_RatingExtender"
                                                            CurrentRating="0">
                                                        </asp:Rating>
                                                    </td>
                                                </tr>
                                                <tr id="trRatingAsSeller" runat="server" visible="False">
                                                    <td id="Td5" runat="server" align="right" valign="middle">
                                                        <asp:Label ID="lblRatingAsSeller" CssClass="black" runat="server" Font-Bold="True"
                                                            Text="Current Rating as Seller :"></asp:Label>
                                                    </td>
                                                    <td id="Td6" runat="server">
                                                        <asp:Rating ID="ratingAsSeller" runat="server" Height="20px" StarCssClass="ratingStar"
                                                            BackColor="#DFEDF7" Width="100%" ReadOnly="True" WaitingStarCssClass="savedRatingStar"
                                                            FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" BehaviorID="ratingAsSeller_RatingExtender"
                                                            CurrentRating="0">
                                                        </asp:Rating>
                                                    </td>
                                                </tr>
                                                <tr id="trratelink" runat="server">
                                                    <td id="Td7" colspan="2" align="right" runat="server">
                                                        <asp:LinkButton ID="lnkRate" runat="server" Text="Post Your Ratings" OnClick="lnkRate_Click"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style1">
                                            <asp:Label ID="Label1" Text="Owner Name:" runat="server" CssClass="black" Font-Bold="True"
                                                Font-Size="Small" meta:resourceKey="Label1Resource2" />
                                        </td>
                                        <td align="left" colspan="3" class="table_border_left">
                                            <asp:Label ID="lblOwnerName" runat="server" 
                                                meta:resourceKey="lblOwnerNameResource2" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #dfedf7">
                                        <td align="left" class="style1">
                                            <asp:Label ID="lblSpecial" Text="Specialization:" runat="server" CssClass="black"
                                                Font-Bold="True" Font-Size="Small" 
                                                meta:resourceKey="lblSpecialResource2"  />
                                        </td>
                                        <td align="left" colspan="3" class="table_border_left">
                                            <asp:Label ID="lblSpecialization" runat="server" 
                                                meta:resourceKey="lblSpecializationResource2" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style1">
                                            <asp:Label ID="Label2" Text="Contact Name :" runat="server" CssClass="black" Font-Bold="True"
                                                Font-Size="Small" meta:resourceKey="Label2Resource2"  />
                                        </td>
                                        <td align="left" colspan="3" class="table_border_left">
                                            <asp:Label ID="lblContactName" runat="server" 
                                                meta:resourceKey="lblContactNameResource2" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #dfedf7">
                                        <td align="left" class="style1">
                                            <asp:Label ID="Label3" Text="Address :" runat="server" CssClass="black" Font-Bold="True"
                                                Font-Size="Small" meta:resourceKey="Label3Resource2"  />
                                        </td>
                                        <td align="left" colspan="3" class="table_border_left">
                                            <asp:Label ID="lblPrimaryAddress" runat="server" 
                                                meta:resourceKey="lblPrimaryAddressResource2" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style1">
                                            <asp:Label ID="Label4" Text="Country :" runat="server" CssClass="black" Font-Bold="True"
                                                Font-Size="Small" meta:resourceKey="Label4Resource2"/>
                                        </td>
                                        <td align="left" colspan="3" class="table_border_left">
                                            <asp:Label ID="lblPrimaryCountry" runat="server" 
                                                meta:resourceKey="lblPrimaryCountryResource2" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #dfedf7">
                                        <td align="left" class="style1">
                                            <asp:Label ID="Label5" Text="State :" runat="server" CssClass="black" Font-Bold="True"
                                                Font-Size="Small" meta:resourceKey="Label5Resource2"  />
                                        </td>
                                        <td align="left" colspan="3" class="table_border_left">
                                            <asp:Label ID="lblPrimaryState" runat="server" 
                                                meta:resourceKey="lblPrimaryStateResource2" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style1">
                                            <asp:Label ID="Label6" Text="City :" runat="server" CssClass="black" Font-Bold="True"
                                                Font-Size="Small" meta:resourceKey="Label6Resource2" />
                                        </td>
                                        <td align="left" colspan="3" class="table_border_left">
                                            <asp:Label ID="lblPrimaryCity" runat="server" 
                                                meta:resourceKey="lblPrimaryCityResource2" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #dfedf7">
                                        <td align="left" class="style1">
                                            <asp:Label ID="Label7" Text="Zip-Code :" runat="server" CssClass="black" Font-Bold="True"
                                                Font-Size="Small" meta:resourceKey="Label7Resource2" />
                                        </td>
                                        <td align="left" colspan="3" class="table_border_left">
                                            <asp:Label ID="lblPrimaryZip" runat="server" 
                                                meta:resourceKey="lblPrimaryZipResource2" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="style1">
                                        <td align="left" class="style1">
                                            <asp:Label ID="Label13" Text="Currency Type :" runat="server" CssClass="black" Font-Bold="True"
                                                Font-Size="Small" meta:resourceKey="Label13Resource2"  />
                                        </td>
                                        <td align="left" colspan="3" class="table_border_left">
                                            <asp:Label ID="lblCurrency" runat="server" 
                                                meta:resourceKey="lblCurrencyResource2" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #dfedf7">
                                        <td style="background-color: #dfedf7">
                                            <asp:Label ID="Label14" Text="Extension :" runat="server" CssClass="black" Font-Bold="True"
                                                Font-Size="Small" meta:resourceKey="Label14Resource2"  />
                                        </td>
                                        <td align="left" colspan="3" class="table_border_left">
                                            <asp:Label ID="lblExtension" runat="server" 
                                                meta:resourceKey="lblExtensionResource2" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr align="left" class="style1">
                                        <td align="left" class="style1">
                                            <asp:Label ID="Label15" Text="Phone Number :" runat="server" CssClass="black" Font-Bold="True"
                                                Font-Size="Small" meta:resourceKey="Label15Resource2"  />
                                        </td>
                                        <td align="left" colspan="3" class="table_border_left">
                                            <asp:Label ID="lblPhoneNumber" runat="server" 
                                                meta:resourceKey="lblPhoneNumberResource2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #dfedf7">
                                        <td style="background-color: #dfedf7">
                                            <asp:Label ID="Label16" Text="Fax Number :" runat="server" CssClass="black" Font-Bold="True"
                                                Font-Size="Small" meta:resourceKey="Label16Resource2"  />
                                        </td>
                                        <td align="left" colspan="3" class="table_border_left">
                                            <asp:Label ID="lblFaxNumber" runat="server" 
                                                meta:resourceKey="lblFaxNumberResource2" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr align="left" class="style1">
                                        <td align="left" class="style1">
                                            <asp:Label ID="Label17" Text="Email Address :" runat="server" CssClass="black" Font-Bold="True"
                                                Font-Size="Small" meta:resourceKey="Label17Resource2"  />
                                        </td>
                                        <td valign="middle" class="table_border_left" colspan="3">
                                            <asp:LinkButton ID="lnkEmilAddress" runat="server" 
                                                OnClick="lnkEmilAddress_Click" meta:resourceKey="lnkEmilAddressResource2"
                                                ></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #dfedf7">
                                        <td style="background-color: #dfedf7">
                                            <asp:Label ID="Label18" Text="Website :" runat="server" CssClass="black" Font-Bold="True"
                                                Font-Size="Small" meta:resourceKey="Label18Resource2" />
                                        </td>
                                        <td colspan="3" class="table_border_left">
                                            <asp:HyperLink ID="lnkWebSite" runat="server" Target="_blank" 
                                                meta:resourceKey="lnkWebSiteResource2" ></asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:ModalPopupExtender ID="ModalPopupExtenderSendEmail" runat="server" BackgroundCssClass="modalBackground"
        TargetControlID="LinkButton1" PopupControlID="pnlMessagePopup" DynamicServicePath=""
        Enabled="True">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlMessagePopup" runat="server" Height="325px" 
        meta:resourcekey="pnlMessagePopupResource2" >
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
                                            <asp:Label ID="lblSendMessageheading" runat="server" Text=" Send Message" 
                                                meta:resourceKey="lblSendMessageheadingResource2" ></asp:Label>
                                        </td>
                                        <td width="3%" align="right" valign="middle" class="popupbox-header">
                                            <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Images/cross.png" OnClick="imgCancel_Click"
                                                ToolTip="Close" meta:resourceKey="imgCancelResource2" />
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
                                            <asp:Label ID="lblError" ForeColor="Red" runat="server" Visible="False" 
                                                meta:resourceKey="lblErrorResource2" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;">
                                            <asp:Label ID="lblto" CssClass="text" runat="server" Text="To" 
                                                meta:resourceKey="lbltoResource2" ></asp:Label>
                                        </td>
                                        <td style="width: 70%;" colspan="2">
                                            <asp:TextBox ID="txtTo" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                Enabled="False" Height="22px" MaxLength="50" ValidationGroup="vgOne" 
                                                Width="99%" meta:resourceKey="txtToResource2"
                                               ></asp:TextBox>
                                        </td>
                                        <td style="width: 10%;">
                                            <asp:LinkButton ID="lnkAddTo" runat="server" CssClass="blue" Visible="False" 
                                                Text="Add" meta:resourceKey="lnkAddToResource2"
                                               ></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="lblToDisable" runat="server" CssClass="black" Height="22px" Text="Not Disclose"
                                                Visible="False" meta:resourceKey="lblToDisableResource2" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;">
                                            <asp:Label ID="lblSubject" runat="server" Text="Subject" CssClass="text" 
                                                meta:resourceKey="lblSubjectResource2" ></asp:Label>
                                            <span class="errormsg">*</span><span> :</span>
                                        </td>
                                        <td style="width: 80%;" colspan="2">
                                            <asp:TextBox ID="txtSubject" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                Height="22px" ValidationGroup="vgOne" Width="99%" MaxLength="100" 
                                                meta:resourceKey="txtSubjectResource2" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="height: 20px" colspan="2">
                                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtSubject"
                                                Display="Dynamic" ErrorMessage="Enter Subject" Text="Enter Subject" ForeColor="Red"
                                                SetFocusOnError="True" ValidationGroup="vgOne" 
                                                meta:resourceKey="rfvDescriptionResource2"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;" valign="top">
                                            <asp:Label ID="lblMessage" runat="server" Text="Message" CssClass="text" 
                                                meta:resourceKey="lblMessageResource2" ></asp:Label>
                                            <span class="errormsg">*</span><span> :</span>
                                        </td>
                                        <td style="width: 80%;" colspan="2">
                                            <asp:TextBox ID="txtContent" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                Height="100px" TextMode="MultiLine" ValidationGroup="vgOne" onkeyup="return ismaxlength(this,500)"
                                                Width="99%" meta:resourceKey="txtContentResource2"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left" style="height: 20px;">
                                            <asp:RequiredFieldValidator ID="rfvBrandName" runat="server" ControlToValidate="txtContent"
                                                Display="Dynamic" ErrorMessage="Enter Message" Text="Enter Message" ForeColor="Red"
                                                SetFocusOnError="True" ValidationGroup="vgOne" 
                                                meta:resourceKey="rfvBrandNameResource2" ></asp:RequiredFieldValidator>
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
                                                Text="Send" ValidationGroup="vgOne" OnClick="btnSubmit_Click" 
                                                meta:resourceKey="btnSubmitResource2" />
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
    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
        meta:resourcekey="LinkButton1Resource2" ></asp:LinkButton>
    <asp:ModalPopupExtender ID="ModalPopupExtenderComments" runat="server" BackgroundCssClass="modalBackground"
        TargetControlID="LinkButton1" PopupControlID="PnlCommentDisplay" DynamicServicePath=""
        Enabled="True">
    </asp:ModalPopupExtender>
    <asp:Panel ID="PnlCommentDisplay" runat="server" Height="325px" 
        meta:resourcekey="PnlCommentDisplayResource2" >
        <div style="height: 100%; width: 510px;" class="popupbox">
            <table style="height: 100%;" width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="popupbox-lefttop-corner">
                    </td>
                    <td class="popupbox-topbg">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="97%" align="left" class="popupbox-header">
                                    <asp:Label ID="lblcommentsdet" runat="server" Text=" Comment Details" 
                                        meta:resourceKey="lblcommentsdetResource2" ></asp:Label>
                                </td>
                                <td width="3%" align="right" valign="middle" class="popupbox-header">
                                    <asp:ImageButton ID="imgCancel2" runat="server" ImageUrl="~/Images/cross.png" OnClick="imgCancel2_Click"
                                        ToolTip="Close" meta:resourceKey="imgCancel2Resource2"/>
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
                                    <asp:Label ID="lblComments" runat="server" 
                                        meta:resourceKey="lblCommentsResource2" ></asp:Label>
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
    </asp:Panel>
</asp:Content>
