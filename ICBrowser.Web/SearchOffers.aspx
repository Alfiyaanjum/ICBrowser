<%@ Page Title="" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="SearchOffers.aspx.cs" Inherits="ICBrowser.Web.SearchOffers" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ MasterType VirtualPath="~/Detail.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding: 0px 5px 0px 5px" class="chart_heading">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSearchResultFor" runat="server" Text="Offers Search Results for: "
                        Font-Bold="True" meta:resourcekey="lblSearchResultForResource1"></asp:Label>
                    <asp:Label ID="lblSearchText" runat="server" ForeColor="BlueViolet" meta:resourcekey="lblSearchTextResource1"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="grid" style="padding: 0px 5px 0px 5px;">
        <asp:GridView ID="grvOfferSearch" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="even"
            RowStyle-CssClass="odd" AllowPaging="True" GridLines="Horizontal" Width="100%"
            PageSize="20" OnPageIndexChanging="grvOfferSearch_PageIndexChanging" OnRowDataBound="grvOfferSearch_RowDataBound"
            OnRowCommand="grvOfferSearch_RowCommand" CssClass="table-border">
            <Columns>
                <asp:TemplateField HeaderText="Part #" HeaderStyle-CssClass="search-th">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkComponentName" runat="server" CommandName="Select" Text='<%# Bind("ComponentName") %>'
                            Visible="False"></asp:LinkButton>
                        <asp:Label ID="LblComponentname" runat="server" Text='<%# Bind("ComponentName") %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="hlComponentName" Text='<%# Bind("ComponentName") %>' runat="server"
                            ImageUrl="~/Images/pdf.png" NavigateUrl='<%# Eval("ComponentName", "http://www.alldatasheet.com/view.jsp?Searchword={0}") %>'
                            Target="_blank"></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle CssClass="search-th"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty" HeaderStyle-CssClass="search-th">
                    <ItemTemplate>
                        <asp:Label ID="LblQuantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Make" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource3">
                    <ItemTemplate>
                        <asp:Label ID="LblBrandName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Brandname") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Stock In Hand" meta:resourcekey="TemplateFieldResource4"
                    HeaderStyle-CssClass="search-th">
                    <ItemTemplate>
                        <asp:Label ID="lblStockInHand" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StockInHand") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Comment" HeaderStyle-CssClass="search-th">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit Price in USD" HeaderStyle-CssClass="search-th">
                    <ItemTemplate>
                        <asp:Label ID="lblPriceInUSD" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PriceInUSD") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Updated" meta:resourcekey="TemplateFieldResource8"
                    HeaderStyle-CssClass="search-th">
                    <ItemTemplate>
                        <asp:Label ID="lblLastUpdated" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ModifiedOn","{0:dd-MMM-yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company Name" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource9">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlCompanyName" runat="server" Target="_self" Text='<%# Bind("CompanyName") %>'
                            NavigateUrl='<%# Eval("userId", "~/UserProfile.aspx?UserId={0}") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DateCode" HeaderStyle-CssClass="search-th">
                    <ItemTemplate>
                        <asp:Label ID="lblDateCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "datecode") %>'
                            meta:resourcekey="lblDateCodeResource1"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Package" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource11">
                    <ItemTemplate>
                        <asp:Label ID="lblPackage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "package") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stock Status" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource12">
                    <ItemTemplate>
                        <asp:Label ID="lblStockStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "stockstatus") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Country" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource13">
                    <ItemTemplate>
                        <asp:Label ID="lblCountry" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "country") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>--%>
            </Columns>
            <EmptyDataTemplate>
                <table style="background-color: #EEF0F6" width="100%" border="0" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td colspan="2" class="errormsg" style="height: 100px" align="center">
                            No records found !
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            <RowStyle CssClass="odd"></RowStyle>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
        </asp:GridView>
    </div>
</asp:Content>
