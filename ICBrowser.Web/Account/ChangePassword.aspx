<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="ICBrowser.Web.Account.ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table class="style1" bgcolor="#9966FF">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSuccess" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="vsSignIn" runat="server" ForeColor="Red" ShowSummary="False"
                    ValidationGroup="SignInValidation" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <strong>Change Password-</strong>
            </td>
        </tr>
        <tr>
            <td>
                Old Password:-
            </td>
            <td>
                <asp:TextBox ID="txtOldPassword" runat="server" TabIndex="1" TextMode="Password"
                    ValidationGroup="ChangePassword" />
                <asp:RequiredFieldValidator ID="reqValidatorUserName" runat="server" ControlToValidate="txtOldPassword"
                    EnableClientScript="true" ForeColor="Red" SetFocusOnError="true" Text="*" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                New Password: -
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" MaxLength="15" TabIndex="2" TextMode="Password"
                    ToolTip="Password must contain one uppercase, one lowercase, one symbolic &amp; one numeric charcter. Allowed length is 8 to 15 characters."
                    ValidationGroup="ChangePassword"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                    EnableClientScript="true" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                    ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regExValPassword" runat="server" ControlToValidate="txtPassword"
                    Display="Dynamic" ErrorMessage="Password must contain a number, a special character, at least 1 upper case character and must be 8 characters long"
                    Text="Password must contain a number, a special character, at least 1 upper case character and must be 8 characters long"
                    ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@'#.$;%^&amp;+=!()*,-/:&lt;&gt;?]).*$"
                    ValidationGroup="ChangePassword"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Confirm Password: -
            </td>
            <td>
                <asp:TextBox ID="txtVerifyPassword" runat="server" MaxLength="15" TabIndex="3" TextMode="Password"
                    ValidationGroup="ChangePassword"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtVerifyPassword"
                    EnableClientScript="true" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                    ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="ConfirmPasswordCompareValidator" runat="server" ControlToCompare="txtPassword"
                    ControlToValidate="txtVerifyPassword" Display="Dynamic" EnableClientScript="true"
                    ErrorMessage="Please Enter Valid Password" SetFocusOnError="true" Text="Please Enter Valid Password"
                    ValidationGroup="ChangePassword"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <br />
                <br />
                <asp:Button ID="btn_submt" runat="server" OnClick="btn_submt_Click" Text="Submit"
                    ValidationGroup="ChangePassword" />
            </td>
        </tr>
    </table>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
