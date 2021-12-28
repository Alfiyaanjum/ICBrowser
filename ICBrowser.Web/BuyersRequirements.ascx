<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuyersRequirements.ascx.cs"
    Inherits="ICBrowser.Web.BuyersRequirements" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="Styles/main.css" rel="stylesheet" type="text/css" />
<%--<div style="float:left;">--%>
<div id="chart_bg">
    <div class="chart_heading">
        <asp:Label ID="lblHeader" runat="server" Text="Latest Requirements:-" meta:resourcekey="lblHeaderResource1"
            CssClass="buyer-heading" Font-Underline="True"></asp:Label>
    </div>
    <div class="grid">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="even"
            RowStyle-CssClass="odd" Width="100%" OnRowCommand="GridView1_RowCommand" meta:resourcekey="GridView1Resource1"
            OnRowDataBound="GridView1_RowDataBound" CssClass="table-border">
            <Columns>
                <asp:TemplateField HeaderText="UserId" SortExpression="UserId" Visible="false" meta:resourcekey="TemplateFieldResource1">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkUserId" runat="server" Text='<%# Bind("UserId") %>' meta:resourcekey="lnkUserIdResource1"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="P/N" SortExpression="ComponentName" meta:resourcekey="TemplateFieldResource2">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnk" runat="server" CommandName="btn" Text='<%# Bind("ComponentName") %>'
                            meta:resourcekey="lnkResource1" Visible="False"></asp:LinkButton>
                        <asp:Label ID="lblpartn" runat="server" Text='<%# Bind("ComponentName") %>' Visible="False"
                            meta:resourcekey="lblpartnResource1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Quantity" HeaderText="QUANTITY" SortExpression="Quantity"
                    meta:resourcekey="BoundFieldResource1" />
                <asp:BoundField DataField="BrandName" HeaderText="MAKE" SortExpression="BrandName"
                    meta:resourcekey="BoundFieldResource2" />
                <asp:BoundField DataField="DateCode" HeaderText="DATE-CODE" SortExpression="DateCode"
                    meta:resourcekey="BoundFieldResource6" />
                <asp:BoundField DataField="Package" HeaderText="PACKAGE" SortExpression="Package"
                    meta:resourcekey="BoundFieldResource4" />
                <asp:BoundField DataField="Description" HeaderText="COMMENT" 
                    SortExpression="Description" meta:resourcekey="BoundFieldResource3" />
            </Columns>
            <HeaderStyle CssClass="buyer-th" />
            <RowStyle CssClass="odd"></RowStyle>
            <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
        </asp:GridView>
    </div>
</div>
