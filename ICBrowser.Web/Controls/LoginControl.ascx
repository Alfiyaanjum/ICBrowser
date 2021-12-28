<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs"
    Inherits="ICBrowser.Web.Controls.LoginControl" %>


<link href="../Styles/main.css" rel="stylesheet" type="text/css" />
<link href="../Styles/style.css" rel="stylesheet" type="text/css" />
<asp:Panel ID="loginPanel" runat="server" BackColor="#EFFBFE" Width="38%" 
    meta:resourcekey="loginPanelResource1">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblUsrName" runat="server" Text="User Name :" Font-Bold="True" 
                        meta:resourcekey="lblUsrNameResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsrName" runat="server" ToolTip="Enter User Name" 
                        CssClass="smallinput_t" meta:resourcekey="txtUsrNameResource1"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvTxtUname" runat="server" ErrorMessage="Please enter Username"
                        ControlToValidate="txtUsrName" ForeColor="Red" 
                        meta:resourcekey="rfvTxtUnameResource1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassWrd" runat="server" Text="Password :" Font-Bold="True" 
                        meta:resourcekey="lblPassWrdResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassWrd" runat="server" TextMode="Password" ToolTip="Enter Password"
                        CssClass="smallinput_t" meta:resourcekey="txtPassWrdResource1"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvTxtPass" runat="server" ErrorMessage="Please enter Password"
                        ControlToValidate="txtPassWrd" ForeColor="Red" 
                        meta:resourcekey="rfvTxtPassResource1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <center>
                        <asp:HyperLink ID="hypSignup" runat="server" ForeColor="#5DB3DD" 
                            meta:resourcekey="hypSignupResource1" Text="SignUp"></asp:HyperLink>
                    </center>
                </td>
                <td>
                    <center>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="signinbutt" 
                            OnClick="btnLogin_Click" meta:resourcekey="btnLoginResource1" />
                    </center>
                </td>
                <td>
                    <asp:Label ID="LblError" runat="server" Visible="False" ForeColor="Red" 
                        meta:resourcekey="LblErrorResource1"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
