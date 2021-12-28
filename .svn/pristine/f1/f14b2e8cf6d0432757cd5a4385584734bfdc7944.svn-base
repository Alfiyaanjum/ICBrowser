using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Web.Security;
using System.Collections;
using System.Data;
namespace ICBrowser.Web
{
    public partial class ViewBuyersProfile : BasePage
    {
        public Guid ViewUserProfileId;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


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
                    Common.UserProfile objuserpro = new Common.UserProfile();
                    UserProfileDetails profiledetais = new UserProfileDetails();

                    objuserpro = profiledetais.GetUserProfileDetails(userid);
                    int memTypeId = 0;
                    memTypeId = objuserpro.TypeOfMembership;

                    if (memTypeId == 1 || Admin.IsAdmin)
                    {
                        if (!Page.IsPostBack)
                        {
                            BindCountry();
                            BuyerProfileDetails();
                            lnkCompnameSave.Visible = false;
                            lnkAddressDetailsSave.Visible = false;
                            lnkContactDetailsSave.Visible = false;
                            lnkCurrencyDetailsSave.Visible = false;
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
        }
        //to get buyer details
        public void BuyerProfileDetails()
        {
            try
            {
                Guid currUserId = new Guid();
                var membershipUser = Membership.GetUser();
                if (membershipUser != null)
                    if (membershipUser.ProviderUserKey != null)
                        currUserId = new Guid(membershipUser.ProviderUserKey.ToString());
                UserProfileDetails userProfile = new UserProfileDetails();


                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
                Common.UserProfile Profile = new Common.UserProfile();

                if (Admin.IsAdmin)
                {
                    Profile = userProfile.GetUserProfileDetails(ViewUserProfileId);

                }
                else
                {
                    Profile = userProfile.GetUserProfileDetails(currUserId);
                }

                lblcompnamevalue.Text = Profile.CompanyName;

                string ContactName= Profile.ContactName;
                string lastname = ContactName.Substring(ContactName.LastIndexOf(' ') + 1);
                string firstname = ContactName.Substring(0, ContactName.IndexOf(" ")).Trim();
                lblFirstNameValue.Text = firstname;
                lblLastNameValue.Text =lastname ;
                lblOwnersnamevalue.Text = Profile.OwnerName;


                lblEmailPreferenceValue.Visible = true;
                // ddlEmailPreference.Visible = false;
                chkbxEmailPreference.Visible = false;
                //Set lblEmailPreference to Text values 
                if (Profile.EmailPreference == 1)
                {
                    lblEmailPreferenceValue.Text = "Yes";
                }
                else
                {
                    lblEmailPreferenceValue.Text = "No";

                }


                if (!string.IsNullOrEmpty(Profile.PrimaryAddress))
                {
                    lblAddress1value.Text = Profile.PrimaryAddress;
                }
                if (!string.IsNullOrEmpty(Profile.SecondaryAddress))
                {
                    lblAddress2value.Text = Profile.SecondaryAddress;
                }
                lblPrimaryCountryvalue.Text = Profile.PrimaryCountry;
                lblSecondaryCountryValue.Text = Profile.SecondaryCountry;
                lblEmailvalue.Text = Profile.email;
                string str = Profile.LandLine;

                string last = str.Substring(str.LastIndexOf('-') + 1);
                string first = str.Substring(0, str.IndexOf("-")).Trim();
                lblPhonevalue.Text = last;
                lblCountrycode.Text = first;

                lblExtensionvalue.Text = Profile.Extension;
                lblMobilevalue.Text = Profile.Mobile;
                lblFaxvalue.Text = Profile.FaxNumber;
                lblPanNumberValue.Text = Profile.PanNumber;
                lblPrimaryStatevalue.Text = Profile.PrimaryState;
                lblSecondaryStateValue.Text = Profile.SecondaryState;
                lblPrimaryCityvalue.Text = Profile.PrimaryCity;
                lblSecondaryCityvalue.Text = Profile.SecondaryCity;
                lblWebsiteurlvalue.Text = Profile.Website;
                lblPriamryZipCodeValue.Text = Profile.PrimaryZip;
                lblSecondaryZipCodeValue.Text = Profile.SecondaryZip;
                lblSpecializaionValue.Text = Profile.Specialization;
                lblCurrencyvalue.Text = Profile.Currency;
                lblLastUpdatedvalue.Text = String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(Profile.ModifiedDate));
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

        }


        public void GetBuyersProfile()
        {


            Guid currUserId = new Guid();
            var membershipUser = Membership.GetUser();
            if (membershipUser != null)
                if (membershipUser.ProviderUserKey != null)
                    currUserId = new Guid(membershipUser.ProviderUserKey.ToString());

            if (Request.QueryString["UserID"] != null)
            {
                ViewUserProfileId = new Guid(Request.QueryString["UserId"]);
            }

            Controller controlIsAdmin = new Controller();
            Users Admin = controlIsAdmin.GetIsAdmin(currUserId);


            //BuyersDataRequirement buyerdata = new BuyersDataRequirement();
            Common.UserProfile userProfile = new Common.UserProfile();
            //cmpdet1 = buyerdata.GetBuyersid(currUserId);
            //CompanyDetails cmpdet = new CompanyDetails();

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
            userProfile.SecondaryCountry = lblSecondaryCountryValue.Text;

            //Emailpreference
            userProfile.EmailPreference = Convert.ToInt32(chkbxEmailPreference.Checked);

            userProfile.email = lblEmailvalue.Text;
            userProfile.Website = lblWebsiteurlvalue.Text;
            string str1 = string.Format(@"{0}-{1}", lblCountrycode.Text, lblPhonevalue.Text);
            userProfile.LandLine = str1;

            userProfile.Extension = lblExtensionvalue.Text;
            userProfile.Mobile = lblMobilevalue.Text;
            userProfile.FaxNumber = lblFaxvalue.Text;
            userProfile.Mobile = lblMobilevalue.Text;
            userProfile.PanNumber = lblPanNumberValue.Text;
            userProfile.Specialization = lblSpecializaionValue.Text;
            userProfile.Currency = lblCurrencyvalue.Text;
            //cmpdet.LastModifiedDate =Convert.ToDateTime(lblLastUpdatedvalue.Text);




            lblEmailPreferenceValue.Visible = true;
            // ddlEmailPreference.Visible = false;
            chkbxEmailPreference.Visible = false;
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

            //to update buyer details
            profile.UpdateUsersProfile(userProfile);
            //BuyerProfileDetails();

            string Updatemsg;
            Updatemsg = "alert('Profile Updated.')";
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", Updatemsg, true);

        }


        protected void input_Click(object sender, EventArgs e)
        {

        }



        protected void lnkcompname_Click1(object sender, EventArgs e)
        {
            try
            {
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
                if (lnkCurrencyDetailsSave.Visible == true)
                {
                    lnkCurrencyDetailsSave.Visible = false;
                    lnkCurrencyDetails.Visible = true;
                }

                if (lnkAddressDetailsCancel.Visible == true)
                {
                    lnkAddressDetailsCancel.Visible = false;
                }
                if (lnkContactDetailsCancel.Visible == true)
                {
                    lnkContactDetailsCancel.Visible = false;
                }

                if (lnkCurrencyDetailsCancel.Visible == true)
                {
                    lnkCurrencyDetailsCancel.Visible = false;
                }

                btnGenerateCode.Visible = false;
                txtGenerateCode.Visible = false;

                lnkcompname.Visible = false;
                lnkCompnameSave.Visible = true;
                lnkcompnameCancel.Visible = true;

                txtcompnamevalue.Visible = true;
                txtcompnamevalue.Text = lblcompnamevalue.Text;
                lblcompnamevalue.Visible = false;

                txtOwnersnamevalue.Visible = true;
                txtOwnersnamevalue.Text = lblOwnersnamevalue.Text;
                lblOwnersnamevalue.Visible = false;

                txtFirstname.Visible=true;
                txtFirstname.Text = lblFirstNameValue.Text;
                lblFirstNameValue.Visible = false;

                txtLastName.Visible = true;
                txtLastName.Text = lblLastNameValue.Text;
                lblLastNameValue.Visible = false;
               

                lblAddress1value.Visible = true;
                txtAddress1.Visible = false;
                lblAddress2value.Visible = true;
                txtAddress2.Visible = false;

                lblEmailPreferenceValue.Visible = true;
                //ddlEmailPreference.Visible = false;
                chkbxEmailPreference.Visible = false;

                lblPrimaryCountryvalue.Visible = true;
                ddlPrimaryCountry.Visible = false;
                lblSecondaryCountryValue.Visible = true;
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


                lblEmailvalue.Visible = true;
                txtEmail.Visible = false;

                lblWebsiteurlvalue.Visible = true;
                txtWebsiteurl.Visible = false;
                lblCountrycode.Visible = true;
                txtCountryCode.Visible = false;
                lblPhonevalue.Visible = true;
                txtPhone.Visible = false;
                lblExtensionvalue.Visible = true;
                txtExtension.Visible = false;
                lblMobilevalue.Visible = true;
                txtMobile.Visible = false;
                lblFaxvalue.Visible = true;
                txtFax.Visible = false;

                lblSpecializaionValue.Visible = true;
                txtSpecializaion.Visible = false;
                lblCurrencyvalue.Visible = true;
                ddlCurreny.Visible = false;

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

                lnkcompname.Visible = true;
                lnkcompnameCancel.Visible = false;
                lnkCompnameSave.Visible = false;

                txtcompnamevalue.Visible = false;
                lblcompnamevalue.Text = txtcompnamevalue.Text;
                lblcompnamevalue.Visible = true;

                txtOwnersnamevalue.Visible = false;
                lblOwnersnamevalue.Text = txtOwnersnamevalue.Text;
                lblOwnersnamevalue.Visible = true;

               
                txtFirstname.Visible = false;
                lblFirstNameValue.Text=txtFirstname.Text.Trim();
                lblFirstNameValue.Visible = true; ;
                
                txtLastName.Visible = false;
                lblLastNameValue.Text=txtLastName.Text.Trim();
                lblLastNameValue.Visible = true; ;


                GetBuyersProfile();

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
                lnkcompname.Visible = true;
                lnkcompnameCancel.Visible = false;
                lnkCompnameSave.Visible = false;

                lblcompnamevalue.Visible = true;
                txtcompnamevalue.Visible = false;
                lblOwnersnamevalue.Visible = true;
                txtOwnersnamevalue.Visible = false;
                //lblContactPersonsNamevalue.Visible = true;
                //txtContactPersonsName.Visible = false;

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
                if (lnkCurrencyDetailsSave.Visible == true)
                {
                    lnkCurrencyDetailsSave.Visible = false;
                    lnkCurrencyDetails.Visible = true;
                }

                if (lnkcompnameCancel.Visible == true)
                {
                    lnkcompnameCancel.Visible = false;
                }
                if (lnkContactDetailsCancel.Visible == true)
                {
                    lnkContactDetailsCancel.Visible = false;
                }

                if (lnkCurrencyDetailsCancel.Visible == true)
                {
                    lnkCurrencyDetailsCancel.Visible = false;
                }

                btnGenerateCode.Visible = false;
                txtGenerateCode.Visible = false;

                lnkAddressDetails.Visible = false;
                lnkAddressDetailsCancel.Visible = true;
                lnkAddressDetailsSave.Visible = true;

                lblEmailPreferenceValue.Visible = true;
                // ddlEmailPreference.Visible = false;
                chkbxEmailPreference.Visible = false;

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
                    ddlPrimaryCountry.SelectedValue = selectedvalue1.ToString();

                }
                else
                {
                    ddlPrimaryCountry.SelectedValue = "0";

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

                lblEmailvalue.Visible = true;
                txtEmail.Visible = false;

                lblWebsiteurlvalue.Visible = true;
                txtWebsiteurl.Visible = false;
                lblCountrycode.Visible = true;
                txtCountryCode.Visible = false;
                lblPhonevalue.Visible = true;
                txtPhone.Visible = false;
                lblExtensionvalue.Visible = true;
                txtExtension.Visible = false;
                lblMobilevalue.Visible = true;
                txtMobile.Visible = false;
                lblFaxvalue.Visible = true;
                txtFax.Visible = false;

                lblcompnamevalue.Visible = true;
                txtcompnamevalue.Visible = false;
                lblOwnersnamevalue.Visible = true;
                txtOwnersnamevalue.Visible = false;
                //lblContactPersonsNamevalue.Visible = true;
                //txtContactPersonsName.Visible = false;

                lblFirstNameValue.Visible = true;
                lblLastNameValue.Visible = true;
                txtFirstname.Visible = false;
                txtLastName.Visible = false;

                lblSpecializaionValue.Visible = true;
                txtSpecializaion.Visible = false;
                lblCurrencyvalue.Visible = true;
                ddlCurreny.Visible = false;


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
                    msgg = "alert('Pan Number is Mandatory for India as Primary Country.')";
                    ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", msgg, true);

                }
                else
                {


                    lnkAddressDetails.Visible = true;
                    lnkAddressDetailsCancel.Visible = false;
                    lnkAddressDetailsSave.Visible = false;

                    txtAddress1.Visible = false;
                    lblAddress1value.Text = txtAddress1.Text;
                    lblAddress1value.Visible = true;

                    txtAddress2.Visible = false;
                    lblAddress2value.Text = txtAddress2.Text;
                    lblAddress2value.Visible = true;

                    txtPrimaryCity.Visible = false;
                    lblPrimaryCityvalue.Text = txtPrimaryCity.Text;
                    lblPrimaryCityvalue.Visible = true;

                    txtSecondaryCity.Visible = false;
                    lblSecondaryCityvalue.Text = txtSecondaryCity.Text;
                    lblSecondaryCityvalue.Visible = true;

                    txtPriamryZipCode.Visible = false;
                    lblPriamryZipCodeValue.Text = txtPriamryZipCode.Text;
                    lblPriamryZipCodeValue.Visible = true;

                    txtSecondaryZipCode.Visible = false;
                    lblSecondaryZipCodeValue.Text = txtSecondaryZipCode.Text;
                    lblSecondaryZipCodeValue.Visible = true;

                    txtPrimaryState.Visible = false;
                    lblPrimaryStatevalue.Text = txtPrimaryState.Text;
                    lblPrimaryStatevalue.Visible = true;

                    txtSecondaryState.Visible = false;
                    lblSecondaryStateValue.Text = txtSecondaryState.Text;
                    lblSecondaryStateValue.Visible = true;



                    lblPanNumberValue.Text = txtPanNumber.Text;
                    lblPanNumberValue.Visible = true;
                    txtPanNumber.Visible = false;

                    ddlPrimaryCountry.Visible = false;
                    lblPrimaryCountryvalue.Text = ddlPrimaryCountry.SelectedItem.Text;
                    lblPrimaryCountryvalue.Visible = true;

                    ddlSecondaryCountry.Visible = false;

                    if (ddlSecondaryCountry.SelectedIndex == 0)
                    {
                        lblSecondaryCountryValue.Visible = false;
                    }
                    else
                    {
                        lblSecondaryCountryValue.Text = ddlSecondaryCountry.SelectedItem.Text;
                        lblSecondaryCountryValue.Visible = true;
                    }


                    GetBuyersProfile();


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
                lblSecondaryCountryValue.Visible = true;
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
                lblEmailPreferenceValue.Visible = true;
                txtPanNumber.Visible = false;
                lblPanNumberValue.Visible = true;


                // ddlEmailPreference.Visible = false;
                chkbxEmailPreference.Visible = false;
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

                if (lnkCurrencyDetailsSave.Visible == true)
                {
                    lnkCurrencyDetailsSave.Visible = false;
                    lnkCurrencyDetails.Visible = true;
                }

                if (lnkcompnameCancel.Visible == true)
                {
                    lnkcompnameCancel.Visible = false;
                }
                if (lnkAddressDetailsCancel.Visible == true)
                {
                    lnkAddressDetailsCancel.Visible = false;
                }

                if (lnkCurrencyDetailsCancel.Visible == true)
                {
                    lnkCurrencyDetailsCancel.Visible = false;
                }

                //email prefernece
                // ddlEmailPreference.Visible = true;
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

                txtCountryCode.Visible = true;
                txtCountryCode.Text = lblCountrycode.Text;
                lblCountrycode.Visible = false;

                txtPhone.Visible = true;
                txtPhone.Text = lblPhonevalue.Text;
                lblPhonevalue.Visible = false;

                txtCountryCode.Visible = true;
                txtCountryCode.Text = lblCountrycode.Text;
                lblCountrycode.Visible = false;

                txtExtension.Visible = true;
                txtExtension.Text = lblExtensionvalue.Text;
                lblExtensionvalue.Visible = false;

                txtMobile.Visible = true;
                txtMobile.Text = lblMobilevalue.Text;
                lblMobilevalue.Visible = false;

                txtFax.Visible = true;
                txtFax.Text = lblFaxvalue.Text;
                lblFaxvalue.Visible = false;

                lblAddress1value.Visible = true;
                txtAddress1.Visible = false;
                lblAddress2value.Visible = true;
                txtAddress2.Visible = false;
                lblPrimaryCountryvalue.Visible = true;
                ddlPrimaryCountry.Visible = false;
                lblSecondaryCountryValue.Visible = true;
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
                //lblContactPersonsNamevalue.Visible = true;
                //txtContactPersonsName.Visible = false;

                lblFirstNameValue.Visible = true;
                lblLastNameValue.Visible = true;
                txtFirstname.Visible = false;
                txtLastName.Visible = false;

                lblSpecializaionValue.Visible = true;
                txtSpecializaion.Visible = false;
                lblCurrencyvalue.Visible = true;
                ddlCurreny.Visible = false;

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

                if (lblEmailvalue.Text != txtEmail.Text && txtGenerateCode.Text == "")
                {
                    string msg;
                    msg = "alert('Generate Verification code to Update the email address.')";
                    ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", msg, true);

                }

                else
                {
                    btnGenerateCode.Visible = false;
                    txtGenerateCode.Visible = false;

                    lnkContactDetails.Visible = true;
                    lnkContactDetailsCancel.Visible = false;
                    lnkContactDetailsSave.Visible = false;

                    //txtEmail.Visible = false;
                    //lblEmailvalue.Text = txtEmail.Text;
                    lblEmailvalue.Visible = true;

                    txtWebsiteurl.Visible = false;
                    lblWebsiteurlvalue.Text = txtWebsiteurl.Text;
                    lblWebsiteurlvalue.Visible = true;

                    txtCountryCode.Visible = false;
                    lblCountrycode.Text = txtCountryCode.Text;
                    lblCountrycode.Visible = true;

                    txtPhone.Visible = false;
                    lblPhonevalue.Text = txtPhone.Text;
                    lblPhonevalue.Visible = true;

                    txtCountryCode.Visible = false;
                    lblCountrycode.Text = txtCountryCode.Text;
                    lblCountrycode.Visible = true;

                    txtExtension.Visible = false;
                    lblExtensionvalue.Text = txtExtension.Text;
                    lblExtensionvalue.Visible = true;

                    txtMobile.Visible = false;
                    lblMobilevalue.Text = txtMobile.Text;
                    lblMobilevalue.Visible = true;

                    txtFax.Visible = false;
                    lblFaxvalue.Text = txtFax.Text;
                    lblFaxvalue.Visible = true;

                    if (txtGenerateCode.Text != "")
                    {
                        if (VerificationCodeCheck())
                        {
                            lblEmailvalue.Text = txtEmail.Text;
                        }
                        else
                        {
                            string msgg;
                            msgg = "alert('Incorrect input of email address or verification code. Please try again!!!')";
                            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", msgg, true);

                        }
                    }
                    txtEmail.Visible = false;


                    //email Prefernce
                    // ddlEmailPreference.Visible = false;
                    chkbxEmailPreference.Visible = false;
                    lblEmailPreferenceValue.Visible = true;

                    GetBuyersProfile();

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

                btnGenerateCode.Visible = false;
                txtGenerateCode.Visible = false;

                lnkContactDetails.Visible = true;
                lnkContactDetailsCancel.Visible = false;
                lnkContactDetailsSave.Visible = false;

                //Email Prefernece
                // ddlEmailPreference.Visible = false;
                chkbxEmailPreference.Visible = false;

                lblEmailPreferenceValue.Visible = true;

                lblEmailvalue.Visible = true;
                txtEmail.Visible = false;
                lblWebsiteurlvalue.Visible = true;
                txtWebsiteurl.Visible = false;
                lblCountrycode.Visible = true;
                txtCountryCode.Visible = false;
                lblPhonevalue.Visible = true;
                txtPhone.Visible = false;
                lblExtensionvalue.Visible = true;
                txtExtension.Visible = false;
                lblMobilevalue.Visible = true;
                txtMobile.Visible = false;
                lblFaxvalue.Visible = true;
                txtFax.Visible = false;
                txtGenerateCode.Text = "";

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void lnkCurrencyDetails_Click1(object sender, EventArgs e)
        {
            try
            {
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
                if (lnkContactDetailsCancel.Visible == true)
                {
                    lnkContactDetailsCancel.Visible = false;
                }

                if (lnkAddressDetailsCancel.Visible == true)
                {
                    lnkAddressDetailsCancel.Visible = false;
                }

                btnGenerateCode.Visible = false;
                txtGenerateCode.Visible = false;

                lnkCurrencyDetails.Visible = false;
                lnkCurrencyDetailsCancel.Visible = true;
                lnkCurrencyDetailsSave.Visible = true;

                txtSpecializaion.Visible = true;
                txtSpecializaion.Text = lblSpecializaionValue.Text;
                lblSpecializaionValue.Visible = false;

                ddlCurreny.Visible = true;
                ddlCurreny.SelectedValue = lblCurrencyvalue.Text;
                lblCurrencyvalue.Visible = false;
                lblEmailPreferenceValue.Visible = true;
                //ddlEmailPreference.Visible = false;
                chkbxEmailPreference.Visible = false;


                lblAddress1value.Visible = true;
                txtAddress1.Visible = false;
                lblAddress2value.Visible = true;
                txtAddress2.Visible = false;
                lblPrimaryCountryvalue.Visible = true;
                ddlPrimaryCountry.Visible = false;
                lblSecondaryCountryValue.Visible = true;
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

                lblEmailvalue.Visible = true;
                txtEmail.Visible = false;

                lblWebsiteurlvalue.Visible = true;
                txtWebsiteurl.Visible = false;
                lblCountrycode.Visible = true;
                txtCountryCode.Visible = false;
                lblPhonevalue.Visible = true;
                txtPhone.Visible = false;
                lblExtensionvalue.Visible = true;
                txtExtension.Visible = false;
                lblMobilevalue.Visible = true;
                txtMobile.Visible = false;
                lblFaxvalue.Visible = true;
                txtFax.Visible = false;

                lblcompnamevalue.Visible = true;
                txtcompnamevalue.Visible = false;
                lblOwnersnamevalue.Visible = true;
                txtOwnersnamevalue.Visible = false;
                //lblContactPersonsNamevalue.Visible = true;
                //txtContactPersonsName.Visible = false;

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

        protected void lnkCurrencyDetailsSave_Click1(object sender, EventArgs e)
        {
            try
            {


                lnkCurrencyDetails.Visible = true;
                lnkCurrencyDetailsCancel.Visible = false;
                lnkCurrencyDetailsSave.Visible = false;

                lblSpecializaionValue.Visible = true;
                lblSpecializaionValue.Text = txtSpecializaion.Text;
                txtSpecializaion.Visible = false;

                ddlCurreny.Visible = false;
                lblCurrencyvalue.Text = ddlCurreny.SelectedItem.Text;
                lblCurrencyvalue.Visible = true;

                GetBuyersProfile();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void lnkCurrencyDetailsCancel_Click1(object sender, EventArgs e)
        {
            try
            {
                lnkCurrencyDetails.Visible = true;
                lnkCurrencyDetailsCancel.Visible = false;
                lnkCurrencyDetailsSave.Visible = false;

                lblSpecializaionValue.Visible = true;
                txtSpecializaion.Visible = false;

                lblCurrencyvalue.Visible = true;
                ddlCurreny.Visible = false;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void btnGenerateCode_Click1(object sender, EventArgs e)
        { string UserName="UserName";
            if (lblEmailvalue.Text != txtEmail.Text)
            {
                if (txtEmail.Text.Trim() != "")
                {

                    string secretcode = generateSecretCode();
                    ViewState["SecretGeneratedKey"] = secretcode;
                    ViewState["EmailAddressAssociatedToSecretKey"] = txtEmail.Text.Trim();
                    Hashtable hash = new Hashtable
                                     {
                                         {"UserName", UserName},
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
                        msg1 = "alert('Verification code has been sent to your email address. Please enter your verification code!')";
                        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", msg1, true);
                        btnGenerateCode.Visible = true;
                    }

                    else
                    {
                        // error sending mail.

                        string msg2;
                        msg2 = "alert('Error has occurred in sending mail. Please try again later!!')";
                        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "CloseWindow", msg2, true);
                        btnGenerateCode.Visible = true;
                        btnGenerateCode.Visible = true;
                    }
                }

            }
            else
            {
                string msg3;
                msg3 = "alert('No change made to Email!!')";
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

        protected void ddlPrimaryCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlPrimaryCountry.SelectedItem.Text == "INDIA" || ddlSecondaryCountry.SelectedItem.Text == "INDIA")
            //{
            //    txtPanNumber.Visible = true;
            //    txtPanNumber.Text = lblPanNumberValue.Text;
            //    lblPanNumberValue.Visible = false;
            //}
            //else
            //{
            //    txtPanNumber.Visible = false;
            //    lblPanNumberValue.Visible = true;
            //    txtPanNumber.Text = lblPanNumberValue.Text;
            //}
        }

       

      
        protected void btnUpgradeMembership_Click(object sender, EventArgs e)
        {
            Response.Redirect("SellerSubscription.aspx?prfl=prfl");
        }
    }
}