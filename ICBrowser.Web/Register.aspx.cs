using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ICBrowser.Common;
using ICBrowser.Business;
using System.Collections.Specialized;
using System.Data;
using System.Collections;

namespace ICBrowser.Web
{
    public partial class Register : BasePage
    {
        public string AbsolutePath { get; set; }

        /// <summary>
        /// Page Load event to customize view of the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLink hyp = (HyperLink)this.Page.Master.FindControl("hyp_log");
            hyp.Visible = false;

            if (!IsPostBack)
            {
                //pnlLogin.Visible = true;
                pnlRegister.Visible = false;

                // If its a new user, show registration form
                if (Request.QueryString["isNew"] != null && Request.QueryString["isNew"] == "1")
                {
                    pnlRegister.Visible = true;
                    //pnlLogin.Visible = false;
                }

                if (Request.QueryString["SellerId"] != null)
                {
                    string querystr = Request.QueryString["SellerId"];
                    Session["querystr"] = querystr;
                }

                if (Request.QueryString["Id"] != null)
                {
                    string querystr = Request.QueryString["Id"];
                    Session["buyerstr"] = querystr;
                }

                if (Request.UrlReferrer != null && Request.UrlReferrer.OriginalString != null)
                {
                    AbsolutePath = Request.UrlReferrer.OriginalString;
                    Session["AbsolutePath"] = AbsolutePath;
                }

                try
                {
                    // Read list of countries from XML into dataset
                    DataSet dsCountries = new DataSet();
                    string filepath = Server.MapPath("/data/List Of Countries.xml");
                    dsCountries.ReadXml(filepath);

                    // Bind dropdownlist of 'Primary Country' with list of countries
                    //ddlPrimaryCountry.DataSource = dsCountries.Tables[0];
                    //ddlPrimaryCountry.DataTextField = "Name";
                    //ddlPrimaryCountry.DataValueField = "CountryID";
                    //ddlPrimaryCountry.DataBind();

                    // Bind dropdownlist of 'Secondary Country' with list of countries
                    //ddlSecondaryCountry.DataSource = dsCountries.Tables[0];
                    //ddlSecondaryCountry.DataTextField = "Name";
                    //ddlSecondaryCountry.DataValueField = "CountryID";
                    //ddlSecondaryCountry.DataBind();
                    addDefault();
                }
                catch (Exception ex)
                {
                    // Log the exception message
                    IClogger.LogError(ex.Message);
                }
            }
        }

        private void addDefault()
        {
            ddlMemberType.Text = "Buyer";
            tbxFirstName.Text = "Alfiya";
            tbxLastName.Text = "Anjum";
            tbxCompanyName.Text = "PraveenCompany";
            tbxWebsite.Text = "google.com";
            txtMobNo.Text = "8319358125";
            txtCCdMobno.Text = "+91";
            tbxCountryCode.Text = "+91";
            tbxCityCode.Text = "0771";
            tbxPhoneNumber.Text = "1234567";
            tbxCountryCode1.Text = "+91";
            tbxCityCode1.Text = "0771";
            tbxFax.Text = "6543";
            tbxGstNumber.Text = "GSTNumber";
            tbxPrimaryAddress.Text = "address";
            tbxPrimaryCity.Text = "Raipur";
            tbxPrimaryState.Text = "State";
            tbxPrimaryCountry.Text = "India";
            tbxPrimaryZip.Text = "492001";
            tbxMsnId.Text = "asd";
            tbxSkypeId.Text = "skype";
            tbxQQId.Text = "ID";
            tbxEmail.Text = "alfiyaanjum21@gmail.com";
            tbxUserName.Text = "Oshin";
            tbxPassword.Text = "asdfgh";
            tbxConfirmPassword.Text = "asdfgh";
            tbxGstNumber.Text = "GSTIN1234567111";
        }
        /// <summary>
        /// Creates new ASP Membership User
        /// </summary>
        /// <returns></returns>
        private string CreateNewUser()
        {
            try
            {
                // Create new User with Email Address as username
                MembershipUser user = Membership.CreateUser(tbxUserName.Text.Trim(), tbxPassword.Text.Trim(), tbxEmail.Text.Trim());
                Membership.ValidateUser(tbxUserName.Text.Trim(), tbxPassword.Text.Trim());

                return user.ProviderUserKey.ToString();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                return "";
            }
        }

        /// <summary>
        /// Event for 'Submit' button click, to register an user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UserProfileDetails usrProflDetails = new UserProfileDetails();
            //|| (ddlSecondaryCountry.SelectedItem.Text == "INDIA" && tbxPanNumber.Text == "")
            //if ((ddlPrimaryCountry.SelectedItem.Text == "INDIA"))
            //{
            //    //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Please Enter Pan Number if selected country is INDIA');</script>");
            //    lblSuccess.Visible = false;
            //    lblError.Visible = true;
            //    lblError.Text = "Please Enter Taxpayer Identification Number.";
            //}
            //else
            //{
            // txtCaptcha.IsValid
            if (true)// condition for captcha
            {
                //if (VerificationCodeCheck())
                {
                    // If User has accepted legal agreement
                    if (chk.Checked == true)
                    {
                        lblAgreementMsg.Visible = false;

                        // Create a new ASP user for Buyer
                        string userIdString = CreateNewUser();
                        if (!userIdString.Equals(""))
                        {
                            Guid newUserId = new Guid(userIdString);

                            // Create new Buyer Object and update details
                            UserDetails newUser = new UserDetails();
                            newUser.UserName = tbxUserName.Text.Trim();
                            newUser.CompanyName = tbxCompanyName.Text.Trim();
                            string firstName = tbxFirstName.Text.Trim();
                            string lastName = tbxLastName.Text.Trim();
                            newUser.ContactName = firstName + " " + lastName;
                            newUser.UserID = newUserId;
                            newUser.Currency = "INR";
                            newUser.GstNumber = tbxGstNumber.Text.Trim();
                            //if (tbxOwnerName.Text.Trim() != "")
                            //    newUser.OwnerName = tbxOwnerName.Text.Trim();
                            //else
                            //    newUser.OwnerName = string.Empty;
                            //if (tbxSpecialization.Text.Trim() != "")
                            //    newUser.Specialization = tbxSpecialization.Text.Trim();
                            //else
                            //    newUser.Specialization = string.Empty;
                            //if (tbxPanNumber.Text.Trim() != "")
                            //    newUser.PanNumber = tbxPanNumber.Text.Trim();
                            //else
                            //    newUser.PanNumber = string.Empty;
                            newUser.EmailPreference = 1;
                            newUser.CreateDate = DateTime.Now;

                            // Enter Buyer's details into database
                            BuyerRegistration registerUser = new BuyerRegistration();
                            if (ddlMemberType.SelectedItem.Text == "Buyer (Free)")
                            {
                                newUser.IsDecline = 2;
                            }
                            else
                            {
                                newUser.IsDecline = 0;
                            }

                            bool statusNewRegisterUser = registerUser.AddUserDetails(newUser);
                            // Create new Buyer Address object and update details
                            AddressDetails newUserAddressDetails = new AddressDetails();

                            // Add mandatory information
                            newUserAddressDetails.UserId = newUserId;
                            newUserAddressDetails.PrimaryAddress = tbxPrimaryAddress.Text.Trim();
                            newUserAddressDetails.PrimaryCity = tbxPrimaryCity.Text.Trim();
                            newUserAddressDetails.PrimaryCountry = tbxPrimaryCountry.Text.Trim();
                            newUserAddressDetails.PrimaryZip = tbxPrimaryZip.Text.Trim();
                            newUserAddressDetails.LandLine = tbxCountryCode.Text.Trim() + "-" + tbxCityCode.Text.Trim() + "-" + tbxPhoneNumber.Text.Trim();
                            if (txtMobNo.Text.Trim() != "")
                                newUserAddressDetails.Mobile = txtCCdMobno.Text.Trim() + "-" + txtMobNo.Text.Trim();

                            if (tbxPrimaryState.Text.Trim() != "")
                                newUserAddressDetails.PrimaryState = tbxPrimaryState.Text.Trim();

                            // Add non-mandatory information                        
                            //if (tbxSecondaryAddress.Text.Trim() != "")
                            //    newUserAddressDetails.SecondaryAddress = tbxSecondaryAddress.Text.Trim();
                            //if (tbxSecondaryCity.Text.Trim() != "")
                            //    newUserAddressDetails.SecondaryCity = tbxSecondaryCity.Text.Trim();
                            //if (tbxSecondaryState.Text.Trim() != "")
                            //    newUserAddressDetails.SecondaryState = tbxSecondaryState.Text.Trim();
                            //if (ddlSecondaryCountry.SelectedItem.Text != "- Select -")
                            //    newUserAddressDetails.SecondaryCountry = ddlSecondaryCountry.SelectedItem.Text;
                            //if (tbxSecondaryZip.Text.Trim() != "")
                            //    newUserAddressDetails.SecondaryZip = tbxSecondaryZip.Text.Trim();
                            if (tbxFax.Text.Trim() != "")
                                newUserAddressDetails.FaxNumber = tbxCountryCode1.Text.Trim() + "-" + tbxCityCode1.Text.Trim() + "-" + tbxFax.Text.Trim();
                            //if (tbxExtension.Text.Trim() != "")
                            //    newUserAddressDetails.Extension = tbxExtension.Text.Trim();
                            if (tbxWebsite.Text.Trim() != "")
                                newUserAddressDetails.Website = tbxWebsite.Text.Trim();
                            if (tbxQQId.Text.Trim() != "")
                                newUserAddressDetails.QQId = tbxQQId.Text.Trim();
                            if (tbxSkypeId.Text.Trim() != "")
                                newUserAddressDetails.SkypeId = tbxSkypeId.Text.Trim();
                            if (tbxMsnId.Text.Trim() != "")
                                newUserAddressDetails.MSNId = tbxMsnId.Text.Trim();

                            // Enter Buyer's address details into database
                            bool statusAddressDetails = registerUser.AddAddressDetails(newUserAddressDetails);

                            SellerRegistration registerSeller = new SellerRegistration();
                            TypeOfMembership trialMembership = registerSeller.GetTrialMembership();
                            try
                            {
                                // Log in registered buyer
                                MembershipUser CurrentUser = Membership.GetUser(tbxUserName.Text.Trim());
                                FormsAuthentication.SetAuthCookie(tbxUserName.Text.Trim(), false);
                                if (ddlMemberType.SelectedItem.Text == "Buyer (Free)")
                                {
                                    bool status = registerUser.CreateUserMembershipDetails(newUserId, 1, null);
                                    System.Web.Security.FormsAuthentication.SignOut();
                                    Session.Abandon();
                                    ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('You have registered successfully.');window.location='Default.aspx';</script>");
                                    //Response.Redirect("Default.aspx", false);
                                    //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('You have registered successfully.');window.location='Default.aspx';</script>");
                                    //lblError.Visible = false;
                                    //lblSuccess.Visible = true;
                                    //lblSuccess.Text = "You have registered successfully.";
                                }
                                else if (ddlMemberType.SelectedItem.Text == "Buyer & Seller(Trial 30 Days)")
                                {
                                    DateTime expDate = DateTime.Now.AddDays(trialMembership.Duration);
                                    bool status = registerUser.CreateUserMembershipDetails(newUserId, 2, expDate);
                                    System.Web.Security.FormsAuthentication.SignOut();
                                    Session.Abandon();
                                    //bool block = usrProflDetails.SetUsrBlock(newUserId);
                                    ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('You have registered successfully. Account will be activated within 2 or 3 working days.');window.location='Default.aspx';</script>");
                                    //this.Master.HeadLoginStatus_LoggedOut(sender, e);
                                }
                                else
                                {
                                    DateTime expDate = DateTime.Now.AddDays(trialMembership.Duration);
                                    bool status = registerUser.CreateUserMembershipDetails(newUserId, 1, expDate);
                                    //System.Web.Security.FormsAuthentication.SignOut();
                                    //Session.Abandon();
                                    Response.Redirect("SellerSubscription.aspx?page=register", false);
                                }
                                //lblVerificationErrorMessage.Visible = false;
                            }
                            catch (Exception ex)
                            {
                                // Log the exception message
                                IClogger.LogError(ex.Message);
                            }
                            // Show alert and redirect to landing page
                            if (statusNewRegisterUser == true && statusAddressDetails == true)
                            {
                                //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('You have registered successfully.');window.location='Default.aspx';</script>");
                                lblError.Visible = false;
                                lblSuccess.Visible = true;
                                lblSuccess.Text = "You have registered successfully.";
                            }
                        }
                        else
                        {
                            // Show alert that User already exists
                            //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('This UserName already exist!');</script>");
                            lblSuccess.Visible = false;
                            lblError.Visible = true;
                            lblError.Text = "This UserName already exist.";
                        }
                    }
                    else
                    {
                        // Incorrect Validation Code or Capcha Code
                        //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Please select ICBrowser Legal Agreement.');</script>");
                        lblSuccess.Visible = false;
                        lblError.Visible = true;
                        lblError.Text = "Please select ICBrowser Legal Agreement.";
                    }
                }
                //else
                //{
                //    //lblVerificationErrorMessage.Visible = true;
                //    //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Incorrect input of email address or verification code. Please try again.');</script>");
                //    lblSuccess.Visible = false;
                //    lblError.Visible = true;
                //    lblError.Text = "Incorrect input of email address or verification code. Please try again.";
                //}
            }
            // }
        }

        /// <summary>
        /// Event for 'Clear' button click, to clear controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            // Clear selections in dropdownlists
            //ddlCurrency.ClearSelection();
            ddlMemberType.ClearSelection();
            // ddlPrimaryCountry.ClearSelection();
            //ddlSecondaryCountry.ClearSelection();
            //chkEmailPrefrence.Checked = false;

            // Clear checkbox & textboxes
            chk.Checked = false;
            tbxEmail.Text = "";
            tbxPassword.Text = "";
            tbxConfirmPassword.Text = "";
            tbxCompanyName.Text = "";
            tbxFirstName.Text = "";
            tbxLastName.Text = "";
            //  tbxOwnerName.Text = "";
            tbxPrimaryAddress.Text = "";
            tbxPrimaryCity.Text = "";
            tbxPrimaryState.Text = "";
            tbxPrimaryZip.Text = "";
            //tbxSecondaryAddress.Text = "";
            //tbxSecondaryCity.Text = "";
            //tbxSecondaryState.Text = "";
            //tbxSecondaryZip.Text = "";
            txtMobNo.Text = "";
            txtCCdMobno.Text = "";
            tbxPrimaryCountry.Text = "";
            tbxGstNumber.Text = "";
            tbxCountryCode.Text = "";
            tbxPhoneNumber.Text = "";
            tbxCityCode.Text = "";
            tbxCityCode1.Text = "";
            tbxCountryCode1.Text = "";
            // tbxExtension.Text = "";
            tbxFax.Text = "";
            tbxWebsite.Text = "";

            tbxMsnId.Text = "";
            tbxQQId.Text = "";
            tbxSkypeId.Text = "";
            //tbxSpecialization.Text = "";
            lblError.Text = "";
            lblSuccess.Text = "";
            lblError.Visible = false;
            lblSuccess.Visible = false;
            //tbxPanNumber.Text = "";
        }

        /// <summary>
        /// Handles the Click event of the lbtnCreateUsr control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lbtnCreateUsr_Click(object sender, EventArgs e)
        {
            pnlRegister.Visible = true;
            //pnlLogin.Visible = false;
            var nameValueCollection = HttpUtility.ParseQueryString(HttpContext.Current.Request.QueryString.ToString());
            nameValueCollection.Add("isNew", "1");
            Response.Redirect(HttpContext.Current.Request.Path + "?" + nameValueCollection);
        }

        #region "Verification"
        //protected void btnGenerateCode_Click(object sender, EventArgs e)
        //{
        //    string userName = "User";
        //    if (tbxEmail.Text.Trim() != "")
        //    {
        //        string secretcode = generateSecretCode();
        //        ViewState["SecretGeneratedKey"] = secretcode;
        //        ViewState["EmailAddressAssociatedToSecretKey"] = tbxEmail.Text.Trim();
        //        Hashtable hash = new Hashtable
        //                             {
        //                                 {"UserName", userName},
        //                                 {"AccountType", "Verification"},
        //                                 {"Password", secretcode}
        //                             };

        //        EmailFactory mailFactory = new EmailFactory();
        //        Email mail = mailFactory.GetAccountRequestMail(tbxEmail.Text.Trim(), "support@icbrowser.com", hash);

        //        if (mail.Send())
        //        {
        //            // success mail sending
        //            //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "alert('Verification code has been send to your email address. Please enter your verification code.');");
        //            //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Verification code has been sent to your Email address. Please enter your verification code!');</script>");
        //            lblError.Visible = false;
        //            lblSuccess.Visible = true;
        //            lblSuccess.Text = "Verification code has been sent to your Email address. Please enter your verification code.";

        //            btnSubmit.Visible = true;
        //            //btnGenerateCode.Visible = true;
        //        }
        //        else
        //        {
        //            // error sending mail.
        //            //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "alert('Error has occurred in sending mail. Please try again later!');");
        //            //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Error has occurred in sending mail. Please try again later!');</script>");
        //            lblSuccess.Visible = false;
        //            lblError.Visible = true;
        //            lblError.Text = "Error has occurred in sending mail. Please try again later.";

        //            btnSubmit.Visible = false;
        //            //btnGenerateCode.Visible = true;
        //        }
        //    }
        //    else
        //    {
        //        //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Please enter Email Address!');</script>");
        //        lblSuccess.Visible = false;
        //        lblError.Visible = true;
        //        lblError.Text = "Please enter Email Address.";
        //    }
        //}

        //private string generateSecretCode()
        //{
        //    string pinPwd = string.Empty;
        //    int j = 0;      //for Upper Case because it will generate the Character same as like ch[i] doing.

        //    Random rnd = new Random();    // random class for random generate the numbers using .Next()

        //    for (int i = 0; i <= 2; i++) // For loop
        //    {
        //        j = j + 1;      //increment the J variable for Random Characters.

        //        // Create nums Array.
        //        int[] nums = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        //        // create an characters Array for it.
        //        char[] ch = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        //        char[] spc = new[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };

        //        nums[i] = nums[rnd.Next(0, 9)];
        //        ch[i] = ch[rnd.Next(0, 20)];
        //        ch[j] = ch[rnd.Next(0, 25)];
        //        spc[i] = spc[rnd.Next(0, 9)];

        //        pinPwd += nums[i].ToString() + ch[i].ToString() + ch[j].ToString().ToUpper() + spc[i].ToString();

        //        // just add/append the nums and ch in pin_pwd.
        //        //pin_pwd will store the string of random generated password.
        //    }
        //    return pinPwd;
        //}

        //private bool VerificationCodeCheck()
        //{
        //    if (ViewState["SecretGeneratedKey"] != null && ViewState["EmailAddressAssociatedToSecretKey"] != null)
        //    {
        //        string secretcode = ViewState["SecretGeneratedKey"].ToString();
        //        if (tbxVerificationCode.Text.Trim() != "" || tbxVerificationCode.Text.Trim() != null)
        //        {
        //            if (tbxVerificationCode.Text.Trim().Equals(secretcode) && ViewState["EmailAddressAssociatedToSecretKey"].Equals(tbxEmail.Text.Trim()))
        //            {
        //                return true;
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    return false;
        //}
        #endregion

        /// <summary>
        /// Handles the Click event of the btnAvailablility control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnAvailablility_Click(object sender, EventArgs e)
        {
            BuyerRegistration registerUser = new BuyerRegistration();
            bool flag = registerUser.checkAvailability(tbxUserName.Text);
            if (flag)
            {
                imgAvail.Visible = true;
                imgNotAvail.Visible = false;
            }
            else
            {
                imgAvail.Visible = false;
                imgNotAvail.Visible = true;
            }
        }

        //protected void lnkbtnGenerateCode_Click(object sender, EventArgs e)
        //{
        //    string userName = "User";
        //    if (tbxUserName.Text.Trim() != "" || tbxUserName.Text.Trim() != "")
        //    {
        //        userName = tbxUserName.Text.Trim();
        //    }

        //    if (tbxEmail.Text.Trim() != "")
        //    {
        //        string secretcode = generateSecretCode();
        //        ViewState["SecretGeneratedKey"] = secretcode;
        //        ViewState["EmailAddressAssociatedToSecretKey"] = tbxEmail.Text.Trim();
        //        Hashtable hash = new Hashtable
        //                             {
        //                                 {"UserName", userName},
        //                                 {"AccountType", "Verification"},
        //                                 {"Password", secretcode}
        //                             };

        //        EmailFactory mailFactory = new EmailFactory();
        //        Email mail = mailFactory.GetAccountRequestMail(tbxEmail.Text.Trim(), "support@icbrowser.com", hash);

        //        if (mail.Send())
        //        {
        //            // success mail sending
        //            //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "alert('Verification code has been send to your email address. Please enter your verification code.');");
        //            //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Verification code has been sent to your Email address. Please enter your verification code!');</script>");
        //            lblError.Visible = false;
        //            lblSuccess.Visible = true;
        //            lblSuccess.Text = "Verification code has been sent to your Email address. Please copy/paste the verification code in the box given before proceeding for registration.";

        //            btnSubmit.Visible = true;

        //        }
        //        else
        //        {
        //            // error sending mail.
        //            //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "alert('Error has occurred in sending mail. Please try again later!');");
        //            //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Error has occurred in sending mail. Please try again later!');</script>");
        //            lblSuccess.Visible = false;
        //            lblError.Visible = true;
        //            lblError.Text = "Error has occurred in sending mail. Please try again later.";

        //            btnSubmit.Visible = false;
        //            //btnGenerateCode.Visible = true;
        //        }
        //    }
        //    else
        //    {
        //        //ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Please enter Email Address!');</script>");
        //        lblSuccess.Visible = false;
        //        lblError.Visible = true;
        //        lblError.Text = "Please enter Email Address.";
        //    }
        //}


        /// <summary>
        /// Handles the Click event of the lbtnPreview control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lbtnPreview_Click(object sender, EventArgs e)
        {
            ibtnPreview.ImageUrl = "Images/ICBrowserFees.PNG";
            modpopPreview.Show();
            ibtnPreview.Visible = true;
        }

        /// <summary>
        /// Handles the Click event of the btnPreviewClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnPreviewClose_Click(object sender, EventArgs e)
        {
            modpopPreview.Hide();
        }

        /// <summary>
        /// Handles the Click event of the ibtnPreview control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void ibtnPreview_Click(object sender, ImageClickEventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "RedirectURL", "<script>window.open('" + ibtnPreview.ImageUrl + "');</script>");
        }
        //protected void ddlPrimaryCountry_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlPrimaryCountry.SelectedItem.Text.Equals("INDIA"))
        //    {

        //    }
        //}
    }
}