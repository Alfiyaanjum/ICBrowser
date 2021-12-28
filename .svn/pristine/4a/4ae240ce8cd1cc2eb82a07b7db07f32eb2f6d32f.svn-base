<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserRating.aspx.cs" Inherits="ICBrowser.Web.UserRating" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 24%;
        }
        .style2
        {
            margin-left: 210px;
        }
    </style>
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
    <table width="100%" cellspacing="0" cellpadding="0" style="background-color: #dfedf7">
        <tr>
            <td>
                <div id="chart_bg">
                    <table width="100%" cellspacing="3" cellpadding="3" >
                        <tr>
                            <td>

                                <div class="headerback">
                                    <asp:Label ID="lblheading" runat="server" CssClass="header" Text="Survey Questions"
                                        meta:resourcekey="lblheadingResource1"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr id="trSelectType" runat="server" visible="false">
                            <td valign="top">
                                <table cellpadding="3" cellspacing="3" width="100%">
                                    <tr>
                                        <td align="right" class="style1">
                                            <asp:Label ID="lblaskType" runat="server" Text="Rate Member as:"
                                                CssClass="bold" meta:resourcekey="lblaskTypeResource1"></asp:Label>
                                        </td>
                                        <td width="100%">
                                            <asp:RadioButtonList ID="rblist" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                                Width="30%" OnSelectedIndexChanged="rblist_SelectedIndexChanged" meta:resourcekey="rblistResource1">
                                                <asp:ListItem Text="Buyer" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                <asp:ListItem Text="Seller" Value="1" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            
                                          
                                        </td>
                                        <%--<td width="70%">
                                            <asp:RequiredFieldValidator ID="rfvSelectType" runat="server" ControlToValidate="rblist"
                                                ErrorMessage="Please make a selection to rate this Member." InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>--%>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" cellspacing="3" cellpadding="3" id="tbquestion" runat="server">
                                    <tr>
                                    <td class="style1"></td>
                                        <td align="left">
                                            <asp:GridView ID="grdrating" Width="80%" CellPadding="5" CellSpacing="5" runat="server"
                                                GridLines="None" HeaderStyle-HorizontalAlign="right" AutoGenerateColumns="False"
                                                OnRowDataBound="grdrating_RowDataBound" 
                                                meta:resourcekey="grdratingResource1" >
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="false" Visible="false" meta:resourcekey="TemplateFieldResource1">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQuestionId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QuestionId") %>'
                                                                Visible="False" meta:resourcekey="lblQuestionIdResource1"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Questions" meta:resourcekey="TemplateFieldResource2" HeaderStyle-Width="80%" ItemStyle-Width="85%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQuestion" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Question") %>'
                                                                meta:resourcekey="lblQuestionResource1"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ratings" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Top" meta:resourcekey="TemplateFieldResource3">
                                                        <ItemTemplate>
                                                            <asp:Rating ID="ratingQuest" runat="server" Height="20px" StarCssClass="ratingStar"
                                                                WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar"
                                                                CurrentRating="0" meta:resourcekey="ratingQuestResource1">
                                                            </asp:Rating>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" style="padding-top: 10px">
                                            <table width="100%" cellpadding="3" cellspacing="3">
                                            <tr>
                                            <td class="style1">
                                              
                                            </td>
                                            <td>
                                            <asp:Label ID="lblratingmsg" runat="server" Text="Rating is mandatory to post comment." meta:resourcekey="rblistResource1" ForeColor="Red" Visible="false"></asp:Label>
                                            </td>
                                            </tr>
                                                <tr>
                                                    <td valign="top" align="right" class="style1">
                                                        <asp:Label ID="lblCommentheader" runat="server" Font-Size="12px" Font-Bold="true" Text="Comment:"
                                                            meta:resourcekey="lblCommentheaderResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtComments" runat="server" CssClass="smallinput_t_multilinetextbox" Font-Names="Calibri" Font-Size="12"
                                                            AutoCompleteType="Disabled" TextMode="MultiLine" Width="80%" Height="150px" meta:resourcekey="txtCommentsResource1"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="lblPostComment" runat="server" Text="Comment is not mandatory and is viewed only by Admin." ForeColor="Blue"
                                                            meta:resourcekey="lblPostCommentResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="blue_button" 
                                                OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False"
                                                CssClass="blue_button" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
