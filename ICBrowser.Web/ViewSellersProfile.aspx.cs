using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Text;



namespace ICBrowser.Web
{
    public partial class ViewSellersProfile : BasePage
    {
        public Guid ViewUserProfileId;
        public DateTime membershipDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {                
                lblMembershipExpiry.Visible = false;
                MembershipUser userToLogin = Membership.GetUser();
                Guid userid = (Guid)userToLogin.ProviderUserKey;

                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(userid);


                if (Request.QueryString["UserID"] != null)
                {
                    ViewUserProfileId = new Guid(Request.QueryString["UserId"]);
                }

                if (userToLogin != null)
                {
                    InventoryGridDetails sellersObj = new InventoryGridDetails();
                    Common.UserProfile objuserpro = new Common.UserProfile();
                    UserProfileDetails profiledetais = new UserProfileDetails();

                    objuserpro = profiledetais.GetUserProfileDetails(userid);
                    int memTypeId = 0;
                    memTypeId = objuserpro.TypeOfMembership;
                    if (memTypeId > 0 || Admin.IsAdmin)
                    {
                        if (Admin.IsAdmin)
                        {
                            btnback.Visible = true;
                        }

                        if (!Page.IsPostBack)
                        {
                            BindCountry();
                            SellerProfileDetails();
                            lnkCompnameSave.Visible = false;
                            lnkAddressDetailsSave.Visible = false;
                            lnkContactDetailsSave.Visible = false;
                            lnkOtherDetailsSave.Visible = false;
                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", true);
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", true);
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

        }

        public void BindCountry()
        {
            // Read list of countries from XML into dataset
            DataSet dsCountries = new DataSet();
            string filepath = Server.MapPath("/data/List Of Countries.xml");
            dsCountries.ReadXml(filepath);

            // Bind dropdownlist of 'Primary Country' with list of countries
            ddlPrimaryCountry.DataSource = dsCountries.Tables[0];
            ddlPrimaryCountry.DataTextField = "Name";
            ddlPrimaryCountry.DataValueField = "CountryID";
            ddlPrimaryCountry.DataBind();

            // Bind dropdownlist of 'Secondary Country' with list of countries
            ddlSecondaryCountry.DataSource = dsCountries.Tables[0];
            ddlSecondaryCountry.DataTextField = "Name";
            ddlSecondaryCountry.DataValueField = "CountryID";
            ddlSecondaryCountry.DataBind();

            //Bind dropdownlist of 'Bar Country' with list of countries
            dsCountries.Tables[0].Rows.RemoveAt(0);
            chkbxlstBarCountry.DataSource = dsCountries.Tables[0];
            chkbxlstBarCountry.DataTextField = "Name";
            chkbxlstBarCountry.DataValueField = "CountryID";
            chkbxlstBarCountry.DataBind();


        }
        //to get Seller details
        public void SellerProfileDetails()
        {
            try
            {
                Guid currUserId = new Guid();
                var membershipUser = Membership.GetUser();
                if (membershipUser != null)
                    if (membershipUser.ProviderUserKey != null)
                        currUserId = new Guid(membershipUser.ProviderUserKey.ToString());


                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(currUserId);


                UserProfileDetails profiledetais = new UserProfileDetails();

                Common.UserProfile Profile = new Common.UserProfile();

                if (Admin.IsAdmin)
                {
                    Profile = profiledetais.GetUserProfileDetails(ViewUserProfileId);
                    lblUsername.Text = Profile.UserName;
                }
                else
                {
                    Profile = profiledetais.GetUserProfileDetails(currUserId);
                    lblUsername.Text = Profile.UserName;
                }

                lblcompnamevalue.Text = Profile.CompanyName;
                string ContactName = Profile.ContactName;
                string lastname = ContactName.Substring(ContactName.LastIndexOf(' ') + 1);
                string firstname = ContactName.Substring(0, ContactName.IndexOf(" ")).Trim();
                lblFirstNameValue.Text = firstname;
                lblLastNameValue.Text = lastname;
                lblOwnersnamevalue.Text = Profile.OwnerName;

                lblEmailPreferenceValue.Visible = true;
                chkbxEmailPreference.Visible = false;
                // ddlEmailPreference.Visible = false;
                //Set lblEmailPreference to Text values 
                if (Profile.EmailPreference == 1)
                {
                    lblEmailPreferenceValue.Text = "Yes";
                }
                else
                {
                    lblEmailPreferenceValue.Text = "No";
                }


                lblAddress1value.Text = Profile.PrimaryAddress;
                lblAddress2value.Text = Profile.SecondaryAddress;

                lblPrimaryCountryvalue.Text = Profile.PrimaryCountry;
                lblSecondaryCountryValue.Text = Profile.SecondaryCountry;
                lblEmailvalue.Text = Profile.email;

                string last2 = "";
                string first2 = "";
                string str2 = "";
                str2 = Profile.Mobile;
                if (!string.IsNullOrEmpty(str2))
                {
                    last2 = str2.Substring(str2.LastIndexOf('-') + 1);
                    first2 = str2.Substring(0, str2.IndexOf("-")).Trim();
                }
                lblMobCntcd.Text = first2;
                lblMobno.Text = last2;

                string str = Profile.LandLine;
                string last = str.Substring(str.LastIndexOf('-') + 1);
                // input.Substring(input.IndexOf("(") + 1, input.IndexOf(")") - input.IndexOf("(") - 1); 
                int start = str.IndexOf("-");
                int stop = str.LastIndexOf('-');
                string middle = "";
                string first = "";


                if (start > 0 || stop > 0)
                {
                    middle = str.Substring(start + 1, stop - start - 1);
                    first = str.Substring(0, str.IndexOf("-")).Trim();
                    plus1.Visible = true;
                    dash1.Visible = true;
                    dash2.Visible = true;

                }


                lblPhonevalue.Text = last;
                lblCtycd.Text = middle;
                lblCntCd.Text = first;
                lblExtensionvalue.Text = Profile.Extension;
                //lblMobilevalue.Text = Profile.Mobile;
                string str1 = Profile.FaxNumber;
                string last1 = "";

                // input.Substring(input.IndexOf("(") + 1, input.IndexOf(")") - input.IndexOf("(") - 1); 
                int start1 = 0;
                int stop1 = 0;
                string middle1 = "";
                string first1 = "";
                if (str1 != null)
                {
                    start1 = str1.IndexOf("-");
                    stop1 = str1.LastIndexOf('-');
                    first1 = str1.Substring(0, str1.IndexOf("-")).Trim();
                    last1 = str1.Substring(str1.LastIndexOf('-') + 1);
                    if (start1 > 0 || stop1 > 0)
                    {
                        middle1 = str1.Substring(start1 + 1, stop1 - start1 - 1);
                        plus2.Visible = true;
                        dash3.Visible = true;
                        dash4.Visible = true;
                    }

                }

                lblFaxvalue.Text = last1;
                lblCityCode1.Text = middle1;
                lblCountrycode1.Text = first1;
                //lblFaxvalue.Text = Profile.FaxNumber;
                lblPanNumberValue.Text = Profile.PanNumber;
                lblPrimaryStatevalue.Text = Profile.PrimaryState;
                lblSecondaryStateValue.Text = Profile.SecondaryState;
                lblPrimaryCityvalue.Text = Profile.PrimaryCity;
                lblSecondaryCityvalue.Text = Profile.SecondaryCity;
                lblWebsiteurlvalue.Text = Profile.Website;
                lblPriamryZipCodeValue.Text = Profile.PrimaryZip;
                lblSecondaryZipCodeValue.Text = Profile.SecondaryZip;
                lblSpecializaionValue.Text = Profile.Specialization;
                //lblCurrencyvalue.Text = Profile.Currency;
                lblMembershiptypeValue.Text = Profile.MembershipTypeName;
                lblLastUpdatedvalue.Text = String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(Profile.ModifiedDate));
                lblMembershipLastDateValue.Text = String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(Profile.MembershipCreation));//membership create date
                lblMembershipPeriodValue.Text = Convert.ToString(Profile.Duration);
                Calendar1.Visible = false;
                lbltxtQQIdText.Text = Profile.QQId;
                lbltxtSkypeIdText.Text = Profile.SkypeId;
                lbltxtMSNIdText.Text = Profile.MSNId;
                List<ICBrowser.Common.UserProfile> lstBarCountry = new List<ICBrowser.Common.UserProfile>();
                lstBarCountry = profiledetais.GetUserBarCountryDetails(currUserId);
                StringBuilder sb = new StringBuilder();
                int count = 0;
                foreach (var barredcountry in lstBarCountry)
                {
                    if (count < 3)
                    {
                        sb.Append(barredcountry.Barcountry + ", ");
                        count = count + 1;
                    }
                    else 
                    {
                        break;
                    }
                    
                }
                lblBarredCountryValue.Text = sb.ToString();
                lblBarredCountryValue.Visible = true;
                if (lstBarCountry.Count > 0)
                {
                    lbtnPreview.Visible = true;
                }

                if (Profile.TypeOfMembership > 0)
                {

                    lblPaymentOptionValue.Text = Convert.ToString(Profile.PaymentOption);

                    TimeSpan t = Convert.ToDateTime(lblMembershipLastDateValue.Text) - Convert.ToDateTime(DateTime.Now.ToString());
                    int timediff = t.Days;

                    if (timediff <= 5)
                    {
                        btnMembership.Visible = true;
                    }

                    if (lblPaymentOptionValue.Text == "1")
                    {
                        lblPaymentOptionValue.Text = "Online";
                    }
                    else
                    {
                        lblPaymentOptionValue.Text = "Offline";
                    }

                    lblPaymentStatusValue.Text = Convert.ToString(Profile.PaymentStatus);
                    string isApproved = Convert.ToString(Profile.IsApproved);

                    if (lblPaymentStatusValue.Text != "")
                    {

                        if (lblPaymentStatusValue.Text == "True" && isApproved == "True")
                        {
                            lblPaymentStatusValue.Text = "Accepted";

                        }
                        else
                        {
                            lblPaymentStatusValue.Text = "In Progress";
                            divMembership.Visible = false;

                        }
                    }
                    else
                    {
                        btnMembership.Visible = true;
                        divPayment.Visible = false;

                        if (Admin.IsAdmin)
                        {
                            divMembership.Visible = true;
                        }
                        else
                        {
                            if (timediff <= 5)
                            {
                                divMembership.Visible = true;
                            }
                            else
                            {
                                divMembership.Visible = false;
                            }
                        }
                    }

                }

                if (Profile.TypeOfMembership >= 1)
                {
                    lblMembershipPeriod.Visible = false;
                    lblMembershipPeriodValue.Visible = false;
                }

                if (Profile.TypeOfMembership == 1)
                {
                    lblMembershipLastDate.Visible = false;
                    lblMembershipLastDateValue.Visible = false;
                }

                if (lblCntCd.Text == "")
                {
                    plus1.Visible = false;
                }
                else
                {
                    plus1.Visible = true;
                }
                if (lblCtycd.Text == "")
                {
                    dash1.Visible = false;
                    dash2.Visible = false;

                }
                else
                {
                    dash1.Visible = true;
                    dash2.Visible = true;
                }
                if (lblCountrycode1.Text == "")
                {
                    plus2.Visible = false;
                }
                else
                {
                    plus2.Visible = true;
                }
                if (lblCityCode1.Text == "")
                {
                    dash3.Visible = false;
                    dash4.Visible = false;

                }
                else
                {
                    dash3.Visible = true;
                    dash4.Visible = true;
                }

                if (lblMobCntcd.Text == "" || lblMobno.Text == "")
                {
                    Plus.Visible = false;
                    dash.Visible = false;
                }
                else
                {
                    Plus.Visible = true;
                    dash.Visible = true;
                }

                //if (lblMobno.Text == "")
                //{
                //    dash.Visible = false;
                //}
                //else
                //{
                //    dash.Visible = true;
                //}

                //else
                //{
                //    btnMembership.Visible = true;
                //    divPayment.Visible = false;

                //    if (Profile.TypeOfMembership == 1 && Profile.PaymentStatus ==null)
                //    {
                //        divMembership.Visible = false;
                //    }

                //}



            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

        }

        public void GetSellersProfile()
        {
            try
            {

                Guid currUserId = new Guid();
                var membershipUser = Membership.GetUser();
                if (membershipUser != null)
                    if (membershipUser.ProviderUserKey != null)
                        currUserId = new Guid(membershipUser.ProviderUserKey.ToString());


                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(currUserId);

                BuyersDataRequirement buyerdata = new BuyersDataRequirement();
                Common.UserProfile userProfile = new Common.UserProfile();

                if (Admin.IsAdmin)
                {
                    userProfile.UserID = ViewUserProfileId;
                }
                else
                {
                    userProfile.UserID = currUserId;
                }
                userProfile.CompanyName = lblcompnamevalue.Text;
                userProfile.OwnerName = lblOwnersnamevalue.Text;
                string strContactName = string.Format(@"{0} {1}", lblFirstNameValue.Text, lblLastNameValue.Text);
                userProfile.ContactName = strContactName;

                userProfile.PrimaryAddress = lblAddress1value.Text;
                userProfile.SecondaryAddress = lblAddress2value.Text;
                userProfile.PrimaryCity = lblPrimaryCityvalue.Text;
                userProfile.SecondaryCity = lblSecondaryCityvalue.Text;
                userProfile.PrimaryState = lblPrimaryStatevalue.Text;
                userProfile.SecondaryState = lblSecondaryStateValue.Text;
                userProfile.PrimaryZip = lblPriamryZipCodeValue.Text;
                userProfile.SecondaryZip = lblSecondaryZipCodeValue.Text;
                userProfile.PrimaryCountry = lblPrimaryCountryvalue.Text;
                if (ddlSecondaryCountry.SelectedIndex == 0)
                {
                    lblSecondaryCountryValue.Visible = false;
                }
                else
                {
                    userProfile.SecondaryCountry = lblSecondaryCountryValue.Text;
                }
                userProfile.MembershipTypeName = lblMembershiptypeValue.Text;
                userProfile.Duration = Convert.ToInt32(lblMembershipPeriodValue.Text);
                // userProfile.EmailPreference = Convert.ToInt32(ddlEmailPreference.SelectedValue);
                //**********
                userProfile.EmailPreference = Convert.ToInt32(chkbxEmailPreference.Checked);

                //cmpdet.PaymentOption =lblPaymentOptionValue.Text;
                //cmpdet.PaymentStatus =Convert.ToInt32(lblPaymentStatusValue.Text);

                userProfile.email = lblEmailvalue.Text;
                userProfile.Website = lblWebsiteurlvalue.Text;
                string str3 = "";
                if (lblMobno.Text != "")
                {
                    str3 = string.Format(@"{0}-{1}", lblMobCntcd.Text, lblMobno.Text);
                }
                userProfile.Mobile = str3;
                string str1 = string.Format(@"{0}-{1}-{2}", lblCntCd.Text, lblCtycd.Text, lblPhonevalue.Text);
                userProfile.LandLine = str1;


                userProfile.Extension = lblExtensionvalue.Text;
                //userProfile.Mobile = lblMobilevalue.Text;
                userProfile.PanNumber = lblPanNumberValue.Text;

                if (lblFaxvalue.Text != "")
                {
                    string str2 = string.Format(@"{0}-{1}-{2}", lblCountrycode1.Text, lblCityCode1.Text, lblFaxvalue.Text);
                    userProfile.FaxNumber = str2;
                }

                userProfile.Specialization = lblSpecializaionValue.Text;
                //userProfile.Currency = lblCurrencyvalue.Text;

                userProfile.QQId = lbltxtQQIdText.Text;
                userProfile.SkypeId = lbltxtSkypeIdText.Text;
                userProfile.MSNId = lbltxtMSNIdText.Text;

                lblEmailPreferenceValue.Visible = true;
                chkbxEmailPreference.Visible = false;
                // ddlEmailPreference.Visible = false;
                //Set lblEmailPreference to Text values 
                if (userProfile.EmailPreference == 1)
                {
                    lblEmailPreferenceValue.Text = "Yes";
                }
                else
                {
                    lblEmailPreferenceValue.Text = "No";
                }

                UserProfileDetails profile = new UserProfileDetails();

                //to update Seller details
                profile.UpdateUsersProfile(userProfile);
                //SellerProfileDetails();

                string Updatemsg;
                Updatemsg = "alert('Profile Updated.')";
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", Updatemsg, true);



            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        //Update for other,address,company details

        public void GetSellersProfileDetails()
        {
            try
            {

                Guid currUserId = new Guid();
                var membershipUser = Membership.GetUser();
                if (membershipUser != null)
                    if (membershipUser.ProviderUserKey != null)
                        currUserId = new Guid(membershipUser.ProviderUserKey.ToString());


                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(currUserId);

                BuyersDataRequirement buyerdata = new BuyersDataRequirement();
                Common.UserProfile userProfile = new Common.UserProfile();

                if (Admin.IsAdmin)
                {
                    userProfile.UserID = ViewUserProfileId;
                }
                else
                {
                    userProfile.UserID = currUserId;
                }
                userProfile.CompanyName = lblcompnamevalue.Text;
                userProfile.OwnerName = lblOwnersnamevalue.Text;
                string strContactName = string.Format(@"{0} {1}", lblFirstNameValue.Text, lblLastNameValue.Text);
                userProfile.ContactName = strContactName;

                userProfile.PrimaryAddress = lblAddress1value.Text;
                userProfile.SecondaryAddress = lblAddress2value.Text;
                userProfile.PrimaryCity = lblPrimaryCityvalue.Text;
                userProfile.SecondaryCity = lblSecondaryCityvalue.Text;
                userProfile.PrimaryState = lblPrimaryStatevalue.Text;
                userProfile.SecondaryState = lblSecondaryStateValue.Text;
                userProfile.PrimaryZip = lblPriamryZipCodeValue.Text;
                userProfile.SecondaryZip = lblSecondaryZipCodeValue.Text;
                userProfile.PrimaryCountry = lblPrimaryCountryvalue.Text;
                if (ddlSecondaryCountry.SelectedIndex == 0)
                {
                    lblSecondaryCountryValue.Visible = false;
                }
                else
                {
                    userProfile.SecondaryCountry = lblSecondaryCountryValue.Text;
                }
                userProfile.MembershipTypeName = lblMembershiptypeValue.Text;
                userProfile.Duration = Convert.ToInt32(lblMembershipPeriodValue.Text);
                // userProfile.EmailPreference = Convert.ToInt32(ddlEmailPreference.SelectedValue);
                //**********
                //userProfile.EmailPreference = Convert.ToInt32(chkbxEmailPreference.Checked);
                if (lblEmailPreferenceValue.Text == "Yes")
                {
                    userProfile.EmailPreference = Convert.ToInt32(true);
                }

                else
                {
                    userProfile.EmailPreference = Convert.ToInt32(false);
                }
                //cmpdet.PaymentOption =lblPaymentOptionValue.Text;
                //cmpdet.PaymentStatus =Convert.ToInt32(lblPaymentStatusValue.Text);

                userProfile.email = lblEmailvalue.Text;
                userProfile.Website = lblWebsiteurlvalue.Text;
                string str3 = "";
                if (lblMobno.Text != "")
                {
                    str3 = string.Format(@"{0}-{1}", lblMobCntcd.Text, lblMobno.Text);
                }
                userProfile.Mobile = str3;
                string str1 = string.Format(@"{0}-{1}-{2}", lblCntCd.Text, lblCtycd.Text, lblPhonevalue.Text);
                userProfile.LandLine = str1;


                userProfile.Extension = lblExtensionvalue.Text;
                //userProfile.Mobile = lblMobilevalue.Text;
                userProfile.PanNumber = lblPanNumberValue.Text;

                if (lblFaxvalue.Text != "")
                {
                    string str2 = string.Format(@"{0}-{1}-{2}", lblCountrycode1.Text, lblCityCode1.Text, lblFaxvalue.Text);
                    userProfile.FaxNumber = str2;
                }

                userProfile.Specialization = lblSpecializaionValue.Text;
                //userProfile.Currency = lblCurrencyvalue.Text;

                userProfile.QQId = lbltxtQQIdText.Text;
                userProfile.SkypeId = lbltxtSkypeIdText.Text;
                userProfile.MSNId = lbltxtMSNIdText.Text;

                lblEmailPreferenceValue.Visible = true;
                chkbxEmailPreference.Visible = false;
                // ddlEmailPreference.Visible = false;
                //Set lblEmailPreference to Text values 
                if (userProfile.EmailPreference == 1)
                {
                    lblEmailPreferenceValue.Text = "Yes";
                }
                else
                {
                    lblEmailPreferenceValue.Text = "No";
                }

                UserProfileDetails profile = new UserProfileDetails();

                //to update Seller details
                profile.UpdateUsersProfile(userProfile);
                //SellerProfileDetails();

                string Updatemsg;
                Updatemsg = "alert('Profile Updated.')";
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", Updatemsg, true);



            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void lnkcompname_Click1(object sender, EventArgs e)
        {
            try
            {
                lblMembershipExpiry.Visible = false;
                if (lnkAddressDetailsSave.Visible == true)
                {
                    lnkAddressDetailsSave.Visible = false;
                    lnkAddressDetails.Visible = true;
                }

                if (lnkAddressDetailsCancel.Visible == true)
                {
                    lnkAddressDetailsCancel.Visible = false;
                }
                if (lnkContactDetailsCancel.Visible == true)
                {
                    lnkContactDetailsCancel.Visible = false;
                }
                if (lnkOtherDetailsCancel.Visible == true)
                {
                    lnkOtherDetailsCancel.Visible = false;
                }

                if (lnkContactDetailsSave.Visible == true)
                {
                    lnkContactDetailsSave.Visible = false;
                    lnkContactDetails.Visible = true;
                }

                if (lnkOtherDetailsSave.Visible == true)
                {
                    lnkOtherDetailsSave.Visible = false;
                    lnkOtherDetails.Visible = true;
                }

                btnGenerateCode.Visible = false;
                txtGenerateCode.Visible = false;


                lblEmailvalue.Visible = true;
                txtEmail.Visible = false;
                //email prefernece               
                lblEmailPreferenceValue.Visible = true;
                //  ddlEmailPreference.Visible = false;
                chkbxEmailPreference.Visible = false;

                lnkcompname.Visible = false;
                lnkCompnameSave.Visible = true;
                lnkcompnameCancel.Visible = true;

                txtcompnamevalue.Visible = true;
                txtcompnamevalue.Text = lblcompnamevalue.Text;
                lblcompnamevalue.Visible = false;

                txtOwnersnamevalue.Visible = true;
                txtOwnersnamevalue.Text = lblOwnersnamevalue.Text;
                lblOwnersnamevalue.Visible = false;

                txtFirstname.Visible = true;
                txtFirstname.Text = lblFirstNameValue.Text;
                lblFirstNameValue.Visible = false;

                txtLastName.Visible = true;
                txtLastName.Text = lblLastNameValue.Text;
                lblLastNameValue.Visible = false;


                lblAddress1value.Visible = true;
                txtAddress1.Visible = false;
                lblAddress2value.Visible = true;
                txtAddress2.Visible = false;

                lblPrimaryCountryvalue.Visible = true;
                ddlPrimaryCountry.Visible = false;
                if (ddlSecondaryCountry.SelectedIndex == 0)
                {
                    lblSecondaryCountryValue.Visible = false;
                }
                else
                {
                    lblSecondaryCountryValue.Visible = true;
                }
                ddlSecondaryCountry.Visible = false;
                lblPrimaryStatevalue.Visible = true;
                txtPrimaryState.Visible = false;
                lblSecondaryStateValue.Visible = true;
                txtSecondaryState.Visible = false;
                lblPrimaryCityvalue.Visible = true;
                txtPrimaryCity.Visible = false;
                lblSecondaryCityvalue.Visible = true;
                txtSecondaryCity.Visible = false;
                lblPriamryZipCodeValue.Visible = true;
                txtPriamryZipCode.Visible = false;
                lblSecondaryZipCodeValue.Visible = true;
                txtSecondaryZipCode.Visible = false;


                lblCtycd.Visible = true;
                txtCityCode.Visible = false;
                lblCityCode1.Visible = true;
                txtCityCode1.Visible = false;
                lblCntCd.Visible = true;
                txtCountryCode.Visible = false;
                lblCountrycode1.Visible = true;
                txtCountryCode1.Visible = false;




                lblWebsiteurlvalue.Visible = true;
                txtWebsiteurl.Visible = false;

                lblMobno.Visible = true;
                txtmobno.Visible = false;
                lblMobCntcd.Visible = true;
                txtMobCntcd.Visible = false;

                lblPhonevalue.Visible = true;
                txtPhone.Visible = false;
                lblExtensionvalue.Visible = true;
                txtExtension.Visible = false;
                //lblMobilevalue.Visible = true;
                //txtMobile.Visible = false;
                lblFaxvalue.Visible = true;
                txtFax.Visible = false;

                lbltxtMSNIdText.Visible = true;
                txtMSNId.Visible = false;
                lbltxtQQIdText.Visible = true;
                txtQQId.Visible = false;
                lbltxtSkypeIdText.Visible = true;
                txtSkypeId.Visible = false;

                txtPanNumber.Visible = false;
                lblPanNumberValue.Visible = true;

                lblSpecializaionValue.Visible = true;
                txtSpecializaion.Visible = false;
                //lblCurrencyvalue.Visible = true;
                //ddlCurreny.Visible = false;

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

        }

        protected void lnkCompnameSave_Click1(object sender, EventArgs e)
        {
            try
            {
                lblMembershipExpiry.Visible = false;
                lnkcompname.Visible = true;
                lnkCompnameSave.Visible = false;
                lnkcompnameCancel.Visible = false;

                txtcompnamevalue.Visible = false;
                lblcompnamevalue.Text = txtcompnamevalue.Text.Trim();
                lblcompnamevalue.Visible = true;

                txtOwnersnamevalue.Visible = false;
                lblOwnersnamevalue.Text = txtOwnersnamevalue.Text.Trim();
                lblOwnersnamevalue.Visible = true;

                txtFirstname.Visible = false;
                lblFirstNameValue.Text = txtFirstname.Text.Trim();
                lblFirstNameValue.Visible = true; ;

                txtLastName.Visible = false;
                lblLastNameValue.Text = txtLastName.Text.Trim();
                lblLastNameValue.Visible = true; ;



                GetSellersProfileDetails();

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void lnkcompnameCancel_Click1(object sender, EventArgs e)
        {
            try
            {
                lblMembershipExpiry.Visible = false;
                lnkcompname.Visible = true;
                lnkcompnameCancel.Visible = false;
                lnkCompnameSave.Visible = false;

                lblcompnamevalue.Visible = true;
                txtcompnamevalue.Visible = false;
                lblOwnersnamevalue.Visible = true;
                txtOwnersnamevalue.Visible = false;
                lblFirstNameValue.Visible = true;
                lblLastNameValue.Visible = true;
                txtFirstname.Visible = false;
                txtLastName.Visible = false;

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void lnkAddressDetails_Click1(object sender, EventArgs e)
        {
            try
            {
                lblMembershipExpiry.Visible = false;
                if (lnkCompnameSave.Visible == true)
                {
                    lnkCompnameSave.Visible = false;
                    lnkcompname.Visible = true;
                }

                if (lnkContactDetailsSave.Visible == true)
                {
                    lnkContactDetailsSave.Visible = false;
                    lnkContactDetails.Visible = true;
                }

                if (lnkOtherDetailsSave.Visible == true)
                {
                    lnkOtherDetailsSave.Visible = false;
                    lnkOtherDetails.Visible = true;
                }

                if (lnkcompnameCancel.Visible == true)
                {
                    lnkcompnameCancel.Visible = false;
                }
                if (lnkContactDetailsCancel.Visible == true)
                {
                    lnkContactDetailsCancel.Visible = false;
                }
                if (lnkOtherDetailsCancel.Visible == true)
                {
                    lnkOtherDetailsCancel.Visible = false;
                }

                btnGenerateCode.Visible = false;
                txtGenerateCode.Visible = false;

                lblEmailvalue.Visible = true;
                txtEmail.Visible = false;
                //email prefernece
                //ddlEmailPreference.Visible = false;
                chkbxEmailPreference.Visible = false;
                lblEmailPreferenceValue.Visible = true;

                lnkAddressDetails.Visible = false;
                lnkAddressDetailsCancel.Visible = true;
                lnkAddressDetailsSave.Visible = true;

                txtAddress1.Visible = true;
                txtAddress1.Text = lblAddress1value.Text;
                lblAddress1value.Visible = false;

                txtAddress2.Visible = true;
                txtAddress2.Text = lblAddress2value.Text;
                lblAddress2value.Visible = false;

                txtPrimaryCity.Visible = true;
                txtPrimaryCity.Text = lblPrimaryCityvalue.Text;
                lblPrimaryCityvalue.Visible = false;

                txtSecondaryCity.Visible = true;
                txtSecondaryCity.Text = lblSecondaryCityvalue.Text;
                lblSecondaryCityvalue.Visible = false;

                txtPriamryZipCode.Visible = true;
                txtPriamryZipCode.Text = lblPriamryZipCodeValue.Text;
                lblPriamryZipCodeValue.Visible = false;

                txtSecondaryZipCode.Visible = true;
                txtSecondaryZipCode.Text = lblSecondaryZipCodeValue.Text;
                lblSecondaryZipCodeValue.Visible = false;

                txtPrimaryState.Visible = true;
                txtPrimaryState.Text = lblPrimaryStatevalue.Text;
                lblPrimaryStatevalue.Visible = false;

                txtSecondaryState.Visible = true;
                txtSecondaryState.Text = lblSecondaryStateValue.Text;
                lblSecondaryStateValue.Visible = false;

                string pricountryname = lblPrimaryCountryvalue.Text.Trim();

                DataSet dsCountries = new DataSet();
                string filepath = Server.MapPath("/data/List Of Countries.xml");
                dsCountries.ReadXml(filepath);
                object selectedvalue = null;

                for (int i = 0; i < dsCountries.Tables[0].Rows.Count; i++)
                {
                    object value = dsCountries.Tables[0].Rows[i][0];
                    if (value.Equals(pricountryname))
                    {
                        selectedvalue = dsCountries.Tables[0].Rows[i][1];
                        break;
                    }
                }
                if (selectedvalue != null)
                {
                    ddlPrimaryCountry.SelectedValue = selectedvalue.ToString();

                }
                else
                {
                    ddlPrimaryCountry.SelectedValue = "0";

                }
                string Seccountryname = lblSecondaryCountryValue.Text.Trim();
                object selectedvalue1 = null;
                for (int i = 0; i < dsCountries.Tables[0].Rows.Count; i++)
                {
                    object value = dsCountries.Tables[0].Rows[i][0];
                    if (value.Equals(Seccountryname))
                    {
                        selectedvalue1 = dsCountries.Tables[0].Rows[i][1];
                        break;
                    }
                }

                if (selectedvalue1 != null)
                {
                    ddlSecondaryCountry.SelectedValue = selectedvalue1.ToString();

                }
                else
                {
                    ddlSecondaryCountry.SelectedValue = "0";

                }
                ddlPrimaryCountry.Visible = true;
                //ddlPrimaryCountry.SelectedItem.Text = lblPrimaryCountryvalue.Text;
                lblPrimaryCountryvalue.Visible = false;

                ddlSecondaryCountry.Visible = true;

                //ddlSecondaryCountry.SelectedItem.Text = lblSecondaryCountryValue.Text;
                lblSecondaryCountryValue.Visible = false;

                txtPanNumber.Visible = true;
                txtPanNumber.Text = lblPanNumberValue.Text;
                lblPanNumberValue.Visible = false;

                lblCtycd.Visible = true;
                txtCityCode.Visible = false;
                lblCityCode1.Visible = true;
                txtCityCode1.Visible = false;
                lblCntCd.Visible = true;
                txtCountryCode.Visible = false;
                lblCountrycode1.Visible = true;
                txtCountryCode1.Visible = false;

                lblWebsiteurlvalue.Visible = true;
                txtWebsiteurl.Visible = false;

                lblMobno.Visible = true;
                txtmobno.Visible = false;
                lblMobCntcd.Visible = true;
                txtMobCntcd.Visible = false;


                lblPhonevalue.Visible = true;
                txtPhone.Visible = false;
                lblExtensionvalue.Visible = true;
                txtExtension.Visible = false;
                //lblMobilevalue.Visible = true;
                //txtMobile.Visible = false;
                lblFaxvalue.Visible = true;
                txtFax.Visible = false;

                lbltxtMSNIdText.Visible = true;
                txtMSNId.Visible = false;
                lbltxtQQIdText.Visible = true;
                txtQQId.Visible = false;
                lbltxtSkypeIdText.Visible = true;
                txtSkypeId.Visible = false;

                lblcompnamevalue.Visible = true;
                txtcompnamevalue.Visible = false;
                lblOwnersnamevalue.Visible = true;
                txtOwnersnamevalue.Visible = false;

                lblFirstNameValue.Visible = true;
                lblLastNameValue.Visible = true;
                txtFirstname.Visible = false;
                txtLastName.Visible = false;

                lblSpecializaionValue.Visible = true;
                txtSpecializaion.Visible = false;

                //lblCurrencyvalue.Visible = true;
                //ddlCurreny.Visible = false;



            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void lnkAddressDetailsSave_Click1(object sender, EventArgs e)
        {
            try
            {
                if (ddlPrimaryCountry.SelectedItem.Text == "INDIA" && txtPanNumber.Text == "")
                {
                    string msgg;
                    msgg = "alert('Taxpayer Identification Number is mandatory for India.')";
                    ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", msgg, true);

                }
                else
                {

                    lnkAddressDetails.Visible = true;
                    lnkAddressDetailsCancel.Visible = false;
                    lnkAddressDetailsSave.Visible = false;

                    txtAddress1.Visible = false;
                    lblAddress1value.Text = txtAddress1.Text.Trim();
                    lblAddress1value.Visible = true;

                    txtAddress2.Visible = false;
                    lblAddress2value.Text = txtAddress2.Text.Trim();
                    lblAddress2value.Visible = true;

                    txtPrimaryCity.Visible = false;
                    lblPrimaryCityvalue.Text = txtPrimaryCity.Text.Trim();
                    lblPrimaryCityvalue.Visible = true;

                    txtSecondaryCity.Visible = false;
                    lblSecondaryCityvalue.Text = txtSecondaryCity.Text.Trim();
                    lblSecondaryCityvalue.Visible = true;

                    txtPriamryZipCode.Visible = false;
                    lblPriamryZipCodeValue.Text = txtPriamryZipCode.Text.Trim();
                    lblPriamryZipCodeValue.Visible = true;

                    txtSecondaryZipCode.Visible = false;
                    lblSecondaryZipCodeValue.Text = txtSecondaryZipCode.Text.Trim();
                    lblSecondaryZipCodeValue.Visible = true;

                    txtPrimaryState.Visible = false;
                    lblPrimaryStatevalue.Text = txtPrimaryState.Text.Trim();
                    lblPrimaryStatevalue.Visible = true;

                    txtSecondaryState.Visible = false;
                    lblSecondaryStateValue.Text = txtSecondaryState.Text.Trim();
                    lblSecondaryStateValue.Visible = true;

                    ddlPrimaryCountry.Visible = false;
                    lblPrimaryCountryvalue.Text = ddlPrimaryCountry.SelectedItem.Text;
                    lblPrimaryCountryvalue.Visible = true;

                    ddlSecondaryCountry.Visible = false;

                    lblSecondaryCountryValue.Text = ddlSecondaryCountry.SelectedItem.Text;
                    lblSecondaryCountryValue.Visible = true;

                    txtPanNumber.Visible = false;
                    lblPanNumberValue.Text = txtPanNumber.Text.Trim();
                    lblPanNumberValue.Visible = true;



                    GetSellersProfileDetails();
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void lnkAddressDetailsCancel_Click1(object sender, EventArgs e)
        {
            try
            {
                lnkAddressDetails.Visible = true;
                lnkAddressDetailsSave.Visible = false;
                lnkAddressDetailsCancel.Visible = false;

                lblAddress1value.Visible = true;
                txtAddress1.Visible = false;
                lblAddress2value.Visible = true;
                txtAddress2.Visible = false;
                lblPrimaryCountryvalue.Visible = true;
                ddlPrimaryCountry.Visible = false;
                if (ddlSecondaryCountry.SelectedIndex == 0)
                {
                    lblSecondaryCountryValue.Visible = false;
                }
                else
                {
                    lblSecondaryCountryValue.Visible = true;
                }

                ddlSecondaryCountry.Visible = false;
                lblPrimaryStatevalue.Visible = true;
                txtPrimaryState.Visible = false;
                lblSecondaryStateValue.Visible = true;
                txtSecondaryState.Visible = false;
                lblPrimaryCityvalue.Visible = true;
                txtPrimaryCity.Visible = false;
                lblSecondaryCityvalue.Visible = true;
                txtSecondaryCity.Visible = false;
                lblPriamryZipCodeValue.Visible = true;
                txtPriamryZipCode.Visible = false;
                lblSecondaryZipCodeValue.Visible = true;
                txtSecondaryZipCode.Visible = false;
                txtPanNumber.Visible = false;
                lblPanNumberValue.Visible = true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void lnkContactDetails_Click1(object sender, EventArgs e)
        {
            try
            {
                lblMembershipExpiry.Visible = false;
                btnGenerateCode.Visible = true;
                txtGenerateCode.Visible = true;
                txtGenerateCode.Text = "";

                if (lnkAddressDetailsSave.Visible == true)
                {
                    lnkAddressDetailsSave.Visible = false;
                    lnkAddressDetails.Visible = true;
                }


                if (lnkCompnameSave.Visible == true)
                {
                    lnkCompnameSave.Visible = false;
                    lnkcompname.Visible = true;
                }

                if (lnkOtherDetailsSave.Visible == true)
                {
                    lnkOtherDetailsSave.Visible = false;
                    lnkOtherDetails.Visible = true;
                }

                if (lnkcompnameCancel.Visible == true)
                {
                    lnkcompnameCancel.Visible = false;
                }
                if (lnkAddressDetailsCancel.Visible == true)
                {
                    lnkAddressDetailsCancel.Visible = false;
                }
                if (lnkOtherDetailsCancel.Visible == true)
                {
                    lnkOtherDetailsCancel.Visible = false;
                }

                //email prefernece
                //ddlEmailPreference.Visible = true;
                chkbxEmailPreference.Visible = true;
                if (lblEmailPreferenceValue.Text == "Yes")
                {
                    chkbxEmailPreference.Checked = true;
                }
                lblEmailPreferenceValue.Visible = false;



                lnkContactDetails.Visible = false;
                lnkContactDetailsCancel.Visible = true;
                lnkContactDetailsSave.Visible = true;

                txtEmail.Visible = true;
                txtEmail.Text = lblEmailvalue.Text;
                lblEmailvalue.Visible = false;

                txtWebsiteurl.Visible = true;
                txtWebsiteurl.Text = lblWebsiteurlvalue.Text;
                lblWebsiteurlvalue.Visible = false;

                txtMobCntcd.Visible = true;
                txtMobCntcd.Text = lblMobCntcd.Text;
                txtmobno.Visible = true;
                txtmobno.Text = lblMobno.Text;
                txtmobno.Visible = true;
                lblMobCntcd.Visible = false;
                lblMobno.Visible = false;

                txtCountryCode.Visible = true;
                txtCountryCode.Text = lblCntCd.Text;
                lblCntCd.Visible = false;


                txtCityCode.Visible = true;
                txtCityCode.Text = lblCtycd.Text;
                lblCtycd.Visible = false;

                txtPhone.Visible = true;
                txtPhone.Text = lblPhonevalue.Text;
                lblPhonevalue.Visible = false;

                txtExtension.Visible = true;
                txtExtension.Text = lblExtensionvalue.Text;
                lblExtensionvalue.Visible = false;

                //txtMobile.Visible = true;
                //txtMobile.Text = lblMobilevalue.Text;
                //lblMobilevalue.Visible = false;
                txtCityCode1.Visible = true;
                txtCityCode1.Text = lblCityCode1.Text;
                lblCityCode1.Visible = false;

                txtCountryCode1.Visible = true;
                txtCountryCode1.Text = lblCountrycode1.Text;
                lblCountrycode1.Visible = false;


                txtFax.Visible = true;
                txtFax.Text = lblFaxvalue.Text;
                lblFaxvalue.Visible = false;


                lbltxtQQIdText.Visible = false;
                txtQQId.Visible = true;
                txtQQId.Text = lbltxtQQIdText.Text;

                lbltxtMSNIdText.Visible = false;
                txtMSNId.Visible = true;
                txtMSNId.Text = lbltxtMSNIdText.Text;

                lbltxtSkypeIdText.Visible = false;
                txtSkypeId.Visible = true;
                txtSkypeId.Text = lbltxtSkypeIdText.Text;

                txtEmail.Visible = true;
                txtEmail.Text = lblEmailvalue.Text;
                lblEmailvalue.Visible = false;

                lblAddress1value.Visible = true;
                txtAddress1.Visible = false;
                lblAddress2value.Visible = true;
                txtAddress2.Visible = false;
                lblPrimaryCountryvalue.Visible = true;
                ddlPrimaryCountry.Visible = false;
                if (ddlSecondaryCountry.SelectedIndex == 0)
                {
                    lblSecondaryCountryValue.Visible = false;
                }
                else
                {
                    lblSecondaryCountryValue.Visible = true;
                }
                ddlSecondaryCountry.Visible = false;
                lblPrimaryStatevalue.Visible = true;
                txtPrimaryState.Visible = false;
                lblSecondaryStateValue.Visible = true;
                txtSecondaryState.Visible = false;
                lblPrimaryCityvalue.Visible = true;
                txtPrimaryCity.Visible = false;
                lblSecondaryCityvalue.Visible = true;
                txtSecondaryCity.Visible = false;
                lblPriamryZipCodeValue.Visible = true;
                txtPriamryZipCode.Visible = false;
                lblSecondaryZipCodeValue.Visible = true;
                txtSecondaryZipCode.Visible = false;

                lblcompnamevalue.Visible = true;
                txtcompnamevalue.Visible = false;
                lblOwnersnamevalue.Visible = true;
                txtOwnersnamevalue.Visible = false;

                lblFirstNameValue.Visible = true;
                lblLastNameValue.Visible = true;
                txtFirstname.Visible = false;
                txtLastName.Visible = false;

                lblSpecializaionValue.Visible = true;
                txtSpecializaion.Visible = false;
                //lblCurrencyvalue.Visible = true;
                //ddlCurreny.Visible = false;

                txtPanNumber.Visible = false;
                lblPanNumberValue.Visible = true;





            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void lnkContactDetailsSave_Click1(object sender, EventArgs e)
        {
            try
            {


                if (lblEmailvalue.Text != txtEmail.Text && txtGenerateCode.Text == "" && txtEmail.Text != "")
                {
                    string msg;
                    msg = "alert('Generate Verification code to Update the email address.')";
                    ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", msg, true);

                }
                else
                {

                    lblEmailvalue.Visible = true;

                    btnGenerateCode.Visible = false;
                    txtGenerateCode.Visible = false;

                    lnkContactDetails.Visible = true;
                    lnkContactDetailsCancel.Visible = false;
                    lnkContactDetailsSave.Visible = false;


                    lblEmailvalue.Visible = true;

                    txtWebsiteurl.Visible = false;
                    lblWebsiteurlvalue.Text = txtWebsiteurl.Text.Trim();
                    lblWebsiteurlvalue.Visible = true;



                    txtmobno.Visible = false;
                    lblMobno.Text = txtmobno.Text.Trim();
                    lblMobno.Visible = true;

                    txtMobCntcd.Visible = false;
                    if (txtmobno.Text != "")
                    {
                        lblMobCntcd.Text = txtMobCntcd.Text.Trim();
                    }
                    else
                    {
                        lblMobCntcd.Text = "";
                    }


                    txtPhone.Visible = false;
                    lblPhonevalue.Text = txtPhone.Text.Trim();
                    lblPhonevalue.Visible = true;


                    txtCityCode.Visible = false;
                    lblCtycd.Text = txtCityCode.Text.Trim();
                    lblCtycd.Visible = true;

                    txtCountryCode.Visible = false;
                    lblCntCd.Text = txtCountryCode.Text.Trim();
                    lblCntCd.Visible = true;

                    txtCityCode1.Visible = false;
                    if (txtFax.Text != "")
                    {
                        lblCityCode1.Text = txtCityCode1.Text.Trim();
                    }
                    else
                    {
                        lblCityCode1.Text = "";
                    }
                    lblCityCode1.Visible = true;

                    txtCountryCode1.Visible = false;
                    if (txtFax.Text != "")
                    {
                        lblCountrycode1.Text = txtCountryCode1.Text.Trim();
                    }
                    else
                    {
                        lblCountrycode1.Text = "";
                    }
                    lblMobCntcd.Visible = true;
                    lblCountrycode1.Visible = true;
                    txtExtension.Visible = false;
                    lblExtensionvalue.Text = txtExtension.Text.Trim();
                    lblExtensionvalue.Visible = true;

                    //txtMobile.Visible = false;
                    //lblMobilevalue.Text = txtMobile.Text;
                    //lblMobilevalue.Visible = true;



                    txtFax.Visible = false;
                    lblFaxvalue.Text = txtFax.Text.Trim();
                    lblFaxvalue.Visible = true;

                    txtQQId.Visible = false;
                    lbltxtQQIdText.Text = txtQQId.Text.Trim();
                    lbltxtQQIdText.Visible = true;

                    txtSkypeId.Visible = false;
                    lbltxtSkypeIdText.Text = txtSkypeId.Text.Trim();
                    lbltxtSkypeIdText.Visible = true;

                    txtMSNId.Visible = false;
                    lbltxtMSNIdText.Text = txtMSNId.Text.Trim();
                    lbltxtMSNIdText.Visible = true;

                    if (lblMobCntcd.Text == "")
                    {
                        Plus.Visible = false;
                    }
                    else
                    {
                        Plus.Visible = true;
                    }
                    if (lblMobno.Text == "")
                    {
                        dash.Visible = false;
                    }
                    else
                    {
                        dash.Visible = true;
                    }

                    if (lblCntCd.Text == "")
                    {
                        plus1.Visible = false;
                    }
                    else
                    {
                        plus1.Visible = true;
                    }
                    if (lblCtycd.Text == "")
                    {
                        dash1.Visible = false;
                        dash2.Visible = false;

                    }
                    else
                    {
                        dash1.Visible = true;
                        dash2.Visible = true;
                    }

                    if (lblMobCntcd.Text == "")
                    {
                        dash.Visible = false;

                    }
                    else
                    {
                        dash.Visible = true;
                    }
                    if (lblCountrycode1.Text.Trim() == "" || txtFax.Text.Trim() == "")
                    {
                        plus2.Visible = false;
                    }
                    else
                    {
                        plus2.Visible = true;
                    }

                    if (lblCityCode1.Text.Trim() == "" || txtFax.Text.Trim() == "")
                    {
                        dash3.Visible = false;
                        dash4.Visible = false;

                    }
                    else
                    {
                        dash3.Visible = true;
                        dash4.Visible = true;
                    }


                    if (txtGenerateCode.Text.Trim() != "")
                    {
                        if (VerificationCodeCheck())
                        {
                            lblEmailvalue.Text = txtEmail.Text.Trim();
                        }
                        else
                        {
                            string msgg;
                            msgg = "alert('Incorrect input of email address or verification code. Please try again.')";
                            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", msgg, true);

                        }
                    }
                    txtEmail.Visible = false;
                    //email Prefernce
                    //ddlEmailPreference.Visible = false;
                    chkbxEmailPreference.Visible = false;
                    lblEmailPreferenceValue.Visible = true;

                    GetSellersProfile();
                }

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void lnkContactDetailsCancel_Click1(object sender, EventArgs e)
        {
            try
            {


                lnkContactDetails.Visible = true;
                lnkContactDetailsCancel.Visible = false;
                lnkContactDetailsSave.Visible = false;

                lblEmailvalue.Visible = true;
                txtEmail.Visible = false;

                lblWebsiteurlvalue.Visible = true;
                txtWebsiteurl.Visible = false;

                lblMobCntcd.Visible = true;
                lblMobno.Visible = true;
                txtmobno.Visible = false;
                txtMobCntcd.Visible = false;


                lblCtycd.Visible = true;
                txtCityCode.Visible = false;
                lblCityCode1.Visible = true;
                txtCityCode1.Visible = false;
                lblCntCd.Visible = true;
                txtCountryCode.Visible = false;
                lblCountrycode1.Visible = true;
                txtCountryCode1.Visible = false;
                lblPhonevalue.Visible = true;
                txtPhone.Visible = false;
                lblExtensionvalue.Visible = true;
                txtExtension.Visible = false;
                //lblMobilevalue.Visible = true;
                //txtMobile.Visible = false;
                lblFaxvalue.Visible = true;
                txtFax.Visible = false;

                lbltxtMSNIdText.Visible = true;
                txtMSNId.Visible = false;
                lbltxtQQIdText.Visible = true;
                txtQQId.Visible = false;
                lbltxtSkypeIdText.Visible = true;
                txtSkypeId.Visible = false;

                btnGenerateCode.Visible = false;
                txtGenerateCode.Visible = false;
                txtGenerateCode.Text = "";
                //Email Prefernece
                //ddlEmailPreference.Visible = false;
                chkbxEmailPreference.Visible = false;
                lblEmailPreferenceValue.Visible = true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void lnkOtherDetails_Click1(object sender, EventArgs e)
        {
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                Guid userid = (Guid)userToLogin.ProviderUserKey;
                List<ICBrowser.Common.UserProfile> lstBarCountry = new List<ICBrowser.Common.UserProfile>();
                UserProfileDetails profiledetais = new UserProfileDetails();
                Common.UserProfile Profile = new Common.UserProfile();
                Profile = profiledetais.GetUserProfileDetails(ViewUserProfileId);

                chckcountrylst.Visible = true;
                // Read list of countries from XML into dataset
                DataSet dsCountries = new DataSet();
                List<string> selectedvalue = new List<string>();
                string filepath = Server.MapPath("/data/List Of Countries.xml");
                dsCountries.ReadXml(filepath);
                dsCountries.Tables[0].Rows.RemoveAt(0);
                lstBarCountry = profiledetais.GetUserBarCountryDetails(userid);
                foreach (var barcountryname in lstBarCountry)
                {
                    for (int i = 0; i < dsCountries.Tables[0].Rows.Count; i++)
                    {
                        object value = dsCountries.Tables[0].Rows[i][0];
                        if (value.Equals(barcountryname.Barcountry))
                        {
                            chkbxlstBarCountry.Items[i].Selected = true;
                            selectedvalue.Add(value.ToString());
                            break;
                        }
                    }
                }

                if (selectedvalue == null)
                {
                    chkbxlstBarCountry.SelectedValue = "0";
                }

                lblMembershipExpiry.Visible = false;

                if (lnkAddressDetailsSave.Visible == true)
                {
                    lnkAddressDetailsSave.Visible = false;
                    lnkAddressDetails.Visible = true;
                }

                if (lnkContactDetailsSave.Visible == true)
                {
                    lnkContactDetailsSave.Visible = false;
                    lnkContactDetails.Visible = true;
                }

                if (lnkCompnameSave.Visible == true)
                {
                    lnkCompnameSave.Visible = false;
                    lnkcompname.Visible = true;
                }

                if (lnkcompnameCancel.Visible == true)
                {
                    lnkcompnameCancel.Visible = false;
                }
                if (lnkAddressDetailsCancel.Visible == true)
                {
                    lnkAddressDetailsCancel.Visible = false;
                }
                if (lnkContactDetailsCancel.Visible == true)
                {
                    lnkContactDetailsCancel.Visible = false;
                }

                btnGenerateCode.Visible = false;
                txtGenerateCode.Visible = false;
                //email prefernece           
                lblEmailPreferenceValue.Visible = true;
                // ddlEmailPreference.Visible = false;
                chkbxEmailPreference.Visible = false;

                lblEmailvalue.Visible = true;
                txtEmail.Visible = false;

                lnkOtherDetails.Visible = false;
                lnkOtherDetailsCancel.Visible = true;
                lnkOtherDetailsSave.Visible = true;

                txtSpecializaion.Visible = true;
                txtSpecializaion.Text = lblSpecializaionValue.Text;
                lblSpecializaionValue.Visible = false;

                //ddlCurreny.Visible = true;
                //ddlCurreny.SelectedValue = lblCurrencyvalue.Text;
                //lblCurrencyvalue.Visible = false;

                lblAddress1value.Visible = true;
                txtAddress1.Visible = false;
                lblAddress2value.Visible = true;
                txtAddress2.Visible = false;
                lblPrimaryCountryvalue.Visible = true;
                ddlPrimaryCountry.Visible = false;
                if (ddlSecondaryCountry.SelectedIndex == 0)
                {
                    lblSecondaryCountryValue.Visible = false;
                }
                else
                {
                    lblSecondaryCountryValue.Visible = true;
                }
                ddlSecondaryCountry.Visible = false;
                lblPrimaryStatevalue.Visible = true;
                txtPrimaryState.Visible = false;
                lblSecondaryStateValue.Visible = true;
                txtSecondaryState.Visible = false;
                lblPrimaryCityvalue.Visible = true;
                txtPrimaryCity.Visible = false;
                lblSecondaryCityvalue.Visible = true;
                txtSecondaryCity.Visible = false;
                lblPriamryZipCodeValue.Visible = true;
                txtPriamryZipCode.Visible = false;
                lblSecondaryZipCodeValue.Visible = true;
                txtSecondaryZipCode.Visible = false;

                lblCtycd.Visible = true;
                txtCityCode.Visible = false;
                lblCityCode1.Visible = true;
                txtCityCode1.Visible = false;
                lblCntCd.Visible = true;
                txtCountryCode.Visible = false;
                lblCountrycode1.Visible = true;
                txtCountryCode1.Visible = false;

                lblWebsiteurlvalue.Visible = true;
                txtWebsiteurl.Visible = false;

                lblMobno.Visible = true;
                txtmobno.Visible = false;
                lblMobCntcd.Visible = true;
                txtMobCntcd.Visible = false;

                lblPhonevalue.Visible = true;
                txtPhone.Visible = false;
                lblExtensionvalue.Visible = true;
                txtExtension.Visible = false;
                //lblMobilevalue.Visible = true;
                //txtMobile.Visible = false;
                lblFaxvalue.Visible = true;
                txtFax.Visible = false;

                lbltxtMSNIdText.Visible = true;
                txtMSNId.Visible = false;
                lbltxtQQIdText.Visible = true;
                txtQQId.Visible = false;
                lbltxtSkypeIdText.Visible = true;
                txtSkypeId.Visible = false;

                lblcompnamevalue.Visible = true;
                txtcompnamevalue.Visible = false;
                lblOwnersnamevalue.Visible = true;
                txtOwnersnamevalue.Visible = false;

                lblFirstNameValue.Visible = true;
                lblLastNameValue.Visible = true;
                txtFirstname.Visible = false;
                txtLastName.Visible = false;

                txtPanNumber.Visible = false;
                lblPanNumberValue.Visible = true;
                lblBarredCountryValue.Visible = false;
                lbtnPreview.Visible = false;

                if (Profile.TypeOfMembership == 2)
                {
                    lblMembershipLastDateValue.Visible = false;
                    Calendar1.Visible = true;
                    Calendar1.SelectedDate = DateTime.Parse(lblMembershipLastDateValue.Text);
                    Calendar1.VisibleDate = Calendar1.SelectedDate;
                }

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void lnkOtherDetailsSave_Click1(object sender, EventArgs e)
        {
            try
            {
                
                chckcountrylst.Visible = false;
                MembershipUser userToLogin = Membership.GetUser();
                Guid userid = (Guid)userToLogin.ProviderUserKey;
                UserProfileDetails profile = new UserProfileDetails();
                UserProfileDetails profiledetais = new UserProfileDetails();
                Common.UserProfile Profile = new Common.UserProfile();
                Profile = profiledetais.GetUserProfileDetails(ViewUserProfileId);
                Common.UserProfile User = new Common.UserProfile();
                Calendar1.VisibleDate = Calendar1.SelectedDate;

                if (Profile.TypeOfMembership == 2 && Calendar1.VisibleDate < DateTime.Now)
                {

                    string msg;
                    msg = "alert('Error Message: Selected Membership Expiry date should be greater than today.')";
                    ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", msg, true);

                }
                else
                {
                    lblMembershipExpiry.Visible = false;
                    lnkOtherDetails.Visible = true;
                    lnkOtherDetailsSave.Visible = false;
                    lnkOtherDetailsCancel.Visible = false;
                    txtSpecializaion.Visible = false;
                    lblSpecializaionValue.Text = txtSpecializaion.Text.Trim();
                    lblSpecializaionValue.Visible = true;
                    Calendar1.Visible = false;
                    List<ICBrowser.Common.UserProfile> lstBarCountry = new List<ICBrowser.Common.UserProfile>();
                    lstBarCountry = profiledetais.GetUserBarCountryDetails(userid);
                    List<string> barcountry = new List<string>();
                    List<string> deletebarcountryrecord = new List<string>();

                    foreach (ListItem li in chkbxlstBarCountry.Items)
                    {
                        if (li.Selected == true)
                        {
                            barcountry.Add(li.Text);
                        }
                        else
                        {
                            foreach (var lst in lstBarCountry)
                            {
                                if (li.Text == lst.Barcountry)
                                {
                                    deletebarcountryrecord.Add(li.Text);
                                }
                            }
                        }
                    }
                    profile.DeleteUsersProfileforBarCountry(userid, deletebarcountryrecord);
                    profile.InsertUsersProfileforBarCountry(userid, barcountry);

                    if (Profile.TypeOfMembership == 2)
                    {
                        User.MembershipExpiryDate = Convert.ToDateTime(Calendar1.VisibleDate);
                        User.UserID = ViewUserProfileId;
                        profile.UpdateUsersMembershipExpiry(User);
                        lblMembershipLastDateValue.Text = String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(Calendar1.VisibleDate));
                        lblMembershipLastDateValue.Visible = true;
                    }
                    lstBarCountry = profiledetais.GetUserBarCountryDetails(userid);
                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (var barredcountry in lstBarCountry)
                    {
                        if (count < 3)
                        {
                            sb.Append(barredcountry.Barcountry + ", ");
                            count = count + 1;
                        }
                        else
                        {
                            break;
                        }

                    }                  
                    lblBarredCountryValue.Text = sb.ToString();
                    lblBarredCountryValue.Visible = true;
                    if (lstBarCountry.Count > 0)
                    {
                        lbtnPreview.Visible = true;
                    }
                    GetSellersProfileDetails();

                }


            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void lnkOtherDetailsCancel_Click1(object sender, EventArgs e)
        {
            try
            {
                chckcountrylst.Visible = false;
                Common.UserProfile objuserpro = new Common.UserProfile();
                UserProfileDetails profiledetais = new UserProfileDetails();
                MembershipUser userToLogin = Membership.GetUser();
                Guid userid = (Guid)userToLogin.ProviderUserKey;
                if (Request.QueryString["UserID"] != null)
                {
                    ViewUserProfileId = new Guid(Request.QueryString["UserId"]);
                }

                lblMembershipExpiry.Visible = false;
                lnkOtherDetails.Visible = true;
                lnkOtherDetailsCancel.Visible = false;
                lnkOtherDetailsSave.Visible = false;

                lblSpecializaionValue.Visible = true;
                txtSpecializaion.Visible = false;
                Calendar1.Visible = false;

                objuserpro = profiledetais.GetUserProfileDetails(userid);
                int memTypeId = 0;
                memTypeId = objuserpro.TypeOfMembership;

                Common.UserProfile Profile = new Common.UserProfile();
                Profile = profiledetais.GetUserProfileDetails(ViewUserProfileId);

                if (memTypeId == 1 || Profile.TypeOfMembership == 1)
                {
                    lblMembershipLastDateValue.Visible = false;
                }
                else
                {
                    lblMembershipLastDateValue.Visible = true;
                }
                lblBarredCountryValue.Visible = true;
                lbtnPreview.Visible = true;

                //lblCurrencyvalue.Visible = true;
                //ddlCurreny.Visible = false;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void btnMembership_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["UserID"] != null)
            {
                Guid userid = new Guid(Request.QueryString["UserID"]);
                Response.Redirect("SellerSubscription.aspx?prfl=prfl" + "&userid=" + userid);
            }
            else 
            {
                MembershipUser userToLogin = Membership.GetUser();
                Guid userid = (Guid)userToLogin.ProviderUserKey;
                Response.Redirect("SellerSubscription.aspx?prfl=prfl" + "&userid=" + userid);
            }
            
        }

        protected void btnGenerateCode_Click1(object sender, EventArgs e)
        {
            string User = "User";

            if (lblEmailvalue.Text != txtEmail.Text)
            {
                if (txtEmail.Text.Trim() != "")
                {

                    string secretcode = generateSecretCode();
                    ViewState["SecretGeneratedKey"] = secretcode;
                    ViewState["EmailAddressAssociatedToSecretKey"] = txtEmail.Text.Trim();
                    Hashtable hash = new Hashtable
                                     {
                                         {"UserName", User},
                                         {"AccountType", "Verification"},
                                         {"Password", secretcode}
                                     };

                    EmailFactory mailFactory = new EmailFactory();
                    Email mail = mailFactory.GetAccountRequestMail(txtEmail.Text.Trim(), "support@icbrowser.com", hash);

                    if (mail.Send())
                    {
                        // success mail sending
                        //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "alert('Verification code has been send to your email address. Please enter your verification code.');");
                        string msg1;
                        msg1 = "alert('Verification code has been sent to your email address. Please enter your verification code.')";
                        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", msg1, true);
                        btnGenerateCode.Visible = true;
                    }
                    else
                    {
                        // error sending mail.

                        string msg2;
                        msg2 = "alert('Error has occurred in sending mail. Please try again later.')";
                        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", msg2, true);
                        btnGenerateCode.Visible = true;
                        btnGenerateCode.Visible = true;
                    }


                }


            }
            else
            {
                string msg3;
                msg3 = "alert('No change made to Email.')";
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", msg3, true);
            }

        }

        private string generateSecretCode()
        {
            string pinPwd = string.Empty;
            int j = 0;      //for Upper Case because it will generate the Character same as like ch[i] doing.

            Random rnd = new Random();    // random class for random generate the numbers using .Next()

            for (int i = 0; i <= 2; i++) // For loop
            {
                j = j + 1;      //increment the J variable for Random Characters.

                // Create nums Array.
                int[] nums = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                // create an characters Array for it.
                char[] ch = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

                char[] spc = new[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };

                nums[i] = nums[rnd.Next(0, 9)];
                ch[i] = ch[rnd.Next(0, 20)];
                ch[j] = ch[rnd.Next(0, 25)];
                spc[i] = spc[rnd.Next(0, 9)];

                pinPwd += nums[i].ToString() + ch[i].ToString() + ch[j].ToString().ToUpper() + spc[i].ToString();

                // just add/append the nums and ch in pin_pwd.
                //pin_pwd will store the string of random generated password.
            }
            return pinPwd;
        }

        private bool VerificationCodeCheck()
        {
            if (ViewState["SecretGeneratedKey"] != null && ViewState["EmailAddressAssociatedToSecretKey"] != null)
            {
                string secretcode = ViewState["SecretGeneratedKey"].ToString();
                if (txtGenerateCode.Text.Trim() != "" || txtGenerateCode.Text.Trim() != null)
                {
                    if (txtGenerateCode.Text.Trim().Equals(secretcode) && ViewState["EmailAddressAssociatedToSecretKey"].Equals(txtEmail.Text.Trim()))
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        protected void lbtnPreview_Click(object sender, EventArgs e)
        {
            BindBarcountryGrid();
            modpopPreview.Show();
        }

        protected void btnPreviewClose_Click(object sender, EventArgs e)
        {
            modpopPreview.Hide();
        }

        private void BindBarcountryGrid()
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid userid = (Guid)userToLogin.ProviderUserKey;
            UserProfileDetails profiledetais = new UserProfileDetails();
            List<ICBrowser.Common.UserProfile> lstBarCountry = new List<ICBrowser.Common.UserProfile>();
            lstBarCountry = profiledetais.GetUserBarCountryDetails(userid);
            gvbarCompanyDetails.DataSource = lstBarCountry;
            gvbarCompanyDetails.DataBind();
        }

        protected void gvbarCompanyDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvbarCompanyDetails.PageIndex = e.NewPageIndex;
            BindBarcountryGrid();
        }
    }
}