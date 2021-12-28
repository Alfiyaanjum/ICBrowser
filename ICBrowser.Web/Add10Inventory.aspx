<%@ Page Title="" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="Add10Inventory.aspx.cs" Inherits="ICBrowser.Web.Add10Inventory" %>

<%@ MasterType VirtualPath="~/Detail.Master" %>
<%@ Register Src="Controls/AddInventory.ascx" TagName="AddInventory" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/main.css" rel="stylesheet" type="text/css" />
    <div style="overflow: scroll; height: 535px; width: 975px">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="hidden_rptr_ControlCount" runat="server"></asp:HiddenField>
        <table border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" align="center">
                    <%--<asp:UpdatePanel ID="upnlAddInventory" runat="server">--%>
                        <%--<ContentTemplate>--%>
                            <asp:Repeater ID="rptAddInventory" runat="server" OnItemCommand="rptAddInventory_ItemCommand">
                                <ItemTemplate>
                                    <uc1:AddInventory ID="ctrlAddInventory" runat="server" Data='<%# Container.DataItem  %>' />
                                </ItemTemplate>
                            </asp:Repeater>
                        <%--</ContentTemplate>--%>
                    <%--</asp:UpdatePanel>--%>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnSave" runat="server" CssClass="blue_button" Style="width: 90px"
                        Text="Save" ValidationGroup="VgOne" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
