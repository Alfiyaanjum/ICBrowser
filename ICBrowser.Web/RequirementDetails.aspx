<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequirementDetails.aspx.cs" Inherits="ICBrowser.Web.RequirementDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 98%">
        <tr>
            <td>
            <table align="center" style="width: 97%">
            <tr>
            <td>
            <asp:GridView ID="GridView1" runat="server" Width="900px">

                </asp:GridView>
            </td>
            </tr>
                
            </table>
            </td>
        </tr>
    </table>
</asp:Content>
