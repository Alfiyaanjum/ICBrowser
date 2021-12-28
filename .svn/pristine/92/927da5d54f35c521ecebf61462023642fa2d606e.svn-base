<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="DeclineUser.aspx.cs" Inherits="ICBrowser.Web.DeclineUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblSucess" runat="server" Visible="False" CssClass="greenmsg" meta:resourcekey="lblSucessResource1"></asp:Label>
                        <asp:Label ID="lblError" runat="server" Visible="False" Text="Error Occured,please try again later."
                            CssClass="redmsg" meta:resourcekey="lblErrorResource1"></asp:Label>
                    </td>
                </tr>
                <tr class="headerback">
                    <td>
                        <asp:Label ID="lblHeading" runat="server" Text="Declined Users" CssClass="header"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="grid">
                            <asp:GridView ID="gvDeclineUser" runat="server" AutoGenerateColumns="False" Height="100%"
                                Width="100%" AllowPaging="True" OnRowDataBound="gvDeclineUser_RowDataBound" CellPadding="5"
                                OnPageIndexChanging="gvDeclineUser_PageIndexChanging" UpdateMode="Conditional"
                                CssClass="table-border" meta:resourcekey="gvDeclineUserSubResource1" AllowSorting="True">
                                <RowStyle CssClass="odd"></RowStyle>
                                <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="User ID" SortExpression="UserID" Visible="False" meta:resourcekey="TemplateFieldResource1">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSellerId" runat="server" CommandName="lnkBtn" Text='<%# Bind("UserID") %>'
                                                meta:resourcekey="lnkSellerIdResource1"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Name" ItemStyle-Width="15%" HeaderStyle-Width="8%"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkUsrName" runat="server" NavigateUrl='<%# Eval("UserID", "ViewSellersProfile.aspx?UserID={0}") %>'
                                                Text='<%# Eval("UserName") %>' meta:resourcekey="lnkUsrNameResource1" Target="_blank" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Company Name" meta:resourcekey="TemplateFieldResource2">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HypLnkCompanyName" Text='<%# Bind("CompanyName") %>' runat="server"
                                                NavigateUrl='<%# Eval("UserID", "../NewUserProfile.aspx?UserID={0}") %>' Target="_blank"
                                                meta:resourcekey="HypLnkCompanyNameResource1"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Name" meta:resourcekey="TemplateFieldResource3">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactName" runat="server" Text='<%# Bind("ContactName") %>' meta:resourcekey="lblContactNameResource1"></asp:Label>
                                            <asp:LinkButton ID="lbtnContactName" runat="server" CommandName="lnkBtn1" Text='<%# Bind("ContactName") %>'
                                                Visible="False" meta:resourcekey="lbtnContactNameResource1"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email Id" SortExpression="EmailId" Visible="False"
                                        meta:resourcekey="TemplateFieldResource4">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnEmailId" runat="server" CommandName="lnkBtn1" Text='<%# Bind("EmailId") %>'
                                                meta:resourcekey="lbtnEmailIdResource1"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CreateDate" HeaderText="Create Date" DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}"
                                        meta:resourcekey="BoundFieldResource1" />
                                    <asp:TemplateField HeaderText="Membership Type" ItemStyle-Width="8%" HeaderStyle-Width="8%"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemType" runat="server" Text='<%# Eval("TypeOfMembership") %>'
                                                meta:resourcekey="lblMemTypeResource1"></asp:Label>
                                            <asp:Label ID="lblOffMemType" runat="server" Text='<%# Eval("OfflineMembership") %>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reason To Decline">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnReasnDecline" runat="server" OnClick="btnReasnDecline_Click"
                                                Visible="true">Reason</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField meta:resourcekey="TemplateFieldResource6">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDecline" runat="server" CommandName="lnkBtn2" Text="Decline"
                                                CommandArgument='<%# Bind("UserId") %>' meta:resourcekey="lnkDeclineResource1"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkSellerId2" runat="server" Text='<%# Bind("UserId") %>' Visible="False"
                                                meta:resourcekey="lnkSellerId2Resource1"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table style="background-color: #EEF0F6" width="100%" border="0" cellpadding="0"
                                        cellspacing="0">
                                        <tr>
                                            <td colspan="2" class="errormsg" style="height: 100px" align="center">
                                                <asp:Label ID="lblNoRcrd" runat="server" Text=" No records found." CssClass="greenmsg"
                                                    meta:resourcekey="lblNoRcrdResource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <PagerStyle CssClass="headerback" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--Modal pop-up for ReasonToBlock --%>
    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
    <asp:ModalPopupExtender ID="ModalPopupExtenderDeclineUser" runat="server" BackgroundCssClass="modalBackground"
        PopupControlID="Panel2" DynamicServicePath="" TargetControlID="LinkButton1" Enabled="True">
    </asp:ModalPopupExtender>
    <asp:Panel ID="Panel2" runat="server" meta:resourcekey="Panel2Resource1">
        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
            <ContentTemplate>
                <div style="height: 70%; width: 510px;" class="popupbox">
                    <table style="height: 100%;" width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="popupbox-lefttop-corner">
                            </td>
                            <td class="popupbox-topbg">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="97%" align="left" class="popupbox-header">
                                            <asp:Label ID="lblReasontoDeclineheading" runat="server" Text="Reason To Decline"
                                                meta:resourcekey="lblReasontoDeclineheadingResource1"></asp:Label>
                                        </td>
                                        <td width="3%" align="right" valign="middle" class="popupbox-header">
                                            <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Images/cross.png" OnClick="imgCancel_Click"
                                                ToolTip="Close" meta:resourcekey="imgCancelResource1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="popupbox-righttop-corner">
                            </td>
                        </tr>
                        <tr>
                            <td class="popupbox-leftbg">
                            </td>
                            <td align="left" valign="top" class="popupbox-content">
                                <div style='width: 100%; min-height: 150px; position: relative;'>
                                    <table>
                                        <tr>
                                            <td style="width: 30%">
                                                <asp:Label ID="lblReasontoDeclne" runat="server" Text="Reason To Block" CssClass="black"
                                                    Font-Bold="true" meta:resourcekey="lblReasontoDeclneResource1"></asp:Label>
                                                <span class="black">:</span>
                                            </td>
                                            <td style="width: 70%">
                                                <asp:Label ID="lblReasntoDeclineValue" runat="server" meta:resourcekey="lblReasntoDeclineValueResource1" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div style='position: absolute; left: 0; width: 100%; bottom: 0;'>
                                        <div style='width: 60px; height: 30px; margin: 0 auto; text-align: center'>
                                            <asp:Button ID="btnPreviewClose" runat="server" Text="Close" Width="60px" CausesValidation="False"
                                                CssClass="blue_button" OnClick="btnPreviewClose_Click" meta:resourcekey="btnPreviewCloseResource1" />
                                        </div>
                                    </div>
                                </div>
                                <%--<table border="0" cellpadding="5" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="right" style="width: 40%;">
                                            <asp:Label ID="lblReasontoDeclne" runat="server" Text="Reason To Block" CssClass="black"
                                                Font-Bold="true" meta:resourcekey="lblReasontoDeclneResource1"></asp:Label>
                                            <span class="black">:</span>
                                        </td>
                                        <td style="width: 60%;" colspan="2">
                                            <asp:Label ID="lblReasntoDeclineValue" runat="server" meta:resourcekey="lblReasntoDeclineValueResource1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Button ID="btnPreviewClose" runat="server" Text="Close" Width="60px" CausesValidation="False"
                                                CssClass="blue_button" OnClick="btnPreviewClose_Click" meta:resourcekey="btnPreviewCloseResource1" />
                                        </td>
                                    </tr>
                                </table>--%>
                            </td>
                            <td class="popupbox-rightbg">
                            </td>
                        </tr>
                        <tr>
                            <td class="popupbox-leftbtm-corner">
                            </td>
                            <td class="popupbox-bottombg">
                            </td>
                            <td class="popupbox-rightbtm-corner">
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="imgCancel" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
