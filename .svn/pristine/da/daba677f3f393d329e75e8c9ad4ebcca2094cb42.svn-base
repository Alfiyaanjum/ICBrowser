using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Common;

namespace ICBrowser.Web
{
    public partial class ErrorPage :BasePage
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hide steps on this page
         //   Master.SetDisableStep(true);

            //get exception on each application error
            Exception caughtException = (Exception)Application["Exception"];

            //create an error message to be added to ICBrowser logger
            string errorInfo = "Offending URL: " + Environment.NewLine + Request.Url +
                                Environment.NewLine +
                               "Source: " + Environment.NewLine + caughtException.Source +
                                Environment.NewLine +
                               "Message: " + Environment.NewLine + caughtException.Message +
                                Environment.NewLine +
                               "Stack Trace: " + Environment.NewLine + caughtException.StackTrace;
            if (caughtException.InnerException != null)
            {
                errorInfo = errorInfo +
                                Environment.NewLine +
                               "Inner Message: " + Environment.NewLine + caughtException.InnerException.Message +
                                Environment.NewLine +
                               "Inner Stack Trace: " + Environment.NewLine + caughtException.InnerException.StackTrace;
            }

            //Message to be shown on the page
            lblMessage.Text = "<span style='font-size:medium;'>An error occured</span>" + "<br/><br/><br/>System error occured you will be redirected to the home page in a while...";

            //Log the thrown exception
          
            //IClogger.LogError(Master.PageController.UserData.RequestId+ Environment.NewLine + " An error occured:" + Environment.NewLine + "Details are as follows:" + Environment.NewLine + errorInfo);
        }
    }
}