<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ForgotPassword.aspx.cs" Inherits="ICBrowser.Web.ForgotPassword" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        h4
        {
            color: #0e74aa;
            padding: 0;
            margin: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlForgetPass" runat="server" DefaultButton="btnSubmit" meta:resourcekey="pnlForgetPassResource1">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="48%" align="left" valign="top">
                    <div class="login-whitebox">
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
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblSuccess" Visible="False" runat="server" CssClass="greenmsg" meta:resourcekey="lblSuccessResource1"></asp:Label>
                                                <asp:Label ID="lblError" Visible="False" runat="server" CssClass="redmsg" meta:resourcekey="lblErrorResource1"></asp:Label>
                                                <%--<asp:ValidationSummary ID="vsSignIn" runat="server" ShowSummary="False" CssClass="redmsgSummary"
                                                                ValidationGroup="SignInValidation" meta:resourcekey="vsSignInResource1" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr class="headerback">
                                                        <td width="40%" align="left">
                                                            <asp:Label ID="lblForPass" CssClass="header" runat="server" Text=" Forgot Password"
                                                                meta:resourcekey="lblForPassResource1"></asp:Label>
                                                            <br />
                                                        </td>
                                                        <td colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="padding: 5px" valign="top" width=" 40%">
                                                            <asp:Label ID="lblEmail" runat="server" Font-Size="Small" meta:resourcekey="lblEmailResource1"
                                                                Text="User Name:"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 20%">
                                                            <asp:TextBox ID="txtUserNameForgotPassword" runat="server" CssClass="smallinput_t200"
                                                                meta:resourcekey="txtUserNameForgotPasswordResource1" TabIndex="1" ValidationGroup="forgotpassword" />
                                                            <%--<asp:RegularExpressionValidator ID="revEmailToValidate"
                                                            runat="server" ControlToValidate="txtUserNameForgotPassword" ErrorMessage="Please enter a valid E-mail address"
                                                            Text="Please enter Valid Email Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            ValidationGroup="forgotpassword" Display="Dynamic" SetFocusOnError="True" 
                                                            ForeColor="Red" meta:resourcekey="revEmailToValidateResource1"></asp:RegularExpressionValidator>--%>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="reqValidatorUserName" runat="server" ControlToValidate="txtUserNameForgotPassword"
                                                                ForeColor="Red" meta:resourcekey="reqValidatorUserNameResource1" SetFocusOnError="True"
                                                                Text="Please enter User Name" ValidationGroup="forgotpassword"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblfrgtmsg" runat="server" Text="Note: New password will be sent to your registered email address."
                                                                meta:resourcekey="lblfrgtmsgResource1" ForeColor="Blue"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="40%">
                                                        </td>
                                                        <td align="left">
                                                            <br />
                                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="blue_button" ValidationGroup="forgotpassword"
                                                                TabIndex="4" OnClick="btnSubmit_Click" meta:resourcekey="btnSubmitResource1" />
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
