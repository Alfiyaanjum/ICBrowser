<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master"
    AutoEventWireup="true" CodeBehind="SellerUploadedInventory.aspx.cs" Inherits="ICBrowser.Web.SellerUploadedInventory"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="Controls/SellerInventories.ascx" TagName="SellerInventories" TagPrefix="uc1" %>
<%--<%@ Register Src="Controls/SellerInventory.ascx" TagName="SellerInventory" TagPrefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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

        function checkAllBoxes() {

            //get total number of rows in the gridview and do whatever
            //you want with it..just grabbing it just cause
            var totalChkBoxes = parseInt('<%= grdInventoryDetails.Rows.Count %>');
            var gvControl = document.getElementById('<%= grdInventoryDetails.ClientID %>');

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
    <style type="text/css">
        .style1
        {
            width: 7%;
        }
        .style2
        {
            width: 14%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <table width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="100%" cellspacing="0" cellpadding="2">
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="8" height="30px" style="text-align: center; text-decoration: underline">
                                        <asp:Label ID="lblinventorymesg" runat="server" CssClass="header" Text="You can post/modify your Inventory parts here!"
                                            Style="font-size: medium; font-weight: 700" meta:resourcekey="lbloffermesgResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="1%" valign="middle">
                                    </td>
                                    <td width="26%" valign="middle" height="15px">
                                        <asp:Label ID="lblinventorymesg1" runat="server" Text=" Post your Inventory in file format"
                                            Style="font-size: small; font-weight: 700" meta:resourcekey="lbloffermesg1Resource1"></asp:Label>
                                    </td>
                                    <td width="1%" valign="middle">
                                    </td>
                                    <td width="68%" valign="middle" height="15px" colspan="2">
                                        <asp:Label ID="lblinventorymesg2" runat="server" Text="Post your Inventories in the given form"
                                            Style="font-size: small; font-weight: 700" meta:resourcekey="lbloffermesg2Resource1"></asp:Label>
                                    </td>
                                    <td width="21%">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="1%" valign="middle">
                                        <img id="img1" runat="server" src="Images/arrow_55.gif" align="middle" alt="arrow" />
                                    </td>
                                    <td width="24%" valign="middle">
                                        <asp:HyperLink ID="lnkAddInventory" runat="server" Text="Upload Inventory File" CssClass="blue_button_fu"
                                            ForeColor="White" Font-Underline="false" ToolTip="Upload your own document and mapped your columns and save your data. Easy & Simple to use."
                                            NavigateUrl="~/UploadRequest.aspx?RequestType=Inventory" meta:resourcekey="lnkAddInventoryResource1"></asp:HyperLink>
                                    </td>
                                    <td width="2%" valign="middle">
                                        <img id="img2" runat="server" src="Images/arrow_55.gif" align="middle" alt="arrow" />
                                    </td>
                                    <td width="70%" valign="middle">
                                        <asp:HyperLink ID="lnkBulkAddInventory" runat="server" Text="Add Inventories Manually"
                                            CssClass="blue_button_fu" ForeColor="White" Font-Underline="false" ToolTip="Add fix amount of Inventories just like excel sheet."
                                            NavigateUrl="~/UploadBulkInventory.aspx" meta:resourcekey="lnkBulkAddInventoryResource1"></asp:HyperLink>
                                    </td>
                                    <td width="5%">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td colspan="2">
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
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%" cellspacing="2" cellpadding="2">
                    <tr>
                        <td>
                            <table align="left" width="100%" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left" valign="top">
                                        <div class="headerback" style="padding-left: 5px">
                                            <asp:Label ID="lblgridheder" runat="server" CssClass="header" Font-Bold="True" Text="Edit/Modify your earlier posted Inventories"
                                                meta:resourcekey="lblgridhederResource1"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td colspan="8" class="headerback">
                                        <span style="color: Red">*</span>
                                        <asp:Label ID="lbloffermesg3" runat="server" Text="fields are mandatory.  Note: Do not leave any space while entering part numbers."
                                            Style="font-size: medium; font-weight: 700" meta:resourcekey="lbloffermesg3Resource1"></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        <div class="grid">
                                            <asp:UpdatePanel ID="Updatepanel1" runat="server">
                                                <ContentTemplate>
                                                    <table width="100%" cellpadding="2" cellspacing="0">
                                                        <tr class="headerback">
                                                            <td valign="top">
                                                                <asp:Panel ID="pnlFilter" DefaultButton="imgSearchFromGrid" runat="server" meta:resourcekey="pnlFilterResource1">
                                                                    <table width="100%" cellspacing="0" cellpadding="0" style="height: 35px">
                                                                        <tr>
                                                                            <td valign="middle" align="left" class="style1">
                                                                                <asp:Label ID="lblFilter" runat="server" Text="Filter With:" CssClass="text" meta:resourcekey="lblFilterResource1"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="middle" class="style2">
                                                                                <asp:DropDownList ID="ddlInventoryGridColumns" runat="server" Width="130px" AutoPostBack="True"
                                                                                    CssClass="smallinput_t200" OnSelectedIndexChanged="ddlInventoryGridColumns_SelectedIndexChanged"
                                                                                    meta:resourcekey="ddlInventoryGridColumnsResource1">
                                                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Part Number" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Make" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="Quantity" Value="3"></asp:ListItem>
                                                                                    <%--<asp:ListItem Text="Status" Value="4"></asp:ListItem>--%>
                                                                                    <%--<asp:ListItem Text="Country" Value="5"></asp:ListItem>--%>
                                                                                    <asp:ListItem Text="Stock Status" Value="5"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td width="10%" valign="middle" align="right">
                                                                                <asp:Label ID="lblSearch" runat="server" Text="Search:" CssClass="text" meta:resourcekey="lblSearchResource1"></asp:Label>
                                                                            </td>
                                                                            <td align="left" width="10%" valign="middle">
                                                                                <asp:TextBox ID="txtSearchFromGrid" runat="server" CssClass="smallinput_t" Width="126px"
                                                                                    meta:resourcekey="txtSearchFromGridResource1"></asp:TextBox>
                                                                                <asp:DropDownList ID="ddlstatus" runat="server" Width="130px" Visible="False" AutoPostBack="True"
                                                                                    CssClass="smallinput_t200" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged"
                                                                                    meta:resourcekey="ddlstatusResource1">
                                                                                    <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Open" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Closed" Value="0"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:DropDownList ID="ddlstockstatus" runat="server" Width="130px" Visible="False"
                                                                                    AutoPostBack="True" CssClass="smallinput_t200" OnSelectedIndexChanged="ddlstockstatus_SelectedIndexChanged"
                                                                                    meta:resourcekey="ddlstockstatusResource1">
                                                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="AVAILABLE" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="IN-HOUSE" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="OEM-EXCESS" Value="3"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td width="3%" align="right" valign="middle">
                                                                                <asp:ImageButton ID="imgSearchFromGrid" runat="server" ImageUrl="~/Images/search_button.png"
                                                                                    ToolTip="Search" OnClick="imgSearchFromGrid_Click" meta:resourcekey="imgSearchFromGridResource1" />
                                                                            </td>
                                                                            <td width="5%" align="left" valign="middle">
                                                                                <asp:ImageButton ID="imgClearSearchSelection" runat="server" ImageUrl="~/Images/clear_btn.png"
                                                                                    CausesValidation="False" ToolTip="Clear Search" OnClick="imgClearSearchSelection_Click"
                                                                                    meta:resourcekey="imgClearSearchSelectionResource1" />
                                                                            </td>
                                                                            <td width="18%" align="left" valign="middle">
                                                                                <asp:Label ID="lblmsg" runat="server" CssClass="redmsg" Visible="False" meta:resourcekey="lblmsgResource1"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr class="headerback">
                                                            <td>
                                                                <asp:Button ID="btnDelInventories" runat="server" Text="Delete" ValidationGroup="deleteConfirmation"
                                                                    CssClass="blue_button_fu" OnClick="btnDelInventories_Click" meta:resourcekey="btnDelInventoriesResource1" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%">
                                                                <div>
                                                                    <asp:GridView ID="grdInventoryDetails" runat="server" AutoGenerateColumns="False"
                                                                        PageSize="20" CellPadding="0" ClientIDMode="Static" AllowSorting="True" DataKeyNames="ComponentId"
                                                                        AllowPaging="True" Width="100%" OnRowEditing="grdInventoryDetails_RowEditing"
                                                                        OnRowUpdating="grdInventoryDetails_RowUpdating" OnRowCancelingEdit="grdInventoryDetails_RowCancelingEdit"
                                                                        OnRowUpdated="grdInventoryDetails_RowUpdated" OnRowDeleting="grdInventoryDetails_RowDeleting"
                                                                        OnPageIndexChanging="grdInventoryDetails_PageIndexChanging" OnRowDataBound="grdInventoryDetails_RowDataBound"
                                                                        meta:resourcekey="grdInventoryDetailsResource1" CssClass="table-border">
                                                                        <Columns>
                                                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                                                                <HeaderTemplate>
                                                                                    <input type="checkbox" id="chkBoxAll" runat="server" onclick="checkAllBoxes();" />
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkbx" runat="server" meta:resourcekey="chkbxResource1" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="3%" HorizontalAlign="Left" />
                                                                            </asp:TemplateField>
                                                                            <%--<asp:TemplateField HeaderText="Status" meta:resourcekey="TemplateFieldResource2">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status") %>'
                                                                                                                meta:resourcekey="lblStatusResource1"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <EditItemTemplate>
                                                                                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="smallinput_t200" meta:resourcekey="ddlStatusResource2">
                                                                                                                <asp:ListItem Text="Closed" Value="0" meta:resourcekey="ListItemResource15"></asp:ListItem>
                                                                                                                <asp:ListItem Text="Open" Value="1" meta:resourcekey="ListItemResource16"></asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </EditItemTemplate>
                                                                                                        <ItemStyle Width="5%" HorizontalAlign="Left" />
                                                                                                        <ControlStyle Width="99%"></ControlStyle>
                                                                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                    </asp:TemplateField>--%>
                                                                            <asp:TemplateField ShowHeader="False" Visible="False" meta:resourcekey="TemplateFieldResource3">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="LblComponentId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentId") %>'
                                                                                        Visible="False" meta:resourcekey="LblComponentIdResource1"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Part #" meta:resourcekey="TemplateFieldResource19">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="LblComponentname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentName") %>'
                                                                                        meta:resourcekey="LblComponentnameResource1"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="8%" HorizontalAlign="Left" />
                                                                                <ControlStyle Width="99%"></ControlStyle>
                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Qty" meta:resourcekey="TemplateFieldResource20">
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
                                                                                        ForeColor="Red" ErrorMessage="Enter Numeric data." ValidationGroup="gridvalidation"
                                                                                        ValidationExpression="^(\s*)\d+(\s*)$" Display="Dynamic" meta:resourcekey="revtxtQntityResource1"></asp:RegularExpressionValidator>
                                                                                </EditItemTemplate>
                                                                                <ItemStyle Width="8%" HorizontalAlign="Left" />
                                                                                <ControlStyle Width="99%"></ControlStyle>
                                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Stock Status" meta:resourcekey="TemplateFieldResource13">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblStkstatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StockStatus") %>'
                                                                                        meta:resourcekey="lblStkstatusResource1"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="8%" HorizontalAlign="Left" />
                                                                                <ControlStyle Width="99%"></ControlStyle>
                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            </asp:TemplateField>
                                                                            <%--<asp:TemplateField HeaderText="Stock In Hand" meta:resourcekey="TemplateFieldResource6">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblStockInHand" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StockInHand") %>'
                                                                                                                meta:resourcekey="lblStockInHandResource1"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <EditItemTemplate>
                                                                                                            <asp:TextBox ID="txtStockInHand" runat="server" Text='<%# Eval("StockInHand") %>'
                                                                                                                Width="8%" CssClass="smallinput_t" meta:resourcekey="txtStockInHandResource1"></asp:TextBox>
                                                                                                            <asp:RegularExpressionValidator ID="revtxtStockInHand" runat="server" ControlToValidate="txtStockInHand"
                                                                                                                ForeColor="Red" ErrorMessage="Enter Numeric data !" ValidationGroup="gridvalidation"
                                                                                                                ValidationExpression="^\d+$" Display="Dynamic" meta:resourcekey="revtxtStockInHandResource1"></asp:RegularExpressionValidator>
                                                                                                        </EditItemTemplate>
                                                                                                        <ItemStyle Width="8%" HorizontalAlign="Center" />
                                                                                                        <ControlStyle Width="99%"></ControlStyle>
                                                                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                    </asp:TemplateField>--%>
                                                                            <asp:TemplateField HeaderText="Make" meta:resourcekey="TemplateFieldResource7">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="LblBrandName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Brandname") %>'
                                                                                        meta:resourcekey="LblBrandNameResource1"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtBrandName" CssClass="smallinput_t" runat="server" Text='<%# Eval("Brandname") %>'
                                                                                        MaxLength="50" meta:resourcekey="txtBrandNameResource1"></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <ItemStyle Width="8%" HorizontalAlign="Left" />
                                                                                <ControlStyle Width="99%"></ControlStyle>
                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Date Code" meta:resourcekey="TemplateFieldResource21">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbldatecode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateCode") %>'
                                                                                        meta:resourcekey="lbldatecodeResource1"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtdateCode" CssClass="smallinput_t" runat="server" Text='<%# Eval("DateCode") %>'
                                                                                        MaxLength="50" meta:resourcekey="txtdateCodeResource1"></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <ItemStyle Width="8%" HorizontalAlign="Left" />
                                                                                <ControlStyle Width="99%"></ControlStyle>
                                                                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Package" meta:resourcekey="TemplateFieldResource9">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblpackage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Package") %>'
                                                                                        meta:resourcekey="lblpackageResource1"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtpackage" CssClass="smallinput_t" runat="server" Text='<%# Eval("Package") %>'
                                                                                        MaxLength="50" meta:resourcekey="txtpackageResource1"></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <ItemStyle Width="8%" HorizontalAlign="Left" />
                                                                                <ControlStyle Width="99%"></ControlStyle>
                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Comment" meta:resourcekey="TemplateFieldResource22">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>'
                                                                                        CssClass="smallinput_t"></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <ItemStyle Width="9%" HorizontalAlign="Left" />
                                                                                <ControlStyle Width="99%"></ControlStyle>
                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            </asp:TemplateField>
                                                                            <%--<asp:TemplateField HeaderText="Price In INR" meta:resourcekey="TemplateFieldResource10">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblINR" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PriceInINR") %>'
                                                                                                                meta:resourcekey="lblINRResource1"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <EditItemTemplate>
                                                                                                            <asp:TextBox ID="txtprinINR" CssClass="smallinput_t" runat="server" Text='<%# Eval("PriceInINR") %>'
                                                                                                                MaxLength="50" meta:resourcekey="txtprinINRResource1"></asp:TextBox>
                                                                                                            <asp:RegularExpressionValidator ID="revpriceinr" ControlToValidate="txtprinINR" ForeColor="Red"
                                                                                                                ValidationGroup="gridvalidation" runat="server" ErrorMessage="Enter Numeric data"
                                                                                                                ValidationExpression="[0-9]*\.?[0-9]*" Text="Enter only Numeric data" meta:resourcekey="revpriceinrResource1"></asp:RegularExpressionValidator>
                                                                                                        </EditItemTemplate>
                                                                                                        <ItemStyle Width="8%" HorizontalAlign="Center" />
                                                                                                        <ControlStyle Width="99%"></ControlStyle>
                                                                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                    </asp:TemplateField>--%>
                                                                            <asp:TemplateField HeaderText="Unit price in IRs" meta:resourcekey="TemplateFieldResource23">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblUSD" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PriceInUSD") %>'
                                                                                        meta:resourcekey="lblUSDResource1"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtprinUSD" CssClass="smallinput_t" runat="server" Text='<%# Eval("PriceInUSD") %>'
                                                                                        MaxLength="50" meta:resourcekey="txtprinUSDResource1"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="revpriceusd" ControlToValidate="txtprinUSD" ValidationGroup="gridvalidation"
                                                                                        runat="server" ErrorMessage="Invalid Number" ForeColor="Red" ValidationExpression="^\d{0,9}(\.\d{1,3})?$"
                                                                                        Display="Dynamic" Text="Enter only Numeric data" meta:resourcekey="revpriceusdResource1"></asp:RegularExpressionValidator>
                                                                                </EditItemTemplate>
                                                                                <ItemStyle Width="8%" HorizontalAlign="Left" />
                                                                                <ControlStyle Width="99%"></ControlStyle>
                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            </asp:TemplateField>
                                                                            <%--<asp:TemplateField HeaderText="Price in CNY" meta:resourcekey="TemplateFieldResource12">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblprinCNY" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PriceInCNY") %>'
                                                                                                                meta:resourcekey="lblprinCNYResource1"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <EditItemTemplate>
                                                                                                            <asp:TextBox ID="txtprinCNY" CssClass="smallinput_t" runat="server" Text='<%# Eval("PriceInCNY") %>'
                                                                                                                MaxLength="50" meta:resourcekey="txtprinCNYResource1"></asp:TextBox>
                                                                                                            <asp:RegularExpressionValidator ID="revpricecny" ControlToValidate="txtprinCNY" ValidationGroup="gridvalidation"
                                                                                                                runat="server" ErrorMessage="Invalid Number" ForeColor="Red" ValidationExpression="[0-9]*\.?[0-9]*"
                                                                                                                Text="Enter only Numeric data" meta:resourcekey="revpricecnyResource1"></asp:RegularExpressionValidator>
                                                                                                        </EditItemTemplate>
                                                                                                        <ItemStyle Width="8%" HorizontalAlign="Center" />
                                                                                                        <ControlStyle Width="99%"></ControlStyle>
                                                                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                    </asp:TemplateField>--%>
                                                                            <%--<asp:TemplateField HeaderText="Country" meta:resourcekey="TemplateFieldResource14">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblcounty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Country") %>'
                                                                                                                meta:resourcekey="lblcountyResource1"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <EditItemTemplate>
                                                                                                            <asp:Label ID="lblcountry" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "Country") %>'
                                                                                                                meta:resourcekey="lblcountryResource1"></asp:Label>
                                                                                                            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="smallinput_t200" meta:resourcekey="ddlCountryResource1">
                                                                                                                <asp:ListItem Text="--Select--" Value="0" meta:resourcekey="ListItemResource17"></asp:ListItem>
                                                                                                                <asp:ListItem Text="INDIA" Value="1" meta:resourcekey="ListItemResource18"></asp:ListItem>
                                                                                                                <asp:ListItem Text="CHINA" Value="2" meta:resourcekey="ListItemResource19"></asp:ListItem>
                                                                                                                <asp:ListItem Text="USA" Value="3" meta:resourcekey="ListItemResource20"></asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </EditItemTemplate>
                                                                                                        <ItemStyle Width="8%" HorizontalAlign="Center" />
                                                                                                        <ControlStyle Width="99%"></ControlStyle>
                                                                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                    </asp:TemplateField>--%>
                                                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource15">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton runat="server" ID="imgbtnEdit" ToolTip="Edit" ImageUrl="~/Images/edit_btn.png"
                                                                                        CausesValidation="False" CommandName="Edit" meta:resourcekey="imgbtnEditResource1" />
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:ImageButton runat="server" ID="imgbtnEdit" ToolTip="Update" ImageUrl="~/Images/save_btn.png"
                                                                                        ValidationGroup="gridvalidation" CommandName="Update" meta:resourcekey="imgbtnEditResource2" />
                                                                                </EditItemTemplate>
                                                                                <ItemStyle Width="1%" HorizontalAlign="Left" />
                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource16">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton runat="server" ID="imgbtnDelete" ImageUrl="~/Images/deletet_btn.png"
                                                                                        CommandName="Delete" ToolTip="Delete" ValidationGroup="deleteConfirmation" meta:resourcekey="imgbtnDeleteResource1" />
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:ImageButton runat="server" ID="imgbtnCancel" ImageUrl="~/Images/cancel_btn.png"
                                                                                        CausesValidation="False" CommandName="Cancel" ToolTip="Cancel" meta:resourcekey="imgbtnCancelResource1" />
                                                                                </EditItemTemplate>
                                                                                <ItemStyle Width="1%" HorizontalAlign="Left" />
                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
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
                                                                        <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                                                        <PagerStyle CssClass="headerback" HorizontalAlign="Center" />
                                                                        <RowStyle CssClass="odd" />
                                                                    </asp:GridView>
                                                                    <asp:CustomValidator ID="CustomValidator1" ClientValidationFunction="confirmDelete"
                                                                        ValidationGroup="deleteConfirmation" runat="server" meta:resourcekey="CustomValidator1Resource1"></asp:CustomValidator>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlInventoryGridColumns" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
