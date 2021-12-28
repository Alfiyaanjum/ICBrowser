using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ICBrowser.Business;
using ICBrowser.Common;

namespace ICBrowser.Web
{
    public partial class BottomPanel : System.Web.UI.UserControl
    {
        List<Common.AdvertPanel> lstbottomLeft = new List<Common.AdvertPanel>();
        List<Common.AdvertPanel> lstbottomRight = new List<Common.AdvertPanel>();
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                AdvertisePanel ar = new AdvertisePanel();
                string position = "Bottom Left";
                lstbottomLeft = ar.GetAdvertisementDetail(position);
                if (lstbottomLeft.Count == 0)
                {
                    imgbtnAd7.ImageUrl = "~/Images/bottomleftfooter.png";
                    imgbtnAd7.Enabled = false;
                }
                else
                {
                    imgbtnAd7.ImageUrl = lstbottomLeft[0].ImageUrl;
                    imgbtnAd7.ToolTip = lstbottomLeft[0].Text;
                }

                position = "Bottom Right";
                lstbottomRight = ar.GetAdvertisementDetail(position);
                if (lstbottomRight.Count == 0)
                {
                    imgbtnAd8.ImageUrl = "~/Images/bottomrightfooter.png";
                    imgbtnAd8.Enabled = false;
                }
                else
                {
                    imgbtnAd8.ImageUrl = lstbottomRight[0].ImageUrl;
                    imgbtnAd8.ToolTip = lstbottomRight[0].Text;
                }
            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

        }
        /// <summary>
        /// Handles the Click7 event of the imgbtnAd7 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void imgbtnAd7_Click7(object sender, ImageClickEventArgs e)
        {
            ImageButton btnClicked = sender as ImageButton;
            //int listIndex = Convert.ToInt32(btnClicked.ID.Substring(0));
            string redirectURL = lstbottomLeft[0].RedirectUrl;
            if (!redirectURL.StartsWith("http://"))
                redirectURL = "http://" + redirectURL;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "RedirectURL", "<script>window.open('" + redirectURL + "');</script>");
        }

        /// <summary>
        /// Handles the Click8 event of the imgbtnAd8 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void imgbtnAd8_Click8(object sender, ImageClickEventArgs e)
        {
            ImageButton btnClicked = sender as ImageButton;
            //int listIndex = Convert.ToInt32(btnClicked.ID.Substring(0));
            string redirectURL = lstbottomRight[0].RedirectUrl;
            if (!redirectURL.StartsWith("http://"))
                redirectURL = "http://" + redirectURL;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "RedirectURL", "<script>window.open('" + redirectURL + "');</script>");
        }
    }
}