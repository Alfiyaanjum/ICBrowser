<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="gvSellerInventoryListing.ascx.cs"
    Inherits="ICBrowser.Web.gvSellerInventoryListing" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="../Styles/main.css" rel="stylesheet" type="text/css" />
<div id="chart_bg">
    <div class="chart_heading" style="background-color: #8BBDE2; padding-left: 5px; font-weight: bold;
        color: #036;">
        <asp:Label ID="lblHeader" runat="server" Text="Latest Offers" meta:resourcekey="lblHeaderResource2"></asp:Label>
    </div>
    <div class="grid">
        <asp:Panel ID="Panel1" runat="server" Height="210px" ScrollBars="Vertical">
            <asp:GridView ID="gvSellerInvList" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="even"
                RowStyle-CssClass="odd" Width="100%" OnRowCommand="gvSellerInvList_RowCommand"
                CssClass="table-border" OnRowDataBound="gvSellerInvList_RowDataBound" meta:resourcekey="gvSellerInvListResource1">
                <HeaderStyle CssClass="seller-th" />
                <RowStyle CssClass="odd"></RowStyle>
                <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                <Columns>
                    <asp:TemplateField HeaderText="User Id" SortExpression="UserId" Visible="false" meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSellerId" runat="server" CommandName="btn" Text='<%# Bind("UserId") %>'
                                meta:resourcekey="lnkSellerIdResource1"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Part #" SortExpression="ComponentName" meta:resourcekey="TemplateFieldResource2">
                        <HeaderStyle Width="200" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnk" runat="server" CommandName="btn" Text='<%# Bind("ComponentName") %>'
                                Visible="False"></asp:LinkButton>
                            <asp:Label ID="lblpartn" runat="server" Text='<%# Bind("ComponentName") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity" meta:resourcekey="TemplateFieldResource4">
                        <HeaderStyle Width="200" />
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>' meta:resourcekey="lblQuantityResource1"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Make" SortExpression="BrandName" meta:resourcekey="TemplateFieldResource5">
                        <HeaderStyle Width="200" />
                        <ItemTemplate>
                            <asp:Label ID="lblBrandName" runat="server" Text='<%# Bind("BrandName") %>' meta:resourcekey="lblBrandNameResource1"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Code" SortExpression="datecode" meta:resourcekey="TemplateFieldResource7">
                        <HeaderStyle Width="200" />
                        <ItemTemplate>
                            <asp:Label ID="lblDateCode" Text='<%# Bind("Datecode") %>' runat="server" meta:resourcekey="lblDateCodeResource1"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Package" SortExpression="Package" meta:resourcekey="TemplateFieldResource8">
                        <HeaderStyle Width="200" />
                        <ItemTemplate>
                            <asp:Label ID="lblPkg" Text='<%# Bind("package") %>' runat="server" meta:resourcekey="lblPkgResource1"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comment" SortExpression="Description " meta:resourcekey="TemplateFieldResource9">
                        <HeaderStyle Width="200" />
                        <ItemTemplate>
                            <asp:Label ID="lbldescription" runat="server" Text='<%# Bind("Description") %>' meta:resourcekey="lbldescriptionResource1"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="odd"></RowStyle>
            </asp:GridView>
        </asp:Panel>
    </div>
</div>
