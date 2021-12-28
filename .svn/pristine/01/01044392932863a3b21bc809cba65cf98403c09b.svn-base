using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Web.Security;
using ICBrowser.Common;
using ICBrowser.DAL;
using ICBrowser.Business;
using System.Data;

namespace ICBrowser.Web
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {

            HttpCookie cookie = Request.Cookies[Common.Constants.CultureInfoCookieName];

            if (cookie != null && cookie.Value != null)
            {
                System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(cookie.Value);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = cultureInfo;
            }
            else if (Request.UserLanguages != null)
            {
                if (Request.UserLanguages.Contains("en-IN"))
                {
                    System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(Common.Constants.DefaultCultureString);
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                }
                else if (Request.UserLanguages.Contains("en-US"))
                {
                    System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(Common.Constants.DefaultCultureString);
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                }
                else if (Request.UserLanguages.Contains("en-GB"))
                {
                    System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(Common.Constants.DefaultCultureString);
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                }
                else if (Request.UserLanguages.Contains("zh-CN"))
                {
                    System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("zh-CN");
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                }
                else
                {
                    System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(Common.Constants.DefaultCultureString);
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                }
            }
        }


        protected void Page_Init(object sender, EventArgs e) // Override
        {
           
            var membershipUser = Membership.GetUser();
            if (membershipUser != null && Utility.CheckUserForMultipleLogins(membershipUser.UserName, Session.SessionID, Application[NewConstant.UsersLoggedInFromDifferentNodes] as DataSet)==false)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                Session.Abandon();
            }
          
        }
    }
}