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
//using ICBrowser.DAL;

namespace ICBrowser.Web
{
    public partial class AdvertPanel: BasePage
    {
        List<Common.AdvertPanel> lsttop = new List<Common.AdvertPanel>();
        List<Common.AdvertPanel> lstbottom = new List<Common.AdvertPanel>();
        List<Common.AdvertPanel> lstright = new List<Common.AdvertPanel>();
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
                string position = "Top";
                lsttop = ar.GetAdvertisementDetail(position);
                if (lsttop.Count == 0)
                {
                    imgbtnAd1.ImageUrl = "Images/ad99.gif";
                    imgbtnAd1.Enabled = false;
                }
                else
                {
                    imgbtnAd1.ImageUrl = lsttop[0].ImageUrl;
                    imgbtnAd1.ToolTip = lsttop[0].Text;

                }

                position = "Right";
                lstright = ar.GetAdvertisementDetail(position);
                int count = lstright.Count;
                switch (count)
                {
                    case 0: List<Common.AdvertPanel> lstdefault = new List<Common.AdvertPanel>();
                        lstdefault.Add(new Common.AdvertPanel()
                        {
                            ImageUrl = "~/Images/ad1.png",
                            Position = position,
                        });
                        lstdefault.Add(new Common.AdvertPanel()
                        {
                            ImageUrl = "~/Images/ad2.gif",
                            Position = position,
                        });
                        lstdefault.Add(new Common.AdvertPanel()
                        {
                            ImageUrl = "~/Images/ad3.gif",
                            Position = position,
                        });
                        rptrAdvertisements.DataSource = lstdefault;
                        rptrAdvertisements.DataBind();
                        break;
                    case 1:
                        lstright.Add(new Common.AdvertPanel()
                        {
                            ImageUrl = "~/Images/ad1.png",
                            Position = position,
                        });
                        lstright.Add(new Common.AdvertPanel()
                        {
                            ImageUrl = "~/Images/ad2.gif",
                            Position = position,
                        });
                        rptrAdvertisements.DataSource = lstright;
                        rptrAdvertisements.DataBind();
                        break;
                    case 2:
                        lstright.Add(new Common.AdvertPanel()
                        {
                            ImageUrl = "~/Images/ad1.png",
                            Position = position,
                        });
                        rptrAdvertisements.DataSource = lstright;
                        rptrAdvertisements.DataBind();
                        break;
                    default:
                        rptrAdvertisements.DataSource = lstright;
                        rptrAdvertisements.DataBind();
                        break;

                }

                position = "Bottom";
                lstbottom = ar.GetAdvertisementDetail(position);
                if (lstbottom.Count == 0)
                {
                    imgbtnAd7.ImageUrl = "Images/ad99.gif";
                    imgbtnAd7.Enabled = false;
                }
                else
                {
                    imgbtnAd7.ImageUrl = lstbottom[0].ImageUrl;
                    imgbtnAd7.ToolTip = lstbottom[0].Text;
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
            string redirectURL = lsttop[0].RedirectUrl;
            if (!redirectURL.StartsWith("http://"))
                redirectURL = "http://" + redirectURL;
            ClientScript.RegisterStartupScript(this.GetType(), "RedirectURL", "<script>window.open('" + redirectURL + "');</script>");
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
            string redirectURL = lstbottom[0].RedirectUrl;
            if (!redirectURL.StartsWith("http://"))
                redirectURL = "http://" + redirectURL;
            ClientScript.RegisterStartupScript(this.GetType(), "RedirectURL", "<script>window.open('" + redirectURL + "');</script>");
        }
    }
}
