<%@ Page Language="C#" Title="ICBrowser.com buy and sell electronic components" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdvertPanel.aspx.cs"
    Inherits="ICBrowser.Web.AdvertPanel" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<head id="Head1" runat="server">--%>
    <%--<script type="text/javascript" src="Scripts/jquery-1.6.min.js">
    </script>--%>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.5/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <!--<script type="text/javascript" src="/js/common.js"></script>-->
    <script src="Scripts/jquery.simplyscroll.js" type="text/javascript"></script>
    <link rel="stylesheet" href="Styles/jquery.simplyscroll.css" media="all" type="text/css" />
    <script type="text/javascript">
        (function ($) {
            $(function () {
                $("#scroller").simplyScroll({ orientation: 'vertical', direction: 'backwards', customClass: 'vert' });
            });
        })(jQuery);
    </script>
    <title></title>
    <style type="text/css">
        #scroller
        {
            width: 232px;
            height: 506px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 76px; width: 934px;" id="top" runat="server">
        <table style="height: 76px; width: 902px;">
            <tr>
                <td class="style1">
                    &nbsp;&nbsp;&nbsp;ICBrowser
                </td>
                <td>
                    <asp:ImageButton ID="imgbtnAd1" runat="server" Height="72px" Width="833px" CausesValidation="false"
                        OnClick="imgbtnAd1_Click1" />
                </td>
            </tr>
        </table>
    </div>
    <div style="height: 500px; margin-left: 700px; width: 201px;" id="right" runat="server">
        <table id="scroller">
            <asp:Repeater runat="server" ID="rptrAdvertisements">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a id="ancAd" href='<%#Eval("RedirectUrl")%>' runat="server" target="_blank">
                                <img id="imgbtnAd2" runat="server" src='<%#Eval("ImageUrl")%>' title='<%#Eval("Text")%>'
                                    alt="" height="100" width="200" />
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div style="height: 107px" id="bottom" runat="server">
        <asp:ImageButton ID="imgbtnAd7" runat="server" Height="100px" Width="902px" OnClick="imgbtnAd7_Click7"
            CausesValidation="false" />
    </div>
</asp:Content>
