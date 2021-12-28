using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Security;
using ICBrowser.Common;
using ICBrowser.Business;
using System.Threading;
using System.Globalization;
using System.Collections;

namespace ICBrowser.Web
{
    public partial class SellerSubscription : BasePage
    {
        private const String TRANSACTION_PREFIX = "MOID";
        public Controller PageController = new Controller();
        HiddenField hidMerchantOrderId = new HiddenField();

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

            dvsilver.Visible = false;
            dvGold.Visible = false;

            try
            {


                if (!IsPostBack)
                {
                    if (Request.QueryString["prfl"] != null && Request.QueryString["prfl"] == "prfl")
                    {
                        string userid = Request.QueryString["userid"];
                        lblChooseMembership.Visible = false;
                        btnCancel.Visible = false;
                        UserDetails obj = PageController.GetSellerDetailById(userid);
                    }
                    else
                    {
                        UserDetails obj = PageController.GetSellerDetailById(Membership.GetUser().ProviderUserKey.ToString());
                    }
                }

                if (Request.QueryString["page"] != null && Request.QueryString["page"] == "register" || Request.QueryString["userid"] != null)
                {
                    SellerRegistration sellerMemberships = new SellerRegistration();
                    List<TypeOfMembership> membershipPackages = sellerMemberships.GetMembershipPackageDetails();

                    TypeOfMembership trial = membershipPackages.Find(a => a.MembershipTypeName == "Trial");
                    lblTrialNoOfListings.Text = trial.ListingCount.ToString();
                    lblTrialNoofofferlimit.Text = trial.OfferLimit.ToString();
                    lblTrialNoOfMonths.Text = trial.Duration.ToString();

                    TypeOfMembership silver = membershipPackages.Find(a => a.MembershipTypeName == "Silver");
                    lblSilverNoOfListings.Text = silver.ListingCount.ToString();
                    lblSilverNoofOfferlimit.Text = silver.OfferLimit.ToString();
                    lblSilverNoOfMonths.Text = silver.Duration.ToString();
                    lblSilverPrice.Text = silver.Amount.ToString();

                    TypeOfMembership gold = membershipPackages.Find(a => a.MembershipTypeName == "Gold");
                    lblGoldNoOfListings.Text = gold.ListingCount.ToString();
                    lblGoldNoofOfferLimit.Text = gold.OfferLimit.ToString();
                    lblGoldNoOfMonths.Text = gold.Duration.ToString();
                    lblGoldPrice.Text = gold.Amount.ToString();

                    TypeOfMembership platinum = membershipPackages.Find(a => a.MembershipTypeName == "Platinum");
                    lblPlatinumNoOfListings.Text = platinum.ListingCount.ToString();
                    lblPlatinumNoOfferLimit.Text = platinum.OfferLimit.ToString();
                    lblPlatinumNoOfMonths.Text = platinum.Duration.ToString();
                    lblPlatinumPrice.Text = platinum.Amount.ToString();
                    lblPlatinumPriceUSD.Text = platinum.AmountUSD.ToString();
                }
                //else if (Request.QueryString["prfl"] != null && Request.QueryString["prfl"] == "prfl")
                //{
                //    Common.UserProfile UserPrfl = new Common.UserProfile();
                //    UserPrfl = (Common.UserProfile)Session["UserProfile"];
                //    if (UserPrfl.TypeOfMembership != null)
                //    {

                //    }
                //}
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string merchantOrderId = InitiateTransaction();
                if (!String.IsNullOrEmpty(merchantOrderId))
                {
                    string subscriptionType = "";
                    string membershipAmount = "";
                    if (rbtnSilver.Checked == true)
                    {
                        subscriptionType = "SILVER";
                        membershipAmount = lblSilverPrice.Text;
                    }
                    else if (rbtnGold.Checked == true)
                    {
                        subscriptionType = "GOLD";
                        membershipAmount = lblGoldPrice.Text;
                    }
                    else if (rbtnPlatinum.Checked == true)
                    {
                        subscriptionType = "PLATINUM";
                        membershipAmount = lblPlatinumPrice.Text;
                    }
                    Session["SubscriptionDet"] = merchantOrderId + "|" + subscriptionType + "|" + membershipAmount;
                }

                Response.Redirect("transactionpage.aspx", true);

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Initiates the transaction.
        /// </summary>
        /// <returns>System.String.</returns>
        private string InitiateTransaction()
        {
            try
            {
                var membershipUser = Membership.GetUser();
                if (membershipUser != null)
                {
                    string MerchantOrderId = TRANSACTION_PREFIX;
                    string UserId = Membership.GetUser().ProviderUserKey.ToString();
                    Guid userid = new Guid(UserId);
                    TransactionDetails transaction =
                        new TransactionDetails
                        {
                            DirectPayReferenceID = 0,
                            UserID = userid,
                            MerchantOrderNo = "",
                            TransactionDate = DateTime.Now,
                            Status = Convert.ToInt32(TransactionState.INITIATE),
                            Amount = Convert.ToDecimal(0.00),
                            MembershipType = Convert.ToInt32(MembershipType.TRIAL),
                            Description = ""
                        };
                    PageController.Create(transaction);
                    Session.Add("MerchantOrder", transaction.TransactionId);
                    MerchantOrderId = MerchantOrderId + transaction.TransactionId.ToString().PadLeft(6, '0');
                    return MerchantOrderId;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
                return string.Empty;
            }

        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {

            UserProfileDetails usrProflDetails = new UserProfileDetails();
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;
            // on click of continue as trial user will become trial user from free member i.e membership of user will change into 2 from 1 which is set on registration page for every new user.
            usrProflDetails.SetMemberShipTypeForTrialUser(currUserId);


            //bool block = usrProflDetails.SetUsrBlock(currUserId);
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Account will be activated within 2 or 3 working days.');</script>");
            this.Master.HeadLoginStatus_LoggedOut(sender, e);

        }

        /// <summary>
        /// Updates the offline user membership details.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void UpdateOfflineUserMembershipDetails(UserMembershipDetails obj)
        {
            try
            {
                Guid userId = new Guid(Request.QueryString["userid"]);
                obj.PaymentOption = 0;//offline payment.
                obj.PaymentStatus = false;//offline status
                obj.UserId = userId;
                Master.PageController.UpdateUserMembershipDetails(obj);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Offlines the send mail.
        /// </summary>
        private void OfflineSendMail()
        {
            try
            {
                UserProfileDetails objUserProfileDetails = new UserProfileDetails();

                MembershipUser userToLogin = Membership.GetUser();
                Guid userid = new Guid(Request.QueryString["userid"]);
                Common.UserProfile objLoggedInUser = new Common.UserProfile();
                objLoggedInUser = objUserProfileDetails.GetUserProfileDetails(userid);
                if (objLoggedInUser != null)
                {
                    Hashtable hash = new Hashtable
                                     {
                                         {"ToUserName", objLoggedInUser.ContactName},
                                         {"FromUserName", "Administrator"},
                                     };

                    // Send Email
                    EmailFactory mailFactory = new EmailFactory();
                    Email mail = mailFactory.SentDefaultTemplateToSeller(objLoggedInUser.email, "support@icbrowser.com", hash);
                    if (mail.Send())
                    {
                        ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Your account has been activated.\\nThank You, Your new member request has been successfully submitted.\\nA customer service representative will review and verify all information you have provided.\\nAdditional information may be required. Please allow 2-3 business days for the approval process.\\nNeed Help? Email support or call us at 091 22 21026611.\\nICBrowser © All Rights Reserved.\\nNIKEE INFOTECH 20,\\nRameshwar,V B Lane,Ghatkopar(E)\\nMumbai 400 077, India.\\nPhone: 091 22 21026611.');window.location='Default.aspx';</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Create New Login Account');window.location='Default.aspx';</script>");
                    }

                }
            }

            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }
        }

        //protected void ddlpayementtype_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
        //update Offline membership.

        /// <summary>
        /// Handles the CheckedChanged event of the rbtnSilver control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void rbtnSilver_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the CheckedChanged event of the rbtnGold control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void rbtnGold_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the CheckedChanged event of the rbtnPlatinum control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void rbtnPlatinum_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnsubsc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnsubsc_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlpayementtype.SelectedValue.Equals("1")) // 1 = Online Mode
                {
                    ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Please Select Offline Payment option; Online Payment option is Under Process.');</script>");
                    //string merchantOrderId = InitiateTransaction();
                    //if (!String.IsNullOrEmpty(merchantOrderId))
                    //{
                    //    string subscriptionType = "";
                    //    string membershipAmount = "";
                    //    if (rbtnSilver.Checked == true)
                    //    {
                    //        subscriptionType = "SILVER";
                    //        membershipAmount = lblSilverPrice.Text;
                    //    }
                    //    else if (rbtnGold.Checked == true)
                    //    {
                    //        subscriptionType = "GOLD";
                    //        membershipAmount = lblGoldPrice.Text;
                    //    }
                    //    else if (rbtnPlatinum.Checked == true)
                    //    {
                    //        subscriptionType = "PLATINUM";
                    //        membershipAmount = lblPlatinumPrice.Text;
                    //    }
                    //    Session["SubscriptionDet"] = merchantOrderId + "|" + subscriptionType + "|" + membershipAmount;
                    //}

                    //Response.Redirect("transactionpage.aspx", false);

                }
                else if (ddlpayementtype.SelectedValue.Equals("2")) // 0 = Offline Mode
                {

                    string merchantOrderId = InitiateTransaction();
                    if (!String.IsNullOrEmpty(merchantOrderId))
                    {
                        UserMembershipDetails obj = new UserMembershipDetails();

                        string subscriptionType = "";
                        string membershipAmount = "";
                        if (rbtnSilver.Checked == true)
                        {
                            subscriptionType = "SILVER";
                            membershipAmount = lblSilverPrice.Text;
                            obj.TypeOfMembership = 1;
                            obj.OfflineMembership = 3;
                        }
                        else if (rbtnGold.Checked == true)
                        {
                            subscriptionType = "GOLD";
                            membershipAmount = lblGoldPrice.Text;
                            obj.TypeOfMembership = 1;
                            obj.OfflineMembership = 4;
                        }
                        else if (rbtnPlatinum.Checked == true)
                        {
                            subscriptionType = "PLATINUM";
                            membershipAmount = lblPlatinumPrice.Text;
                            obj.TypeOfMembership = 1;
                            obj.OfflineMembership = 5;
                        }
                        Session["SubscriptionDet"] = merchantOrderId + "|" + subscriptionType + "|" + membershipAmount;
                        UpdateOfflineUserMembershipDetails(obj);
                        OfflineSendMail();

                    }
                }

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }
        }


    }
}