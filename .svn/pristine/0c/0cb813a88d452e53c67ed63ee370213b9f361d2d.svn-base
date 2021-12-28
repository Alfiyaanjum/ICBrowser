<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Favourites.aspx.cs"
    Inherits="ICBrowser.Web.Favourites" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function confirmDelete(source, args) {
            if (confirm('Are you sure you want to delete ?')) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
            return;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />
    <div id="chart_bg">
        <div class="chart_heading">
            <asp:Label ID="lblHeader" runat="server" Text="Favourites:-" meta:resourcekey="lblHeaderResource1"></asp:Label>
        </div>
        <div class="grid">
            <asp:GridView ID="favDetails" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="even"
                AllowPaging="true" RowStyle-CssClass="odd" Width="100%" OnRowCommand="favDetails_RowCommand"
                OnRowDeleting="favDetails_RowDeleting" meta:resourcekey="favDetailsResource1"
                CssClass="table-border">
                <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                <Columns>
                    <asp:TemplateField HeaderText="FavouritesID" Visible="false" meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFavId" runat="server" Text='<%# Bind("FavouritesID") %>' meta:resourcekey="lnkFavIdResource1"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="userid" SortExpression="userid" Visible="false" meta:resourcekey="TemplateFieldResource2">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkuserid" runat="server" Text='<%# Bind("FavUserID") %>' meta:resourcekey="lnkBuyerIdResource1"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="SellerId" SortExpression="SellerId" Visible="false"
                        meta:resourcekey="TemplateFieldResource4">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSellerId" runat="server" Text='<%# Bind("FavUserID") %>' meta:resourcekey="lnkSellerIdResource1"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Favourite" SortExpression="Favourite" meta:resourcekey="TemplateFieldResource3">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkBuyer" runat="server" CommandName="btn" Text='<%# Bind("CompanyName") %>'
                                meta:resourcekey="lnkBuyerResource1"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="SellerId" SortExpression="SellerId" Visible="false"
                        meta:resourcekey="TemplateFieldResource4"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Favourite" SortExpression="Favourite of Seller" meta:resourcekey="TemplateFieldResource5">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSeller" runat="server" CommandName="btn" Text='<%# Bind("CompanyName") %>'
                                meta:resourcekey="lnkSellerResource1"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="AddedOn" HeaderText="Added On" SortExpression="AddedOn"
                        DataFormatString="{0:dd-MMM-yyyy}" meta:resourcekey="BoundFieldResource1" />
                    <asp:TemplateField HeaderText="Delete" meta:resourcekey="TemplateFieldResource6">
                        <ItemTemplate>
                            <%--<asp:ImageButton runat="server" ID="imgbtnDelete" CssClass="blue_button" CommandName="Delete"
                                ToolTip="Delete" ValidationGroup="deleteConfirmation" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FavouritesID") %>'
                                meta:resourcekey="imgbtnDeleteResource1" />--%>
                            <asp:Button runat="server" ID="btndelete" CssClass="blue_button" CommandName="Delete"
                                Text="Delete" ToolTip="Delete" ValidationGroup="deleteConfirmation" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FavouritesID") %>'
                                meta:resourcekey="btnDeleteResource1" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="odd"></RowStyle>
                <EmptyDataTemplate>
                    <table style="background-color: #EEF0F6" width="100%" border="0" cellpadding="0"
                        cellspacing="0">
                        <tr>
                            <td colspan="2" class="errormsg" style="height: 100px" align="center">
                                No record found !
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            </asp:GridView>
            <asp:CustomValidator ID="CustomValidator1" ClientValidationFunction="confirmDelete"
                ValidationGroup="deleteConfirmation" runat="server" meta:resourcekey="CustomValidator1Resource1"></asp:CustomValidator>
        </div>
    </div>
</asp:Content>
