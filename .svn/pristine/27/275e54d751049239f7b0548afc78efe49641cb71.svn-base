<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master"
    AutoEventWireup="true" CodeBehind="ComponentSearchFiltered.aspx.cs" Inherits="ICBrowser.Web.ComponentSearchFiltered"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ MasterType VirtualPath="~/Detail.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 7%;
        }
        .style2
        {
            width: 8%;
        }
        .style3
        {
            width: 9%;
        }
        #navigation
        {
            background: #AFD5E0 url("/Images/bg-nav.gif") repeat-x;
            border: 1px solid #979797;
            border-width: 1px 0;
            font-size: 1.1em;
            margin-top: 0px;
            padding-top: .6em;
        }
        
        #navigation ul, #navigation ul li
        {
            list-style: none;
            margin: 0;
            padding: 0;
            font-family: Calibri;
        }
        
        #navigation ul
        {
            padding-left: 2px;
            text-align: left;
        }
        
        #navigation ul li
        {
            display: inline;
            margin-right: 2px;
            line-height: 28px;
        }
        
        #navigation ul li.last
        {
            margin-right: 0;
        }
        
        #navigation ul li span
        {
            background: url("/Images/tab-right.gif") no-repeat 100% 0;
            color: #06C;
            padding: 5px 0;
        }
        
        #navigation ul li span a
        {
            background: url("/Images/tab-left.gif") no-repeat;
            padding: 5px 1em;
            text-decoration: none;
        }
        
        #navigation ul li a:hover
        {
            color: #69C;
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="chart_bg">
        <div>
            <div class="formBackgorund" style="width: 70%">
                <table id="filterParameters" width="100%" cellpadding="3">
                    <tr>
                        <td colspan="6" class="headerback">
                            <asp:Label ID="lblRequirementHeader" runat="server" Text="Search components from Requirement/PO database"
                                class="header"></asp:Label>
                            <asp:Label ID="lblComponentHeader" runat="server" Text=" Search components from Offer/Inventory database"
                                class="header"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #B3CFE2;" colspan="6">
                            <asp:Label ID="lblMultiplePartSearchInstrcution" runat="server" Text="For multiple parts search, use 'Enter' to separate the each items."></asp:Label>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td width="6%" align="right" valign="top" rowspan="4">
                            <asp:Label ID="lblPartNumber" runat="server" Text="Part #:" meta:resourcekey="lblPartNumberResource1"></asp:Label>
                        </td>
                        <td width="35%" rowspan="4">
                            <asp:TextBox ID="txtPartNumber" runat="server" TextMode="MultiLine" Width="100%"
                                Height="140" Font-Names="Calibri" Font-Size="12pt"></asp:TextBox>
                        </td>
                        <td width="10%" align="right" valign="top">
                            <asp:Label ID="lblQuantity" runat="server" Text="Quantity" meta:resourcekey="lblQuantityResource1"></asp:Label>
                        </td>
                        <%--  
                       
                        
                    </td>--%>
                        <td width="20%" valign="top" align="left">
                            <asp:TextBox ID="txtQuantity" runat="server" meta:resourcekey="txtQuantityResource1"
                                CssClass="smallinput_t" Width="100px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revtxtQuantity" runat="server" ValidationGroup="VgOne"
                                ErrorMessage="Enter Numeric Value" ForeColor="Red" ControlToValidate="txtQuantity"
                                ValidationExpression="^(\s*)\d+(\s*)$" meta:resourcekey="revtxtQuantityResource1"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                        <td align="right" valign="top" class="style3" width="19">
                            <asp:Label ID="lblMake" runat="server" Text="Make" meta:resourcekey="lblMakeResource1"></asp:Label>
                        </td>
                        <td valign="top" align="left" class="style1" width="10%">
                            <asp:TextBox ID="txtMake" runat="server" meta:resourcekey="txtMakeResource1" CssClass="smallinput_t"
                                Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            <asp:Label ID="lblPackage" runat="server" Text="Package" meta:resourcekey="lblPackageResource1"></asp:Label>
                        </td>
                        <td valign="top" align="left">
                            <asp:TextBox ID="txtPackage" runat="server" meta:resourcekey="txtPackageResource1"
                                CssClass="smallinput_t" Width="100px"></asp:TextBox>
                        </td>
                        <td align="right" valign="top" class="style3">
                            <asp:Label ID="lblLastUpdate" runat="server" Text="Search From:"></asp:Label>
                        </td>
                        <td valign="top" align="left">
                            <asp:DropDownList ID="ddlLastUpdate" runat="server" CssClass="smallinput_t100">
                                <asp:ListItem Text="All" Selected="True" Value="all"></asp:ListItem>
                                <asp:ListItem Text="1 week" Value="1_week"></asp:ListItem>
                                <asp:ListItem Text="2 week" Value="2_week"></asp:ListItem>
                                <asp:ListItem Text="1 month" Value="1_month"></asp:ListItem>
                                <asp:ListItem Text="3 month" Value="3_month"></asp:ListItem>
                                <asp:ListItem Text="Archived" Value="archived"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            <asp:Label ID="lblDateCode" runat="server" Text="Date Code" meta:resourcekey="lblDateCodeResource1"></asp:Label>
                        </td>
                        <td valign="top" align="left">
                            <asp:TextBox ID="txtDateCode" runat="server" meta:resourcekey="txtDateCodeResource1"
                                CssClass="smallinput_t" Width="100px"></asp:TextBox>
                        </td>
                        <td class="style3">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <asp:Panel ID="pnlStockStatus" runat="server" Visible="false" meta:resourcekey="pnlStockStatusResource1">
                            <td valign="middle" align="right">
                                <asp:Label ID="lblStockStatus" runat="server" Text="Stock Status:" meta:resourcekey="lblStockStatusResource1"></asp:Label>
                            </td>
                            <td style="vertical-align: top" colspan="3" align="left">
                                <asp:CheckBoxList ID="cblStockStatus" runat="server" RepeatDirection="Horizontal"
                                    Style="vertical-align: middle; position: relative; top: 1px; width: 70%" CellPadding="-1">
                                    <asp:ListItem Text="Available" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="In House" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="OEM Excess" Value="3"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </asp:Panel>
                        <asp:Panel ID="pnlPO" runat="server" Visible="false" meta:resourcekey="pnlPOResource1">
                            <td align="right">
                                <asp:Label ID="lblWithPO" runat="server" Text="Requirement Status:" meta:resourceKey="lblWithPOResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList align="middle" ID="ddlWithPO" runat="server" meta:resourceKey="ddlWithPOResource1"
                                    CssClass="smallinput_t100">
                                    <asp:ListItem Text="Any" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="PO" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="RFQ" Value="0"></asp:ListItem>                                    
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </asp:Panel>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <table align="left">
                                <tr>
                                    <td align="left">
                                        <asp:CheckBox ID="cbxExactMatch" runat="server" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblExactMatch" runat="server" Text="Exact Match" meta:resourcekey="lblExactMatchResource1"
                                            Style="float: left"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="blue_button" meta:resourcekey="btnSubmitResource1"
                                            OnClick="btnSubmit_Click" Text="Search" ValidationGroup="VgOne" Width="50px" />
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="Button1" Text="Clear" OnClick="btnClear_Click" meta:resourcekey="btnClearResource1"
                                            CssClass="blue_button" Width="50px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                        </td>
                        <td colspan="5" align="left">
                            <table cellpadding="0" cellspacing="0" class="ui-accordion" style="text-align: left">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div>
        <div>
            <asp:Label ID="lblPartMsg" runat="server" Visible="false" Text="Click on individual parts for search results."
                Style="font-weight: 700" meta:resourcekey="lblPartMsgResource1"></asp:Label>
            <asp:Repeater ID="rptSearchResult" runat="server" OnItemDataBound="rptSearchResult_ItemDataBound">
                <HeaderTemplate>
                    <div id="navigation">
                        <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><span>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnSearchString_OnClick">LinkButton</asp:LinkButton>
                    </span></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul> </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div id="grid">
            <asp:GridView ID="grdComponentSearchFilterResults" runat="server" AutoGenerateColumns="False"
                AlternatingRowStyle-CssClass="even" RowStyle-CssClass="odd" AllowPaging="True"
                GridLines="Horizontal" Font-Names="Arial" Width="100%" PageSize="24" OnRowDataBound="grdComponentSearchFilterResults_RowDataBound"
                meta:resourcekey="grdComponentSearchFilterResultsResource1" OnPageIndexChanging="grdComponentSearchFilterResults_PageIndexChanging"
                Visible="False" OnRowCommand="grdComponentSearchFilterResults_RowCommand" CssClass="table-border">
                <Columns>
                    <asp:TemplateField HeaderText="User Id" SortExpression="UserId" Visible="false" meta:resourcekey="TemplateFieldResource9">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSellerId" runat="server" Text='<%# Bind("UserId") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Part #" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource40">
                        <HeaderStyle Width="15%" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkComponentName" runat="server" CommandName="Select" Text='<%# Bind("ComponentName") %>'></asp:LinkButton>
                            <asp:HyperLink ID="hlComponentName" Text='<%# Bind("ComponentName") %>' runat="server"
                                ToolTip="Click to view Datasheet" ImageUrl="~/Images/pdf.png" NavigateUrl='<%# Eval("ComponentName", "http://www.alldatasheet.com/view.jsp?Searchword={0}") %>'
                                Target="_blank"></asp:HyperLink>
                            <asp:Image ID="imgOffer" runat="server" ImageUrl="Images/hot.gif" Style="vertical-align: top"
                                Visible="False" />
                            <asp:Label ID="lblArchev" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem,"Archev") %>'></asp:Label>
                        </ItemTemplate>
                        <%--<ItemStyle Width="18%" />--%>
                        <%--<ControlStyle Width="99%"></ControlStyle>--%>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource41">
                        <HeaderStyle Width="8%" />
                        <ItemTemplate>
                            <asp:Label ID="LblQuantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Make" meta:resourcekey="TemplateFieldResource3" HeaderStyle-CssClass="search-th">
                        <HeaderStyle Width="8%" />
                        <ItemTemplate>
                            <asp:Label ID="LblBrandName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Brandname") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="Stock In Hand" meta:resourcekey="TemplateFieldResource4"
                        HeaderStyle-CssClass="search-th">
                        <ItemTemplate>
                            <asp:Label ID="lblStockInHand" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StockInHand") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Comment" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource42">
                        <HeaderStyle Width="15%" />
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit price in IRs" HeaderStyle-CssClass="search-th">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <asp:Label ID="lblPriceInUSD" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PriceInUSD") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company Name" meta:resourcekey="TemplateFieldResource9"
                        HeaderStyle-CssClass="search-th">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%-- <asp:Label ID="lblCompanyName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CompanyName") %>'></asp:Label>--%>
                            <asp:HyperLink ID="hlBuyerName" runat="server" Text='<%# Bind("CompanyName") %>'
                                NavigateUrl='<%# Eval("userId", "~/NewUserProfile.aspx?UserId={0}") %>' Target="_blank"></asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DateCode" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource45">
                        <HeaderStyle Width="8%" />
                        <ItemTemplate>
                            <asp:Label ID="lblDateCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "datecode") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Package" meta:resourcekey="TemplateFieldResource11"
                        HeaderStyle-CssClass="search-th">
                        <HeaderStyle Width="8%" />
                        <ItemTemplate>
                            <asp:Label ID="lblPackage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "package") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Stock Status" meta:resourcekey="TemplateFieldResource12"
                        HeaderStyle-CssClass="search-th">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <asp:Label ID="lblStockStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "stockstatus") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Country" meta:resourcekey="TemplateFieldResource13"
                        HeaderStyle-CssClass="search-th">
                        <ItemTemplate>
                            <asp:Label ID="lblCountry" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "country") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Posted On" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource44">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <asp:Label ID="lblLastUpdated" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CreatedOn","{0:dd-MMM-yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IsOffer" Visible="false" meta:resourcekey="TemplateFieldResource14">
                        <ItemTemplate>
                            <asp:Label ID="lblIsOffer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IsOffer") %>'
                                Visible="False"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <RowStyle CssClass="odd"></RowStyle>
                <PagerStyle BackColor="#E0ECF8" ForeColor="Black" HorizontalAlign="Center" />
                <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
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
            </asp:GridView>
        </div>
        <div id="grid1">
            <asp:GridView ID="grdRequirementSearchFilterResults" runat="server" AutoGenerateColumns="False"
                AlternatingRowStyle-CssClass="even" RowStyle-CssClass="odd" AllowPaging="True"
                OnRowCommand="grdRequirementSearchFilterResults_RowCommand" GridLines="Horizontal"
                Font-Names="Arial" Width="100%" PageSize="24" OnRowDataBound="grdRequirementSearchFilterResults_RowDataBound"
                meta:resourcekey="grdRequirementSearchFilterResultsResource1" OnPageIndexChanging="grdRequirementSearchFilterResults_PageIndexChanging"
                Visible="False">
                <Columns>
                    <asp:TemplateField HeaderText="User Id" SortExpression="UserId" Visible="false" meta:resourcekey="TemplateFieldResource9">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSellerId" runat="server" Text='<%# Bind("UserId") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Part #" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource30">
                        <HeaderStyle Width="15%" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkComponentName" runat="server" CommandName="Select" Text='<%# Bind("ComponentName") %>'></asp:LinkButton>
                            <%--  <asp:Label ID="LblComponentname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentName") %>'
                                meta:resourcekey="LblComponentnameResource1"></asp:Label>--%>
                            <%-- <asp:HyperLink ID="hlCompName" Text='<%# Bind("ComponentName") %>' runat="server"
                                ToolTip="Click to view Datasheet" ImageUrl="~/Images/pdf.png" NavigateUrl='<%# Eval("ComponentName", "http://www.alldatasheet.com/view.jsp?Searchword={0}") %>'
                                Target="_blank"></asp:HyperLink>--%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qty" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource31">
                        <HeaderStyle Width="8%" />
                        <ItemTemplate>
                            <asp:Label ID="LblQuantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Make" meta:resourcekey="TemplateFieldResource16" HeaderStyle-CssClass="search-th">
                        <HeaderStyle Width="8%" />
                        <ItemTemplate>
                            <asp:Label ID="LblBrandName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Brandname") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company Name" meta:resourcekey="TemplateFieldResource17"
                        HeaderStyle-CssClass="search-th">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <asp:HyperLink ID="hlBuyerName" runat="server" Text='<%# Bind("buyerName") %>' NavigateUrl='<%# Eval("userId", "~/NewUserProfile.aspx?UserId={0}") %>'
                                Target="_blank"></asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Code" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource32">
                        <HeaderStyle Width="8%" />
                        <ItemTemplate>
                            <asp:Label ID="lblDateCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateCode") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit price in IRs" HeaderStyle-CssClass="search-th"
                        meta:resourcekey="TemplateFieldResource33">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <asp:Label ID="lblPriceInUSD" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PriceInUSD") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comment" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource34">
                        <HeaderStyle Width="15%" />
                        <ItemTemplate>
                            <asp:Label ID="lbldescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Package" meta:resourcekey="TemplateFieldResource20"
                        HeaderStyle-CssClass="search-th">
                        <HeaderStyle Width="8%" />
                        <ItemTemplate>
                            <asp:Label ID="lblPackage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Package") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Country" meta:resourcekey="TemplateFieldResource21">
                        <ItemTemplate>
                            <asp:Label ID="lblCountry" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Country") %>'
                                meta:resourcekey="lblCountryResource2"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="PO/RFQ" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource35">
                        <HeaderStyle Width="8%" />
                        <ItemTemplate>
                            <asp:Label ID="lblWithPO" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RequirementwithPO") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Posted On" HeaderStyle-CssClass="search-th" meta:resourcekey="TemplateFieldResource36">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <asp:Label ID="lblLastUpdated" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CreationDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <RowStyle CssClass="odd"></RowStyle>
                <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                <PagerStyle BackColor="#E0ECF8" ForeColor="Black" HorizontalAlign="Center" />
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
            </asp:GridView>
        </div>
    </div>
</asp:Content>
