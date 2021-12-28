<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddInventory.ascx.cs"
    Inherits="ICBrowser.Web.Controls.AddInventory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
<link href="../Styles/main.css" rel="stylesheet" type="text/css" />
<link href="../Styles/style.css" rel="stylesheet" type="text/css" />--%>
<style type="text/css">
    .style3
    {
        width: 163px;
    }
    .style4
    {
        width: 176px;
    }
    .style5
    {
        width: 194px;
    }
</style>
<div style="height: 80%; width: 900px; padding-left: 30px" class="popupboxWebControl">
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <table style="height: 100%;" width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="popupbox-lefttop-corner">
                    </td>
                    <td class="popupbox-topbg">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="95%" align="left" class="popupbox-header">
                                    <asp:Label ID="lblReqPopupHeader" CssClass="header" runat="server" 
                                        Text="Add Inventory" meta:resourcekey="lblReqPopupHeaderResource1"></asp:Label>
                                </td>
                                <td width="5%" align="right" valign="bottom" class="popupbox-header">
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
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="top" width="50%" style="padding-top: 10px">
                                    <table width="100%" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top" align="right" width="40%">
                                                <asp:Label ID="lblComponentName" runat="server" Text="Part Number" 
                                                    CssClass="text" meta:resourcekey="lblComponentNameResource1"></asp:Label>
                                                <span class="errormsg">*</span><span> :</span>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:TextBox ID="TxtComponentName" CssClass="smallinput_t" ValidationGroup="VgOne"
                                                    runat="server" Width="99%" meta:resourcekey="TxtComponentNameResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td height="35px" align="left" valign="top">
                                                <asp:RequiredFieldValidator ID="reqComponentName" runat="server" ControlToValidate="TxtComponentName"
                                                    ErrorMessage="Part Number Required" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                    ValidationGroup="VgOne" meta:resourcekey="reqComponentNameResource1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right" style="width: 40%">
                                                <asp:Label ID="lblBrandname" runat="server" Text=" Make" CssClass="text" 
                                                    meta:resourcekey="lblBrandnameResource1"></asp:Label>
                                                <span class="errormsg">*</span><span> :</span>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:TextBox ID="TxtBrandName" CssClass="smallinput_t" ValidationGroup="VgOne" runat="server"
                                                    Width="99%" meta:resourcekey="TxtBrandNameResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td height="35px" align="left" valign="top">
                                                <asp:RequiredFieldValidator ID="rfvbrandname" runat="server" ControlToValidate="TxtBrandName"
                                                    ErrorMessage="Make Required" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                    ValidationGroup="VgOne" meta:resourcekey="rfvbrandnameResource1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <asp:Label ID="lblDescription" runat="server" Text="Description" 
                                                    CssClass="text" meta:resourcekey="lblDescriptionResource1"></asp:Label><span
                                                    class="errormsg">*</span><span> :</span>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:TextBox ID="TxtDescription" CssClass="smallinput_t_multilinetextbox" runat="server"
                                                    Width="99%" ValidationGroup="VgOne" TextMode="MultiLine" Height="50px" 
                                                    meta:resourcekey="TxtDescriptionResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td height="35px" align="left" valign="top">
                                                <asp:RequiredFieldValidator ID="rfvdesc" runat="server" ControlToValidate="TxtDescription"
                                                    ErrorMessage="Required" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                    ValidationGroup="VgOne" meta:resourcekey="rfvdescResource1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <asp:Label ID="lblAvailDate" runat="server" Text="Available Date" 
                                                    CssClass="text" meta:resourcekey="lblAvailDateResource1"></asp:Label>
                                                (dd-mm-yyyy) <span class="errormsg">*</span><span> :</span>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:TextBox ID="txtAvailfrom" runat="server" class="smallinput_t" 
                                                    ValidationGroup="VgOne" meta:resourcekey="txtAvailfromResource1"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                    TargetControlID="txtAvailfrom" ViewStateMode="Enabled" Format="dd-MMM-yyyy" 
                                                    Enabled="True">
                                                </asp:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td height="20px" align="left" valign="top">
                                                <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtAvailfrom"
                                                    Display="Dynamic" ErrorMessage="Please Select a Date" ForeColor="Red" SetFocusOnError="True"
                                                    ValidationGroup="VgOne" meta:resourcekey="rfvDateResource1"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <asp:Label ID="lblStockinHand" runat="server" Text=" Stock In Hand" 
                                                    CssClass="text" meta:resourcekey="lblStockinHandResource1"></asp:Label>
                                                <span class="errormsg">*</span><span> :</span>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:TextBox ID="TxtStockInHand" CssClass="smallinput_t" runat="server" Width="60%"
                                                    MaxLength="9" ValidationGroup="VgOne" 
                                                    meta:resourcekey="TxtStockInHandResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td height="35px" align="left" valign="top">
                                                <asp:RequiredFieldValidator ID="rfvstockinhand" runat="server" ControlToValidate="TxtStockInHand"
                                                    ErrorMessage="Stock In Hand Required" ForeColor="Red" SetFocusOnError="True"
                                                    Display="Dynamic" ValidationGroup="VgOne" 
                                                    meta:resourcekey="rfvstockinhandResource1" />
                                                <asp:RegularExpressionValidator ID="revtxtStockInHand" runat="server" ControlToValidate="TxtStockInHand"
                                                    ForeColor="Red" ValidationGroup="VgOne" 
                                                    ErrorMessage="Enter Numeric data !" Display="Dynamic"
                                                    ValidationExpression="^\d+$" meta:resourcekey="revtxtStockInHandResource1"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top" width="50%" style="padding-top: 10px">
                                    <table width="100%" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top" align="right" width="45%">
                                                <asp:Label ID="lblQuantity" runat="server" Text=" Quantity" CssClass="text" 
                                                    meta:resourcekey="lblQuantityResource1"></asp:Label>
                                                <span class="errormsg">*</span><span> :</span>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:TextBox ID="TxtQuantity" CssClass="smallinput_t" runat="server" Width="60%"
                                                    MaxLength="9" ValidationGroup="VgOne" 
                                                    meta:resourcekey="TxtQuantityResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td height="35px" align="left" valign="top">
                                                <asp:RequiredFieldValidator ID="rfvqnty" runat="server" ControlToValidate="TxtQuantity"
                                                    ErrorMessage="Quantity Required" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                    ValidationGroup="VgOne" meta:resourcekey="rfvqntyResource1" />
                                                <asp:RegularExpressionValidator ID="revtxtQuantity" runat="server" ValidationGroup="VgOne"
                                                    ControlToValidate="TxtQuantity" ErrorMessage="Please enter Numeric Data" ValidationExpression="^(\s*)\d+(\s*)$"
                                                    ForeColor="Red" meta:resourcekey="revtxtQuantityResource1"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right" width="45%">
                                                <asp:Label ID="lblPriceinINR" runat="server" Text=" Price In INR" 
                                                    CssClass="text" meta:resourcekey="lblPriceinINRResource1"></asp:Label>
                                                <span class="errormsg">*</span><span> :</span>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:TextBox ID="TxtPriceInINR" CssClass="smallinput_t" runat="server" Width="60%"
                                                    MaxLength="9" ValidationGroup="VgOne" 
                                                    meta:resourcekey="TxtPriceInINRResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td height="35px" valign="top" align="left">
                                                <asp:RequiredFieldValidator ID="rfvtxtPrcInINR" runat="server" ControlToValidate="TxtPriceInINR"
                                                    ErrorMessage="Price In INR Required" ForeColor="Red" 
                                                    SetFocusOnError="True" Display="Dynamic"
                                                    ValidationGroup="VgOne" meta:resourcekey="rfvtxtPrcInINRResource1" />
                                                <asp:RegularExpressionValidator ID="revpriceinr" ControlToValidate="TxtPriceInINR"
                                                    ForeColor="Red" ValidationGroup="VgOne" runat="server" ErrorMessage="Enter Numeric data"
                                                    ValidationExpression="[0-9]*\.?[0-9]*" Text="Enter only Numeric data" 
                                                    meta:resourcekey="revpriceinrResource1"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right" width="45%">
                                                <asp:Label ID="lblPriceinUSD" runat="server" Text="Price In USD" 
                                                    CssClass="text" meta:resourcekey="lblPriceinUSDResource1"></asp:Label>
                                                <span class="errormsg">*</span><span> :</span>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:TextBox ID="TxtPriceInUSD" ValidationGroup="VgOne" CssClass="smallinput_t" runat="server"
                                                    MaxLength="9" Width="60%" meta:resourcekey="TxtPriceInUSDResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td height="35px" valign="top" align="left">
                                                <asp:RequiredFieldValidator ID="rfvPrcInUSD" runat="server" ControlToValidate="TxtPriceInUSD"
                                                    ErrorMessage="Price In USD Required" ForeColor="Red" 
                                                    SetFocusOnError="True" Display="Dynamic"
                                                    ValidationGroup="VgOne" meta:resourcekey="rfvPrcInUSDResource1" />
                                                <asp:RegularExpressionValidator ID="revpriceusd" ControlToValidate="TxtPriceInUSD"
                                                    ValidationGroup="VgOne" runat="server" ErrorMessage="Invalid Number" ForeColor="Red"
                                                    ValidationExpression="[0-9]*\.?[0-9]*" Text="Enter only Numeric data" 
                                                    meta:resourcekey="revpriceusdResource1"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right" width="45%">
                                                <asp:Label ID="lblPriceinCNY" runat="server" Text="Price In CNY" 
                                                    CssClass="text" meta:resourcekey="lblPriceinCNYResource1"></asp:Label>
                                                <span class="errormsg">*</span><span> :</span>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:TextBox ID="txtpriceinCNY" CssClass="smallinput_t" runat="server" Width="60%"
                                                    MaxLength="9" meta:resourcekey="txtpriceinCNYResource1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td height="35px" valign="top" align="left">
                                                <asp:RequiredFieldValidator ID="rfvpriceinCNY" runat="server" ControlToValidate="txtpriceinCNY"
                                                    ErrorMessage="Price In CNY Required" ForeColor="Red" 
                                                    SetFocusOnError="True" Display="Dynamic"
                                                    ValidationGroup="VgOne" meta:resourcekey="rfvpriceinCNYResource1" />
                                                <asp:RegularExpressionValidator ID="revpriceinCNY" ControlToValidate="txtpriceinCNY"
                                                    ValidationGroup="VgOne" runat="server" ErrorMessage="Invalid Number"
                                                    ForeColor="Red" ValidationExpression="[0-9]*\.?[0-9]*" 
                                                    Text="Enter only Numeric data" meta:resourcekey="revpriceinCNYResource1"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right" width="45%">
                                                <asp:Label ID="lblDataSheetURL" runat="server" Text=" DataSheet URL :" 
                                                    CssClass="text" meta:resourcekey="lblDataSheetURLResource1"></asp:Label>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:FileUpload ID="FuploadAdd" runat="server" CssClass="browse_but" 
                                                    meta:resourcekey="FuploadAddResource1" />
                                                &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;OR
                                                <asp:TextBox ID="txtDatasheetlink" runat="server" CssClass="smallinput_t" 
                                                    Width="60%" meta:resourcekey="txtDatasheetlinkResource1"></asp:TextBox>
                                                (<asp:Label ID="lblfrex" runat="server" Text="For ex.:" 
                                                    meta:resourcekey="lblfrexResource1"></asp:Label>
                                                http://www.google.com)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblError" runat="server" CssClass="redmsg" Visible="False" 
                                                    meta:resourcekey="lblErrorResource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <table width="100%" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="right" width="50%">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CommandName="Save" CausesValidation="False"
                                                    Width="80px" CssClass="blue_button" BackColor="Transparent" BorderColor="Transparent"
                                                    BorderStyle="None" Height="25px" OnClick="btnSave_Click" 
                                                    meta:resourcekey="btnSaveResource1" />
                                            </td>
                                            <td align="left" style="padding-left: 10px" width="50%">
                                                <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Delete" CausesValidation="False"
                                                    Width="80px" CssClass="blue_button" BackColor="Transparent" BorderColor="Transparent"
                                                    BorderStyle="None" OnClick="btnRemove_Click" 
                                                    meta:resourcekey="btnRemoveResource1" />
                                            </td>
                                        </tr>
                                    </table>
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
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnRemove" />
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
</div>
