<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SellerInventories.ascx.cs"
    Inherits="ICBrowser.Web.Controls.SellerInventories" %>
<table width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <table width="100%" cellspacing="1" cellpadding="2">
                <tr>
                    <td valign="top" width="12%" id="tdPartNumber" runat="server" align="center">
                        <asp:TextBox ID="txtPartNumber" runat="server" Width="100%" CssClass="smallinput_t"
                            MaxLength="50"></asp:TextBox>
                    </td>
                    <td valign="top" width="10%" id="tdQuantity" runat="server" align="left">
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="smallinput_t" Width="100%"
                            MaxLength="5"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revtxtQuantity" runat="server" ValidationGroup="VgOne"
                            ErrorMessage="Enter Numeric Value" ForeColor="Red" ControlToValidate="TxtQuantity"
                            ValidationExpression="^(\s*)\d+(\s*)$" meta:resourcekey="revtxtQuantityResource1"
                            Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                    <td valign="top" width="13%" id="tdddlStockstatus" runat="server" align="center">
                        <asp:DropDownList ID="ddlStockStatus" runat="server" Width="100%" CssClass="smallinput_t200"
                            meta:resourcekey="ddlStockStatusResource1">
                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Available" Value="1"></asp:ListItem>
                            <asp:ListItem Text="In House" Value="2"></asp:ListItem>
                            <asp:ListItem Text="OEM Excess" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top" width="13%" id="tdBrandName" runat="server" align="center">
                        <asp:TextBox ID="txtBrandname" runat="server" Width="100%" CssClass="smallinput_t"
                            MaxLength="30"></asp:TextBox>
                    </td>
                    <td valign="top" width="13%" id="tdDateCode" runat="server" align="center">
                        <asp:TextBox ID="txtDateCode" runat="server" CssClass="smallinput_t" Width="100%"
                            MaxLength="30"></asp:TextBox>
                    </td>
                    <td valign="top" width="13%" id="tdPackage" runat="server" align="center">
                        <asp:TextBox ID="txtPackage" runat="server" CssClass="smallinput_t" Width="100%"
                            MaxLength="30"></asp:TextBox>
                    </td>
                    <td valign="top" width="13%" id="tdDesc" runat="server" align="center">
                        <asp:TextBox ID="txtDescription" runat="server" Width="97%"  CssClass="smallinput_t" Font-Names="Arial" Font-Size="10"
                             TextMode="MultiLine" Height="22px" MaxLength="500"></asp:TextBox>
                    </td>
                    <%--<td valign="top" width="8%" id="tdStockInHand" runat="server">
                        <asp:TextBox ID="txtStockInhand" runat="server" CssClass="smallinput_t" Width="100%"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev" runat="server" ValidationGroup="VgOne" ForeColor="Red"
                            ControlToValidate="txtStockInhand" ErrorMessage="Enter Numeric Value" ValidationExpression="^(\s*)\d+(\s*)$"
                            meta:resourcekey="revResource1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>--%>
                    <%--<td valign="top" width="8%" id="tdPriceINR" runat="server">
                        <asp:TextBox ID="txtPriceinINR" runat="server" CssClass="smallinput_t" Width="100%"
                            meta:resourcekey="txtPriceinINRResource1"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revpriceinr" ControlToValidate="txtPriceinINR"
                            ForeColor="Red" ValidationGroup="VgOne" runat="server" ErrorMessage="Enter Numeric Value"
                            ValidationExpression="[0-9]*\.?[0-9]*" meta:resourcekey="revpriceinrResource1"
                            Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>--%>
                    <td valign="top" width="13%" id="tdPriceUSD" runat="server" align="center">
                        <asp:TextBox ID="txtPriceInUSD" runat="server" CssClass="smallinput_t" Width="100%"
                            MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revpriceusd" ControlToValidate="txtPriceInUSD"
                            ValidationGroup="VgOne" runat="server" ErrorMessage="Enter Numeric Value Upto 3 Decimal"
                            ForeColor="Red" Display="Dynamic" ValidationExpression="^\d{0,9}(\.\d{1,3})?$"
                            meta:resourcekey="revpriceusdResource1"></asp:RegularExpressionValidator>
                    </td>
                    <%--<td valign="top" width="8%" id="tdPriceCNY" runat="server">
                        <asp:TextBox ID="txtPriceInCNY" runat="server" CssClass="smallinput_t" Width="100%"
                            meta:resourcekey="txtPriceInCNYResource1"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtPriceInCNY"
                            ValidationGroup="VgOne" runat="server" ErrorMessage="Enter Numeric Value" ForeColor="Red"
                            Display="Dynamic" ValidationExpression="[0-9]*\.?[0-9]*" meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator>
                    </td>--%>
                    <%--<td valign="top" width="10%" id="tdCountry" runat="server">
                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="smallinput_t200" meta:resourcekey="ddlCountryResource1"
                            Width="100%">
                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="INDIA" Value="1"></asp:ListItem>
                            <asp:ListItem Text="CHINA" Value="2"></asp:ListItem>
                            <asp:ListItem Text="USA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>--%>
                </tr>
            </table>
        </td>
    </tr>
</table>
