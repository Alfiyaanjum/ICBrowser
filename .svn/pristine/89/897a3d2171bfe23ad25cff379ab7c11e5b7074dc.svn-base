<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="OfflineSubscription.aspx.cs" Inherits="ICBrowser.Web.OfflineSubscription"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
                        <asp:Label ID="lblHeading" runat="server" Text="All Offline Subscribed Users" CssClass="header"
                            meta:resourcekey="lblHeadingResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="grid">
                            <asp:GridView ID="gvOfflineSub" runat="server" AutoGenerateColumns="False" Height="100%"
                                Width="100%" AllowPaging="True" PageSize="23" AllowSorting="True" OnRowCommand="gvOfflineSub_RowCommand"
                                OnPageIndexChanging="gvOfflineSub_PageIndexChanging" OnSorting="gvOfflineSub_Sorting"
                                UpdateMode="Conditional" CssClass="table-border" meta:resourcekey="gvOfflineSubResource1">
                                <RowStyle CssClass="odd"></RowStyle>
                                <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="User ID" SortExpression="UserID" Visible="False" meta:resourcekey="TemplateFieldResource1">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSellerId" runat="server" CommandName="lnkBtn" Text='<%# Bind("UserID") %>'
                                                meta:resourcekey="lnkSellerIdResource1"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Name" SortExpression="UserName" ItemStyle-Width="15%"
                                        HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkUsrName" runat="server" NavigateUrl='<%# Eval("UserID", "ViewSellersProfile.aspx?UserID={0}") %>'
                                                Text='<%# Eval("UserName") %>' meta:resourcekey="lnkUsrNameResource1" Target="_blank" />
                                            <asp:LinkButton ID="lbtnUserName" runat="server" CommandName="lnkBtn1" Text='<%# Bind("UserName") %>'
                                                Visible="False"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Company Name" SortExpression="CompanyName" meta:resourcekey="TemplateFieldResource2">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HypLnkCompanyName" Text='<%# Bind("CompanyName") %>' runat="server"
                                                NavigateUrl='<%# Eval("UserID", "../NewUserProfile.aspx?UserID={0}") %>' Target="_blank"
                                                meta:resourcekey="HypLnkCompanyNameResource1"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Name" SortExpression="ContactName" meta:resourcekey="TemplateFieldResource3">
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
                                    <asp:BoundField DataField="CreateDate" HeaderText="Create Date" SortExpression="CreateDate"
                                        DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}" meta:resourcekey="BoundFieldResource1" />
                                    <asp:TemplateField HeaderText="" meta:resourcekey="TemplateFieldResource5">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkApproved" runat="server" CommandName="lnkBtn1" CommandArgument='<%# Bind("UserId") %>'
                                                Text="Approve" meta:resourcekey="lnkApprovedResource1"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkSellerId1" runat="server" Text='<%# Bind("UserId") %>' Visible="False"
                                                meta:resourcekey="lnkSellerId1Resource1"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField meta:resourcekey="TemplateFieldResource6">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDecline" runat="server" CommandName="lnkBtn2" Text="Decline"
                                                CommandArgument='<%# Bind("UserId") %>' meta:resourcekey="lnkDeclineResource1"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkSellerId2" runat="server" Text='<%# Bind("UserId") %>' Visible="False"
                                                meta:resourcekey="lnkSellerId2Resource1"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
    <%--<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
    <asp:ModalPopupExtender ID="ModalPopupExtenderSendEmail" runat="server" BackgroundCssClass="modalBackground"
        PopupControlID="Panel2" DropShadow="True" DynamicServicePath="" TargetControlID="LinkButton1"
        Enabled="True">
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
                                            <asp:Label ID="lblSendMessageheading" runat="server" Text="Send Message" meta:resourcekey="lblSendMessageheadingResource1"></asp:Label>
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
                                <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="width: 20%;">
                                        </td>
                                        <td align="left" style="width: 80%;" colspan="2">
                                            <asp:Label ID="lbleror" runat="server" Visible="False" CssClass="redmsg" meta:resourcekey="lblerorResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;">
                                            <span class="errormsg">*</span><asp:Label ID="lblSubject" runat="server" Text="Subject"
                                                CssClass="black" meta:resourcekey="lblSubjectResource1"></asp:Label>
                                            <span class="black">:</span>
                                        </td>
                                        <td style="width: 80%;" colspan="2">
                                            <asp:TextBox ID="txtSubject" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                Height="22px" Width="97%" MaxLength="100" ValidationGroup="WithoutTemplate" meta:resourcekey="txtSubjectResource1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="height: 20px">
                                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtSubject"
                                                Display="Dynamic" ErrorMessage="Enter Subject" Text="Enter Subject" ForeColor="Red"
                                                SetFocusOnError="True" ValidationGroup="WithoutTemplate" meta:resourcekey="rfvDescriptionResource1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;" valign="top">
                                            <span class="errormsg">*</span><asp:Label ID="lblMessage" runat="server" Text="Message"
                                                CssClass="black" meta:resourcekey="lblMessageResource1"></asp:Label>
                                            <span class="black">:</span>
                                        </td>
                                        <td style="width: 80%;" colspan="2">
                                            <asp:TextBox ID="txtContent" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_multilinetextbox"
                                                Height="100px" TextMode="MultiLine" ValidationGroup="WithoutTemplate" onkeyup="return ismaxlength(this,500)"
                                                Width="99%" meta:resourcekey="txtContentResource1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left" style="height: 20px;">
                                            <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtContent"
                                                Display="Dynamic" Text="Enter Message" ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="WithoutTemplate" meta:resourcekey="rfvMessageResource1"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right" style="height: 20px;">
                                            <label id='lblCaption' style="font-family: Tahoma; font-size: 1em; font-weight: bold">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">
                                        </td>
                                        <td align="right" style="width: 80%;" colspan="2">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="blue_button" Style="width: 80px"
                                                Text="Send" OnClick="btnSubmit_Click" ValidationGroup="WithoutTemplate" meta:resourcekey="btnSubmitResource1" />
                                        </td>
                                    </tr>
                                </table>
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
                <asp:PostBackTrigger ControlID="btnSubmit" />
                <asp:PostBackTrigger ControlID="imgCancel" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>--%>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
        PopupControlID="Panel1" DropShadow="True" DynamicServicePath="" TargetControlID="LinkButton2"
        Enabled="True">
    </asp:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" meta:resourcekey="Panel2Resource1">
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
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
                                            <asp:Label ID="lblReasondecline" runat="server" Text="Reason For Decline" Font-Bold="true"
                                                meta:resourcekey="lblReasondeclineResource1"></asp:Label>
                                        </td>
                                        <td width="3%" align="right" valign="middle" class="popupbox-header">
                                            <asp:ImageButton ID="delineImageCancel" runat="server" ImageUrl="~/Images/cross.png"
                                                OnClick="delineImageCancel_Click" ToolTip="Close" meta:resourcekey="imgCancelResource1" />
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
                                <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                     <tr>
                                        <td align="left" style="width: 35%;" valign="top">
                                            <asp:Label ID="lbldecline" runat="server" Text="Reason For Decline" CssClass="black" Font-Bold="true"
                                                meta:resourcekey="lbldeclineResource1"></asp:Label>
                                            <span class="black">:</span>
                                        </td>
                                        <td style="width: 64%;" colspan="2" align="left">
                                            <asp:TextBox ID="txtdecline" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_multilinetextbox"
                                                Height="100px" TextMode="MultiLine" ValidationGroup="WithoutTemplate" onkeyup="return ismaxlength(this,500)"
                                                Width="99%" meta:resourcekey="txtdeclineResource1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left" style="height: 20px;">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdecline"
                                                Display="Dynamic" Text="Enter Message" ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="WithoutTemplate" meta:resourcekey="rfvMessageResource1"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right" style="height: 20px;">
                                            <label id='lblCaption' style="font-family: Tahoma; font-size: 1em; font-weight: bold">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">
                                        </td>
                                        <td align="right" style="width: 80%;" colspan="2">
                                            <asp:Button ID="btndecline" runat="server" CssClass="blue_button" Style="width: 80px"
                                                Text="Save" OnClick="btndecline_Click" ValidationGroup="WithoutTemplate" meta:resourcekey="btndeclineResource1" />
                                        </td>
                                    </tr>
                                </table>
                                <%--<div style='width: 100%; min-height: 150px; position: relative;'>
                                    <table>
                                        <tr>
                                            <td align="right" style="width: 20%;" valign="top">
                                                <asp:Label ID="lbldecline" runat="server" Text="Reason For Decline" CssClass="black"
                                                    meta:resourcekey="lbldeclineResource1"></asp:Label>
                                                <span class="black">:</span>
                                            </td>
                                            <td style="width: 80%;" colspan="2">
                                                <asp:TextBox ID="txtdecline" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_multilinetextbox"
                                                    Height="90px" TextMode="MultiLine" ValidationGroup="WithoutTemplate" onkeyup="return ismaxlength(this,500)"
                                                    Width="99%" meta:resourcekey="txtdeclineResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left" style="height: 20px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdecline"
                                                    Display="Dynamic" Text="Enter Message" ForeColor="Red" SetFocusOnError="True"
                                                    ValidationGroup="WithoutTemplate" meta:resourcekey="rfvMessageResource1"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right" style="height: 20px;">
                                                <label id='lblCaption' style="font-family: Tahoma; font-size: 1em; font-weight: bold">
                                                </label>
                                            </td>
                                        </tr>
                                    </table>
                                    <div style='position: absolute; left: 0; width: 100%; bottom: 0;'>
                                        <div style='width: 60px; height: 30px; margin: 0 auto; text-align: center'>
                                            <asp:Button ID="btndecline" runat="server" CssClass="blue_button" Style="width: 80px"
                                                Text="Save" OnClick="btndecline_Click" ValidationGroup="WithoutTemplate" meta:resourcekey="btndeclineResource1" />
                                        </div>
                                    </div>
                                </div>--%>
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
                <asp:PostBackTrigger ControlID="btndecline" />
                <asp:PostBackTrigger ControlID="delineImageCancel" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
    <table width="100%">
        <tr class="headerback">
            <td>
                <asp:Label ID="lblHead" runat="server" Text="All Trial Users" CssClass="header" meta:resourcekey="lblHeadResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid">
                    <asp:GridView ID="gvTrialUsrGrid" runat="server" AutoGenerateColumns="False" Height="100%"
                        Width="100%" AllowPaging="True" AlternatingRowStyle-CssClass="even" RowStyle-CssClass="odd"
                        UpdateMode="Conditional" OnPageIndexChanging="gvTrialUsrGrid_PageIndexChanging"
                        OnSorting="gvTrialUsrGrid_Sorting" OnRowCommand="gvTrialUsrGrid_RowCommand" OnRowDataBound="gvTrialUsrGrid_RowDataBound"
                        meta:resourcekey="gvTrialUsrGridResource1" AllowSorting="true">
                        <RowStyle CssClass="odd"></RowStyle>
                        <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="User ID" SortExpression="UserID" Visible="false" meta:resourcekey="TemplateFieldResource7">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUId" runat="server" CommandName="lnkBtn" Text='<%# Bind("UserID") %>'
                                        meta:resourcekey="lnkUIdResource1"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Name" SortExpression="UserName" ItemStyle-Width="15%"
                                HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkUsrName" runat="server" NavigateUrl='<%# Bind("UserID", "ViewSellersProfile.aspx?UserID={0}") %>'
                                        Text='<%# Bind("UserName") %>' Target="_blank" />
                                    <asp:LinkButton ID="lbtnUserName" runat="server" CommandName="lnkBtn1" Text='<%# Bind("UserName") %>'
                                        Visible="False"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company Name" SortExpression="CompanyName" meta:resourcekey="TemplateFieldResource8">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hypCmpnyName" Text='<%# Bind("CompanyName") %>' runat="server"
                                        NavigateUrl='<%# Bind("UserID", "NewUserProfile.aspx?UserID={0}") %>' Target="_blank"
                                        meta:resourcekey="hypCmpnyNameResource1"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Name" SortExpression="ContactName" meta:resourcekey="TemplateFieldResource9">
                                <ItemTemplate>
                                    <asp:Label ID="lblContactNme" runat="server" Text='<%# Bind("ContactName") %>' meta:resourcekey="lblContactNmeResource1"></asp:Label>
                                    <asp:LinkButton ID="lbtnContactName" runat="server" CommandName="lnkBtn1" Text='<%# Bind("ContactName") %>'
                                        Visible="False" meta:resourcekey="lbtnContactNameResource2"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email Id" SortExpression="EmailId" Visible="false"
                                meta:resourcekey="TemplateFieldResource10">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn" runat="server" CommandName="lnkBtn1" Text='<%# Bind("email") %>'
                                        meta:resourcekey="lbtnResource1"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreateDate" HeaderText="Create Date" SortExpression="CreateDate"
                                DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}" meta:resourcekey="BoundFieldResource2" />
                            <asp:TemplateField HeaderText="Check Matches" Visible="true" meta:resourcekey="TemplateFieldResource11">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hypLnkMatches" Text="Check Matches" runat="server" NavigateUrl='<%# Eval("UserID", "~/AdminChkMatch.aspx?UserID={0}") %>'
                                        Target="_self" meta:resourcekey="hypLnkMatchesResource1"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" meta:resourcekey="TemplateFieldResource12">
                                <ItemTemplate>
                                    <asp:Button ID="btnStat" runat="server" CausesValidation="False" Text='<%# Eval("PaymentStatus") %>'
                                        meta:resourcekey="btnStatResource1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="true" meta:resourcekey="TemplateFieldResource13">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkApprd" runat="server" CommandName="lnkBtn1" Text="Approve"
                                        CommandArgument='<%# Bind("UserId") %>' meta:resourcekey="lnkApprdResource1"></asp:LinkButton>
                                    <asp:Label ID="lblApproved" runat="server" meta:resourcekey="lblApprovedResource1"></asp:Label>
                                    <asp:LinkButton ID="lnkUsrId" runat="server" Text='<%# Bind("UserId") %>' Visible="False"
                                        meta:resourcekey="lnkUsrIdResource1"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="true" meta:resourcekey="TemplateFieldResource14">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDecn" runat="server" CommandName="lnkBtn2" Text="Decline"
                                        CommandArgument='<%# Bind("UserId") %>' meta:resourcekey="lnkDecnResource1"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkUserID" runat="server" Text='<%# Bind("UserId") %>' Visible="False"
                                        meta:resourcekey="lnkUserIDResource1"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table style="background-color: #EEF0F6" width="100%" border="0" cellpadding="0"
                                cellspacing="0">
                                <tr>
                                    <td colspan="2" class="errormsg" style="height: 100px" align="center">
                                        <asp:Label ID="lblNoRcrd" runat="server" Text=" No records found." CssClass="greenmsg"
                                            meta:resourcekey="lblNoRcrdResource2"></asp:Label>
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
</asp:Content>
