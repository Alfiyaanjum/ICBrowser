<%@ Page Language="C#" Title="ICBrowser.com buy and sell electronic components" AutoEventWireup="true" CodeBehind="transactionPage.aspx.cs"
    Inherits="ICBrowser.Web.transactionPage" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ Register Src="Controls/TopPanel.ascx" TagName="TopPanel" TagPrefix="uc1" %>
<%@ Register Src="Controls/RightPanel.ascx" TagName="RightPanel" TagPrefix="uc1" %>
<%@ Register Src="Controls/BottomPanel.ascx" TagName="BottomPanel" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head id='Head1' runat='server'>
    <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
    <meta http-equiv='X-UA-Compatible' content='IE=8' />
    <title>ICBrowser</title>
    <link href='Styles/style.css' rel='stylesheet' type='text/css' />
    <link href='Styles/main.css' rel='stylesheet' type='text/css' />
    <script src='Scripts/dpEncodeRequest.js' type='text/javascript'></script>
    <script type="text/javascript">
        function encodeTxnRequest() {
            //alert(window.document.forms[0].requestparameter.value);
            window.document.forms[0].requestparameter.value = encodeValue(window.document.forms[0].requestparameter.value);
            //alert(window.document.forms[0].requestparameter.value);
            //document.ecom.requestparameter.value = encodeValue(document.ecom.requestparameter.value);
            //window.document.forms[0].submit();
        } 
    </script>
    <link href="Styles/themes/start/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.5/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <script src="../Scripts/jquery.simplyscroll.js" type="text/javascript"></script>
    <link rel="stylesheet" href="Styles/jquery.simplyscroll.css" media="all" type="text/css" />
    <%--style for login control--%>
    <style type="text/css">
        body
        {
            font-size: 60%;
        }
        label, input
        {
            display: block;
        }
        input.text
        {
            margin-bottom: 05px;
            width: 80%;
            padding: .4em;
        }
        fieldset
        {
            padding: 0;
            border: 0; /*margin-top: 10px;*/
        }
        h1
        {
            font-size: 1.2em;
            margin: .6em 0;
        }
        div#users-contain
        {
            width: 350px;
            margin: 20px 0;
        }
        div#users-contain table
        {
            margin: 1em 0;
            border-collapse: collapse;
            width: 100%;
        }
        div#users-contain table td, div#users-contain table th
        {
            border: 1px solid #eee;
            padding: .6em 10px;
            text-align: left;
        }
        .ui-dialog .ui-state-error
        {
            padding: .3em;
        }
        .validateTips
        {
            border: 1px solid transparent;
            padding: 0.3em;
        }
        .style1
        {
            width: 315px;
        }
    </style>
    <%--Javascript For Login--%>
    <script type="text/javascript">
        $.fx.speeds._default = 1000;
        $(document).ready(function () {
            document.getElementById('txtPassword').onkeypress = function (e) {
                if (!e) e = window.event;
                if (e.keyCode == '13') {
                    document.getElementById("HiddenUsername").value = $("#txtUname").val();
                    document.getElementById("HiddenPassword").value = $("#txtPassword").val();
                    $("#dialog-form").dialog("close");
                    document.getElementById("<%=btnNew.ClientID %>").click();
                    return false;
                }
            }

            $("#dialog-form").dialog({

                autoOpen: false,
                show: "blind",
                hide: "blind"
            });
        });

        $(function () {
            $("#dialog:ui-dialog").dialog("destroy");
            allFields = $([]).add(name).add(password),
            	tips = $(".validateTips");

            var name = $("#txtUname"),
			password = $("#txtPassword"),
			allFields = $([]).add(name).add(password),
			tips = $(".validateTips");

            function updateTips(t) {
                tips
				.text(t)
				.addClass("ui-state-highlight");
                setTimeout(function () {
                    tips.removeClass("ui-state-highlight", 1500);
                }, 500);
            }

            function checkLength(o, n, min, max) {
                if (o.val().length > max || o.val().length < min) {
                    o.addClass("ui-state-error");
                    updateTips("Length of " + n + " must be between " +
					min + " and " + max + ".");
                    return false;
                } else {
                    return true;
                }
            }

            function checkRegexp(o, regexp, n) {
                if (!(regexp.test(o.val()))) {
                    o.addClass("ui-state-error");
                    updateTips(n);
                    return false;
                } else {
                    return true;
                }
            }

            $("#dialog-form").dialog({
                autoOpen: false,
                height: 185,
                width: 251,
                modal: true,
                position: [1031, 98],
                draggable: false,
                buttons: {
                    "Login": function () {
                        var bValid = true;
                        allFields.removeClass("ui-state-error");
                        bValid = bValid && checkLength(name, "txtUname", 3, 16);
                        bValid = bValid && checkLength(password, "txtPassword", 5, 16);
                        //bValid = bValid && checkRegexp(name, /^[a-z]([0-9a-z_])+$/i, "Username may consist of a-z, 0-9, underscores, begin with a letter.");
                        //bValid = bValid && checkRegexp(password, /^([0-9a-zA-Z])+$/, "Password field only allow : a-z 0-9");

                        if (bValid) {
                            document.getElementById("HiddenUsername").value = $("#txtUname").val();
                            document.getElementById("HiddenPassword").value = $("#txtPassword").val();

                            $(this).dialog("close");
                            document.getElementById("<%=btnNew.ClientID %>").click();
                        }
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                        $("#HiddenValidUser").value == "true";
                    }
                },
                close: function () {
                    allFields.val("").removeClass("ui-state-error");
                }
            });

            $("#hyp_log")
			.click(function () {
			    $("#dialog-form").dialog("open");
			});

        });

        $(document).ready(function () {
            if ($("#HiddenValidUser").val() == "false") {
                alert('Username or Password is not valid.');
                $("#HiddenValidUser").value == "true"
                $("#dialog-form").dialog("open");
            }
        });    
    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $("#scroller").simplyScroll({ orientation: 'vertical', direction: 'backwards', customClass: 'vert' });
        });
    </script>
</head>
<body>
    <form name="ecom" id="ecom" runat="server" method="post" action="http://test.timesofmoney.com/direcpay/secure/dpMerchantTransaction.jsp"
    onsubmit="encodeTxnRequest();">
    <div id="main_container">
        <div>
            <asp:HiddenField ID="HiddenUsername" runat="server" />
            <asp:HiddenField ID="HiddenPassword" runat="server" />
            <asp:HiddenField ID="HiddenValidUser" runat="server" />
            <asp:Button runat="server" Style="display: none" ID="btnNew" Text="Submit" OnClick="btnNew_Click"
                ValidationGroup="SignInValidation1" meta:resourcekey="btnNewResource1" />
            <div id="dialog-form" title="Login" class="ui-dialog">
                <fieldset>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:Label ID="lbluname" runat="server" meta:resourcekey="lblunameResource1" Text="Name:-"></asp:Label>
                            </td>
                            <td>
                                <input type="text" name="name" id="txtUname" class="text ui-widget-content ui-corner-all" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblpass" runat="server" Text="Password:-" meta:resourcekey="lblpassResource1"></asp:Label>
                            </td>
                            <td>
                                <input type="password" name="password" id="txtPassword" value="" class="text ui-widget-content ui-corner-all" />
                            </td>
                        </tr>
                        <tr style="width: 100%" align="left">
                            <td style="width: 50%" align="left">
                                <asp:HyperLink ID="HyperLink4" runat="server" meta:resourcekey="HypNewUsrResource1"
                                    ForeColor="#316192" Text="Create New User" NavigateUrl="~/Register.aspx"></asp:HyperLink>
                            </td>
                            <td style="width: 50%" align="left">
                                <asp:HyperLink ID="HyperLink5" runat="server" meta:resourcekey="HypForPassResource1"
                                    ForeColor="#316192" Text="Forgot Password"></asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
        <%--main table start--%>
        <table width="1022" border="0" cellspacing="0" cellpadding="0">
            <%--top tr for top_bg--%>
            <tr>
                <td colspan="3" align="left" valign="top">
                    <img src="images/top_bg.jpg" width="1022" height="18" />
                </td>
            </tr>
            <%--tr for IC_logo--%>
            <tr>
                <td style="background-repeat: repeat-y; background-image: url(images/left_side_bg.jpg)"
                    width="13" align="left" valign="top">
                </td>
                <td width="996" align="left" valign="top" bgcolor="#FFFFFF">
                    <!--main body start-->
                    <div style="padding: 10px 10px 10px 10px">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="224" align="left" valign="top">
                                    <img src="images/icb_logo.jpg" alt="" width="218" height="51" />
                                </td>
                                <td width="618" align="right" valign="top">
                                    <div id="login_box">
                                        <table width="100%" border="0" align="right" cellspacing="0">
                                            <tr align="right">
                                                <td>
                                                    <asp:RadioButtonList runat="server" ID="rdlLanguagePreference" AutoPostBack="True"
                                                        RepeatDirection="Horizontal" OnSelectedIndexChanged="rdlLanguagePreference_SelectedIndexChanged"
                                                        meta:resourcekey="rdlLanguagePreferenceResource1">
                                                        <asp:ListItem Text="English" Value="en-IN" Selected="True" meta:resourcekey="ListItemResource1">
                                                        </asp:ListItem>
                                                        <asp:ListItem Text="中国的" Value="zh-CN" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr align="right">
                                                <td align="right">
                                                    <asp:HyperLink ID="hyp_log" runat="server" BorderStyle="None" EnableTheming="False"
                                                        EnableViewState="False" Font-Bold="True" meta:resourcekey="hyp_logResource1">
                                                           <img src="Images/sign_in_btn.png" width="64" height="23" border="0" alt="SignIn" /></asp:HyperLink>
                                                    <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="False">
                                                        <AnonymousTemplate>
                                                            <a id="HeadLoginStatus0" runat="server" href="~/Site.Master"></a>
                                                        </AnonymousTemplate>
                                                        <LoggedInTemplate>
                                                            Welcome <span class="bold">
                                                                <asp:LoginName ID="HeadLoginName" runat="server" meta:resourcekey="HeadLoginNameResource1"
                                                                    ForeColor="#3333FF" />
                                                            </span>, [
                                                            <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/"
                                                                LogoutText="Log Out" meta:resourcekey="HeadLoginStatusResource1" />
                                                            ]
                                                        </LoggedInTemplate>
                                                    </asp:LoginView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="background-repeat: repeat-y; background-image: url(images/right_side_bg.jpg)"
                    width="13" align="right" valign="top">
                </td>
            </tr>
            <%--tr for navigation bar--%>
            <tr>
                <td style="background-repeat: repeat-y; background-image: url(images/left_side_bg.jpg)"
                    width="13" align="left" valign="top" bgcolor="#FFFFFF">
                </td>
                <td width="996" align="left" valign="top" bgcolor="#FFFFFF">
                    <!--main body start-->
                    <div style="padding: 10px 10px 10px 10px">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="6">
                                    <img src="images/menubg_left.png" width="6" height="36">
                                </td>
                                <td>
                                    <div id="navcontainer">
                                        <ul id="menu">
                                            <li><a href="Default.aspx">Home</a></li>
                                            <li><a href="About.aspx">About Us</a></li>
                                            <li><a href="#">Why Us</a></li>
                                            <li><a href="#">Services</a></li>
                                            <li><a href="#">Solutions</a></li>
                                            <li><a href="#">FAQ</a></li>
                                            <li><a href="#">Contacts</a></li>
                                            <li id="profile" runat="server" visible="false"><a href="#" id="myprofile" runat="server">
                                                My Profile</a></li>
                                            <%--<asp:LinkButton Visible="false" runat="server" ID="profile1" ForeColor="White">My Profile</asp:LinkButton>--%>
                                        </ul>
                                    </div>
                                </td>
                                <td width="6" align="right">
                                    <img src="images/menubg_right.png" width="6" height="36" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="background-repeat: repeat-y; background-image: url(images/right_side_bg.jpg)"
                    width="13" align="right" valign="top" bgcolor="#FFFFFF">
                </td>
            </tr>
            <%--tr for top add and online search--%>
            <tr>
                <td style="background-repeat: repeat-y; background-image: url(images/left_side_bg.jpg)"
                    width="13" align="left" valign="top" bgcolor="#FFFFFF">
                </td>
                <td width="996" align="left" valign="top" bgcolor="#FFFFFF">
                    <!--main body start-->
                    <div style="padding: 0px 10px 10px 10px">
                        <div style="float: left; width: 70%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left" valign="top">
                                        <%-- Place for top adervtisement content-panel --%>
                                        <uc1:TopPanel ID="TopPanel1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%--Online search --%>
                        <div style="float: left; width: 30%">
                            <div id="online_search" style="padding-left: 5px">
                                <table>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtSearchString" runat="server" meta:resourcekey="txtSearchStringResource1"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                                CausesValidation="False" meta:resourcekey="btnSearchResource1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:RadioButtonList ID="rblSearchType" runat="server" RepeatDirection="Horizontal"
                                                meta:resourcekey="rblSearchTypeResource1">
                                                <asp:ListItem Text="Offerings" Value="0" Selected="True" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                                <asp:ListItem Text="Requirement" Value="1" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </td>
                <td style="background-repeat: repeat-y; background-image: url(images/right_side_bg.jpg)"
                    width="13" align="right" valign="top" bgcolor="#FFFFFF">
                </td>
            </tr>
            <%--tr for grids and right add--%>
            <tr>
                <td style="background-repeat: repeat-y; background-image: url(images/left_side_bg.jpg)"
                    width="13" align="left" valign="top" bgcolor="#FFFFFF">
                </td>
                <td width="996" align="left" valign="top" bgcolor="#FFFFFF">
                    <!--main body start-->
                    <div style="padding: 10px 10px 10px 10px">
                        <div style="float: left; width: 100%">
                            <div id="content">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="left">
                                            <div style="height: 540px; width: 680px;">
                                                <% %>
                                                <table cellpadding="0" cellspacing="0" border="0" id="ch_tableBuyerProfile" width="100%">
                                                    <tr class="headerback">
                                                        <th align="center" class="style2" colspan="2">
                                                            <asp:Label ID="Label8" Text="Verify your details and click on 'Pay'" runat="server"
                                                                Font-Bold="True" meta:resourcekey="Label8Resource1"></asp:Label>
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="style1">
                                                            <asp:Label ID="Label4" runat="server" Text="Seller Name" meta:resourcekey="Label4Resource1"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblSellerName" runat="server" meta:resourcekey="lblSellerNameResource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label5" runat="server" Text="Subscription" meta:resourcekey="Label5Resource1"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblSubscription" runat="server" meta:resourcekey="lblSubscriptionResource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="center">
                                                            <input type="submit" name="submit" value="Pay" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <% %>
                                                <input id="requestparameter" type="hidden" name="requestparameter" runat="server" />
                                                <%--<input type="submit" name="submit" value="Pay"  />--%>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%-- Place for right adervtisement content-panel --%>
                            <div id="right_advt">
                                <uc1:RightPanel ID="RightPanel" runat="server" />
                            </div>
                        </div>
                        <%-- Place for bottom adervtisement content-panel --%>
                        <div style="float: left">
                            <table width="100%" border="0" cellpadding="0" cellspacing="5">
                                <tr>
                                    <td>
                                        <uc1:BottomPanel ID="BottomPanel" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
                <td style="background-repeat: repeat-y; background-image: url(images/right_side_bg.jpg)"
                    width="13" align="center" valign="top" bgcolor="#FFFFFF">
                </td>
            </tr>
            <%--bottom tr for bottom_bg image--%>
            <tr>
                <td colspan="3" valign="bottom">
                    <img src="images/bottom_bg.jpg" width="1022" height="18" />
                </td>
            </tr>
        </table>
        <%--main table ends--%>
    </div>
    <div id="footer" style="padding: 0px 0px 10px 10px">
        <a href="#" class="footer">Terms &amp; Conditionsdding: 0px 0px 10px 10px"> <a href="#"
            class="footer">Terms &amp; Conditions</a> | <a href="#" class="footer">Privacy Policy</a>
            | <a href="#" class="footer">FAQ</a> | <a href="#" class="footer">Site Map</a> |
            <a href="#" class="footer">Contact Us</a> | <a href="#" class="footer">Advertise With
                Us</a><br />
            All Rights Reserved © The ICBrowser 2000 - 2012<br />
    </div>
    </form>
</body>
</html>
