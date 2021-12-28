<%@ Page Language="C#"  Title="ICBrowser.com buy and sell electronic components" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MatchOffers.aspx.cs"
    ValidateRequest="false" Inherits="ICBrowser.Web.MatchRequirments" Culture="auto"
    UICulture="auto" meta:resourcekey="PageResource1" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="ASPnetControls" Assembly="ASPnetPagerV2_8" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="chart_bg">
        <table class="headerback" width="100%">
            <tr>
                <td colspan="2">
                    <div>
                        <asp:Label ID="lblHeader" runat="server" Text="Match components from Offers/Inventories database with my posted Requirements/PO"
                            CssClass="header" meta:resourcekey="lblHeaderResource1"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="70%">
                </td>
                <td width="30%" align="right">
                    <asp:Label ID="lblErmsg" runat="server" Font-Size="Small" ForeColor="Red" Visible="False"
                        meta:resourcekey="lblErmsgResource1"></asp:Label>
                    <asp:Label ID="lblCrmsg" runat="server" Font-Size="Small" ForeColor="Green" Visible="False"
                        meta:resourcekey="lblCrmsgResource1"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Repeater ID="rptrRequirement" runat="server" OnItemCommand="rptrRequirement_ItemCommand"
            OnItemDataBound="rptrRequirement_ItemDataBound">
            <ItemTemplate>
                <div id="chart_bgl">
                    <table width="100%">
                        <tr>
                            <td width="30%">
                                <asp:HyperLink ID="BuyerName" runat="server" Font-Size="Medium" Font-Bold="True"
                                    Style="padding-left: 10px" ForeColor="#505EAD" NavigateUrl='<%# Eval("UserId", "../NewUserProfile.aspx?UserId={0}") %>'
                                    Target="_blank" Text='<%# Bind("CompanyName") %>' meta:resourcekey="BuyerNameResource1"></asp:HyperLink>
                            </td>
                            <td width="50%" align="right">
                                <asp:Label ID="lblmsg" runat="server" Font-Size="Small" ForeColor="Red" Visible="False"
                                    meta:resourcekey="lblmsgResource1"></asp:Label>
                            </td>
                            <td width="20%" align="center">
                                <asp:Button ID="btnSendMsg" runat="server" Text="Send Message" CommandArgument='<%# Eval("UserId") %>'
                                    CommandName="Send" CssClass="blue_button" meta:resourcekey="btnSendMsgResource1" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <div class="grid">
                                    <asp:GridView ID="MatchRequirements" runat="server" AutoGenerateColumns="False" DataSource='<%# Eval("Components") %>'
                                        OnRowCommand="MatchRequirements_RowCommand" Width="100%" CssClass="table-border"
                                        meta:resourcekey="MatchRequirementsResource1">
                                        <Columns>
                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkbx" runat="server" meta:resourcekey="chkbxResource1" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UserId" SortExpression="UserId" Visible="False" meta:resourcekey="TemplateFieldResource2">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkUserId" runat="server" Text='<%# Bind("UserId") %>' meta:resourcekey="lnkUserIdResource1"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Part #" SortExpression="ComponentName" meta:resourcekey="TemplateFieldResource20">
                                                <HeaderStyle Width="20%" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk" runat="server" CommandName="btn" CommandArgument='<%# Eval("UserId") %>'
                                                        Text='<%# Bind("ComponentName") %>' meta:resourcekey="lnkResource1"></asp:LinkButton>
                                                    <asp:Label ID="lblpartn" runat="server" Text='<%# Bind("ComponentName") %>' Visible="False"
                                                        meta:resourcekey="lblpartnResource1"></asp:Label>
                                                    <asp:Label ID="lblflag" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Flag") %>'
                                                        Visible="False" meta:resourcekey="lblflagResource1"></asp:Label>
                                                    <asp:Image ID="flag" runat="server" ImageUrl="Images/hot.gif" Style="vertical-align: top"
                                                        Visible="False" meta:resourcekey="flagResource2"></asp:Image>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty" SortExpression="Quantity" meta:resourcekey="TemplateFieldResource21">
                                                <HeaderStyle Width="8%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>' meta:resourcekey="lblQuantityResource1"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Make" SortExpression="Brand Name" meta:resourcekey="TemplateFieldResource5">
                                                <HeaderStyle Width="8%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBrandName" runat="server" Text='<%# Bind("BrandName") %>' meta:resourcekey="lblBrandNameResource1"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date Code" SortExpression="DateCode" meta:resourcekey="TemplateFieldResource22">
                                                <HeaderStyle Width="8%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDateCode" runat="server" Text='<%# Bind("DateCode") %>' meta:resourcekey="lblDateCodeResource1"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Package" SortExpression="Package" meta:resourcekey="TemplateFieldResource7">
                                                <HeaderStyle Width="8%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPackage" runat="server" Text='<%# Bind("Package") %>' meta:resourcekey="lblPackageResource1"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price In IRS" SortExpression="PriceInUSD" meta:resourcekey="TemplateFieldResource23">
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPriceInUSD" runat="server" Text='<%# Bind("PriceInUSD") %>' meta:resourcekey="lblPriceInUSDResource1"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comment" meta:resourcekey="TemplateFieldResource24">
                                                <HeaderStyle Width="20%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CreatedOn" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Posted On"
                                                SortExpression="CreatedOn" meta:resourcekey="TemplateFieldResource25">
                                                <HeaderStyle Width="10%" />
                                            </asp:BoundField>
                                        </Columns>
                                        <RowStyle CssClass="odd"></RowStyle>
                                        <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                    </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
            </ItemTemplate>
            <FooterTemplate>
                <%-- Label used for showing Error Message --%>
                <asp:Label ID="lblErrorMsg" runat="server" CssClass="redmsg" Text="No Records Found."
                    Visible="false">
                </asp:Label>
            </FooterTemplate>
        </asp:Repeater>
        <table width="100%">
            <tr class="pagination" align="center">
                <td>
                    <cc:PagerV2_8 ID="pagerForRepeater" PageSize="50" runat="server" OnCommand="pager_Command"
                        GenerateGoToSection="True" BackToFirstClause="to First Page" BackToPageClause="Back to Page"
                        CompactModePageCount="0" CurrentIndex="1" FirstClause="&amp;lt;&amp;lt;" FromClause="From"
                        GenerateFirstLastSection="False" GenerateHiddenHyperlinks="False" GeneratePagerInfoSection="True"
                        GenerateSmartShortCuts="True" GenerateToolTips="True" GoClause="go" GoToLastClause="to Last Page"
                        ItemCount="0" LastClause="&amp;gt;&amp;gt;" MaxSmartShortCutCount="6" meta:resourcekey="pagerForRepeaterResource1"
                        NextClause="&amp;gt;" NextToPageClause="Next to Page" NormalModePageCount="15"
                        OfClause="of" PageClause="Page" PreviousClause="&amp;lt;" QueryStringParameterName="pagerControlCurrentPageIndex"
                        RTL="False" ShowingResultClause="Showing Results" ShowResultClause="Show Result"
                        SmartShortCutRatio="3" SmartShortCutThreshold="30" ToClause="to" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
