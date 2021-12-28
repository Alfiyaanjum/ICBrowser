using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using ICBrowser.Common;
using System.Web.Security;
using ICBrowser.Business;

namespace ICBrowser.Web
{
    public partial class transactionPage : BasePage
    {
        string MerchantOrderId = "";
        string Amount = "";
        string subscriptionType = "";
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack && Session["SubscriptionDet"] != null)
                {
                    string[] data = Session["SubscriptionDet"].ToString().Split('|');
                    MerchantOrderId = data[0];
                    subscriptionType = data[1];
                    Amount = data[2];
                }

                //int sellerID;
                //bool flag = int.TryParse(Session["SellerID"].ToString(), out sellerID);


                UserRequirements userReq = new UserRequirements();

                UserDetails userDetails = userReq.getUserDetails(Membership.GetUser().ProviderUserKey.ToString());
                lblSellerName.Text = userDetails.ContactName;
                lblSubscription.Text = subscriptionType;

                requestparameter.Value = Web.Properties.Settings.Default.MerchantID + "|DOM|IND|INR|" + Amount + "|" + MerchantOrderId + "|" + subscriptionType + "|" + Request.UrlReferrer.ToString().Substring(0, Request.UrlReferrer.ToString().LastIndexOf('/')) + "/" + Web.Properties.Settings.Default.HandleTransactionResponse + "| " + Request.UrlReferrer.ToString().Substring(0, Request.UrlReferrer.ToString().LastIndexOf('/')) + "/" + Web.Properties.Settings.Default.HandleTransactionResponse + "|TOML";

                if (Membership.GetUser() != null)
                {
                    hyp_log.Visible = false;
                    profile.Visible = true;
                    Business.UserRequirements usersdata = new Business.UserRequirements();
                    int useridcount = usersdata.GetUserCountByUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()));
                    if (useridcount > 0)
                    {
                        myprofile.HRef = "BuyersRequirment.aspx";
                    }
                    else
                    {
                        myprofile.HRef = "UploadInventory.aspx";
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (rblSearchType.SelectedValue == "0")
                {
                    //if (!Request.Url.AbsoluteUri.Contains("searchresults.aspx"))
                    Response.Redirect("searchresults.aspx" + "?searchText=" + txtSearchString.Text + "&" + "searchType=" + rblSearchType.SelectedValue);
                    //rblSearchType.SelectedIndex = 0;
                }
                else if (rblSearchType.SelectedValue == "1")
                {
                    Response.Redirect("RequirementSearchResult.aspx" + "?searchText=" + txtSearchString.Text + "&" + "searchType=" + rblSearchType.SelectedValue);
                    //rblSearchType.SelectedIndex = 1;
                }
                //SearchClicked(txtSearchString.Text, true);

                if (rblSearchType.SelectedIndex == 0)
                    Response.Redirect("SearchResults.aspx?searchText=" + txtSearchString.Text);
                else if (rblSearchType.SelectedIndex == 1)
                    Response.Redirect("RequirementSearchResult.aspx?searchText=" + txtSearchString.Text);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the btnNew control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                MembershipUser userToLogin = Membership.GetUser(HiddenUsername.Value);
                bool validateuser = Membership.ValidateUser(HiddenUsername.Value, HiddenPassword.Value);

                if (validateuser == true)
                {
                    MembershipUser CurrentUser = Membership.GetUser(HiddenUsername.Value);
                    FormsAuthentication.SetAuthCookie(HiddenUsername.Value, false);
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    if (userToLogin != null && userToLogin.IsApproved == false)
                    {
                        //lblError.Visible = true;
                        //lblError.Text = Web.Properties.Settings.Default.ActivationMessage;
                    }
                    else
                    {
                        HiddenValidUser.Value = "false";

                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the rdlLanguagePreference control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void rdlLanguagePreference_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                Response.Redirect(Request.Path);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }



    }
}