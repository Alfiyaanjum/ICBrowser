<%@ Page Title="" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="RequirementSearchResult.aspx.cs" Inherits="ICBrowser.Web.RequirementSearchResult"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ MasterType VirtualPath="~/Detail.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="padding: 0px 5px 0px 5px" class="chart_heading">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Requirement Search Results for: " Font-Bold="True"
                            meta:resourcekey="Label1Resource1"></asp:Label>
                        <asp:Label ID="Label2" runat="server" ForeColor="BlueViolet" meta:resourcekey="Label2Resource1"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="padding: 0px 5px 0px 5px;" id="grid">
            <asp:GridView ID="grdReqSearchResults" runat="server" AutoGenerateColumns="False"
                ClientIDMode="Static" AlternatingRowStyle-CssClass="even" RowStyle-CssClass="odd"
                AllowPaging="True" OnPageIndexChanging="grdReqSearchResults_PageIndexChanging"
                OnRowCommand="grdReqSearchResults_RowCommand" PageSize="24" Font-Names="Arial"
                Width="100%" OnRowDataBound="grdReqSearchResults_RowDataBound" CssClass="table-border"
                meta:resourcekey="grdReqSearchResultsResource1">
                <Columns>
                    <asp:TemplateField HeaderText="User Id" SortExpression="UserId" Visible="false" meta:resourcekey="TemplateFieldResource9">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSellerId" runat="server" Text='<%# Bind("UserId") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Part #" HeaderStyle-CssClass="search-th">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkComponentName" runat="server" Text='<%# Bind("ComponentName") %>'
                                CommandName="Select" meta:resourceKey="lnkComponentNameResource1" Visible="false"></asp:LinkButton>
                            <asp:Label ID="LblComponentname" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentName") %>'></asp:Label>
                            <asp:HyperLink ID="hlCompName" Text='<%# Bind("ComponentName") %>' runat="server"
                                ImageUrl="~/Images/pdf.png" NavigateUrl='<%# Eval("ComponentName", "http://www.alldatasheet.com/view.jsp?Searchword={0}") %>'
                                Target="_blank"></asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
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
                    <asp:TemplateField HeaderText="Company Name" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource4">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlCompanyName" runat="server" Target="_self" Text='<%# Bind("BuyerName") %>'
                                NavigateUrl='<%# Eval("userId", "~/UserProfile.aspx?UserId={0}") %>'>
                            </asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Updated" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource5">
                        <ItemTemplate>
                            <asp:Label ID="lblLastUpdated" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"modifiedDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="d/c" HeaderStyle-CssClass="search-th">
                        <ItemTemplate>
                            <asp:Label ID="lblDateCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateCode") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Package" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource7">
                        <ItemTemplate>
                            <asp:Label ID="lblPackage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Package") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Country" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource8">
                        <ItemTemplate>
                            <asp:Label ID="lblCountry" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Country") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="PO/RFQ" HeaderStyle-CssClass="search-th">
                        <ItemTemplate>
                            <asp:Label ID="lblWithPO" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RequirementwithPO") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price In USD" SortExpression="PriceInUSD">
                        <ItemTemplate>
                            <asp:Label ID="lblPriceInUSD" runat="server" Text='<%# Bind("PriceInUSD") %>' meta:resourcekey="lblPriceInUSDResource1"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comment" HeaderStyle-CssClass="search-th">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
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
    </div>
</asp:Content>
