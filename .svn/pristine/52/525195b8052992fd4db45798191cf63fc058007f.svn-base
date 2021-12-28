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
    public partial class TopPanel : System.Web.UI.UserControl
    {
        List<Common.AdvertPanel> lsttopleft = new List<Common.AdvertPanel>();
        List<Common.AdvertPanel> lsttopright = new List<Common.AdvertPanel>();
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            AdvertisePanel ar = new AdvertisePanel();
            try
            {
                string position = "Top Left";
                lsttopleft = ar.GetAdvertisementDetail(position);
                if (lsttopleft.Count == 0)
                {
                    imgbtnAd1.ImageUrl = "~/Images/topleftheader.png";
                    imgbtnAd1.Enabled = false;
                }
                else
                {
                    imgbtnAd1.ImageUrl = lsttopleft[0].ImageUrl;
                    imgbtnAd1.ToolTip = lsttopleft[0].Text;

                }

                position = "Top Right";
                lsttopright = ar.GetAdvertisementDetail(position);
                if (lsttopright.Count == 0)
                {
                    imgbtnAd2.ImageUrl = "~/Images/toprightheader.png";
                    imgbtnAd2.Enabled = false;
                }
                else
                {
                    imgbtnAd2.ImageUrl = lsttopright[0].ImageUrl;
                    imgbtnAd2.ToolTip = lsttopright[0].Text;

                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

        }


        /// <summary>
        /// Handles the Click1 event of the imgbtnAd1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void imgbtnAd1_Click1(object sender, ImageClickEventArgs e)
        {
            ImageButton btnClicked = sender as ImageButton;
            //int listIndex = Convert.ToInt32(btnClicked.ID.Substring(0));
            string redirectURL = lsttopleft[0].RedirectUrl;
            if (!redirectURL.StartsWith("http://"))
                redirectURL = "http://" + redirectURL;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "RedirectURL", "<script>window.open('" + redirectURL + "');</script>");
        }

        /// <summary>
        /// Handles the Click2 event of the imgbtnAd2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void imgbtnAd2_Click2(object sender, ImageClickEventArgs e)
        {
            ImageButton btnClicked = sender as ImageButton;
            //int listIndex = Convert.ToInt32(btnClicked.ID.Substring(0));
            string redirectURL = lsttopright[0].RedirectUrl;
            if (!redirectURL.StartsWith("http://"))
                redirectURL = "http://" + redirectURL;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "RedirectURL", "<script>window.open('" + redirectURL + "');</script>");
        }


    }
}