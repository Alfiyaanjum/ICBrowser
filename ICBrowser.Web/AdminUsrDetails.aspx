<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master"
    AutoEventWireup="true" CodeBehind="AdminUsrDetails.aspx.cs" Inherits="ICBrowser.Web.AdminUsrDetails"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/AdminMaster.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="lblSucess" runat="server" Visible="False" CssClass="greenmsg" meta:resourcekey="lblSucessResource1"></asp:Label>
                <asp:Label ID="lblError" runat="server" Visible="False" CssClass="redmsg" meta:resourcekey="lblErrorResource1"></asp:Label>
            </td>
        </tr>
        <tr class="headerback">
            <td>
                <asp:Label ID="lblPaidUsr" runat="server" Text="Paid and Trial User Details" CssClass="header"
                    meta:resourcekey="lblPaidUsrResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFilter" DefaultButton="imgSearchFromGrid" BackColor="#B3D1EB" runat="server"
                    meta:resourcekey="pnlFilterResource1">
                    <table width="100%" cellspacing="0" cellpadding="0" style="height: 35px">
                        <tr>
                            <td valign="middle" align="right" width="25%" style="padding-right: 8px">
                                <asp:Label ID="lblFilter" runat="server" Text="Filter With:" CssClass="lblInfo" meta:resourcekey="lblFilterResource1"></asp:Label>
                            </td>
                            <td align="right" width="10%" valign="middle">
                                <asp:DropDownList ID="ddlUsrGridColumns" runat="server" Width="130px" CssClass="smallinput_t200"
                                    meta:resourcekey="ddlUsrGridColumnsResource1">
                                    <asp:ListItem Text="--Select--" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                    <asp:ListItem Text="User Name" Value="1" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                    <asp:ListItem Text="Company Name" Value="2" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                    <asp:ListItem Text="Contact Name" Value="3" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                    <%--    <asp:ListItem Text="Owner Name" Value="4" meta:resourcekey="ListItemResource5"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                            <td width="7%" valign="middle" align="center" style="padding-right: 8px">
                                <asp:Label ID="lblSearch" runat="server" Text="Search:" CssClass="lblInfo" meta:resourcekey="lblSearchResource1"></asp:Label>
                            </td>
                            <td align="left" width="10%" valign="middle">
                                <asp:TextBox ID="txtSearchFromGrid" runat="server" CssClass="smallinput_t" Width="126px"
                                    ValidationGroup="b" meta:resourcekey="txtSearchFromGridResource1"></asp:TextBox>
                            </td>
                            <td width="6%" align="center" valign="middle">
                                <asp:ImageButton ID="imgSearchFromGrid" runat="server" ImageUrl="~/Images/search_button.png"
                                    ToolTip="Search" ValidationGroup="paid" OnClick="imgSearchFromGrid_Click" meta:resourcekey="imgSearchFromGridResource1" />
                            </td>
                            <td width="5%" align="left" valign="middle">
                                <asp:ImageButton ID="imgClearSearchSelection" runat="server" ImageUrl="~/Images/clear_btn.png"
                                    CausesValidation="False" ToolTip="Clear Search" OnClick="imgClearSearchSelection_Click"
                                    meta:resourcekey="imgClearSearchSelectionResource1" />
                            </td>
                            <td width="30%">
                                <asp:RequiredFieldValidator ID="rfvpaid" runat="server" ErrorMessage="Please select option."
                                    ControlToValidate="ddlUsrGridColumns" ValidationGroup="paid" InitialValue="0"
                                    SetFocusOnError="True" ForeColor="Red" meta:resourcekey="rfvpaidResource1"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Insert value For Search."
                                    ForeColor="Red" ControlToValidate="txtSearchFromGrid" ValidationGroup="paid"
                                    meta:resourcekey="RequiredFieldValidator1Resource1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid">
                    <asp:GridView ID="gvPaidUsrDetails" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvPaidUsrDetails_RowCancelingEdit"
                        OnRowUpdating="gvPaidUsrDetails_RowUpdating" OnRowEditing="gvPaidUsrDetails_RowEditing"
                        OnRowDataBound="gvPaidUsrDetails_RowDataBound" AlternatingRowStyle-CssClass="even"
                        RowStyle-CssClass="odd" Width="100%" AllowPaging="True" OnPageIndexChanging="gvPaidUsrDetails_PageIndexChanging"
                        CssClass="table-border" meta:resourcekey="gvPaidUsrDetailsResource1" OnRowCommand="gvPaidUsrDetails_RowCommand">
                        <RowStyle CssClass="odd"></RowStyle>
                        <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="UserID" SortExpression="UserID" Visible="false" meta:resourcekey="TemplateFieldResource1">
                                <ItemTemplate>
                                    <asp:Label ID="lblUsrId" runat="server" Text='<%# Eval("UserID") %>' meta:resourcekey="lblUsrIdResource1"></asp:Label>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EmailId") %>' meta:resourcekey="lblEmailResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Name" SortExpression="UserName" ItemStyle-Width="8%"
                                HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource2">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkUsrName" runat="server" NavigateUrl='<%# Eval("UserID", "ViewSellersProfile.aspx?UserID={0}") %>'
                                        Text='<%# Eval("UserName") %>' meta:resourcekey="lnkUsrNameResource1" Target="_blank" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company Name" SortExpression="CompanyName" ItemStyle-Width="8%"
                                HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource3">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkCompName" runat="server" NavigateUrl='<%# Eval("UserID", "NewUserProfile.aspx?UserID={0}") %>'
                                        Text='<%# Eval("CompanyName") %>' Target="_blank" meta:resourcekey="lnkCompNameResource1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country" SortExpression="Country" ItemStyle-Width="10%"
                                HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrimaryCountry" runat="server" Text='<%# Eval("PrimaryCountry") %>'
                                        meta:resourcekey="lblPrimaryCountryResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Name" SortExpression="ContactName" ItemStyle-Width="10%"
                                HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource4">
                                <ItemTemplate>
                                    <asp:Label ID="lblContactName" runat="server" Text='<%# Eval("ContactName") %>' meta:resourcekey="lblContactNameResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Expiry Date" SortExpression="ExpiryDate" ItemStyle-Width="8%"
                                HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource5">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("MembershipExpiryDate") %>' meta:resourcekey="Label3Resource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreateDate" ReadOnly="true" DataFormatString="{0:dd-MMM-yyyy}"
                                ItemStyle-Width="8%" HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left"
                                HeaderText="Create Date" meta:resourcekey="BoundFieldResource1" />
                            <asp:BoundField DataField="ModifiedDate" ReadOnly="true" DataFormatString="{0:dd-MMM-yyyy}"
                                ItemStyle-Width="8%" HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left"
                                HeaderText="Modified Date" meta:resourcekey="BoundFieldResource2" />
                            <asp:TemplateField HeaderText="Inventories" SortExpression="Inventories" ItemStyle-Width="8%"
                                HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource6">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkInventories" runat="server" Text="Inventories" NavigateUrl='<%# Eval("UserID", "SellerUploadedInventory.aspx?UserID={0}") %>'
                                        meta:resourcekey="lnkInventoriesResource1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Offerings" SortExpression="Offerings" ItemStyle-Width="8%"
                                HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource7">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkOffers" runat="server" Text="Offerings" NavigateUrl='<%# Eval("UserID", "UserOffers.aspx?UserID={0}") %>'
                                        meta:resourcekey="lnkOffersResource1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Requirements" SortExpression="Requirements" ItemStyle-Width="8%"
                                HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource8">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnlRequiremtnts" runat="server" Text="Requirements" NavigateUrl='<%# Eval("UserID", "BuyersRequirment.aspx?UserID={0}") %>'
                                        meta:resourcekey="lnlRequiremtntsResource1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Type" SortExpression="TypeOfMembership" ItemStyle-Width="8%"
                                HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource9">
                                <ItemTemplate>
                                    <asp:Label ID="lblMemType" runat="server" Text='<%# Eval("TypeOfMembership") %>'
                                        meta:resourcekey="lblMemTypeResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reason To Block/Unblock" meta:resourcekey="TemplateFieldResource10"
                                ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnReasnPaid" runat="server" OnClick="btnReasnPaid_Click" Visible="true">Reason</asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="tb" runat="server" CssClass="smallinput_t" TextMode="MultiLine"
                                        meta:resourcekey="tbResource1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTxtBlock" runat="server" Text="*" ForeColor="Red"
                                        ControlToValidate="tb" meta:resourcekey="rfvTxtBlockResource1"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" meta:resourcekey="TemplateFieldResource11">
                                <ItemTemplate>
                                    <asp:Button ID="btnStat" runat="server" CausesValidation="False" Text='<%# Eval("PaymentStatus") %>'
                                        meta:resourcekey="btnStatResource1" /></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" meta:resourcekey="TemplateFieldResource11">
                                <ItemTemplate>
                                    <asp:Button ID="btnExclude" runat="server" CausesValidation="False" Text='<%# Eval("IsExcluded") %>'
                                        meta:resourcekey="btnExcludeResource1" /></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Block Account" ItemStyle-Width="6%" HeaderStyle-Width="6%"
                                HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource12">
                                <EditItemTemplate>
                                    <asp:Button ID="btnSendMail" runat="server" CssClass="blue_button_fu" CommandName="Update"
                                        Text="Confirm" meta:resourcekey="btnSendMailResource1" />
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="blue_button_fu"
                                        CommandName="Cancel" Text="Cancel" meta:resourcekey="btnCancelResource1" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="btnedit" runat="server" CausesValidation="False" CssClass="blue_button_fu"
                                        CommandName="Edit" Text="Block" meta:resourcekey="btneditResource1" />
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
            <td>
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblscs" runat="server" Visible="False" CssClass="greenmsg" meta:resourcekey="lblscsResource1"></asp:Label>
                <asp:Label ID="lblerr" runat="server" Visible="False" CssClass="redmsg" meta:resourcekey="lblerrResource1"></asp:Label>
            </td>
        </tr>
        <tr class="headerback">
            <td>
                <asp:Label ID="lblFreeUserDetails" runat="server" Text="Free User Details" CssClass="header"
                    meta:resourcekey="lblFreeUserDetailsResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFreeUserDetail" DefaultButton="imgbtn" runat="server" BackColor="#B3D1EB"
                    meta:resourcekey="pnlFreeUserDetailResource1">
                    <table width="100%" cellspacing="0" cellpadding="0" style="height: 35px">
                        <tr>
                            <td width="25%" style="padding-right: 8px" align="right">
                                <asp:Label ID="lblFltr" runat="server" Text="Filter With: " CssClass="lblInfo" meta:resourcekey="lblFltrResource1"></asp:Label>
                            </td>
                            <td align="right" width="10%" valign="middle">
                                <asp:DropDownList ID="ddlFreeUsr" runat="server" Width="130px" CssClass="smallinput_t200"
                                    ValidationGroup="free" meta:resourcekey="ddlFreeUsrResource1">
                                    <asp:ListItem Text="--Select--" Value="0" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                    <asp:ListItem Text="User Name" Value="1" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                    <asp:ListItem Text="Company Name" Value="2" meta:resourcekey="ListItemResource8"></asp:ListItem>
                                    <asp:ListItem Text="Contact Name" Value="3" meta:resourcekey="ListItemResource9"></asp:ListItem>
                                    <%--<asp:ListItem Text="Owner Name" Value="4" meta:resourcekey="ListItemResource10"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                            <td width="7%" valign="middle" align="center" style="padding-right: 8px">
                                <asp:Label ID="lblSrctext" runat="server" Text="Search:" CssClass="lblInfo" meta:resourcekey="lblSrctextResource1"></asp:Label>
                            </td>
                            <td align="left" width="10%" valign="middle">
                                <asp:TextBox ID="txtSrchd" runat="server" CssClass="smallinput_t" Width="126px" ValidationGroup="a"
                                    meta:resourcekey="txtSrchdResource1"></asp:TextBox>
                            </td>
                            <td width="6%" align="center" valign="middle">
                                <asp:ImageButton ID="imgbtn" runat="server" ImageUrl="~/Images/search_button.png"
                                    ToolTip="Search" ValidationGroup="free" OnClick="imgbtn_Click" meta:resourcekey="imgbtnResource1" />
                            </td>
                            <td width="5%" align="left" valign="middle">
                                <asp:ImageButton ID="imgClr" runat="server" ImageUrl="~/Images/clear_btn.png" CausesValidation="False"
                                    ToolTip="Clear Search" OnClick="imgClr_Click" meta:resourcekey="imgClrResource1" />
                            </td>
                            <td width="30%">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSrchd"
                                    ErrorMessage="Please Insert value For Search." ForeColor="Red" ValidationGroup="free"
                                    meta:resourcekey="RequiredFieldValidator2Resource1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid">
                    <asp:GridView ID="gvFreeUsrDetails" runat="server" AutoGenerateColumns="False" OnRowUpdating="gvFreeUsrDetails_RowUpdating"
                        OnRowCancelingEdit="gvFreeUsrDetails_RowCancelingEdit" OnRowEditing="gvFreeUsrDetails_RowEditing"
                        OnRowDataBound="gvFreeUsrDetails_RowDataBound" AlternatingRowStyle-CssClass="even"
                        AllowPaging="True" RowStyle-CssClass="odd" Width="100%" OnPageIndexChanging="gvFreeUsrDetails_PageIndexChanging"
                        meta:resourcekey="gvFreeUsrDetailsResource1" OnRowCommand="gvFreeUsrDetails_RowCommand">
                        <RowStyle CssClass="odd"></RowStyle>
                        <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="UserID" SortExpression="UserID" Visible="false" meta:resourcekey="TemplateFieldResource13">
                                <ItemTemplate>
                                    <asp:Label ID="lblUId" runat="server" Text='<%# Eval("UserID") %>' meta:resourcekey="lblUIdResource1"></asp:Label>
                                    <asp:Label ID="lblEmailId" runat="server" Text='<%# Eval("email") %>' meta:resourcekey="lblEmailIdResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Name" SortExpression="UserName" ItemStyle-Width="8%"
                                HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource14">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkUName" runat="server" NavigateUrl='<%# Eval("UserID", "ViewSellersProfile.aspx?UserID={0}") %>'
                                        Text='<%# Eval("UserName") %>' Target="_blank" meta:resourcekey="lnkUNameResource1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company Name" SortExpression="CompanyName" ItemStyle-Width="8%"
                                HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource15">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkCompanyName" runat="server" NavigateUrl='<%# Eval("UserID", "NewUserProfile.aspx?UserID={0}") %>'
                                        Text='<%# Eval("CompanyName") %>' Target="_blank" meta:resourcekey="lnkCompanyNameResource1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country" SortExpression="Country" ItemStyle-Width="10%"
                                HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrimaryCountry" runat="server" Text='<%# Eval("PrimaryCountry") %>'
                                        meta:resourcekey="lblPrimaryCountryResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Name" SortExpression="ContactName" ItemStyle-Width="12%"
                                HeaderStyle-Width="12%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource16">
                                <ItemTemplate>
                                    <asp:Label ID="lblCntName" runat="server" Text='<%# Eval("ContactName") %>' meta:resourcekey="lblCntNameResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owner Name" SortExpression="OwnerName" ItemStyle-Width="8%"
                                HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource17">
                                <ItemTemplate>
                                    <asp:Label ID="lblOwnrName" runat="server" Text='<%# Eval("OwnerName") %>' meta:resourcekey="lblOwnrNameResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreateDate" ReadOnly="true" DataFormatString="{0:dd-MMM-yyyy}"
                                HeaderText="CreateDate" meta:resourcekey="BoundFieldResource3" ItemStyle-Width="8%"
                                HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="ModifiedDate" ReadOnly="true" DataFormatString="{0:dd-MMM-yyyy}"
                                HeaderText="ModifiedDate" ItemStyle-Width="8%" HeaderStyle-Width="8%" HeaderStyle-HorizontalAlign="Left"
                                meta:resourcekey="BoundFieldResource4" />
                            <asp:TemplateField HeaderText="Requirements" SortExpression="Requirements" ItemStyle-Width="15%"
                                HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                meta:resourcekey="TemplateFieldResource18">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkInven" runat="server" Text="Requirements" NavigateUrl='<%# Eval("UserID", "BuyersRequirment.aspx?UserID={0}") %>'
                                        meta:resourcekey="lnkInvenResource1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reason To Block/Unblock" ItemStyle-Width="15%" HeaderStyle-Width="15%"
                                HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource19">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnReasnFree" runat="server" OnClick="btnReasnFree_Click" Visible="true">Reason</asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtBlock" runat="server" TextMode="MultiLine" meta:resourcekey="txtBlockResource1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTxtBox" runat="server" Text="*" ForeColor="Red"
                                        ControlToValidate="txtBlock" meta:resourcekey="rfvTxtBoxResource1"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" meta:resourcekey="TemplateFieldResource20">
                                <ItemTemplate>
                                    <asp:Button ID="btnStatus" runat="server" CausesValidation="False" Text='<%# Eval("PaymentStatus") %>'
                                        meta:resourcekey="btnStatusResource1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" meta:resourcekey="TemplateFieldResource11">
                                <ItemTemplate>
                                    <asp:Button ID="btnExclude" runat="server" CausesValidation="False" Text='<%# Eval("IsExcluded") %>'
                                        meta:resourcekey="btnExcludeResource1" /></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Block Account" ItemStyle-Width="6%" HeaderStyle-Width="6%"
                                HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource21">
                                <EditItemTemplate>
                                    <asp:Button ID="btnSendEMail" runat="server" CssClass="blue_button_fu" CausesValidation="False"
                                        CommandName="Update" Text="Confirm" meta:resourcekey="btnSendEMailResource1" />
                                    <asp:Button ID="btnCncel" runat="server" CssClass="blue_button_fu" CausesValidation="False"
                                        CommandName="Cancel" Text="Cancel" meta:resourcekey="btnCncelResource1" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="btnedt" runat="server" CssClass="blue_button_fu" CausesValidation="False"
                                        CommandName="Edit" Text="Block" meta:resourcekey="btnedtResource1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle Width="100%" Wrap="True" />
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
                        <%--    <RowStyle HorizontalAlign="Left" />--%>
                        <PagerStyle CssClass="headerback" HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    <%--Modal pop-up for ReasonToBlock --%>
    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
    <asp:ModalPopupExtender ID="ModalPopupExtenderBlockUnblock" runat="server" BackgroundCssClass="modalBackground"
        PopupControlID="Panel2" DynamicServicePath="" TargetControlID="LinkButton1" Enabled="True">
    </asp:ModalPopupExtender>
    <asp:Panel ID="Panel2" runat="server" meta:resourcekey="Panel2Resource1">
        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
            <ContentTemplate>
                <div style="height: 70%; width: 510px;" class="popupbox">
                    <table style="height: 100%;" width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="popupbox-lefttop-corner">
                            </td>
                            <td class="popupbox-topbg">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="97%" align="left" class="popupbox-header">
                                            <asp:Label ID="lblReasontoBlockheading" runat="server" Text="Reason To Block/Unblock"
                                                meta:resourcekey="lblReasontoBlockheadingResource1"></asp:Label>
                                        </td>
                                        <td width="3%" align="right" valign="middle" class="popupbox-header">
                                            <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Images/cross.png" OnClick="imgCancel_Click"
                                                ToolTip="Close" meta:resourcekey="imgCancelResource1" />
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
                            <td align="left" valign="top" class="popupbox-content">
                                <%--<table border="0" cellpadding="5" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="right" style="width: 30%;">
                                            <asp:Label ID="lblReasontoblock" runat="server" Text="Reason To Block" CssClass="black"
                                                Font-Bold="true" meta:resourcekey="lblReasontoblockResource1"></asp:Label>
                                            <span class="black">:</span>
                                        </td>
                                        <td style="width: 70%;" colspan="2">
                                            <asp:Label ID="lblReasntoblockValue" runat="server" meta:resourcekey="lblReasntoblockValueResource1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 35%;" valign="top">
                                            <asp:Label ID="lblResntoUnblck" runat="server" Text="Reason To Unblock" CssClass="black"
                                                Font-Bold="true" meta:resourcekey="lblReasntoUnblckResource1"></asp:Label>
                                            <span class="black">:</span>
                                        </td>
                                        <td style="width: 65%;" colspan="2">
                                            <asp:Label ID="lblReasontoUnblckValue" runat="server" meta:resourcekey="lblReasontoUnblckValueResource1" />
                                        </td>
                                    </tr>
                                    <td colspan="3">
                                    </td>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Button ID="btnPreviewClose" runat="server" Text="Close" Width="60px" CausesValidation="False"
                                                CssClass="blue_button" OnClick="btnPreviewClose_Click" meta:resourcekey="btnPreviewCloseResource1" />
                                        </td>
                                    </tr>
                                </table>--%>
                                <div style='width: 100%; min-height: 150px; position: relative;'>
                                    <table>
                                        <tr>
                                            <td align="right" style="width: 30%;">
                                                <asp:Label ID="lblReasontoblock" runat="server" Text="Reason To Block" CssClass="black"
                                                    Font-Bold="true" meta:resourcekey="lblReasontoblockResource1"></asp:Label>
                                                <span class="black">:</span>
                                            </td>
                                            <td style="width: 70%;" colspan="2">
                                                <asp:Label ID="lblReasntoblockValue" runat="server" meta:resourcekey="lblReasntoblockValueResource1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 35%;" valign="top">
                                                <asp:Label ID="lblResntoUnblck" runat="server" Text="Reason To Unblock" CssClass="black"
                                                    Font-Bold="true" meta:resourcekey="lblReasntoUnblckResource1"></asp:Label>
                                                <span class="black">:</span>
                                            </td>
                                            <td style="width: 65%;" colspan="2">
                                                <asp:Label ID="lblReasontoUnblckValue" runat="server" meta:resourcekey="lblReasontoUnblckValueResource1" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div style='position: absolute; left: 0; width: 100%; bottom: 0;'>
                                        <div style='width: 60px; height: 30px; margin: 0 auto; text-align: center'>
                                            <asp:Button ID="btnPreviewClose" runat="server" Text="Close" Width="60px" CausesValidation="False"
                                                CssClass="blue_button" OnClick="btnPreviewClose_Click" meta:resourcekey="btnPreviewCloseResource1" />
                                        </div>
                                    </div>
                                </div>
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
                <asp:PostBackTrigger ControlID="imgCancel" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
