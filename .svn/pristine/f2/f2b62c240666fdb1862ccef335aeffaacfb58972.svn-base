<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InventoryGrid.ascx.cs"
    Inherits="ICBrowser.Web.Controls.InventoryGrid" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<table width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <table width="100%" cellspacing="0" cellpadding="0">
                <tr class="head">
                    <td class="bold">
                        Inventory Details
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdInventoryDetails" runat="server" CellPadding="5" AutoGenerateColumns="False"
                            Width="100%" OnRowDataBound="grdInventoryDetails_RowDataBound" PageSize="3" AllowSorting="True"
                            DataKeyNames="ComponentId" AllowPaging="True" OnRowDeleting="grdInventoryDetails_RowDeleting"
                            OnRowEditing="grdInventoryDetails_RowEditing" OnRowCommand="grdInventoryDetails_RowCommand"
                            OnRowUpdating="grdInventoryDetails_RowUpdating" OnRowCancelingEdit="grdInventoryDetails_RowCancelingEdit"
                            OnRowUpdated="grdInventoryDetails_RowUpdated" OnPageIndexChanging="grdInventoryDetails_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField ShowHeader="false" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="LblComponentId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentId")%>'
                                            Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Component_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="LblComponentname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ComponentName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtComponentName" runat="server" Width="100px" Text='<%# Eval("ComponentName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="LblQuantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtQuantity" runat="server" Width="100px" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Brand_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="LblBrandName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Brandname")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtBrandName" runat="server" Width="100px" Text='<%# Eval("Brandname") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DataSheetURL">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkURL" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ComponentId")%>'
                                            CausesValidation="false" CommandName="DownLoad" Text='<%# DataBinder.Eval(Container.DataItem, "DataSheetURL")%>'></asp:LinkButton>&nbsp;&nbsp;
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDataSheetlnk" runat="server" Text='<%# Eval("DataSheetURL") %>'
                                            Width="300px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Upload file">
                                    <ItemTemplate>
                                        <%--<asp:Button ID="btnUpload" runat="server" Text="Upload" Width="80px" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ComponentId")%>'
                                            CommandName="Upload" CausesValidation="false" />--%>
                                        <asp:Button ID="btnUploadlnk" runat="server" Text="Link" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ComponentId")%>'
                                            CausesValidation="false" CommandName="Upload" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Operations">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LnkEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                            Text="Edit"></asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton ID="LnkUpdate" runat="server" CausesValidation="false" CommandName="Update"
                                            Text="Update"></asp:LinkButton>&nbsp;
                                        <asp:LinkButton ID="LnkDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                            Text="Delete"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                       <%-- <asp:Panel ID="panelUpload" runat="server" Width="50%" CssClass="panelbackcolor"
                            Height="200px">
                            <table width="100%" cellspacing="5" cellpadding="5">
                                <tr class="header">
                                    <td class="bold">
                                        Upload File
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        Upload File :
                                        <asp:FileUpload ID="fuploadgrid" runat="server" />
                                        &nbsp;&nbsp;<asp:Button ID="btnUploadfromgrd" runat="server" Text="Upload" Width="80px"
                                            CausesValidation="false" />
                                        <br />
                                        OR
                                        <br />
                                        <asp:TextBox ID="txtLink" runat="server" Width="150px" Text="http://"></asp:TextBox>
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnSavefUpload" runat="server" Text="Save" Width="80px" CausesValidation="false"
                                            OnClick="btnSavefUpload_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>--%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
