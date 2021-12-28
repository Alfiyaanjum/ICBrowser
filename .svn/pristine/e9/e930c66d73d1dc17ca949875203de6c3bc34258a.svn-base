<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="ViewRatings.aspx.cs" Inherits="ICBrowser.Web.ViewRatings" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function confirmDelete() {
            if (confirm('Are you sure you want to delete this ratings ?')) {
                return true;
            }
            else {
                return false;
            }
            return;
        }
        

    </script>
    <asp:ScriptManager ID="sm1" runat="server">
    </asp:ScriptManager>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr style="background-color: White">
            <td>
                <table width="100%" cellpadding="0" cellspacing="0" style="border: 1px solid #069;
                    border-collapse: separate;" align="center">
                    <tr class="headerback">
                        <td valign="middle">
                            <asp:Label ID="lblSellerHeader" Font-Size="Medium" runat="server" Text=" Paid Member Ratings"
                                CssClass="header" meta:resourcekey="lblSellerHeaderResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr style="background-color: #EFFBFE">
                                    <td valign="top">
                                        <table width="100%" cellspacing="0" cellpadding="0" style="height: 35px">
                                            <tr>
                                                <td width="25%" valign="middle" align="right">
                                                    <asp:Label ID="lblSearch" runat="server" Text="Search Company Name:" CssClass="text"
                                                        meta:resourcekey="lblSearchResource1"></asp:Label>
                                                </td>
                                                <td align="left" width="15%" valign="middle" style="padding-left:5px">
                                                    <asp:TextBox ID="txtSearchFromGrid" runat="server" CssClass="smallinput_t" Width="126px"
                                                        meta:resourcekey="txtSearchFromGridResource1"></asp:TextBox>
                                                </td>
                                                <td width="5%" align="left" valign="middle">
                                                    <asp:ImageButton ID="imgSearchFromGrid" runat="server" ImageUrl="~/Images/search_button.png"
                                                        OnClick="imgSearchFromGrid_Click" ToolTip="Search" meta:resourcekey="imgSearchFromGridResource1" />
                                                    <%-- <asp:ImageButton ID="imgSearchFromGrid" CausesValidation="False" runat="server" ImageUrl="~/Images/Search.png"
                                                                        ToolTip="Search" OnClick="imgSearchFromGrid_Click" meta:resourcekey="imgSearchFromGridResource1" />&nbsp;&nbsp;--%>
                                                </td>
                                                <td width="80%" align="left" valign="middle">
                                                    <asp:ImageButton ID="imgClearSearchSelection" runat="server" ImageUrl="~/Images/clear_btn.png"
                                                        CausesValidation="False" ToolTip="Clear Search" OnClick="imgClearSearchSelection_Click"
                                                        meta:resourcekey="imgClearSearchSelectionResource1" />
                                                </td>
                                                <%--  <td width="75%" align="left" valign="middle">
                                                    <asp:Label ID="lblmsg" runat="server" CssClass="redmsg" Visible="false"></asp:Label>
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div>
                                            <asp:GridView ID="grdSellerRating" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left" Width="100%" OnRowDataBound="grdSellerRating_RowDataBound"
                                                PageSize="15" OnRowCommand="grdSellerRating_RowCommand" AllowPaging="True" OnPageIndexChanging="grdSellerRating_PageIndexChanging"
                                                meta:resourcekey="grdSellerRatingResource1">
                                                <HeaderStyle BackColor="#EFFBFE" CssClass="table-border" />
                                                <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="false" Visible="false" meta:resourcekey="TemplateFieldResource1">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSellerId" Visible="False" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserID") %>'
                                                                meta:resourcekey="lblSellerIdResource1"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Company Name" meta:resourcekey="TemplateFieldResource2"
                                                        ItemStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="lnkSellerName" runat="server" NavigateUrl='<%# Eval("UserID", "NewUserProfile.aspx?UserID={0}") %>'
                                                                Text='<%# Eval("CompanyName") %>' Target="_blank" meta:resourcekey="lnkSellerNameResource1" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Average Rating As Seller" meta:resourcekey="TemplateFieldResource3"
                                                        ItemStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Rating ID="ratingQuestSeller" runat="server" Height="20px" StarCssClass="ratingStar"
                                                                ReadOnly="True" CurrentRating="0" WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar"
                                                                EmptyStarCssClass="emptyRatingStar" BehaviorID="ratingQuestSeller_RatingExtender"
                                                                meta:resourcekey="ratingQuestSellerResource1">
                                                            </asp:Rating>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Average Rating As Buyer" meta:resourcekey="TemplateFieldResource4"  ItemStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Rating ID="ratingQuestBuyer" runat="server" Height="20px" StarCssClass="ratingStar"
                                                                ReadOnly="True" CurrentRating="0" WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar"
                                                                EmptyStarCssClass="emptyRatingStar" BehaviorID="ratingQuestBuyer_RatingExtender"
                                                                meta:resourcekey="ratingQuestBuyerResource1">
                                                            </asp:Rating>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete your Ratings" meta:resourcekey="TemplateFieldResource5"  ItemStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Button runat="server" ID="imgbtnPaidAsSellerDelete" Text="For Seller" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserID") %>'
                                                                CommandName="DeletePaidMemberRatingAsSeller" ToolTip="Delete your Ratings for this Seller"
                                                                OnClientClick="return confirmDelete();" CssClass="blue_button" ValidationGroup="deleteConfirmation"
                                                                meta:resourcekey="imgbtnPaidAsSellerDeleteResource1" />&nbsp;&nbsp;
                                                            <asp:Button runat="server" ID="imgbtnPaidAsBuyerDelete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserID") %>'
                                                                CommandName="DeletePaidMemberRatingAsBuyer" Text="For Buyer" ToolTip="Delete your Ratings for this Buyer"
                                                                OnClientClick="return confirmDelete();" CssClass="blue_button" ValidationGroup="deleteConfirmation"
                                                                meta:resourcekey="imgbtnPaidAsBuyerDeleteResource1" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table style="background-color: #EEF0F6" width="100%" border="0" cellpadding="0"
                                                        cellspacing="0">
                                                        <tr>
                                                            <td colspan="2" class="errormsg" style="height: 100px" align="center">
                                                                No records found.
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                                <RowStyle CssClass="odd" />
                                                <PagerStyle CssClass="headerback" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 20px">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr style="background-color: White">
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" style="border: 1px solid #069;
                                border-collapse: separate;" align="center">
                                <tr class="headerback">
                                    <td valign="middle">
                                        <asp:Label ID="lblFreeMember" CssClass="header" runat="server" Text=" Free Member Ratings"
                                            meta:resourcekey="lblFreeMemberResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr style="background-color: #EFFBFE">
                                                <td valign="top" style="padding-top: 5px" align="center">
                                                    <table width="98%" cellspacing="0" cellpadding="0" style="height: 35px">
                                                        <tr>
                                                            <td width="25%" valign="middle" align="right">
                                                                <asp:Label ID="Label1" runat="server" Text="Search Company Name :" CssClass="text"
                                                                    meta:resourcekey="Label1Resource1"></asp:Label>
                                                            </td>
                                                            <td align="left" width="15%" valign="middle" style="padding-left:5px">
                                                                <asp:TextBox ID="txtSearchFreeMember" runat="server" CssClass="smallinput_t" Width="126px"
                                                                    meta:resourcekey="txtSearchFreeMemberResource1"></asp:TextBox>
                                                            </td>
                                                            <td width="5%" align="left" valign="middle">
                                                                <asp:ImageButton ID="ImgSearchFreeMember" runat="server" ImageUrl="~/Images/search_button.png"
                                                                    ToolTip="Search" OnClick="ImgSearchFreeMember_Click" meta:resourcekey="ImgSearchFreeMemberResource1" />
                                                                <%-- <asp:ImageButton ID="imgSearchFromGrid" CausesValidation="False" runat="server" ImageUrl="~/Images/Search.png"
                                                                        ToolTip="Search" OnClick="imgSearchFromGrid_Click" meta:resourcekey="imgSearchFromGridResource1" />&nbsp;&nbsp;--%>
                                                            </td>
                                                            <td width="80%" align="left" valign="middle">
                                                                <asp:ImageButton ID="imgClearFreeMmeberSearch" runat="server" ImageUrl="~/Images/clear_btn.png"
                                                                    CausesValidation="False" ToolTip="Clear Search" OnClick="imgClearFreeMmeberSearch_Click"
                                                                    meta:resourcekey="imgClearFreeMmeberSearchResource1" />
                                                            </td>
                                                            <%--<td width="75%" align="left" valign="middle">
                                                                <asp:Label ID="lblFreeMemberError" runat="server" CssClass="redmsg" Visible="false"></asp:Label>
                                                            </td>--%>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <div>
                                                        <asp:GridView ID="grdFreeMember" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                            AllowPaging="True" GridLines="Horizontal" HeaderStyle-HorizontalAlign="Left"
                                                            Width="100%" PageSize="15" OnRowDataBound="grdFreeMember_RowDataBound" OnRowCommand="grdFreeMember_RowCommand"
                                                            OnPageIndexChanging="grdFreeMember_PageIndexChanging" meta:resourcekey="grdFreeMemberResource1">
                                                            <HeaderStyle BackColor="#EFFBFE" />
                                                            <AlternatingRowStyle CssClass="even" />
                                                            <Columns>
                                                                <asp:TemplateField ShowHeader="false" Visible="false" meta:resourcekey="TemplateFieldResource6">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBuyerId" Visible="False" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserID") %>'
                                                                            meta:resourcekey="lblBuyerIdResource1"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Company Name" meta:resourcekey="TemplateFieldResource7"
                                                                    ItemStyle-Width="25%">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="lnkSellerName" runat="server" NavigateUrl='<%# Eval("UserID", "NewUserProfile.aspx?UserID={0}") %>'
                                                                            Text='<%# Eval("CompanyName") %>' Target="_blank" meta:resourcekey="lnkSellerNameResource2" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <%--  <asp:TemplateField HeaderText=" Ratings As Seller">
                                            <ItemTemplate>
                                                <asp:Rating ID="ratingQuestSeller" runat="server" Height="20px" StarCssClass="ratingStar"
                                                    ReadOnly="true" CurrentRating="0" WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar"
                                                    EmptyStarCssClass="emptyRatingStar">
                                                </asp:Rating>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" BackColor="#EDEDED" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>--%>
                                                                <asp:TemplateField HeaderText=" Average Ratings As Buyer" meta:resourcekey="TemplateFieldResource8"
                                                                    ItemStyle-Width="25%">
                                                                    <ItemTemplate>
                                                                        <asp:Rating ID="ratingQuestASBuyer" runat="server" Height="20px" StarCssClass="ratingStar"
                                                                            ReadOnly="True" CurrentRating="0" WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar"
                                                                            EmptyStarCssClass="emptyRatingStar" BehaviorID="ratingQuestASBuyer_RatingExtender"
                                                                            meta:resourcekey="ratingQuestASBuyerResource1">
                                                                        </asp:Rating>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete your Ratings" meta:resourcekey="TemplateFieldResource9" ItemStyle-HorizontalAlign="Right"
                                                                    ItemStyle-Width="50%">
                                                                    <ItemTemplate>
                                                                        <asp:Button runat="server" ID="imgbtnFreeDelete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserID") %>'
                                                                            Text="Delete" ToolTip="Delete your Ratings for this Buyer" OnClientClick="return confirmDelete();"
                                                                            CssClass="blue_button" ValidationGroup="deleteConfirmation" CommandName="DeleteFreeMemberRating"
                                                                            meta:resourcekey="imgbtnFreeDeleteResource1"/>
                                                                    </ItemTemplate>
                                                                   
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <table style="background-color: #EEF0F6" width="100%" border="0" cellpadding="0"
                                                                    cellspacing="0">
                                                                    <tr>
                                                                        <td colspan="2" class="errormsg" style="height: 100px" align="center">
                                                                            No records found.
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </EmptyDataTemplate>
                                                            <RowStyle CssClass="odd" />
                                                            <PagerStyle CssClass="headerback" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
