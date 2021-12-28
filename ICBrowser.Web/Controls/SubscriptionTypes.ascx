<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubscriptionTypes.ascx.cs"
    Inherits="ICBrowser.Web.Controls.SubscriptionTypes" %>
<div id="grid">
    <div>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
            RepeatDirection="Horizontal" meta:resourcekey="RadioButtonList1Resource1" >
            <asp:ListItem Text="Trail" Value="0" Selected="True" 
                meta:resourcekey="ListItemResource1"></asp:ListItem>
            <asp:ListItem Text="Silver" Value="1" meta:resourcekey="ListItemResource2"></asp:ListItem>
            <asp:ListItem Text="Gold" Value="2" meta:resourcekey="ListItemResource3"></asp:ListItem>
            <asp:ListItem Text="Platinum" Value="3" meta:resourcekey="ListItemResource4"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div>
        <asp:Label ID="lblMembershipFeatures" runat="server" 
            meta:resourcekey="lblMembershipFeaturesResource1" ></asp:Label>
    </div>
</div>
