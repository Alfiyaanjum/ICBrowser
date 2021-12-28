<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableViewState="true" CodeBehind="UploadInventory.aspx.cs" Inherits="ICBrowser.Web.UploadInventory"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=txtProductDate]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
        });
    </script>
    <script type="text/javascript">
        function showPopUp(componentid) {
            //  alert("Hello world in Show Popup");
            $get('<%= hidComponentId.ClientID %>').value = componentid;
            $find('<%= ModalPopupExtender1.ClientID %>').show();
        }

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
            $("#MainContent_datepicker").datepicker({ minDate: new Date(), dateFormat: 'dd-M-yy' });
        });
        
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindPicker);
            bindPicker();
        });
        function bindPicker() {
            $("input[type=text][id*=DateTimeValue]").datepicker({ minDate: new Date(), dateFormat: 'dd-M-yy' });
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdf1" runat="server" />
    <asp:HiddenField ID="hidComponentId" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" Value="lnkShow" />
    <table width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top">
                <table width="100%" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="padding5" align="left" valign="middle" colspan="2">
                            <%-- <a href="data/InventoryExcelSheet/Inventory.xls" style="color: Blue">Download Template</a>--%>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text="Download Template" Target="_blank"
                                NavigateUrl="data/InventoryExcelSheet/Inventory.xls" meta:resourcekey="HyperLink1Resource1"></asp:HyperLink>
                            <%--<asp:HyperLink ID="HyperLink1" runat="server" Text="Download Template" Target="_blank"
                                NavigateUrl="data/InventoryExcelSheet/Inventory.xls"
                                meta:resourcekey="HyperLink1Resource1"></asp:HyperLink>--%>
                            &nbsp;&nbsp;OR &nbsp;&nbsp;
                            <asp:LinkButton ID="lnkAddInventory" runat="server" Style="color: Blue" Text="Add Inventory"
                                CausesValidation="False" meta:resourcekey="lnkAddInventoryResource1"></asp:LinkButton>
                            &nbsp;&nbsp;OR &nbsp;&nbsp;
                            <asp:LinkButton ID="lnkBulkAddInventory" runat="server" Text="Bulk Add Inventory "
                                CausesValidation="false" OnClick="lnkBulkAddInventory_Click"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" cellspacing="0" cellpadding="4">
                                <tr>
                                    <td align="left" valign="top">
                                        <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left" width="20%">
                                                    <%-- <span style="color: Black">Upload&nbsp;File :&nbsp; </span>--%>
                                                    <asp:Label ID="lblUpload" CssClass="text " runat="server" Text="Upload File :" meta:resourcekey="lblUploadResource1"></asp:Label>
                                                </td>
                                                <td align="center" width="10%">
                                                    <asp:FileUpload ID="fuExcelSheet" runat="server" CssClass="browse_but" meta:resourcekey="fuExcelSheetResource1" />
                                                </td>
                                                <td align="left" width="60%" style="padding-left: 10px">
                                                    <asp:Button ID="FileUpload" runat="server" OnClick="FileUpload_Click" CssClass="upload_but"
                                                        Height="20px" CausesValidation="False" BackColor="Transparent" BorderColor="Transparent"
                                                        BorderStyle="None" meta:resourcekey="FileUploadResource1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <%--      <td valign="top" width="50%">
                                        <div id="chart_bgSearch">
                                            <div class="chart_heading">
                                                Search
                                            </div>
                                            <div class="grid">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="40%" align="left">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>--%>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--   <tr style="height: 8px">
            <td style="width: 200px">
                <asp:Label ID="lblStatusmsg" runat="server" CssClass="redmsg" Visible="false"></asp:Label>
            </td>
        </tr>--%>
        <tr>
            <td style="width: 100%">
                <table style="width: 100%" cellspacing="0" cellpadding="0">
                    <tr style="height: 8px">
                        <td style="width: 100%">
                            <asp:Label ID="lblUploadMessage" runat="server" CssClass="greenmsg" meta:resourcekey="lblUploadMessageResource1"></asp:Label>
                            <asp:Label ID="lblExcessMessage" runat="server" CssClass="redmsg" meta:resourcekey="lblExcessMessageResource1"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <table align="left" width="100%" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="left" valign="top">
                            <div id="chart_bg">
                                <div class="chart_heading">
                                    <asp:Label ID="lblgrdheading" runat="server" CssClass="header" Text="Uploaded Inventories"
                                        meta:resourcekey="lblgrdheadingResource1"></asp:Label>
                                </div>
                                <div class="grid">
                                    <asp:UpdatePanel ID="Updatepanel1" runat="server">
                                        <ContentTemplate>
                                            <table width="100%" cellpadding="2" cellspacing="0">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:Panel ID="pnlFilter" DefaultButton="imgSearchFromGrid" runat="server">
                                                            <table width="100%" cellspacing="0" cellpadding="0" style="height: 35px">
                                                                <tr>
                                                                    <td valign="middle" align="right" width="15%">
                                                                        <asp:Label ID="lblFilter" runat="server" Text="Filter With :" CssClass="text" meta:resourcekey="lblFilterResource1"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="20%" valign="middle">
                                                                        <asp:DropDownList ID="ddlInventoryGridColumns" runat="server" Width="130px" AutoPostBack="True"
                                                                            CssClass="smallinput_t200" OnSelectedIndexChanged="ddlInventoryGridColumns_SelectedIndexChanged"
                                                                            meta:resourcekey="ddlInventoryGridColumnsResource1">
                                                                            <asp:ListItem Text="--Select--" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                                            <asp:ListItem Text="Part Number" Value="1" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                                                            <asp:ListItem Text="Make" Value="2" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                                                            <asp:ListItem Text="Quantity" Value="3" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                                                            <asp:ListItem Text="Status" Value="4" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td width="15%" valign="middle" align="right">
                                                                        <asp:Label ID="lblSearch" runat="server" Text="Search Text :" CssClass="text" meta:resourcekey="lblSearchResource1"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="20%" valign="middle">
                                                                        <asp:TextBox ID="txtSearchFromGrid" runat="server" CssClass="smallinput_t" Width="126px"
                                                                            meta:resourcekey="txtSearchFromGridResource1"></asp:TextBox>
                                                                        <asp:DropDownList ID="ddlstatus" runat="server" Width="130px" Visible="False" AutoPostBack="True"
                                                                            CssClass="smallinput_t200" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged"
                                                                            meta:resourcekey="ddlstatusResource1">
                                                                            <asp:ListItem Text="--Select--" Value="-1" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                                                            <asp:ListItem Text="Open" Value="1" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                                                            <asp:ListItem Text="Closed" Value="0" meta:resourcekey="ListItemResource8"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td width="5%" align="left" valign="middle">
                                                                        <asp:ImageButton ID="imgSearchFromGrid" runat="server" ImageUrl="~/Images/Search.png"
                                                                            OnClick="imgSearchFromGrid_Click" ToolTip="Search" meta:resourcekey="imgSearchFromGridResource1" />
                                                                        <%-- <asp:ImageButton ID="imgSearchFromGrid" CausesValidation="False" runat="server" ImageUrl="~/Images/Search.png"
                                                                        ToolTip="Search" OnClick="imgSearchFromGrid_Click" meta:resourcekey="imgSearchFromGridResource1" />&nbsp;&nbsp;--%>
                                                                    </td>
                                                                    <td width="60%" align="left" valign="middle">
                                                                        <asp:ImageButton ID="imgClearSearchSelection" runat="server" ImageUrl="~/Images/clear_icon.png"
                                                                            CausesValidation="False" ToolTip="Clear Search" OnClick="imgClearSearchSelection_Click"
                                                                            meta:resourcekey="imgClearSearchSelectionResource1" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" align="left">
                                                        <table width="100%" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top" class="chart_heading">
                                                                    <table width="100%" cellpadding="0" cellspacing="0" style="background-color: Gray">
                                                                        <tr>
                                                                            <td>
                                                                                <table width="100%" cellspacing="0" cellpadding="0" style="background-color: #dfedf7">
                                                                                    <tr>
                                                                                        <td width="8%" align="left">
                                                                                            <asp:Label ID="lblgrdStatus" runat="server" Text="Status" CssClass="bold" meta:resourcekey="lblgrdStatusResource1"></asp:Label>
                                                                                        </td>
                                                                                        <td width="16%" align="left">
                                                                                            <asp:Label ID="lblgrdComponentName" runat="server" Text="Part Number" CssClass="bold"
                                                                                                meta:resourcekey="lblgrdComponentNameResource1"></asp:Label>
                                                                                        </td>
                                                                                        <td width="9%" align="left">
                                                                                            <asp:Label ID="lblgrdQuantity" runat="server" Text="Quantity" CssClass="bold" meta:resourcekey="lblgrdQuantityResource1"></asp:Label>
                                                                                        </td>
                                                                                        <td width="14%" align="left">
                                                                                            <asp:Label ID="lblgrdStockinHand" runat="server" Text="Stock in Hand" CssClass="bold"
                                                                                                meta:resourcekey="lblgrdStockinHandResource1"></asp:Label>
                                                                                        </td>
                                                                                        <td width="16%" align="left">
                                                                                            <asp:Label ID="lblgrdBrandname" runat="server" Text="Make" CssClass="bold" meta:resourcekey="lblgrdBrandnameResource1"></asp:Label>
                                                                                        </td>
                                                                                        <td width="14%" align="left">
                                                                                            <asp:Label ID="lblgrdDatasheet" runat="server" Text="DataSheet" CssClass="bold" meta:resourcekey="lblgrdDatasheetResource1"></asp:Label>
                                                                                        </td>
                                                                                        <td width="12%" align="left" colspan="2">
                                                                                            <asp:Label ID="lblOperations" runat="server" Text="Operations" CssClass="bold" meta:resourcekey="lblOperationsResource1"></asp:Label>
                                                                                        </td>
                                                                                        <%--  <td width="2%" align="left">
                                                                            </td>--%>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <div style="overflow: scroll; height: 350px; width: 650px">
                                                                        <asp:GridView ID="grdInventoryDetails" runat="server" AutoGenerateColumns="False"
                                                                            PageSize="15" ShowHeader="False" CellPadding="0" OnRowDeleting="grdInventoryDetails_RowDeleting"
                                                                            ClientIDMode="Static" OnRowCommand="grdInventoryDetails_RowCommand" OnRowUpdating="grdInventoryDetails_RowUpdating"
                                                                            OnRowCancelingEdit="grdInventoryDetails_RowCancelingEdit" OnRowUpdated="grdInventoryDetails_RowUpdated"
                                                                            OnRowDataBound="grdInventoryDetails_RowDataBound" AllowSorting="True" DataKeyNames="ComponentId"
                                                                            AllowPaging="True" Width="100%" OnPageIndexChanging="grdInventoryDetails_PageIndexChanging"
                                                                            OnRowEditing="grdInventoryDetails_RowEditing1" meta:resourcekey="grdInventoryDetailsResource1">
                                                                            <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Status" meta:resourcekey="TemplateFieldResource1">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status") %>'
                                                                                            meta:resourcekey="lblStatusResource1"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="smallinput_t200" meta:resourcekey="ddlStatusResource2">
                                                                                            <asp:ListItem Text="Closed" Value="0" meta:resourcekey="ListItemResource9"></asp:ListItem>
                                                                                            <asp:ListItem Text="Open" Value="1" meta:resourcekey="ListItemResource10"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <ItemStyle Width="10%" />
                                                                                    <ControlStyle Width="99%"></ControlStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ShowHeader="False" Visible="False" meta:resourcekey="TemplateFieldResource2">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="LblComponentId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentId") %>'
                                                                                            Visible="False" meta:resourcekey="LblComponentIdResource1"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Part Number" meta:resourcekey="TemplateFieldResource3">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="LblComponentname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentName") %>'
                                                                                            meta:resourcekey="LblComponentnameResource1"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="txtComponentName" runat="server" CssClass="smallinput_t" Text='<%# Eval("ComponentName") %>'
                                                                                            meta:resourcekey="txtComponentNameResource1"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RfVtxtCompNmae" runat="server" ControlToValidate="txtComponentName"
                                                                                            ValidationGroup="gridvalidation" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                                                            ErrorMessage="Enter Component Name" meta:resourcekey="RfVtxtCompNmaeResource1"></asp:RequiredFieldValidator>
                                                                                    </EditItemTemplate>
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ControlStyle Width="99%"></ControlStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Quantity" meta:resourcekey="TemplateFieldResource4">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="LblQuantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>'
                                                                                            meta:resourcekey="LblQuantityResource1"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' CssClass="smallinput_t"
                                                                                            meta:resourcekey="txtQuantityResource1"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="rfvqntity" runat="server" ControlToValidate="txtQuantity"
                                                                                            ValidationGroup="gridvalidation" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                                                            ErrorMessage="Enter Quantity" meta:resourcekey="rfvqntityResource1"></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="revtxtQntity" runat="server" ControlToValidate="txtQuantity"
                                                                                            ForeColor="Red" ErrorMessage="Enter Numeric data !" ValidationGroup="gridvalidation"
                                                                                            ValidationExpression="^(\s*)\d+(\s*)$" Display="Dynamic" meta:resourcekey="revtxtQntityResource1"></asp:RegularExpressionValidator>
                                                                                    </EditItemTemplate>
                                                                                    <ItemStyle Width="10%" />
                                                                                    <ControlStyle Width="99%"></ControlStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Stock In Hand" meta:resourcekey="TemplateFieldResource5">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStockInHand" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StockInHand") %>'
                                                                                            meta:resourcekey="lblStockInHandResource1"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="txtStockInHand" runat="server" Text='<%# Eval("StockInHand") %>'
                                                                                            CssClass="smallinput_t" meta:resourcekey="txtStockInHandResource1"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="rfvStkInHnd" runat="server" ControlToValidate="txtStockInHand"
                                                                                            ValidationGroup="gridvalidation" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                                                            ErrorMessage="Enter StockInHand" meta:resourcekey="rfvStkInHndResource1"></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="revtxtStockInHand" runat="server" ControlToValidate="txtStockInHand"
                                                                                            ForeColor="Red" ErrorMessage="Enter Numeric data !" ValidationGroup="gridvalidation"
                                                                                            ValidationExpression="^\d+$" Display="Dynamic" meta:resourcekey="revtxtStockInHandResource1"></asp:RegularExpressionValidator>
                                                                                    </EditItemTemplate>
                                                                                    <ItemStyle Width="15%" />
                                                                                    <ControlStyle Width="99%"></ControlStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Make" meta:resourcekey="TemplateFieldResource6">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="LblBrandName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Brandname") %>'
                                                                                            meta:resourcekey="LblBrandNameResource1"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="txtBrandName" CssClass="smallinput_t" runat="server" Text='<%# Eval("Brandname") %>'
                                                                                            MaxLength="50" meta:resourcekey="txtBrandNameResource1"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="rfvbrandname" runat="server" ControlToValidate="txtBrandName"
                                                                                            ValidationGroup="gridvalidation" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                                                            ErrorMessage="Enter Brand Name" meta:resourcekey="rfvbrandnameResource1"></asp:RequiredFieldValidator>
                                                                                    </EditItemTemplate>
                                                                                    <ItemStyle Width="18%" />
                                                                                    <ControlStyle Width="99%"></ControlStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Datasheet" meta:resourcekey="TemplateFieldResource7">
                                                                                    <ItemTemplate>
                                                                                        <asp:HyperLink ID="lnkDataSheet" Target="_blank" Text='<%# Eval("DataSheetFileName") %>'
                                                                                            runat="server" ForeColor="Blue" NavigateUrl='<%# Eval("DataSheetURL") %>' meta:resourcekey="lnkDataSheetResource1"></asp:HyperLink>
                                                                                        <a href="javascript:void(0);" onclick='javascript:showPopUp(<%# Eval("ComponentId") %>);'>
                                                                                            <asp:ImageButton ID="imgupload" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ComponentId") %>'
                                                                                                CommandName="Upload" ImageUrl="~/Images/upload_btn.png" runat="server" Style="border: none;"
                                                                                                Height="20px" Width="2%" OnClientClick="return false" meta:resourcekey="imguploadResource1" />
                                                                                        </a>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <a href="javascript:void(0);" onclick='javascript:showPopUp(<%# Eval("ComponentId") %>);'>
                                                                                            <asp:ImageButton ID="imguploadEdit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "DataSheetFileName") %>'
                                                                                                CommandName="Upload" runat="server" ImageUrl="~/Images/upload_btn.png" Style="border: none;"
                                                                                                Width="2%" Height="20px" OnClientClick="return false" meta:resourcekey="imguploadEditResource1" />
                                                                                        </a>
                                                                                    </EditItemTemplate>
                                                                                    <ControlStyle Width="99%"></ControlStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="5%"></HeaderStyle>
                                                                                    <ItemStyle Width="15%" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField meta:resourcekey="TemplateFieldResource8">
                                                                                    <ItemTemplate>
                                                                                        <%--  <asp:ImageButton runat="server" ID="imgbtnEdit" ToolTip="Edit" ImageUrl="~/Images/edit.png"
                                                                                            CausesValidation="False" CommandName="Edit" meta:resourcekey="imgbtnEditResource1" />--%>
                                                                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CausesValidation="false"
                                                                                            CommandName="Edit"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <%--<asp:ImageButton runat="server" ID="imgbtnEdit" ToolTip="Update" ImageUrl="~/Images/save.png"
                                                                                            ValidationGroup="gridvalidation" CommandName="Update" meta:resourcekey="imgbtnEditResource2" />--%>
                                                                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Update" ValidationGroup="gridvalidation"
                                                                                            CommandName="Update"></asp:LinkButton>
                                                                                    </EditItemTemplate>
                                                                                    <ItemStyle Width="2%" />
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField meta:resourcekey="TemplateFieldResource9">
                                                                                    <ItemTemplate>
                                                                                        <%--<asp:ImageButton runat="server" ID="imgbtnDelete" ImageUrl="~/Images/del.png" CommandName="Delete"
                                                                                            ToolTip="Delete" ValidationGroup="deleteConfirmation" meta:resourcekey="imgbtnDeleteResource1" />--%>
                                                                                        <asp:LinkButton ID="lnkdelete" runat="server" Text="Delete" ValidationGroup="deleteConfirmation"
                                                                                            CommandName="Delete"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                        <%--<asp:ImageButton runat="server" ID="imgbtnCancel" ImageUrl="~/Images/cancel.png"
                                                                                            CausesValidation="False" CommandName="Cancel" ToolTip="Cancel" meta:resourcekey="imgbtnCancelResource1" />--%>
                                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CausesValidation="False"
                                                                                            CommandName="Cancel"></asp:LinkButton>
                                                                                    </EditItemTemplate>
                                                                                    <ItemStyle Width="2%" />
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EditRowStyle Wrap="True" Width="100%"></EditRowStyle>
                                                                            <EmptyDataTemplate>
                                                                                <table style="background-color: #EEF0F6" width="100%" border="0" cellpadding="0"
                                                                                    cellspacing="0">
                                                                                    <tr>
                                                                                        <td colspan="2" class="errormsg" style="height: 100px" align="center">
                                                                                            No records found !
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EmptyDataTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                            <RowStyle CssClass="odd" />
                                                                        </asp:GridView>
                                                                        <asp:CustomValidator ID="CustomValidator1" ClientValidationFunction="confirmDelete"
                                                                            ValidationGroup="deleteConfirmation" runat="server" meta:resourcekey="CustomValidator1Resource1"></asp:CustomValidator>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlInventoryGridColumns" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ModalPopupExtender ID="modalpopou" runat="server" TargetControlID="lnkAddInventory"
                    PopupControlID="pnlAdd" BackgroundCssClass="modalBackground" DynamicServicePath=""
                    Enabled="True">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlAdd" runat="server" Width="100%" Height="410px" meta:resourcekey="pnlAddResource1">
                    <asp:UpdatePanel runat="server" ID="upnlAdd">
                        <ContentTemplate>
                            <div style="height: 100%;" class="popupbox">
                                <table style="height: 100%;" width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="popupbox-lefttop-corner">
                                        </td>
                                        <td class="popupbox-topbg">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="97%" align="left" class="popupbox-header">
                                                        <asp:Label ID="lblAddInventory" runat="server" Text=" Add Inventory" CssClass="title"
                                                            meta:resourceKey="lblAddInventoryResource1"></asp:Label>
                                                    </td>
                                                    <td width="3%" align="right" valign="middle" class="popupbox-header">
                                                        <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Images/cross.png" OnClick="imgCancel_Click"
                                                            ToolTip="Cancel" meta:resourceKey="imgCancelResource1" />
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
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td valign="top" width="50%">
                                                        <table width="100%" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top" align="right" width="40%">
                                                                    <asp:Label ID="lblComponentName" runat="server" Text="Part Number" CssClass="text"
                                                                        meta:resourceKey="lblComponentNameResource2"></asp:Label>
                                                                    <span class="errormsg">*</span><span> :</span>
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <asp:TextBox ID="TxtComponentName" CssClass="smallinput_t" runat="server" Width="99%"
                                                                        meta:resourceKey="TxtComponentNameResource2"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td height="35px" align="left" valign="top">
                                                                    <asp:RequiredFieldValidator ID="reqComponentName" runat="server" ControlToValidate="TxtComponentName"
                                                                        ErrorMessage="Part Number Required" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                                        ValidationGroup="WithoutTemplate" meta:resourceKey="reqComponentNameResource1" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" align="right" style="width: 40%">
                                                                    <asp:Label ID="lblBrandname" runat="server" Text=" Make" CssClass="text" meta:resourceKey="lblBrandnameResource2"></asp:Label>
                                                                    <span class="errormsg">*</span><span> :</span>
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <asp:TextBox ID="TxtBrandName" CssClass="smallinput_t" runat="server" Width="99%"
                                                                        meta:resourceKey="TxtBrandNameResource2"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td height="35px" align="left" valign="top">
                                                                    <asp:RequiredFieldValidator ID="rfvbrandname" runat="server" ControlToValidate="TxtBrandName"
                                                                        ErrorMessage="Make Required" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                                        ValidationGroup="WithoutTemplate" meta:resourceKey="rfvbrandnameResource2" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" align="right">
                                                                    <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="text"
                                                                        meta:resourceKey="lblDescriptionResource1"></asp:Label><span class="errormsg">*</span><span>
                                                                            :</span>
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <asp:TextBox ID="TxtDescription" CssClass="smallinput_t_multilinetextbox" runat="server"
                                                                        Width="99%" TextMode="MultiLine" Height="50px" meta:resourceKey="TxtDescriptionResource1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td height="35px" align="left" valign="top">
                                                                    <asp:RequiredFieldValidator ID="rfvdesc" runat="server" ControlToValidate="TxtDescription"
                                                                        ErrorMessage="Required" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                                        ValidationGroup="WithoutTemplate" meta:resourceKey="rfvdescResource1" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" align="right">
                                                                    <asp:Label ID="lblAvailDate" runat="server" Text="Available Date" CssClass="text"
                                                                        meta:resourceKey="lblAvailDateResource1"></asp:Label>
                                                                    (dd-mm-yyyy) <span class="errormsg">*</span><span> :</span>
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <%--  <ew:CalendarPopup ID="CalendarExtender" runat="server" ControlDisplay="TextBoxImage"
                                                                                ImageUrl="~/Images/dummyCal.png" Height="20px" Width="150px" PopupLocation="Bottom"
                                                                                Nullable="True" Culture="en-IN" SelectedDate="" VisibleDate="" meta:resourceKey="CalendarExtenderResource1" />--%>
                                                                    <%--<input type="text" id="datepicker" runat="server" readonly="readonly" class="smallinput_t" />--%>
                                                                    <asp:TextBox ID="txtAvailfrom" runat="server" class="smallinput_t" ValidationGroup="VgOne"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtAvailfrom"
                                                                        EnableViewState="true" ViewStateMode="Enabled" Format="dd-MMM-yyyy">
                                                                    </asp:CalendarExtender>
                                                                    <%--<input type="text" name="datetime" id="Text1" runat="server" readonly="readonly"
                                                                        class="smallinput_t">--%>
                                                                    <%-- <asp:TextBox ID="datepicker" runat="server" ReadOnly="true" ValidationGroup="WithoutTemplate"></asp:TextBox>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td height="20px" align="left" valign="top">
                                                                    <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtAvailfrom"
                                                                        meta:resourceKey="rfvDateResource1" Display="Dynamic" ErrorMessage="Please Select a Date"
                                                                        ForeColor="Red" SetFocusOnError="True" ValidationGroup="WithoutTemplate"></asp:RequiredFieldValidator>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="datepicker"
                                                                                Display="Dynamic" ErrorMessage="Please Enter Date" ForeColor="Red" SetFocusOnError="True"
                                                                                ValidationGroup="WithoutTemplate"></asp:RequiredFieldValidator>--%>
                                                                    <%--  <ew:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="CalendarExtender"
                                                                                ForeColor="Red" ErrorMessage="Available date Required" SetFocusOnError="True"
                                                                                ValidationGroup="WithoutTemplate" meta:resourceKey="rfvDateResource1"></ew:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" align="right">
                                                                    <asp:Label ID="lblStockinHand" runat="server" Text=" Stock In Hand" CssClass="text"
                                                                        meta:resourceKey="lblStockinHandResource2"></asp:Label>
                                                                    <span class="errormsg">*</span><span> :</span>
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <asp:TextBox ID="TxtStockInHand" CssClass="smallinput_t" runat="server" Width="60%"
                                                                        MaxLength="9" meta:resourceKey="TxtStockInHandResource2"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td height="35px" align="left" valign="top">
                                                                    <asp:RequiredFieldValidator ID="rfvstockinhand" runat="server" ControlToValidate="TxtStockInHand"
                                                                        ErrorMessage="Stock In Hand Required" ForeColor="Red" SetFocusOnError="True"
                                                                        Display="Dynamic" ValidationGroup="WithoutTemplate" meta:resourceKey="rfvstockinhandResource1" />
                                                                    <asp:RegularExpressionValidator ID="revtxtStockInHand" runat="server" ControlToValidate="TxtStockInHand"
                                                                        ForeColor="Red" ValidationGroup="WithoutTemplate" ErrorMessage="Enter Numeric data !"
                                                                        Display="Dynamic" ValidationExpression="^\d+$" meta:resourceKey="revtxtStockInHandResource2"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top" width="50%">
                                                        <table width="100%" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top" align="right" width="45%">
                                                                    <asp:Label ID="lblQuantity" runat="server" Text=" Quantity" CssClass="text" meta:resourceKey="lblQuantityResource2"></asp:Label>
                                                                    <span class="errormsg">*</span><span> :</span>
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <asp:TextBox ID="TxtQuantity" CssClass="smallinput_t" runat="server" Width="60%"
                                                                        MaxLength="9" meta:resourceKey="TxtQuantityResource2"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td height="35px" align="left" valign="top">
                                                                    <asp:RequiredFieldValidator ID="rfvqnty" runat="server" ControlToValidate="TxtQuantity"
                                                                        ErrorMessage="Quantity Required" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                                        ValidationGroup="WithoutTemplate" meta:resourceKey="rfvqntyResource1" />
                                                                    <asp:RegularExpressionValidator ID="revtxtQuantity" runat="server" ValidationGroup="WithoutTemplate"
                                                                        ControlToValidate="TxtQuantity" ErrorMessage="Please enter Numeric Data" ValidationExpression="^(\s*)\d+(\s*)$"
                                                                        ForeColor="Red" meta:resourceKey="revtxtQuantityResource1"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" align="right" width="45%">
                                                                    <asp:Label ID="lblPriceinINR" runat="server" Text=" Price In INR" CssClass="text"
                                                                        meta:resourceKey="lblPriceinINRResource1"></asp:Label>
                                                                    <span class="errormsg">*</span><span> :</span>
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <asp:TextBox ID="TxtPriceInINR" CssClass="smallinput_t" runat="server" Width="60%"
                                                                        MaxLength="9" meta:resourceKey="TxtPriceInINRResource1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td height="35px" valign="top" align="left">
                                                                    <asp:RequiredFieldValidator ID="rfvtxtPrcInINR" runat="server" ControlToValidate="TxtPriceInINR"
                                                                        ErrorMessage="Price In INR Required" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                                        ValidationGroup="WithoutTemplate" meta:resourceKey="rfvtxtPrcInINRResource1" />
                                                                    <asp:RegularExpressionValidator ID="revpriceinr" ControlToValidate="TxtPriceInINR"
                                                                        ForeColor="Red" ValidationGroup="WithoutTemplate" runat="server" ErrorMessage="Enter Numeric data"
                                                                        ValidationExpression="[0-9]*\.?[0-9]*" Text="Enter only Numeric data" meta:resourceKey="revpriceinrResource1"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" align="right" width="45%">
                                                                    <asp:Label ID="lblPriceinUSD" runat="server" Text="Price In USD" CssClass="text"
                                                                        meta:resourceKey="lblPriceinUSDResource1"></asp:Label>
                                                                    <span class="errormsg">*</span><span> :</span>
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <asp:TextBox ID="TxtPriceInUSD" CssClass="smallinput_t" runat="server" Width="60%"
                                                                        MaxLength="9" meta:resourceKey="TxtPriceInUSDResource1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td height="35px" valign="top" align="left">
                                                                    <asp:RequiredFieldValidator ID="rfvPrcInUSD" runat="server" ControlToValidate="TxtPriceInUSD"
                                                                        ErrorMessage="Price In USD Required" ForeColor="Red" SetFocusOnError="True" Display="Dynamic"
                                                                        ValidationGroup="WithoutTemplate" meta:resourceKey="rfvPrcInUSDResource1" />
                                                                    <asp:RegularExpressionValidator ID="revpriceusd" ControlToValidate="TxtPriceInUSD"
                                                                        ValidationGroup="WithoutTemplate" runat="server" ErrorMessage="Invalid Number"
                                                                        ForeColor="Red" ValidationExpression="[0-9]*\.?[0-9]*" Text="Enter only Numeric data"
                                                                        meta:resourceKey="revpriceusdResource1"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" align="right" width="45%">
                                                                    <asp:Label ID="lblPriceinCNY" runat="server" Text="Price In CNY" CssClass="text"
                                                                        meta:resourceKey="lblPriceinCNYResource1"></asp:Label>
                                                                    <span class="errormsg">*</span><span> :</span>
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <asp:TextBox ID="txtpriceinCNY" CssClass="smallinput_t" runat="server" Width="60%"
                                                                        meta:resourceKey="txtpriceinCNYResource1" MaxLength="9"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td height="35px" valign="top" align="left">
                                                                    <asp:RequiredFieldValidator ID="rfvpriceinCNY" runat="server" ControlToValidate="txtpriceinCNY"
                                                                        meta:resourceKey="rfvpriceinCNYResource1" ErrorMessage="Price In CNY Required"
                                                                        ForeColor="Red" SetFocusOnError="True" Display="Dynamic" ValidationGroup="WithoutTemplate" />
                                                                    <asp:RegularExpressionValidator ID="revpriceinCNY" ControlToValidate="txtpriceinCNY"
                                                                        ValidationGroup="WithoutTemplate" runat="server" ErrorMessage="Invalid Number"
                                                                        meta:resourceKey="revpriceinCNYResource1" ForeColor="Red" ValidationExpression="[0-9]*\.?[0-9]*"
                                                                        Text="Enter only Numeric data"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" align="right" width="45%">
                                                                    <asp:Label ID="lblDataSheetURL" runat="server" Text=" DataSheet URL :" CssClass="text"
                                                                        meta:resourceKey="lblDataSheetURLResource1"></asp:Label>
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <asp:FileUpload ID="FuploadAdd" runat="server" CssClass="browse_but" meta:resourceKey="FuploadAddResource1" />
                                                                    &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;OR
                                                                    <asp:TextBox ID="txtDatasheetlink" runat="server" CssClass="smallinput_t" Width="60%"
                                                                        meta:resourceKey="txtDatasheetlinkResource1"></asp:TextBox>
                                                                    (<asp:Label ID="lblfrex" runat="server" Text="For ex.:" meta:resourceKey="lblfrexResource1"></asp:Label>
                                                                    http://www.google.com)
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnAddInventoryDetails" runat="server" Text="Save" Width="80px" OnClick="btnAddInventoryDetails_Click"
                                                            ValidationGroup="WithoutTemplate" CssClass="blue_button" meta:resourceKey="btnAddInventoryDetailsResource1" />
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
                            <asp:PostBackTrigger ControlID="btnAddInventoryDetails" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%" cellspacing="5" cellpadding="6">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkShow" runat="server" meta:resourcekey="lnkShowResource1"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lnkShow"
                                PopupControlID="panelUploadFile" BackgroundCssClass="modalBackground" DynamicServicePath=""
                                Enabled="True">
                            </asp:ModalPopupExtender>
                            <asp:Panel ID="panelUploadFile" runat="server" Width="350px" Height="250px" meta:resourcekey="panelUploadFileResource1">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                    <ContentTemplate>
                                        <div style="height: 100%; width: 100%;" class="popupbox">
                                            <table style="height: 100%;" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td class="popupbox-lefttop-corner">
                                                    </td>
                                                    <td class="popupbox-topbg">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="97%" align="left" class="popupbox-header">
                                                                    <asp:Label ID="lblUploadgrd" runat="server" Text="Upload File" CssClass="title" meta:resourceKey="lblUploadgrdResource1"></asp:Label>
                                                                </td>
                                                                <td width="3%" align="right" valign="middle" class="popupbox-header">
                                                                    <asp:ImageButton ID="imgcancl" runat="server" ImageUrl="~/Images/cross.png" meta:resourceKey="imgcanclResource1"
                                                                        OnClick="imgcancl_Click" />
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
                                                            <tr id="trUploadedFile" runat="server" visible="false">
                                                                <td align="left">
                                                                    <asp:Label ID="lblgrdUpldFile" runat="server" Text="Uploaded File :" CssClass="text"></asp:Label>
                                                                    <asp:Label ID="lblUploadedFile" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:FileUpload ID="fuGridUploader" runat="server" meta:resourceKey="fuGridUploaderResource1"
                                                                        CssClass="browse_but" />
                                                                    OR
                                                                    <br />
                                                                    <asp:TextBox ID="txtlink" runat="server" Width="150px"></asp:TextBox>
                                                                    (<asp:Label ID="lblex" runat="server" Text="For ex.:" CssClass="text" meta:resourceKey="lblexResource1"></asp:Label>
                                                                    http://www.google.com) &nbsp;&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Button ID="btnUploadSave" runat="server" Text="Save" Width="80px" CausesValidation="False"
                                                                        CssClass="blue_button" OnClick="btnUploadSave_Click" meta:resourceKey="btnUploadSaveResource1" />
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
                                        <asp:PostBackTrigger ControlID="btnUploadSave" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
