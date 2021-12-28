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
    public partial class RightPanel : System.Web.UI.UserControl
    {
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
                string position = "Right";
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
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

    }
}