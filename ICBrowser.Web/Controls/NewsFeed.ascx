<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsFeed.ascx.cs" Inherits="ICBrowser.Web.NewsFeed" %>
<div style="width: 100%">
      <marquee behavior="scroll" direction="down" onmouseover="this.stop();" onmouseout="this.start();" scrolldelay="20" scrollamount="1" height="120px" white-space: "nowrap">
      <asp:Repeater ID="rssRepeater" runat="server">
                <ItemTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td style="font-weight: bold">
                                <asp:HyperLink ID="hyplink" runat="server" NavigateUrl='<%#Eval("link")%>' Target="_blank"
                                    Text='<%#Eval("title")%>' Font-Bold="true" Font-Size="14px"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #C0C0C0; font-size: small" align="left">
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("pubdate")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <hr />
                </ItemTemplate>
            </asp:Repeater>
      </marquee>      
</div>
