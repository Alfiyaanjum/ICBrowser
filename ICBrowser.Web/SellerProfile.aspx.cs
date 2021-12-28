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
    public partial class SellerProfile : BasePage
    {

        //public int getSellerid = 0;
        SellerRatingByBuyer sellerrating = new SellerRatingByBuyer();
        #region "BindData"

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                Guid sellerIduserid = (Guid)userToLogin.ProviderUserKey;
                Guid UserId = new Guid(Request.QueryString["UserId"]);
                if (userToLogin == null)
                {

                    //string sellerId = Request.QueryString["SellerId"];
                    Response.Redirect("Default.aspx?UserId=" + UserId, false);
                }

                Controller sellerdetailsobj = new Controller();
                BuyersDataRequirement buyersdata = new BuyersDataRequirement();
                if (!Page.IsPostBack)
                {
                    //string sellerid = Request.QueryString["Id"];
                    Guid userid = (Guid)userToLogin.ProviderUserKey;
                    // Check For Is Admin True
                    bool IsAdmin = buyersdata.IsAdminCheckForLoggedInUsers(sellerIduserid);
                    if (IsAdmin == true) // user is admin
                    {
                        lnkRate.Visible = false;
                        imgbtnaddFav.Visible = false;
                        lblAddFavoriteText.Visible = false;
                        getSellersAverageRating((UserId));//gets Average rating of Seller whose Profile is been View by the logged buyer
                        BindData(UserId); // bind data on basis of buyer id
                    }
                    else
                        if (userToLogin != null) // check membership is null
                        {
                            Guid useridLogin = (Guid)userToLogin.ProviderUserKey;
                            //Controller controlIsAdmin = new Controller();//admin object
                            //Users Admin = controlIsAdmin.GetIsAdmin(userid);

                            InventoryGridDetails sellersObj = new InventoryGridDetails();
                            int sellersCount = sellersObj.GetSellersCountByUserId(useridLogin);
                            Guid userId = new Guid(Request.QueryString["UserId"]);
                            Session["UserId"] = userId;

                            if (sellersCount > 0)
                            {
                                btnEmilAddress.Visible = false;
                                imgbtnaddFav.Visible = false;
                                lblAddFavoriteText.Visible = false;
                                trratelink.Visible = false;
                                trCurrntrate.Visible = false;
                                //lnkEmilAddress.Visible = false;
                                BindData(userId);
                            }
                            else
                            {

                                //List<SellerAddressDetails> sellersubsciptiontype = sellerdetailsobj.GetSellerCompanyDetailsByID(Convert.ToInt32(Request.QueryString["SellerId"])); // find seller subscription type
                                //List<BuyerAddressDetails> objBuyerDetails = bdr.getBuyerAddressDetailsOnBuyerId(Convert.ToInt32(buyerid));

                                //if (sellersubsciptiontype[0].typeOfMembership != 1) // seller is not trail user

                                // Populate Buyer Address Details and Buyer Details Fields on basis of buyer id
                                if (Convert.ToInt32(UserId) > 0)
                                {
                                    getSellersAverageRating(UserId);//gets Average rating of Seller whose Profile is been View by the logged buyer

                                    BindData(UserId); // bind data on basis of buyer id
                                    imgbtnaddFav.Visible = true;
                                    lblAddFavoriteText.Visible = true;
                                }
                                else // if buyer is null from query string than default data is display
                                {
                                    BindDefualtData(); // bind default data if buyer id is not passes
                                    trCurrntrate.Visible = false;
                                    trratelink.Visible = false;
                                    //lnkRate.Visible = false;
                                    //lblCurentRating.Visible = false;
                                    imgbtnaddFav.Visible = false;
                                    lblAddFavoriteText.Visible = false;
                                    ratingSeller.Visible = false;
                                }

                                //else // seller is trial user
                                //{
                                //    BindDefualtData();
                                //    trratelink.Visible = false;
                                //    trCurrntrate.Visible = false;
                                //    //lblCurentRating.Visible = false;
                                //    //lnkRate.Visible = false;
                                //    imgbtnaddFav.Visible = false;
                                //    lblAddFavoriteText.Visible = false;
                                //    ratingSeller.Visible = false;
                                //}
                            }
                        }
                        else
                        {
                            trCurrntrate.Visible = false;
                            trratelink.Visible = false;
                            //lnkRate.Visible = false;
                            //ratingSeller.Visible = false;
                        }

                }
                //else
                //{
                //    Response.Redirect("Register.aspx", true);
                //}
                ChckForAddedToFavoriteCondtion();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        public void getSellersAverageRating(Guid UserId)
        {
            try
            {
                int currentAvgRating = sellerrating.getSellerAvgRating(UserId);
                ratingSeller.CurrentRating = currentAvgRating;
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }


        //private void ChckForAddedToFavoriteCondtion()
        //{

        //    //Guid userid = (Guid)userToLogin.ProviderUserKey;

        //    bool flag = false;
        //    BuyersDataRequirement buyersdata = new BuyersDataRequirement(); // Buyer Object
        //    Controller SellerDetailsObj = new Controller(); // Seller Object

        //    try
        //    {
        //        MembershipUser userToLogin = Membership.GetUser();
        //        Guid userId = new Guid(userToLogin.ProviderUserKey.ToString());
        //        int buyersidcount = buyersdata.getCountBuyersRequirementDetailsByUserId(userToLogin.ProviderUserKey.ToString());
        //        string UserId = Request.QueryString["UserId"];
        //        List<BuyerAddressDetails> lstBuyerDetails = buyersdata.GetBuyerDetailsbyuserid(userId);
        //        List<SellerAddressDetails> lstSellerDetails = SellerDetailsObj.GetSellerCompanyDetailsByID(Convert.ToInt32(Request.QueryString["UserId"]));
        //        if (buyersidcount > 0) // User is Buyer
        //        {
        //            imgbtnaddFav.Visible = true;
        //            if (lstSellerDetails[0].typeOfMembership != 1 && lstBuyerDetails.Count > 0 && lstSellerDetails.Count > 0) // seller is not trail user
        //            {
        //                flag = SellerDetailsObj.CheckForAddedFavListForUser(lstBuyerDetails[0].userid.ToString(), lstSellerDetails[0].userid.ToString());
        //                if (flag == true)
        //                {
        //                    imgbtnaddFav.Enabled = false;
        //                    imgbtnaddFav.ToolTip = "Already Added to Favorite List";
        //                }
        //                else
        //                {
        //                    imgbtnaddFav.Enabled = true;
        //                    imgbtnaddFav.ToolTip = "Add Favourite";
        //                }
        //            }
        //            else // if user selects trial seller users
        //            {
        //                imgbtnaddFav.Visible = false;
        //            }
        //        }
        //        else // user is seller
        //        {
        //            imgAddPopUp.Visible = false;
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
                //ClientScript.RegisterStartupScript(this.GetType(), "Upgrade Your Account", "alert('Please Upgrade your account. You currently Trial Member.');", true);
                //List<SellerAddressDetails> objSellerDetails = new List<SellerAddressDetails>();
                UserProfile userProfile = new UserProfile();
                Controller bdr = new Controller();
                UserProfileDetails UserDetails = new UserProfileDetails();
                userProfile = UserDetails.GetUserProfileDetails(new Guid(Request.QueryString["UserId"]));
                if (userProfile != null)
                {
                    lblCompanyName.Text = "Not to disclose";
                    lblOwnerName.Text = "Not to disclose";
                    lblContactName.Text = "Not to disclose";
                    //lblContactName.Visible = false;
                    lblPrimaryAddress.Text = "Not to disclose";
                    lblPrimaryCountry.Text = "Not to disclose";
                    lblPrimaryState.Text = "Not to disclose";
                    lblPrimaryCity.Text = "Not to disclose";
                    lblPrimaryZip.Text = "Not to disclose";
                    lblCurrency.Text = "Not to disclose";
                    lblExtension.Text = "Not to disclose";
                    lblPhoneNumber.Text = "Not to disclose";
                    lblFaxNumber.Text = "Not to disclose";
                    lnkEmilAddress.Text = userProfile.email;
                    lnkEmilAddress.Visible = false;
                    lnkWebSite.Text = "Not to disclose";
                    lblSpecialization.Text = "Not to disclose";
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        private void BindData(Guid UserId)
        {
            try
            {
                //List<SellerAddressDetails> objSellerDetails = new List<SellerAddressDetails>();
                //Controller bdr = new Controller();
                //objSellerDetails = bdr.GetSellerCompanyDetailsByID(Convert.ToInt32(Request.QueryString["UserId"]));
                //if (objSellerDetails != null)
                UserProfile userProfile = new UserProfile();
                Controller bdr = new Controller();
                UserProfileDetails UserDetails = new UserProfileDetails();
                userProfile = UserDetails.GetUserProfileDetails(new Guid(Request.QueryString["UserId"]));
                if (userProfile != null)
                {
                    lblCompanyName.Text = userProfile.objUserDetails.CompanyName; // here Seller name is company name
                    //lblOwnerName.Text = userProfile.objAddressDetails.;
                    lblContactName.Text = userProfile.objUserDetails.ContactName;
                    lblPrimaryAddress.Text = userProfile.objAddressDetails.PrimaryAddress;
                    lblPrimaryCountry.Text = userProfile.objAddressDetails.PrimaryCountry;
                    lblPrimaryState.Text = userProfile.objAddressDetails.PrimaryState;
                    lblPrimaryCity.Text = userProfile.objAddressDetails.PrimaryCity;
                    lblPrimaryZip.Text = userProfile.objAddressDetails.PrimaryZip;
                    lblCurrency.Text = userProfile.objUserDetails.Currency;
                    lblExtension.Text = userProfile.objAddressDetails.Extension;
                    lblPhoneNumber.Text = userProfile.objAddressDetails.LandLine;
                    lblFaxNumber.Text = userProfile.objAddressDetails.FaxNumber;
                    lnkEmilAddress.Text = userProfile.email;
                    lnkWebSite.Text = userProfile.objAddressDetails.Website;
                    lnkWebSite.NavigateUrl = userProfile.objAddressDetails.Website;
                    lblSpecialization.Text = userProfile.m_objUserDetails.Specialization;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        #endregion

        #region "Email Sending"
        protected void btnEmailAddress(object sender, EventArgs e)
        {

            Controller bdr = new Controller();
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                txtContent.Text = "";
                txtSubject.Text = "";
                // Controller cts = new Controller();
                //  string BuyerId = Request.QueryString["BuyerId"];
                //List<BuyerDetails> lst = new List<BuyerDetails>();
                // lst = cts.GetBuyerDetailsBySellerID(Convert.ToInt32(BuyerId));
                // if (lst != null) // seller is not trail user
                {
                    ModalPopupExtenderSendEmail.Show();
                    lblError.Visible = false;
                    lblError.Text = "";
                    txtTo.Text = lblContactName.Text;
                    //txtFrom.Text = userToLogin.Email;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

        }
        //protected void lnkEmailAddress_Click(object sender, EventArgs e)
        //{
        //    MembershipUser userToLogin = Membership.GetUser();
        //    Controller bdr = new Controller();
        //    try
        //    {
        //        txtContent.Text = "";
        //        txtSubject.Text = "";
        //        // Controller cts = new Controller();
        //        //  string BuyerId = Request.QueryString["BuyerId"];
        //        //List<BuyerDetails> lst = new List<BuyerDetails>();
        //        // lst = cts.GetBuyerDetailsBySellerID(Convert.ToInt32(BuyerId));
        //        // if (lst != null) // seller is not trail user
        //        {
        //            ModalPopupExtenderSendEmail.Show();
        //            lblError.Visible = false;
        //            lblError.Text = "";
        //            txtTo.Text = lnkEmailAddress.Text;
        //            txtFrom.Text = userToLogin.Email;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogError(ex.ToString());
        //    }
        //}

        protected void lnkAddTo_Click(object sender, EventArgs e)
        {
            try
            {
                ModalPopupExtenderAddReceipient.Show();
                txtAddTo.Text = "";
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void imgCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ModalPopupExtenderSendEmail.Hide();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void imgAddPopUp_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ModalPopupExtenderAddReceipient.Hide();
                ModalPopupExtenderSendEmail.Show();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            try
            {
                ////List<SellerAddressDetails> objSellerDetails = new List<SellerAddressDetails>();
                ////Controller bdr = new Controller();
                ////objSellerDetails = bdr.GetSellerCompanyDetailsByID(Convert.ToInt32(Request.QueryString["UserId"]));
                //UserProfile userProfile = new UserProfile();
                //Controller bdr = new Controller();
                //UserProfileDetails UserDetails = new UserProfileDetails();
                //userProfile = UserDetails.GetUserProfileDetails(new Guid(Request.QueryString["UserId"]));
                //MembershipUser userToLogin = Membership.GetUser();
                //string userid = userToLogin.ProviderUserKey.ToString();
                
                //BuyersDataRequirement objBuyerDetailsSellerDewtails = new BuyersDataRequirement();
                //BuyersDataRequirement bcr = new BuyersDataRequirement();
                ////List<BuyerAddressDetails> objBuyerDetailsBuyerDetails = new List<BuyerAddressDetails>();
                //List<BuyerAddressDetails> lst = bcr.GetBuyerDetailsbyuserid(new Guid(userid));
                ////Controller controlIsAdmin = new Controller();
                ////Users Admin = controlIsAdmin.GetIsAdmin(new Guid(userid));

                //if (userToLogin != null)
                //{
                //    List<SellerAddressDetails> sellersubsciptiontype = bdr.GetSellerCompanyDetailsByID(Convert.ToInt32(Request.QueryString["UserId"]));

                //    //if (Admin.IsAdmin == true)
                //    //{
                //    //    string admname = Admin.UserName;
                //    //}



                //    Hashtable hash = new Hashtable
                //                     {
                //                         {"ToUserName", userProfile.m_objUserDetails.ContactName},
                //                         {"FromUserName",userProfile.m_objUserDetails.ContactName},
                //                         {"Subject", txtSubject.Text},
                //                         {"EmailAddress", txtTo.Text},
                //                         {"Message", txtContent.Text}
                //                     };
                //    EmailFactory mailFactory = new EmailFactory();
                //    Guid UserId = new Guid(userToLogin.ProviderUserKey.ToString());
                //    Guid userId = new Guid(objSellerDetails[0].userid.ToString());
                //    Boolean isInboxDeleted = false, isSentItemDelete = false;
                //    int parentid = 0;
                //    objBuyerDetailsSellerDewtails.SaveMessageDetails(UserId, userId, txtSubject.Text, txtContent.Text, DateTime.Now, 1, isInboxDeleted, isSentItemDelete, parentid);

                //    //if (sellersubsciptiontype[0].typeOfMembership != 1)
                //    {
                //        Email mail = mailFactory.SendEmail(lnkEmilAddress.Text, "icbrowser@gmail.com", txtSubject.Text, txtContent.Text, hash);
                //        if (mail.Send())
                //        {
                //            ModalPopupExtenderSendEmail.Hide();
                //        }
                //        else
                //        {

                //            ModalPopupExtenderSendEmail.Show();
                //            lblError.Visible = true;
                //            lblError.Text = "Error Occurred in sending mail. Please try again later.";
                //        }
                //    }
                //    //else
                //    //{
                //    //    Email mail = mailFactory.SentDefaultTemplateToSeller(lnkEmilAddress.Text, "icbrowser@gmail.com", txtSubject.Text, txtContent.Text, hash);
                //    //    if (mail.Send())
                //    //    {
                //    //        ModalPopupExtenderSendEmail.Hide();
                //    //    }
                //    //    else
                //    //    {

                //    //        ModalPopupExtenderSendEmail.Show();
                //    //        lblError.Visible = true;
                //    //        lblError.Text = "Error Occurred in sending mail. Please try again later.";
                //    //    }
                //    //}



                //}


                Guid UserId = new Guid(Request.QueryString["UserId"]);
                Common.UserProfile objSelectUserProfile = new Common.UserProfile();
                UserProfileDetails objUserProfileDetails = new UserProfileDetails();
                objSelectUserProfile = objUserProfileDetails.GetUserProfileDetails(UserId);

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

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

        }

        protected void btnAddTo_Click1(object sender, EventArgs e)
        {
            try
            {
                txtTo.Text = txtTo.Text + ";" + txtAddTo.Text;
                ModalPopupExtenderAddReceipient.Hide();
                ModalPopupExtenderSendEmail.Show();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        #endregion

        # region "AddFavorite"
        protected void imgbtnaddFav_Click(object sender, ImageClickEventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            BuyersDataRequirement buyersdata = new BuyersDataRequirement(); // Buyer Object
            Controller SellerDetailsObj = new Controller(); // Seller Object
            bool flag = false;
            int status = 0;
            try
            {
                if (userToLogin != null) // check membership is null
                {
                    Guid BuyerUserid = new Guid(userToLogin.ProviderUserKey.ToString());
                    int buyersidcount = buyersdata.getCountBuyersRequirementDetailsByUserId(userToLogin.ProviderUserKey.ToString());
                    string SellerId = Request.QueryString["SellerId"];
                    List<BuyerAddressDetails> lstBuyerDetails = buyersdata.GetBuyerDetailsbyuserid(BuyerUserid);
                    List<SellerAddressDetails> lstSellerDetails = SellerDetailsObj.GetSellerCompanyDetailsByID(Convert.ToInt32(Request.QueryString["SellerId"]));
                    if (buyersidcount > 0) // User is Buyer
                    {
                        if (lstSellerDetails[0].typeOfMembership != 1 && lstBuyerDetails.Count > 0 && lstSellerDetails.Count > 0) // seller is not trail user
                        {
                            imgbtnaddFav.Visible = true;
                            // Insert Values
                            flag = SellerDetailsObj.AddFavoriteSellerToBuyer(lstBuyerDetails[0].userid.ToString(), lstSellerDetails[0].userid.ToString(), DateTime.Now, status);

                            if (flag == true) // Favorite is added
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "Add Favorite", "alert('You Have Added Favorite Successfully.');", true);
                                imgbtnaddFav.Enabled = false;
                                imgbtnaddFav.ToolTip = "Already Added to Favorite List";
                            }
                            else // Favorite is already added 
                            {
                                //imgbtnaddFav.Enabled = false;
                                //imgbtnaddFav.ToolTip = "Already Added to Favorite List";
                                //ClientScript.RegisterStartupScript(this.GetType(), "Add Favorite", "alert('It Has Already Been Added To Your Favorite List.');", true);
                            }
                        }
                        else // if buyer selects trial seller than don`t allow to add seller as his favorite
                        {
                            imgbtnaddFav.Visible = false;
                        }
                    }
                    else // User is Seller
                    {
                        // Hide Image Button so he could not added seller as seller favorite
                        imgbtnaddFav.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        #endregion

        protected void lnkRate_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BuyersRatingforSeller.aspx?&SellerId=" + Session["getSellerid"].ToString());
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }
    }
}