using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ICBrowser.Business;
using ICBrowser.Common;
using System.DirectoryServices;
using System.Security.Principal;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Data;

namespace ICBrowser.Web
{
    public partial class _Default : BasePage
    {
        public Common.UserProfile objuserPro = new Common.UserProfile();
        public int sellersCount = 0;
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            UserControl ucSellerInvent = (UserControl)LoadControl("~/Controls/gvSellerInventoryListing.ascx");
            UserControl ucBuyerRequi = (UserControl)LoadControl("~/Controls/BuyersRequirements.ascx");
            UserControl ucExRateWidget = (UserControl)LoadControl("~/Controls/ucCurrencyExchangeRate.ascx");

            try
            {
                
                    //String UserName = string.Empty;
                    //UserName = Context.User.Identity.Name;
                    //string IPAdd = string.Empty;
                    //IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    //if (string.IsNullOrEmpty(IPAdd))
                    //    IPAdd = Request.ServerVariables["REMOTE_ADDR"];

                    //// lblIP.Text = IPAdd;
                    ////  IPAdd = "122.160.116.113";
                    //GetLocation(IPAdd);
                

                if (Membership.GetUser() != null)
                {
                    MembershipUser userToLogin = Membership.GetUser();
                    if (userToLogin != null)
                    {
                        Guid useridLogin = (Guid)userToLogin.ProviderUserKey;
                        InventoryGridDetails objInventorygriddetails = new InventoryGridDetails();
                        objuserPro = objInventorygriddetails.GetUserCountByUserId(useridLogin);
                        sellersCount = objuserPro.TypeOfMembership;
                        if (sellersCount > 1)
                        {
                            phTop.Controls.Add(ucBuyerRequi);
                            phBottom.Controls.Add(ucSellerInvent);
                        }
                        else
                        {
                            phTop.Controls.Add(ucSellerInvent);
                            phBottom.Controls.Add(ucBuyerRequi);
                        }
                    }
                    else
                    {
                        phTop.Controls.Add(ucSellerInvent);
                        phBottom.Controls.Add(ucBuyerRequi);
                    }
                }
                else
                {
                    phTop.Controls.Add(ucSellerInvent);
                    phBottom.Controls.Add(ucBuyerRequi);
                }
              
            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        //private void GetLocation(string IPAdd)
        //{
        //    WebRequest rssReq = WebRequest.Create("http://api.hostip.info/?ip={0}&position=true" + IPAdd);
        //    WebProxy px = new WebProxy("http://api.hostip.info/?ip={0}&position=true" + IPAdd, true);
        //    rssReq.Proxy = px;
        //    rssReq.Timeout = 2000;
        //    try
        //    {
        //        string currUserId = "";
        //        MembershipUser userToLogin = Membership.GetUser();
        //        if (userToLogin != null)
        //        {
        //            currUserId = Convert.ToString(userToLogin.ProviderUserKey);
        //        }
        //        WebResponse rep = rssReq.GetResponse();
        //        XmlTextReader xtr = new XmlTextReader(rep.GetResponseStream());
        //        Label lbl = new Label();
        //        DataSet ds = new DataSet();
        //        ds.ReadXml(xtr);

        //        UserLocationDetails LocDet = new UserLocationDetails();
        //        LocDet.City = ds.Tables["Hostip"].Rows[0]["name"].ToString();
        //        //lblCity.Text = ds.Tables[0].Rows[0][3].ToString();
        //        LocDet.Country = ds.Tables["Hostip"].Rows[0]["countryName"].ToString();
        //        LocDet.UserId = currUserId;
        //        LocDet.IPAddress = IPAdd;

        //        AdminStaticData admin = new AdminStaticData();
        //        admin.InserUserLocationDetails(LocDet);
        //        //return ds.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }


        //}
    }
}
