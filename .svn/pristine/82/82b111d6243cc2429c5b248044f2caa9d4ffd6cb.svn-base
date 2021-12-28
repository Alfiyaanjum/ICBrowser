<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SellerSubscription.aspx.cs" Inherits="ICBrowser.Web.SellerSubscription"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblSucess" runat="server" Visible="False" CssClass="greenmsg"></asp:Label>
    <asp:Label ID="lblError" runat="server" Visible="False" CssClass="redmsg"></asp:Label>
    <div id="content" style="width: 100%">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="left">
                    <div>
                        <div style="background-color: #dfedf7">
                            <table width="100%">
                                <tr>
                                    <td class="headerback">
                                        <asp:Label ID="lblWelcome" runat="server" Text="Welcome to ICBrowser." CssClass="header"
                                            meta:resourcekey="lblWelcomeResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblChooseMembership" runat="server" Text="You've registered successfully. Please choose a Membership Package :"
                                            Font-Size="Small" ForeColor="Black" meta:resourcekey="lblChooseMembershipResource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="background-color: #dfedf7">
                            <div class="traildiv">
                                <table cellspacing="5" width="100%">
                                    <tr>
                                        <td style="background-image: url('Images/membership_bg_trial.png'); background-repeat: no-repeat;
                                            margin-left: 10%" class="membership_tabs">
                                            <table width="100%" style="height: 100%; width: 100%;">
                                                <tr valign="middle">
                                                    <td align="left" style="height: 22%; padding-left: 60px">
                                                        <asp:Label ID="lblTrial" runat="server" Text="Trial" Font-Size="Medium" meta:resourcekey="lblTrialResource1"
                                                            Font-Bold="true"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr valign="middle" style="height: 20%; width: 100%;">
                                                    <td style="padding-left: 15px">
                                                        <asp:Label ID="lblTrialNoOfListings" runat="server" Font-Size="Small" meta:resourcekey="lblTrialNoOfListingsResource1"></asp:Label>
                                                        <asp:Label ID="lblTrialListings" runat="server" Text="Line Items" Font-Size="Small"
                                                            meta:resourcekey="lblTrialListingsResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr valign="middle" style="height: 20%; width: 100%;">
                                                    <td style="padding-left: 15px">
                                                        <asp:Label ID="lblTrialNoofofferlimit" runat="server" Font-Size="Small" meta:resourcekey="lblTrialNoofofferlimitResource1"></asp:Label>
                                                        <asp:Label ID="lbTrilfofferlimit" runat="server" Text="Offer Limit" Font-Size="Small"
                                                            meta:resourcekey="lblTrialNoofofferlimitResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr valign="middle" style="height: 25%; width: 100%;">
                                                    <td style="padding-left: 15px">
                                                        <asp:Label ID="lblTrialNoOfMonths" runat="server" Font-Size="Small" meta:resourcekey="lblTrialNoOfMonthsResource1"></asp:Label>
                                                        <asp:Label ID="lblTrialValidity" runat="server" Text="Days Validity" Font-Size="Small"
                                                            meta:resourcekey="lblTrialValidityResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <%--<tr valign="middle" style="height: 19.5%; width: 100%;">
                                                                            <td>
                                                                                <asp:Label ID="lblTrialMessaging" runat="server" Text="3. No Messaging" Font-Size="Small"></asp:Label>
                                                                                <asp:Label ID="Label1" runat="server" Text="3. No Messaging" Font-Size="Small"></asp:Label>
                                                                            </td>
                                                                        </tr>--%>
                                                <tr valign="middle" style="height: 25%; width: 100%;">
                                                    <td style="padding-left: 15px">
                                                        <asp:Label ID="lblTrialPrice" runat="server" Font-Size="Small" Text="Free of Cost"
                                                            meta:resourcekey="lblTrialPriceResource1"></asp:Label>
                                                        <%--<asp:Label ID="Label1" runat="server" Text="4. Free of Cost" Font-Size="Small"></asp:Label>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding-left: 12%">
                                            <asp:Button ID="btnCancel" runat="server" Text="Continue with Trial" OnClick="btnCancel_Click"
                                                CssClass="blue_button" meta:resourcekey="btnCancelResource1" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="goldplatinumsilverdiv">
                                <table cellspacing="5" align="center" width="100%">
                                    <tr>
                                        <div id="dvsilver" runat="server">
                                            <td style="background-image: url('Images/membership_bg_silver.png'); background-repeat: no-repeat"
                                                class="membership_tabs">
                                                <table width="100%" style="height: 100%; width: 100%;">
                                                    <tr valign="middle">
                                                        <td align="right" style="height: 22%; padding-left: 10px">
                                                            <asp:RadioButton ID="rbtnSilver" runat="server" GroupName="rbtngrpMembership" TextAlign="Right"
                                                                Font-Bold="True" Font-Size="Small" OnCheckedChanged="rbtnSilver_CheckedChanged"
                                                                Enabled="false" />
                                                        </td>
                                                        <td align="left" style="height: 22%; padding-right: 70px">
                                                            <asp:Label ID="lblSilver" runat="server" Text="Silver" Font-Size="Medium" meta:resourcekey="lblSilverResource1"
                                                                Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr valign="middle" style="height: 20%; width: 100%;">
                                                        <td style="padding-left: 15px" colspan="2">
                                                            <asp:Label ID="lblSilverNoOfListings" runat="server" Font-Size="Small" meta:resourcekey="lblSilverNoOfListingsResource1"></asp:Label>
                                                            <asp:Label ID="lblSilverListings" runat="server" Text="Line Items" Font-Size="Small"
                                                                meta:resourcekey="lblSilverListingsResource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr valign="middle" style="height: 20%; width: 100%;">
                                                        <td style="padding-left: 15px" colspan="2">
                                                            <asp:Label ID="lblSilverNoofOfferlimit" runat="server" Font-Size="Small" meta:resourcekey="lblSilverNoofOfferlimitResource1"></asp:Label>
                                                            <asp:Label ID="lblSilverOfferlimit" runat="server" Text="Offer Limit" Font-Size="Small"
                                                                meta:resourcekey="lblSilverNoofOfferlimitResource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr valign="middle" style="height: 25%; width: 100%;">
                                                        <td style="padding-left: 15px" colspan="2">
                                                            <asp:Label ID="lblSilverNoOfMonths" runat="server" Font-Size="Small" meta:resourcekey="lblSilverNoOfMonthsResource1"></asp:Label>
                                                            <asp:Label ID="lblSilverValidity" runat="server" Text="Days Validity" Font-Size="Small"
                                                                meta:resourcekey="lblSilverValidityResource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <%--<tr valign="middle" style="height: 19.5%; width: 100%;">
                                                                            <td>
                                                                                <asp:Label ID="lblTrialMessaging" runat="server" Text="3. No Messaging" Font-Size="Small"></asp:Label>
                                                                                <asp:Label ID="Label1" runat="server" Text="3. No Messaging" Font-Size="Small"></asp:Label>
                                                                            </td>
                                                                        </tr>--%>
                                                    <tr valign="middle" style="height: 25%; width: 100%;">
                                                        <td style="padding-left: 15px" colspan="2">
                                                            <asp:Label ID="lblSilverUSD" runat="server" Text="INR" Font-Size="Small" meta:resourcekey="lblSilverUSDResource1"></asp:Label>
                                                            <asp:Label ID="lblSilverPrice" runat="server" Font-Size="Small" meta:resourcekey="lblSilverPriceResource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </div>
                                        <div id="dvGold" runat="server">
                                            <td style="background-image: url('Images/membership_bg_gold.png'); background-repeat: no-repeat"
                                                class="membership_tabs">
                                                <table width="100%" style="height: 100%; width: 100%;">
                                                    <tr valign="middle">
                                                        <td align="right" style="height: 22%; padding-left: 10px">
                                                            <asp:RadioButton ID="rbtnGold" runat="server" GroupName="rbtngrpMembership" TextAlign="Right"
                                                                Font-Bold="True" Font-Size="Small" OnCheckedChanged="rbtnGold_CheckedChanged"
                                                                Enabled="false" />
                                                        </td>
                                                        <td align="left" style="height: 22%; padding-right: 60px; padding-top: 8px">
                                                            <asp:Label ID="lblGold" runat="server" Text="Gold" Font-Size="Medium" meta:resourcekey="lblGoldResource1"
                                                                Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr valign="middle" style="height: 20%; width: 100%;">
                                                        <td style="padding-left: 15px" colspan="2">
                                                            <asp:Label ID="lblGoldNoOfListings" runat="server" Font-Size="Small" meta:resourcekey="lblGoldNoOfListingsResource1"></asp:Label>
                                                            <asp:Label ID="lblGoldListings" runat="server" Text="Line Items" Font-Size="Small"
                                                                meta:resourcekey="lblGoldListingsResource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr valign="middle" style="height: 20%; width: 100%;">
                                                        <td style="padding-left: 15px" colspan="2">
                                                            <asp:Label ID="lblGoldNoofOfferLimit" runat="server" Font-Size="Small" meta:resourcekey="lblGoldNoofOfferLimitResource1"></asp:Label>
                                                            <asp:Label ID="lblGoldOfferLimit" runat="server" Text="Offer Limit" Font-Size="Small"
                                                                meta:resourcekey="lblGoldNoofOfferLimitResource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr valign="middle" style="height: 25%; width: 100%;">
                                                        <td style="padding-left: 15px" colspan="2">
                                                            <asp:Label ID="lblGoldNoOfMonths" runat="server" Font-Size="Small" meta:resourcekey="lblGoldNoOfMonthsResource1"></asp:Label>
                                                            <asp:Label ID="lblGoldValidity" runat="server" Text="Days Validity" Font-Size="Small"
                                                                meta:resourcekey="lblGoldValidityResource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <%--<tr valign="middle" style="height: 19.5%; width: 100%;">
                                                                            <td>
                                                                                <asp:Label ID="lblTrialMessaging" runat="server" Text="3. No Messaging" Font-Size="Small"></asp:Label>
                                                                                <asp:Label ID="Label1" runat="server" Text="3. No Messaging" Font-Size="Small"></asp:Label>
                                                                            </td>
                                                                        </tr>--%>
                                                    <tr valign="middle" style="height: 25%; width: 100%;">
                                                        <td style="padding-left: 15px" colspan="2">
                                                            <asp:Label ID="lblGoldUSD" runat="server" Text="INR" Font-Size="Small" meta:resourcekey="lblGoldUSDResource1"></asp:Label>
                                                            <asp:Label ID="lblGoldPrice" runat="server" Font-Size="Small" meta:resourcekey="lblGoldPriceResource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </div>
                                        <td style="background-image: url('Images/membership_bg_platinum.png'); background-repeat: no-repeat"
                                            class="membership_tabs">
                                            <table width="100%" style="height: 100%; width: 100%;">
                                                <tr valign="middle">
                                                    <td align="right" style="height: 22%; width: 5%">
                                                        <asp:RadioButton ID="rbtnPlatinum" runat="server" Font-Bold="True" TextAlign="Right"
                                                            GroupName="rbtngrpMembership" Font-Size="Small" OnCheckedChanged="rbtnPlatinum_CheckedChanged"  Checked="true"/>
                                                    </td>
                                                    <td align="left" style="height: 22%; padding-right: 120px">
                                                        <asp:Label ID="lblPlatinum" runat="server" Text="Platinum" Font-Size="Medium" meta:resourcekey="lblPlatinumResource1"
                                                            Font-Bold="true"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr valign="middle" style="height: 20%; width: 100%;">
                                                    <td style="padding-left: 15px" colspan="2">
                                                        <asp:Label ID="lblPlatinumNoOfListings" runat="server" Font-Size="Small" meta:resourcekey="lblPlatinumNoOfListingsResource1"></asp:Label>
                                                        <asp:Label ID="lblPlatinumListings" runat="server" Text="Line Items" Font-Size="Small"
                                                            meta:resourcekey="lblPlatinumListingsResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr valign="middle" style="height: 20%; width: 100%;">
                                                    <td style="padding-left: 15px" colspan="2">
                                                        <asp:Label ID="lblPlatinumNoOfferLimit" runat="server" Font-Size="Small" meta:resourcekey="lblPlatinumNoofOfferLimitResource1"></asp:Label>
                                                        <asp:Label ID="lblPlatinumOfferLimit" runat="server" Text="Offer Limit" Font-Size="Small"
                                                            meta:resourcekey="lblPlatinumNoofOfferLimitResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr valign="middle" style="height: 25%; width: 100%;">
                                                    <td style="padding-left: 15px" colspan="2">
                                                        <asp:Label ID="lblPlatinumNoOfMonths" runat="server" Font-Size="Small" meta:resourcekey="lblPlatinumNoOfMonthsResource1"></asp:Label>
                                                        <asp:Label ID="lblPlatinumValidity" runat="server" Text="Days Validity" Font-Size="Small"
                                                            meta:resourcekey="lblPlatinumValidityResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <%--<tr valign="middle" style="height: 19.5%; width: 100%;">
                                                                            <td>
                                                                                <asp:Label ID="lblTrialMessaging" runat="server" Text="3. No Messaging" Font-Size="Small"></asp:Label>
                                                                                <asp:Label ID="Label1" runat="server" Text="3. No Messaging" Font-Size="Small"></asp:Label>
                                                                            </td>
                                                                        </tr>--%>
                                                <tr valign="middle" style="height: 25%; width: 100%;">
                                                    <td style="padding-left: 15px" colspan="2">
                                                        <asp:Label ID="lblPlatinumINR" runat="server" Text="INR" Font-Size="Small" meta:resourcekey="lblPlatinumINRResource1"></asp:Label>
                                                        <asp:Label ID="lblPlatinumPrice" runat="server" Font-Size="Small" meta:resourcekey="lblPlatinumPriceResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr valign="middle" style="height: 25%; width: 100%;">
                                                    <td style="padding-left: 15px" colspan="2">
                                                        <asp:Label ID="lblPlatinumUSD" runat="server" Text="USD" Font-Size="Small"></asp:Label>
                                                        <asp:Label ID="lblPlatinumPriceUSD" runat="server" Font-Size="Small"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td align="left" valign="middle" colspan="3">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPayment" runat="server" Text="Payment Option" Font-Bold="True"
                                                            Font-Size="Small" meta:resourcekey="lblPaymentResource1"></asp:Label><span>:</span>
                                                        <asp:DropDownList ID="ddlpayementtype" runat="server" CssClass="smallinput_t200"
                                                            Height="23px" meta:resourcekey="ddlpayementtypeResource1">
                                                            <asp:ListItem Text="--Select--" Value="0" Selected="True" meta:resourcekey="ListItemResource5">
                                                            </asp:ListItem>
                                                            <asp:ListItem Text="Online" Value="1" meta:resourcekey="ListItemResource6">
                                                            </asp:ListItem>
                                                            <asp:ListItem Text="Offline" Value="2" meta:resourcekey="ListItemResource7">
                                                            </asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnsubsc" runat="server" Text="Subscribe" CssClass="blue_button_fu"
                                                            OnClick="btnsubsc_Click" meta:resourcekey="btnsubscResource1" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <%--<asp:RadioButton ID="rbtnTrial" runat="server" Text="Trial" GroupName="rbtngrpMembership"
                                            Checked="True" Font-Bold="True" Font-Size="Small" meta:resourcekey="rbtnTrialResource1" />--%>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div style="background-color: #dfedf7">
                            <table style="width: 100%;" cellspacing="10" cellpadding="2">
                                <tr>
                                    <td width="22%">
                                    </td>
                                    <td valign="middle" align="left" width="25%">
                                    </td>
                                    <td valign="middle" style="width: 25%;" align="left">
                                    </td>
                                </tr>
                                <%-- </table>
                                                </td>
                                            </tr>--%>
                                <%--<asp:Button ID="btnSubmit" runat="server" Text="Subscribe" OnClick="btnSubmit_Click"
                                                            meta:resourcekey="btnSubmitResource1" />--%>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
