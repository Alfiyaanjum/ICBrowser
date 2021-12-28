<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RightPanel.ascx.cs"
    Inherits="ICBrowser.Web.RightPanel" %>
<div style="vertical-align: middle; text-align: center;">
    <table id="scroller">
        <asp:Repeater runat="server" ID="rptrAdvertisements">
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <a id="ancAd" href='<%# Eval("RedirectUrl") %>' runat="server" target="_blank">
                            <asp:Image ID="imgbtnAd2" runat="server" ToolTip='<%# Eval("Text") %>' ImageUrl='<%# Eval("ImageUrl") %>'
                                Height="200" Width="270" />
                            &nbsp;</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</div>
