<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BuyersRatingforSeller.aspx.cs" Inherits="ICBrowser.Web.BuyersRatingforSeller"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        function ratingsaved() {
            alert("Your ratings have been saved.");
        }

        function IsMaxLength(obj, MaxLen) {
            return (obj.value.length <= MaxLen);
        }


        function ismaxlength(objTxtCtrl, nLength) {
            if (objTxtCtrl.getAttribute && objTxtCtrl.value.length > nLength)
                objTxtCtrl.value = objTxtCtrl.value.substring(0, nLength)

            if (document.all)
                document.getElementById('lblCaption').innerText = objTxtCtrl.value.length + ' Out Of ' + nLength;
            else
                document.getElementById('lblCaption').textContent = objTxtCtrl.value.length + ' Out Of ' + nLength;

        }

    </script>
    <asp:ScriptManager ID="sm1" runat="server">
    </asp:ScriptManager>
    <table width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <div id="chart_bg">
                    <table width="100%" cellspacing="3" cellpadding="3">
                        <tr>
                            <td>
                                <div class="chart_heading">
                                    <asp:Label ID="lblheading" runat="server" CssClass="header" Text="Survey Question"
                                        meta:resourcekey="lblheadingResource1"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" cellspacing="3" cellpadding="3">
                                    <tr>
                                        <td>
                                            <table width="100%" cellspacing="3" cellpadding="3">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblQuestionHeading" runat="server" Text="Questions" CssClass="bold"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="100%" cellspacing="3" cellpadding="3">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblRatingheading" runat="server" Text="Your Ratings" CssClass="bold"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" cellspacing="3" cellpadding="3">
                                                <tr>
                                                    <td>
                                                        1.&nbsp;&nbsp;<asp:Label ID="lblQuestion1" runat="server" Font-Size="12px" Font-Italic="True"
                                                            meta:resourcekey="lblQuestion1Resource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="100%" cellspacing="3" cellpadding="3">
                                                <tr>
                                                    <td>
                                                        <asp:Rating ID="ratingQuest1" runat="server" Height="20px" StarCssClass="ratingStar"
                                                            WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar"
                                                            BehaviorID="ratingQuest1_RatingExtender" CurrentRating="0" meta:resourcekey="ratingQuest1Resource1">
                                                        </asp:Rating>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" cellspacing="3" cellpadding="3">
                                                <tr>
                                                    <td>
                                                        2.&nbsp;&nbsp;<asp:Label ID="lblQuestion2" runat="server" Font-Size="12px" Font-Italic="True"
                                                            meta:resourcekey="lblQuestion2Resource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="100%" cellspacing="3" cellpadding="3">
                                                <tr>
                                                    <td>
                                                        <asp:Rating ID="ratingQuest2" runat="server" Height="20px" StarCssClass="ratingStar"
                                                            WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar"
                                                            BehaviorID="ratingQuest2_RatingExtender" CurrentRating="0" meta:resourcekey="ratingQuest2Resource1">
                                                        </asp:Rating>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" cellspacing="5" cellpadding="5">
                                                <tr>
                                                    <td>
                                                        3.&nbsp;&nbsp;<asp:Label ID="lblQuestion3" runat="server" Font-Size="12px" Font-Italic="True"
                                                            meta:resourcekey="lblQuestion3Resource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="100%" cellspacing="3" cellpadding="3">
                                                <tr>
                                                    <td>
                                                        <asp:Rating ID="ratingQuest3" runat="server" Height="20px" StarCssClass="ratingStar"
                                                            WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar"
                                                            BehaviorID="ratingQuest3_RatingExtender" CurrentRating="0" meta:resourcekey="ratingQuest3Resource1">
                                                        </asp:Rating>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" cellspacing="3" cellpadding="3">
                                                <tr>
                                                    <td>
                                                        4.&nbsp;&nbsp;<asp:Label ID="lblQuestion4" Font-Size="12px" Font-Italic="True" runat="server"
                                                            meta:resourcekey="lblQuestion4Resource1"></asp:Label>&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="100%" cellspacing="3" cellpadding="3">
                                                <tr>
                                                    <td>
                                                        <asp:Rating ID="ratingQuest4" runat="server" Height="20px" StarCssClass="ratingStar"
                                                            WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar"
                                                            BehaviorID="ratingQuest4_RatingExtender" CurrentRating="0" meta:resourcekey="ratingQuest4Resource1">
                                                        </asp:Rating>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" style="padding-top: 10px">
                                            <table width="100%" cellpadding="3" cellspacing="3">
                                                <tr>
                                                    <td valign="top" align="right" width="30%">
                                                        <asp:Label ID="lblCommentheader" runat="server" Font-Size="12px" Text="Your Comments :"></asp:Label>
                                                    </td>
                                                    <td valign="top">
                                                        <%--<asp:TextBox ID="txtReplyMessage" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                            onkeyup="return ismaxlength(this,500)" Height="100px" MaxLength="50" ValidationGroup="WithoutTemplate"
                                                            Width="380px" TextMode="MultiLine" meta:resourcekey="txtReplyContentResource1"></asp:TextBox>--%>
                                                        <asp:TextBox ID="txtComments" runat="server" CssClass="smallinput_t_multilinetextbox"
                                                            AutoCompleteType="Disabled" onkeypress="return IsMaxLength(this, 500);" TextMode="MultiLine"
                                                            onkeyup="return ismaxlength(this,500)" Width="90%" Height="150px"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="lblPostComment" runat="server" Text="(*Not Mandatory).Please post your comment.Enter only 500 characters."></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr style="height: 12px">
                                                    <td colspan="2" align="center">
                                                        <label id='lblCaption' style="font-family: Tahoma; font-size: 1em; font-weight: bold">
                                                        </label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="50%" style="padding-top: 5px">
                                                        <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="blue_button" OnClientClick="ratingsaved();"
                                                            OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                                    </td>
                                                    <td style="padding-left: 10px; padding-top: 5px" align="left" width="50%">
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="blue_button" CausesValidation="false"
                                                            OnClick="btnCancel_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <asp:LinkButton ID="lbkback" runat="server" Text="Back" CausesValidation="False"
                                                OnClick="lbkback_Click" meta:resourcekey="lbkbackResource1"></asp:LinkButton>
                                        </td>
                                    </tr>--%>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
