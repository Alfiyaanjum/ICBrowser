<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master"
    AutoEventWireup="true" EnableViewState="true" CodeBehind="BuyersRequirment.aspx.cs"
    Inherits="ICBrowser.Web.BuyReq" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%--<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Assembly="eWorld.UI.Compatibility" Namespace="eWorld.UI.Compatibility"
    TagPrefix="cc2" %>--%>
<%--<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style16
        {
            width: 19%;
        }
        .style17
        {
            width: 7%;
        }
        .style18
        {
            width: 5%;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function confirmDelete(source, args) {
            if (confirm('Are you sure you want to delete ?')) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
            return;
        }
        $(function () {
            $("#MainContent_datepicker").datepicker({ minDate: new Date(), dateFormat: 'dd-M-yy', showTime: true, time24h: false });
        });

        function checkAllBoxes() {
            //alert('hi');
            //get total number of rows in the gridview and do whatever
            //you want with it..just grabbing it just cause
            var totalChkBoxes = parseInt('<%= gdvBuyersReqDetails.Rows.Count %>');
            //alert(totalChkBoxes);
            var gvControl = document.getElementById('<%= gdvBuyersReqDetails.ClientID %>');

            //this is the checkbox in the item template...this has to be the same name as the ID of it
            var gvChkBoxControl = "chkbx";

            //this is the checkbox in the header template
            var mainChkBox = document.getElementById("chkBoxAll");

            //get an array of input types in the gridview
            var inputTypes = gvControl.getElementsByTagName("input");

            for (var i = 0; i < inputTypes.length; i++) {
                //if the input type is a checkbox and the id of it is what we set above
                //then check or uncheck according to the main checkbox in the header template             
                if (inputTypes[i].type == 'checkbox' && inputTypes[i].id.indexOf(gvChkBoxControl, 0) >= 0)
                    inputTypes[i].checked = mainChkBox.checked;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
            </td>
            <td colspan="8" height="30px" style="text-align: center; text-decoration: underline">
                <asp:Label ID="lblRequirementmesg" runat="server" CssClass="header" Text="You can post/modify your Requirement/PO parts here!"
                    Style="font-size: large; font-weight: 700" meta:resourcekey="lblRequirementmesgResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="1%" valign="middle">
            </td>
            <td width="26%" valign="middle" height="15px">
                <asp:Label ID="lblRequirementmesg1" runat="server" Text=" Post your Requirement/PO in file format"
                    Style="font-size: small; font-weight: 700" meta:resourcekey="lblRequirementmesg1Resource1"></asp:Label>
            </td>
            <td width="1%" valign="middle">
            </td>
            <td width="68%" valign="middle" height="15px" colspan="2">
                <asp:Label ID="lblRequirementmesg2" runat="server" Text="Post your Requirement/PO in the given form"
                    Style="font-size: small; font-weight: 700" meta:resourcekey="lbloffermesg2Resource1"></asp:Label>
            </td>
            <td width="21%">
            </td>
        </tr>
        <tr>
            <td width="1%">
                <img id="img2" runat="server" src="Images/arrow_55.gif" alt="" />
            </td>
            <td width="25%" height="30px">
                <asp:LinkButton ID="buyersreq" runat="server" CausesValidation="False" OnClick="buyersreq_Click"
                    CssClass="blue_button_fu" ForeColor="White" Font-Underline="false" Text="Upload Requirement/PO File"
                    ToolTip="Upload your own document and mapped your columns and save your data. Easy & Simple to use."
                    meta:resourcekey="buyersreqResource2"></asp:LinkButton>
            </td>
            <td width="1%">
                <img id="img3" runat="server" src="Images/arrow_55.gif" alt="" />
            </td>
            <td width="70%" height="30px">
                <asp:HyperLink ID="lnkBulkAddRequirements" runat="server" Text="Add Requirements/PO Manually"
                    CssClass="blue_button_fu" ForeColor="White" Font-Underline="false" NavigateUrl="~/UploadBulkRequest.aspx"
                    ToolTip="Add fix amount of requirement just like excel sheet." meta:resourcekey="lnkBulkAddRequirementsResource2"></asp:HyperLink>
            </td>
            <td width="16%">
            </td>
        </tr>
    </table>
    <table border="0" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="100%" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <div class="headerback" style="padding-left: 5px">
                                <asp:Label ID="lblgrdheading" runat="server" Text="Edit/Modify your earlier posted Requirement/PO "
                                    class="header" meta:resourcekey="lblgrdheadingResource1"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="8" class="headerback">
                            <span style="color: Red">*</span>
                            <asp:Label ID="lbloffermesg3" runat="server" Text="fields are mandatory.   Note: Do not leave any space while entering part numbers."
                                Style="font-size: medium; font-weight: 700" meta:resourcekey="lbloffermesg3Resource1"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="grid">
                                        <table width="100%" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="top" class="headerback">
                                                    <asp:Panel DefaultButton="btnSearch" runat="server" meta:resourcekey="PanelResource1">
                                                        <table width="100%" cellpadding="0" cellspacing="0" style="height: 35px">
                                                            <tr>
                                                                <td align="left" class="style17">
                                                                    <asp:Label ID="lblFilter" runat="server" Text="Filter With:" meta:resourcekey="lblFilterResource1"></asp:Label>
                                                                </td>
                                                                <td align="left" class="style16">
                                                                    <asp:DropDownList ID="ddlSearchType" runat="server" Width="130px" AutoPostBack="True"
                                                                        CssClass="smallinput_t200" OnSelectedIndexChanged="ddlSearchType_SelectedIndexChanged"
                                                                        meta:resourcekey="ddlSearchTypeResource1">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Part Number" Value="ComponentName"></asp:ListItem>
                                                                        <asp:ListItem Text="Make" Value="BrandName"></asp:ListItem>
                                                                        <asp:ListItem Text="Quantity" Value="Quantity"></asp:ListItem>
                                                                        <%--<asp:ListItem Text="Status" Value="4"></asp:ListItem>--%>
                                                                        <asp:ListItem Text="With PO/RFQ" Value="Status_with_po"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" class="style18">
                                                                    <asp:Label ID="lblsearch" runat="server" Text="Search:" meta:resourcekey="lblsearchResource1"></asp:Label>
                                                                </td>
                                                                <td width="5%" align="left">
                                                                    <asp:TextBox ID="txtSearchContent" runat="server" CssClass="smallinput_t200" meta:resourcekey="txtSearchContentResource1"
                                                                        AutoCompleteType="Search"></asp:TextBox>
                                                                    <asp:DropDownList ID="ddlStatusSearch" runat="server" Visible="False" AutoPostBack="True"
                                                                        Width="110px" OnSelectedIndexChanged="ddlStatusSearch_SelectedIndexChanged" meta:resourcekey="ddlStatusSearchResource1">
                                                                        <asp:ListItem Text="Select" Value="select"></asp:ListItem>
                                                                        <asp:ListItem Text="PO" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="RFQ" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td width="2%">
                                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/search_button.png"
                                                                        OnClick="btnSearch_Click" ToolTip="Search" meta:resourcekey="btnSearchResource1" />
                                                                </td>
                                                                <td width="3%">
                                                                    <asp:ImageButton ID="btnClearSearch" runat="server" ImageUrl="~/Images/clear_btn.png"
                                                                        ToolTip="Clear" OnClick="btnClearSearch_Click" meta:resourcekey="btnClearSearchResource1" />
                                                                </td>
                                                                <td width="18%">
                                                                    <asp:Label ID="lblmsg" runat="server" CssClass="redmsg" Visible="False" meta:resourcekey="lblmsgResource1"></asp:Label>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style17">
                                                                    <asp:Button ID="btnDelInventories" runat="server" Text="Delete" OnClick="btnDelInventories_Click"
                                                                        CssClass="blue_button_fu" ValidationGroup="deleteConfirmation" meta:resourcekey="btnDelInventoriesResource1" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <asp:GridView ID="gdvBuyersReqDetails" runat="server" AllowSorting="True" ClientIDMode="Static"
                                                        PageSize="20" AutoGenerateColumns="False" DataKeyNames="BuyerRequirementId" CellPadding="0"
                                                        AllowPaging="True" OnRowEditing="gdvBuyersReqDetails_RowEditing" OnRowUpdating="gdvBuyersReqDetails_RowUpdating"
                                                        OnRowDeleting="gdvBuyersReqDetails_RowDeleting" OnRowCancelingEdit="gdvBuyersReqDetails_RowCancelingEdit"
                                                        OnPageIndexChanging="gdvBuyersReqDetails_PageIndexChanging1" OnRowDataBound="gdvBuyersReqDetails_RowDataBound"
                                                        Width="100%" meta:resourcekey="gdvBuyersReqDetailsResource1" CssClass="table-border">
                                                        <Columns>
                                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource10">
                                                                <HeaderTemplate>
                                                                    <input type="checkbox" id="chkBoxAll" runat="server" onclick="checkAllBoxes();" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkbx" runat="server" meta:resourcekey="chkbxResource1" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                                <ControlStyle Width="99%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False" Visible="False" meta:resourcekey="TemplateFieldResource1">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBuyerRequirementId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BuyerRequirementId") %>'
                                                                        Visible="False" meta:resourcekey="lblBuyerRequirementIdResource1"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                                                                <ControlStyle Width="99%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False" Visible="False" meta:resourcekey="TemplateFieldResource1">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUserId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserId") %>'
                                                                        Visible="False" meta:resourcekey="lblBuyerRequirementIdResource1"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                                                                <ControlStyle Width="99%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Part #" meta:resourcekey="TemplateFieldResource20">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblComponentName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentName") %>'
                                                                        meta:resourcekey="lblComponentNameResource1"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblComponentName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentName") %>'
                                                                        meta:resourcekey="lblComponentNameResource1"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="6%" />
                                                                <ControlStyle Width="99%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Qty" meta:resourcekey="TemplateFieldResource21">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>'
                                                                        meta:resourcekey="lblQuantityResource1"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' CssClass="smallinput_t"
                                                                        meta:resourcekey="txtQuantityResource1"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvQuality" runat="server" ControlToValidate="txtQuantity"
                                                                        ErrorMessage="Please Enter value" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                                        meta:resourcekey="rfvQualityResource1" />
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorQuantity" runat="server"
                                                                        ControlToValidate="txtQuantity" ErrorMessage="Enter Numeric Data" ValidationExpression="^(\s*)\d+(\s*)$"
                                                                        ForeColor="Red" Display="Dynamic" meta:resourcekey="RegularExpressionValidatorQuantityResource1"></asp:RegularExpressionValidator>
                                                                </EditItemTemplate>
                                                                <ControlStyle Width="99%" />
                                                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Make" meta:resourcekey="TemplateFieldResource11">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBrandName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BrandName") %>'
                                                                        meta:resourcekey="lblBrandNameResource2"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtBrandName" runat="server" Text='<%# Eval("BrandName") %>' CssClass="smallinput_t"
                                                                        meta:resourcekey="txtBrandNameResource3"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                                                                <ControlStyle Width="99%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date Code" meta:resourcekey="TemplateFieldResource22">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDateCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateCode") %>'
                                                                        meta:resourcekey="lblDateCodeResource1"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtDateCode" runat="server" Text='<%# Eval("DateCode") %>' CssClass="smallinput_t"
                                                                        meta:resourcekey="txtDateCodeResource1"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                                                                <ControlStyle Width="99%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Package" meta:resourcekey="TemplateFieldResource13">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPackage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Package") %>'
                                                                        meta:resourcekey="lblPackageResource1"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtPackage" runat="server" Text='<%# Eval("Package") %>' CssClass="smallinput_t"
                                                                        meta:resourcekey="txtPackageResource1"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                                                                <ControlStyle Width="99%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Unit price in IRs" meta:resourcekey="TemplateFieldResource23">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPriceInUSD" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PriceInUSD") %>'
                                                                        meta:resourcekey="lblPriceInUSDResource1"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtPriceInUSD" runat="server" Text='<%# Eval("PriceInUSD") %>' CssClass="smallinput_t"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revpriceusd" ControlToValidate="txtPriceInUSD"
                                                                        runat="server" ErrorMessage="Enter Numeric Value Upto 3 Decimal" ForeColor="Red"
                                                                        Display="Dynamic" ValidationExpression="^\d{0,9}(\.\d{1,3})?$" meta:resourcekey="revpriceusdResource1"></asp:RegularExpressionValidator>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                                                                <ControlStyle Width="99%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Comment" meta:resourcekey="TemplateFieldResource24">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'
                                                                        meta:resourcekey="lblDescriptionResource1"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>'
                                                                        CssClass="smallinput_t" meta:resourcekey="txtDescriptionResource1"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                                                                <ControlStyle Width="99%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="With PO/RFQ" meta:resourcekey="TemplateFieldResource14">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblWithPO" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RequirementWithPO") %>'
                                                                        meta:resourcekey="lblWithPOResource1"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlWithPO" Width="80px" runat="server" CssClass="smallinput_t200"
                                                                        meta:resourcekey="ddlWithPOResource1">
                                                                        <asp:ListItem Text="PO" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="RFQ" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                                <ControlStyle Width="99%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource8">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgbtnEdit" ToolTip="Edit" ImageUrl="~/Images/edit_btn.png"
                                                                        CommandName="Edit" meta:resourcekey="imgbtnEditResource2" />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgbtnEdit" ToolTip="Update" ImageUrl="~/Images/save_btn.png"
                                                                        CommandName="Update" meta:resourcekey="imgbtnEditResource1" />
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource9">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgbtnDelete" ImageUrl="~/Images/deletet_btn.png"
                                                                        CommandName="Delete" ToolTip="Delete" ValidationGroup="deleteConfirmation" meta:resourcekey="imgbtnDeleteResource1" />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgbtnCancel" ImageUrl="~/Images/cancel_btn.png"
                                                                        CommandName="Cancel" ToolTip="Cancel" meta:resourcekey="imgbtnCancelResource1" />
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
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
                                                        <RowStyle CssClass="odd"></RowStyle>
                                                        <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <PagerStyle CssClass="headerback" HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                    <asp:CustomValidator ID="CustomValidator1" ClientValidationFunction="confirmDelete"
                                                        ValidationGroup="deleteConfirmation" runat="server" meta:resourcekey="CustomValidator1Resource1"></asp:CustomValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlSearchType" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="sortDirection" Value="Ascending" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
