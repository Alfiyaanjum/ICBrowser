<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ComponentDetails.aspx.cs" Inherits="ICBrowser.Web.ComponentDetails"
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
    <asp:Label ID="lnkEmilAddress" runat="server" meta:resourcekey="lnkEmilAddressResource1"></asp:Label>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr class="table-row">
            <td width="30%">
                <asp:Label ID="lbl_componentName" runat="server" Text="Component Name" Font-Bold="True"
                    Font-Size="Medium" meta:resourcekey="lbl_componentNameResource1"></asp:Label><span>:</span>
            </td>
            <%--<td width="60%" align="right">
                <asp:Label ID="lblmsg" runat="server" CssClass="greenmsg" Visible="False" meta:resourcekey="lblmsgResource1"></asp:Label>
            </td>--%>
            <%--<td width="10%" align="center">
                <asp:Button ID="btnSendMsg" runat="server" Text="Send Message" OnClick="btnSendMsg_Click"
                    CssClass="blue_button" meta:resourcekey="btnSendMsgResource1" />
            </td>--%>
        </tr>
        <tr>
            <td colspan="3">
                <div class="grid">
                    <asp:GridView ID="gvComponentDetails" runat="server" AutoGenerateColumns="False"
                        Width="100%" PageSize="20" AlternatingRowStyle-CssClass="even" RowStyle-CssClass="odd"
                        meta:resourcekey="gvComponentDetailsResource1" OnRowCommand="gvComponentDetails_RowCommand"
                        OnRowDataBound="gvComponentDetails_RowDataBound">
                        <RowStyle CssClass="odd"></RowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="User Id" SortExpression="UserId" Visible="false" meta:resourcekey="TemplateFieldResource9">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSellerId" runat="server" Text='<%# Bind("UserId") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Part Number" meta:resourcekey="TemplateFieldResource10">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPartNumber" runat="server" CommandName="SelectPartNumber"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company Name" SortExpression="CompanyName" meta:resourcekey="TemplateFieldResource1">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk" runat="server" CommandName="SelectCompanyName" Text='<%# Bind("CompanyName") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Make" SortExpression="BrandName" meta:resourcekey="TemplateFieldResource2">
                                <ItemTemplate>
                                    <asp:Label ID="lblBrandName" runat="server" Text='<%# Bind("BrandName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity" meta:resourcekey="TemplateFieldResource3">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Code" SortExpression="DateCode" meta:resourcekey="TemplateFieldResource6">
                                <ItemTemplate>
                                    <asp:Label ID="lblDateCode" runat="server" Text='<%# Bind("DateCode") %>' meta:resourcekey="lblDateCodeResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Stock In Hand" SortExpression="StockInHand" meta:resourcekey="TemplateFieldResource4">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("StockInHand") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Price In USD" SortExpression="PriceInUSD" meta:resourcekey="TemplateFieldResource7">
                                <ItemTemplate>
                                    <asp:Label ID="lblUnitPriceUSD" runat="server" Text='<%# Bind("PriceInUSD") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stock Status" SortExpression="stockstatus" meta:resourcekey="TemplateFieldResource8">
                                <ItemTemplate>
                                    <asp:Label ID="lblStkStatus" runat="server" Text='<%# Bind("stockstatus") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comment" meta:resourcekey="TemplateFieldResource20">
                                <ItemTemplate>
                                    <asp:Label ID="lbldescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:TemplateField>
                        </Columns>
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
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <%--<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>--%>
    <%-- <asp:ModalPopupExtender ID="ModalPopupExtenderSendEmail" runat="server" BackgroundCssClass="modalBackground"
        PopupControlID="pnlMessagePopup" DropShadow="True" DynamicServicePath="" TargetControlID="LinkButton1"
        Enabled="True">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlMessagePopup" runat="server" meta:resourcekey="Panel2Resource1">
        <asp:UpdatePanel runat="server" ID="upnlMessagePopup">
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
                                            <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Images/cross.png" meta:resourcekey="imgCancelResource1"
                                                OnClick="imgCancel_Click" ToolTip="Close" />
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
                                            <asp:Label ID="lblError" runat="server" meta:resourcekey="lblErrorResource1" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;">
                                            <asp:Label ID="lblSubject" runat="server" Text="Subject" CssClass="black" meta:resourcekey="Label23Resource1"></asp:Label>
                                            <span class="errormsg">*</span><span class="black">:</span>
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
                                                SetFocusOnError="True" ValidationGroup="WithoutTemplate" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;" valign="top">
                                            <asp:Label ID="lblMessage" runat="server" Text="Message" CssClass="black" meta:resourcekey="Label25Resource1"></asp:Label>
                                            <span class="errormsg">*</span><span class="black">:</span>
                                        </td>
                                        <td style="width: 80%;" colspan="2">
                                            <asp:TextBox ID="txtContent" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_multilinetextbox "
                                                Text="I need        (Part_No) of        (quantity)" Height="100px" meta:resourcekey="txtContentResource1"
                                                TextMode="MultiLine" ValidationGroup="WithoutTemplate" onkeyup="return ismaxlength(this,500)"
                                                Width="99%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left" style="height: 20px;">
                                            <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtContent"
                                                Display="Dynamic" Text="Enter Message" ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="WithoutTemplate" meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator>
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
                                                Text="Send" OnClick="btnSubmit_Click1" ValidationGroup="WithoutTemplate" meta:resourcekey="btnSubmitResource1" />
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
</asp:Content>
