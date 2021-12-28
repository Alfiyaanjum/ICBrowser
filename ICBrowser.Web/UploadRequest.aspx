<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="UploadRequest.aspx.cs" Inherits="ICBrowser.Web.UploadRequest" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="~/Controls/UploadSheetData.ascx" TagName="UploadData" TagPrefix="userControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdnStatus" runat="server" />
    <asp:HiddenField ID="hdnLastSelection" runat="server" />
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
                <userControl:UploadData ID="ctrlUploaddata" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
