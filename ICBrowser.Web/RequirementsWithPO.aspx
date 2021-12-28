<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="RequirementsWithPO.aspx.cs" Inherits="ICBrowser.Web.RequirementsWithPO"
    Culture="auto" UICulture="auto" meta:resourcekey="PageResource1" %>

<%@ MasterType VirtualPath="~/Detail.Master" %>
<%@ Register Namespace="ASPnetControls" Assembly="ASPnetPagerV2_8" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="headerback">
        <asp:Label ID="lblHeading" runat="server" Text="View/Browse components requirement with Purchase Order posted by members" CssClass="header"
            meta:resourcekey="lblHeadingResource1"></asp:Label>
    </div>
    <div id="chart_bgl" style="width: 100%">
        <asp:Panel ID="pnl" runat="server" ScrollBars="Vertical" meta:resourcekey="pnlResource1"
            Height="450px">
            <asp:Repeater ID="rptRequirementWithPO" runat="server" OnItemCommand="rptRequirementWithPO_ItemCommand"
                OnItemDataBound="rptRequirementWithPO_ItemDataBound">
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
                                        Visible="False" meta:resourcekey="ImgQQIdTextResource1" />
                                </td>
                                <td width="5%">
                                    <asp:ImageButton ID="ImgSkypeText" runat="server" ToolTip='<%# Bind("SkypeId") %>'
                                        ImageUrl="~/Images/skype.png" Visible="False" meta:resourcekey="ImgSkypeTextResource1" />
                                </td>
                                <td width="5%">
                                    <asp:ImageButton ID="ImgMSNText" runat="server" ToolTip='<%# Bind("MSNId") %>' ImageUrl="~/Images/msn.png"
                                        Visible="False" meta:resourcekey="ImgMSNTextResource1" />
                                </td>
                                <td width="40%">
                                </td>
                                <td width="10%" align="right">
                                    <asp:LinkButton ID="hnkMore" runat="server" Text="View Full List..." CommandName="More"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "userId") %>' ForeColor="#fc0505"
                                        meta:resourceKey="hnkMoreResource3"></asp:LinkButton>
                                </td>
                                <td width="10%" align="right">
                                    <asp:Label ID="lblRecords" runat="server" Text="Total Records:" Font-Bold="True"
                                        Font-Italic="True" meta:resourcekey="lblRecordsResource1"></asp:Label>
                                </td>
                                <td width="5%" align="left">
                                    <asp:Label ID="lblTotalItems" runat="server" Text='<%# Bind("TotalItems") %>' meta:resourcekey="lblTotalItemsResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10">
                                    <asp:Label ID="lblCityText" runat="server" Text="City:" Font-Bold="True" Font-Italic="True"
                                        meta:resourcekey="lblCityTextResource1"></asp:Label>
                                    <asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>' meta:resourcekey="lblCityResource1"></asp:Label>
                                    <asp:Label ID="lblCountryText" runat="server" Text="Country:" Font-Bold="True" Font-Italic="True"
                                        meta:resourcekey="lblCountryTextResource1"></asp:Label>
                                    <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>' meta:resourcekey="lblCountryResource1"></asp:Label>
                                    <asp:Label ID="lblTelText" runat="server" Text="Tel #:" Font-Bold="True" Font-Italic="True"
                                        meta:resourcekey="lblTelTextResource1"></asp:Label>
                                    <asp:Label ID="lblTel" runat="server" Text='<%# Bind("LandLine") %>' meta:resourcekey="lblTelResource1"></asp:Label>
                                    <asp:Label ID="lblEmailText" runat="server" Text="Email:" Font-Bold="True" Font-Italic="True"
                                        meta:resourcekey="lblEmailTextResource1"></asp:Label>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("EmaiId") %>' meta:resourcekey="lblEmailResource1"></asp:Label>
                                    <asp:Button ID="btnquote" runat="server" Text='Quote' CommandName="button" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "userId") %>' />
                                </td>
                            </tr>
                        </table>
                        <table width="100%">
                            <tr>
                                <td style="width: 100%" class="grid">
                                    <asp:GridView ID="grdRequirementWithPO" runat="server" AutoGenerateColumns="False"
                                        DataSource='<%# Eval("BuyersRequirement") %>' Width="100%" CssClass="table-border"
                                        OnRowDataBound="grdRequirementWithPO_RowDataBound" OnRowCommand="grdRequirementWithPO_RowCommand"
                                        AllowPaging="True" meta:resourcekey="grdRequirementWithPOResource1">
                                        <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="UserID" Visible="False" meta:resourcekey="TemplateFieldResource1">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserId" runat="server" Text='<%# Bind("UserId") %>' meta:resourcekey="lblUserIdResource1"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Part #" SortExpression="BuyerName" meta:resourcekey="TemplateFieldResource2">
                                                <HeaderStyle Width="20%" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkComponentName" runat="server" Text='<%# Bind("ComponentName") %>'
                                                        CommandName="Select" meta:resourcekey="lnkComponentNameResource1"></asp:LinkButton>
                                                 <%--   <asp:HyperLink ID="hlComponentName" Text='<%# Bind("ComponentName") %>' runat="server"
                                                        ToolTip="Click to view Datasheet" ImageUrl="~/Images/pdf.png" BorderStyle="None"
                                                        NavigateUrl='<%# Eval("ComponentName", "http://www.alldatasheet.com/view.jsp?Searchword={0}") %>'
                                                        Target="_blank" meta:resourcekey="hlComponentNameResource1"></asp:HyperLink>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Quantity" HeaderText="Qty" meta:resourcekey="BoundFieldResource1">
                                                <HeaderStyle Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BrandName" HeaderText="Make" meta:resourcekey="BoundFieldResource2">
                                                <HeaderStyle Width="8%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DateCode" HeaderText="Date Code" meta:resourcekey="BoundFieldResource3">
                                                <HeaderStyle Width="8%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Package" HeaderText="Package" meta:resourcekey="BoundFieldResource4">
                                                <HeaderStyle Width="8%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PriceInUSD" HeaderText="Unit Price In USD" meta:resourcekey="BoundFieldResource5">
                                                <HeaderStyle Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Description" HeaderText="Comment" meta:resourcekey="BoundFieldResource6">
                                                <HeaderStyle Width="20%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Updated On" SortExpression="ModifiedDate" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblModifiedOn" runat="server" Text='<%# Bind("ModifiedDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <%-- <asp:BoundField DataField="ModifiedDate" DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}"
                                                HeaderText="Updated On" meta:resourcekey="BoundFieldResource7">
                                                <HeaderStyle Width="10%" />
                                            </asp:BoundField>--%>
                                        </Columns>
                                        <PagerSettings Visible="False" />
                                        <RowStyle CssClass="odd" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
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
        </asp:Panel>
    </div>
</asp:Content>
