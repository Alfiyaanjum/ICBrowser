<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="StaticData.aspx.cs" Inherits="ICBrowser.Web.StaticData" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .v_padding
        {
            padding-bottom: 14px;
        }
        
        
        .blue_button_fu
        {
            border: 1px solid #157dd7;
            text-align: center;
            font-weight: bold;
            color: #fff;
            background-image: url(../Images/buttonbg.gif);
            background-repeat: repeat-x;
            float: left;
            padding: 2px;
            margin-left: 5px;
        }
        
        .fileupload
        {
            border: 1px solid #999999;
        }
        .bigtxtfieldAdmin
        {
            border: 1px solid #0096d6;
            color: #434647;
            background-color: #fff;
            width: 800px;
            height: 130px;
            padding: 2px;
        }
        
        
        
        .FontLnkBtn
        {
            font-weight: bold;
            font-size: 16px;
            text-align: center;
        }
        
        
        .lblHead1
        {
            text-align: center;
            color: #64327A;
        }
        
        .lblcntus
        {
            text-align: center; /*color: #64327A;*/
            color: #036;
            font-weight: bold;
        }
        
        .greenmsgsd
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
        .redmsgsd
        {
            font-size: small;
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
        .buttsd
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
        }
        
        .mainnndiv
        {
            width: 100%;
            background-color: #EFFBFE;
            border: 1px solid #3F7FB5;
        }
        
        .LblEngCn
        {
            font-size: 12px;
            color: #076394;
        }
        div.floating-menu
        {
            position: fixed;
            background: #fff4c8;
            border: 1px solid #ffcc00;
            width: 150px;
            z-index: 100;
        }
        div.floating-menu a, div.floating-menu h3
        {
            display: block;
            margin: 0 0.5em;
        }
        #overhead-collect
        {
            position: absolute;
            top: -1px;
            padding-bottom: 1px;
            left: 0;
            right: 0;
            z-index: 125;
            background-color: #637768;
            border-bottom: 1px solid #313F3A;
            height: 3%;
        }
        #overhead
        {
            white-space: nowrap;
            border-collapse: collapse;
            vertical-align: middle;
            width: 25%;
        }
        a
        {
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainnndiv">
        <table border="0" cellpadding="2" cellspacing="0" width="100%">
            <tr>
                <td>
                    <div class="FontLnkBtn">
                        <table width="100%">
                            <tr class="headerback">
                                <td width="14%" valign="middle">
                                    <asp:LinkButton ID="lnkTab1" runat="server" OnClick="lnkTab1_Click" CausesValidation="False"
                                        Text="About Us" meta:resourcekey="lnkTab1Resource1"></asp:LinkButton>
                                </td>
                                <td width="14%" valign="middle">
                                    <asp:LinkButton ID="lnkTab2" runat="server" OnClick="lnkTab2_Click" CausesValidation="False"
                                        Text="Escrow" meta:resourcekey="lnkTab2Resource1"></asp:LinkButton>
                                </td>
                                <td width="14%" valign="middle">
                                    <asp:LinkButton ID="lnkTab4" runat="server" OnClick="lnkTab4_Click" CausesValidation="False"
                                        Text="Contact Us" meta:resourcekey="lnkTab4Resource1"></asp:LinkButton>
                                </td>
                                <td width="14%" valign="middle">
                                    <asp:LinkButton ID="lbtnFaq" runat="server" Text="FAQ" CausesValidation="False" OnClick="lbtnFaq_Click"
                                        meta:resourcekey="lbtnFaqResource1"></asp:LinkButton>
                                </td>
                                <td width="14%" valign="middle">
                                    <asp:LinkButton ID="lbtnWhyUs" runat="server" Text="Why Us" CausesValidation="False"
                                        meta:resourcekey="lbtnWhyUsResource1" OnClick="lbtnWhyUs_Click"></asp:LinkButton>
                                </td>
                                <td width="15%" valign="middle">
                                    <asp:LinkButton ID="lnkBtnLegalAgreement" runat="server" Text="Legal Agreement" CausesValidation="False"
                                        OnClick="lnkBtnLegalAgreement_Click" meta:resourcekey="lnkBtnLegalAgreementResource1"></asp:LinkButton>
                                </td>
                                <td width="15%" valign="middle">
                                    <asp:LinkButton ID="lnkBtnPrivacyPolicy" runat="server" Text="Privacy Policy" CausesValidation="False"
                                         meta:resourcekey="lnkBtnPrivacyPolicyResource1" 
                                        onclick="lnkBtnPrivacyPolicy_Click"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSucess" runat="server" Style="text-align: center;" Visible="False"
                        Text="Data saved successfully." CssClass="greenmsgsd" meta:resourcekey="lblSucessResource1"></asp:Label>
                    <asp:Label ID="lblError" runat="server" Visible="False" Text="Error Occured,please try again later."
                        CssClass="redmsgsd" Style="text-align: center;" meta:resourcekey="lblErrorResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:MultiView ID="myMV" runat="server" ActiveViewIndex="0">
                        <asp:View ID="myView1" runat="server">
                            <table width="100%">
                                <tr>
                                    <td width="18%" align="right">
                                        <asp:Label ID="lblSelectImage" runat="server" Text="Select Image:" Font-Bold="False"
                                            CssClass="LblEngCn" meta:resourcekey="lblSelectImageResource1"></asp:Label>
                                    </td>
                                    <td align="center" width="30%">
                                        <asp:FileUpload ID="FuImage" runat="server" CssClass="fileupload" meta:resourcekey="FuImageResource1"
                                            Width="100%" />
                                    </td>
                                    <td width="40%">
                                        <asp:Label ID="lblMesg" Visible="False" Text="Image Uploaded Sucessfully." runat="server"
                                            ForeColor="Blue" meta:resourcekey="lblMesgResource1"></asp:Label>
                                        <asp:Label ID="lblmsg" Visible="False" Text=" Only .jpg, .jpeg, .png, .gif files are allowed to upload."
                                            runat="server" ForeColor="Red" meta:resourcekey="lblmsgResource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="pnlAboutUs" runat="server" Style="padding: 5px" Height="100%" Width="100%"
                                DefaultButton="btnSubAu" meta:resourcekey="pnlAboutUsResource1">
                                <table>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblEngAu" runat="server" Text="English:" CssClass="LblEngCn" meta:resourcekey="lblEngAuResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="EngAu" runat="server" Width="100%" meta:resourcekey="EngAuResource2" />
                                        </td>
                                        <td width="10%">
                                            <%--<asp:RequiredFieldValidator ID="rfvTxtEng1" runat="server" Text="*" SetFocusOnError="True"
                                                ControlToValidate="EngAu" ForeColor="Red" meta:resourcekey="rfvTxtEng1Resource1"></asp:RequiredFieldValidator>
                                            --%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblCnAu" runat="server" Text="Chinese:" CssClass="LblEngCn" meta:resourcekey="lblCnAuResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="CnAu" runat="server" Width="100%" meta:resourcekey="CnAuResource2" />
                                        </td>
                                        <td width="10%">
                                            <%-- <asp:RequiredFieldValidator ID="rfvTxtCn1" runat="server" Text="*" SetFocusOnError="True"
                                                ControlToValidate="CnAu" ForeColor="Red" meta:resourcekey="rfvTxtCn1Resource1"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right" width="44%">
                                            <asp:Button ID="btnSubAu" runat="server" OnClick="btnSubAu_Click" Text="Save" CssClass="blue_button_fu"
                                                meta:resourcekey="btnSubAuResource1" />
                                            <asp:Button ID="btnCanAu" runat="server" Text="Clear" CssClass="blue_button_fu" meta:resourcekey="btnCanAuResource1"
                                                CausesValidation="False" OnClick="btnCanAu_Click" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:View>
                        <asp:View ID="myView2" runat="server">
                            <table width="100%">
                                <tr>
                                    <td width="18%" align="right">
                                        <asp:Label ID="lblSelectImage1" runat="server" Text="Select Image" Font-Bold="False"
                                            CssClass="LblEngCn" meta:resourcekey="lblSelectImage1Resource1"></asp:Label>
                                    </td>
                                    <td align="center" width="30%">
                                        <asp:FileUpload ID="FuImage1" runat="server" CssClass="fileupload" Width="100%" meta:resourcekey="FuImage1Resource1" />
                                    </td>
                                    <td width="40%">
                                        <asp:Label ID="lblMesg1" Visible="False" Text="Image Uploaded Sucessfully." runat="server"
                                            ForeColor="Blue" meta:resourcekey="lblMesg1Resource1"></asp:Label>
                                        <asp:Label ID="lblmsg1" Visible="False" Text=" Only .jpg, .jpeg, .png, .gif files are allowed to upload."
                                            runat="server" ForeColor="Red" meta:resourcekey="lblmsg1Resource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="pnlEscrow" runat="server" Style="padding: 5px" Height="100%" Width="100%"
                                DefaultButton="btnSubEs" meta:resourcekey="pnlEscrowResource1">
                                <table>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblEngEs" runat="server" Text="English:" CssClass="LblEngCn" meta:resourcekey="lblEngEsResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="EngEs" runat="server" Width="100%" TabIndex="36" meta:resourcekey="EngEsResource2" />
                                        </td>
                                        <td width="10%">
                                            <%-- <asp:RequiredFieldValidator ID="rfvTxtEng2" runat="server" Text="*" SetFocusOnError="True"
                                                ControlToValidate="EngEs" ForeColor="Red" meta:resourcekey="rfvTxtEng2Resource1"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblCnEs" runat="server" Text="Chinese:" CssClass="LblEngCn" meta:resourcekey="lblCnEsResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="CnEs" runat="server" Width="100%" TabIndex="36" meta:resourcekey="CnEsResource2" />
                                        </td>
                                        <td width="10%">
                                            <%-- <asp:RequiredFieldValidator ID="rfvTxtCn2" runat="server" Text="*" SetFocusOnError="True"
                                                ControlToValidate="CnEs" ForeColor="Red" meta:resourcekey="rfvTxtCn2Resource1"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSubEs" runat="server" OnClick="btnSubEs_Click" Text="Save" CssClass="blue_button_fu"
                                                meta:resourcekey="btnSubEsResource1" />
                                            <asp:Button ID="btnCanEs" runat="server" Text="Clear" CssClass="blue_button_fu" meta:resourcekey="btnCanEsResource1"
                                                CausesValidation="False" OnClick="btnCanEs_Click" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:View>
                        <asp:View ID="myView3" runat="server">
                            <table width="100%">
                                <tr>
                                    <td width="18%" align="right">
                                        <asp:Label ID="lblSelectImage3" runat="server" Text="Select Image" Font-Bold="False"
                                            CssClass="LblEngCn" meta:resourcekey="lblSelectImage3Resource1"></asp:Label>
                                    </td>
                                    <td align="left" width="20%">
                                        <asp:FileUpload ID="FuImage3" runat="server" CssClass="fileupload" Width="60%" meta:resourcekey="FuImage3Resource1" />
                                    </td>
                                    <td width="50%">
                                        <asp:Label ID="lblMesg2" Visible="False" Text="Image Uploaded Sucessfully." runat="server"
                                            ForeColor="Blue" meta:resourcekey="lblMesg2Resource1"></asp:Label>
                                        <asp:Label ID="lblmsg2" Visible="False" Text=" Only .jpg, .jpeg, .png, .gif files are allowed to upload."
                                            runat="server" ForeColor="Red" meta:resourcekey="lblmsg2Resource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%">
                                <tr class="table-row-subheader">
                                    <td width="18%" align="right">
                                        <asp:Label ID="lblCustServc" runat="server" Text="Customer Service" CssClass="lblcntus"
                                            meta:resourcekey="lblCustServcResource1"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="v_padding">
                                        <asp:Label ID="lblCustServiceEmail" runat="server" CssClass="LblEngCn" Text="Email Id"
                                            meta:resourcekey="lblCustServiceEmailResource1"></asp:Label>
                                    </td>
                                    <td width="70%" valign="top">
                                        <asp:TextBox ID="txtCustSerEmail" runat="server" CssClass="smallinput_t200" meta:resourcekey="txtCustSerEmailResource1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustSerEmail"
                                            ErrorMessage="Please Enter Email Id." ForeColor="Red" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="v_padding">
                                        <asp:Label ID="lblCustServicePhNo" runat="server" Text="Phone No" CssClass="LblEngCn"
                                            meta:resourcekey="lblCustServicePhNoResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCustSerPhNo" runat="server" CssClass="smallinput_t200" meta:resourcekey="txtCustSerPhNoResource1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCustSerPhNo"
                                            ErrorMessage="Please Enter Phone No." ForeColor="Red" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr class="table-row-subheader">
                                    <td align="right">
                                        <asp:Label ID="lblAdd" runat="server" Text="Advertisement" CssClass="lblcntus" meta:resourcekey="lblAddResource1"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="v_padding">
                                        <asp:Label ID="lblAddEmail" runat="server" Text="Email Id" CssClass="LblEngCn" meta:resourcekey="lblAddEmailResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAddEmail" runat="server" CssClass="smallinput_t200" meta:resourcekey="txtAddEmailResource1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvAddemail" runat="server" ControlToValidate="txtAddEmail"
                                            ErrorMessage="Please Enter Email Id." ForeColor="Red" meta:resourcekey="rfvAddemailResource1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="v_padding">
                                        <asp:Label ID="lblAddPno" runat="server" Text="Phone No" CssClass="LblEngCn" meta:resourcekey="lblAddPnoResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAddPno" runat="server" CssClass="smallinput_t200" meta:resourcekey="txtAddPnoResource1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvAddPno" runat="server" ControlToValidate="txtAddPno"
                                            ErrorMessage="Please Enter Phone No." ForeColor="Red" meta:resourcekey="rfvAddPnoResource1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr class="table-row-subheader">
                                    <td align="right">
                                        <asp:Label ID="lblsalesofc" runat="server" Text="Sales Office" CssClass="lblcntus"
                                            meta:resourcekey="lblsalesofcResource1"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="v_padding">
                                        <asp:Label ID="lblSalesOfcEmail" runat="server" Text="Email Id" CssClass="LblEngCn"
                                            meta:resourcekey="lblSalesOfcEmailResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSalesEmail" runat="server" CssClass="smallinput_t200" meta:resourcekey="txtSalesEmailResource1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvSalesOfcemail" runat="server" ControlToValidate="txtSalesEmail"
                                            ErrorMessage="Please Enter Email Id." ForeColor="Red" meta:resourcekey="rfvSalesOfcemailResource1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="v_padding">
                                        <asp:Label ID="lblSalesPno" runat="server" Text="Phone No" CssClass="LblEngCn" meta:resourcekey="lblSalesPnoResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSalesPno" runat="server" CssClass="smallinput_t200" meta:resourcekey="txtSalesPnoResource1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvSalesPno" runat="server" ControlToValidate="txtSalesPno"
                                            ErrorMessage="Please Enter Phone No." ForeColor="Red" meta:resourcekey="rfvSalesPnoResource1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="pnlContactUs" runat="server" Style="padding: 5px" Height="100%" Width="100%"
                                DefaultButton="btnSubCu" meta:resourcekey="pnlContactUsResource1">
                                <table>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblEngCu" runat="server" Text="English:" CssClass="LblEngCn" meta:resourcekey="lblEngCuResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="EngCu" runat="server" Width="100%" TabIndex="36" meta:resourcekey="EngCuResource2" />
                                        </td>
                                        <td width="10%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblCnCu" runat="server" Text="Chinese:" CssClass="LblEngCn" meta:resourcekey="lblCnCuResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="CnCu" runat="server" Width="100%" TabIndex="36" meta:resourcekey="CnCuResource2" />
                                        </td>
                                        <td width="10%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSubCu" runat="server" OnClick="btnSubCu_Click" Text="Save" CssClass="blue_button_fu"
                                                meta:resourcekey="btnSubCuResource1" />
                                            <asp:Button ID="btnCanCu" runat="server" Text="Clear" CssClass="blue_button_fu" meta:resourcekey="btnCanCuResource1"
                                                CausesValidation="False" OnClick="btnCanCu_Click" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:View>
                        <asp:View ID="myView4" runat="server">
                            <asp:Panel ID="Panel1" runat="server" Style="padding: 5px" Height="100%" Width="100%"
                                DefaultButton="btnSubCu" meta:resourcekey="Panel1Resource1">
                                <table>
                                    <tr>
                                        <td width="20%" align="right">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="Label1" runat="server" Text="Select Language:" CssClass="LblEngCn"
                                                meta:resourcekey="Label1Resource2"></asp:Label>
                                        </td>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td width="50%" align="left">
                                                        <asp:DropDownList ID="ddlLang" runat="server" Width="130px" CssClass="smallinput_t200"
                                                            ValidationGroup="free" meta:resourcekey="ddlLangResource1">
                                                            <asp:ListItem Text="--Select--" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                            <asp:ListItem Text="English" Value="1" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                                            <asp:ListItem Text="Chinese" Value="2" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvLang" runat="server" ControlToValidate="ddlLang"
                                                            ErrorMessage="Please Select Language." ForeColor="Red" InitialValue="0" SetFocusOnError="True"
                                                            ValidationGroup="free" meta:resourcekey="rfvLangResource1"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="50%" align="left">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnAddQue" runat="server" CssClass="blue_button_fu" Text="Add New FAQ"
                                                                        PostBackUrl="~/FaqQuestion.aspx" meta:resourcekey="btnAddQueResource1" />
                                                                </td>
                                                                <td width="30px">
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnDelete" runat="server" CssClass="blue_button_fu" Text="Delete FAQ"
                                                                        OnClick="btnDelete_Click" ValidationGroup="delete" CausesValidation="False" meta:resourcekey="btnDeleteResource1" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" align="right">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblDdlQueId" runat="server" Text="Select Question Number:" CssClass="LblEngCn"
                                                meta:resourcekey="lblDdlQueIdResource1"></asp:Label>
                                        </td>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td width="60%" align="left">
                                                        <asp:DropDownList ID="ddlQueId" runat="server" Width="130px" AutoPostBack="True"
                                                            CssClass="smallinput_t200" ValidationGroup="free" OnSelectedIndexChanged="ddlQueId_SelectedIndexChanged"
                                                            meta:resourcekey="ddlQueIdResource1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvDDL" runat="server" ControlToValidate="ddlQueId"
                                                            ErrorMessage="Please Select Question Number." ForeColor="Red" InitialValue="0"
                                                            SetFocusOnError="True" ValidationGroup="free" meta:resourcekey="rfvDDLResource1"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="40%" align="left">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblQuestion" runat="server" Text="Question:" CssClass="LblEngCn" meta:resourcekey="lblQuestionResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="queEdtr" runat="server" Width="100%" ValidationGroup="free" meta:resourcekey="queEdtrResource1" />
                                        </td>
                                        <td width="10%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblAns" runat="server" Text="Answer:" CssClass="LblEngCn" meta:resourcekey="lblAnsResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="ansEdtr" runat="server" Width="100%" TabIndex="36" ValidationGroup="free"
                                                meta:resourcekey="ansEdtrResource1" />
                                        </td>
                                        <td width="10%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnQueSave" runat="server" Text="Save" CssClass="blue_button_fu"
                                                OnClick="btnQueSave_Click" ValidationGroup="free" meta:resourcekey="btnQueSaveResource1" /><asp:Button
                                                    ID="btnQueClear" runat="server" Text="Clear" CssClass="blue_button_fu" CausesValidation="False"
                                                    OnClick="btnQueClear_Click" ValidationGroup="free" meta:resourcekey="btnQueClearResource1" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:View>
                        <asp:View ID="myView6" runat="server">
                            <asp:Panel ID="PnlWhyUs" runat="server" Style="padding: 5px" Height="100%" Width="100%"
                                meta:resourcekey="PnlWhyUsResource1">
                                <table>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblWhyUs" runat="server" Text="English:" CssClass="LblEngCn" meta:resourcekey="lblWhyUsEngResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="edtrlblWhyUsEng" runat="server" Width="100%" meta:resourcekey="edtrlblWhyUsEngResource1" />
                                        </td>
                                        <td width="10%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblWhyUsCn" runat="server" Text="Chinese:" CssClass="LblEngCn" meta:resourcekey="lblWhyUsCnResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="edtrWhyUsCn" runat="server" Width="100%" meta:resourcekey="edtrWhyUsCnResource1" />
                                        </td>
                                        <td width="10%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSavewhyUs" runat="server" Text="Save" CssClass="blue_button_fu"
                                                meta:resourcekey="btnSavewhyUsResource1" OnClick="btnSavewhyUs_Click" />
                                            <asp:Button ID="btnClearwhyus" runat="server" Text="Clear" CssClass="blue_button_fu"
                                                CausesValidation="False" meta:resourcekey="btnClearwhyusResource1" OnClick="btnClearwhyus_Click" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:View>
                        <asp:View ID="myView5" runat="server">
                            <asp:Panel ID="pnlLegalAgree" runat="server" Style="padding: 5px" Height="100%" Width="100%"
                                meta:resourcekey="pnlLegalAgreeResource1">
                                <table>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblLegalAgreeEng" runat="server" Text="English:" CssClass="LblEngCn"
                                                meta:resourcekey="lblLegalAgreeEngResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="edtrLegalAgreeEng" runat="server" Width="100%" meta:resourcekey="edtrLegalAgreeEngResource1" />
                                        </td>
                                        <td width="10%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblLegalAgreeCn" runat="server" Text="Chinese:" CssClass="LblEngCn"
                                                meta:resourcekey="lblLegalAgreeCnResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="edtrLegalAgreeCn" runat="server" Width="100%" meta:resourcekey="edtrLegalAgreeCnResource1" />
                                        </td>
                                        <td width="10%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSaveLegalAgree" runat="server" Text="Save" CssClass="blue_button_fu"
                                                OnClick="btnSaveLegalAgree_Click" meta:resourcekey="btnSaveLegalAgreeResource1" />
                                            <asp:Button ID="btnClearLegalAgree" runat="server" Text="Clear" CssClass="blue_button_fu"
                                                CausesValidation="False" OnClick="btnClearLegalAgree_Click" meta:resourcekey="btnClearLegalAgreeResource1" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:View>
                        <asp:View ID="myView7" runat="server">
                            <asp:Panel ID="PnlPrivatePolicy" runat="server" Style="padding: 5px" Height="100%" Width="100%"
                                meta:resourcekey="PnlPrivatePolicyResource1">
                                <table>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblPrivatePolicyEng" runat="server" Text="English:" CssClass="LblEngCn"
                                                meta:resourcekey="lblPrivatePolicyEngResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="edtrPrivatePolicyEng" runat="server" Width="100%" meta:resourcekey="edtrPrivatePolicyEngResource1" />
                                        </td>
                                        <td width="10%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" align="right" valign="top">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblPrivatePolicyCn" runat="server" Text="Chinese:" CssClass="LblEngCn"
                                                meta:resourcekey="lblPrivatePolicyCnResource1"></asp:Label>
                                        </td>
                                        <td width="70%">
                                            <cc2:Editor ID="edtrPrivatePolicyCn" runat="server" Width="100%" meta:resourcekey="edtrPrivatePolicyCnResource1" />
                                        </td>
                                        <td width="10%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSavePrivatePolicy" runat="server" Text="Save" CssClass="blue_button_fu"
                                                 meta:resourcekey="btnSavePrivatePolicyResource1" 
                                                onclick="btnSavePrivatePolicy_Click" />
                                            <asp:Button ID="btnClearPrivatePolicy" runat="server" Text="Clear" CssClass="blue_button_fu"
                                                CausesValidation="False"  
                                                meta:resourcekey="btnClearPrivatePolicyResource1" 
                                                onclick="btnClearPrivatePolicy_Click" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
