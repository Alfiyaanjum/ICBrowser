<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadSheetData.ascx.cs"
    Inherits="ICBrowser.Web.Controls.UploadSheetData" %>
<link href="../Styles/global.css" rel="stylesheet" type="text/css" />
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script type="text/javascript">
    function ConfirmTemplateSheet() {
        //alert (ans); 

        var flag = confirm("Is your file as per ICBrowser Template? Click 'Ok' for Yes, 'Cancel' for No.");
        if (flag == true) {

            //            var controlYes = document.getElementById("MainContent_ctrlUploaddata_lblYes");
            //            controlYes.style.display = "block";
            //            var controlNo = document.getElementById("MainContent_ctrlUploaddata_lblNo");
            //            controlNo.style.display = "none";
            document.getElementById("<%=HiddenField1.ClientID %>").value = "true";

        }
        else {
            //            var controlNo = document.getElementById("MainContent_ctrlUploaddata_lblNo");
            //            controlNo.style.display = "block";
            //            var controlYes = document.getElementById("MainContent_ctrlUploaddata_lblYes");
            //            controlYes.style.display = "none";
            document.getElementById("<%=HiddenField1.ClientID %>").value = "false";

        }
    }
</script>


<script type="text/javascript">
    function ConfirmOverwrite() {
        //alert (ans); 

        var flag = confirm("Are you sure, You want to overwrite? Click 'Ok' for Yes, 'Cancel' for No.");
        if (flag == true) {

            //            var controlYes = document.getElementById("MainContent_ctrlUploaddata_lblYes");
            //            controlYes.style.display = "block";
            //            var controlNo = document.getElementById("MainContent_ctrlUploaddata_lblNo");
            //            controlNo.style.display = "none";
            document.getElementById("<%=HiddenField2.ClientID %>").value = "true";

        }
        else {
            document.getElementById('MainContent_ctrlUploaddata_rdbExist').checked = true;
            document.getElementById('MainContent_ctrlUploaddata_rdbOverwrite').checked = false;
            document.getElementById("<%=HiddenField2.ClientID %>").value = "false";
        }
    }
</script>


<style type="text/css">
    .RedMessage
    {
        color: Red;
    }
    .GreenMessage
    {
        color: Green;
    }
    .style1
    {
        width: 8%;
    }
    p.MsoNormal
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:0in;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
p.MsoListParagraphCxSpFirst
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
p.MsoListParagraphCxSpMiddle
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
p.MsoListParagraphCxSpLast
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:.5in;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
    .style2
    {
        line-height: 115%;
        font-size: 11.0pt;
        font-family: Calibri, sans-serif;
        background: white;
    }
</style>
<div>
<div class="formBackgorund">
    <table align="center" width="100%">
        <tr>
            <td>
            <div class="headerback" >
                <asp:Label ID="lblUploadName" runat="server" Text="" CssClass="header"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="Header">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        
                        <tr>
                            <td style="width: 25%; height: 25px" align="right">
                                <asp:Label runat="server" ID="lblInstruction" Text="Please Read Instructions For File Upload"
                                    meta:resourcekey="lblInstructionResource1" 
                                    style="text-decoration: underline; font-weight: 700" />
                            </td>
                            <td style="width: 1%; height: 25px">
                            </td>
                            <td style="width: 80%; height: 25px" align="left">
                                <asp:LinkButton ID="lnkHelp" runat="server" Style="background-image: ~/Images/help (2).png"
                                    Text="Instructions" meta:resourcekey="lnkHelpResource1"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; height: 25px" align="right">
                                <asp:Label ID="lblDownloadTemplate" runat="server" Text="To Upload The File In ICBrowser Format" meta:resourcekey="lblDownloadTemplateResource1"></asp:Label>
                            </td>
                            <td style="width: 1%; height: 25px">
                            </td>
                            <td style="width: 60%; height: 25px" align="left">
                                <asp:HyperLink ID="hyplnkDwnloadInventory" runat="server" Text="Download" Target="_blank"
                                    ToolTip="user upload our ready to use excel sheet in just 2 steps." NavigateUrl="~/data/inventoryexcelsheet/inventory.xls"
                                    meta:resourcekey="hyplnkDwnloadInventoryResource1"></asp:HyperLink>
                                <asp:HyperLink ID="hyplnkDwnloadRequirement" runat="server" Text="Download" Target="_blank"
                                    ToolTip="user upload our ready to use excel sheet in just 2 steps." NavigateUrl="~/data/BuyersRequirementsheet/BUYER_TEMPLATE.xls"
                                    meta:resourcekey="hyplnkDwnloadRequirementResource1"></asp:HyperLink>
                                     <asp:Label ID="lbldownloadtxt" runat="server" Text="template file.xls" CssClass="black"
                                    meta:resourcekey="lbldownloadtxtResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; height: 25px;" align="right">
                                <asp:Label ID="lblStkstatus" runat="server" Text="Stock Status" CssClass="black"
                                    meta:resourcekey="lblStkstatusResource1"></asp:Label>
                            </td>
                            <td style="width: 1%">
                            </td>
                            <td style="width: 20%;" align="left">
                                <asp:DropDownList ID="ddlStockStatus" runat="server" CssClass="smallinput_t200" meta:resourcekey="ddlStockStatusResource1">
                                    <asp:ListItem Text="---SELECT---" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                    <asp:ListItem Text="AVAILABLE" Value="1" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                    <asp:ListItem Text="IN-HOUSE" Value="2" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                    <asp:ListItem Text="OEM-EXCESS" Value="3" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlStockStatus" runat="server" InitialValue="0"
                                    ValidationGroup="validategrp" ForeColor="Red" ErrorMessage="Select Stock Status"
                                    ControlToValidate="ddlStockStatus" meta:resourcekey="rfvddlStockStatusResource1"></asp:RequiredFieldValidator>
                            </td>                            
                        </tr>
                        <tr>
                            <td style="width: 20%; height: 25px;" align="right">
                                <asp:Label ID="lblPorfq" runat="server" Text="PO/RFQ" CssClass="black"></asp:Label>
                            </td>
                            <td style="width: 1%">
                            </td>
                            <td style="width: 20%;" align="left">
                                <asp:DropDownList ID="ddlPorfq" runat="server" CssClass="smallinput_t200">
                                    <asp:ListItem Text="---SELECT---" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                    <asp:ListItem Text="PO" Value="1" ></asp:ListItem>
                                    <asp:ListItem Text="RFQ" Value="2" ></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlPorfq" runat="server" InitialValue="0"
                                    ValidationGroup="validategrp" ForeColor="Red" ErrorMessage="Select PO or RFQ"
                                    ControlToValidate="ddlPorfq"></asp:RequiredFieldValidator>
                            </td>                            
                        </tr>
                        <tr>
                            <td style="width: 20%; height: 20%" align="right">
                                <asp:Label ID="lblUploadFile" runat="server" Text="Upload File" CssClass="black"
                                    meta:resourcekey="lblUploadFileResource1"></asp:Label>
                            </td>
                            <td style="width: 1%; height: 20%">
                            </td>
                            <td colspan="2" align="left">
                                  <table width="100%"  style="margin-left:-5px">
                                    <tr>
                                        <td align="left" width="15%" >
                                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="browse_but" OnClick="ConfirmTemplateSheet()"
                                                meta:resourcekey="FileUpload1Resource1"/>
                                            <input id="HiddenField1" type="hidden" value="" runat="server" />                                            
                                        </td>
                                        <td align="left" class="style1">
                                            <asp:Button ID="btnUpload" runat="server" CssClass="blue_button" 
                                                CausesValidation="False" Text="Upload" BackColor="Transparent" OnClick="btnUpload_Click"
                                                meta:resourcekey="btnUploadResource1" Width="100px" />                                            
                                        </td>
                                        <td align="left">
                                        <asp:Label ID="lblSelectedFile" runat="server" ForeColor="Blue" Text="Selected file:" meta:resourcekey="lblSelectedFileResource1"></asp:Label>
                                        <asp:Label ID="lblSelectedFileName" runat="server" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%--<tr>
                          
                            <td style="width: 1%" ; height="25px"></td>
                            <td style="width: 10%";height="25px"" align="left">
                                <asp:CheckBox ID="chkIsTemplate" runat="server" meta:resourcekey="chkIsTemplateResource1" />
                                <input id="HiddenField1" type="hidden" value="" runat="server" />
                                <asp:Label ID="lblYes" runat="server" Text="Yes" Style="display: none" meta:resourcekey="lblYesResource1"></asp:Label>
                                <asp:Label ID="lblNo" runat="server" Text="No" Style="display: none" meta:resourcekey="lblNoResource1"></asp:Label>
                            </td>
                            <td style="width: 70%;" align="left">
                            </td>
                        </tr>--%>
                        
                        <tr>
                            <td style="width: 10%; height: 25px" align="right">
                                <asp:Label ID="lblMessage" runat="server" Text="Message" CssClass="black" meta:resourcekey="lblMessageResource1"></asp:Label>
                            </td>
                            <td style="width: 1%; height: 25px;">
                            </td>
                            <td style="width: 10%; height: 25px;" align="left" colspan="2">
                                <asp:Label ID="lblStatus" runat="server" Text="No File Uploaded" CssClass="RedMessage"
                                    meta:resourcekey="lblStatusResource1"></asp:Label>
                            </td>
                            <%--<td style="width: 80%;" align="left">
                            </td>--%>
                        </tr>
                        <tr>
                            <td style="width: 10%; height: 25px" align="right">
                              
                            </td>
                            <td style="width: 1%; height: 25px;">
                            </td>
                            <td style="width: 10%; height: 25px;" align="left" colspan="2">
                              <table width="100%">
                              <tr>
                              <td width="15%">
                       
                                  <%--<asp:RadioButtonList ID="rdblistuploadparts"  CausesValidation="false" 
                                      RepeatDirection="Horizontal" runat="server">
                                   <asp:ListItem Text="Add To Existing" Value="rdbExist"  Selected="True">
                                    </asp:ListItem>
                                    <asp:ListItem Text="OverWrite Existing" Value="rdbOverwrite" ></asp:ListItem>
                                  </asp:RadioButtonList>--%>
                                  <input id="HiddenField2" type="hidden" value="" runat="server" /> 
                                  <asp:RadioButton ID="rdbExist" Text="Add To Existing"  GroupName = "a" Checked="true" runat="server" />
                                  </td>
                                  <td>
                                   <asp:RadioButton ID="rdbOverwrite" Text="OverWrite Existing"  GroupName = "a" 
                                          runat="server" onclick="ConfirmOverwrite()"  
                                   />

                              </td>
                              </tr>
                                  
                              </table>
                            </td>
                         
                        </tr>
                        <tr>
                            <td style="width: 20%;">
                            </td>
                            <td style="width: 1%">
                            </td>
                            <td colspan="2" width="100%" align="left">
                                <table width="10%">
                                    <tr>
                                        <td width="5%">
                                            <asp:Button ID="btnWorkSheetMapping" runat="server" OnClick="btnSave_Click"   Text="Save Mapping"
                                                ValidationGroup="validategrp"  CssClass="blue_button" 
                                                meta:resourcekey="btnWorkSheetMappingResource1" Width="100px"/>
                                        </td>
                                        <td width="5%" align="left">
                                            <asp:Button ID="btnClear" runat="server" Text="Clear Content" CssClass="blue_button"
                                                Enabled="False" OnClick="btnClear_Click" 
                                                meta:resourcekey="btnClearResource1" Width="100px" />
                                        </td>
                                        <td align="left">
                                        <asp:Button ID="btnback" runat="server" Text="Back" CssClass="blue_button"
                                                meta:resourcekey="btnbackResource1" CausesValidation="false" 
                                                onclick="btnback_Click" Width="100px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <%--  <td style="width: 60%;" align="left">
                            </td>--%>
                        </tr>
                    </table>
                </div>               
            </td>
        </tr>
    </table>
    
    </div>
    <br />   
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="left" valign="top" bgcolor="#ECF2F9" class="ui-accordion" colspan="4">
                <img src="../Images/map-coloum.png" width="980" height="32" alt="Map Column" />
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <span class="red">* Please note mapping of Part # and Quantity is mandatory.</span>
            </td>
        </tr>
        <tr style="background-color: #dfedf7">
            <td>
                <div style="overflow: scroll; height: 400px;">
                    <div class="gridd">
                        <asp:GridView ID="dvWorkSheetData" runat="server"   Width="100%" OnRowDataBound="dvWorkSheetData_RowDataBound"
                            RowStyle-HorizontalAlign="Center" RowStyle-CssClass="even" AlternatingRowStyle-CssClass="odd" HeaderStyle-HorizontalAlign="Center"
                            CssClass="table-border" meta:resourcekey="dvWorkSheetDataResource1">
                            <EmptyDataRowStyle BackColor="LightBlue" ForeColor="DarkCyan" />
                           

                            <EmptyDataTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image ID="NoDataImage" ImageUrl="~/Images/del.png" AlternateText="No Image"
                                                runat="server" meta:resourcekey="NoDataImageResource1" />
                                        </td>
                                        <td>
                                            No data found.
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="grid_head"></HeaderStyle>
                            <RowStyle CssClass="odd"></RowStyle>
                            <AlternatingRowStyle CssClass="even"></AlternatingRowStyle>
                        </asp:GridView>
                         
                    </div>
                </div>
            </td>
        </tr>
    </table>
</div><br />
<div id="ModalPopupInstruction">
    <asp:ModalPopupExtender ID="ModalPopupExtenderSendEmail" runat="server" BackgroundCssClass="modalBackground"
        TargetControlID="lnkHelp" PopupControlID="pnlMessagePopup" Y="30" Enabled="True"
        CancelControlID="imgCancel" DynamicServicePath="">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlMessagePopup" runat="server" Height="200px"  meta:resourcekey="pnldisplayResource1">
        <div style="width: 800px; height: 180px;" class="popupbox">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="popupbox-lefttop-corner">
                    </td>
                    <td class="popupbox-topbg">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="97%" align="left" class="popupbox-header">
                                    <asp:Label ID="lblInstructionheading" Font-Bold="true" runat="server" Text="Instructions" meta:resourcekey="lblInstructionheadingResource1"></asp:Label>
                                </td>
                                <td width="3%" align="right" valign="middle" class="popupbox-header">
                                    <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Images/cross.png" meta:resourcekey="imgCancelResource1"
                                        ToolTip="Close" />
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
                        <div style="overflow: auto; height: 300px; width: 100%;">
                            <table border="0" cellpadding="0" cellspacing="0" class="style2" 
                                style="mso-cellspacing: 0in; mso-yfti-tbllook: 1184; mso-padding-alt: 3.75pt 3.75pt 3.75pt 3.75pt">
                                <tr>
                                    <td>
                                        <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
  14.25pt">
                                            <b>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Important Instructions before uploading file:&nbsp;<p></p>
                                            </span></b>
                                        </p>
                                        <p class="MsoListParagraphCxSpFirst" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l1 level1 lfo1">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">To create your Inventory/Offer/Requirement/PO file as per ICBrowser Template, 
                                            click on download template link.
                                            <p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  line-height:14.25pt">
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:
  &quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:
  &quot;Times New Roman&quot;;color:black;mso-fareast-language:EN-IN">Save the template file on your computer&nbsp;<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l1 level1 lfo1">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Template file is of type .xls (Excel worksheet)<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l1 level1 lfo1">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Columns field in Template file are: Part #, Quantity, Make, Comment, Date Code, 
                                            Package and Price in IRS.<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  line-height:14.25pt">
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:
  &quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:
  &quot;Times New Roman&quot;;color:black;mso-fareast-language:EN-IN">You can now edit your data file. Remember, no other 
                                            data should be there&nbsp;except&nbsp;</span><b><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:#0066FF;mso-fareast-language:EN-IN">column heading</span></b><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:#0066FF;mso-fareast-language:EN-IN">&nbsp;</span><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
  &quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;color:black;
  mso-fareast-language:EN-IN">on first row. Other data in first row </span>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:#0066FF;mso-fareast-language:EN-IN;mso-bidi-font-weight:bold">will not be saved</span><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">&nbsp;while uploading.<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l1 level1 lfo1">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]><b style="mso-bidi-font-weight:normal">
                                            <span lang="EN-IN" style="font-size:12.0pt;
  font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
  mso-bidi-font-family:&quot;Times New Roman&quot;;color:#007DFF;mso-fareast-language:
  EN-IN">Stock Status</span><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN"><p></p>
                                            </span></b>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.75in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l1 level2 lfo1">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">A.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Select ‘</span><b><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
  &quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;color:#0066FF;
  mso-fareast-language:EN-IN">Available</span></b><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
  &quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;color:black;
  mso-fareast-language:EN-IN">’ if you are uploading parts list Available to you but not in your stock (Note: This will be 
                                            interpreted as ‘Available’ in ICBrowser database)<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.75in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l1 level2 lfo1">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">B.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Select ‘</span><b><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
  &quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;color:#0066FF;
  mso-fareast-language:EN-IN">In House</span></b><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
  &quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;color:black;
  mso-fareast-language:EN-IN">’ if you are uploading parts list of your own stock (Note: This will be interpreted as ‘In 
                                            House’ in ICBrowser database).&nbsp;<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpLast" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.75in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l1 level2 lfo1">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">C.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Select ‘</span><b><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
  &quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;color:#0066FF;
  mso-fareast-language:EN-IN">OEM Excess</span></b><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
  &quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;color:black;
  mso-fareast-language:EN-IN">’ if you are uploading OEM excess Inventory/Offer file. (Note: This will be interpreted as 
                                            ‘OEM excess’ in ICBrowser database)<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;text-indent:
  21.3pt;line-height:14.25pt">
                                            <span lang="EN-IN" style="font-size:12.0pt;
  font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
  mso-bidi-font-family:&quot;Times New Roman&quot;;color:#0066FF;mso-fareast-language:
  EN-IN;mso-bidi-font-weight:bold">*[Step 4 not required for Requirement file.]</span><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">&nbsp;<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
  14.25pt">
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">
                                            <p>&nbsp;</p>
                                            </span>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="MsoListParagraphCxSpFirst" style="margin:0in;margin-bottom:.0001pt;
  mso-add-space:auto;line-height:14.25pt">
                                            <b>
                                            <span lang="EN-IN" style="font-size:
  12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
  mso-bidi-font-family:&quot;Times New Roman&quot;;color:black;mso-fareast-language:EN-IN">Steps to Upload file edited and 
                                            saved as per ICBrowser Template<p></p>
                                            </span></b>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l0 level1 lfo2">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Click&nbsp;</span><b style="mso-bidi-font-weight:normal"><span lang="EN-IN" style="font-size:12.0pt;
  font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
  mso-bidi-font-family:&quot;Times New Roman&quot;;color:#007DFF;mso-fareast-language:
  EN-IN">Browse</span></b><span lang="EN-IN" style="font-size:12.0pt;font-family:
  &quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:
  &quot;Times New Roman&quot;;color:black;mso-fareast-language:EN-IN"><p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l0 level1 lfo2">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">If your file is ‘NOT’ as per ICBrowser Template click CANCEL (Mapping needs to be 
                                            done manually).<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l0 level1 lfo2">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Select Inventory/Offer/Requirement file and click&nbsp;</span><b 
                                                style="mso-bidi-font-weight:normal"><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:#007DFF;mso-fareast-language:EN-IN">OPEN</span></b><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
  &quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;color:black;
  mso-fareast-language:EN-IN"><p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l0 level1 lfo2">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Click&nbsp;</span><b style="mso-bidi-font-weight:normal"><span lang="EN-IN" style="font-size:12.0pt;
  font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
  mso-bidi-font-family:&quot;Times New Roman&quot;;color:#007DFF;mso-fareast-language:
  EN-IN">Upload</span></b><span lang="EN-IN" style="font-size:12.0pt;font-family:
  &quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:
  &quot;Times New Roman&quot;;color:black;mso-fareast-language:EN-IN">.<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  line-height:14.25pt">
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:
  &quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:
  &quot;Times New Roman&quot;;color:black;mso-fareast-language:EN-IN">Your uploaded file name is displayed for your 
                                            reference.<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpLast" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l0 level1 lfo2">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Click&nbsp;</span><b style="mso-bidi-font-weight:normal"><span lang="EN-IN" style="font-size:12.0pt;
  font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
  mso-bidi-font-family:&quot;Times New Roman&quot;;color:#007DFF;mso-fareast-language:
  EN-IN">Save&nbsp;Mapping</span></b><span lang="EN-IN" style="font-size:12.0pt;
  font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
  mso-bidi-font-family:&quot;Times New Roman&quot;;color:black;mso-fareast-language:EN-IN"> to save your File.&nbsp;<br /> </span>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:#007DFF;mso-fareast-language:EN-IN">*[Step 5 not required for Requirement file.]</span><span lang="EN-IN" style="font-size:12.0pt;font-family:
  &quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:
  &quot;Times New Roman&quot;;color:black;mso-fareast-language:EN-IN"><br />
                                            <br style="mso-special-character:line-break" />
                                            <![if !supportLineBreakNewLine]>
                                            <br style="mso-special-character:line-break" />
                                            <![endif]>
                                            <p></p>
                                            </span>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
  14.25pt">
                                            <b>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Steps to Upload file edited and save in Non ICBrowser Template (your own column 
                                            format)<p></p>
                                            </span></b>
                                        </p>
                                        <p class="MsoListParagraphCxSpFirst" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l2 level1 lfo3">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Click&nbsp;</span><b><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:#0066FF;mso-fareast-language:EN-IN">Browse</span></b><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
  &quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;color:black;
  mso-fareast-language:EN-IN"><p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l2 level1 lfo3">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">If your file is ‘NOT’ as per ICBrowser Template click CANCEL (Mapping needs to be 
                                            done manually)<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l2 level1 lfo3">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Select Inventory/Offer/Requirement /PO file and click on&nbsp;</span><b><span 
                                                lang="EN-IN" style="font-size:12.0pt;
  font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
  mso-bidi-font-family:&quot;Times New Roman&quot;;color:#0066FF;mso-fareast-language:
  EN-IN">OPEN</span></b><span lang="EN-IN" style="font-size:12.0pt;font-family:
  &quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:
  &quot;Times New Roman&quot;;color:black;mso-fareast-language:EN-IN"><p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l2 level1 lfo3">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Click </span><b>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
  &quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;color:#0066FF;
  mso-fareast-language:EN-IN">Upload</span></b><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
  &quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;color:black;
  mso-fareast-language:EN-IN">.<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  line-height:14.25pt">
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:
  &quot;Verdana&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:
  &quot;Times New Roman&quot;;color:black;mso-fareast-language:EN-IN">Your uploaded file is displayed for your reference.<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l2 level1 lfo3">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Your parts list will be displayed on the screen and you can now map the columns. 
                                            This will be interpreted&nbsp;accordingly by ICBrowser to store in database.<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpMiddle" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l2 level1 lfo3">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Map the columns correctly (Note: Mapping of part# and Quantity is Mandatory).<p></p>
                                            </span>
                                        </p>
                                        <p class="MsoListParagraphCxSpLast" style="margin-top:0in;margin-right:0in;
  margin-bottom:0in;margin-left:.25in;margin-bottom:.0001pt;mso-add-space:auto;
  text-indent:-.25in;line-height:14.25pt;mso-list:l2 level1 lfo3">
                                            <![if !supportLists]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:Verdana;mso-bidi-font-family:Verdana;color:black;
  mso-fareast-language:EN-IN"><span style="mso-list:Ignore">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
                                            </span></span><![endif]>
                                            <span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN">Click </span><b style="mso-bidi-font-weight:
  normal"><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:#007DFF;mso-fareast-language:EN-IN">Save Mapping</span></b><span lang="EN-IN" style="font-size:12.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;
  mso-fareast-font-family:&quot;Times New Roman&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;;
  color:black;mso-fareast-language:EN-IN"> to save your File.<br />
                                            <br />
                                            <b>
                                            <br />
                                            </b>
                                            </span>
                                        </p>
                                    </td>
                                </tr>
                            </table>
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
    </asp:Panel>
</div>
