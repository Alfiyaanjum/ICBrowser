<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCurrencyExchangeRate.ascx.cs"
    Inherits="ICBrowser.Web.Controls.ucCurrencyExchangeRate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div>
    <%-- <div class="chart_heading">
        <asp:Label ID="lblExRateHeader" runat="server" Text="Today's Exchange Rate"></asp:Label>
    </div>--%>
    <div class="grid">
        <asp:GridView ID="gvExchangeRate" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="even"
            RowStyle-CssClass="odd" Width="100%" CssClass="table-border" 
            meta:resourcekey="gvExchangeRateResource1">
            <Columns>
                <asp:BoundField DataField="ForeignCurrency" HeaderText="Currency" 
                    SortExpression="ForeignCurrency" meta:resourcekey="BoundFieldResource1" />
                <asp:BoundField DataField="ExchangeRate" HeaderText="in INR" 
                    SortExpression="ExchangeRate" meta:resourcekey="BoundFieldResource2" />
            </Columns>
            <RowStyle CssClass="odd"></RowStyle>
            <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
        </asp:GridView>
    </div>
</div>
