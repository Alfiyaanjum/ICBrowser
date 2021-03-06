<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="ICBrowser.Web.Register" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Detail.Master" %>
<%@ Register TagPrefix="cc1" Namespace="WebControlCaptcha" Assembly="WebControlCaptcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .CustomValidatorCalloutStyle div, .CustomValidatorCalloutStyle td
        {
            border: solid 1px blue;
            background-color: #ADD8E6;
        }
        .newStyle1
        {
            font-size: x-small;
        }
        .style1
        {
            width: 28%;
        }
    </style>
    <div>
        <asp:Panel runat="server" Visible="False" DefaultButton="btnSubmit" ID="pnlRegister"
            BackColor="#EFFBFE" meta:resourcekey="pnlRegisterResource1">
            <%--<div>
                <div>
                    <div>
                    </div>--%>
            <table width="100%" cellspacing="0" cellpadding="0">
                <tr style="height: 8px">
                    <td style="width: 100%" align="left">
                        <asp:Label ID="lblSuccess" runat="server" Font-Names="Verdana" Font-Size="12" CssClass="greenmsg"
                            Visible="false"></asp:Label>
                        <asp:Label ID="lblError" runat="server" Font-Names="Verdana" Font-Size="12" CssClass="redmsg"
                            Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
            <table style="border-top: 1px solid #069; border-left: 1px solid #069; border-right: 1px solid #069;"
                align="center" width="50%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <div>
                            <table width="100%">
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lblRegistationheader" runat="server" Text="New User Registration Form"
                                            CssClass="header" meta:resourcekey="lblRegistationheaderResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" colspan="3">
                                        <asp:LinkButton ID="lbtnPreview" runat="server" Text="Click here to view Membership Features"
                                            Font-Bold="true" OnClick="lbtnPreview_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="3%">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%" colspan="3">
                                        <asp:Label ID="lblcomment" runat="server" ForeColor="Red" Font-Names="Verdana" Font-Size="12"
                                            Text="Note:Fields Marked with * are mandatory" Style="font-weight: 700"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25.5%">
                                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                                            ID="lblRegister" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblRegisterResource1"
                                            Text="Register as a"></asp:Label>
                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                    </td>
                                    <td align="left" width="37%">
                                        <asp:DropDownList ID="ddlMemberType" runat="server" align="middle" CssClass="smallinput_t200_register"
                                            Font-Names="Verdana" Font-Size="12" TabIndex="1" Width="100%">
                                            <asp:ListItem Text="- Select -" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Buyer (Free)" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Buyer & Seller(Trial 30 Days)" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Buyer & Seller Platinum (Paid)" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" width="37%">
                                        <asp:RequiredFieldValidator ID="rfvMemberType" runat="server" ControlToValidate="ddlMemberType"
                                            Display="None" ErrorMessage="Please Select Membership Type" CssClass="lblRegInfo"
                                            ForeColor="Red" InitialValue="0" meta:resourcekey="rfvMemberTypeResource1" ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table cellpadding="0" width="100%">
                                <tr>
                                    <td align="right" style="width: 50%;">
                                        <div>
                                            <table cellpadding="0" style="width: 100%;">
                                                <tr>
                                                    <td>
                                                        <div>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" width="25%">
                                                                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                                                                            ID="lblFirstName" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblFirstNameResource1"
                                                                            Text="First Name"></asp:Label>
                                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                                    </td>
                                                                    <td align="left" style="width: 38%;">
                                                                        <asp:TextBox ID="tbxFirstName" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                                            Font-Names="Verdana" Font-Size="12" TabIndex="2" Width="100%"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="37%">
                                                                        <asp:RequiredFieldValidator ID="rfvCtN" runat="server" ControlToValidate="tbxFirstName"
                                                                            Display="None" ErrorMessage="Enter First Name" CssClass="lblRegInfo" ForeColor="Red"
                                                                            meta:resourcekey="rfvCtNResource1" ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="rgvCtn" runat="server" ControlToValidate="tbxFirstName"
                                                                            Display="None" ErrorMessage="Enter Text For Name" CssClass="lblRegInfo" ForeColor="Red"
                                                                            meta:resourcekey="regexvalContactNameTextResource1" ValidationExpression="^[^0-9]+$"
                                                                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" width="25%">
                                                                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                                                                            ID="lblLastName" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblLastNameResource1"
                                                                            Text="Last Name"></asp:Label>
                                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                                    </td>
                                                                    <td align="left" style="width: 38%;">
                                                                        <asp:TextBox ID="tbxLastName" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                                            Font-Names="Verdana" Font-Size="12" TabIndex="3" Width="100%"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="37%">
                                                                        <asp:RequiredFieldValidator ID="rfvLN" runat="server" ControlToValidate="tbxLastName"
                                                                            Display="None" ErrorMessage="Enter Last Name" CssClass="lblRegInfo" ForeColor="Red"
                                                                            meta:resourcekey="rfvLNResource1" ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="rgvLN" runat="server" ControlToValidate="tbxLastName"
                                                                            Display="None" ErrorMessage="Enter Text For Name" CssClass="lblRegInfo" ForeColor="Red"
                                                                            ValidationExpression="^[^0-9]+$" ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div>
                                                            <table cellpadding="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="25%">
                                                                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                                                                            ID="lblCompanyName" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblCompanyNameResource1"
                                                                            Text="Company Name"></asp:Label>
                                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                                    </td>
                                                                    <td align="left" style="width: 38%;">
                                                                        <asp:TextBox ID="tbxCompanyName" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                                            Font-Names="Verdana" Font-Size="12" meta:resourcekey="tbxCompanyNameResource1"
                                                                            TabIndex="4" Width="100%"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="37%">
                                                                        <asp:RequiredFieldValidator ID="rgvCN" runat="server" ControlToValidate="tbxCompanyName"
                                                                            Display="None" ErrorMessage="Enter Company Name" CssClass="lblRegInfo" ForeColor="Red"
                                                                            meta:resourcekey="rfvCompanyNameResource1" ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="rfvCN" runat="server" ControlToValidate="tbxCompanyName"
                                                                            Display="None" ErrorMessage="'&lt;' or '&gt;' are not allowed" CssClass="lblRegInfo"
                                                                            ForeColor="Red" meta:resourcekey="rCNResource1" ValidationExpression="^((?![&lt;&gt;]).)*$"
                                                                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div>
                                                            <table cellpadding="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="25%">
                                                                        <%--<span style="color: Red; font-family: Verdana; font-size: 12;">*</span>--%>
                                                                        <asp:Label ID="lblWebsite" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblWebsiteResource1"
                                                                            Text="Website"></asp:Label>
                                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                                    </td>
                                                                    <td align="left" style="width: 38%;">
                                                                        <asp:TextBox ID="tbxWebsite" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                                            Font-Names="Verdana" Font-Size="12" meta:resourcekey="tbxWebsiteResource1" TabIndex="5"
                                                                            Width="100%"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" width="37%">
                                                                        <asp:RegularExpressionValidator ID="rgvWB" runat="server" ControlToValidate="tbxWebsite"
                                                                            Display="None" ErrorMessage="Enter Valid Website" CssClass="lblRegInfo" ForeColor="Red"
                                                                            meta:resourcekey="regexvalWebsiteResource1" ValidationExpression="(http://([\w-]+\.)|([\w-]+\.))+[\w-]*(/[\w- ./?%=]*)?"
                                                                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                                        <%--  <asp:RequiredFieldValidator ID="rfqWebsite" runat="server" ControlToValidate="tbxWebsite"
                                                                            Display="None" ErrorMessage="Enter Website URL" CssClass="lblRegInfo" ForeColor="Red"
                                                                            ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div>
                                                            <table cellpadding="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="25%">
                                                                       <%-- <span style="color: Red; font-family: Verdana; font-size: 12;">*</span>--%><asp:Label
                                                                            ID="lblMobile" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblMobileResource1"
                                                                            Text="Mobile"></asp:Label>
                                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                                        <br />
                                                                        <asp:Label ID="lblMobexa" runat="server" Style="font-size: x-small; color: #000000;
                                                                            font-family: Verdana" Text="(ex:91-XXXXXXXXXX)"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="9%">
                                                                        <asp:TextBox ID="txtCCdMobno" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                                            Font-Names="Verdana" Font-Size="8" MaxLength="4" meta:resourcekey="tbxCountryCodeResource1"
                                                                            TabIndex="6" Width="100%" Enabled="false"></asp:TextBox>
                                                                        <asp:TextBoxWatermarkExtender ID="txtWExtMobno" runat="server" TargetControlID="txtCCdMobno"
                                                                            WatermarkCssClass="watermarked" WatermarkText="+91"/>
                                                                    </td>
                                                                    <td align="right" style="width: 1%; font-family: Verdana; font-size: 12;">
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:TextBox ID="txtMobNo" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                                            Font-Names="Verdana" Font-Size="8" MaxLength="10" meta:resourcekey="txtMobNoNumberResource1"
                                                                            TabIndex="7" Width="97%"></asp:TextBox>
                                                                        <asp:TextBoxWatermarkExtender ID="txtWMMob" runat="server" TargetControlID="txtMobNo"
                                                                            WatermarkCssClass="watermarked" WatermarkText="Mobile Number" />
                                                                    </td>
                                                                    <td align="left" width="37%">
                                                                        <asp:RegularExpressionValidator ID="rgvCCMb" runat="server" ControlToValidate="txtCCdMobno"
                                                                            Display="None" ErrorMessage="Enter Valid Country Code" CssClass="lblRegInfo"
                                                                            ForeColor="Red" meta:resourcekey="regexvalCountryCodeResource1" ValidationExpression="^[0-9]{0,4}"
                                                                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                                      <%--  <asp:RequiredFieldValidator ID="rfvMobno" runat="server" ControlToValidate="txtMobNo"
                                                                            Display="None" ErrorMessage="Enter Mobile no." CssClass="lblRegInfo" ForeColor="Red"
                                                                            meta:resourcekey="rfvMobnoResource1" ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>--%>
                                                                        <asp:RegularExpressionValidator ID="rgvMobno" runat="server" ControlToValidate="txtMobNo"
                                                                            Display="None" ErrorMessage="Enter Valid Mobile no." CssClass="lblRegInfo" ForeColor="Red"
                                                                            meta:resourcekey="rgvMobnoResource1" ValidationExpression="^[0-9]{10}"
                                                                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div>
                                                            <table cellpadding="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="25%">
                                                                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                                                                            ID="lblPhoneNumber" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblPhoneNumberResource1"
                                                                            Text="Phone Number"></asp:Label>
                                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                                        <br />
                                                                        <asp:Label ID="lblPhneNo" runat="server" Style="font-size: x-small; color: #000000;
                                                                            font-family: Verdana" Text="(ex:91-XXX-XXXXXXXX)"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="9%">
                                                                        <asp:TextBox ID="tbxCountryCode" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                                            Font-Names="Verdana" Font-Size="8" MaxLength="4" meta:resourcekey="tbxCountryCodeResource1"
                                                                            TabIndex="8" Width="100%" Enabled="false"></asp:TextBox>
                                                                        <asp:TextBoxWatermarkExtender ID="TBWCountryCode" runat="server" TargetControlID="tbxCountryCode"
                                                                            WatermarkCssClass="watermarked" WatermarkText="+91" />
                                                                    </td>
                                                                    <td align="right" style="width: 1%; font-family: Verdana; font-size: 12;">
                                                                    </td>
                                                                    <td align="left" width="9%">
                                                                        <asp:TextBox ID="tbxCityCode" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                                            Font-Names="Verdana" Font-Size="8" MaxLength="4" meta:resourcekey="tbxCityCodeResource1"
                                                                            TabIndex="9" Width="100%"></asp:TextBox>
                                                                        <asp:TextBoxWatermarkExtender ID="TBWCityCode" runat="server" TargetControlID="tbxCityCode"
                                                                            WatermarkCssClass="watermarked" WatermarkText="City Code" />
                                                                    </td>
                                                                    <td align="right" style="width: 1%; font-family: Verdana; font-size: 12;">
                                                                    </td>
                                                                    <td align="left" width="18%">
                                                                        <asp:TextBox ID="tbxPhoneNumber" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                                            Font-Names="Verdana" Font-Size="8" MaxLength="10" meta:resourcekey="tbxPhoneNumberResource1"
                                                                            TabIndex="10" Width="97%"></asp:TextBox>
                                                                        <asp:TextBoxWatermarkExtender ID="TBWPhoneNumber" runat="server" TargetControlID="tbxPhoneNumber"
                                                                            WatermarkCssClass="watermarked" WatermarkText="Phone Number" />
                                                                    </td>
                                                                    <td align="left" width="37%">
                                                                        <asp:RegularExpressionValidator ID="rgvCC" runat="server" ControlToValidate="tbxCountryCode"
                                                                            Display="None" ErrorMessage="Enter Valid Country Code" CssClass="lblRegInfo"
                                                                            ForeColor="Red" meta:resourcekey="regexvalCountryCodeResource1" ValidationExpression="^[0-9]{0,4}"
                                                                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                                        <asp:RegularExpressionValidator ID="rgvCtyCd" runat="server" ControlToValidate="tbxCityCode"
                                                                            Display="None" ErrorMessage="Enter Valid City Code" CssClass="lblRegInfo" ForeColor="Red"
                                                                            meta:resourcekey="rgvCtyCdResource1" ValidationExpression="^[0-9]{0,4}" ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rfvPNB" runat="server" ControlToValidate="tbxPhoneNumber"
                                                                            Display="None" ErrorMessage="Enter Phone no." CssClass="lblRegInfo" ForeColor="Red"
                                                                            meta:resourcekey="rfvPhoneNumberResource1" ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="rgvPNB" runat="server" ControlToValidate="tbxPhoneNumber"
                                                                            Display="None" ErrorMessage="Enter Valid Phone no." CssClass="lblRegInfo" ForeColor="Red"
                                                                            meta:resourcekey="regexvalPhoneNumberResource1" ValidationExpression="^[0-9]{0,11}"
                                                                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        
                                                        <div>
                                                            <table cellpadding="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="25%">
                                                                        <asp:Label ID="lblFax" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblFaxResource1"
                                                                            Text="Fax"></asp:Label>
                                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                                        <br />
                                                                        <asp:Label ID="Label1" runat="server" Style="font-size: x-small; color: #000000;
                                                                            font-family: Verdana" Text="(ex:91-XXX-XXXXXXXX)"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="9%">
                                                                        <asp:TextBox ID="tbxCountryCode1" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                                            Font-Names="Verdana" Font-Size="8" MaxLength="4" meta:resourcekey="tbxCountryCodeResource1"
                                                                            TabIndex="11" Width="100%" Enabled="false"></asp:TextBox>
                                                                        <asp:TextBoxWatermarkExtender ID="TBWCountryCode1" runat="server" TargetControlID="tbxCountryCode1"
                                                                            WatermarkCssClass="watermarked" WatermarkText="+91" />
                                                                    </td>
                                                                    <td align="right" style="width: 1%; font-family: Verdana; font-size: 12;">
                                                                    </td>
                                                                    <td align="left" width="9%">
                                                                        <asp:TextBox ID="tbxCityCode1" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                                            Font-Names="Verdana" Font-Size="8" MaxLength="4" meta:resourcekey="tbxCountryCodeResource1"
                                                                            TabIndex="12" Width="100%"></asp:TextBox>
                                                                        <asp:TextBoxWatermarkExtender ID="TBWCityCode1" runat="server" TargetControlID="tbxCityCode1"
                                                                            WatermarkCssClass="watermarked" WatermarkText="City Code" />
                                                                    </td>
                                                                    <td align="right" style="width: 1%; font-family: Verdana; font-size: 12;">
                                                                    </td>
                                                                    <td align="left" width="18%">
                                                                        <asp:TextBox ID="tbxFax" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                                            Font-Names="Verdana" Font-Size="8" MaxLength="10" meta:resourcekey="tbxFaxResource1"
                                                                            TabIndex="13" Width="97%"></asp:TextBox>
                                                                        <asp:TextBoxWatermarkExtender ID="TBWFax" runat="server" TargetControlID="tbxFax"
                                                                            WatermarkCssClass="watermarked" WatermarkText="Fax Number" />
                                                                    </td>
                                                                    <td align="left" width="37%">
                                                                        <asp:RegularExpressionValidator ID="rgvCCF" runat="server" ControlToValidate="tbxCountryCode1"
                                                                            Display="None" ErrorMessage="Enter Valid Country Code" CssClass="lblRegInfo"
                                                                            ForeColor="Red" meta:resourcekey="rgvCCFResource1" ValidationExpression="^[0-9]{0,4}"
                                                                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                                        <asp:RegularExpressionValidator ID="rgvCtyCdF" runat="server" ControlToValidate="tbxCityCode1"
                                                                            Display="None" ErrorMessage="Enter Valid City Code" CssClass="lblRegInfo" ForeColor="Red"
                                                                            meta:resourcekey="rgvCtyCdFResource1" ValidationExpression="^[0-9]{0,4}" ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                                        <asp:RegularExpressionValidator ID="rgvFX" runat="server" ControlToValidate="tbxFax"
                                                                            Display="None" ErrorMessage="Enter Valid Fax no." CssClass="lblRegInfo" ForeColor="Red"
                                                                            meta:resourcekey="regexvalFaxResource1" ValidationExpression="^[0-9]{0,10}" ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>

                                                       
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table align="center" width="100%">
                                <tr>
                                    <td>
                                       <div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" width="25%">
                                                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                                                            ID="GStLbl" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblPrimaryAddressResource1"
                                                            Text="Address"></asp:Label>
                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                    </td>
                                                    <td align="left" width="38%">
                                                        <asp:TextBox ID="tbxPrimaryAddress" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                            Font-Names="Verdana" Font-Size="12" meta:resourcekey="tbxPrimaryAddressResource1"
                                                            TabIndex="14" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="left" width="37%">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxPrimaryAddress"
                                                            Display="None" ErrorMessage="Enter Address" CssClass="lblRegInfo" ForeColor="Red"
                                                            ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbxPrimaryAddress"
                                                            Display="None" ErrorMessage="'&lt;' or '&gt;' are not allowed" CssClass="lblRegInfo"
                                                            ForeColor="Red" meta:resourcekey="regexvalPrimaryAddressResource1" ValidationExpression="^((?![&lt;&gt;]).)*$"
                                                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" width="25%">
                                                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                                                            ID="lblPrimaryAddress" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblSecondaryAddressResource1"
                                                            Text="GST Number"></asp:Label>
                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                    </td>
                                                    <td align="left" width="38%">
                                                        <asp:TextBox ID="tbxGstNumber" MaxLength="15" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                            Font-Names="Verdana" Font-Size="12" meta:resourcekey="tbxSecondaryAddressResource1"
                                                            TabIndex="14" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="left" width="37%">
                                                        <asp:RequiredFieldValidator ID="rfvPA" runat="server" ControlToValidate="tbxPrimaryAddress"
                                                            Display="None" ErrorMessage="Enter GST number" CssClass="lblRegInfo" ForeColor="Red"
                                                            ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rgvPA" runat="server" ControlToValidate="tbxPrimaryAddress"
                                                            Display="None" ErrorMessage="'&lt;' or '&gt;' are not allowed" CssClass="lblRegInfo"
                                                            ForeColor="Red" meta:resourcekey="regexvalPrimaryAddressResource1" ValidationExpression="^((?![&lt;&gt;]).)*$"
                                                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" width="25%">
                                                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                                                            ID="lblPrimaryCity" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblPrimaryCityResource1"
                                                            Text="City"></asp:Label>
                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                    </td>
                                                    <td align="left" width="38%">
                                                        <asp:TextBox ID="tbxPrimaryCity" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                            Font-Names="Verdana" Font-Size="12" meta:resourcekey="tbxPrimaryCityResource1"
                                                            TabIndex="15" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="left" width="37%">
                                                        <asp:RequiredFieldValidator ID="rfvPC" runat="server" ControlToValidate="tbxPrimaryCity"
                                                            Display="None" ErrorMessage="Enter City" CssClass="lblRegInfo" ForeColor="Red"
                                                            meta:resourcekey="rfvPrimaryCityResource1" ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rgvPC" runat="server" ControlToValidate="tbxPrimaryCity"
                                                            Display="None" ErrorMessage="Enter Text For City" CssClass="lblRegInfo" ForeColor="Red"
                                                            meta:resourcekey="regexvalPrimaryCityTextResource1" ValidationExpression="^[^0-9]+$"
                                                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" width="25%">
                                                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                                                            ID="lblPrimaryState" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblPrimaryStateResource1"
                                                            Text="State/Province"></asp:Label>
                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                    </td>
                                                    <td align="left" width="38%">
                                                        <asp:TextBox ID="tbxPrimaryState" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                            Font-Names="Verdana" Font-Size="12" meta:resourcekey="tbxPrimaryStateResource1"
                                                            TabIndex="16" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="left" width="37%">
                                                        <asp:RegularExpressionValidator ID="rgvPS" runat="server" ControlToValidate="tbxPrimaryState"
                                                            Display="None" ErrorMessage="Enter Text For State" CssClass="lblRegInfo" ForeColor="Red"
                                                            meta:resourcekey="regexvalPrimaryStateTextResource1" ValidationExpression="^[^0-9]+$"
                                                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="rfvPS" runat="server" ControlToValidate="tbxPrimaryState"
                                                            Display="None" ErrorMessage="Enter State" CssClass="lblRegInfo" ForeColor="Red"
                                                            meta:resourcekey="rfvPSResource1" ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" width="25%">
                                                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                                                            ID="lblPrimaryCountry" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblPrimaryCountryResource1"
                                                            Text="Country"></asp:Label>
                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                    </td>
                                                    <td align="left" width="38%">
                                                        <%--<asp:DropDownList ID="ddlPrimaryCountry" runat="server" align="middle" AutoPostBack="false"
                                                            CssClass="smallinput_t200_register" Font-Names="Verdana" Font-Size="12" meta:resourcekey="ddlPrimaryCountryResource1"
                                                            TabIndex="17" Width="100%">
                                                        </asp:DropDownList>--%>
                                                        <asp:TextBox ID="tbxPrimaryCountry" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                                            Font-Names="Verdana" Font-Size="12" meta:resourcekey="tbxCompanyNameResource1"
                                                                            TabIndex="4" Width="100%"  Enabled="false" ></asp:TextBox>
                                                        <asp:TextBoxWatermarkExtender ID="tbxPrimaryExtender1" runat="server" TargetControlID="tbxPrimaryCountry"
                                                                            WatermarkCssClass="watermarked" WatermarkText="INDIA"/>
                                                    </td>
                                                    <td align="left" width="37%">
                                                        <asp:RequiredFieldValidator ID="rfvPCctr" runat="server" ControlToValidate="tbxPrimaryCountry"
                                                            Display="None" ErrorMessage="Please Select Country" CssClass="lblRegInfo" ForeColor="Red"
                                                            InitialValue="0" meta:resourcekey="rfvPrimaryCountryResource1" ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" width="25%">
                                                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                                                            ID="lblPrimaryZip" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblPrimaryZipResource1"
                                                            Text="Zip Code"></asp:Label>
                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                    </td>
                                                    <td align="left" width="38%">
                                                        <asp:TextBox ID="tbxPrimaryZip" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                            Font-Names="Verdana" Font-Size="12" MaxLength="7" meta:resourcekey="tbxPrimaryZipResource1"
                                                            TabIndex="18" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="left" width="37%">
                                                        <asp:RequiredFieldValidator ID="rfvPZ" runat="server" ControlToValidate="tbxPrimaryZip"
                                                            Display="None" ErrorMessage="Enter Zip Code" CssClass="lblRegInfo" ForeColor="Red"
                                                            meta:resourcekey="rfvPrimaryZipResource1" ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                                                        <%--<asp:RegularExpressionValidator ID="rgvPZ" runat="server" ErrorMessage="Enter Valid Zip Code"
                                                            ControlToValidate="tbxPrimaryZip" ValidationExpression="^[0-9]{7}" ForeColor="Red"
                                                            CssClass="lblRegInfo" Display="None" ValidationGroup="ValidateToSubmit" meta:resourcekey="regexvalPrimaryZipResource1"></asp:RegularExpressionValidator>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <%-- <div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" width="25%">
                                                        <asp:Label ID="lblPanNumber" runat="server" CssClass="lblRegInfo" Text="TIN"></asp:Label>
                                                        <span style="font-family: Verdana; font-size: 12;">:</span><br />
                                                        <asp:Label ID="Label2" runat="server" Font-Names="Verdana" Font-Size="8" Text="(Taxpayer Identification Number)"></asp:Label>
                                                    </td>
                                                    <td align="left" width="38%">
                                                        <asp:TextBox ID="tbxPanNumber" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                            Font-Names="Verdana" Font-Size="12" MaxLength="12" TabIndex="17" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="left" width="37%">
                                                        <asp:RegularExpressionValidator ID="rgvPNO" runat="server" ControlToValidate="tbxPanNumber"
                                                            Display="None" ErrorMessage="Invalid TIN Number" CssClass="lblRegInfo" ForeColor="Red"
                                                            meta:resourcekey="rgvPNOResource1" ValidationExpression="^([a-zA-Z0-9]{12})$"
                                                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>--%>
                                        <div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" width="25%">
                                                        <asp:Label ID="lblMsn" runat="server" CssClass="lblRegInfo" Text="MSN"></asp:Label>
                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/msn.png" align="absmiddle" />
                                                    </td>
                                                    <td align="left" width="39%">
                                                        <asp:TextBox ID="tbxMsnId" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                            Font-Names="Verdana" Font-Size="12" TabIndex="19" Width="98%"></asp:TextBox>
                                                    </td>
                                                    <td align="left" width="38%">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" width="25%">
                                                        <asp:Label ID="lblSkype" runat="server" CssClass="lblRegInfo" Text="Skype"></asp:Label>
                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/skype.png" align="absmiddle" />
                                                    </td>
                                                    <td align="left" width="38%">
                                                        <asp:TextBox ID="tbxSkypeId" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                            Font-Names="Verdana" Font-Size="12" TabIndex="20" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="left" width="38%">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" width="25%">
                                                        <asp:Label ID="lblqq" runat="server" CssClass="lblRegInfo" Text="QQ"></asp:Label>
                                                        <span style="font-family: Verdana; font-size: 12;">:</span>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/qq.png" align="absmiddle" />
                                                    </td>
                                                    <td align="left" width="38%">
                                                        <asp:TextBox ID="tbxQQId" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                                                            Font-Names="Verdana" Font-Size="12" TabIndex="21" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="left" width="38%">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <%-- </div>
            </div>--%>
            <%--<div>--%>
            <table width="50%" align="center" style="border-left: 1px solid #069; border-right: 1px solid #069;">
                <tr>
                    <td align="left" width="25%">
                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                            ID="lblEmail" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblEmailResource1"
                            Text="E-mail"></asp:Label>
                        <span style="font-family: Verdana; font-size: 12;">:</span>
                    </td>
                    <td align="left" width="38%">
                        <asp:TextBox ID="tbxEmail" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                            Font-Names="Verdana" Font-Size="12" meta:resourcekey="tbxEmailResource1" TabIndex="22"
                            Width="100%"></asp:TextBox>
                    </td>
                    <td width="37%" align="left">
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbxEmail"
                            Display="None" ErrorMessage="Enter Email Address" CssClass="lblRegInfo" ForeColor="Red"
                            meta:resourcekey="rfvEmailResource1" ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rgvEmail" runat="server" ControlToValidate="tbxEmail"
                            Display="None" ErrorMessage="Enter Valid Email Address" CssClass="lblRegInfo"
                            ForeColor="Red" meta:resourcekey="regexvalEmailResource1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <%--</div>--%>
            <%--<div>--%>
            <table width="50%" align="center" style="border-left: 1px solid #069; border-right: 1px solid #069;">
                <tr>
                    <td align="left" width="25%">
                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                            ID="lblUserName" runat="server" CssClass="lblRegInfo" Text="Choose User Name"></asp:Label>
                        <span style="font-family: Verdana; font-size: 12;">:</span>
                    </td>
                    <td align="left" width="38%">
                        <asp:TextBox ID="tbxUserName" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                            Font-Names="Verdana" Font-Size="12" MaxLength="20" TabIndex="23" Width="100%"></asp:TextBox>
                    </td>
                    <td align="right" width="10%">
                        <asp:Button ID="btnAvailablility" runat="server" CssClass="blue_button" Font-Names="Verdana"
                            Font-Size="10" Height="25px" meta:resourcekey="btnAvailablilityResource1" OnClick="btnAvailablility_Click"
                            Text="Check" ValidationGroup="Validate" Width="62px" />
                    </td>
                    <td align="left" width="27%">
                        <asp:Image ID="imgAvail" runat="server" Height="16px" ImageUrl="Images/check.png"
                            Visible="false" Width="16px" />
                        <asp:Image ID="imgNotAvail" runat="server" Height="16px" ImageUrl="Images/del.png"
                            Visible="false" Width="16px" />
                    </td>
                </tr>
            </table>
            <%--</div>--%>
            <%--<div>--%>
            <table width="50%" align="center" style="border-left: 1px solid #069; border-right: 1px solid #069;">
                <tr>
                    <td align="left" width="25%">
                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                            ID="lblPassword" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblPasswordResource1"
                            Text="Password"></asp:Label>
                        <span style="font-family: Verdana; font-size: 12;">:</span>
                    </td>
                    <td align="left" width="38%">
                        <asp:TextBox ID="tbxPassword" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                            Font-Names="Verdana" Font-Size="12" meta:resourcekey="tbxPasswordResource1" TabIndex="24"
                            TextMode="Password" Width="100%"></asp:TextBox>
                    </td>
                    <td align="left" width="37%">
                        <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ControlToValidate="tbxPassword"
                            Display="None" ErrorMessage="Enter Password" CssClass="lblRegInfo" ForeColor="Red"
                            meta:resourcekey="rfvPasswordResource1" ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rgvPL" runat="server" ControlToValidate="tbxPassword"
                            Display="None" ErrorMessage="Minimum six characters required for password" CssClass="lblRegInfo"
                            ForeColor="Red" meta:resourcekey="regexvalPasswordLengthResource1" ValidationExpression="^.{6,}$"
                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <%--</div>--%>
            <%--<div>--%>
            <table width="50%" align="center" style="border-left: 1px solid #069; border-right: 1px solid #069;">
                <tr>
                    <td align="left" width="25%">
                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span><asp:Label
                            ID="lblConfirmPassword" runat="server" CssClass="lblRegInfo" meta:resourcekey="lblConfirmPasswordResource1"
                            Text="Confirm Password"></asp:Label>
                        <span style="font-family: Verdana; font-size: 12;">:</span>
                    </td>
                    <td align="left" width="38%">
                        <asp:TextBox ID="tbxConfirmPassword" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t_register"
                            Font-Names="Verdana" Font-Size="12" meta:resourcekey="tbxConfirmPasswordResource1"
                            TabIndex="25" TextMode="Password" Width="100%"></asp:TextBox>
                    </td>
                    <td align="left" width="37%">
                        <asp:RequiredFieldValidator ID="rfvCPwd" runat="server" ControlToValidate="tbxConfirmPassword"
                            Display="None" ErrorMessage="Enter Confirm Password" CssClass="lblRegInfo" ForeColor="Red"
                            meta:resourcekey="rfvconfirmpasswordresource1" ValidationGroup="ValidateToSubmit"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpCPwd" runat="server" ControlToCompare="tbxPassword"
                            ControlToValidate="tbxConfirmPassword" Display="None" ErrorMessage="Passwords don't match"
                            CssClass="lblRegInfo" ForeColor="Red" meta:resourcekey="cmpvalConfirmPasswordResource1"
                            ValidationGroup="ValidateToSubmit"></asp:CompareValidator>
                        <asp:RegularExpressionValidator ID="rgvPwdB" runat="server" ControlToValidate="tbxPassword"
                            Display="None" ErrorMessage="'&lt;','&gt;' or White Spaces are not allowed" CssClass="lblRegInfo"
                            ForeColor="Red" meta:resourcekey="regexvalPasswordBracketsResource1" ValidationExpression="^((?![&lt;&gt;\s]).)*$"
                            ValidationGroup="ValidateToSubmit"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <%--</div>--%>
            <%--<div>--%>
            <table width="50%" style="border-left: 1px solid #069; border-right: 1px solid #069;"
                align="center">
                <tr>
                    <td align="left" width="25%">
                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span>
                        <asp:Label ID="lblCaptchaPic" runat="server" CssClass="lblRegInfo" Text="Verification Code "></asp:Label><span
                            style="font-family: Verdana; font-size: 12;">:</span>
                    </td>
                    <td align="left" width="75%">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="100%">
                                    <cc1:CaptchaControl runat="server" ID="txtCaptcha" CaptchaBackgroundNoise="Medium"
                                        CssClass="lblRegInfo" TabIndex="26" CaptchaFontWarping="Medium" CaptchaMaxTimeout="240">
                                    </cc1:CaptchaControl>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <%--</div>--%>
            <%--<div>--%>
            <table width="50%" style="border-left: 1px solid #069; border-right: 1px solid #069;
                border-bottom: 1px solid #069;" align="center">
                <tr>
                    <td width="25%">
                    </td>
                    <td align="right" width="1%">
                        <asp:CheckBox ID="chk" runat="server" Checked="true" meta:resourcekey="cbxAcceptResource1"
                            TabIndex="36" />
                    </td>
                    <td style="width: 52%;" align="left">
                        <asp:Label runat="server" ID="lblAcceptTerms" Text="I accept the terms of" CssClass="lblRegInfo"
                            meta:resourcekey="lblAcceptTermsResource1"></asp:Label>
                        <asp:HyperLink ID="hlnkAgreement" runat="server" NavigateUrl="TermsAndConditions.aspx"
                            CssClass="lblRegInfo" Text="ICBROWSER LEGAL AGREEMENT" Target="_blank" meta:resourcekey="hlnkAgreementResource1"></asp:HyperLink>
                        <span style="color: Red; font-family: Verdana; font-size: 12;">*</span>
                    </td>
                    <td style="width: 23%;" align="left">
                        <asp:Label ID="lblAgreementMsg" runat="server" Visible="False" Text="Please accept ICBROWSER LEGAL AGREEMENT"
                            Style="color: #FF0000" CssClass="lblRegInfo" meta:resourcekey="lblAgreementMsgResource1"></asp:Label>
                    </td>
                </tr>
            </table>
            <%--</div>--%>
            <%--<div>--%>
            <table align="center">
                <tr>
                    <td>
                        <asp:Button align="right" runat="server" ID="btnSubmit" CssClass="blue_button" Text="Register"
                            OnClick="btnSubmit_Click" ValidationGroup="ValidateToSubmit" Font-Names="Verdana"
                            Font-Size="12" meta:resourcekey="btnSubmitResource1" />
                    </td>
                    <td>
                        <asp:Button align="left" runat="server" ID="btnClear" CssClass="blue_button" Text="Clear"
                            Font-Names="Verdana" Font-Size="12" OnClick="btnClear_Click" meta:resourcekey="btnClearResource1" />
                    </td>
                </tr>
            </table>
            <%--</div>--%>
        </asp:Panel>
    </div>
    <div>
        <table>
            <tr>
                <td align="center">
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
                    <asp:ModalPopupExtender ID="modpopPreview" runat="server" PopupControlID="pnlPreview"
                        TargetControlID="LinkButton1" BackgroundCssClass="modalBackground" DynamicServicePath=""
                        Enabled="True">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlPreview" runat="server" meta:resourcekey="pnlPreviewResource1">
                        <asp:UpdatePanel runat="server" ID="upnlPreview">
                            <ContentTemplate>
                                <div style="height: 100%; width: 100%;" class="popupbox">
                                    <table style="height: 100%;" width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="popupbox-lefttop-corner">
                                            </td>
                                            <td class="popupbox-topbg">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="97%" align="left" class="popupbox-header">
                                                            <asp:Label ID="lblPreview" runat="server" Text="Membership Features" CssClass="title"></asp:Label>
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
                                            <td align="center" valign="top" class="popupbox-content">
                                                <table width="100%" style="height: 100%;" border="0" cellpadding="5" cellspacing="0">
                                                    <tr id="trUploadedFile" runat="server">
                                                        <td id="Td1" align="left" runat="server">
                                                            <asp:ImageButton ID="ibtnPreview" runat="server" Visible="False" OnClick="ibtnPreview_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="btnPreviewClose" runat="server" Text="Close" Width="60px" CausesValidation="False"
                                                                CssClass="blue_button" OnClick="btnPreviewClose_Click" meta:resourcekey="btnPreviewCloseResource1" />
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
                            </Triggers>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <div style="text-align: left">
        <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" ShowSummary="false"
            Font-Names="Verdana" Font-Size="12" ShowMessageBox="true" ValidationGroup="ValidateToSubmit" />
        <asp:ValidationSummary ID="valSummary1" runat="server" DisplayMode="BulletList" ShowSummary="false"
            Font-Names="Verdana" Font-Size="12" ShowMessageBox="true" ValidationGroup="Validate" />
    </div>
</asp:Content>
