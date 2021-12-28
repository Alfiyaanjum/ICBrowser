using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Common;
using ICBrowser.Business;
using System.Web.Security;
using System.Threading;
using System.Globalization;
using System.Data;
using ICBrowser.DAL;
using System.DirectoryServices;
using System.Security.Principal;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.IO;



namespace ICBrowser.Web
{
    public delegate void Search(string searchText, bool searchRequirement);
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        //public int SessionTimeOutWithin
        //{
        //    get { return Session.Timeout; }
        //}

        //public string PageToSentAfterSessionTimeOut
        //{
        //    get { return "SessionTimeOutPage.htm"; }
        //}

        public Controller PageController = new Controller();
        public event Search SearchClicked;
        InventoryGridDetails sellersObj = new InventoryGridDetails();
        Common.UserProfile objuserpro = null;

        public Common.UserProfile LoggedInUserDetails
        {
            get { return objuserpro; }
            set
            {
                objuserpro = value;
            }
        }

        UserProfileDetails profiledetais = new UserProfileDetails();

        public Guid currUserId;
        int memTypeId = 0;


        /// <summary>
        /// Handles the Init event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Init(object sender, EventArgs e)
        {
            object obj = Session["UserProfile"];
            MembershipUser userToLogin = Membership.GetUser();

            if (obj != null)
            {
                LoggedInUserDetails = obj as Common.UserProfile;
            }
            else
            {
                if (userToLogin != null)
                {
                    Guid userid = (Guid)userToLogin.ProviderUserKey;
                    UserProfileDetails Upd = new UserProfileDetails();
                    LoggedInUserDetails = Upd.GetUserProfileDetails(userid);
                    Session["UserProfile"] = LoggedInUserDetails;
                }
            }

            /////log user out when user remains ideal for session timeout period. 
            if (userToLogin != null)
            {
                if (Context.Session != null)
                {
                    if (Session.IsNewSession)
                    {
                        HttpCookie newSessionIdCookie = Request.Cookies["ASP.NET_SessionId"];
                        if (newSessionIdCookie != null)
                        {
                            string newSessionIdCookieValue = newSessionIdCookie.Value;

                            if (newSessionIdCookieValue != string.Empty)
                            {
                                System.Web.Security.FormsAuthentication.SignOut();
                                // This means Session was timed Out and New Session was started
                                Response.Redirect("SessionTimeOutPage.htm");
                            }
                        }
                    }
                }

            }

        }

        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);
        //    this.HeadContent.Controls.Add(new LiteralControl(
        //        String.Format("<meta http-equiv='refresh' content='{0};url={1}'>",
        //        SessionTimeOutWithin * 60, PageToSentAfterSessionTimeOut)));
        //}

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearchString.Attributes.Add("OnKeyUp", "isEmpty()");
            txtSearchString.Attributes.Add("OnKeyDown", "isEmpty()");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (!Page.IsPostBack)
            {
                HttpCookie cookie = Request.Cookies[Constants.CultureInfoCookieName];

                if (cookie != null && cookie.Value != null)
                {
                    rdlLanguagePreference.SelectedValue = cookie.Value;

                }
                else if (CultureInfo.CurrentUICulture.Name == "zh-CN")
                {
                    rdlLanguagePreference.SelectedValue = "zh-CN";
                }

                //rblSearchType.SelectedValue = Request.QueryString["searchType"];
                //Response.Cache.SetExpires(DateTime.Now.AddMonths(1));
                //Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
                //Response.Cache.SetValidUntilExpires(true);
                HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(false);
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.Cache.SetNoStore();
                Response.Cache.SetExpires(DateTime.Now.AddMonths(1));
                Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
                Response.Cache.SetValidUntilExpires(true);

            }



            MembershipUser userToLogin = Membership.GetUser();
            if (userToLogin != null)
            {
                lblsignup.Visible = false;
                lbtnCreateUser.Visible = false;
                lblslash.Visible = false;
                liescrow.Visible = true;
                liwhyus.Visible = false;
                currUserId = (Guid)userToLogin.ProviderUserKey;
                liAbtUs.Visible = false;
                liContUs.Visible = false;
                hyp_log.Visible = false;
                profile.Visible = true;
                limymailbox.Visible = true;
                lnkMyMailBox.Visible = true;
                //TopPanel1.Visible = false;


                int memTypeId = LoggedInUserDetails.TypeOfMembership;
                //sslcertify.Visible = true;
                if (memTypeId > 1)
                {
                    //sslcertify.Visible = true;
                    liSellersfunction.Visible = true;
                    anchSellFun.Visible = true;
                    liBuyFun.Visible = true;
                    anchBuyFun.Visible = true;

                    if (memTypeId == 2)
                    {
                        lnkBulkFun.Visible = false;
                        //lnkFavourites.Visible = false;
                    }
                    else
                    {
                        //lnkFavourites.Visible = true;
                    }
                }
                else
                {
                    liBuyFun.Visible = true;
                    limymailbox.Visible = true;
                    lnkMyMailBox.Visible = true;
                    anchBuyFun.Visible = true;
                    lnkMatch.Visible = false;
                    //lnkOffers.Visible = false;
                    //lnkDetailedInventoryListing.Visible = false;
                    //lnkSearchOffers.Visible = false;

                }


                //chk for Admin.......
                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
                if (Admin.IsAdmin == true)
                {
                    usercounts.Visible = true;//For hit counter visibility..
                    liAdmin.Visible = true;
                    profile.Visible = false;
                    anchBuyFun.Visible = false;
                    liBuyFun.Visible = false;
                    lnkBuyfun.Visible = false;
                    limymailbox.Visible = false;
                }

                // Unread Email Count Code
                ICBrowser.Business.EmailNotifications emailNotify = new ICBrowser.Business.EmailNotifications();
                int unreadMailCounts = emailNotify.getNewEmailNotificationForUser(currUserId);
                if (unreadMailCounts > 0)
                {
                    unreadMailCount.Visible = true;
                }
                else
                {
                    unreadMailCount.Visible = false;
                }
            }

        }



        /// <summary>
        /// Handles the Click event of the btnNew control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            liAdmin.Visible = false;
            MembershipUser userToLogin = Membership.GetUser(HiddenUsername.Value);
            bool validateuser = Membership.ValidateUser(HiddenUsername.Value, HiddenPassword.Value);
            Guid userid = (Guid)userToLogin.ProviderUserKey;
            Controller controlIsValidUser = new Controller();
            bool ValidUser = controlIsValidUser.GetIsValidUser(userid);

            if (validateuser == true && ValidUser == true)
            {
                try
                {
                    if (userToLogin != null)
                    {

                        if (userToLogin.IsOnline)
                        {
                            DataSet multipleSignInData = Application[NewConstant.UsersLoggedInFromDifferentNodes] as DataSet;
                            Utility.ProcessLogin(HiddenUsername.Value.Trim(), Session.SessionID, multipleSignInData);
                            Application[NewConstant.UsersLoggedInFromDifferentNodes] = multipleSignInData;
                        }

                        //Guid userid = (Guid)userToLogin.ProviderUserKey;
                        UserProfileDetails Upd = new UserProfileDetails();
                        Common.UserProfile UsrPrfl = new Common.UserProfile();
                        UsrPrfl = Upd.GetUserProfileDetails(userid);
                        Session["UserProfile"] = UsrPrfl;
                        LoggedInUserDetails = (Common.UserProfile)Session["UserProfile"];
                        memTypeId = LoggedInUserDetails.TypeOfMembership;

                        if (memTypeId > 1)
                        {
                            int MembershipStatus = sellersObj.GetMembershipExpireddate(userid);
                            if (MembershipStatus == 0)
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "javascript:validateMembershipExpiry();", true);
                            }
                            else
                            {
                                HiddenValidUser.Value = "true";
                                MembershipUser CurrentUser = Membership.GetUser(HiddenUsername.Value);
                                FormsAuthentication.SetAuthCookie(HiddenUsername.Value, false);
                                Response.Redirect(Request.RawUrl, false);
                            }
                        }
                        else
                        {

                            HiddenValidUser.Value = "true";
                            MembershipUser CurrentUser = Membership.GetUser(HiddenUsername.Value);
                            FormsAuthentication.SetAuthCookie(HiddenUsername.Value, false);
                            Response.Clear();
                            Response.Redirect(Request.RawUrl, false);
                        }
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", true);
                    }

                }
                catch (Exception ex)
                {
                    IClogger.LogMessage(ex.Message);
                }

            }
            else
            {
                if (userToLogin != null && userToLogin.IsApproved == false)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "javascript:NotApprove();", true);
                }
                else
                {
                    if ((HiddenUsername.Value != "") && (HiddenPassword.Value != ""))
                    {
                        HiddenValidUser.Value = "false";
                    }

                }
            }

        }

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtSearchString.Text.Trim()))
            //{
            //    Session["SearchValue"] = txtSearchString.Text.Trim();
            //    Response.Redirect("SearchResults.aspx");
            //}
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the rdlLanguagePreference control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void rdlLanguagePreference_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Sets the cookie that is to be used by Global.asax
            HttpCookie cookie = new HttpCookie(Constants.CultureInfoCookieName);
            cookie.Value = rdlLanguagePreference.SelectedValue;
            Response.Cookies.Add(cookie);

            //Set the culture and reload the page for immediate effect. 
            //Future effects are handled by Global.asax
            Thread.CurrentThread.CurrentCulture =
                          new CultureInfo(rdlLanguagePreference.SelectedValue);
            Thread.CurrentThread.CurrentUICulture =
                          new CultureInfo(rdlLanguagePreference.SelectedValue);
            Response.Redirect(Request.Url.PathAndQuery);
        }

        /// <summary>
        /// Handles the Click event of the lnkViewProfile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkViewProfile_Click(object sender, EventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid userid = (Guid)userToLogin.ProviderUserKey;
            if (Membership.GetUser() != null)
            {
                //objuserpro = profiledetais.GetUserProfileDetails(userid);
                //hyp_log.Visible = false;
                //profile.Visible = true;
                //int memTypeId = objuserpro.TypeOfMembership;
                //UserRequirements UserReq = new UserRequirements();
                //int useridcount = UserReq.GetUserCountByUserId(userid);

                //if (memTypeId == 1)
                //{
                //    Response.Redirect("ViewBuyersProfile.aspx");
                //}
                //else
                //{
                Response.Redirect("ViewSellersProfile.aspx");

            }
        }

        /// <summary>
        /// Handles the Click event of the lnkMemberslist control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkMemberslist_Click(object sender, EventArgs e)
        {
            if (Membership.GetUser() != null)
            {
                //hyp_log.Visible = false;
                //profile.Visible = true;

                //MembershipUser userToLogin = Membership.GetUser();
                //Guid userid = (Guid)userToLogin.ProviderUserKey;
                //objuserpro = profiledetais.GetUserProfileDetails(userid);
                //int memTypeId = objuserpro.TypeOfMembership;
                ////UserRequirements ur = new UserRequirements();
                ////int FreeUserCount = ur.GetUserCountByUserId(UserId);

                //if (memTypeId == 1)
                //{
                //    Response.Redirect("ViewBuyersProfile.aspx");
                //}
                //else
                //{
                Response.Redirect("AdminUsrDetails.aspx");

            }
        }

        /// <summary>
        /// Handles the Click event of the lnkMyMailBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkMyMailBox_Click(object sender, EventArgs e)
        {
            if (Membership.GetUser() != null)
            {
                Response.Redirect("EmailSentReceiveDetails.aspx");
            }
        }

        /// <summary>
        /// Handles the Click event of the lnkReferenceList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkReferenceList_Click(object sender, EventArgs e)
        {
            if (Membership.GetUser() != null)
            {
                Response.Redirect("ReferenceList.aspx");
            }
        }

        /// <summary>
        /// Handles the Click event of the lnkFavourites control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkFavourites_Click(object sender, EventArgs e)
        {
            if (Membership.GetUser() != null)
            {
                Response.Redirect("Favourites.aspx");
            }
        }

        /// <summary>
        /// Handles the Click event of the lnkChangePassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            if (Membership.GetUser() != null)
            {
                Response.Redirect("ChangePassword.aspx");
            }
        }

        /// <summary>
        /// Handles the LoggedOut event of the HeadLoginStatus control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void HeadLoginStatus_LoggedOut(object sender, EventArgs e)
        {
            Response.AddHeader("Pragma", "no-cache");
            Response.CacheControl = "no-cache";
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Expires = -1;
            Session.Abandon();
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "signout", "DisableHistory()", true);
            //Session.Abandon();
            //System.Web.Security.FormsAuthentication.SignOut();
            //Response.Redirect("~/Default.aspx");
        }

        /// <summary>
        /// Handles the Click event of the lbtnCreateUser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lbtnCreateUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx?isNew=1", true);
        }

        /// <summary>
        /// Handles the Click event of the imgbtnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchString.Text.Trim()))
            {
                Session["SearchValue"] = txtSearchString.Text.Trim();
                Response.Redirect("SearchResults.aspx");
            }
        }

        //protected void lnkSellFun_Click(object sender, EventArgs e)
        //{
        //    MembershipUser userToLogin = Membership.GetUser();
        //    Guid UserId = (Guid)userToLogin.ProviderUserKey;
        //    Response.Redirect("~/UserOffers.aspx?UserID=" + UserId);
        //}



        //protected void lnkUploadData_Click(object sender, EventArgs e)
        //{
        //    if (Membership.GetUser() != null)
        //    {
        //        hyp_log.Visible = false;
        //        profile.Visible = true;
        //        BuyersDataRequirement buyersdata = new BuyersDataRequirement();
        //        int buyersidcount = buyersdata.getCountBuyersRequirementDetailsByUserId(Membership.GetUser().ProviderUserKey.ToString());
        //        if (buyersidcount > 0)
        //        {
        //            Response.Redirect("BuyersRequirment.aspx");
        //        }
        //        else
        //        {
        //            Response.Redirect("UploadInventory.aspx");
        //        }
        //    }
        //}

        //protected void lnkSellFun_Click(object sender, EventArgs e)
        //{

        //}
    }
}
