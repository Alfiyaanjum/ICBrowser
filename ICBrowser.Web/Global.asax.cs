using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;
using System.Globalization;

namespace ICBrowser.Web
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup     
            Application["usersLoggedInFromDifferentNodes"] = Utility.GetMultipleSigninsData();
            log4net.Config.XmlConfigurator.Configure();
                       
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            //Code that runs when an unhandled error occurs
            Exception ex = Server.GetLastError();
            Application["Exception"] = ex; //store the error for later
            Server.ClearError(); //clear the error so we can continue onwards
            Response.Redirect("~/ErrorPage.aspx"); //direct user to error page

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    HttpCookie cookie = Request.Cookies[Common.Constants.CultureInfoCookieName];

        //    if (cookie != null && cookie.Value != null)
        //    {
        //        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
        //        Thread.CurrentThread.CurrentCulture = new CultureInfo(cookie.Value);
        //    }
        //    else
        //    {
        //        Thread.CurrentThread.CurrentUICulture = new CultureInfo(Common.Constants.DefaultCultureString);
        //        Thread.CurrentThread.CurrentCulture = new CultureInfo(Common.Constants.DefaultCultureString);
        //    }
        //}

        //protected void Application_AcquireRequestState(object sender,EventArgs e)
        //{

        //    HttpCookie cookie = Request.Cookies[Common.Constants.CultureInfoCookieName];

        //    if (cookie != null && cookie.Value != null)
        //    {
        //        System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(cookie.Value);
        //        Thread.CurrentThread.CurrentUICulture = cultureInfo;
        //        Thread.CurrentThread.CurrentCulture = cultureInfo;
        //    }
        //    else
        //    {
        //        System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(Common.Constants.DefaultCultureString);
        //        Thread.CurrentThread.CurrentUICulture = cultureInfo;
        //        Thread.CurrentThread.CurrentCulture = cultureInfo;
        //    }

        //}



    }
}
