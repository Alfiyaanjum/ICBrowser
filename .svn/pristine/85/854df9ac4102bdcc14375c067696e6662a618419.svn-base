<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SearchResults.aspx.cs" Inherits="ICBrowser.Web.SearchResults" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="headerback">
        <asp:Label ID="Label1" runat="server" Text="Component Search Results for: " CssClass="header"
            meta:resourcekey="Label1Resource1"></asp:Label>
        <asp:Label ID="lblParttosearch" runat="server" ForeColor="BlueViolet" Font-Bold="true"
            Font-Size="Medium" meta:resourcekey="lblParttosearchResource1"></asp:Label>
    </div>
    <div style="padding: 0px 0px 0px 0px;" id="grid">
        <asp:GridView ID="grdSearchResults" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="even"
            RowStyle-CssClass="odd" AllowPaging="True" GridLines="Horizontal" OnPageIndexChanging="grdSearchResults_PageIndexChanging"
            Font-Names="Arial" Width="100%" PageSize="20" OnRowDataBound="grdSearchResults_RowDataBound"
            DataKeyNames="isOffer" CssClass="table-border" OnRowCommand="grdSearchResults_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="User Id" SortExpression="UserId" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkUserId" runat="server" CommandName="Select" Text='<%# Bind("UserId") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Part #" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource20">
                    <HeaderStyle Width="15%" />
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkComponentName" Text='<%# Bind("ComponentName") %>' runat="server"
                            Visible="false" CommandName="Select"></asp:LinkButton>
                        <asp:Label ID="LblComponentname" runat="server" Text='<%# Bind("ComponentName") %>'
                            Visible="false"></asp:Label>
                        <asp:HyperLink ID="hlComponentName" Text='<%# Bind("ComponentName") %>' runat="server"
                            ToolTip="Click to view Datasheet" ImageUrl="~/Images/pdf.png" NavigateUrl='<%# Eval("ComponentName", "http://www.alldatasheet.com/view.jsp?Searchword={0}") %>'
                            Target="_blank"></asp:HyperLink>
                        <asp:Image ID="imgHotOffer" runat="server" ImageUrl="~/Images/hot.gif" Visible="false" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource21">
                    <HeaderStyle Width="8%" />
                    <ItemTemplate>
                        <asp:Label ID="LblQuantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Make" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource3">
                    <HeaderStyle Width="8%" />
                    <ItemTemplate>
                        <asp:Label ID="LblBrandName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Brandname") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit Price in USD" HeaderStyle-CssClass="search-th"
                    meta:resourcekey="TemplateFieldResource22">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPriceInUSD" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PriceInUSD") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company Name" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource9">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:HyperLink ID="hlCompanyName" runat="server" Target="_blank" Text='<%# Bind("CompanyName") %>'
                            NavigateUrl='<%# Eval("userId", "~/NewUserProfile.aspx?UserId={0}") %>' Visible="false">
                        </asp:HyperLink>
                        <asp:Label ID="lblCompanyName" runat="server" Text='<%# Bind("CompanyName") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date Code" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource23">
                    <HeaderStyle Width="8%" />
                    <ItemTemplate>
                        <asp:Label ID="lblDateCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "datecode") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Package" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource11">
                    <HeaderStyle Width="8%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPackage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "package") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Comment" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource24">
                    <HeaderStyle Width="15%" />
                    <ItemTemplate>
                        <asp:Label ID="lbldescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stock Status" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource12">
                    <HeaderStyle Width="8%" />
                    <ItemTemplate>
                        <asp:Label ID="lblStockStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "stockstatus") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Updated" meta:resourcekey="TemplateFieldResource8"
                    HeaderStyle-CssClass="search-th">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblLastUpdated" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ModifiedOn","{0:dd-MMM-yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IsOffer" HeaderStyle-CssClass="search-th" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblIsOffer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"IsOffer") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
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
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            <RowStyle CssClass="odd"></RowStyle>
            <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
            <PagerStyle CssClass="headerback" HorizontalAlign="Center" />
        </asp:GridView>
    </div>
</asp:Content>
