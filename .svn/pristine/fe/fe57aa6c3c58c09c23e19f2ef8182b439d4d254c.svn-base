<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="ViewSellersProfile.aspx.cs"
    Inherits="ICBrowser.Web.ViewSellersProfile" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="input" meta:resourcekey="Panel1Resource1">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table width="100%" cellspacing="0" cellpadding="5" border="1">
                        <tr>
                            <td>
                                <asp:Label ID="lblMembershipExpiry" runat="server" Text="" Font-Bold="true" Style="color: Red;
                                    font-size: larger" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr class="headerback">
                            <td colspan="2">
                                <asp:Label ID="lblCompanyProfile" runat="server" Text="Profile Details For User"
                                    meta:resourcekey="lblCompanyProfiles1" CssClass="header"></asp:Label>
                                <asp:Label ID="lblUsername" runat="server" Text="" CssClass="header"></asp:Label>
                                <tr class="headerback">
                                    <td colspan="2">
                                        <div style="float: right">
                                            <table align="right">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblLastUpdated" runat="server" Text="Last Updated Date :" meta:resourcekey="lblLastUpdatedResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblLastUpdatedvalue" runat="server" Text="" Style="color: #000000;"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </td>
                        </tr>
                        <tr class="table-row-subheader">
                            <td>
                                <asp:Label ID="lblCompanyDetails" runat="server" Text="Company Details" meta:resourcekey="lblCompanyDetailsResource1"
                                    CssClass="header"></asp:Label>
                            </td>
                            <td align="right">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="lnkcompname" runat="server" Text="Edit" Width="50px" Height="20px"
                                                CssClass="blue_button" meta:resourcekey="lnkcompnameResource1" OnClick="lnkcompname_Click1" />
                                        </td>
                                        <td>
                                            <asp:Button ID="lnkCompnameSave" runat="server" Text="Save" Width="50px" Visible="false"
                                                ValidationGroup="a" Height="20px" CssClass="blue_button" meta:resourcekey="lnkCompnameSaveResource1"
                                                OnClick="lnkCompnameSave_Click1" />
                                        </td>
                                        <td>
                                            <asp:Button ID="lnkcompnameCancel" runat="server" Text="Cancel" Width="50px" Visible="false"
                                                Height="20px" CssClass="blue_button" meta:resourcekey="lnkcompnameCancelResource1"
                                                OnClick="lnkcompnameCancel_Click1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%" cellspacing="0">
                                    <tr class="even">
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblCompanyName" runat="server" Text="Company Name:" meta:resourcekey="lblCompanyNameResource1"></asp:Label>
                                        </td>
                                        <td width="80%">
                                            <asp:Label ID="lblcompnamevalue" runat="server" meta:resourcekey="lblcompnamevalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtcompnamevalue" runat="server" Visible="False" MaxLength="30"
                                                CssClass="smallinput_t" meta:resourcekey="txtcompnamevalueResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCompnamevalue" runat="server" ControlToValidate="txtcompnamevalue"
                                                ErrorMessage="Please Enter Company Name" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="a" meta:resourcekey="rfvCompnamevalueResource1" />
                                            <asp:RegularExpressionValidator ID="rgvtxtcompnamevalue" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                Display="Dynamic" ValidationGroup="a" ControlToValidate="txtcompnamevalue" SetFocusOnError="True"
                                                ForeColor="Red" ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtcompnamevalueResource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblOwnersname" runat="server" Text="Owner Name:" meta:resourcekey="lblOwnersnameResource1"></asp:Label>
                                        </td>
                                        <td width="80%">
                                            <asp:Label ID="lblOwnersnamevalue" runat="server" meta:resourcekey="lblOwnersnamevalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtOwnersnamevalue" runat="server" Visible="False" MaxLength="30"
                                                CssClass="smallinput_t" meta:resourcekey="txtOwnersnamevalueResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvtxtOwnersnamevalue1" runat="server" ControlToValidate="txtOwnersnamevalue"
                                                ErrorMessage="Enter Text Only" ValidationExpression="^[^0-9]+$" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="a" meta:resourcekey="rgvtxtOwnersnamevalue1Resource1"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="rgvtxtOwnersnamevalue" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                Display="Dynamic" ValidationGroup="a" ControlToValidate="txtOwnersnamevalue"
                                                SetFocusOnError="True" ForeColor="Red" ValidationExpression="^((?![<>]).)*$"
                                                meta:resourcekey="rgvtxtOwnersnamevalueResource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table style="width: 100%">
                                    <tr class="even">
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblFirstName" runat="server" Text="First Name:" meta:resourcekey="lblFirstNameResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblFirstNameValue" runat="server" meta:resourcekey="lblFirstNameValueResource1"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="txtFirstname" runat="server" Visible="False" CssClass="smallinput_t"
                                                MaxLength="50" meta:resourcekey="txtFirstnameResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstname"
                                                ErrorMessage="Please Enter First Name" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="a" meta:resourcekey="rfvFirstNameResource1" />
                                            <asp:RegularExpressionValidator ID="rgvtxtFirstname" runat="server" ControlToValidate="txtFirstname"
                                                ErrorMessage="Enter Text Only" ValidationExpression="^[^0-9]+$" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="a" meta:resourcekey="rgvtxtContactPersonsName1Resource1"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="rgvtxtFirstNamevalue" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                Display="Dynamic" ValidationGroup="a" ControlToValidate="txtFirstname" SetFocusOnError="True"
                                                ForeColor="Red" ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtFirstNamevalueResource1"></asp:RegularExpressionValidator>
                                        </td>
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblLastName" runat="server" Text="Last Name:" meta:resourcekey="lblLastNameResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblLastNameValue" runat="server" Style="color: #000000;" meta:resourcekey="lblLastNameValueResource1"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="txtLastName" runat="server" Visible="False" CssClass="smallinput_t"
                                                MaxLength="50" meta:resourcekey="txtLastNameResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtLastName" runat="server" ControlToValidate="txtLastName"
                                                ErrorMessage="Please Enter Last  Name" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="a" meta:resourcekey="rfvtxtLastNameResource1" />
                                            <asp:RegularExpressionValidator ID="rgvtxtLastName" runat="server" ControlToValidate="txtLastName"
                                                ErrorMessage="Enter Text Only" ValidationExpression="^[^0-9]+$" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="a" meta:resourcekey="rgvtxtLastNameResource1"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="rgvtxtLastNameValue" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                Display="Dynamic" ValidationGroup="a" ControlToValidate="txtLastName" SetFocusOnError="True"
                                                ForeColor="Red" ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtLastNameValueeResource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="table-row-subheader">
                            <td>
                                <asp:Label ID="lblAddressDetails" runat="server" Text="Address Details" meta:resourcekey="lblAddressDetailsResource1"
                                    CssClass="header"></asp:Label>
                            </td>
                            <td align="right">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="lnkAddressDetails" runat="server" Text="Edit" Width="50px" Height="20px"
                                                CssClass="blue_button" meta:resourcekey="lnkAddressDetailsResource1" OnClick="lnkAddressDetails_Click1" />
                                        </td>
                                        <td>
                                            <asp:Button ID="lnkAddressDetailsSave" runat="server" Text="Save" Width="50px" Visible="false"
                                                ValidationGroup="b" Height="20px" CssClass="blue_button" meta:resourcekey="lnkAddressDetailsSaveResource1"
                                                OnClick="lnkAddressDetailsSave_Click1" />
                                        </td>
                                        <td>
                                            <asp:Button ID="lnkAddressDetailsCancel" runat="server" Text="Cancel" Width="50px"
                                                Visible="false" Height="20px" CssClass="blue_button" meta:resourcekey="lnkAddressDetailsCancelResource1"
                                                OnClick="lnkAddressDetailsCancel_Click1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblAddress1" runat="server" Text="Primary Address:" meta:resourcekey="lblAddress1Resource1"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblmsg" runat="server" Text="(Max Length 200 chars)" Style="font-size: x-small;
                                                padding-right: 5px" meta:resourcekey="lblmsgResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblAddress1value" runat="server" meta:resourcekey="lblAddress1valueResource1"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="txtAddress1" TextMode="MultiLine" MaxLength="200" runat="server"
                                                CssClass="smallinput" Visible="False" Width="148px" Height="60px" meta:resourcekey="txtAddress1Resource1"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ControlToValidate="txtAddress1"
                                                ErrorMessage="Please Enter Primary Address" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rfvAddress1Resource1" />
                                            <%-- <asp:RegularExpressionValidator ID="rgvtxtAddress12" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                        Display="Dynamic" ValidationGroup="b" ControlToValidate="txtAddress1" SetFocusOnError="True"
                                        ForeColor="Red" ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtAddress12Resource1"></asp:RegularExpressionValidator>--%>
                                            <asp:RegularExpressionValidator ID="rgvtxtAddress1" ControlToValidate="txtAddress1"
                                                ErrorMessage="Exceeding 200 characters" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="b" ValidationExpression="^[\s\S]{0,200}$"
                                                runat="server" meta:resourcekey="rgvtxtAddress1Resource1" />
                                        </td>
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblAddress2" runat="server" Text="Secondary Address:" meta:resourcekey="lblAddress2Resource1"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblmsg1" runat="server" Text="(Max Length 200 chars)" Style="font-size: x-small;
                                                color: #000000; font-family: Verdana" meta:resourcekey="lblmsg1Resource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblAddress2value" runat="server" Style="color: #000000" meta:resourcekey="lblAddress2valueResource1"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="txtAddress2" TextMode="MultiLine" MaxLength="200" runat="server"
                                                CssClass="smallinput" Visible="False" Width="148px" Height="60px" meta:resourcekey="txtAddress2Resource1"></asp:TextBox>
                                            <br />
                                            <%--<asp:RegularExpressionValidator ID="rgvtxtAddress21" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                        Display="Dynamic" ValidationGroup="b" ControlToValidate="txtAddress2" ForeColor="Red"
                                        ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtAddress21Resource1"></asp:RegularExpressionValidator>--%>
                                            <asp:RegularExpressionValidator ID="rgvtxtAddress2" ControlToValidate="txtAddress2"
                                                ErrorMessage="Exceeding 200 characters" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="b" ValidationExpression="^[\s\S]{0,200}$"
                                                runat="server" meta:resourcekey="rgvtxtAddress2Resource1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%" cellspacing="0">
                                    <tr class="even">
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblPrimaryCity" runat="server" Text="City:" meta:resourcekey="lblPrimaryCityResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblPrimaryCityvalue" runat="server" meta:resourcekey="lblPrimaryCityvalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtPrimaryCity" runat="server" Visible="False" MaxLength="30" CssClass="smallinput_t"
                                                meta:resourcekey="txtPrimaryCityResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtPrimaryCity"
                                                ErrorMessage="Please Enter City" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                ValidationGroup="b" meta:resourcekey="rfvCityResource1" />
                                            <asp:RegularExpressionValidator ID="rgvtxtPrimaryCityvalue1" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                Display="Dynamic" ValidationGroup="b" ControlToValidate="txtPrimaryCity" ForeColor="Red"
                                                ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtPrimaryCityvalue1Resource1"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="rgvtxtPrimaryCityvalue" runat="server" ControlToValidate="txtPrimaryCity"
                                                ErrorMessage="Enter Valid City" ValidationExpression="^[^0-9]+$" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rgvtxtPrimaryCityvalueResource1"></asp:RegularExpressionValidator>
                                        </td>
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblSecondaryCity" runat="server" Text="City:" meta:resourcekey="lblSecondaryCityResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblSecondaryCityvalue" runat="server" meta:resourcekey="lblSecondaryCityvalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtSecondaryCity" runat="server" Visible="False" MaxLength="30"
                                                CssClass="smallinput_t" meta:resourcekey="txtSecondaryCityResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvtxtSecondaryCity1" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                Display="Dynamic" ValidationGroup="b" ControlToValidate="txtSecondaryCity" ForeColor="Red"
                                                ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtSecondaryCity1Resource1"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSecondaryCity"
                                                ErrorMessage="Enter Valid City" ValidationExpression="^[^0-9]+$" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblPriamryZipCode" runat="server" Text="Zip Code:" meta:resourcekey="lblPriamryZipCodeResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblPriamryZipCodeValue" runat="server" meta:resourcekey="lblPriamryZipCodeValueResource1"></asp:Label>
                                            <asp:TextBox ID="txtPriamryZipCode" runat="server" Visible="False" MaxLength="7"
                                                CssClass="smallinput_t"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPriamryZipCode" runat="server" ControlToValidate="txtPriamryZipCode"
                                                ErrorMessage="Please Enter Primary Zip" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rfvPriamryZipCodeResource1" />
                                            <%-- <asp:RegularExpressionValidator ID="rgvPriamryZipCodevalue" runat="server" ControlToValidate="txtPriamryZipCode"
                                                ErrorMessage="Enter Valid Zip Code." ValidationExpression="^[0-9]{6}" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rgvPriamryZipCodevalueResource1"></asp:RegularExpressionValidator>--%>
                                        </td>
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblSecondaryZipCode" runat="server" Text="Zip Code:" meta:resourcekey="lblSecondaryZipCodeResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblSecondaryZipCodeValue" runat="server" meta:resourcekey="lblSecondaryZipCodeValueResource1"></asp:Label>
                                            <asp:TextBox ID="txtSecondaryZipCode" runat="server" Visible="False" MaxLength="7"
                                                CssClass="smallinput_t"></asp:TextBox>
                                            <%--<asp:RegularExpressionValidator ID="rgvSecondaryZipCode" runat="server" ControlToValidate="txtSecondaryZipCode"
                                                ErrorMessage="Enter Valid Zip Code." ValidationExpression="^[0-9]{6}" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rgvSecondaryZipCodeResource1"></asp:RegularExpressionValidator>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%" cellspacing="0">
                                    <tr class="even">
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblPrimaryState" runat="server" Text="State:" Style="color: #000000;"
                                                meta:resourcekey="lblPrimaryStateResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblPrimaryStatevalue" runat="server" Style="color: #000000" meta:resourcekey="lblPrimaryStatevalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtPrimaryState" runat="server" Visible="False" MaxLength="30" CssClass="smallinput_t"
                                                meta:resourcekey="txtPrimaryStateResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvPrimaryState1" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                Display="Dynamic" ValidationGroup="b" ControlToValidate="txtPrimaryState" ForeColor="Red"
                                                ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvPrimaryState1Resource1"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="rgvPrimaryState" runat="server" ControlToValidate="txtPrimaryState"
                                                ErrorMessage="Enter Valid State" ValidationExpression="^[^0-9]+$" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rgvPrimaryStateResource1"></asp:RegularExpressionValidator>
                                        </td>
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblSecondaryState" runat="server" Text="State:" Style="color: #000000;"
                                                meta:resourcekey="lblSecondaryStateResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblSecondaryStateValue" runat="server" meta:resourcekey="lblSecondaryStateValueResource1"></asp:Label>
                                            <asp:TextBox ID="txtSecondaryState" runat="server" Visible="False" MaxLength="30"
                                                CssClass="smallinput_t" meta:resourcekey="txtSecondaryStateResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvtxtSecondaryState" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                Display="Dynamic" ValidationGroup="b" ControlToValidate="txtSecondaryState" ForeColor="Red"
                                                ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtSecondaryStateResource1"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="rgvSecondaryState" runat="server" ControlToValidate="txtSecondaryState"
                                                ErrorMessage="Enter Valid State" ValidationExpression="^[^0-9]+$" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rgvSecondaryStateResource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblPrimaryCountry" runat="server" Text="Country:" Style="color: #000000;"
                                                meta:resourcekey="lblPrimaryCountryResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblPrimaryCountryvalue" runat="server" meta:resourcekey="lblPrimaryCountryvalueResource1"></asp:Label>
                                            <asp:DropDownList ID="ddlPrimaryCountry" Width="150px" runat="server" Visible="False"
                                                CssClass="smallinput_t200_register" MaxLength="30" meta:resourcekey="ddlPrimaryCountryResource1">
                                            </asp:DropDownList>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvPrimaryCountry" runat="server" ControlToValidate="ddlPrimaryCountry"
                                                ErrorMessage="Please Select Country" InitialValue="0" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rfvPrimaryCountryResource1" />
                                        </td>
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblSecondaryCountry" runat="server" Text="Country:" Style="color: #000000;"
                                                meta:resourcekey="lblSecondaryCountryResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblSecondaryCountryValue" runat="server" meta:resourcekey="lblSecondaryCountryValueResource1"></asp:Label>
                                            <asp:DropDownList ID="ddlSecondaryCountry" Width="150px" runat="server" Visible="False"
                                                CssClass="smallinput_t200_register" MaxLength="30" meta:resourcekey="ddlSecondaryCountryResource1">
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%">
                                    <tr class="even">
                                        <td width="25%" align="right">
                                            <asp:Label ID="lblPanNumber" runat="server" Text="Taxpayer Identification Number(TIN):"
                                                Style="color: #000000;" meta:resourcekey="lblPanNumberResource1"></asp:Label>
                                        </td>
                                        <td width="75%">
                                            <asp:Label ID="lblPanNumberValue" runat="server" meta:resourcekey="lblPanNumberValueResource1"></asp:Label>
                                            <asp:TextBox ID="txtPanNumber" runat="server" CssClass="smallinput_t" MaxLength="12"
                                                Visible="false"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="regexvalPanNumber" runat="server" ErrorMessage="Invalid TIN Number"
                                                ControlToValidate="txtPanNumber" ValidationExpression="^([a-zA-Z0-9]{12})$" Display="Dynamic"
                                                ValidationGroup="b" ForeColor="Red" meta:resourcekey="regexvalPanNumberResource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="table-row-subheader">
                            <td>
                                <asp:Label ID="lblContactDetails" runat="server" Text="Contact Details" meta:resourcekey="lblContactDetailsResource1"
                                    CssClass="header"></asp:Label>
                            </td>
                            <td align="right">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="lnkContactDetails" runat="server" Text="Edit" Width="50px" Height="20px"
                                                CssClass="blue_button" meta:resourcekey="lnkContactDetailsResource1" OnClick="lnkContactDetails_Click1" />
                                        </td>
                                        <td>
                                            <asp:Button ID="lnkContactDetailsSave" runat="server" Text="Save" Width="50px" Visible="false"
                                                ValidationGroup="c" Height="20px" CssClass="blue_button" meta:resourcekey="lnkContactDetailsSaveResource1"
                                                OnClick="lnkContactDetailsSave_Click1" />
                                        </td>
                                        <td>
                                            <asp:Button ID="lnkContactDetailsCancel" runat="server" Text="Cancel" Width="50px"
                                                Visible="false" Height="20px" CssClass="blue_button" meta:resourcekey="lnkContactDetailsCancelResource1"
                                                OnClick="lnkContactDetailsCancel_Click1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="even">
                            <td colspan="2">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="19%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblEmail" runat="server" Text="Email:" meta:resourcekey="lblEmailResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblEmailvalue" runat="server" meta:resourcekey="lblEmailvalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtEmail" runat="server" Visible="False" CssClass="smallinput_t"
                                                Width="200px" MaxLength="50" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rftxtEmail" runat="server" ControlToValidate="txtEmail"
                                                ErrorMessage="Please Enter Email" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                ValidationGroup="c" meta:resourcekey="rftxtEmailResource1" />
                                            <asp:RegularExpressionValidator ID="rgvtxtEmail" runat="server" ControlToValidate="txtEmail"
                                                ErrorMessage="Enter Valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ForeColor="Red" Display="Dynamic" ValidationGroup="c"></asp:RegularExpressionValidator>
                                        </td>
                                        <td width="15%">
                                            <asp:Button ID="btnGenerateCode" runat="server" Text="Generate Code" CssClass="blue_button"
                                                Visible="false" Height="28px" Width="102px" OnClick="btnGenerateCode_Click1"
                                                meta:resourcekey="btnGenerateCodeResource1" />
                                        </td>
                                        <td width="30%">
                                            <asp:TextBox ID="txtGenerateCode" runat="server" Visible="False" CssClass="smallinput_t"
                                                MaxLength="25" meta:resourcekey="txtGenerateCodeResource1"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblEmailPreference" runat="server" Text="Email Preference:" Style="color: #000000;"
                                                meta:resourcekey="lblEmailPreferenceResource1"></asp:Label>
                                        </td>
                                        <td width="82%" colspan="5" align="left">
                                            <asp:Label ID="lblEmailPreferenceValue" runat="server" meta:resourcekey="lblEmailPreferenceValueResource1"></asp:Label>
                                            <asp:CheckBox ID="chkbxEmailPreference" runat="server" Visible="False" />
                                            <%--<asp:DropDownList ID="ddlEmailPreference" align="middle" runat="server" CssClass="smallinput_t200"
                                                Visible="False" Width="100px" meta:resourcekey="ddlEmailPreferenceResource1">
                                                <asp:ListItem Text="- Select -" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                <asp:ListItem Text="4 Hourly" Value="1" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                                <asp:ListItem Text="8 Hourly" Value="2" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                                <asp:ListItem Text="Daily" Value="3" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                                <asp:ListItem Text="Weekly" Value="4" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                                <asp:ListItem Text="Monthly" Value="5" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                                <asp:ListItem Text="No Emails" Value="6" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                            </asp:DropDownList>--%>
                                            <%--<asp:RequiredFieldValidator ID="rfvEmailPreference" runat="server" ErrorMessage="Please make a selection"
                                                ForeColor="Red" ControlToValidate="ddlEmailPreference" InitialValue="0" ValidationGroup="c"
                                                meta:resourcekey="rfvEmailPreferenceResource1" ></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%" cellspacing="0">
                                    <tr class="even">
                                        <td width="20%" align="right" style="padding-left: 12px;">
                                            <asp:Label ID="lblWebsiteurl" runat="server" Text="Website Url: " Style="color: #000000;"
                                                meta:resourcekey="lblWebsiteurlResource1"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblexa" runat="server" Text="(ex: http://www.yahoo.com)" Style="font-size: x-small;
                                                color: #000000; font-family: Verdana" meta:resourcekey="lblexaResource1"></asp:Label>
                                        </td>
                                        <td width="82%">
                                            <asp:Label ID="lblWebsiteurlvalue" runat="server" meta:resourcekey="lblWebsiteurlvalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtWebsiteurl" runat="server" Visible="False" MaxLength="50" CssClass="smallinput_t"
                                                meta:resourcekey="txtWebsiteurlResource1" Width="200px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvWebsiteurlvalue" runat="server" ControlToValidate="txtWebsiteurl"
                                                ErrorMessage="Enter Valid Websiteurl" ValidationExpression="(http://([\w-]+\.)|([\w-]+\.))+[\w-]*(/[\w- ./?%=]*)?"
                                                ForeColor="Red" Display="Dynamic" ValidationGroup="c" meta:resourcekey="rgvWebsiteurlvalueResource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="20%" align="right" style="padding-left: 12px;">
                                            <asp:Label ID="lblMobile" runat="server" Text="Mobile:" meta:resourcekey="lblMobileResource1"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblMobexa" runat="server" Font-Size="8" Text="(ex:+91-9975674756)"
                                                Style="font-size: x-small; color: #000000; font-family: Verdana"></asp:Label>
                                        </td>
                                        <%-- <td class="black">
                                           
                                        </td>--%>
                                        <td width="4%" align="left">
                                            <table>
                                                <tr>
                                                    <td id="Plus" runat="server" visible="false">
                                                        +
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMobCntcd" runat="server" Font-Size="8" MaxLength="4" Height="20px"
                                                            Width="50px" CssClass="smallinput_t" Visible="False" meta:resourcekey="txtMobCntcdResource1"></asp:TextBox>
                                                        <asp:TextBoxWatermarkExtender ID="txtWMCountrycode" runat="server" TargetControlID="txtMobCntcd"
                                                            WatermarkText="Country Code" WatermarkCssClass="watermarked" />
                                                        <asp:Label ID="lblMobCntcd" runat="server" meta:resourcekey="lblMobCntcdResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="76%">
                                            <table>
                                                <tr>
                                                    <td id="dash" runat="server" visible="false">
                                                        -
                                                    </td>
                                                    <td>
                                                        <%--</td>
                                                    <td>--%>
                                                        <asp:TextBox ID="txtmobno" Font-Size="8" runat="server" Visible="False" MaxLength="10"
                                                            Height="22px" CssClass="smallinput_t" Width="95px" meta:resourcekey="txtmobnoResource1"></asp:TextBox>
                                                        <asp:TextBoxWatermarkExtender ID="txtWMMobno" runat="server" TargetControlID="txtmobno"
                                                            WatermarkText="Mobile Number" WatermarkCssClass="watermarked" />
                                                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPhone"
                                                            ErrorMessage="Please Enter Phone no." ForeColor="Red" SetFocusOnError="True"
                                                            Display="Dynamic" ValidationGroup="c" meta:resourcekey="rfvPhoneResource1" />--%>
                                                        <asp:RegularExpressionValidator ID="rgvMobno" runat="server" ControlToValidate="txtmobno"
                                                            ErrorMessage="Enter Valid Mobile no" ValidationExpression="^[0-9]{10}" ForeColor="Red"
                                                            Display="Dynamic" ValidationGroup="c" meta:resourcekey="rgvMobnoResource1"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="rgvCntcd" runat="server" ControlToValidate="txtMobCntcd"
                                                            Display="Dynamic" ErrorMessage="Enter Valid Country Code" ValidationExpression="^[0-9]{0,4}"
                                                            ForeColor="Red" ValidationGroup="c"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="lblMobno" runat="server" meta:resourcekey="lblMobnoResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td colspan="4">
                                            <table style="width: 100%" cellspacing="0">
                                                <tr class="even">
                                                    <td width="20%" align="right" style="padding-right: 5px">
                                                        <asp:Label ID="Label2" runat="server" Text="Extension:" Style="color: #000000;" meta:resourcekey="lblExtensionResource1"></asp:Label>
                                                    </td>
                                                    <td width="82%">
                                                        <asp:Label ID="Label3" runat="server" meta:resourcekey="lblExtensionvalueResource1"></asp:Label>
                                                        <asp:TextBox ID="TextBox2" runat="server" Visible="False" MaxLength="5" CssClass="smallinput_t"
                                                            meta:resourcekey="txtExtensionResource1"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtExtension"
                                                            ErrorMessage="Enter Valid Extension" ValidationExpression="^[0-9]+$" ForeColor="Red"
                                                            Display="Dynamic" ValidationGroup="c" meta:resourcekey="rgvExtensionvalueResource1"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>--%>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%">
                                    <tr class="even">
                                        <td width="20%" align="right" style="padding-left: 12px;">
                                            <asp:Label ID="lblPhone" runat="server" Text="Phone:" meta:resourcekey="lblPhoneResource1"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblPhneNo" runat="server" Font-Size="8" Text="(ex:+91-22-21026611)"
                                                Style="font-size: x-small; color: #000000; font-family: Verdana"></asp:Label>
                                        </td>
                                        <%-- <td class="black">
                                           
                                        </td>--%>
                                        <td width="4%" align="left">
                                            <table>
                                                <tr>
                                                    <td id="plus1" runat="server" visible="false">
                                                        +
                                                    </td>
                                                    <td>
                                                        <%-- </td>
                                                    <td>--%>
                                                        <asp:TextBox ID="txtCountryCode" runat="server" Font-Size="8" MaxLength="4" Height="20px"
                                                            Width="50px" CssClass="smallinput_t" Visible="False" meta:resourcekey="txtCountryCodeResource1"></asp:TextBox>
                                                        <asp:TextBoxWatermarkExtender ID="TBWtxtCountryCode" runat="server" TargetControlID="txtCountryCode"
                                                            WatermarkText="Country Code" WatermarkCssClass="watermarked" />
                                                        <asp:Label ID="lblCntCd" runat="server" meta:resourcekey="lblCountrycodeResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <%-- <td class="black">
                                                
                                            </td>--%>
                                        </td>
                                        <td width="4%" align="left">
                                            <table>
                                                <tr>
                                                    <td id="dash1" runat="server" visible="false">
                                                        -
                                                    </td>
                                                    <td>
                                                        <%--</td>
                                                    <td>--%>
                                                        <asp:TextBox ID="txtCityCode" runat="server" Font-Size="8" MaxLength="4" Height="20px"
                                                            Width="50px" CssClass="smallinput_t" Visible="False" meta:resourcekey="txtCityCodeResource1"></asp:TextBox>
                                                        <asp:TextBoxWatermarkExtender ID="TBWtxtCityCode" runat="server" TargetControlID="txtCityCode"
                                                            WatermarkText="City Code" WatermarkCssClass="watermarked" />
                                                        <asp:Label ID="lblCtycd" runat="server" meta:resourcekey="lblCityCodeResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <%-- <td class="black">
                                                
                                            </td>--%>
                                        </td>
                                        <td width="72%">
                                            <table>
                                                <tr>
                                                    <td id="dash2" runat="server" visible="false">
                                                        -
                                                    </td>
                                                    <td>
                                                        <%--</td>
                                                    <td>--%>
                                                        <asp:TextBox ID="txtPhone" Font-Size="8" runat="server" Visible="False" MaxLength="10"
                                                            Height="22px" CssClass="smallinput_t" Width="95px" meta:resourcekey="txtPhoneResource1"></asp:TextBox>
                                                        <asp:TextBoxWatermarkExtender ID="TBWtxtPhone" runat="server" TargetControlID="txtPhone"
                                                            WatermarkText="Phone Number" WatermarkCssClass="watermarked" />
                                                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                                                            ErrorMessage="Please Enter Phone no." ForeColor="Red" SetFocusOnError="True"
                                                            Display="Dynamic" ValidationGroup="c" meta:resourcekey="rfvPhoneResource1" />
                                                        <asp:RegularExpressionValidator ID="rgvPhonevalue" runat="server" ControlToValidate="txtPhone"
                                                            ErrorMessage="Enter Valid Phone no" ValidationExpression="^[0-9]{0,10}" ForeColor="Red"
                                                            Display="Dynamic" ValidationGroup="c" meta:resourcekey="rgvPhonevalueResource1"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="rgvCityCode" runat="server" ControlToValidate="txtCityCode"
                                                            Display="Dynamic" ErrorMessage="Enter Valid City Code" ValidationExpression="^[0-9]{0,4}"
                                                            ForeColor="Red" ValidationGroup="c"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="rgvCountryCode" runat="server" ControlToValidate="txtCountryCode"
                                                            Display="Dynamic" ErrorMessage="Enter Valid Country Code" ValidationExpression="^[0-9]{0,4}"
                                                            ForeColor="Red" ValidationGroup="c"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="lblPhonevalue" runat="server" meta:resourcekey="lblPhonevalueResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td colspan="4">
                                            <table style="width: 100%" cellspacing="0">
                                                <tr class="even">
                                                    <td width="20%" align="right" style="padding-right: 5px">
                                                        <asp:Label ID="Label2" runat="server" Text="Extension:" Style="color: #000000;" meta:resourcekey="lblExtensionResource1"></asp:Label>
                                                    </td>
                                                    <td width="82%">
                                                        <asp:Label ID="Label3" runat="server" meta:resourcekey="lblExtensionvalueResource1"></asp:Label>
                                                        <asp:TextBox ID="TextBox2" runat="server" Visible="False" MaxLength="5" CssClass="smallinput_t"
                                                            meta:resourcekey="txtExtensionResource1"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtExtension"
                                                            ErrorMessage="Enter Valid Extension" ValidationExpression="^[0-9]+$" ForeColor="Red"
                                                            Display="Dynamic" ValidationGroup="c" meta:resourcekey="rgvExtensionvalueResource1"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>--%>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%" cellspacing="0">
                                    <tr class="odd">
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblExtension" runat="server" Text="Extension:" Style="color: #000000;"
                                                meta:resourcekey="lblExtensionResource1"></asp:Label>
                                        </td>
                                        <td width="82%">
                                            <asp:Label ID="lblExtensionvalue" runat="server" meta:resourcekey="lblExtensionvalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtExtension" runat="server" Visible="False" MaxLength="5" CssClass="smallinput_t"
                                                meta:resourcekey="txtExtensionResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvExtensionvalue" runat="server" ControlToValidate="txtExtension"
                                                ErrorMessage="Enter Valid Extension" ValidationExpression="^[0-9]+$" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="c" meta:resourcekey="rgvExtensionvalueResource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%--<tr>
                            <td colspan="4">
                                <table style="width: 100%" cellspacing="0">
                                    <tr>
                                        <td width="30%">
                                            <asp:Label ID="lblMobile" runat="server" Text="Mobile :" Style="color: #000000" meta:resourcekey="lblMobileResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <asp:Label ID="lblMobilevalue" runat="server" meta:resourcekey="lblMobilevalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtMobile" runat="server" Visible="False" MaxLength="10" CssClass="smallinput_t"
                                                meta:resourcekey="txtMobileResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvMobilevalue" runat="server" ControlToValidate="txtMobile"
                                                ErrorMessage="Enter Valid mobile no" ValidationExpression="^[0-9]{10}" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="c" meta:resourcekey="rgvMobilevalueResource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%">
                                    <tr class="even">
                                        <td width="20%" align="right" style="padding-left: 10px;">
                                            <asp:Label ID="lblFax" runat="server" Text="Fax:" meta:resourcekey="lblFaxResource1"></asp:Label>
                                        </td>
                                        <%--  <td width="82%">--%>
                                        <%--  <asp:Label ID="lblFaxvalue" runat="server" meta:resourcekey="lblFaxvalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtFax" runat="server" Visible="False" MaxLength="20" CssClass="smallinput_t"
                                                meta:resourcekey="txtFaxResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvFaxvalue" runat="server" ControlToValidate="txtFax"
                                                ErrorMessage="Enter Valid Fax no" ValidationExpression="\d{0,4}-\d{0,4}-\d{0,10}" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="c" meta:resourcekey="rgvFaxvalueResource1"></asp:RegularExpressionValidator>--%>
                                        <td width="4%" align="left">
                                            <table>
                                                <tr>
                                                    <td id="plus2" runat="server" visible="false">
                                                        +
                                                    </td>
                                                    <td>
                                                        <%--</td>
                                                    <td>--%>
                                                        <asp:TextBox ID="txtCountryCode1" Font-Size="8" runat="server" MaxLength="4" Height="20px"
                                                            Width="50px" CssClass="smallinput_t" Visible="False" meta:resourcekey="txtCountryCode1Resource1"></asp:TextBox>
                                                        <asp:TextBoxWatermarkExtender ID="TBWtxtCountryCode1" runat="server" TargetControlID="txtCountryCode1"
                                                            WatermarkText="Country Code" WatermarkCssClass="watermarked" />
                                                        <asp:Label ID="lblCountrycode1" runat="server" meta:resourcekey="lblCountrycode1Resource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <%-- <td class="black">
                                                
                                            </td>--%>
                                        </td>
                                        <td width="4%" align="left">
                                            <table>
                                                <tr>
                                                    <td id="dash3" runat="server" visible="false">
                                                        -
                                                    </td>
                                                    <td>
                                                        <%--</td>
                                                    <td>--%>
                                                        <asp:TextBox ID="txtCityCode1" Font-Size="8" runat="server" MaxLength="4" Height="20px"
                                                            Width="50px" CssClass="smallinput_t" Visible="False" meta:resourcekey="txtCityCode1Resource1"></asp:TextBox>
                                                        <asp:TextBoxWatermarkExtender ID="TBWtxtCityCode1" runat="server" TargetControlID="txtCityCode1"
                                                            WatermarkText="City Code" WatermarkCssClass="watermarked" />
                                                        <asp:Label ID="lblCityCode1" runat="server" meta:resourcekey="lblCityCode1Resource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <%-- <td class="black">
                                                
                                            </td>--%>
                                        </td>
                                        <td width="72%">
                                            <table>
                                                <tr>
                                                    <td id="dash4" runat="server" visible="false">
                                                        -
                                                    </td>
                                                    <td>
                                                        <%--</td>
                                                    <td>--%>
                                                        <asp:TextBox ID="txtFax" Font-Size="8" runat="server" Visible="False" MaxLength="10"
                                                            Height="22px" CssClass="smallinput_t" Width="95px" meta:resourcekey="txtFaxResource1"></asp:TextBox>
                                                        <asp:TextBoxWatermarkExtender ID="TBWtxtFax" runat="server" TargetControlID="txtFax"
                                                            WatermarkText="Fax Number" WatermarkCssClass="watermarked" />
                                                        <asp:RegularExpressionValidator ID="rfvfaxvalue1" runat="server" ControlToValidate="txtFax"
                                                            ErrorMessage="Enter Valid Fax no" ValidationExpression="^[0-9]{0,10}" ForeColor="Red"
                                                            Display="Dynamic" ValidationGroup="c" meta:resourcekey="rfvfaxvalue1Resource1"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="rgvCityCode1" runat="server" ControlToValidate="txtCityCode1"
                                                            Display="Dynamic" ErrorMessage="Enter Valid City Code" ValidationExpression="^[0-9]{0,4}"
                                                            ForeColor="Red" ValidationGroup="c"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="rgvCountryCode1" runat="server" ControlToValidate="txtCountryCode1"
                                                            Display="Dynamic" ErrorMessage="Enter Valid Country Code" ValidationExpression="^[0-9]{0,4}"
                                                            ForeColor="Red" ValidationGroup="c"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="lblFaxvalue" runat="server" meta:resourcekey="lblFaxvalueResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <%--</td>--%>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="odd">
                            <td colspan="4">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblQQId" runat="server" Text="QQ:" meta:resourcekey="lblQQIdResource1"></asp:Label>
                                        </td>
                                        <td width="20%" align="left">
                                            <asp:Label ID="lbltxtQQIdText" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtQQId" runat="server" CssClass="smallinput_t" Visible="False"></asp:TextBox>
                                        </td>
                                        <td width="15%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblSkypeId" runat="server" Text="Skype:" meta:resourcekey="lblSkypeIdResource1"></asp:Label>
                                        </td>
                                        <td width="15%">
                                            <asp:Label ID="lbltxtSkypeIdText" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtSkypeId" runat="server" CssClass="smallinput_t" Visible="False"></asp:TextBox>
                                        </td>
                                        <td width="15%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblMSNId" runat="server" Text="MSN:" meta:resourcekey="lblMSNIdResource1"></asp:Label>
                                        </td>
                                        <td width="15%">
                                            <asp:Label ID="lbltxtMSNIdText" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtMSNId" runat="server" CssClass="smallinput_t" Visible="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="table-row-subheader">
                            <td>
                                <asp:Label ID="lblOtherDetails" runat="server" Text="Other Details" meta:resourcekey="lblOtherDetailsResource1"
                                    CssClass="header"></asp:Label>
                                <asp:ImageButton ID="input" runat="server" Width="1px" Height="1px" ImageUrl="~/Images/menubg.png"
                                    meta:resourcekey="inputResource1" />
                            </td>
                            <td align="right">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="lnkOtherDetails" runat="server" Text="Edit" Width="50px" Height="20px"
                                                CssClass="blue_button" meta:resourcekey="lnkOtherDetailsResource1" OnClick="lnkOtherDetails_Click1" />
                                        </td>
                                        <td>
                                            <asp:Button ID="lnkOtherDetailsSave" runat="server" Text="Save" Width="50px" ValidationGroup="d"
                                                Visible="false" Height="20px" CssClass="blue_button" meta:resourcekey="lnkOtherDetailsSaveResource1"
                                                OnClick="lnkOtherDetailsSave_Click1" />
                                        </td>
                                        <td>
                                            <asp:Button ID="lnkOtherDetailsCancel" runat="server" Text="Cancel" Width="50px"
                                                Height="20px" CssClass="blue_button" Visible="false" meta:resourcekey="lnkOtherDetailsCancelResource1"
                                                OnClick="lnkOtherDetailsCancel_Click1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%" cellspacing="0">
                                    <tr class="even">
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblSpecializaion" runat="server" Text="Specialization:" Style="color: #000000;"
                                                meta:resourcekey="lblSpecializaionResource1"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblmsg3" runat="server" Text="(Max Length 200 chars)" Style="font-size: x-small;
                                                color: #000000; font-family: Verdana" meta:resourcekey="lblmsg3Resource1"></asp:Label>
                                        </td>
                                        <td width="80%">
                                            <asp:Label ID="lblSpecializaionValue" runat="server" meta:resourcekey="lblSpecializaionValueResource1"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="txtSpecializaion" TextMode="MultiLine" MaxLength="200" runat="server"
                                                CssClass="smallinput" Visible="False" Width="180px" Height="60px" meta:resourcekey="txtSpecializaionResource1"></asp:TextBox>
                                            <br />
                                            <asp:RegularExpressionValidator ID="rgvSpecializaion" ControlToValidate="txtSpecializaion"
                                                ErrorMessage="Exceeding 200 characters" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="d" ValidationExpression="^[\s\S]{0,200}$"
                                                runat="server" meta:resourcekey="rgvSpecializaionResource1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%--<tr>
                            <td colspan="4">
                                <table style="width: 100%" cellspacing="0">
                                    <tr>
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblCurrency" runat="server" Text="Currency:" Style="color: #000000;"
                                                meta:resourcekey="lblCurrencyResource1"></asp:Label>
                                        </td>
                                        <td width="80%">
                                            <asp:Label ID="lblCurrencyvalue" runat="server" meta:resourcekey="lblCurrencyvalueResource1"></asp:Label>
                                            <br />
                                            <asp:DropDownList ID="ddlCurreny" runat="server" Width="128px" Visible="False" CssClass="smallinput_t200"
                                                meta:resourcekey="ddlCurrenyResource1">
                                                <asp:ListItem Value="INR" meta:resourcekey="ListItemResource8"></asp:ListItem>
                                                <asp:ListItem Value="USD" meta:resourcekey="ListItemResource9"></asp:ListItem>
                                                <asp:ListItem Value="CNY" meta:resourcekey="ListItemResource10"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvCurrency" runat="server" InitialValue="0" ControlToValidate="ddlCurreny"
                                                ErrorMessage="Please Enter Currency Type" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="d" meta:resourcekey="rfvCurrencyResource1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%" cellspacing="0">
                                    <tr class="odd">
                                        <td width="20%" align="right" style="padding-right: 5px">
                                            <asp:Label ID="lblMembershiptype" runat="server" Text="Membership Type:" Style="color: #000000;"
                                                meta:resourcekey="lblMembershiptypeResource1"></asp:Label>
                                        </td>
                                        <td width="80%">
                                            <asp:Label ID="lblMembershiptypeValue" runat="server" meta:resourcekey="lblMembershiptypeValueResource1"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <div id="divMembership" runat="server">
                            <tr>
                                <td colspan="4">
                                    <table style="width: 100%" cellspacing="0">
                                        <tr class="even">
                                            <td width="20%" align="right" style="padding-right: 5px">
                                                <asp:Label ID="lblMembershipLastDate" runat="server" Text="Membership Started On:"
                                                    meta:resourcekey="lblMembershipLastDateResource1"></asp:Label>
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblMembershipLastDateValue" runat="server" Text='<%# Eval("lblMembershipLastDateValue", "{0:dd-MMM-yyyy}") %>'
                                                    meta:resourcekey="lblMembershipLastDateValueResource1"></asp:Label>
                                                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999"
                                                    CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                                    ForeColor="Black" Height="180px" Width="200px">
                                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                                    <NextPrevStyle VerticalAlign="Bottom" />
                                                    <OtherMonthDayStyle ForeColor="#808080" />
                                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                                    <SelectorStyle BackColor="#CCCCCC" />
                                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                                </asp:Calendar>
                                            </td>
                                            <td width="20%" align="right" style="padding-right: 5px">
                                                <asp:Label ID="lblMembershipPeriod" runat="server" Text="Membership Period(Days):"
                                                    meta:resourcekey="lblMembershipPeriodResource1"></asp:Label>
                                            </td>
                                            <td width="40%">
                                                <asp:Label ID="lblMembershipPeriodValue" runat="server" meta:resourcekey="lblMembershipPeriodValueResource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </div>
                        <div id="divPayment" runat="server">
                            <tr class="odd">
                                <td colspan="4">
                                    <table style="width: 100%" cellspacing="0">
                                        <tr>
                                            <td width="20%" align="right" style="padding-right: 5px">
                                                <asp:Label ID="lblPaymentOption" runat="server" Text="Payment Option:" Style="color: #000000;"
                                                    meta:resourcekey="lblPaymentOptionResource1"></asp:Label>
                                            </td>
                                            <td width="80%">
                                                <asp:Label ID="lblPaymentOptionValue" runat="server" meta:resourcekey="lblPaymentOptionValueResource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="even">
                                <td colspan="4">
                                    <table style="width: 100%" cellspacing="0">
                                        <tr>
                                            <td width="20%" align="right" style="padding-right: 5px">
                                                <asp:Label ID="lblPaymentStatus" runat="server" Text="Payment Status:" Style="color: #000000;"
                                                    meta:resourcekey="lblPaymentStatusResource1"></asp:Label>
                                            </td>
                                            <td width="80%">
                                                <asp:Label ID="lblPaymentStatusValue" runat="server" meta:resourcekey="lblPaymentStatusValueResource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </div>
                        <tr class="odd">
                            <td width="20.35%" align="right" style="padding-right: 5px">
                                <asp:Label ID="Label1" runat="server" Text="Bar Country:" meta:resourcekey="lblBarCountryResource1"></asp:Label>
                            </td>
                            <td width="80%">
                                <asp:Label ID="lblBarredCountryValue" runat="server" Text='<%# Eval("lblBarredCountryValue") %>'
                                    meta:resourcekey="lblBarredCountryValueResource1"></asp:Label>
                                <asp:LinkButton ID="lbtnPreview" runat="server" Text="..." Font-Bold="true" OnClick="lbtnPreview_Click"
                                    Visible="false"></asp:LinkButton>
                                <div id="chckcountrylst" visible="false" class="smallinput_t200_barcountry" runat="server">
                                    <asp:CheckBoxList ID="chkbxlstBarCountry" runat="server" AutoPostBack="false" Font-Names="Verdana"
                                        Font-Size="9" Width="100%" meta:resourcekey="chkbxlstBarCountryResource1">
                                    </asp:CheckBoxList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%">
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btnMembership" runat="server" Text="Upgrade Membership" Visible="False"
                                                Style="margin-bottom: 20px;" Height="21px" Width="160px" CssClass="blue_button"
                                                meta:resourcekey="btnMembershipResource1" OnClick="btnMembership_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnback" runat="server" Visible="false" Text="Back" CssClass="blue_button"
                    OnClientClick="window.close();" />
            </td>
        </tr>
    </table>
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
                                <div style="height: 100%; width: 20%;" class="popupbox">
                                    <table style="height: 100%;" width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="popupbox-lefttop-corner">
                                            </td>
                                            <td class="popupbox-topbg">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="97%" align="left" class="popupbox-header">
                                                            <asp:Label ID="lblPreview" runat="server" Text="Bar Countries" CssClass="title"></asp:Label>
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
                                                            <div class="grid">
                                                                <asp:GridView ID="gvbarCompanyDetails" runat="server" AutoGenerateColumns="False"
                                                                    AlternatingRowStyle-CssClass="even" RowStyle-CssClass="odd" Width="100%" AllowPaging="True"
                                                                    OnPageIndexChanging="gvbarCompanyDetails_PageIndexChanging" CssClass="table-border"
                                                                    meta:resourcekey="gvbarCompanyDetailsResource1">
                                                                    <RowStyle CssClass="odd"></RowStyle>
                                                                    <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sr.No" SortExpression="Sr.No" ItemStyle-Width="8%"
                                                                            HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSlno" runat="server" Text='<%#Container.DataItemIndex+1 %>' />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bar Country" SortExpression="BarCountry" ItemStyle-Width="8%"
                                                                            HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblbarcuntry" runat="server" Text='<%# Eval("Barcountry") %>' meta:resourcekey="lblbarcuntryResource1" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EditRowStyle Width="100%" Wrap="True" />
                                                                    <RowStyle HorizontalAlign="Left" />
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
                                                                    <PagerStyle CssClass="headerback" HorizontalAlign="Center" />
                                                                </asp:GridView>
                                                            </div>
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
</asp:Content>
