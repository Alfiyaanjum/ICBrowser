<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Site.Master" CodeBehind="BroadcastEmail.aspx.cs" Inherits="ICBrowser.Web.BroadcastEmail"
    UICulture="auto" Culture="auto" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function ismaxlength(objTxtCtrl, nLength) {
            if (objTxtCtrl.getAttribute && objTxtCtrl.value.length > nLength)
                objTxtCtrl.value = objTxtCtrl.value.substring(0, nLength)

            if (document.all)
                document.getElementById('lblCaption').innerText = objTxtCtrl.value.length + ' Out Of ' + nLength;
            else
                document.getElementById('lblCaption').textContent = objTxtCtrl.value.length + ' Out Of ' + nLength;
        }


        function checkAllBoxes() {

            //get total number of rows in the gridview and do whatever
            //you want with it..just grabbing it just cause
           var gvControl = document.getElementById('<%= gvAllUsrDetails.ClientID %>');
            
           //this is the checkbox in the item template...this has to be the same name as the ID of it
            var gvChkBoxControl = "chkbx";

            //this is the checkbox in the Upper Panel
            var gvalluser = document.getElementById("chkAllUsers");
            var gvallFreeuser =document.getElementById("chkFreeUser");
            var gvallPaiduser = document.getElementById("chkPaidUser");
            var gvallTrialuser = document.getElementById("chkTrialUser");

            //get an array of input types in the gridview
            var inputTypes = gvControl.getElementsByTagName("input");
           
            for (var i = 0; i < inputTypes.length; i++) {
                //if the input type is a checkbox and the id of it is what we set above
                //then check or uncheck according to the main check boxes n upper panel
                if (inputTypes[i].type == 'checkbox' && inputTypes[i].id.indexOf(gvChkBoxControl, 0) >= 0)
                    if (gvalluser.checked || gvallFreeuser.checked || gvallPaiduser.checked || gvallTrialuser.checked)
                        inputTypes[i].disabled = true;
                    else
                        inputTypes[i].disabled = false;
            }
        }


    </script>
    <style type="text/css">
        .style1
        {
            color: red;
        }
        .style3
        {
            height: 10px;
            width: 1%;
        }
        .style4
        {
            height: 20px;
            width: 1%;
        }
        .style5
        {
            width: 1%;
        }
        
        .style8
        {
            width: 6px;
        }
        .style10
        {
            width: 10%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hfToUserDetails" runat="server" />
    <asp:HiddenField ID="hfFromUserDetails" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel ID="pnlMessagePopupss" runat="server" BackColor="#EFFBFE" meta:resourcekey="Panel2Resource1">
        <div id="divtoprint">
            <table style="height: 100%;" width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="left" colspan="3">
                        <asp:Label ID="lblError" runat="server" CssClass="redmsg" meta:resourcekey="lblErrorResource1"
                            Visible="False"></asp:Label>
                        <asp:Label ID="lblSucess" runat="server" CssClass="greenmsg" Visible="False" meta:resourcekey="lblSendResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="3">
                        <div class="headerback">
                            <asp:Label ID="lblHeading" runat="server" Text="Send Message" CssClass="header" meta:resourcekey="lblSendResHead1"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 10%;">
                        <%--<asp:HyperLink ID="hypLnkTo" runat="server" Text="To" Target="_blank" />--%>
                        <asp:LinkButton ID="lbtnMailTo" runat="server" Text="To" OnClick="lbtnPreview_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 10%;">
                        <asp:Label ID="LblFrom" runat="server" Text="From:" CssClass="black" meta:resourcekey="LblFromResource1"></asp:Label>
                    </td>
                    <td align="right" class="style5">
                        &nbsp;
                    </td>
                    <td style="width: 80%;">
                        <asp:TextBox ID="txtFrom" runat="server" CssClass="smallinput_t" Height="22px" MaxLength="100"
                            meta:resourcekey="txtFromResource1" ReadOnly="true" ValidationGroup="WithoutTemplate"
                            Text="support@icbrowser.com" Enabled="false" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td class="style3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 10%;">
                        <span class="style1">*</span>
                        <asp:Label ID="lblSubject" runat="server" Text="Subject:" CssClass="black" meta:resourcekey="Label23Resource1"></asp:Label>
                    </td>
                    <td align="right" class="style5">
                        &nbsp;
                    </td>
                    <td style="width: 80%;">
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="smallinput_t" Height="22px"
                            MaxLength="100" meta:resourcekey="txtSubjectResource1" ValidationGroup="WithoutTemplate"
                            Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="style5">
                        &nbsp;
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtSubject"
                                        Display="Dynamic" ErrorMessage="Enter Subject" Text="Enter Subject" ForeColor="Red"
                                        SetFocusOnError="True" ValidationGroup="WithoutTemplate" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 10%;" valign="top">
                        <span class="style1">*</span>
                        <asp:Label ID="lblMessage" runat="server" Text="Message:" CssClass="black" meta:resourcekey="Label25Resource1"></asp:Label>
                    </td>
                    <td valign="top" align="right" class="style5">
                        &nbsp;
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtContent" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_multilinetextbox"
                            Height="100px" meta:resourcekey="txtContentResource1" onkeyup="return ismaxlength(this,500)"
                            Font-Names="Calibri" Font-Size="12" TextMode="MultiLine" ValidationGroup="WithoutTemplate"
                            Width="99%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="style5">
                        &nbsp;
                    </td>
                    <td>
                        <label id='lblCaption' style="font-family: Tahoma; font-size: 1em; font-weight: bold">
                        </label>
                        <table width="100%">
                            <tr>
                                <td align="left" colspan="3">
                                    <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtContent"
                                        Display="Dynamic" ForeColor="Red" meta:resourcekey="RequiredFieldValidator3Resource1"
                                        SetFocusOnError="True" Text="Enter Message" ValidationGroup="WithoutTemplate"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style10">
                                    <asp:Button ID="btnSendMessage" runat="server" CssClass="blue_button" Style="width: 110px;"
                                        Text="Send Message" meta:resourcekey="btnPrintPreviewResource1" OnClick="btnSendMessage_Click"
                                        ValidationGroup="WithoutTemplate" />
                                </td>
                                <td width="90%">
                                    <asp:Button ID="btnCancelMessage" runat="server" CssClass="blue_button" Style="width: 110px;"
                                        Text="Cancel Message" meta:resourcekey="btnCancelMessageResource1" OnClick="btnCancelMessage_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <div>
        <table>
            <tr>
                <td align="center">
                    <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" meta:resourcekey="LinkButton6Resource1"></asp:LinkButton>
                    <asp:ModalPopupExtender ID="modpopPreview" runat="server" PopupControlID="pnlPreview"
                        TargetControlID="LinkButton6" BackgroundCssClass="modalBackground" DynamicServicePath=""
                        Enabled="True">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlPreview" runat="server" meta:resourcekey="pnlPreviewResource1">
                        <asp:UpdatePanel runat="server" ID="upnlPreview">
                            <ContentTemplate>
                                <div style="width: 100%;" class="popupbox">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="popupbox-lefttop-corner">
                                            </td>
                                            <td class="popupbox-topbg">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="97%" align="left" class="popupbox-header">
                                                            <asp:Label ID="lblPreview" runat="server" Text="Message Preview" CssClass="title"></asp:Label>
                                                        </td>
                                                        <td width="3%" align="center" valign="middle" class="popupbox-header">
                                                            <asp:ImageButton ID="ImgbtnCancel" ImageUrl="~/Images/cross.png" runat="server" />
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
                                            <td align="center" valign="top" class="popupbox-content">
                                                <table width="100%" style="height: 100%;" border="0" cellpadding="5" cellspacing="0">
                                                    <tr class="headerback">
                                                        <td valign="top">
                                                            <asp:Panel ID="pnlFilter" runat="server" meta:resourcekey="pnlFilterResource1">
                                                                <table width="100%" cellspacing="0" cellpadding="0" style="height: 35px">
                                                                    <tr>
                                                                        <td width="10%" valign="middle" align="left">
                                                                            <asp:Label ID="lblFilter" runat="server" Text="Select Users:" CssClass="text" ForeColor="Black"
                                                                                meta:resourcekey="lblFilterResource1"></asp:Label>
                                                                        </td>
                                                                        <td width="10%" valign="middle" align="left">
                                                                            <input type="checkbox" id="chkAllUsers" runat="server" onclick="checkAllBoxes();" clientidmode="Static" style="display:inline"/>All
                                                                            User
                                                                        </td>
                                                                        <td width="10%" valign="middle" align="left">
                                                                            <input type="checkbox" id="chkFreeUser" runat="server" onclick="checkAllBoxes();" clientidmode="Static" style="display:inline"/>All
                                                                            Free
                                                                        </td>
                                                                        <td width="10%" valign="middle" align="left">
                                                                            <input type="checkbox" id="chkPaidUser" runat="server" onclick="checkAllBoxes();" clientidmode="Static" style="display:inline"/>All
                                                                            Paid
                                                                        </td>
                                                                        <td width="10%" align="left" valign="middle">
                                                                            <input type="checkbox" id="chkTrialUser" runat="server" onclick="checkAllBoxes();" clientidmode="Static" style="display:inline" />All
                                                                            Trial
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr id="trUploadedFile" runat="server">
                                                        <td id="Td1" align="left" runat="server">
                                                            <div class="grid" style="overflow: scroll; height: 250px; width: 500px">
                                                                <asp:GridView ID="gvAllUsrDetails" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvAllUsrDetails_RowCancelingEdit"
                                                                    CellPadding="0" ClientIDMode="Static" OnRowUpdating="gvAllUsrDetails_RowUpdating"
                                                                    OnRowEditing="gvAllUsrDetails_RowEditing" OnRowDataBound="gvAllUsrDetails_RowDataBound"
                                                                    AlternatingRowStyle-CssClass="even" RowStyle-CssClass="odd" Width="100%" OnPageIndexChanging="gvAllUsrDetails_PageIndexChanging"
                                                                    CssClass="table-border" meta:resourcekey="gvAllUsrDetailsResource1">
                                                                    <RowStyle CssClass="odd"></RowStyle>
                                                                    <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="UserID" SortExpression="UserID" Visible="false" meta:resourcekey="TemplateFieldResource1">
                                                                            <ItemTemplate>
                                                                                <%--<asp:Label ID="lblUsrId" runat="server" Text='<%# Eval("UserID") %>' meta:resourcekey="lblUsrIdResource1"></asp:Label>--%>
                                                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EmailId") %>' meta:resourcekey="lblEmailResource1"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                                                            <HeaderTemplate>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkbx" runat="server" meta:resourcekey="chkbxResource1" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="3%" HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Contact Name" SortExpression="ContactName" ItemStyle-Width="20%"
                                                                            HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource4">
                                                                            <ItemTemplate>
                                                                                <%--<asp:HyperLink ID="lnkContactName" runat="server" NavigateUrl='<%# Eval("UserID", "NewUserProfile.aspx?UserID={0}") %>'
                                                                                    Text='<%# Eval("ContactName") %>' Target="_blank" meta:resourcekey="lblContactNameResource1" />--%>
                                                                                <asp:Label ID="lblContactName" runat="server" Text='<%# Eval("ContactName") %>' meta:resourcekey="lblContactNameResource1"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="User Type" SortExpression="TypeOfMembership" ItemStyle-Width="8%"
                                                                            HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource9">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMemType" runat="server" Text='<%# Eval("TypeOfMembership") %>'
                                                                                    meta:resourcekey="lblMemTypeResource1"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EditRowStyle Width="100%" Wrap="True" />
                                                                    <RowStyle HorizontalAlign="Left" />
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
                                                                    <PagerStyle CssClass="headerback" HorizontalAlign="Center" />
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="btnPreviewClose" runat="server" Text="Ok" Width="60px" CausesValidation="False"
                                                                CssClass="blue_button" meta:resourcekey="btnPreviewCloseResource1" OnClick="btnPreviewClose_Click" />
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
                                <asp:PostBackTrigger ControlID="btnPreviewClose" />
                                <asp:PostBackTrigger ControlID="ImgbtnCancel" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
