<%@ Page Language="C#" Title="Home Page" AutoEventWireup="true" CodeBehind="Requirements.aspx.cs"
    Inherits="ICBrowser.Web.Requirements" MasterPageFile="~/Site.master" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table  width="80%" align="center">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="left" style="width: 30%; text-align: left;">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                        <td align="left">
                            <asp:Button ID="btnUpload" runat="server" Width="100px" Text="Upload" OnClick="btnUpload_Click2"
                                CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td width="40%">
                            <asp:HyperLink runat="server" Text="Click Here to Download" Target="_blank" NavigateUrl="~/Requirements/Requirements.xlsx"></asp:HyperLink>
                        </td>
                        <td>
                            <asp:Label ID="lblmsg1" runat="server" Text="" Style="color: #FF0000"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Lblmsg" runat="server" Text="" Style="color: #FF0000"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td width="100%">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="false">Buyers Requirements Page</asp:LinkButton>
                            <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
                     </asp:ScriptManager>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalPopup"
                                TargetControlID="LinkButton1" PopupControlID="pnldisplay" CancelControlID="btnCancel">
                            </asp:ModalPopupExtender>
                            <asp:Panel ID="pnldisplay" CssClass="panelbackcolor" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <table align="center" width="100%">
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Label ID="lblMandotory" runat="server" Text="(All Fields are Mandatory)" Style="color: #FF0000"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td width="10%">
                                                    </td>
                                                    <td width="21%">
                                                        <asp:Label ID="lblComponent" runat="server" Text="Component Name :"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtComponent" runat="server" Height="22px" Width="180px" AutoCompleteType="Disabled"
                                                            OnTextChanged="txtComponent_TextChanged">
                                                        </asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtComponent"
                                                            FilterType="LowercaseLetters,UppercaseLetters" />
                                                    </td>
                                                    <td width="20%">
                                                        <asp:RequiredFieldValidator ID="rfvComponent" runat="server" ErrorMessage="Enter Component name"
                                                            ControlToValidate="txtComponent" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td width="10%">
                                                    </td>
                                                    <td width="21%">
                                                        <asp:Label ID="lblQuantity" runat="server" Text="Quantity :"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtQuantity" runat="server" Height="22px" Width="180px" AutoCompleteType="Disabled"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtQuantity"
                                                            FilterType="Numbers" />
                                                    </td>
                                                    <td width="20%">
                                                        <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ErrorMessage="EnterQuantity"
                                                            ControlToValidate="txtQuantity" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td width="10%">
                                                    </td>
                                                    <td width="21%">
                                                        <asp:Label ID="lblDescription" runat="server" Text="Description :"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtDescription" runat="server" Height="22px" Width="180px" AutoCompleteType="Disabled"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtDescription"
                                                            FilterType="LowercaseLetters,UppercaseLetters" />
                                                    </td>
                                                    <td width="20%">
                                                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage="Enter Description"
                                                            ControlToValidate="txtDescription" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td width="10%">
                                                    </td>
                                                    <td width="21%">
                                                        <asp:Label ID="lblBrandName" runat="server" Text="BrandName :"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtBrandName" runat="server" Height="22px" Width="180px" AutoCompleteType="Disabled"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtBrandName"
                                                            FilterType="LowercaseLetters,UppercaseLetters" />
                                                    </td>
                                                    <td width="20%">
                                                        <asp:RequiredFieldValidator ID="rfvBrandName" runat="server" ErrorMessage="Enter BrandName"
                                                            ControlToValidate="txtBrandName" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td width="10%">
                                                    </td>
                                                    <td width="21%">
                                                        <asp:Label ID="lblCompanyName" runat="server" Text="CompanyName :"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtCompanyName" runat="server" Height="22px" Width="180px" AutoCompleteType="Disabled"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtCompanyName"
                                                            FilterType="LowercaseLetters,UppercaseLetters" />
                                                    </td>
                                                    <td width="20%">
                                                        <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ErrorMessage="Enter Company Name"
                                                            ControlToValidate="txtCompanyName" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td width="10%">
                                                    </td>
                                                    <td width="21%">
                                                        <asp:Label ID="lblRequiredBefore" runat="server" Text="RequiredBefore :"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtRequiredBefore" runat="server" Height="22px" Width="180px" AutoCompleteType="Disabled"></asp:TextBox>
                                                        <asp:CalendarExtender ID="txtRequiredBefore_CalendarExtender" runat="server" Enabled="True"
                                                            TargetControlID="txtRequiredBefore" Format="dd-MMM-yyyy">
                                                        </asp:CalendarExtender>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:RequiredFieldValidator ID="rfvRequiredBefore" runat="server" ErrorMessage="Enter Date"
                                                            ControlToValidate="txtCompanyName" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td width="50%" align="right">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Height="28px" Width="75px"
                                                            OnClick="btnSubmit_Click" ValidationGroup="a" />
                                                    </td>
                                                    <td width="10%">
                                                        <asp:Button ID="btnCancel" runat="server" Text="cancel" Height="28px" Width="75px"
                                                            OnClick="btnCancel_Click" />
                                                    </td>
                                                    <td width="40%">
                                                        <asp:Label ID="lblmsg2" runat="server" Text="" Style="color: #FF0000"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
