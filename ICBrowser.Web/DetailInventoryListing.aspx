<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master"
    AutoEventWireup="true" CodeBehind="DetailInventoryListing.aspx.cs" Inherits="ICBrowser.Web.DetailInventoryListing"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ MasterType VirtualPath="~/Detail.Master" %>
<%@ Register Namespace="ASPnetControls" Assembly="ASPnetPagerV2_8" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="headerback">
        <asp:Label ID="lblHeading" runat="server" Text="View/Browse hot components offered by members"
            CssClass="header" meta:resourcekey="lblHeadingResource2"></asp:Label>
    </div>
    <div style="clear: both">
    </div>
    <div id="chart_bgl">
        <asp:Panel ID="Panel1" runat="server" meta:resourcekey="Panel1Resource1" ScrollBars="Vertical"
            Height="450px">
            <asp:Repeater ID="RepDetailed" runat="server" OnItemDataBound="RepDetailed_ItemDataBound"
                OnItemCommand="RepDetailed_ItemCommand">
                <ItemTemplate>
                    <div id="chart_bgl">
                        <table width="100%">
                            <tr>
                                <td width="20%">
                                    <asp:HyperLink ID="hypCompanyName" runat="server" meta:resourcekey="HyperLink1Resource1"
                                        NavigateUrl='<%# Eval("UserId", "../NewUserProfile.aspx?UserId={0}") %>' Target="_blank"
                                        Font-Bold="True" Text='<%# Bind("CompanyName") %>' Font-Size="Medium"></asp:HyperLink>
                                </td>
                                <td width="5%">
                                    <asp:ImageButton ID="ImgQQIdText" runat="server" ToolTip='<%# Bind("QQId") %>' ImageUrl="~/Images/qq.png"
                                        Visible="false" />
                                </td>
                                <td width="5%">
                                    <asp:ImageButton ID="ImgSkypeText" runat="server" ToolTip='<%# Bind("SkypeId") %>'
                                        ImageUrl="~/Images/skype.png" Visible="false" />
                                </td>
                                <td width="5%">
                                    <asp:ImageButton ID="ImgMSNText" runat="server" ToolTip='<%# Bind("MSNId") %>' ImageUrl="~/Images/msn.png"
                                        Visible="false" />
                                </td>
                                <td width="40%">
                                </td>
                                <td width="10%" align="right">
                                    <asp:LinkButton ID="hnkMore" runat="server" Text="View Full List..." CommandName="More"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserId") %>' ForeColor="#fc0505"
                                        meta:resourceKey="hnkMoreResource3"></asp:LinkButton>
                                </td>
                                <td width="10%" align="right">
                                    <asp:Label ID="lblRecords" runat="server" Text="Total Records:" Font-Bold="true"
                                        Font-Italic="true" meta:resourceKey="lblRecordsResource3"></asp:Label>
                                </td>
                                <td width="5%" align="left">
                                    <asp:Label ID="lblTotalItems" runat="server" Text='<%# Bind("TotalItems") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10">
                                    <asp:Label ID="lblCityText" runat="server" Text="City:" Font-Bold="true" Font-Italic="true"
                                        meta:resourceKey="lblCityTextResource3"></asp:Label>
                                    <asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                    <asp:Label ID="lblCountryText" runat="server" Text="Country:" Font-Bold="true" Font-Italic="true"
                                        meta:resourceKey="lblCountryTextResource3"></asp:Label>
                                    <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                                    <asp:Label ID="lblTelText" runat="server" Text="Tel #:" Font-Bold="true" Font-Italic="true"
                                        meta:resourceKey="lblTelTextResource3"></asp:Label>
                                    <asp:Label ID="lblTel" runat="server" Text='<%# Bind("LandLine") %>'></asp:Label>
                                    <asp:Label ID="lblEmailText" runat="server" Text="Email:" Font-Bold="true" Font-Italic="true"
                                        meta:resourceKey="lblEmailTextResource3"></asp:Label>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("EmaiId") %>'></asp:Label>
                                    <asp:Button ID="btnquote" runat="server" Text='Request Quote' CommandName="button" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "userId") %>' />
                                </td>
                            </tr>
                        </table>
                        <table width="100%">
                            <tr>
                                <td class="grid">
                                    <asp:GridView ID="gvDetailInvList" runat="server" AutoGenerateColumns="False" Width="100%"
                                        DataSource='<%# Eval("DetailsRequirement") %>' OnRowCommand="gvDetailInvList_RowCommand"
                                        CssClass="table-border" OnRowDataBound="gvDetailInvList_RowDataBound">
                                        <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="User Id" SortExpression="UserId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkUserId" runat="server" CommandName="Select" Text='<%# Bind("UserId") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Part#" ItemStyle-Width="20%" meta:resourcekey="TemplateFieldResource1"
                                                SortExpression="ComponentName">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkComponentName" runat="server" Text='<%# Bind("ComponentName") %>'
                                                        CommandName="Select" meta:resourcekey="lnkComponentNameResource2"></asp:LinkButton>
                                                    <asp:HyperLink ID="hlComponentName" Text='<%# Bind("ComponentName") %>' runat="server"
                                                        ImageUrl="~/Images/pdf.png" NavigateUrl='<%# Eval("ComponentName", "http://www.alldatasheet.com/view.jsp?Searchword={0}") %>'
                                                        Target="_blank" meta:resourcekey="hlComponentNameResource2" ToolTip="Click to view Datasheet"></asp:HyperLink>
                                                    <%-- <asp:Image ID="imgOffer" runat="server" ImageUrl="Images/hot.gif" Style="vertical-align: top"
                                                        meta:resourceKey="imgOfferResource1" />--%>
                                                    <asp:Label ID="lblOffer" runat="server" Text='<%# Bind("isOffer") %>' Visible="False"
                                                        meta:resourcekey="lblOfferResource2"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="5%" DataField="Quantity" HeaderText="Qty" meta:resourcekey="BoundFieldResource1"
                                                SortExpression="Quantity"></asp:BoundField>
                                            <asp:TemplateField ItemStyle-Width="10%" HeaderText="Stock Status" meta:resourcekey="TemplateFieldResource12"
                                                HeaderStyle-CssClass="search-th">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStockStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "stockstatus") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="BrandName" ItemStyle-Width="8%" HeaderText="Make" meta:resourcekey="BoundFieldResource2"
                                                SortExpression="BrandName"></asp:BoundField>
                                            <asp:BoundField DataField="datecode" HeaderText="Date Code" ItemStyle-Width="8%"
                                                SortExpression="datecode" meta:resourceKey="BoundFieldResource5"></asp:BoundField>
                                            <asp:BoundField DataField="Package" ItemStyle-Width="10%" HeaderText="Package" SortExpression="Package"
                                                meta:resourceKey="BoundFieldResource6"></asp:BoundField>
                                            <asp:BoundField DataField="Description" ItemStyle-Width="20%" HeaderText="Comment"
                                                meta:resourcekey="BoundFieldResource3" SortExpression="Description"></asp:BoundField>
                                            <asp:BoundField DataField="PriceInUSD" ItemStyle-Width="10%" HeaderText="Unit price in USD"
                                                SortExpression="PriceInUSD" meta:resourceKey="BoundFieldResource9"></asp:BoundField>
                                            <%--   <asp:BoundField DataField="ModifiedOn" HeaderText="Updated On" ItemStyle-Width="10%"
                                           DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}" meta:resourceKey="BoundFieldResource12"></asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Updated On" SortExpression="ModifiedOn" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblModifiedOn" runat="server" Text='<%# Bind("ModifiedOn") %>'></asp:Label>
                                                </ItemTemplate>
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
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
            <table width="100%">
                <tr class="pagination" align="center">
                    <td>
                        <cc:PagerV2_8 ID="pagerForRepeater" PageSize="50" runat="server" OnCommand="pager_Command"
                            GenerateGoToSection="True" OnPreRender="pagerForRepeater_PreRender" BackToFirstClause="to First Page"
                            BackToPageClause="Back to Page" CompactModePageCount="10" CurrentIndex="1" FirstClause="&amp;lt;&amp;lt;"
                            FromClause="From" GenerateFirstLastSection="False" GenerateHiddenHyperlinks="False"
                            GeneratePagerInfoSection="True" GenerateSmartShortCuts="True" GenerateToolTips="True"
                            GoClause="go" GoToLastClause="to Last Page" ItemCount="0" LastClause="&amp;gt;&amp;gt;"
                            MaxSmartShortCutCount="6" meta:resourcekey="pagerForRepeaterResource1" NextClause="&amp;gt;"
                            NextToPageClause="Next to Page" NormalModePageCount="15" OfClause="of" PageClause="Page"
                            PreviousClause="&amp;lt;" QueryStringParameterName="pagerControlCurrentPageIndex"
                            RTL="False" ShowingResultClause="Showing Results" ShowResultClause="Show Result"
                            SmartShortCutRatio="3" SmartShortCutThreshold="30" ToClause="to" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
