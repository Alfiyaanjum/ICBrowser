using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ICBrowser.Common;
using System.Collections;
using System.Net;
using System.Net.Mail;
using ICBrowser.Business;
using System.Data;
using ICBrowser.DAL;
using ICBrowser.Web;

namespace ICBrowser.Web
{
    public partial class BuyerProfile : BasePage
    {
        BuyerRatingBySeller BuyerRating = new BuyerRatingBySeller();
        Ratings rats = new Ratings();

        #region "BindData"
        //public static bool statusforaddtofacorite = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                BuyersDataRequirement buyersdata = new BuyersDataRequirement();
                if (!Page.IsPostBack)
                {
                    Guid buyerid = new Guid(Request.QueryString["UserId"]);
                    Guid userid = new Guid(userToLogin.ProviderUserKey.ToString());

                    // Check For Is Admin True
                    bool IsAdmin = buyersdata.IsAdminCheckForLoggedInUsers(userid);
                    if (IsAdmin == true) // user is admin
                    {
                        lnkRate.Visible = false;
                        imgbtnaddFav.Visible = false;
                        lblAddFavoriteText.Visible = false;
                        //getBuyersAverageRating(buyerid);//gets Average rating of Seller whose Profile is been View by the logged buyer
                        BindData(buyerid); // bind data on basis of buyer id
                    }
                    else // user is not admin. User may be buyer or seller
                    {
                        lblAddFavoriteText.Visible = true;
                        lblCurentRating.Visible = true;
                        lnkRate.Visible = true;
                        imgbtnaddFav.Visible = true;
                        //int buyersidcount = buyersdata.getCountBuyersRequirementDetailsByUserId(userid);
                        //if (buyersidcount > 0) // if buyers login bind default data
                        //{
                        //    Response.Redirect("Default.aspx", false);
                        //    //BindDefualtDataForBuyerLogin();
                        //}
                        //else  // else seller login dan process data
                        //{
                        //    if (userToLogin != null) // check membership is null
                        //    {

                        //List<SellerDetails> sellersubsciptiontype = buyersdata.GetSellerDetails(userToLogin.ProviderUserKey.ToString()); // find seller subscription type
                        //List<BuyerAddressDetails> objBuyerDetails = buyersdata.getBuyerAddressDetailsOnBuyerId(Convert.ToInt32(buyerid));
                        //if (sellersubsciptiontype[0].TypeOfMembership != 1) // seller is not trail user
                        //{
                        // Populate Buyer Address Details and Buyer Details Fields on basis of buyer id
                        //if (Convert.ToInt32(buyerid) > 0)
                        //{
                        //getBuyersAverageRating(Convert.ToInt32(buyerid));//gets Average rating of Seller whose Profile is been View by the logged buyer
                        BindData(buyerid); // bind data on basis of buyer id
                        //}
                        //else // if buyer is null from query string than default data is display
                        //{
                        //BindDefualtData(); // bind default data if buyer id is not passes
                        //}
                        //}
                        //else // seller is trial user
                        //{
                        //    Response.Redirect("Default.aspx", false);
                        //    //BindDefualtData();
                        //}
                        //}
                        //    else
                        //    {
                        //        Response.Redirect("Register.aspx", true);
                        //    }
                        //}
                    }
                }

                // Add to Favorite Condition to check whether user is already added or not
                //ChckForAddedToFavoriteCondtion();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        //protected void getBuyersAverageRating(Guid buyerid)
        //{
        //    int currentAvgRating = BuyerRating.getBuyerAvgRating(buyerid);

        //    ratingBuyer.CurrentRating = currentAvgRating;
        //}

        //private void ChckForAddedToFavoriteCondtion()
        //{
        //    MembershipUser userToLogin = Membership.GetUser();
        //    BuyersDataRequirement bdr = new BuyersDataRequirement();
        //    bool statusforaddtofacorite = false;
        //    try
        //    {
        //        string buyerid = Request.QueryString["Id"];
        //        List<SellerDetails> sellersubsciptiontype = bdr.GetSellerDetails(userToLogin.ProviderUserKey.ToString()); // find seller subscription type
        //        List<BuyerAddressDetails> objBuyerDetails = bdr.getBuyerAddressDetailsOnBuyerId(Convert.ToInt32(buyerid)); // find buyer details based on buyer id passed in query string
        //        if (objBuyerDetails.Count > 0)
        //        {
        //            statusforaddtofacorite = bdr.CheckForAlreadyAddedFavoriteList(userToLogin.ProviderUserKey.ToString(), objBuyerDetails[0].userid.ToString());
        //            if (statusforaddtofacorite == true) // user has already added to his favorite list so disable start button
        //            {
        //                imgbtnaddFav.Enabled = false;
        //                imgbtnaddFav.ToolTip = "Already Added to Favorite List";
        //            }
        //            else // user has not added to his favorite list. so enable image button
        //            {
        //                imgbtnaddFav.Enabled = true;
        //                imgbtnaddFav.ToolTip = "Add Favourite";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogError(ex.ToString());
        //    }
        //}

        private void BindDefualtData()
        {
            try
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Upgrade Your Account", "alert('To View Buyers Details Please Upgrade Your Membership.');", true);
                lblCompanyName.Text = "N.A";
                lblOwnerName.Text = "N.A";
                lblContactName.Text = "N.A";
                lblPrimaryAddress.Text = "N.A";
                lblPrimaryCountry.Text = "N.A";
                lblPrimaryState.Text = "N.A";
                lblPrimaryCity.Text = "N.A";
                lblPrimaryZip.Text = "N.A";
                //lblSecondaryAddress.Text = "N.A";
                //lblSecondaryCountry.Text = "N.A";
                //lblSecondaryState.Text = "N.A";
                //lblSecondaryCity.Text = "N.A";
                //lblSecondaryZip.Text = "N.A";
                lblCurrency.Text = "N.A";
                lblExtension.Text = "N.A";
                lblPhoneNumber.Text = "N.A";
                lblFaxNumber.Text = "N.A";
                //lnkEmailAddress.Text = "Send Mail";
                btnEmilAddress.Visible = false;
                lnkWebSite.Text = "N.A";
                //ClientScript.RegisterStartupScript(this.GetType(), "Upgrade Your Account", "alert('To View Buyers Details Please Upgrade Your Membership.');", true);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        //private void BindDefualtDataForBuyerLogin()
        //{
        //    try
        //    {
        //        //ClientScript.RegisterStartupScript(this.GetType(), "Upgrade Your Account", "alert('Please Upgrade your account. You currently Trial Member.');", true);
        //        lblCompanyName.Text = "N.A";
        //        lblOwnerName.Text = "N.A";
        //        lblContactName.Text = "N.A";
        //        lblPrimaryAddress.Text = "N.A";
        //        lblPrimaryCountry.Text = "N.A";
        //        lblPrimaryState.Text = "N.A";
        //        lblPrimaryCity.Text = "N.A";
        //        lblPrimaryZip.Text = "N.A";
        //        //lblSecondaryAddress.Text = "N.A";
        //        //lblSecondaryCountry.Text = "N.A";
        //        //lblSecondaryState.Text = "N.A";
        //        //lblSecondaryCity.Text = "N.A";
        //        //lblSecondaryZip.Text = "N.A";
        //        lblCurrency.Text = "N.A";
        //        lblExtension.Text = "N.A";
        //        lblPhoneNumber.Text = "N.A";
        //        lblFaxNumber.Text = "N.A";
        //        //lnkEmailAddress.Text = "Send Mail";
        //        btnEmilAddress.Visible = false;
        //        lnkWebSite.Text = "N.A";
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogError(ex.ToString());
        //    }
        //}

        private void BindData(Guid buyerid)
        {
            try
            {
                Common.UserProfile objUserProfile = new Common.UserProfile();
                UserProfileDetails objUserProfileDetails = new UserProfileDetails();

                //UserDetails objUserDetails = new UserDetails();
                //BuyersDataRequirement bdr = new BuyersDataRequirement();
                objUserProfile = objUserProfileDetails.GetUserProfileDetails(buyerid);
                if (objUserProfile != null)
                {
                    lblCompanyName.Text = objUserProfile.objUserDetails.CompanyName; // here buyer name is company name
                    lblOwnerName.Text = objUserProfile.objUserDetails.OwnerName;
                    lblSpecialization.Text = objUserProfile.objUserDetails.Specialization;
                    lblContactName.Text = objUserProfile.objUserDetails.ContactName;


                    lblPrimaryAddress.Text = objUserProfile.objAddressDetails.PrimaryAddress;
                    lblPrimaryCountry.Text = objUserProfile.objAddressDetails.PrimaryCountry;
                    lblPrimaryState.Text = objUserProfile.objAddressDetails.PrimaryState;
                    lblPrimaryCity.Text = objUserProfile.objAddressDetails.PrimaryCity;
                    lblPrimaryZip.Text = objUserProfile.objAddressDetails.PrimaryZip;
                    //lblSecondaryAddress.Text = objBuyerDetails[0].secondaryaddress;
                    //lblSecondaryCountry.Text = objBuyerDetails[0].secondarycountry;
                    //lblSecondaryState.Text = objBuyerDetails[0].secondarystate;
                    //lblSecondaryCity.Text = objBuyerDetails[0].secondarycity;
                    //lblSecondaryZip.Text = objBuyerDetails[0].secondaryzip;
                    lblCurrency.Text = objUserProfile.objUserDetails.Currency;
                    lblExtension.Text = objUserProfile.objAddressDetails.Extension;
                    lblPhoneNumber.Text = objUserProfile.objAddressDetails.LandLine;
                    lblFaxNumber.Text = objUserProfile.objAddressDetails.FaxNumber;
                    lnkEmailAddress.Text = objUserProfile.objUserDetails.EmailId;
                    lnkWebSite.Text = objUserProfile.objAddressDetails.Website;
                    lnkWebSite.NavigateUrl = objUserProfile.objAddressDetails.Website;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        #endregion

        #region "Email Sending"
        //protected void lnkEmailAddress_Click(object sender, EventArgs e)
        //{
        //    MembershipUser userToLogin = Membership.GetUser();
        //    BuyersDataRequirement bdr = new BuyersDataRequirement();

        //    //getting buyer details
        //    List<BuyerAddressDetails> objBuyerDetailsBuyerDetails = new List<BuyerAddressDetails>();
        //    string buyerid = Request.QueryString["Id"];
        //    objBuyerDetailsBuyerDetails = bdr.getBuyerAddressDetailsOnBuyerId(Convert.ToInt32(buyerid));
        //    try
        //    {
        //        txtContent.Text = "";
        //        txtSubject.Text = "";
        //        BuyersDataRequirement sellersubsciptiontype = new BuyersDataRequirement();
        //        List<SellerDetails> lst = new List<SellerDetails>();
        //        lst = sellersubsciptiontype.GetSellerDetails(userToLogin.ProviderUserKey.ToString());
        //        if (lst != null && objBuyerDetailsBuyerDetails != null) // seller is not trail user
        //        {
        //            ModalPopupExtenderSendEmail.Show();
        //            lblError.Visible = false;
        //            lblError.Text = "";
        //            txtTo.Text = objBuyerDetailsBuyerDetails[0].contactname;
        //            //txtFrom.Text = userToLogin.Email;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogError(ex.ToString());
        //    }
        //}

        protected void btnEmilAddress_Click(object sender, EventArgs e)
        {
            //MembershipUser userToLogin = Membership.GetUser();
            //BuyersDataRequirement bdr = new BuyersDataRequirement();

            //getting buyer details
            //List<BuyerAddressDetails> objBuyerDetailsBuyerDetails = new List<BuyerAddressDetails>();
            //string buyerid = Request.QueryString["Id"];
            //objBuyerDetailsBuyerDetails = bdr.getBuyerAddressDetailsOnBuyerId(Convert.ToInt32(buyerid));


            Guid buyerUserId = new Guid(Request.QueryString["UserId"]);
            Common.UserProfile objUserProfile = new Common.UserProfile();
            UserProfileDetails objUserProfileDetails = new UserProfileDetails();
            
            try
            {
                txtContent.Text = "";
                txtSubject.Text = "";
                //BuyersDataRequirement sellersubsciptiontype = new BuyersDataRequirement();
                //List<SellerDetails> lst = new List<SellerDetails>();
                //lst = sellersubsciptiontype.GetSellerDetails(userToLogin.ProviderUserKey.ToString());
                objUserProfile = objUserProfileDetails.GetUserProfileDetails(buyerUserId);
                if (objUserProfile != null) // seller is not trail user
                {
                    ModalPopupExtenderSendEmail.Show();
                    lblError.Visible = false;
                    lblError.Text = "";
                    txtTo.Text = objUserProfile.objUserDetails.ContactName;
                    //txtFrom.Text = userToLogin.Email;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        //protected void lnkAddTo_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ModalPopupExtenderAddReceipient.Show();
        //        txtAddTo.Text = "";
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //protected void imgCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ModalPopupExtenderSendEmail.Hide();
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogError(ex.ToString());
        //    }
        //}

        //protected void imgAddPopUp_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        ModalPopupExtenderAddReceipient.Hide();
        //        ModalPopupExtenderSendEmail.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogError(ex.ToString());
        //    }
        //}

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {

            // buyer data
            //List<BuyerAddressDetails> objBuyerDetailsBuyerDetails = new List<BuyerAddressDetails>();
            //BuyersDataRequirement bdr = new BuyersDataRequirement();
            Guid buyerUserId = new Guid(Request.QueryString["UserId"]);
            Common.UserProfile objSelectUserProfile = new Common.UserProfile();
            UserProfileDetails objUserProfileDetails = new UserProfileDetails();
            objSelectUserProfile = objUserProfileDetails.GetUserProfileDetails(buyerUserId);

            Guid objLoggedInUserId = new Guid(Membership.GetUser().ProviderUserKey.ToString());
            Common.UserProfile objLoggedInUser = new Common.UserProfile();
            objLoggedInUser = objUserProfileDetails.GetUserProfileDetails(objLoggedInUserId);
            //objBuyerDetailsBuyerDetails = bdr.getBuyerAddressDetailsOnBuyerId(Convert.ToInt32(buyerid));


            if (objSelectUserProfile != null && objLoggedInUser != null)
            {
                Hashtable hash = new Hashtable
                                     {
                                         {"ToUserName", objSelectUserProfile.objUserDetails.ContactName},
                                         {"FromUserName", objLoggedInUser.objUserDetails.ContactName},
                                         {"Subject", txtSubject.Text},
                                         {"EmailAddress", txtTo.Text},
                                         {"Message", txtContent.Text}
                                     };
                EmailFactory mailFactory = new EmailFactory();
                Email mail = mailFactory.SendEmail(objSelectUserProfile.objUserDetails.EmailId, "icbrowser@gmail.com", txtSubject.Text, txtContent.Text, hash);

                // Save Email
                EmailDetails objSaveEmailDetailsOfUser = new EmailDetails();
                objSaveEmailDetailsOfUser.SaveMessageDetails(objLoggedInUser.objUserDetails.UserID, objSelectUserProfile.objUserDetails.UserID, txtSubject.Text.Trim(), txtContent.Text.Trim(), DateTime.Now, 1, false, false, 0);
                if (mail.Send())
                {
                    ModalPopupExtenderSendEmail.Hide();
                }
                else
                {
                    ModalPopupExtenderSendEmail.Show();
                    lblError.Visible = true;
                    lblError.Text = "Error Occurred in sending mail. Please try again later.";
                }
            }

            // sellers data
            //BuyersDataRequirement objBuyerDetailsSellerDewtails = new BuyersDataRequirement();
            //InventoryGridDetails sellersObj = new InventoryGridDetails();
            //List<EmailDetailsForUser> lstSellerDetails = new List<EmailDetailsForUser>();
            //try
            //{
            //MembershipUser userToLogin = Membership.GetUser();
            //int sellersCount = sellersObj.GetSellersCountByUserId(new Guid(userToLogin.ProviderUserKey.ToString()));
            //if (sellersCount > 0)
            //{
            //lstSellerDetails = objBuyerDetailsSellerDewtails.GetUserNameForEmailDisplayOnUserId(new Guid(userToLogin.ProviderUserKey.ToString()), "SELLER");
            //}
            //else
            //{
            //lstSellerDetails = objBuyerDetailsSellerDewtails.GetUserNameForEmailDisplayOnUserId(new Guid(userToLogin.ProviderUserKey.ToString()), "BUYER");
            //}

            //    if (userToLogin != null && objBuyerDetailsBuyerDetails != null && lstSellerDetails != null)
            //    {
            //        Hashtable hash = new Hashtable
            //                         {
            //                             {"ToUserName", objBuyerDetailsBuyerDetails[0].contactname},
            //                             {"FromUserName", lstSellerDetails[0].FromUserName},
            //                             {"Subject", txtSubject.Text},
            //                             {"EmailAddress", txtTo.Text},
            //                             {"Message", txtContent.Text}
            //                         };
            //        EmailFactory mailFactory = new EmailFactory();
            //        Email mail = mailFactory.SendEmail(lnkEmailAddress.Text, "icbrowser@gmail.com", txtSubject.Text, txtContent.Text, hash);

            //        //lstbuyerDetails = objBuyerDetails.getBuyerDetailsOnBuyerId(Convert.ToInt32(buyerid));
            //        Guid fromuserid = new Guid(userToLogin.ProviderUserKey.ToString());
            //        Guid touserid = new Guid(objBuyerDetailsBuyerDetails[0].userid.ToString());
            //        Boolean isInboxDeleted = false, isSentItemDelete = false;
            //        int parentid = 0;
            //        //Save Message Details in Message Details Table
            //        objBuyerDetailsSellerDewtails.SaveMessageDetails(fromuserid, touserid, txtSubject.Text, txtContent.Text, DateTime.Now, 1, isInboxDeleted, isSentItemDelete, parentid);
            //        if (mail.Send())
            //        {
            //            ModalPopupExtenderSendEmail.Hide();
            //        }
            //        else
            //        {
            //            //objselleremaildetails.CreateSellerEmailDetails(sellerid, Convert.ToInt32(buyerid), txtSubject.Text, txtContent.Text, DateTime.Now, 0);
            //            ModalPopupExtenderSendEmail.Show();
            //            lblError.Visible = true;
            //            lblError.Text = "Error Occurred in sending mail. Please try again later.";
            //        }
            //    }
            //    else
            //    {
            //        lblError.Visible = true;
            //        lblError.Text = "Error Occurred in sending mail. Please try again later.";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    IClogger.LogError(ex.ToString());
            //}

            //}

            //protected void btnAddTo_Click1(object sender, EventArgs e)
            //{
            //    try
            //    {
            //        txtTo.Text = txtTo.Text + ";" + txtAddTo.Text;
            //        ModalPopupExtenderAddReceipient.Hide();
            //        ModalPopupExtenderSendEmail.Show();
            //    }
            //    catch (Exception ex)
            //    {
            //        IClogger.LogError(ex.ToString());
            //    }
            //}
        }
        #endregion

        # region "AddFavourite"
        protected void imgbtnaddFav_Click(object sender, ImageClickEventArgs e)
        {
            //MembershipUser userToLogin = Membership.GetUser();
            //BuyersDataRequirement bdr = new BuyersDataRequirement();
            //try
            //{
            //    if (userToLogin != null) // check membership is null
            //    {
            //        string buyerid = Request.QueryString["Id"];

            //        List<SellerDetails> sellersubsciptiontype = bdr.GetSellerDetails(userToLogin.ProviderUserKey.ToString()); // find seller subscription type
            //        if (sellersubsciptiontype[0].TypeOfMembership != 1) // seller is not trail user
            //        {
            //            // Find Buyer Detials on basis of buyer Id
            //            imgbtnaddFav.Visible = true;
            //            List<BuyerAddressDetails> objBuyerDetails = bdr.getBuyerAddressDetailsOnBuyerId(Convert.ToInt32(buyerid));
            //            bool flag = false;
            //            int status = 0;
            //            if (objBuyerDetails.Count > 0)
            //            {
            //                flag = bdr.AddToFavouriteForSellerToBuyer(userToLogin.ProviderUserKey.ToString(), objBuyerDetails[0].userid.ToString(), DateTime.Now, status);

            //                if (flag == true) // Favorite is added
            //                {
            //                    ClientScript.RegisterStartupScript(this.GetType(), "Add Favorite", "alert('You Have Added Favorite Successfully.');", true);
            //                    imgbtnaddFav.Enabled = false;
            //                    imgbtnaddFav.ToolTip = "Already Added to Favorite List";
            //                }
            //                else // Favorite is already added 
            //                {
            //                    imgbtnaddFav.Enabled = true;
            //                    imgbtnaddFav.ToolTip = "Add Favourite";
            //                    //statusforaddtofacorite = false;
            //                    //ClientScript.RegisterStartupScript(this.GetType(), "Add Favorite", "alert('It Has Already Been Added To Your Favorite List.');", true);
            //                }
            //            }
            //        }
            //        else // seller is trial member
            //        {
            //            imgbtnaddFav.Visible = false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    IClogger.LogError(ex.ToString());
            //}
        }
        #endregion

        protected void lnkRate_Click(object sender, EventArgs e)
        {
            //Response.Redirect("SellersRatingforBuyer.aspx?&BuyerId=" + Convert.ToInt32(Request.QueryString["Id"]));
        }
    }
}