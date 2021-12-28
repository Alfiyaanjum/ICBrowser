<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddRequirement.ascx.cs"
    Inherits="ICBrowser.Web.Controls.AddRequirement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="Styles/Site.css" rel="stylesheet" type="text/css" />
<link href="Styles/main.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function checkDate(sender, args) {
        if (sender._selectedDate.getDateOnly() < new Date().getDateOnly()) {
            alert("You cannot select a day earlier than today!");
            sender._selectedDate = new Date();
            // set the date back to the current date
            sender._textbox.set_Value(sender._selectedDate.format(sender._format))
        }
        else if (sender._selectedDate.getDateOnly() == new Date().getDateOnly()) {
        }
    }
</script>
<div style="height: 80%; width: 900px; padding-left: 30px" class="popupboxWebControl">
    <table style="height: 100%;" width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="popupbox-lefttop-corner">
            </td>
            <td class="popupbox-topbg">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="97%" align="left" class="popupbox-header">
                            <asp:Label ID="lblReqPopupHeader" runat="server" Text="Add Requirement" 
                                meta:resourcekey="lblReqPopupHeaderResource1"></asp:Label>
                        </td>
                        <td width="3%" align="right" valign="middle" class="popupbox-header">
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
                <%--<table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="25%" align="right">
                            <asp:Label ID="lblPartNumber" runat="server" Text="Part Number" CssClass="black"></asp:Label>
                            <span class="errormsg">*</span><span> :</span>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbxPartNumber" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                MaxLength="50" Width="80%" ValidationGroup="VgOne"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="black" ValidationGroup="VgOne"></asp:Label>
                            <span class="errormsg">*</span><span> :</span>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbxReqPopupQuantity" runat="server" AutoCompleteType="Disabled"
                                CssClass="smallinput_t" MaxLength="10" Width="80%" ValidationGroup="VgOne"></asp:TextBox>
                        </td>
                        <td align="center" rowspan="2">
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Delete" CausesValidation="False"
                                CssClass="blue_button" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None"
                                Height="40px" OnClick="btnRemove_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="rfvPartNumber" runat="server" ControlToValidate="tbxPartNumber"
                                Display="Dynamic" ErrorMessage="Please Enter Part Number" ForeColor="Red" SetFocusOnError="True"
                                ValidationGroup="VgOne"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="tbxReqPopupQuantity"
                                Display="Dynamic" ErrorMessage="Please Enter Quantity" ForeColor="Red" SetFocusOnError="True"
                                ValidationGroup="VgOne"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rgxQuantity" runat="server" ControlToValidate="tbxReqPopupQuantity"
                                Display="Dynamic" ErrorMessage="Please Enter Numeric Data" ForeColor="Red" ValidationExpression="^(\s*)[1-9][0-9]{0,8}(\s*)$"
                                ValidationGroup="VgOne"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" rowspan="2">
                            <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="black"></asp:Label>
                            <span class="errormsg">*</span><span> :</span>
                        </td>
                        <td align="left" rowspan="2">
                            <asp:TextBox ID="tbxReqPopupDescription" runat="server" AutoCompleteType="Disabled"
                                CssClass="smallinput_t_multilinetextbox" TextMode="MultiLine" Width="80%" Height="80"
                                ValidationGroup="VgOne"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblMake" runat="server" Text="Make" CssClass="black"></asp:Label>
                            <span class="errormsg">*</span><span> :</span>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbxMake" runat="server" AutoCompleteType="Disabled" ValidationGroup="VgOne"
                                CssClass="smallinput_t" MaxLength="50" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" rowspan="0">
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="rfvMake" runat="server" ControlToValidate="tbxMake"
                                Display="Dynamic" ErrorMessage="Please Enter Make Value" ForeColor="Red" SetFocusOnError="True"
                                ValidationGroup="VgOne"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" rowspan="2">
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="tbxReqPopupDescription"
                                Display="Dynamic" ErrorMessage="Please Enter Description" ForeColor="Red" SetFocusOnError="True"
                                ValidationGroup="VgOne"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblRequiredBefo" runat="server" Text="Required Before" CssClass="black"></asp:Label>
                            <span class="errormsg">*</span><span> :</span>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtRequiredBefore" runat="server" class="smallinput_t" ValidationGroup="VgOne"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRequiredBefore"
                                EnableViewState="true" ViewStateMode="Enabled" Format="dd-MMM-yyyy" OnClientDateSelectionChanged="checkDate">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left">
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="rfvRequiredBefore" runat="server" ControlToValidate="txtRequiredBefore"
                                Display="Dynamic" ErrorMessage="Please Select a Date" ForeColor="Red" SetFocusOnError="True"
                                ValidationGroup="VgOne"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>--%>
                <asp:UpdatePanel ID="upd" runat="server">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnSave" />
                        <asp:PostBackTrigger ControlID="btnRemove" />
                    </Triggers>
                    <ContentTemplate>
                        <table cellpadding="5" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblPartNumber" runat="server" Text="Part Number" 
                                        CssClass="black" meta:resourcekey="lblPartNumberResource1"></asp:Label>
                                    <span class="errormsg">*</span><span> :</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxPartNumber" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                        MaxLength="50" Width="80%" ValidationGroup="VgOne" 
                                        meta:resourcekey="tbxPartNumberResource1"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="black" 
                                        ValidationGroup="VgOne" meta:resourcekey="lblQuantityResource1"></asp:Label>
                                    <span class="errormsg">*</span><span> :</span>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="tbxReqPopupQuantity" runat="server" AutoCompleteType="Disabled"
                                        CssClass="smallinput_t" MaxLength="9" Width="80%" ValidationGroup="VgOne" 
                                        meta:resourcekey="tbxReqPopupQuantityResource1"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Delete" CausesValidation="False"
                                        CssClass="blue_button" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None"
                                        Height="25px" OnClick="btnRemove_Click" 
                                        meta:resourcekey="btnRemoveResource1" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CommandName="Save" CausesValidation="False"
                                        CssClass="blue_button" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None"
                                        Height="25px" OnClick="btnSave_Click" 
                                        meta:resourcekey="btnSaveResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfvPartNumber" runat="server" ControlToValidate="tbxPartNumber"
                                        Display="Dynamic" ErrorMessage="Please Enter Part Number" ForeColor="Red" SetFocusOnError="True"
                                        ValidationGroup="VgOne" meta:resourcekey="rfvPartNumberResource1"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="tbxReqPopupQuantity"
                                        Display="Dynamic" ErrorMessage="Please Enter Quantity" ForeColor="Red" SetFocusOnError="True"
                                        ValidationGroup="VgOne" meta:resourcekey="rfvQuantityResource1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rgxQuantity" runat="server" ControlToValidate="tbxReqPopupQuantity"
                                        Display="Dynamic" ErrorMessage="Please Enter Numeric Data" ForeColor="Red" ValidationExpression="^(\s*)[1-9][0-9]{0,9}(\s*)$"
                                        ValidationGroup="VgOne" meta:resourcekey="rgxQuantityResource1"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDescription" runat="server" Text="Description" 
                                        CssClass="black" meta:resourcekey="lblDescriptionResource1"></asp:Label>
                                    <span class="errormsg">*</span><span> :</span>
                                </td>
                                <td rowspan="3" valign="top">
                                    <asp:TextBox ID="tbxReqPopupDescription" runat="server" AutoCompleteType="Disabled"
                                        CssClass="smallinput_t_multilinetextbox" TextMode="MultiLine" Width="80%" Height="80px"
                                        ValidationGroup="VgOne" meta:resourcekey="tbxReqPopupDescriptionResource1"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblMake" runat="server" Text="Make" CssClass="black" 
                                        meta:resourcekey="lblMakeResource1"></asp:Label>
                                    <span class="errormsg">*</span><span> :</span>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="tbxMake" runat="server" AutoCompleteType="Disabled" ValidationGroup="VgOne"
                                        CssClass="smallinput_t" MaxLength="50" Width="80%" 
                                        meta:resourcekey="tbxMakeResource1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfvMake" runat="server" ControlToValidate="tbxMake"
                                        Display="Dynamic" ErrorMessage="Please Enter Make Value" ForeColor="Red" SetFocusOnError="True"
                                        ValidationGroup="VgOne" meta:resourcekey="rfvMakeResource1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblRequiredBefo" runat="server" Text="Required Before" 
                                        CssClass="black" meta:resourcekey="lblRequiredBefoResource1"></asp:Label>
                                    <span class="errormsg">*</span><span> </span>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRequiredBefore" runat="server" class="smallinput_t" 
                                        ValidationGroup="VgOne" meta:resourcekey="txtRequiredBeforeResource1"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtRequiredBefore0_CalendarExtender" runat="server" 
                                        TargetControlID="txtRequiredBefore" ViewStateMode="Enabled" 
                                        Format="dd-MMM-yyyy" OnClientDateSelectionChanged="checkDate" Enabled="True">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="tbxReqPopupDescription"
                                        Display="Dynamic" ErrorMessage="Please Enter Description" ForeColor="Red" SetFocusOnError="True"
                                        ValidationGroup="VgOne" meta:resourcekey="rfvDescriptionResource1"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfvRequiredBefore" runat="server" ControlToValidate="txtRequiredBefore"
                                        Display="Dynamic" ErrorMessage="Please Select a Date" ForeColor="Red" SetFocusOnError="True"
                                        ValidationGroup="VgOne" meta:resourcekey="rfvRequiredBeforeResource1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
