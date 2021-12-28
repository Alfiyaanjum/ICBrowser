<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="ICBrowser.Web.ChangePassword" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        h4
        {
            font: normal 21px Tahoma;
            color: #0e74aa;
            padding: 0;
            margin: 0;
        }
        .padding2
        {
            padding: 2px;
        }
        .padding5
        {
            padding: 5px;
        }
        .padding7
        {
            padding: 5px;
        }
        
        .paddingB5
        {
            padding-bottom: 5px;
        }
        .paddingLeft
        {
            padding-left: 130px;
        }
        .paddingtop28
        {
            padding-top: 28px;
        }
        .paddingtop18
        {
            padding-top: 18px;
        }
        .padding10
        {
            padding: 10px;
        }
        .paddingT5B10L10
        {
            padding: 5px 0 10px 10px;
        }
        .paddingT10B3L10
        {
            padding: 10px 0 3px 10px;
        }
        .paddingT5B15L20
        {
            padding: 5px 0 15px 20px;
        }
        .paddingL5
        {
            padding-left: 5px;
        }
        .paddingT5R5B5L15
        {
            padding: 5px 5px 5px 15px;
        }
        .center_wrapper
        {
            width: 1000px;
            margin: 0 auto;
            padding-top: 10px;
            text-align: center;
            display: block;
            float: none;
        }
        .login
        {
            width: 806px;
            padding: 0;
            margin: 0 auto;
            display: block;
        }
        .login-whitebox-lefttop-corner
        {
            background: url(../images/login-whitebox-lefttop.gif) no-repeat left bottom;
            width: 11px;
            height: 9px;
        }
        
        .login-whitebox-righttop-corner
        {
            background: url(../images/login-whitebox-righttop.gif) no-repeat left bottom;
            width: 11px;
            height: 9px;
        }
        
        .login-whitebox-leftbtm-corner
        {
            background: url(../images/login-whitebox-leftbtm.gif) no-repeat left top;
            width: 11px;
            height: 9px;
        }
        
        
        .login-whitebox-rightbtm-corner
        {
            background: url(../images/login-whitebox-rightbtm.gif) no-repeat left top;
            width: 11px;
            height: 9px;
        }
        
        
        .login-whitebox-topbg
        {
            background: url(../images/login-whitebox-topbg.gif) repeat-x left bottom;
            height: 9px;
        }
        
        .login-whitebox-bottombg
        {
            background: url(../images/login-whitebox-btmbg.gif) repeat-x left top;
            height: 9px;
        }
        
        .login-whitebox-leftbg
        {
            background: url(../images/login-whitebox-leftbg.gif) repeat-y left top;
            width: 11px;
        }
        
        .login-whitebox-rightbg
        {
            background: url(../images/login-whitebox-rightbg.gif) repeat-y left top;
            width: 11px;
        }
        
        .login-whitebox-content
        {
            background-color: #effbfe;
            padding: 5px;
            font-size: 11px;
        }
        .redmsgSummary
        {
            width: 99%;
            margin: 15px 0 0 0;
            padding: 8px;
            font-family: Tahoma;
            display: block;
            float: left;
            color: #b70606;
            border: #dc6666 solid 1px;
            text-align: left;
            padding: 5px;
            font-weight: bold;
        }
        
        .greenmsg
        {
            width: 99%;
            margin: 15px 0 0 0;
            padding: 8px;
            font-family: Tahoma;
            display: block;
            float: left;
            color: #3b8704;
            border: #54de20 solid 1px;
            text-align: left;
            padding: 5px;
            background-color: #dcf9d8;
            font-weight: bold;
        }
        
        .redmsg
        {
            width: 99%;
            margin: 15px 0 0 0;
            padding: 8px;
            font-family: Tahoma;
            display: block;
            float: left;
            color: #b70606;
            border: #dc6666 solid 1px;
            text-align: left;
            padding: 5px;
            background-color: #fac8bf;
            font-weight: bold;
        }
        
        .smallinput_t200
        {
            border: 1px solid #0096d6;
            font-family: Tahoma;
            font-size: 11px;
            color: #434647;
            height: 22px;
            width: 200px;
            background-image: url(../images/textfieldbg.gif);
            background-repeat: repeat-x;
            background-position: left top;
            padding: 2px;
            padding: 2px;
        }
        /*.login-whitebox
        {
            width: 680px;
            float: left;
            padding: 0;
            margin: 0;
            display: block;
            color: #484244;
        }*/
        .signinbuttcp
        {
            background-image: url(../images/active_but.png);
            background-repeat: no-repeat;
            background-position: center center;
            width: 61px;
            height: 32px;
            text-align: center;
            font-family: Tahoma;
            font-weight: bold;
            font-size: 12px;
            color: #000;
            cursor: pointer;
            text-shadow: #FFFFFF 1px 1px;
            margin: 0 auto;
            border: 0px none;
            padding: 0;
            vertical-align: bottom;
        }
        
        
        
        .digi_wrapper
        {
            width: 680px;
            display: block;
            margin: 0px;
            padding: 0px;
            background-image: url(../images/main-bg.png);
            background-repeat: no-repeat;
            background-position: center top;
            float: left;
        }
        .breadcrumbs
        {
            font: normal 11px Tahoma;
            color: #484244;
            padding: 4px;
        }
    </style>
    <script type="text/javascript">
        function CheckConditionsCheck(source, args) {
            var checkbox = document.getElementById('chkTermsAndConditions');
            if (checkbox.checked == true)
                args.IsValid = true;
            else {
                args.IsValid = false;
            }
            return;
        }      
    </script>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return true;

            return false;
        }      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="cpPanel" runat="server" meta:resourcekey="cpPanelResource1" DefaultButton="btnSubmit"
        Height="100%" Width="100%">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="48%" align="left" valign="top">
                    <div>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="login-whitebox-lefttop-corner">
                                    &nbsp;
                                </td>
                                <td class="login-whitebox-topbg">
                                    &nbsp;
                                </td>
                                <td class="login-whitebox-righttop-corner">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="login-whitebox-leftbg">
                                    &nbsp;
                                </td>
                                <td align="left" valign="top" class="login-whitebox-content">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="100%" align="left" valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td align="left" valign="top" class="padding5" colspan="2" width="100%">
                                                            <asp:Label ID="lblSuccess" Visible="False" runat="server" CssClass="greenmsg" meta:resourcekey="lblSuccessResource1"></asp:Label>
                                                            <asp:Label ID="lblError" Visible="False" runat="server" CssClass="redmsg" meta:resourcekey="lblErrorResource1"></asp:Label>
                                                            <asp:ValidationSummary ID="vsSignIn" runat="server" ShowSummary="False" CssClass="redmsgSummary"
                                                                ValidationGroup="SignInValidation" meta:resourcekey="vsSignInResource1" />
                                                        </td>
                                                    </tr>
                                                    <tr class="headerback">
                                                        <td align="left" valign="top" class="padding5">
                                                            <asp:Label ID="lblChangePwd" runat="server" Text="Change Password" CssClass="header"
                                                                meta:resourcekey="lblChangePwdResource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" class="breadcrumbs">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="40%" align="right">
                                                            <span class="errormsg">*</span>
                                                            <asp:Label ID="lblOldPassword" runat="server" Text=" Current Password:" meta:resourcekey="lblOldPasswordResource1"></asp:Label>
                                                        </td>
                                                        <td align="left" class="padding5">
                                                            <asp:TextBox CssClass="smallinput_t200" ID="txtOldPassword" runat="server" ValidationGroup="ChangePassword"
                                                                TabIndex="1" TextMode="Password" meta:resourcekey="txtOldPasswordResource1" />
                                                            <asp:RequiredFieldValidator ID="reqValidatorUserName" runat="server" ControlToValidate="txtOldPassword"
                                                                ForeColor="Red" SetFocusOnError="True" ErrorMessage="Please Enter Current Password"
                                                                ValidationGroup="ChangePassword" Display="Dynamic" meta:resourcekey="reqValidatorUserNameResource1"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <span class="errormsg">*</span>
                                                            <asp:Label ID="lblNewPassword" runat="server" Text=" New Password:" meta:resourcekey="lblNewPasswordResource1"></asp:Label>
                                                        </td>
                                                        <td align="left" class="padding5">
                                                            <asp:TextBox AutoCompleteType="Disabled" ID="txtPassword" runat="server" CssClass="smallinput_t200"
                                                                TextMode="Password" TabIndex="2" meta:resourcekey="tbxPasswordResource1" Height="22px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Please Enter New Password"
                                                                ValidationGroup="ChangePassword" ControlToValidate="txtPassword" ForeColor="Red"
                                                                Display="Dynamic" meta:resourcekey="rfvPasswordResource1"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="regexvalPasswordLength" runat="server" ErrorMessage="Minimum six characters required"
                                                                Display="Dynamic" ValidationGroup="ChangePassword" ControlToValidate="txtPassword"
                                                                ForeColor="Red" ValidationExpression="^.{6,}$" meta:resourcekey="regexvalPasswordLengthResource1"></asp:RegularExpressionValidator>
                                                            <asp:RegularExpressionValidator ID="regexvalPasswordBrackets" runat="server" ErrorMessage="'<','>' or White Spaces are not allowed"
                                                                Display="Dynamic" ValidationGroup="ChangePassword" ControlToValidate="txtPassword"
                                                                ForeColor="Red" ValidationExpression="^((?![<>\s]).)*$" meta:resourcekey="regexvalPasswordBracketsResource1"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <span class="errormsg">*</span>
                                                            <asp:Label ID="lblConfirmPwd" runat="server" Text=" Confirm Password:" meta:resourcekey="lblConfirmPwdResource1"></asp:Label>
                                                        </td>
                                                        <td align="left" class="padding5">
                                                            <asp:TextBox ID="txtVerifyPassword" runat="server" CssClass="smallinput_t200" TextMode="Password"
                                                                TabIndex="3" MaxLength="15" ValidationGroup="ChangePassword" meta:resourcekey="txtVerifyPasswordResource1"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtVerifyPassword"
                                                                Display="Dynamic" ErrorMessage="Please Re-enter New Password" SetFocusOnError="True"
                                                                ValidationGroup="ChangePassword" ForeColor="Red" meta:resourcekey="rfvConfirmPasswordResource1"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="ConfirmPasswordCompareValidator" runat="server" ErrorMessage="Please Enter Valid Password"
                                                                Display="Dynamic" Text="Please Enter Valid Password" ControlToCompare="txtPassword"
                                                                ControlToValidate="txtVerifyPassword" ValidationGroup="ChangePassword" SetFocusOnError="True"
                                                                ForeColor="Red" meta:resourcekey="ConfirmPasswordCompareValidatorResource1"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                        </td>
                                                        <td height="30px">
                                                            <table width="100%">
                                                                <tr align="left">
                                                                    <td width="12%">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="blue_button" ValidationGroup="ChangePassword"
                                                                            TabIndex="4" OnClick="btnSubmit_Click" meta:resourcekey="btnSubmitResource1"
                                                                            Width="60px" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnCancel" runat="server" Text="Clear" CssClass="blue_button" TabIndex="5"
                                                                            meta:resourcekey="btnCancelResource1" CausesValidation="False" OnClick="btnCancel_Click"
                                                                            Width="60px" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="login-whitebox-rightbg">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="login-whitebox-leftbtm-corner">
                                    &nbsp;
                                </td>
                                <td class="login-whitebox-bottombg">
                                    &nbsp;
                                </td>
                                <td class="login-whitebox-rightbtm-corner">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
