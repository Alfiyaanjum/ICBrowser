<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="EmailSentReceiveDetails.aspx.cs" Inherits="ICBrowser.Web.EmailSentReceiveDetails"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 87px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function confirmDelete(source, args) {
            if (confirm('Are you sure you want to delete ?')) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
            return;
        }
    </script>
    <script language="javascript" type="text/javascript">
        function ismaxlength(objTxtCtrl, nLength) {
            if (objTxtCtrl.getAttribute && objTxtCtrl.value.length > nLength)
                objTxtCtrl.value = objTxtCtrl.value.substring(0, nLength)

            if (document.all)
                document.getElementById('lblCaption').innerText = objTxtCtrl.value.length + ' Out Of ' + nLength;
            else
                document.getElementById('lblCaption').textContent = objTxtCtrl.value.length + ' Out Of ' + nLength;

        }       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellpadding="1" cellspacing="0">
        <tr>
            <td align="center">
                <asp:Button ID="btnInbox" runat="server" Text="Inbox" OnClick="btnInbox_Click" CssClass="button_bg"
                    Width="80px" meta:resourcekey="lnkInboxResource1" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnSentItems" runat="server" Text="Sent" CommandName="sentitems"
                    OnClick="btnSentItems_Click" meta:resourcekey="lnkSentItemsResource1" CssClass="button_bg"
                    Width="80px" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnDelete" runat="server" Text="Trash" CssClass="button_bg" Width="80px"
                    OnClick="btnDelete_Click" meta:resourcekey="lnkDeleteResource1" />
            </td>
        </tr>
    </table>
    <div style="top: -88px; left: 100px; width: 92%; position: relative">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    <asp:Label ID="lblMessageForDelete" runat="server" Text="No Row is Deleted. Please Select Checkbox."
                        CssClass="red" Visible="False" meta:resourcekey="lblMessageForDeleteResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <div>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr >
                                    <td width="100%" class="headerback">
                                        <asp:Label ID="lblHeaderInbox" runat="server" Text="Inbox" meta:resourcekey="lblHeaderInboxResource1"
                                            CssClass="header"></asp:Label>
                                        <asp:Label ID="lblHeaderSentItem" runat="server" CssClass="header"
                                            Text="Sent" Visible="False" meta:resourcekey="lblHeaderSentItemResource1"></asp:Label>
                                        <asp:Label ID="lblHeaderDeleteItems" runat="server" CssClass="header"
                                            Text="Trash" Visible="False" meta:resourcekey="lblHeaderDeleteItemsResource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="grid">
                            <asp:GridView ID="gvEmailDetails" runat="server" AllowSorting="True" ClientIDMode="Static"
                                PageSize="20" AutoGenerateColumns="False" AllowPaging="True" Width="100%" OnRowDataBound="gvEmailDetails_RowDataBound"
                                OnRowCommand="gvEmailDetails_RowCommand" OnPageIndexChanging="gvEmailDetails_PageIndexChanging"
                                OnRowDeleting="gvEmailDetails_RowDeleting" meta:resourcekey="gvEmailDetailsResource1"
                                CssClass="table-border">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False" Visible="False" HeaderText="FromUserId" meta:resourcekey="TemplateFieldResource1">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFromUserId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FromUserId") %>'
                                                Visible="False" meta:resourcekey="lblFromUserIdResource1"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False" Visible="False" HeaderText="ToUserId" meta:resourcekey="TemplateFieldResource2">
                                        <ItemTemplate>
                                            <asp:Label ID="lblToUserId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ToUserId") %>'
                                                Visible="False" meta:resourcekey="lblToUserIdResource1"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False" Visible="False" meta:resourcekey="TemplateFieldResource3">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSellerEmailId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MessageId") %>'
                                                Visible="False" meta:resourcekey="lblSellerEmailIdResource1"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" Visible="false" meta:resourcekey="TemplateFieldResource4">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status") %>'
                                                meta:resourcekey="lblStatusResource1"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject" meta:resourcekey="TemplateFieldResource5">
                                        <ItemTemplate>
                                            <asp:LinkButton ForeColor="Black" Font-Underline="False" ID="lnkSubject" runat="server"
                                                Text='<%# DataBinder.Eval(Container.DataItem, "Subject") %>' CommandName="subject"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MessageId") %>' meta:resourcekey="lnkSubjectResource1"
                                                ToolTip="Subject"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date" meta:resourcekey="TemplateFieldResource6">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSentDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SentDate") %>'
                                                meta:resourcekey="lblSentDateResource1"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="100%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField meta:resourcekey="TemplateFieldResource8">
                                        <ItemTemplate>
                                            <asp:Image ID="imgAttachment" runat="server" ToolTip="Attachment" ImageUrl="~/Images/pin_new.png"
                                                Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AttachedFilName" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAttachedFileName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AttachedFile") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField meta:resourcekey="TemplateFieldResource7">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgbtnDelete" ImageUrl="~/Images/deletet_btn.png"
                                                CommandName="Delete" ToolTip="Delete" ValidationGroup="deleteConfirmation" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MessageId") %>'
                                                meta:resourcekey="imgbtnDeleteResource1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle Width="100%" Wrap="True" />
                                <EmptyDataTemplate>
                                    <table style="background-color: #EEF0F6" width="100%" border="0" cellpadding="0"
                                        cellspacing="0">
                                        <tr>
                                            <td colspan="2" class="errormsg" style="height: 100px" align="center">
                                                No records found.
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <RowStyle CssClass="odd"></RowStyle>
                                <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                <HeaderStyle HorizontalAlign="Left" />
                                <PagerStyle CssClass="headerback" HorizontalAlign="Center" />
                            </asp:GridView>
                            <asp:CustomValidator ID="CustomValidator1" ClientValidationFunction="confirmDelete"
                                ValidationGroup="deleteConfirmation" runat="server" meta:resourcekey="CustomValidator1Resource1"></asp:CustomValidator>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
