<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="FaqQuestion.aspx.cs" Inherits="ICBrowser.Web.FaqQuestion" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .blue_button_fu
        {
            border: 1px solid #157dd7;
            text-align: center;
            font-family: Tahoma;
            font-weight: bold;
            font-size: 11px;
            color: #fff;
            height: 28px;
            background-image: url(../Images/buttonbg.gif);
            background-repeat: repeat-x;
            background-position: center center;
        }
        
        .fileupload
        {
            border: 1px solid #999999;
            text-align: center;
            font-family: Tahoma;
            font-weight: bold;
            font-size: 11px;
            color: #333333;
            background: url(../Images/but_bg.gif) repeat-x center center;
            height: 25px;
        }
        .bigtxtfieldAdmin
        {
            border: 1px solid #0096d6;
            font-family: Tahoma;
            font-size: 11px;
            color: #434647;
            background-image: url(../images/input-listbg.gif);
            background-repeat: repeat-x;
            background-position: left top;
            background-color: #fff;
            width: 800px;
            height: 130px;
            padding: 2px;
        }
        
        .FontLnkBtn
        {
            font-family: Tahoma;
            font-size: 20px;
            text-align: center; /* font-weight: bold;*/
            background: url(../Images/gradient-white-down-sm.png) repeat-x scroll 0 0 #618872;
            height: 100px;
            padding: 0 0 0 20px;
            border-bottom: 1px solid #5C5D5C;
        }
        
        .lblHead
        {
            font-family: Calibri;
            font-size: x-large;
            text-align: center;
            font-weight: bold;
            color: #64327A;
        }
        
        .lblHead1
        {
            font-family: Calibri;
            font-size: x-large;
            text-align: center;
            color: #64327A;
        }
        
        
        .greenmsgsd
        {
            font-size: small;
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
        .LblEngCn
        {
            font-weight: bold;
            font-size: medium;
            color: #076394;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server" Style="padding: 5px" Height="100%" Width="100%"
        meta:resourcekey="Panel1Resource1">
        <table>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblSucess" runat="server" Visible="False" Text="Question saved successfully."
                        CssClass="greenmsgsd" meta:resourcekey="lblSucessResource1" Style="text-align: center;"></asp:Label>
                    <asp:Label ID="lblError" runat="server" Visible="False" Text="Error occured, please try again later."
                        CssClass="redmsgsd" meta:resourcekey="lblErrorResource1" Style="text-align: center;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="20%" class="headerback" colspan="2">
                 <asp:Label ID="lblHeading2" runat="server" Text="Add New FAQ"
                        CssClass="header" meta:resourcekey="lblHeading2Resource1"></asp:Label>      
                </td>
            </tr>
            <tr>
                <td width="20%" align="right" valign="top">
                   <span class="errormsg">*</span><asp:Label ID="lblQuestion" runat="server" Text="Question (English)" CssClass="LblEngCn"
                        meta:resourcekey="lblQuestionResource1"></asp:Label>
                </td>
                <td width="70%">
                    <cc2:Editor ID="queEng" runat="server" Width="100%" validationgroup="free" meta:resourcekey="queEngResource1" />
                </td>
                <td width="10%">
                   <%-- <asp:RequiredFieldValidator ID="rfvQue" runat="server" Text="*" SetFocusOnError="True"
                        ControlToValidate="queEng" ForeColor="Red" ValidationGroup="free" meta:resourcekey="rfvQueResource1"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td width="20%" align="right" valign="top">
                    <span class="errormsg">*</span><asp:Label ID="lblAns" runat="server" Text="Answer (English)" CssClass="LblEngCn"
                        meta:resourcekey="lblAnsResource1"></asp:Label>
                </td>
                <td width="70%">
                    <cc2:Editor ID="ansEng" runat="server" Width="100%" TabIndex="36" validationgroup="free"
                        meta:resourcekey="ansEngResource1" />
                </td>
                <td width="10%">
                   <%-- <asp:RequiredFieldValidator ID="rfvAns" runat="server" Text="*" SetFocusOnError="True"
                        ControlToValidate="ansEng" ForeColor="Red" ValidationGroup="free" meta:resourcekey="rfvAnsResource1"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td width="20%" align="right" valign="top">
                    <span class="errormsg">*</span><asp:Label ID="lblQueCny" runat="server" Text="Question (Chinese)" CssClass="LblEngCn"
                        meta:resourcekey="lblQueCnyResource1"></asp:Label>
                </td>
                <td width="70%">
                    <cc2:Editor ID="queCny" runat="server" Width="100%" validationgroup="free" meta:resourcekey="queCnyResource1" />
                </td>
                <td width="10%">
                  <%--  <asp:RequiredFieldValidator ID="rfvQueCny" runat="server" Text="*" SetFocusOnError="True"
                        ControlToValidate="queCny" ForeColor="Red" ValidationGroup="free" meta:resourcekey="rfvQueCnyResource1"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td width="20%" align="right" valign="top">
                    <span class="errormsg">*</span><asp:Label ID="lblAnsCny" runat="server" Text="Answer (Chinese)" CssClass="LblEngCn"
                        meta:resourcekey="lblAnsCnyResource1"></asp:Label>
                </td>
                <td width="70%">
                    <cc2:Editor ID="ansCny" runat="server" Width="100%" validationgroup="free" meta:resourcekey="ansCnyResource1" />
                </td>
                <td width="10%">
                   <%-- <asp:RequiredFieldValidator ID="rfvAnsCny" runat="server" Text="*" SetFocusOnError="True"
                        ControlToValidate="ansCny" ForeColor="Red" ValidationGroup="free" meta:resourcekey="rfvAnsCnyResource1"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
            <td colspan="2">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="headerback">
                        <tr>
                            <td align="right" width="44%">
                                <asp:Button ID="btnQueSave" runat="server" Text="Save" CssClass="blue_button_fu"
                                    OnClick="btnQueSave_Click" ValidationGroup="free" meta:resourcekey="btnQueSaveResource1" />
                            </td>
                            <td width="16%" align="center">
                            <%-- <asp:LinkButton ID="LinkButton1" runat="server" CssClass="blue_button_fu" 
                        PostBackUrl="~/StaticData.aspx" ForeColor="White" >Back</asp:LinkButton>--%>
                        <asp:Button  ID="btnback" runat="server" CssClass="blue_button_fu"  Text="Back"  meta:resourcekey="LinkButton1Resource1" PostBackUrl="~/StaticData.aspx"/>
                        
                            </td>
                            <td width="44%" align="left">
                                <asp:Button ID="btnQueClear" runat="server" Text="Clear" CssClass="blue_button_fu"
                                    CausesValidation="False" OnClick="btnQueClear_Click" ValidationGroup="free" meta:resourcekey="btnQueClearResource1" />
                            </td>
                        </tr>
                    </table>
                </td>
            <td></td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
