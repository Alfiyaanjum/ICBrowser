using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;
using System.Data;
using System.Web.Security;
using System.Xml.Linq;
using System.IO;
using ICBrowser.Common;

namespace ICBrowser.Web
{
    public partial class NewsFeed : System.Web.UI.UserControl
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            GetRSS();
        }
        /// <summary>
        /// Gets the RSS.
        /// </summary>
        private void GetRSS()
        {

            //Create a WebRequest
            WebRequest rssReq = WebRequest.Create("http://www.ecnmag.com/rss-feeds/all/rss.xml/all");

            //Create a Proxy
            WebProxy px = new WebProxy("http://www.ecnmag.com/rss-feeds/all/rss.xml/all", true);

            //Assign the proxy to the WebRequest
            rssReq.Proxy = px;

            //Set the timeout in Seconds for the WebRequest
            rssReq.Timeout = 20000;
            try
            {
                //Get the WebResponse
                WebResponse rep = rssReq.GetResponse();

                //Read the Response in a XMLTextReader
                XmlTextReader xtr = new XmlTextReader(rep.GetResponseStream());

                //Create a new DataSet
                DataSet ds = new DataSet();

                //Read the Response into the DataSet
                ds.ReadXml(xtr);

                //Bind the Results to the Repeater
                rssRepeater.DataSource = ds.Tables[2];
                rssRepeater.DataBind();
            }
         
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
    }
}


