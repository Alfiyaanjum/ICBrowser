<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="OfferDetails.aspx.cs" Inherits="ICBrowser.Web.OfferDetails" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        function ismaxlength(objTxtCtrl, nLength) {
            if (objTxtCtrl.getAttribute && objTxtCtrl.value.length > nLength)
                objTxtCtrl.value = objTxtCtrl.value.substring(0, nLength)

            if (document.all)
                document.getElementById('lblCaption').innerText = objTxtCtrl.value.length + ' Out Of ' + nLength;
            else
                document.getElementById('lblCaption').textContent = objTxtCtrl.value.length + ' Out Of ' + nLength;

        }     
    </script>
    <asp:Label ID="lnkEmilAddress" runat="server" meta:resourcekey="lnkEmilAddressResource1"></asp:Label>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr class="table-row">
            <td width="30%">
                <asp:Label ID="lbl_offerName" runat="server" Text="Offer Name" Font-Bold="True"
                    Font-Size="Medium" meta:resourcekey="lbl_componentNameResource1"></asp:Label><span>:</span>
            </td>
            <td width="60%" align="right">
                <asp:Label ID="lblmsg" runat="server" CssClass="greenmsg" Visible="False" meta:resourcekey="lblmsgResource1"></asp:Label>
            </td>
            <td width="10%">
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div class="grid">
                    <asp:GridView ID="gvOfferDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                        PageSize="20" AlternatingRowStyle-CssClass="even" RowStyle-CssClass="odd" OnRowCommand="gvOfferDetails_RowCommand"
                        OnRowDataBound="gvOfferDetails_RowDataBound" meta:resourcekey="gvOfferDetailsResource1">
                        <RowStyle CssClass="odd"></RowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="User Id" SortExpression="UserId" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUserId" runat="server" CommandName="Select" Text='<%# Bind("UserId") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Part Number" meta:resourcekey="TemplateFieldResource10">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPartNumber" runat="server" CommandName="SelectPartNumber"
                                        Text='<%# Bind("ComponentName") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company Name" SortExpression="CompanyName" meta:resourcekey="TemplateFieldResource1">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkCompanyName" runat="server" CommandName="SelectCompanyName"
                                        Text='<%# Bind("CompanyName") %>' meta:resourcekey="lnkCompanyNameResource1"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Make" SortExpression="BrandName" meta:resourcekey="TemplateFieldResource2">
                                <ItemTemplate>
                                    <asp:Label ID="lblBrandName" runat="server" Text='<%# Bind("BrandName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity" meta:resourcekey="TemplateFieldResource3">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Code" SortExpression="DateCode" meta:resourcekey="TemplateFieldResource6">
                                <ItemTemplate>
                                    <asp:Label ID="lblDateCode" runat="server" Text='<%# Bind("DateCode") %>' meta:resourcekey="lblDateCodeResource1"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price In USD" SortExpression="PriceInUSD" meta:resourcekey="TemplateFieldResource7">
                                <ItemTemplate>
                                    <asp:Label ID="lblPriceInUSD" runat="server" Text='<%# Bind("PriceInUSD") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stock Status" SortExpression="stockstatus" meta:resourcekey="TemplateFieldResource8">
                                <ItemTemplate>
                                    <asp:Label ID="lblStkStatus" runat="server" Text='<%# Bind("stockstatus") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comment" meta:resourcekey="TemplateFieldResource9">
                                <ItemTemplate>
                                    <asp:Label ID="lbldescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:TemplateField>
                        </Columns>
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
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
