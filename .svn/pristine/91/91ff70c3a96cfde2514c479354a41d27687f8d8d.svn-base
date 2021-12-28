<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeBehind="AdminRating.aspx.cs" Inherits="ICBrowser.Web.AdminRating"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .grid
        {
            float: none;
            margin: 0;
            display: block;
            color: #3e3e3e;
            text-align: left;
        }
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
        
        .greenmsg
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
        .even
        {
            background: #dfedf7;
        }
        .odd
        {
            background: #fff;
        }
        .redmsg
        {
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
        .smallinput_t200
        {
            border: 1px solid #0096d6;
            font-family: Tahoma;
            font-size: 11px;
            color: #434647;
            height: 26px;
            background-image: url(../Images/textfieldbg.gif);
            background-repeat: repeat-x;
            background-position: left top;
            padding: 2px;
            padding: 2px;
        }
    </style>
    <script type="text/javascript">
        function confirmDelete(source, args) {
            if (confirm('Are you sure you want to delete ?')) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
            return;
        }

    </script>
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<link href="Styles/Site.css" rel="stylesheet" type="text/css" />--%>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td valign="top" align="center">
                <div class="formBackgorund">
                    <table width="100%" cellpadding="5" cellspacing="0" align="center">
                        <tr>
                            <td colspan="3" align="left">
                                <%--<asp:Label ID="lblSucess" runat="server" Visible="false" CssClass="greenmsg"></asp:Label>--%>
                                <asp:Label ID="lblErrorMessage" runat="server" Visible="False" CssClass="redmsg"
                                    meta:resourcekey="lblErrorMessageResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr class="headerback">
                            <td colspan="3" align="left">
                                <asp:Label ID="lblHeading" CssClass="header" runat="server" Text="Add Rating Questions"
                                    meta:resourcekey="lblHeadingResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" width="20%" align="right">
                                <asp:Label ID="lblQuestion" runat="server" Text="Question:" meta:resourcekey="lblQuestionResource1"></asp:Label>
                            </td>
                            <td width="80%" align="left" colspan="2">
                                <asp:TextBox ID="txtQuestion" runat="server" Width="200px" TextMode="MultiLine" Height="40px" Font-Names="Calibri" Font-Size="11"
                                    meta:resourcekey="txtQuestionResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtQuestion" runat="server" ErrorMessage="Enter Questions"
                                    ValidationGroup="ValidateToSave" ControlToValidate="txtQuestion" ForeColor="Red"
                                    Display="Dynamic" meta:resourcekey="rfvtxtQuestionResource1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="right">
                                <asp:Label ID="lblTypeOfMember" runat="server" Text="Select Type:" meta:resourcekey="lblTypeOfMemberResource1"></asp:Label>
                            </td>
                            <td width="80%" align="left" colspan="2">
                                <asp:DropDownList ID="ddlTypeofMember" runat="server" CssClass="smallinput_t200"
                                    Width="205px" meta:resourcekey="ddlTypeofMemberResource1">
                                    <asp:ListItem Text="---Select---" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Buyer" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Seller" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlTypeofMember" runat="server" ErrorMessage="Please select type"
                                    ForeColor="Red" ControlToValidate="ddlTypeofMember" InitialValue="-1" ValidationGroup="ValidateToSave"
                                    meta:resourcekey="rfvddlTypeofMemberResource1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="right">
                            </td>
                            <td width="5%" align="left">
                                <asp:Button ID="btnSave" runat="server" Text="Save" Width="60px" CssClass="blue_button_fu"
                                    OnClick="btnSave_Click" ValidationGroup="ValidateToSave" meta:resourcekey="btnSaveResource1" />
                            </td>
                            <td width="75%" align="left">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="blue_button_fu"
                                    Width="60px" CausesValidation="False" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="8">
                                <asp:LinkButton ID="lnkViewratings" runat="server" Text="View Ratings" CausesValidation="False"
                                    PostBackUrl="~/ViewRatings.aspx" meta:resourcekey="lnkViewratingsResource1"></asp:LinkButton>
                            </td>
                        </tr>
                        <%-- <tr>
                        <td width="20%">
                        </td>
                        <td>
                            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>--%>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px">
                <table width="100%" cellpadding="3" cellspacing="0" style="border: 1px solid #00CCFF;
                    border-collapse: separate;" align="center">
                    <tr class="headerback">
                        <td>
                            <asp:Label ID="lblgrdHeading" runat="server" Text="Rating Questions" CssClass="header"
                                meta:resourcekey="lblgrdHeadingResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="grid">
                                <asp:GridView ID="grdQuestion" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                    Width="100%" GridLines="Horizontal" ClientIDMode="Static" HeaderStyle-HorizontalAlign="Left"
                                    DataKeyNames="QuestionId" OnRowDataBound="grdQuestion_RowDataBound" OnRowCommand="grdQuestion_RowCommand"
                                    OnRowDeleted="grdQuestion_RowDeleted" OnRowDeleting="grdQuestion_RowDeleting"
                                    OnRowEditing="grdQuestion_RowEditing" OnRowUpdated="grdQuestion_RowUpdated" OnRowUpdating="grdQuestion_RowUpdating"
                                    OnRowCancelingEdit="grdQuestion_RowCancelingEdit" CssClass="table-border" meta:resourcekey="grdQuestionResource1">
                                    <RowStyle CssClass="odd"></RowStyle>
                                    <HeaderStyle BackColor="#B3D1EB" />
                                    <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False" Visible="False" meta:resourcekey="TemplateFieldResource1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuestionId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QuestionId") %>'
                                                    Visible="False" meta:resourcekey="lblQuestionIdResource1"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Questions" meta:resourcekey="TemplateFieldResource2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuestion1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Question") %>'
                                                    meta:resourcekey="lblQuestion1Resource1"></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtgrdquestion" runat="server" CssClass="smallinput_t" Text='<%# Eval("Question") %>'
                                                    meta:resourcekey="txtgrdquestionResource1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvquestion" runat="server" ErrorMessage="*Please enter the Question."
                                                    ForeColor="Red" ValidationGroup="gridvalidation" ControlToValidate="txtgrdquestion"
                                                    meta:resourcekey="rfvquestionResource1"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemStyle Width="25%" />
                                            <ControlStyle Width="99%"></ControlStyle>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type Of Member" meta:resourcekey="TemplateFieldResource3">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltype" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TypeOfUser") %>'
                                                    meta:resourcekey="lbltypeResource1"></asp:Label>
                                            </ItemTemplate>
                                            <%--  <EditItemTemplate>
                                                <asp:DropDownList ID="ddlTypeOfUser" runat="server" CssClass="smallinput_t200">
                                                    <asp:ListItem Text="---Select---" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="Buyer" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Seller" Value="1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>--%>
                                            <ItemStyle Width="7%" />
                                            <ControlStyle Width="99%"></ControlStyle>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Right" meta:resourcekey="TemplateFieldResource4">
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="imgbtnEdit" ToolTip="Edit" ImageUrl="~/Images/edit_btn.png"
                                                    CausesValidation="False" CommandName="Edit" meta:resourcekey="imgbtnEditResource1" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:ImageButton runat="server" ID="imgbtnEdit" ToolTip="Update" ImageUrl="~/Images/save_btn.png"
                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "QuestionId") %>' ValidationGroup="gridvalidation"
                                                    CommandName="Update" meta:resourcekey="imgbtnEditResource2" />
                                            </EditItemTemplate>
                                            <ItemStyle Width="4%" />
                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField meta:resourcekey="TemplateFieldResource5" ItemStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="imgbtnDelete" ImageUrl="~/Images/deletet_btn.png"
                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "QuestionId") %>' CommandName="Delete"
                                                    ToolTip="Delete" ValidationGroup="deleteConfirmation" meta:resourcekey="imgbtnDeleteResource1" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:ImageButton runat="server" ID="imgbtnCancel" ImageUrl="~/Images/cancel_btn.png"
                                                    CausesValidation="False" CommandName="Cancel" ToolTip="Cancel" meta:resourcekey="imgbtnCancelResource1" />
                                            </EditItemTemplate>
                                            <ItemStyle Width="4%" />
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle Wrap="True" Width="100%"></EditRowStyle>
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
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <PagerStyle CssClass="headerback" HorizontalAlign="Center" />
                                    <RowStyle CssClass="odd" />
                                </asp:GridView>
                                <asp:CustomValidator ID="CustomValidator1" ClientValidationFunction="confirmDelete"
                                    ValidationGroup="deleteConfirmation" runat="server" meta:resourcekey="CustomValidator1Resource1"></asp:CustomValidator>
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                            <asp:LinkButton ID="lnkViewratings" runat="server" Text="View Ratings" CausesValidation="false"
                                PostBackUrl="~/ViewRatings.aspx"></asp:LinkButton>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
