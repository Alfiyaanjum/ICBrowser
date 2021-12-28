<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="AdminChkMatch.aspx.cs" Inherits="ICBrowser.Web.AdminChkMatch" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

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
    <table width="100%" id="tblData" runat="server" cellpadding="4" cellspacing="0">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblSucess" runat="server" Visible="False" CssClass="greenmsg" meta:resourcekey="lblSucessResource1"></asp:Label>
                <asp:Label ID="lblError" runat="server" Visible="False" CssClass="redmsg" meta:resourcekey="lblErrorResource1"></asp:Label>
            </td>
        </tr>
        <tr class="headerback" style="background-color: #8BBDE2">
            <td colspan="2">
                <asp:Label ID="lblhead" runat="server" Text="Check Match For:" CssClass="header"></asp:Label>
            </td>
        </tr>
        <tr style="background-color: #dfedf7">
            <td style="width: 25%; text-align: right;">
                <asp:Label ID="lblCntName" runat="server" Text="Contact Name" Font-Bold="False" Visible="false"
                    meta:resourcekey="lblCntNameResource1"></asp:Label>
            </td>
            <td style="width: 75%">
                <asp:Label ID="lblCntName1" runat="server" Text="Label" Visible="false" meta:resourcekey="lblCntName1Resource1"></asp:Label>
            </td>
        </tr>
        <%--      <tr>
            <td style="width: 25%; text-align: right;">
                <asp:Label ID="lblUserName" runat="server" Text="User Name" Font-Bold="False" meta:resourcekey="lblUserNameResource1"></asp:Label>
            </td>
            <td style="width: 75%">
                <asp:Label ID="lblUserName1" runat="server" Text="Label" meta:resourcekey="lblUserName1Resource1"></asp:Label>
            </td>
        </tr>
        <tr style="background-color: #dfedf7">
            <td style="width: 25%; text-align: right;">
                <asp:Label ID="lblCmpnyName" runat="server" Text="Company Name" Font-Bold="False"
                    meta:resourcekey="lblCmpnyNameResource1"></asp:Label>
            </td>
            <td style="width: 75%">
                <asp:Label ID="lblCmpnyName1" runat="server" Text="Label" meta:resourcekey="lblCmpnyName1Resource1"></asp:Label>
            </td>
        </tr>--%>
        <tr style="background-color: #dfedf7">
            <td style="width: 25%; text-align: right;">
                <asp:Label ID="lblEmailId" runat="server" Text="Email Id" Font-Bold="False" meta:resourcekey="lblEmailIdResource1"></asp:Label>
            </td>
            <td style="width: 75%">
                <asp:Label ID="lblEmailId1" runat="server" Text="Label" meta:resourcekey="lblEmailId1Resource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 25%; text-align: right;">
                <asp:Label ID="lblPhoneNo" runat="server" Text="Phone No:" Font-Bold="False" meta:resourcekey="lblPhoneNoResource1"></asp:Label>
            </td>
            <td style="width: 75%">
                <asp:Label ID="lblPhoneNo1" runat="server" Text="Label" meta:resourcekey="lblPhoneNo1Resource1"></asp:Label>
            </td>
        </tr>
        <tr style="background-color: #dfedf7">
            <td style="width: 25%; text-align: right;">
                <asp:Label ID="lblMobNo" runat="server" Text="Mobile No." Font-Bold="False" meta:resourcekey="lblMobNoResource1"></asp:Label>
            </td>
            <td style="width: 75%">
                <asp:Label ID="lblMobNo1" runat="server" Text="Label" meta:resourcekey="lblMobNo1Resource1"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <%--<table width="100%">
        <tr>
            <td width="92%" align="right" colspan="5">
                <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="blue_button_fu"
                    OnClick="btnApprove_Click" meta:resourcekey="btnApproveResource1" />
            </td>
            <td width="4%" align="left">
                <asp:Button ID="btnDecline" runat="server" Text="Decline" CssClass="blue_button_fu"
                    OnClick="btnDecline_Click" meta:resourcekey="btnDeclineResource1" />
            </td>
            <td width="4%" align="left">
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="blue_button_fu" PostBackUrl="~/OfflineSubscription.aspx"
                    meta:resourcekey="btnBackResource1" />
            </td>
        </tr>
    </table>--%>
    <br />
    <table width="100%">
        <tr class="headerback">
            <td>
                <asp:Label ID="lblMatchings" runat="server" Text="Matching Records" CssClass="header"
                    meta:resourcekey="lblMatchingsResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid">
                    <asp:GridView ID="gvTrialUsrGrid" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvTrialUsrGrid_RowDataBound"
                        OnRowCommand="gvTrialUsrGrid_RowCommand" Height="100%" Width="100%" AllowPaging="True"
                        AlternatingRowStyle-CssClass="even" CellPadding="5" RowStyle-CssClass="odd" UpdateMode="Conditional"
                        CssClass="table-border" OnPageIndexChanging="gvTrialUsrGrid_PageIndexChanging"
                        meta:resourcekey="gvTrialUsrGridResource1">
                        <RowStyle CssClass="odd"></RowStyle>
                        <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="User ID" SortExpression="UserID" Visible="false" meta:resourcekey="TemplateFieldResource1">
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
                            <asp:TemplateField HeaderText="Company Name" SortExpression="CompanyName" meta:resourcekey="TemplateFieldResource2">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hypCmpnyName" Text='<%# Bind("CompanyName") %>' runat="server"
                                        NavigateUrl='<%# Eval("UserID", "../NewUserProfile.aspx?UserID={0}") %>' Target="_blank"
                                        meta:resourcekey="hypCmpnyNameResource1"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Name" SortExpression="ContactName" meta:resourcekey="TemplateFieldResource3">
                                <ItemTemplate>
                                    <asp:Label ID="lblContactNme" runat="server" Text='<%# Bind("ContactName") %>' meta:resourcekey="lblContactNmeResource1"></asp:Label>
                                    <asp:LinkButton ID="lbtnContactName" runat="server" CommandName="lnkBtn1" Text='<%# Bind("ContactName") %>'
                                        Visible="False" meta:resourcekey="lbtnContactNameResource1"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email Id" SortExpression="EmailId" meta:resourcekey="TemplateFieldResource4">
                                <ItemTemplate>
                                    <asp:Label ID="lblMailId" runat="server" Text='<%# Bind("email") %>' meta:resourcekey="lblMailIdResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mobile No" meta:resourcekey="TemplateFieldResource5">
                                <ItemTemplate>
                                    <asp:Label ID="lblMobNo" runat="server" Text='<%# Bind("Mobile") %>' meta:resourcekey="lblMobNoResource2"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Membership Type" SortExpression="TypeOfMembership" ItemStyle-Width="8%"
                                HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblMemType" runat="server" Text='<%# Eval("TypeOfMembership") %>'
                                        meta:resourcekey="lblMemTypeResource1"></asp:Label>
                                    <asp:Label ID="lblOffMemType" runat="server" Text='<%# Eval("OfflineMembership") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Created Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreate" runat="server" Text='<%# Bind("CreateDate") %>' meta:resourcekey="lblCreateResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="CreateDate" HeaderText="Create Date" SortExpression="CreateDate"
                                DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}" meta:resourcekey="BoundFieldResource2" />
                            <asp:TemplateField HeaderText="" Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkApprd" runat="server" CommandName="lnkBtn1" Text="Approve"
                                        Visible="false" CommandArgument='<%# Bind("UserID") %>'></asp:LinkButton>
                                    <asp:LinkButton ID="lnkAppUsrId" runat="server" Text='<%# Bind("UserID") %>' Visible="false"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkMembshpType" runat="server" Text='<%# Bind("TypeOfMembership") %>'
                                        Visible="false"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkIsdecline" runat="server" Text='<%# Bind("IsDecline") %>'
                                        Visible="false"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDecn" runat="server" CommandName="lnkBtn2" Text="Decline"
                                        CommandArgument='<%# Bind("UserID") %>'></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDecUserID" runat="server" Text='<%# Bind("UserID") %>' Visible="false"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table style="background-color: #EEF0F6" width="100%" border="0" cellpadding="0"
                                cellspacing="0">
                                <tr>
                                    <td colspan="2" class="errormsg" style="height: 100px" align="center">
                                        No Matches found.
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
    <br />
    <br />
    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
    <asp:ModalPopupExtender ID="ModalPopupExtenderSendDeclineMessage" runat="server"
        BackgroundCssClass="modalBackground" PopupControlID="Panel1" 
        DynamicServicePath="" TargetControlID="LinkButton2" Enabled="True">
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
                                        <td align="right" style="width: 20%;" valign="top">
                                            <asp:Label ID="lbldecline" runat="server" Text="Reason For Decline" CssClass="black"
                                                meta:resourcekey="lbldeclineResource1"></asp:Label>
                                            <span class="black">:</span>
                                        </td>
                                        <td style="width: 80%;" colspan="2">
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
</asp:Content>
