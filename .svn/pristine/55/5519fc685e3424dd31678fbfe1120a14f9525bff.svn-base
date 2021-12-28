<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeBehind="ViewBuyersProfile.aspx.cs"
    Inherits="ICBrowser.Web.ViewBuyersProfile" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Panel ID="Panel2" runat="server" smartnavigation="true" DefaultButton="input"
            meta:resourcekey="Panel2Resource1">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table cellspacing="0" cellpadding="2" width="100%">
                        <tr>
                            <td align="left">
                                <asp:Button ID="btnUpgradeMembership" runat="server" Text="Upgrade Membership" CssClass="blue_button"
                                    OnClick="btnUpgradeMembership_Click" />
                            </td>
                            <td>
                                <table align="right">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblLastUpdated" runat="server" Text="Last Updated Date :" meta:resourcekey="lblLastUpdatedResource1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLastUpdatedvalue" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="table-row">
                                <asp:Label ID="lblCompanyDetails" runat="server" Text="Company Details :" meta:resourcekey="lblCompanyDetailsResource1"></asp:Label>
                            </td>
                            <td align="right" class="table-row">
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
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table style="width: 100%" cellspacing="0">
                                    <tr class="even">
                                        <td width="30%">
                                            <asp:Label ID="lblCompanyName" runat="server" Text="Company Name :" meta:resourcekey="lblCompanyNameResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <asp:Label ID="lblcompnamevalue" runat="server" meta:resourcekey="lblcompnamevalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtcompnamevalue" runat="server" Visible="False" CssClass="smallinput_t"
                                                MaxLength="30" meta:resourcekey="txtcompnamevalueResource1"></asp:TextBox>
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
                            <td colspan="2">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="30%">
                                            <asp:Label ID="lblOwnersname" runat="server" Text="Owner Name :" meta:resourcekey="lblOwnersnameResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <asp:Label ID="lblOwnersnamevalue" runat="server" meta:resourcekey="lblOwnersnamevalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtOwnersnamevalue" runat="server" Visible="False" CssClass="smallinput_t"
                                                MaxLength="30" meta:resourcekey="txtOwnersnamevalueResource1"></asp:TextBox>
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
                                        <td width="20%">
                                            <asp:Label ID="lblFirstName" runat="server" Text="First Name :" meta:resourcekey="lblFirstNamevalueResource1"></asp:Label>
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
                                        <td width="20%">
                                            <asp:Label ID="lblLastName" runat="server" Text="Last Name :" meta:resourcekey="lblSecondNamevalueResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblLastNameValue" runat="server" meta:resourcekey="lblLastNameValueResource1"></asp:Label>
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
                        <tr>
                            <td class="table-row">
                                <asp:Label ID="lblAddressDetails" runat="server" Text="Address Details :" meta:resourcekey="lblAddressDetailsResource1"></asp:Label>
                            </td>
                            <td align="right" class="table-row">
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
                            <td colspan="2">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="20%">
                                            <asp:Label ID="lblAddress1" runat="server" Text="Primary Address :" Style="font-weight: 700;"
                                                meta:resourcekey="lblAddress1Resource1"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblmsg" runat="server" Text="(Max Length 200 chars)" Style="font-size: x-small;"
                                                meta:resourcekey="lblmsgResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblAddress1value" runat="server" meta:resourcekey="lblAddress1valueResource1"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="txtAddress1" TextMode="MultiLine" MaxLength="200" runat="server"
                                                CssClass="smallinput" Visible="False" Width="180px" Height="60px" meta:resourcekey="txtAddress1Resource1"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ControlToValidate="txtAddress1"
                                                ErrorMessage="Please Enter Primary Address" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rfvAddress1Resource1" />
                                            <%--<asp:RegularExpressionValidator ID="rgvtxtAddress12" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                        Display="Dynamic" ValidationGroup="b" ControlToValidate="txtAddress1" SetFocusOnError="True"
                                        ForeColor="Red" ValidationExpression="^((?![<>]).)*$" 
                                        meta:resourcekey="rgvtxtAddress12Resource1"></asp:RegularExpressionValidator>--%>
                                            <asp:RegularExpressionValidator ID="rgvtxtAddress1" ControlToValidate="txtAddress1"
                                                ErrorMessage="Exceeding 200 characters" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="b" ValidationExpression="^[\s\S]{0,200}$"
                                                runat="server" meta:resourcekey="rgvtxtAddress1Resource1" />
                                        </td>
                                        <td width="20%">
                                            <asp:Label ID="lblAddress2" runat="server" Text="Secondary Address :" Style="font-weight: 700;"
                                                meta:resourcekey="lblAddress2Resource1"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblmsg1" runat="server" Text="(Max Length 200 chars)" Style="font-size: x-small;"
                                                meta:resourcekey="lblmsg1Resource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblAddress2value" runat="server" meta:resourcekey="lblAddress2valueResource1"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="txtAddress2" TextMode="MultiLine" MaxLength="200" runat="server"
                                                CssClass="smallinput" Visible="False" Width="180px" Height="60px" meta:resourcekey="txtAddress2Resource1"
                                                OnTextChanged="txtAddress2_TextChanged"></asp:TextBox>
                                            <br />
                                            <%--<asp:RegularExpressionValidator ID="rgvtxtAddress21" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                        Display="Dynamic" ValidationGroup="b" ControlToValidate="txtAddress2" ForeColor="Red"
                                        ValidationExpression="^((?![<>]).)*$" 
                                        meta:resourcekey="rgvtxtAddress21Resource1"></asp:RegularExpressionValidator>--%>
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
                            <td colspan="2">
                                <table style="width: 100%" cellspacing="0">
                                    <tr class="even">
                                        <td width="20%">
                                            <asp:Label ID="lblPrimaryCity" runat="server" Text="City :" meta:resourcekey="lblPrimaryCityResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblPrimaryCityvalue" runat="server" meta:resourcekey="lblPrimaryCityvalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtPrimaryCity" runat="server" Visible="False" MaxLength="30" CssClass="smallinput_t"
                                                meta:resourcekey="txtPrimaryCityResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtPrimaryCity"
                                                ErrorMessage="Please Enter City" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                ValidationGroup="b" meta:resourcekey="rfvCityResource1" />
                                            <asp:RegularExpressionValidator ID="rgvtxtPrimaryCityvalue" runat="server" ControlToValidate="txtPrimaryCity"
                                                ErrorMessage="Enter Valid City" ValidationExpression="^[^0-9]+$" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rgvtxtPrimaryCityvalueResource1"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="rgvtxtPrimaryCityvalue1" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                Display="Dynamic" ValidationGroup="b" ControlToValidate="txtPrimaryCity" ForeColor="Red"
                                                ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtPrimaryCityvalue1Resource1"></asp:RegularExpressionValidator>
                                        </td>
                                        <td width="20%">
                                            <asp:Label ID="lblSecondaryCity" runat="server" Text="City :" meta:resourcekey="lblSecondaryCityResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblSecondaryCityvalue" runat="server" meta:resourcekey="lblSecondaryCityvalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtSecondaryCity" runat="server" Visible="False" CssClass="smallinput_t"
                                                MaxLength="30" meta:resourcekey="txtSecondaryCityResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvtxtSecondaryCity1" runat="server" ControlToValidate="txtSecondaryCity"
                                                ErrorMessage="Enter Valid City" ValidationExpression="^[^0-9]+$" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rgvtxtSecondaryCity1Resource1"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="rgvtxtSecondaryCity" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                Display="Dynamic" ValidationGroup="b" ControlToValidate="txtSecondaryCity" ForeColor="Red"
                                                ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvtxtSecondaryCityResource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="20%">
                                            <asp:Label ID="lblPriamryZipCode" runat="server" Text="Zip/Postal Code :" meta:resourcekey="lblPriamryZipCodeResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblPriamryZipCodeValue" runat="server" meta:resourcekey="lblPriamryZipCodeValueResource1"></asp:Label>
                                            <asp:TextBox ID="txtPriamryZipCode" runat="server" Visible="False" CssClass="smallinput_t"
                                                MaxLength="6" meta:resourcekey="txtPriamryZipCodeResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPriamryZipCode" runat="server" ControlToValidate="txtPriamryZipCode"
                                                ErrorMessage="Please Enter Primary Zip" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rfvPriamryZipCodeResource1" />
                                            <asp:RegularExpressionValidator ID="rgvPriamryZipCodevalue" runat="server" ControlToValidate="txtPriamryZipCode"
                                                ErrorMessage="Enter Valid Zip Code." ValidationExpression="^[0-9]{6}" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rgvPriamryZipCodevalueResource1"></asp:RegularExpressionValidator>
                                        </td>
                                        <td width="20%">
                                            <asp:Label ID="lblSecondaryZipCode" runat="server" Text="Zip/Postal Code :" meta:resourcekey="lblSecondaryZipCodeResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblSecondaryZipCodeValue" runat="server" meta:resourcekey="lblSecondaryZipCodeValueResource1"></asp:Label>
                                            <asp:TextBox ID="txtSecondaryZipCode" runat="server" Visible="False" CssClass="smallinput_t"
                                                MaxLength="6" meta:resourcekey="txtSecondaryZipCodeResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvSecondaryZipCode" runat="server" ControlToValidate="txtSecondaryZipCode"
                                                ErrorMessage="Enter Valid Zip Code." ValidationExpression="^[0-9]{6}" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rgvSecondaryZipCodeResource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table style="width: 100%" cellspacing="0">
                                    <tr class="even">
                                        <td width="20%">
                                            <asp:Label ID="lblPrimaryState" runat="server" Text="State :" meta:resourcekey="lblPrimaryStateResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblPrimaryStatevalue" runat="server" meta:resourcekey="lblPrimaryStatevalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtPrimaryState" runat="server" Visible="False" MaxLength="30" CssClass="smallinput_t"
                                                meta:resourcekey="txtPrimaryStateResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvPrimaryState" runat="server" ControlToValidate="txtPrimaryState"
                                                ErrorMessage="Enter Valid State" ValidationExpression="^[^0-9]+$" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rgvPrimaryStateResource1"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="rgvPrimaryState1" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                Display="Dynamic" ValidationGroup="b" ControlToValidate="txtPrimaryState" ForeColor="Red"
                                                ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvPrimaryState1Resource1"></asp:RegularExpressionValidator>
                                        </td>
                                        <td width="20%">
                                            <asp:Label ID="lblSecondaryState" runat="server" Text="State :" meta:resourcekey="lblSecondaryStateResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblSecondaryStateValue" runat="server" meta:resourcekey="lblSecondaryStateValueResource1"></asp:Label>
                                            <asp:TextBox ID="txtSecondaryState" runat="server" Visible="False" CssClass="smallinput_t"
                                                MaxLength="30" meta:resourcekey="txtSecondaryStateResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvSecondaryState" runat="server" ControlToValidate="txtSecondaryState"
                                                ErrorMessage="Enter Valid State" ValidationExpression="^[^0-9]+$" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rgvSecondaryStateResource1"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="rgvSecondaryState1" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                Display="Dynamic" ValidationGroup="b" ControlToValidate="txtSecondaryState" ForeColor="Red"
                                                ValidationExpression="^((?![<>]).)*$" meta:resourcekey="rgvSecondaryState1Resource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="20%">
                                            <asp:Label ID="lblPrimaryCountry" runat="server" Text="Country :" meta:resourcekey="lblPrimaryCountryResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblPrimaryCountryvalue" runat="server" meta:resourcekey="lblPrimaryCountryvalueResource1"></asp:Label>
                                            <br />
                                            <asp:DropDownList ID="ddlPrimaryCountry" Width="150px" runat="server" Visible="False"
                                                CssClass="smallinput_t200_register" MaxLength="30" meta:resourcekey="ddlPrimaryCountryResource1"
                                                OnSelectedIndexChanged="ddlPrimaryCountry_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvPrimaryCountry" runat="server" ControlToValidate="ddlPrimaryCountry"
                                                InitialValue="0" ErrorMessage="Please Select Country" ForeColor="Red" SetFocusOnError="True"
                                                Display="Dynamic" ValidationGroup="b" meta:resourcekey="rfvPrimaryCountryResource1" />
                                        </td>
                                        <td width="20%">
                                            <asp:Label ID="lblSecondaryCountry" runat="server" Text="Country :" meta:resourcekey="lblSecondaryCountryResource1"></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblSecondaryCountryValue" runat="server" meta:resourcekey="lblSecondaryCountryValueResource1"></asp:Label>
                                            <%--<asp:TextBox ID="ddlSecondaryCountry" runat="server" Visible="False" CssClass="smallinput_t"
                                                MaxLength="30" meta:resourcekey="ddlSecondaryCountryResource1"></asp:TextBox>--%>
                                            <br />
                                            <asp:DropDownList ID="ddlSecondaryCountry" Width="150px" runat="server" Visible="False"
                                                CssClass="smallinput_t200_register" MaxLength="30" meta:resourcekey="ddlSecondaryCountryResource1">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="even">
                            <td colspan="4">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="40%">
                                            <asp:Label ID="lblPanNumber" runat="server" Text="Permanent Account Number:"></asp:Label>
                                        </td>
                                        <td width="60%">
                                            <asp:Label ID="lblPanNumberValue" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtPanNumber" runat="server" CssClass="smallinput_t" Visible="false"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="regexvalPanNumber" runat="server" ErrorMessage="Invalid PAN Number Format"
                                                ControlToValidate="txtPanNumber" ValidationExpression="(\s*)[A-Z][A-Z][A-Z][A-Z][A-Z][0-9][0-9][0-9][0-9][A-Z](\s*)$"
                                                Display="Dynamic" ValidationGroup="b" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="table-row">
                                <asp:Label ID="lblContactDetails" runat="server" Text="Contact Details :" meta:resourcekey="lblContactDetailsResource1"></asp:Label>
                            </td>
                            <td class="table-row" align="right">
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
                                        <td width="30%">
                                            <asp:Label ID="lblEmail" runat="server" Text="Email :" meta:resourcekey="lblEmailResource1"></asp:Label>
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
                                                ForeColor="Red" Display="Dynamic" ValidationGroup="c" meta:resourcekey="rgvPrimaryCountryResource1"></asp:RegularExpressionValidator>
                                            <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                        Display="Dynamic" ValidationGroup="b" 
                                        ControlToValidate="ddlPrimaryCountry" ForeColor="Red"
                                        ValidationExpression="^((?![<>]).)*$" 
                                        meta:resourcekey="rgvPrimaryCountry1Resource1"></asp:RegularExpressionValidator>--%>
                                        </td>
                                        <td width="15%">
                                            <asp:Button ID="btnGenerateCode" runat="server" Text="Generate Code" CssClass="blue_button"
                                                Visible="false" Height="28px" Width="102px" meta:resourcekey="btnGenerateCodeResource1"
                                                OnClick="btnGenerateCode_Click1" />
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
                                        <td width="30%">
                                            <asp:Label ID="lblEmailPreference" runat="server" Text="Email Preference :" meta:resourcekey="lblEmailPreferenceResource1"></asp:Label>
                                        </td>
                                        <td width="70%" colspan="5" align="left">
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
                                                meta:resourcekey="rfvEmailPreferenceResource1" 
                                                ></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%" cellspacing="0">
                                    <tr class="even">
                                        <td width="30%">
                                            <asp:Label ID="lblWebsiteurl" runat="server" Text="Website Url :" meta:resourcekey="lblWebsiteurlResource1"></asp:Label>
                                            <asp:Label ID="lblexa" runat="server" Text="(ex:http://www.yahoo.com)" Style="font-size: x-small;"
                                                meta:resourcekey="lblexaResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
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
                                        <td width="30%">
                                            <asp:Label ID="lblPhone" runat="server" Text="Phone :" meta:resourcekey="lblPhoneResource1"></asp:Label>
                                        </td>
                                        <td>
                                            <span class="style1">+</span>
                                        </td>
                                        <td width="5%">
                                            <asp:Label ID="lblCountrycode" runat="server" meta:resourcekey="lblCountrycodeResource1"></asp:Label>
                                            <asp:TextBox ID="txtCountryCode" runat="server" MaxLength="4" Height="20px" Width="30px"
                                                CssClass="smallinput_t" Visible="False" meta:resourcekey="txtCountryCodeResource1"></asp:TextBox>
                                        </td>
                                        <td>
                                            <span class="style1">-</span>
                                        </td>
                                        <td width="65%">
                                            <asp:Label ID="lblPhonevalue" runat="server" meta:resourcekey="lblPhonevalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtPhone" runat="server" MaxLength="11" Visible="False" Height="22px"
                                                CssClass="smallinput_t" Width="95px" meta:resourcekey="txtPhoneResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                                                Display="Dynamic" ErrorMessage="Please Enter Phone no." ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="c" meta:resourcekey="rfvPhoneResource1" />
                                            <asp:RegularExpressionValidator ID="rgvPhonevalue" runat="server" ControlToValidate="txtPhone"
                                                Display="Dynamic" ErrorMessage="Enter Valid Phone no" ForeColor="Red" ValidationExpression="^[0-9]{0,11}"
                                                ValidationGroup="c" meta:resourcekey="rgvPhonevalueResource1"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvCountryCode" runat="server" ControlToValidate="txtCountryCode"
                                                Display="Dynamic" ErrorMessage="Please Enter Country Code" ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="c" meta:resourcekey="rfvCountryCodeResource1" />
                                            <asp:RegularExpressionValidator ID="rgvCountryCode" runat="server" ControlToValidate="txtCountryCode"
                                                Display="Dynamic" ErrorMessage="Enter Valid Country Code" ForeColor="Red" ValidationExpression="^[0-9]+$"
                                                ValidationGroup="c" meta:resourcekey="rgvCountryCodeResource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%" cellspacing="0">
                                    <tr class="even">
                                        <td width="30%">
                                            <asp:Label ID="lblExtension" runat="server" Text="Extension :" meta:resourcekey="lblExtensionResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <asp:Label ID="lblExtensionvalue" runat="server" meta:resourcekey="lblExtensionvalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtExtension" runat="server" MaxLength="5" Visible="False" CssClass="smallinput_t"
                                                meta:resourcekey="txtExtensionResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvExtensionvalue" runat="server" ControlToValidate="txtExtension"
                                                Display="Dynamic" ErrorMessage="Enter Valid Extension" ForeColor="Red" ValidationExpression="^[0-9]+$"
                                                ValidationGroup="c" meta:resourcekey="rgvExtensionvalueResource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%" cellspacing="0">
                                    <tr>
                                        <td width="30%">
                                            <asp:Label ID="lblMobile" runat="server" Text="Mobile :" meta:resourcekey="lblMobileResource1"></asp:Label>
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
                        </tr>
                        <tr class="even">
                            <td colspan="4">
                                <table style="width: 100%">
                                    <tr>
                                        <td width="30%">
                                            <asp:Label ID="lblFax" runat="server" Text="Fax :" meta:resourcekey="lblFaxResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <asp:Label ID="lblFaxvalue" runat="server" meta:resourcekey="lblFaxvalueResource1"></asp:Label>
                                            <asp:TextBox ID="txtFax" runat="server" Visible="False" MaxLength="11" CssClass="smallinput_t"
                                                meta:resourcekey="txtFaxResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgvFaxvalue" runat="server" ControlToValidate="txtFax"
                                                ErrorMessage="Enter Valid Fax no" ValidationExpression="^[0-9]{0,11}" ForeColor="Red"
                                                Display="Dynamic" ValidationGroup="c" meta:resourcekey="rgvFaxvalueResource1"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="table-row">
                                <asp:Label ID="lblCurrencyDetails" runat="server" Text="Other Details :" meta:resourcekey="lblCurrencyDetailsResource1"
                                    Style="font-weight: 400;"></asp:Label>
                                <asp:ImageButton ID="input" runat="server" Width="1px" Height="1px" ImageUrl="~/Images/menubg.png"
                                    meta:resourcekey="inputResource1" />
                            </td>
                            <td class="table-row" align="right">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="lnkCurrencyDetails" runat="server" Text="Edit" Width="50px" Height="20px"
                                                CssClass="blue_button" meta:resourcekey="lnkCurrencyDetailsResource1" OnClick="lnkCurrencyDetails_Click1" />
                                        </td>
                                        <td>
                                            <asp:Button ID="lnkCurrencyDetailsSave" runat="server" Text="Save" Width="50px" ValidationGroup="d"
                                                Visible="false" Height="20px" CssClass="blue_button" meta:resourcekey="lnkCurrencyDetailsSaveResource1"
                                                OnClick="lnkCurrencyDetailsSave_Click1" />
                                        </td>
                                        <td>
                                            <asp:Button ID="lnkCurrencyDetailsCancel" runat="server" Text="Cancel" Width="50px"
                                                Height="20px" CssClass="blue_button" Visible="false" meta:resourcekey="lnkCurrencyDetailsCancelResource1"
                                                OnClick="lnkCurrencyDetailsCancel_Click1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%" cellspacing="0">
                                    <tr>
                                        <td colspan="4">
                                            <table style="width: 100%" cellspacing="0">
                                                <tr class="even">
                                                    <td width="30%">
                                                        <asp:Label ID="lblSpecializaion" runat="server" Text="Specialization :" meta:resourcekey="lblSpecializaionResource1"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="lblmsg3" runat="server" Text="(Max Length 200 chars)" Style="font-size: x-small;"
                                                            meta:resourcekey="lblmsg3Resource1"></asp:Label>
                                                    </td>
                                                    <td width="70%">
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
                                    <tr>
                                        <td width="30%">
                                            <asp:Label ID="lblCurrency" runat="server" Text="Currency :" meta:resourcekey="lblCurrencyResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
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
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>
