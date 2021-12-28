<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuyersRequirements.ascx.cs"
    Inherits="ICBrowser.Web.Controls.BuyersRequirements" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="../Styles/main.css" rel="stylesheet" type="text/css" />
<%--<div style="float:left;">--%>
<div id="chart_bg">
    <div class="chart_heading" style="background-color: #8BBDE2;">
        <asp:Label ID="lblHeader" runat="server" Text="Latest Requirements" CssClass="buyer-heading"
            meta:resourcekey="lblHeaderResource1"></asp:Label>
    </div>
    <div class="grid">
        <asp:Panel ID="Panel1" runat="server" Height="210px" ScrollBars="Vertical">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="even"
                RowStyle-CssClass="odd" Width="100%" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                CssClass="table-border" meta:resourcekey="GridView1Resource1">
                <Columns>
                    <asp:TemplateField HeaderText="UserId" SortExpression="UserId" Visible="false" meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkUserId" runat="server" Text='<%# Bind("UserId") %>' meta:resourcekey="lnkUserIdResource1"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Part #" SortExpression="ComponentName" meta:resourcekey="TemplateFieldResource2">
                        <HeaderStyle Width="200" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnk" runat="server" CommandName="btn" Text='<%# Bind("ComponentName") %>'
                                Visible="False" meta:resourcekey="lnkResource1"></asp:LinkButton>
                            <asp:Label ID="lblpartn" runat="server" Text='<%# Bind("ComponentName") %>' Visible="False"
                                meta:resourcekey="lblpartnResource1"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"
                        meta:resourcekey="BoundFieldResource1">
                        <HeaderStyle Width="200" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BrandName" HeaderText="Make" SortExpression="BrandName"
                        meta:resourcekey="BoundFieldResource2">
                        <HeaderStyle Width="200" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DateCode" HeaderText="Date Code" SortExpression="DateCode"
                        meta:resourcekey="BoundFieldResource3">
                        <HeaderStyle Width="200" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Package" HeaderText="Package" SortExpression="Package"
                        meta:resourcekey="BoundFieldResource4">
                        <HeaderStyle Width="200" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Comment" SortExpression="Description"
                        meta:resourcekey="BoundFieldResource5">
                        <HeaderStyle Width="200" />
                    </asp:BoundField>
                </Columns>
                <HeaderStyle CssClass="buyer-th" />
                <RowStyle CssClass="odd"></RowStyle>
                <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
            </asp:GridView>
        </asp:Panel>
    </div>
</div>
