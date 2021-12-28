<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="MoreDetails.aspx.cs" Inherits="ICBrowser.Web.MoreDetails"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="headerback">
        <asp:Label ID="lblHeading" runat="server" CssClass="header" meta:resourcekey="lblHeadingResource1"></asp:Label>
        <div style="float: right">
            <asp:Button ID="btnback" runat="server" Text="Close" Visible="true" CssClass="blue_button"
                OnClick="btnback_Click" meta:resourcekey="btnbackResource1" />
        </div>
    </div>
    <div class="grid" style="background-color: #B3CFE2">
        <span style="padding: 5px">
            <asp:LinkButton ID="hnkCompanyName" runat="server" meta:resourceKey="hnkCompanyNameResource3"
                Font-Bold="True" Font-Size="Medium" OnClick="hnkCompanyName_Click"> </asp:LinkButton>
            <asp:Button ID="btnquote" runat="server" Text='' OnClick="btnquote_Click"/>
        </span>
        <%-- <asp:HyperLink ID="hnkCompanyName" runat="server" Font-Size="Medium" Font-Bold="True"
             ForeColor="#505EAD" NavigateUrl='<%# Eval("UserId", "../NewUserProfile.aspx?UserId={0}") %>'
            Target="_blank" meta:resourceKey="hnkCompanyNameResource3">[hnkCompanyName]</asp:HyperLink>--%>
        <asp:GridView ID="gvBuyrListng" runat="server" AutoGenerateColumns="False" Width="100%"
            PageSize="20" HorizontalAlign="Center" meta:resourcekey="gvBuyrListngResource1"
            CssClass="table-border" AllowPaging="True" OnPageIndexChanging="gvBuyrListng_PageIndexChanging"
            OnRowCommand="gvBuyrListng_RowCommand" OnRowDataBound="gvBuyrListng_RowDataBound"
            BorderColor="#B3CFE2">
            <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField HeaderText="User Id" SortExpression="UserId" Visible="false" meta:resourcekey="TemplateFieldResource9">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkSellerId" runat="server" Text='<%# Bind("UserId") %>' meta:resourcekey="lnkSellerIdResource1"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Part #" SortExpression="BuyerName" meta:resourcekey="TemplateFieldResource1">
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkComponentName" runat="server" Text='<%# Bind("ComponentName") %>'
                            CommandName="Select" meta:resourceKey="lnkComponentNameResource1"></asp:LinkButton>
                        <asp:HyperLink ID="hlComponentName" Text='<%# Bind("ComponentName") %>' runat="server"
                            ToolTip="Click to view Datasheet" ImageUrl="~/Images/pdf.png" BorderStyle="None"
                            NavigateUrl='<%# Eval("ComponentName", "http://www.alldatasheet.com/view.jsp?Searchword={0}") %>'
                            Target="_blank" meta:resourcekey="hlComponentNameResource1"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty" SortExpression="Quantity" meta:resourcekey="TemplateFieldResource2">
                    <HeaderStyle Width="8%" />
                    <ItemTemplate>
                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>' meta:resourcekey="lblQuantityResource1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stock Status" meta:resourcekey="TemplateFieldResource4">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblstockstatus" runat="server" Text='<%# Bind("StockStatus") %>' meta:resourcekey="lblstockstatusResource1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Make" SortExpression="Brand Name" meta:resourcekey="TemplateFieldResource5">
                    <HeaderStyle Width="8%" />
                    <ItemTemplate>
                        <asp:Label ID="lblBrandName" runat="server" Text='<%# Bind("BrandName") %>' meta:resourcekey="lblBrandNameResource1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date Code" meta:resourcekey="TemplateFieldResource3">
                    <HeaderStyle Width="8%" />
                    <ItemTemplate>
                        <asp:Label ID="lblDateCode" runat="server" Text='<%# Bind("DateCode") %>' meta:resourcekey="lblDateCodeResource1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="Package" HeaderText="Package" SortExpression="Package">
                    <HeaderStyle Width="8%" />
                </asp:BoundField>--%>
                <asp:TemplateField HeaderText="Package" SortExpression="Package">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPackage" runat="server" Text='<%# Bind("Package") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="PO/RFQ" meta:resourcekey="TemplateFieldResource6"
                    Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblRequirementwithPO" runat="server" Text='<%# Bind("RequirementwithPO") %>'
                            meta:resourcekey="RequirementwithPOResource1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price In USD" SortExpression="PriceInUSD" meta:resourcekey="TemplateFieldResource7">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lblPriceInUSD" runat="server" Text='<%# Bind("PriceInUSD") %>' meta:resourcekey="lblPriceInUSDResource1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Comment" meta:resourcekey="TemplateFieldResource8">
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <asp:Label ID="lbldescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'
                            meta:resourcekey="lbldescriptionResource1"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="ModifiedDate" DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}"
                    HeaderText="Updated Date" meta:resourcekey="BoundFieldResource1">
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="ModifiedOn" DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}"
                    HeaderText="Updated On" meta:resourcekey="BoundFieldResource2">
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
            </Columns>
            <PagerStyle HorizontalAlign="Center" />
            <RowStyle CssClass="odd" />
        </asp:GridView>
    </div>
</asp:Content>
