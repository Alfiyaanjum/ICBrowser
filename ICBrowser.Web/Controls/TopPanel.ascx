<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopPanel.ascx.cs" Inherits="ICBrowser.Web.TopPanel" %>
<div align="center" style="height: 150px;" id="topAd" runat="server">
<table cellspacing="0" cellpadding="0" width="100%"><tr><td>
    <asp:ImageButton ID="imgbtnAd1" runat="server" CausesValidation="False"
        OnClick="imgbtnAd1_Click1" height="150px" width="100%" 
        meta:resourcekey="imgbtnAd1Resource1" /></td><td width="10px" ></td><td>
     <asp:ImageButton ID="imgbtnAd2" runat="server" CausesValidation="False"
        OnClick="imgbtnAd2_Click2" height="150px" width="100%" 
         meta:resourcekey="imgbtnAd2Resource1"/></td></tr>
        </table>
</div>
