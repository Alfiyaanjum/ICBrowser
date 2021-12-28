<%@ Page Title="ICBrowser.com buy and sell electronic components" Language="C#" MasterPageFile="~/Detail.Master" AutoEventWireup="true"
    CodeBehind="UploadAdvertisement.aspx.cs" Inherits="ICBrowser.Web.UploadAdvertisement"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function checkDate(sender, args) {
            if (sender._selectedDate.getDateOnly() < new Date().getDateOnly()) {
                alert("You cannot select a day earlier than today.");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
            else if (sender._selectedDate.getDateOnly() == new Date().getDateOnly()) {
            }
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#MainContent_datepickerStart").datepicker({ minDate: new Date(), dateFormat: 'dd-M-yy', showTime: true, time24h: false });
        });
        $(function () {
            $("#MainContent_datepickerEnd").datepicker({ minDate: new Date(), dateFormat: 'dd-M-yy', showTime: true, time24h: false });
        });
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
    <script type="text/javascript" language="javascript">
        function ValidateFun(source, arguments) {
            //get the date that user has entered

            var startDate = document.getElementById("tbxGridStartDate").value;
            var endDate = document.getElementById("tbxGridEndDate").value;

            var strday1 = String(startDate);
            strday1 = strday1.substring(0, 2);
            var day1 = Number(strday1);

            var strmonth1 = String(startDate);
            strmonth1 = strmonth1.substring(3, 6);

            switch (strmonth1) {
                case "Jan": var month1 = 00;
                    break;
                case "Feb": var month1 = 01;
                    break;
                case "Mar": var month1 = 02;
                    break;
                case "Apr": var month1 = 03;
                    break;
                case "May": var month1 = 04;
                    break;
                case "Jun": var month1 = 05;
                    break;
                case "Jul": var month1 = 06;
                    break;
                case "Aug": var month1 = 07;
                    break;
                case "Sep": var month1 = 08;
                    break;
                case "Oct": var month1 = 09;
                    break;
                case "Nov": var month1 = 10;
                    break;
                case "Dec": var month1 = 11;
                    break;
                default: break;
            }


            var stryear1 = String(startDate);
            stryear1 = stryear1.substring(7, 11);
            var year1 = Number(stryear1);

            var strday2 = String(endDate);
            strday2 = strday2.substring(0, 2);
            var day2 = Number(strday2);

            var strmonth2 = String(endDate);
            strmonth2 = strmonth2.substring(3, 6);

            switch (strmonth2) {
                case "Jan": var month2 = 00;
                    break;
                case "Feb": var month2 = 01;
                    break;
                case "Mar": var month2 = 02;
                    break;
                case "Apr": var month2 = 03;
                    break;
                case "May": var month2 = 04;
                    break;
                case "Jun": var month2 = 05;
                    break;
                case "Jul": var month2 = 06;
                    break;
                case "Aug": var month2 = 07;
                    break;
                case "Sep": var month2 = 08;
                    break;
                case "Oct": var month2 = 09;
                    break;
                case "Nov": var month2 = 10;
                    break;
                case "Dec": var month2 = 11;
                    break;
                default: break;
            }

            var stryear2 = String(endDate);
            stryear2 = stryear2.substring(7, 11);
            var year2 = Number(stryear2);

            var date1 = new Date(year1, month1, day1);
            var date2 = new Date(year2, month2, day2);

            if (date1 < date2) {

                arguments.IsValid = true;
            }
            else {
                arguments.IsValid = false;
            }
        }              

    </script>
    <script type="text/javascript" language="javascript">
        function validate(oSrc, args) {

            var startDate = document.getElementById("<%=datepickerStart.ClientID %>").value;
            var endDate = document.getElementById("<%=datepickerEnd.ClientID %>").value;

            var strday1 = String(startDate);
            strday1 = strday1.substring(0, 2);
            var day1 = Number(strday1);

            var strmonth1 = String(startDate);
            strmonth1 = strmonth1.substring(3, 6);

            switch (strmonth1) {
                case "Jan": var month1 = 00;
                    break;
                case "Feb": var month1 = 01;
                    break;
                case "Mar": var month1 = 02;
                    break;
                case "Apr": var month1 = 03;
                    break;
                case "May": var month1 = 04;
                    break;
                case "Jun": var month1 = 05;
                    break;
                case "Jul": var month1 = 06;
                    break;
                case "Aug": var month1 = 07;
                    break;
                case "Sep": var month1 = 08;
                    break;
                case "Oct": var month1 = 09;
                    break;
                case "Nov": var month1 = 10;
                    break;
                case "Dec": var month1 = 11;
                    break;
                default: break;
            }


            var stryear1 = String(startDate);
            stryear1 = stryear1.substring(7, 11);
            var year1 = Number(stryear1);

            var strday2 = String(endDate);
            strday2 = strday2.substring(0, 2);
            var day2 = Number(strday2);

            var strmonth2 = String(endDate);
            strmonth2 = strmonth2.substring(3, 6);

            switch (strmonth2) {
                case "Jan": var month2 = 00;
                    break;
                case "Feb": var month2 = 01;
                    break;
                case "Mar": var month2 = 02;
                    break;
                case "Apr": var month2 = 03;
                    break;
                case "May": var month2 = 04;
                    break;
                case "Jun": var month2 = 05;
                    break;
                case "Jul": var month2 = 06;
                    break;
                case "Aug": var month2 = 07;
                    break;
                case "Sep": var month2 = 08;
                    break;
                case "Oct": var month2 = 09;
                    break;
                case "Nov": var month2 = 10;
                    break;
                case "Dec": var month2 = 11;
                    break;
                default: break;
            }

            var stryear2 = String(endDate);
            stryear2 = stryear2.substring(7, 11);
            var year2 = Number(stryear2);

            var date1 = new Date(year1, month1, day1);
            var date2 = new Date(year2, month2, day2);


            var miliday1 = date1.getTime();
            var miliday2 = date2.getTime();

            var diff = miliday2 - miliday1;
            if (date1 < date2) {

                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }
        function datepickerStart_onclick() {

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="sc1" runat="server">
    </asp:ScriptManager>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindPicker);
            bindPicker();
        });
        function bindPicker() {
            $("input[type=text][id*=tbxGridStartDate]").datepicker({ minDate: new Date(), dateFormat: 'dd-M-yy' });
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindPicker);
            bindPicker();
        });
        function bindPicker() {
            $("input[type=text][id*=tbxGridEndDate]").datepicker({ minDate: new Date(), dateFormat: 'dd-M-yy' });
        }
    </script>--%>
    <%--<script type="text/javascript">
        function showPopUp(componentid) {
            //  alert("Hello world in Show Popup");
            $get('<%= hidComponentId.ClientID %>').value = componentid;
            $find('<%= ModalPopupExtender1.ClientID %>').show();
        }
    </script>--%>
    <div style="width: 100%; height: 100%">
        <div>
            <div class="formBackgorund">
                <table align="center" width="99%">
                    <tr>
                        <td>
                            <div>
                                <asp:Label ID="lblUploadMessage" runat="server" CssClass="lblstatus" Visible="False"
                                    meta:resourcekey="lblUploadMessageResource1"></asp:Label>
                            </div>
                            <div class="headerback">
                                <asp:Label ID="lblUploadAdHeader" runat="server" CssClass="header" Text="Upload New Advertisements"
                                    meta:resourcekey="lblUploadAdHeaderResource1"></asp:Label>
                            </div>
                            <div>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 22%;" align="right">
                                            <span class="errormsg">*</span><asp:Label ID="lblUploadAdImage" runat="server" Text="Upload Advertisement Image:"
                                                meta:resourcekey="lblUploadAdImageResource1"></asp:Label>
                                        </td>
                                        <td style="width: 10%;" align="left" valign="middle">
                                            <asp:FileUpload ID="fuAdImage" runat="server" CssClass="browse_but" meta:resourcekey="fuAdImageResource1"
                                                Width="200px" />
                                        </td>
                                        <td style="width: 20%;" align="left">
                                            <asp:LinkButton ID="lbtnPreview" runat="server" Text="Click here to view Image Preview"
                                                OnClick="lbtnPreview_Click" meta:resourcekey="lbtnPreviewResource1"></asp:LinkButton>
                                        </td>
                                        <td style="width: 30%;" align="left" colspan="3">
                                            <asp:RequiredFieldValidator ID="rfvAdImage" runat="server" ErrorMessage="Please select a file"
                                                ForeColor="Red" ValidationGroup="ValidateToSubmit" ControlToValidate="fuAdImage"
                                                Display="Dynamic" meta:resourcekey="rfvAdImageResource1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 22%;" align="right">
                                            <span class="errormsg">*</span><asp:Label ID="lblStartDate" runat="server" Text="Start Date:"
                                                meta:resourcekey="lblStartDateResource1"></asp:Label>
                                        </td>
                                        <td style="width: 10%;" align="left">
                                            <input style="width: 200px;" type="text" name="datetimeStart" id="datepickerStart"
                                                runat="server" readonly="readonly" class="smallinput_t" onclick="return datepickerStart_onclick()" />
                                        </td>
                                        <td style="width: 20%;" align="left">
                                            <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" ErrorMessage="Select Start Date"
                                                ForeColor="Red" ValidationGroup="ValidateToSubmit" ControlToValidate="datepickerStart"
                                                Display="Dynamic" meta:resourcekey="rfvStartDateResource1"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="width: 10%;" align="right">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblEndDate" runat="server" Text="End Date" meta:resourcekey="lblEndDateResource1"></asp:Label>
                                        </td>
                                        <td style="width: 10%;" align="left">
                                            <input type="text" style="width: 150px;" name="datetimeEnd" id="datepickerEnd" runat="server"
                                                readonly="readonly" class="smallinput_t" />
                                        </td>
                                        <td style="width: 30%;" align="left">
                                            <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ErrorMessage="Select End Date"
                                                ForeColor="Red" ValidationGroup="ValidateToSubmit" ControlToValidate="datepickerEnd"
                                                Display="Dynamic" meta:resourcekey="rfvEndDateResource1"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="cmpvalEndDate" runat="server" ErrorMessage="End Date cannot be before Start Date"
                                                Display="Dynamic" ControlToValidate="datepickerEnd" ValidationGroup="ValidateToSubmit"
                                                ForeColor="Red" ClientValidationFunction="validate" meta:resourcekey="cmpvalEndDateResource1"></asp:CustomValidator>
                                            <%--  <asp:CompareValidator ID="cmpvalEndDate" runat="server" ErrorMessage="End Date cannot be before Start Date"
                                                    Display="Dynamic" ValidationGroup="ValidateToSubmit" ControlToCompare="datepickerStart"
                                                    ForeColor="Red" Operator="LessThanEqual" Type="Date" ControlToValidate="datepickerEnd"></asp:CompareValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 22%;" align="right">
                                            <span class="errormsg">*</span><asp:Label ID="lblInfoText" runat="server" Text="Info Text"
                                                meta:resourcekey="lblInfoTextResource1"></asp:Label>
                                        </td>
                                        <td style="width: 10%;" align="right">
                                            <asp:TextBox ID="tbxInfoText" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                Width="200px" MaxLength="50" meta:resourcekey="tbxInfoTextResource1"></asp:TextBox>
                                        </td>
                                        <td style="width: 20%;" align="left">
                                            <asp:RequiredFieldValidator ID="rfvInfoText" runat="server" ErrorMessage="Enter Info text"
                                                ForeColor="Red" ValidationGroup="ValidateToSubmit" ControlToValidate="tbxInfoText"
                                                Display="Dynamic" meta:resourcekey="rfvInfoTextResource1"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="regexvalInfoText" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                Display="Dynamic" ValidationGroup="ValidateToSubmit" ControlToValidate="tbxInfoText"
                                                ForeColor="Red" ValidationExpression="^((?![<>]).)*$" meta:resourcekey="regexvalInfoTextResource1"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="width: 10%;" align="right">
                                            <span class="errormsg">*</span>
                                            <asp:Label ID="lblemailid" runat="server" Text="Email ID" meta:resourcekey="lblemailidResource1"></asp:Label>
                                        </td>
                                        <td style="width: 10%;" align="right">
                                            <asp:TextBox ID="tbxemailid" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                Width="150px" MaxLength="50" meta:resourcekey="tbxemailidResource1"></asp:TextBox>
                                        </td>
                                        <td style="width: 30%;" align="left">
                                            <asp:RequiredFieldValidator ID="rfvemailid" runat="server" ErrorMessage="Enter EmailID"
                                                ForeColor="Red" ValidationGroup="ValidateToSubmit" ControlToValidate="tbxemailid"
                                                Display="Dynamic" meta:resourcekey="rfvemailidResource1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <asp:UpdatePanel runat="server" ID="upnluploadAdd">
                                        <ContentTemplate>
                                            <tr>
                                                <td style="width: 22%;" align="right">
                                                    <span class="errormsg">*</span><asp:Label ID="lblPosition" runat="server" Text="Image Position"
                                                        meta:resourcekey="lblPositionResource1"></asp:Label>
                                                </td>
                                                <td style="width: 10%;" align="right">
                                                    <asp:DropDownList ID="ddlPosition" Width="200px" runat="server" CssClass="smallinput_t200"
                                                        meta:resourcekey="ddlPositionResource1">
                                                        <asp:ListItem Text="- Select -" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Top Left" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Top Right" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Right" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Bottom Left" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Bottom Right" Value="5"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 20%;" align="left">
                                                    <asp:RequiredFieldValidator ID="rfvPosition" runat="server" ErrorMessage="Select Image Position"
                                                        ForeColor="Red" ValidationGroup="ValidateToSubmit" ControlToValidate="ddlPosition"
                                                        InitialValue="0" Display="Dynamic" meta:resourcekey="rfvPositionResource1"></asp:RequiredFieldValidator>
                                                </td>
                                                <td style="width: 10%;" align="right">
                                                    <span id="msgspan" runat="server" class="errormsg">*</span>
                                                    <asp:Label ID="lblRedirectUrl" runat="server" Text="Redirect URL" meta:resourcekey="lblRedirectUrlResource1"></asp:Label>
                                                    <asp:Label ID="lblHttp" runat="server" Text="http://" meta:resourcekey="lblHttpResource1"></asp:Label>
                                                </td>
                                                <td style="width: 10%;" align="left" valign="bottom">
                                                    <asp:TextBox ID="tbxRedirectUrl" runat="server" AutoCompleteType="Disabled" CssClass="smallinput_t"
                                                        Width="150px" meta:resourcekey="tbxRedirectUrlResource1"></asp:TextBox>
                                                </td>
                                                <td style="width: 30%;" align="left">
                                                    <asp:RequiredFieldValidator ID="rfvRedirectUrl" runat="server" ErrorMessage="Enter Redirect URL"
                                                        ForeColor="Red" ValidationGroup="ValidateToSubmit" ControlToValidate="tbxRedirectUrl"
                                                        Display="Dynamic" meta:resourcekey="rfvRedirectUrlResource1"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="regexvalRedirectUrl" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                        ForeColor="Red" ValidationGroup="ValidateToSubmit" ControlToValidate="tbxRedirectUrl"
                                                        Display="Dynamic" ValidationExpression="^((?![<>]).)*$" meta:resourcekey="regexvalRedirectUrlResource1"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlPosition" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </table>
                            </div>
                            <div>
                                <table width="100%">
                                </table>
                            </div>
                            <div>
                                <table width="100%">
                                </table>
                            </div>
                            <div>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 50%;" align="right">
                                            <asp:Button align="right" ID="btnSubmit" runat="server" ValidationGroup="ValidateToSubmit"
                                                CssClass="blue_button" Width="15%" Text="Insert Ad" OnClick="btnSubmit_Click"
                                                meta:resourcekey="btnSubmitResource1" />
                                        </td>
                                        <td style="width: 50%;" align="left">
                                            <asp:Button ID="btnClear" Width="15%" runat="server" CssClass="blue_button" Text="Clear"
                                                OnClick="btnClear_Click" CausesValidation="False" meta:resourcekey="btnClearResource1" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <br />
        <div>
            <asp:Panel runat="server" ID="pnlAdGrid" Visible="False" meta:resourcekey="pnlAdGridResource1">
                <div>
                    <table style="border: 1px solid #00CCFF; border-collapse: separate;" align="center"
                        width="99%">
                        <tr>
                            <td align="center">
                                <div id="chart_bg" style="width: 100%; background-repeat: repeat-x;">
                                    <div class="headerback" align="left">
                                        <asp:Label ID="lblGvHeading" runat="server" CssClass="header" Text="Uploaded Advertisements"
                                            meta:resourcekey="lblGvHeadingResource1"></asp:Label>
                                    </div>
                                    <div class="grid">
                                        <asp:GridView ID="gvUploadedAds" runat="server" AutoGenerateColumns="False" PageSize="5"
                                            CellPadding="0" ClientIDMode="Static" AllowSorting="True" AllowPaging="True"
                                            Width="100%" OnPageIndexChanging="gvUploadedAds_PageIndexChanging" OnRowCancelingEdit="gvUploadedAds_RowCancelingEdit"
                                            OnRowDeleting="gvUploadedAds_RowDeleting" OnRowEditing="gvUploadedAds_RowEditing"
                                            OnRowUpdating="gvUploadedAds_RowUpdating" CssClass="table-border" meta:resourcekey="gvUploadedAdsResource1">
                                            <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False" Visible="False" meta:resourcekey="TemplateFieldResource1">
                                                    <ItemTemplate>
                                                        <asp:Label ID="colLblAdvId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AdvertisementID") %>'
                                                            meta:resourcekey="colLblAdvIdResource1"></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="99%"></ControlStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemStyle Width="0%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Image" meta:resourcekey="TemplateFieldResource2">
                                                    <EditItemTemplate>
                                                        <asp:FileUpload ID="fuGridImage" runat="server" CssClass="browse_but" meta:resourcekey="fuGridImageResource1" />
                                                        <asp:Label ID="colLblAdImage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ImageUrl") %>'
                                                            Visible="False" meta:resourcekey="colLblAdImageResource1"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Image ID="colAdImage" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageUrl") %>'
                                                            meta:resourcekey="colAdImageResource1" />
                                                    </ItemTemplate>
                                                    <ControlStyle Width="99%" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="30%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Start Date" meta:resourcekey="TemplateFieldResource3">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="tbxGridStartDate" runat="server" Text='<%# Bind("StartDate") %>'
                                                            CssClass="smallinput_t" meta:resourcekey="tbxGridStartDateResource1"></asp:TextBox>
                                                        <asp:CalendarExtender ID="calexGridStartDate" runat="server" TargetControlID="tbxGridStartDate"
                                                            ViewStateMode="Enabled" Format="dd-MMM-yyyy" OnClientDateSelectionChanged="checkDate"
                                                            CssClass="CalendarDatePicker" Enabled="True">
                                                        </asp:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                            ErrorMessage="Select date" ForeColor="Red" ControlToValidate="tbxGridStartDate"
                                                            ValidationGroup="ValidateToEdit" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="colStartDate" runat="server" meta:resourcekey="colStartDateResource1"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="99%" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="13%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="End Date" meta:resourcekey="TemplateFieldResource4">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="tbxGridEndDate" runat="server" Text='<%# Bind("EndDate") %>' CssClass="smallinput_t"
                                                            meta:resourcekey="tbxGridEndDateResource1"></asp:TextBox>
                                                        <asp:CalendarExtender ID="calexGridEndDate" runat="server" TargetControlID="tbxGridEndDate"
                                                            ViewStateMode="Enabled" Format="dd-MMM-yyyy" OnClientDateSelectionChanged="checkDate"
                                                            CssClass="CalendarDatePicker" Enabled="True">
                                                        </asp:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                            ErrorMessage="Select date" ForeColor="Red" ControlToValidate="tbxGridEndDate"
                                                            ValidationGroup="ValidateToEdit" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFun"
                                                            Display="Dynamic" ControlToValidate="tbxGridEndDate" ForeColor="Red" ErrorMessage="End Date must be greater than Start Date"
                                                            ValidationGroup="ValidateToEdit" meta:resourcekey="CustomValidator1Resource1"></asp:CustomValidator>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="colEndDate" runat="server" meta:resourcekey="colEndDateResource1"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="99%" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="13%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Text" meta:resourcekey="TemplateFieldResource5">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="tbxGridInfoText" runat="server" Text='<%# Eval("Text") %>' AutoCompleteType="Disabled"
                                                            CssClass="smallinput_t" Width="100%" MaxLength="50" meta:resourcekey="tbxGridInfoTextResource1"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="regexvalGridInfoText" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                            Display="Dynamic" ValidationGroup="ValidateToEdit" ControlToValidate="tbxGridInfoText"
                                                            ForeColor="Red" ValidationExpression="^((?![<>]).)*$" meta:resourcekey="regexvalGridInfoTextResource1"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="colText" runat="server" meta:resourcekey="colTextResource1" Text='<%# DataBinder.Eval(Container.DataItem, "Text") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="90%" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="11%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Redirect URL" meta:resourcekey="TemplateFieldResource6">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblGridHttp" runat="server" Text="http://" meta:resourcekey="lblGridHttpResource1"></asp:Label>
                                                        <asp:TextBox ID="tbxGridRedirectUrl" Text='<%# Eval("RedirectUrl") %>' runat="server"
                                                            AutoCompleteType="Disabled" CssClass="smallinput_t" Width="50%" meta:resourcekey="tbxGridRedirectUrlResource1"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="regexvalGridRedirectUrl" runat="server" ErrorMessage="'<' or '>' are not allowed"
                                                            ForeColor="Red" ValidationGroup="ValidateToEdit" ControlToValidate="tbxGridRedirectUrl"
                                                            Display="Dynamic" ValidationExpression="^((?![<>]).)*$" Width="50%" meta:resourcekey="regexvalGridRedirectUrlResource1"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="colRedUrl" runat="server" meta:resourcekey="colRedUrlResource1" Text='<%# DataBinder.Eval(Container.DataItem, "RedirectUrl") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="90%"></ControlStyle>
                                                    <HeaderStyle HorizontalAlign="Left" Width="5%"></HeaderStyle>
                                                    <ItemStyle Width="20%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Position" meta:resourcekey="TemplateFieldResource7">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlGridPosition" Width="100%" runat="server" CssClass="smallinput_t200">
                                                            <asp:ListItem Text="- Select -" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Top Left" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Top Right" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Right" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Bottom Left" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Bottom Right" Value="5"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvGridPosition" runat="server" ErrorMessage="Select Image Position"
                                                            ForeColor="Red" ValidationGroup="ValidateToEdit" ControlToValidate="ddlGridPosition"
                                                            InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="colPosition" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Position") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="4%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Email" meta:resourcekey="TemplateFieldResource8">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="tbxGridEmail" Text='<%# Eval("Email") %>' runat="server" AutoCompleteType="Disabled"
                                                            CssClass="smallinput_t" Width="50%" meta:resourcekey="tbxGridEmailResource1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvgridemailid" runat="server" ErrorMessage="Enter Email"
                                                            ForeColor="Red" ValidationGroup="ValidateToEdit" ControlToValidate="tbxGridEmail"
                                                            Display="Dynamic" Width="50%" meta:resourcekey="rfvgridemailidResource1"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="colEmail" runat="server" meta:resourcekey="colEmailResource1" Text='<%# DataBinder.Eval(Container.DataItem, "Email") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="90%"></ControlStyle>
                                                    <HeaderStyle HorizontalAlign="Left" Width="5%"></HeaderStyle>
                                                    <ItemStyle Width="20%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField meta:resourcekey="TemplateFieldResource9">
                                                    <EditItemTemplate>
                                                        <asp:ImageButton runat="server" ID="imgbtnEdit" ValidationGroup="ValidateToEdit"
                                                            ToolTip="Update" ImageUrl="~/Images/save_btn.png" CommandName="Update" meta:resourcekey="imgbtnEditResource2" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" ImageUrl="~/Images/edit_btn.png"
                                                            meta:resourcekey="imgbtnEditResource1" ToolTip="Edit" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField meta:resourcekey="TemplateFieldResource10">
                                                    <EditItemTemplate>
                                                        <asp:ImageButton runat="server" ID="imgbtnCancel" ImageUrl="~/Images/cancel_btn.png"
                                                            CommandName="Cancel" ToolTip="Cancel" CausesValidation="False" meta:resourcekey="imgbtnCancelResource1" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnDelete" runat="server" CommandName="Delete" ImageUrl="~/Images/deletet_btn.png"
                                                            meta:resourcekey="imgbtnDeleteResource1" ToolTip="Delete" ValidationGroup="deleteConfirmation" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle Wrap="True" Width="100%"></EditRowStyle>
                                            <EmptyDataTemplate>
                                                <table style="background-color: #EEF0F6" width="100%" border="0" cellpadding="0"
                                                    cellspacing="0">
                                                    <tr>
                                                        <td colspan="2" class="errormsg" style="height: 100px" align="center">
                                                            No Ads Uploaded.
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EmptyDataTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <PagerStyle CssClass="headerback" HorizontalAlign="Center" />
                                            <RowStyle CssClass="odd" />
                                        </asp:GridView>
                                        <asp:CustomValidator ID="cvalDelete" ClientValidationFunction="confirmDelete" ValidationGroup="deleteConfirmation"
                                            runat="server" meta:resourcekey="cvalDeleteResource1"></asp:CustomValidator>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
        <div>
            <table>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
                        <asp:ModalPopupExtender ID="modpopPreview" runat="server" PopupControlID="pnlPreview"
                            TargetControlID="LinkButton1" BackgroundCssClass="modalBackground" DynamicServicePath=""
                            Enabled="True">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlPreview" runat="server" meta:resourcekey="pnlPreviewResource1">
                            <asp:UpdatePanel runat="server" ID="upnlPreview">
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
                                                                <asp:Label ID="lblPreview" runat="server" Text="Advertisement Preview" CssClass="title"
                                                                    meta:resourcekey="lblPreviewResource1"></asp:Label>
                                                            </td>
                                                            <td width="3%" align="right" valign="middle" class="popupbox-header">
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
                                                        <tr id="trUploadedFile" runat="server">
                                                            <td align="left" runat="server">
                                                                <asp:ImageButton ID="ibtnPreview" runat="server" Visible="False" OnClick="ibtnPreview_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Button ID="btnPreviewClose" runat="server" Text="Close" Width="60px" CausesValidation="False"
                                                                    CssClass="blue_button" OnClick="btnPreviewClose_Click" meta:resourcekey="btnPreviewCloseResource1" />
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
                                    <asp:PostBackTrigger ControlID="btnPreviewClose" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
