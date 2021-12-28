<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master"
    AutoEventWireup="true" CodeBehind="UserOffers.aspx.cs" Inherits="ICBrowser.Web.UserOffers"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

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
            var totalChkBoxes = parseInt('<%= grvOffer.Rows.Count %>');
            var gvControl = document.getElementById('<%= grvOffer.ClientID %>');

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
        .style2
        {
            width: 5%;
        }
        .style3
        {
            width: 17%;
        }
        .style4
        {
            width: 8%;
        }
        .style5
        {
            width: 13%;
        }
        .newStyle1
        {
            color: #FF0000;
        }
        .newStyle2
        {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <%--  <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />--%>
    <div>
        <div id="Header">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                    </td>
                    <td colspan="8" height="30px" style="text-align:center;text-decoration:underline">
                        <asp:Label ID="lbloffermesg" runat="server" CssClass="header" Text="You can post offer/Change your offered parts here!"
                            Style="font-size: large; font-weight: 700" meta:resourcekey="lbloffermesgResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="1%" valign="middle">
                    </td>
                    <td width="24%" valign="middle" height="15px">
                        <asp:Label ID="lbloffermesg1" runat="server" Text=" Post your offer in file format"
                            Style="font-size: small; font-weight: 700" meta:resourcekey="lbloffermesg1Resource1"></asp:Label>
                    </td>
                    <td width="1%" valign="middle">
                    </td>
                    <td width="70%" valign="middle" height="15px">
                        <asp:Label ID="lbloffermesg2" runat="server" Text="Post your offer in the given form"
                            Style="font-size: small; font-weight: 700" meta:resourcekey="lbloffermesg2Resource1"></asp:Label>
                    </td>
                    <td width="21%">
                    </td>
                </tr>
                <tr>
                    <td width="1%" valign="middle">
                        <img id="img2" runat="server" src="Images/arrow_55.gif" alt="" />
                    </td>
                    <td width="24%" valign="middle" height="30px">
                        <asp:LinkButton ID="lnbAddOffers" runat="server" CausesValidation="False" Text="Upload Offer File"
                            CssClass="blue_button_fu" ForeColor="White" Font-Underline="false" OnClick="lnbAddOffers_Click"
                            ToolTip="Upload your own document and mapped your columns and save your data. Easy & Simple to use."
                            meta:resourcekey="lnbAddOffersResource1"></asp:LinkButton>
                    </td>
                    <td width="1%" valign="middle">
                        <img id="img3" runat="server" src="Images/arrow_55.gif" alt="" />
                    </td>
                    <td width="70%" valign="middle" height="30px">
                        <asp:LinkButton ID="lblBulkOfferUpload" runat="server" CausesValidation="False" Text="Add Offers Manually"
                            CssClass="blue_button_fu" ForeColor="White" Font-Underline="false" ToolTip="Add fix amount of Offers just like excel sheet."
                            OnClick="lblBulkOfferUpload_Click" meta:resourcekey="lblBulkOfferUploadResource1"></asp:LinkButton>
                    </td>
                    <td width="21%">
                    </td>
                </tr>
            </table>
        </div>
        <div id="GridHeader">
            <asp:UpdatePanel ID="Updatepanel1" runat="server">
                <ContentTemplate>
                    <div class="grid">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="top">
                                    <div class="headerback">
                                        <asp:Panel ID="pnlFilter" DefaultButton="imgSearchFromGrid" runat="server" meta:resourcekey="pnlFilterResource1">
                                            <table width="100%" cellspacing="0" cellpadding="5" style="height: 35px">
                                                <tr>
                                                    <td colspan="8">
                                                        <div class="">
                                                            <asp:Label ID="lblgridheder" runat="server" CssClass="header" Text="Edit/Modify your earlier posted offer"
                                                                Font-Bold="true" meta:resourcekey="lblgridhederResource1"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td colspan="8">
                                                        <span style="color: Red">*</span>
                                                        <asp:Label ID="lbloffermesg3" runat="server" Text="fields are mandatory.  Note: Do not leave any space while entering part numbers."
                                                            Style="font-size: medium; font-weight: 700" meta:resourcekey="lbloffermesg3Resource1"></asp:Label>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td valign="middle" align="left" class="style4">
                                                        <asp:Label ID="lblFilter" runat="server" Text="Filter With:" CssClass="text" ForeColor="Black"
                                                            meta:resourcekey="lblFilterResource1"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle" class="style3">
                                                        <asp:DropDownList ID="ddlInventoryGridColumns" runat="server" Width="130px" AutoPostBack="True"
                                                            CssClass="smallinput_t200" OnSelectedIndexChanged="ddlInventoryGridColumns_SelectedIndexChanged"
                                                            meta:resourcekey="ddlInventoryGridColumnsResource1">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Part Number" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Make" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Quantity" Value="3"></asp:ListItem>
                                                            <%--<asp:ListItem Text="Status" Value="4"></asp:ListItem>--%>
                                                            <asp:ListItem Text="Stock Status" Value="5"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td valign="middle" align="left" class="style2">
                                                        <asp:Label ID="lblSearch" runat="server" Text="Search:" CssClass="text" ForeColor="Black"
                                                            meta:resourcekey="lblSearchResource1"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle" style="width: 10%">
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
                                                    <td width="5%" align="left" valign="middle">
                                                        <asp:ImageButton ID="imgSearchFromGrid" runat="server" ImageUrl="~/Images/search_button.png"
                                                            ToolTip="Search" OnClick="imgSearchFromGrid_Click" meta:resourcekey="imgSearchFromGridResource1" />
                                                    </td>
                                                    <td width="5%" align="left" valign="middle">
                                                        <asp:ImageButton ID="imgClearSearchSelection" runat="server" ImageUrl="~/Images/clear_btn.png"
                                                            CausesValidation="False" ToolTip="Clear Search" OnClick="imgClearSearchSelection_Click"
                                                            meta:resourcekey="imgClearSearchSelectionResource1" />
                                                    </td>
                                                    <td align="left" width="18%" valign="middle">
                                                        <asp:Label ID="lblmsg" runat="server" CssClass="redmsg" Visible="False" meta:resourcekey="lblmsgResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style4">
                                                        <asp:Button ID="btnDel" runat="server" Text="Delete" CssClass="blue_button_fu" OnClick="btnDel_Click"
                                                            ValidationGroup="deleteConfirmation" meta:resourcekey="btnDelResource1" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:GridView ID="grvOffer" runat="server" AutoGenerateColumns="False" PageSize="20"
                                        CellPadding="0" ClientIDMode="Static" AllowSorting="True" AllowPaging="True"
                                        DataKeyNames="OfferId" Width="100%" OnRowCancelingEdit="grvOffer_RowCancelingEdit"
                                        OnRowDeleting="grvOffer_RowDeleting" OnRowEditing="grvOffer_RowEditing" OnRowUpdating="grvOffer_RowUpdating"
                                        OnPageIndexChanging="grvOffer_PageIndexChanging" OnRowDataBound="grvOffer_RowDataBound"
                                        CssClass="table-border" meta:resourcekey="grvOfferResource1">
                                        <Columns>
                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                                                <HeaderTemplate>
                                                    <input type="checkbox" id="chkBoxAll" runat="server" onclick="checkAllBoxes();" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkbx" runat="server" meta:resourcekey="chkbxResource1" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                <ControlStyle Width="100%"></ControlStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False" Visible="False" meta:resourcekey="TemplateFieldResource1">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblOfferId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OfferId") %>'
                                                        Visible="False" meta:resourcekey="LblOfferIdResource1"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                                                <ControlStyle Width="99%"></ControlStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Part #" meta:resourcekey="TemplateFieldResource20">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblComponentname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentName") %>'
                                                        meta:resourcekey="LblComponentnameResource1"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="LblComponentname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentName") %>'
                                                        meta:resourcekey="LblComponentnameResource2"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="6%" />
                                                <ControlStyle Width="99%"></ControlStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty" meta:resourcekey="TemplateFieldResource21">
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
                                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                                                <ControlStyle Width="99%"></ControlStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Stock Status" meta:resourcekey="TemplateFieldResource13">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStkstatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StockStatus") %>'
                                                        meta:resourcekey="lblStkstatusResource1"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                <ControlStyle Width="99%"></ControlStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Make" meta:resourcekey="TemplateFieldResource6">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblBrandName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Brandname") %>'
                                                        meta:resourcekey="LblBrandNameResource1"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtBrandName" CssClass="smallinput_t" runat="server" Text='<%# Eval("Brandname") %>'
                                                        MaxLength="50" meta:resourcekey="txtBrandNameResource1"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="7%" HorizontalAlign="Left" />
                                                <ControlStyle Width="99%"></ControlStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date Code" meta:resourcekey="TemplateFieldResource22">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldatecode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateCode") %>'
                                                        meta:resourcekey="lbldatecodeResource1"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtdateCode" CssClass="smallinput_t" runat="server" Text='<%# Eval("DateCode") %>'
                                                        MaxLength="50" meta:resourcekey="txtdateCodeResource1"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="7%" HorizontalAlign="Left" />
                                                <ControlStyle Width="99%"></ControlStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Package" meta:resourcekey="TemplateFieldResource8">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpackage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Package") %>'
                                                        meta:resourcekey="lblpackageResource1"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtpackage" CssClass="smallinput_t" runat="server" Text='<%# Eval("Package") %>'
                                                        MaxLength="50" meta:resourcekey="txtpackageResource1"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                                                <ControlStyle Width="99%"></ControlStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comment" meta:resourcekey="TemplateFieldResource23">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'
                                                        meta:resourcekey="lblDescriptionResource1"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>'
                                                        CssClass="smallinput_t" meta:resourcekey="txtDescriptionResource1"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="8%" HorizontalAlign="Left" />
                                                <ControlStyle Width="99%"></ControlStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit price in IRs" meta:resourcekey="TemplateFieldResource24">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUSD" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PriceInUSD") %>'
                                                        meta:resourcekey="lblUSDResource1"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtprinUSD" CssClass="smallinput_t" runat="server" Text='<%# Eval("PriceInUSD") %>'
                                                        MaxLength="50" meta:resourcekey="txtprinUSDResource1"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="revpriceusd" ControlToValidate="txtprinUSD" ValidationGroup="gridvalidation"
                                                        runat="server" ErrorMessage="Invalid Number" ForeColor="Red" ValidationExpression="^\d{0,9}(\.\d{1,3})?$"
                                                        Display="Dynamic" Text="Enter Numeric Value Upto 3 decimals." meta:resourcekey="revpriceusdResource1"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                                <ItemStyle Width="8%" HorizontalAlign="Left" />
                                                <ControlStyle Width="99%"></ControlStyle>
                                            </asp:TemplateField>
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
                                        <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <PagerStyle CssClass="headerback" HorizontalAlign="Center" />
                                        <RowStyle CssClass="odd" />
                                    </asp:GridView>
                                    <asp:CustomValidator ID="CustomValidator1" ClientValidationFunction="confirmDelete"
                                        ValidationGroup="deleteConfirmation" runat="server" meta:resourcekey="CustomValidator1Resource1"></asp:CustomValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlInventoryGridColumns" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
