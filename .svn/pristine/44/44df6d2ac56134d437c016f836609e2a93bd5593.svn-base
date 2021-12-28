<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="DetailedBuyersRequirements.aspx.cs" Inherits="ICBrowser.Web.DetailedBuyersRequirements"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ MasterType VirtualPath="~/Detail.Master" %>
<%@ Register Namespace="ASPnetControls" Assembly="ASPnetPagerV2_8" TagPrefix="cc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="headerback">
        <asp:Label ID="lblHeading" runat="server" Text="View/Browse components requirement posted by members" CssClass="header" meta:resourcekey="lblHeadingResource1"></asp:Label>
    </div>
    <div id="chart_bgl" style="width: 100%">
        <asp:Panel ID="Panel1" runat="server" meta:resourcekey="Panel1Resource1" ScrollBars="Vertical"
            Height="450px">
            <div>
                <asp:Repeater ID="rptrBuyer" runat="server" OnItemDataBound="rptrBuyer_ItemDataBound"
                    OnItemCommand="rptrBuyer_ItemCommand">
                    <ItemTemplate>
                        <div id="chart_bgl" style="width: 100%">
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
                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "userId") %>' ForeColor="#fc0505"
                                            meta:resourceKey="hnkMoreResource3"></asp:LinkButton>
                                    </td>
                                    <td width="10%" align="right">
                                        <asp:Label ID="lblRecords" runat="server" Text="Total Records:" Font-Bold="true"
                                            Font-Italic="true" meta:resourceKey="lblRecordsResource1"></asp:Label>
                                    </td>
                                    <td width="5%" align="left">
                                        <asp:Label ID="lblTotalItems" runat="server" Text='<%# Bind("TotalItems") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="10">
                                        <asp:Label ID="lblCityText" runat="server" Text="City:" Font-Bold="true" Font-Italic="true"
                                            meta:resourceKey="lblCityTextResource1"></asp:Label>
                                        <asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                        <asp:Label ID="lblCountryText" runat="server" Text="Country:" Font-Bold="true" Font-Italic="true"
                                            meta:resourceKey="lblCountryTextResource1"></asp:Label>
                                        <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                                        <asp:Label ID="lblTelText" runat="server" Text="Tel #:" Font-Bold="true" Font-Italic="true"
                                            meta:resourceKey="lblTelTextResource1"></asp:Label>
                                        <asp:Label ID="lblTel" runat="server" Text='<%# Bind("LandLine") %>'></asp:Label>
                                        <asp:Label ID="lblEmailText" runat="server" Text="Email:" Font-Bold="true" Font-Italic="true"
                                            meta:resourceKey="lblEmailTextResource1"></asp:Label>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("EmaiId") %>'></asp:Label>
                                        <asp:Button ID="btnquote" runat="server" Text='Quote' CommandName="button" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "userId") %>' />
                                    </td>
                                </tr>
                            </table>
                            <table width="100%">
                                <tr>
                                    <td class="grid">
                                        <asp:GridView ID="gvBuyrListng" runat="server" OnRowCommand="gvBuyrListng_RowCommand"
                                            OnRowDataBound="gvBuyrListng_RowDataBound" AutoGenerateColumns="False" DataSource='<%# Eval("BuyersRequirement") %>'
                                            Width="100%" CssClass="table-border" PageSize="10" AllowPaging="true" PagerSettings-Visible="false"
                                            PageIndex="0">
                                            <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                            <Columns>
                                                <asp:TemplateField HeaderText="User Id" SortExpression="UserId" Visible="false" meta:resourcekey="TemplateFieldResource9">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkSellerId" runat="server" Text='<%# Bind("UserId") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Part #" SortExpression="BuyerName">
                                                    <HeaderStyle Width="20%" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkComponentName" runat="server" Text='<%# Bind("ComponentName") %>'
                                                            CommandName="Select" meta:resourceKey="lnkComponentNameResource1"></asp:LinkButton>
                                                       <%-- <asp:HyperLink ID="hlComponentName" Text='<%# Bind("ComponentName") %>' runat="server"
                                                            ToolTip="Click to view Datasheet" ImageUrl="~/Images/pdf.png" BorderStyle="None"
                                                            NavigateUrl='<%# Eval("ComponentName", "http://www.alldatasheet.com/view.jsp?Searchword={0}") %>'
                                                            Target="_blank" meta:resourcekey="hlComponentNameResource1"></asp:HyperLink>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty" SortExpression="Quantity" meta:resourcekey="TemplateFieldResource1">
                                                    <HeaderStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Make" SortExpression="Brand Name" meta:resourcekey="TemplateFieldResource5">
                                                    <HeaderStyle Width="8%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBrandName" runat="server" Text='<%# Bind("BrandName") %>' meta:resourcekey="lblBrandNameResource1"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date Code" meta:resourcekey="TemplateFieldResource2">
                                                    <HeaderStyle Width="8%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDateCode" runat="server" Text='<%# Bind("DateCode") %>' meta:resourcekey="lblDateCodeResource1"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Package" meta:resourceKey="BoundFieldResource7">
                                                    <HeaderStyle Width="8%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblpackage" runat="server" Text='<%# Bind("Package") %>' meta:resourcekey="lblDateCodeResource1"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="PO/RFQ" meta:resourcekey="TemplateFieldResource3">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblWithPO" runat="server" Text='<%# Eval("RequirementwithPO") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText=" Unit Price In USD" SortExpression="PriceInUSD" meta:resourcekey="TemplateFieldResource4">
                                                    <HeaderStyle Width="15%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPriceInUSD" runat="server" Text='<%# Bind("PriceInUSD") %>' meta:resourcekey="lblPriceInUSDResource1"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Comment" meta:resourcekey="TemplateFieldResource6">
                                                    <HeaderStyle Width="20%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Updated On" SortExpression="ModifiedDate" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblModifiedOn" runat="server" Text='<%# Bind("ModifiedDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="odd" />
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
            </div>
        </asp:Panel>
    </div>
</asp:Content>
