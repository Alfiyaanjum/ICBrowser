<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ForgetPassword.aspx.cs" Inherits="ICBrowser.Web.Account.ForgetPassword"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Panel ID="pnlForPass" runat="server">
            <table bgcolor="#99CCFF">
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="lblforpass" runat="server" Text="Forgot Password"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSuccess" runat="server" Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ValidationSummary ID="vsSignIn" runat="server" ForeColor="Red" ShowSummary="False"
                            ValidationGroup="SignInValidation" Width="218px" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblheader" runat="server" Text="Email Id (Username)"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserNameForgetPassword" runat="server" CssClass="smallinput_t200"
                            TabIndex="1" ValidationGroup="forgotpassword" />
                        <asp:RequiredFieldValidator ID="reqValidatorUserName" runat="server" ControlToValidate="txtUserNameForgetPassword"
                            EnableClientScript="true" SetFocusOnError="true" Text="Please enter Email Id"
                            ValidationGroup="forgotpassword"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmailToValidate" runat="server" ControlToValidate="txtUserNameForgetPassword"
                            Display="Dynamic" EnableClientScript="true" ErrorMessage="Please enter a valid E-mail address"
                            SetFocusOnError="true" Text="Please enter Valid Email Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="forgotpassword"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" OnClick="btnSubmit_Click"
                            Text="Submit" ValidationGroup="forgotpassword" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
