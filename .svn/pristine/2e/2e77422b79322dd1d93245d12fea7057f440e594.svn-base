<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Detail.Master" CodeBehind="AddBuyersRequirements.aspx.cs"
    Inherits="ICBrowser.Web.AddBuyersRequirements" %>

<%@ MasterType VirtualPath="~/Detail.Master" %>
<%@ Register Src="~/Controls/AddRequirement.ascx" TagName="BuyersAddRequirement"
    TagPrefix="userControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />
    <div style="overflow: scroll; height: 535px; width: 975px">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="hidden_rptr_ControlCount" runat="server"></asp:HiddenField>
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="center" style="height: 10px">
                    <asp:Label ID="lblStatusmsg" runat="server" CssClass="redmsg" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 975px">
                    <asp:UpdatePanel runat="server" ID="updateDirectorDtl">
                        <ContentTemplate>
                            <asp:Repeater ID="rptAddBuyerRequirements" runat="server" OnItemCommand="rptAddRequirements_ItemCommand">
                                <ItemTemplate>
                                    <userControl:BuyersAddRequirement ID="ctrlAddRequirements" runat="server" Data='<%# Container.DataItem  %>' />
                                </ItemTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnSave" runat="server" CssClass="blue_button" Style="width: 90px"
                        Text="Save All" ValidationGroup="VgOne" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
