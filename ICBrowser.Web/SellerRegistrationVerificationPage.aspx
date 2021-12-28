<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SellerRegistrationVerificationPage.aspx.cs" Inherits="ICBrowser.Web.SellerRegistrationVerificationPage" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/dpEncodeRequest.js" type="text/javascript"></script>
    <script type="text/javascript">
        function encodeTxnRequest() {
            document.ecom.requestparameter.value =
encodeValue(document.ecom.requestparameter.value);
            document.getElementById('btnSubmit').click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form name="ecom" method="post" action="http://test.timesofmoney.com/direcpay/secure/dpMerchantTransaction.jsp"
    onsubmit="encodeTxnRequest();">
    <input type="hidden" name="custName" value="Test User" runat="server"/>
    <input type="hidden" name="custAddress" value="Mumbai" runat="server"/>
    <input type="hidden" name="custCity" value="Mumbai" runat="server"/>
    <input type="hidden" name="custState" value="Maharashtra" runat="server"/>
    <input type="hidden" name="custPinCode" value="400001" runat="server"/>
    <input type="hidden" name="custCountry" value="IN" runat="server"/>
    <input type="hidden" name="custPhoneNo1" value="91" runat="server"/>
    <input type="hidden" name="custPhoneNo2" value="022" runat="server"/>
    <input type="hidden" name="custPhoneNo3" value="28000000" runat="server"/>
    <input type="hidden" name="custMobileNo" value="9820000000" runat="server"/>
    <input type="hidden" name="custEmailId" value="testuser@gmail.com" runat="server"/>
    <input type="hidden" name="deliveryName" value="Test User" runat="server"/>
    <input type="hidden" name="deliveryAddress" value="Mumbai" runat="server"/>
    <input type="hidden" name="deliveryCity" value="Mumbai" runat="server"/>
    <input type="hidden" name="deliveryState" value="Maharashtra" runat="server"/>
    <input type="hidden" name="deliveryPinCode" value="400234" runat="server"/>
    <input type="hidden" name="deliveryCountry" value="IN" runat="server"/>
    <input type="hidden" name="deliveryPhNo1" value="91" runat="server"/>
    <input type="hidden" name="deliveryPhNo2" value="022" runat="server"/>
    <input type="hidden" name="deliveryPhNo3" value="28000000" runat="server"/>
    <input type="hidden" name="deliveryMobileNo" value="9920000000" runat="server"/>
    <input type="hidden" name="otherNotes" value="test transaction for direcpay" runat="server"/>
    <input type="hidden" name="editAllowed”" value="Y" runat="server"/>
    <input type="hidden" name="requestparameter" value="200904281000001|DOM|IND|INR|10|test-order|others|www.url.com/success.html| www.url.com/fail.html" runat="server"/>
    <input type="Button" name="btnSubmit" value="Submit" />
    </form>
    <asp:Label ID="lblSellerName" runat="server" ></asp:Label>

</asp:Content>
