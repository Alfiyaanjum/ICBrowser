using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using System.Data;
using System.Reflection;
using ICBrowser.Common;
using System.Web.Security;
using System.Collections;

namespace ICBrowser.Web
{
    /// <summary>
    /// Class ListingDetail.
    /// </summary>
    public class ListingDetail
    {
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string LandLine { get; set; }
        public string EmaiId { get; set; }
        public string QQId { get; set; }
        public string SkypeId { get; set; }
        public string MSNId { get; set; }
        public int TotalItems { get; set; }
        public List<ICBrowser.Common.Component> DetailsRequirement { get; set; }
    }
    public partial class DetailInventoryListing : BasePage
    {
        List<Common.Component> values = new List<Common.Component>();
        Hashtable htMoreDetailsInfo = new Hashtable();
        SellerInventoryListing sil = new SellerInventoryListing();
        Guid loggedInUserId;
        MembershipUser userToLogin = Membership.GetUser();
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    loggedInUserId = (Guid)userToLogin.ProviderUserKey;
                    Common.UserProfile objuserpro = new Common.UserProfile();
                    UserProfileDetails profiledetais = new UserProfileDetails();
                    int memTypeId = 0;
                    objuserpro = profiledetais.GetUserProfileDetails(loggedInUserId);
                    memTypeId = objuserpro.TypeOfMembership;
                    if (memTypeId >= 1)
                    {
                        BindRepeater(1);
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                }

            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PreRender event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (pagerForRepeater.ItemCount == 0 && pagerForRepeater.CurrentIndex > 0)
            {
                pagerForRepeater.CurrentIndex = 0;
                pagerForRepeater.Enabled = false;
                pagerForRepeater.Visible = false;
            }
            else
                pagerForRepeater.Visible = true;
        }

        /// <summary>
        /// Binds the repeater.
        /// </summary>
        /// <param name="currentPage">The current page.</param>
        private void BindRepeater(int currentPage)
        {
            loggedInUserId = (Guid)userToLogin.ProviderUserKey;
            var listOfComponents = sil.DetailedInventory(pagerForRepeater.PageSize, currentPage);

            List<ListingDetail> listOfDistinctOrders = new List<ListingDetail>();
            int count = listOfComponents.Count;

            SellerInventoryListing Offer = new SellerInventoryListing();
            List<ICBrowser.Common.Component> OfferDetails = new List<ICBrowser.Common.Component>();

            var asd = listOfComponents.OrderByDescending(aa => aa.ModifiedOn).ToList();

            foreach (var g in asd)
            {
                if (listOfDistinctOrders.Count(aa => aa.UserId == g.UserId) == 0)
                {
                    OfferDetails = Offer.UserOfferDetailsForMatch(g.UserId, loggedInUserId);
                    g.TotalItems = OfferDetails.Count;
                    listOfDistinctOrders.Add(new ListingDetail
                    {
                        UserId = g.UserId,
                        CompanyName = g.CompanyName,
                        Country = g.country,
                        City = g.City,
                        LandLine = g.LandLine,
                        EmaiId = g.EmailId,
                        QQId = g.QQId,
                        SkypeId = g.SkypeId,
                        MSNId = g.MSNId,
                        TotalItems = g.TotalItems,
                        DetailsRequirement = new List<ICBrowser.Common.Component>()
                    });
                }
            }


            List<Fields> values = new List<Fields>();

            foreach (var g in listOfDistinctOrders)
            {
                foreach (var d in listOfComponents.Where(aa => aa.UserId == g.UserId))
                {
                    if (d.PriceInUSD == 0) 
                    {
                        d.PriceInUSD = null;
                    }
                    g.DetailsRequirement.Add(d);
                }
            }
            pagerForRepeater.ItemCount = sil.TotalPages;
            Session["itemCount"] = pagerForRepeater.ItemCount;
            if (listOfComponents.Count() == 0 && pagerForRepeater.CurrentIndex > 1)
                BindRepeater(--pagerForRepeater.CurrentIndex);
            RepDetailed.DataSource = listOfDistinctOrders;
            RepDetailed.DataBind();

        }

        /// <summary>
        /// Handles the Command event of the pager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CommandEventArgs"/> instance containing the event data.</param>
        public void pager_Command(object sender, CommandEventArgs e)
        {
            int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
            pagerForRepeater.CurrentIndex = currnetPageIndx;
            BindRepeater(currnetPageIndx);
        }

        /// <summary>
        /// Handles the PreRender event of the pagerForRepeater control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void pagerForRepeater_PreRender(object sender, EventArgs e)
        {
            if (pagerForRepeater.ItemCount < pagerForRepeater.PageSize)
            {
                pagerForRepeater.Visible = false;
            }
        }

        /// <summary>
        /// Handles the ItemDataBound event of the RepDetailed control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RepeaterItemEventArgs"/> instance containing the event data.</param>
        protected void RepDetailed_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton ImgQQIdText = (ImageButton)e.Item.FindControl("ImgQQIdText");
                ImageButton ImgSkypeText = (ImageButton)e.Item.FindControl("ImgSkypeText");
                ImageButton ImgMSNText = (ImageButton)e.Item.FindControl("ImgMSNText");
                Label lblTel = (Label)e.Item.FindControl("lblTel");
                if (ImgQQIdText.ToolTip.Trim() != "")
                {
                    ImgQQIdText.Visible = true;
                }
                if (ImgSkypeText.ToolTip.Trim() != "")
                {
                    ImgSkypeText.Visible = true;
                }
                if (ImgMSNText.ToolTip.Trim() != "")
                {
                    ImgMSNText.Visible = true;
                }

                string Phone = lblTel.Text;
                if (Phone.Substring(1, 1) == "-")
                {
                    lblTel.Text = Phone.Replace("-", "");
                }
                else if (Phone.Contains("--"))
                {
                    lblTel.Text = Phone.Replace("--", "-");
                }
                else if (Phone.Substring(0, 1) == "-")
                {

                    lblTel.Text = Phone.Remove(0, 1);
                }
                else
                {
                    lblTel.Text = lblTel.Text;
                }

                LinkButton hnkMore = (LinkButton)e.Item.FindControl("hnkMore");
                Label lblTotalItems = ((Label)e.Item.FindControl("lblTotalItems"));

                if (Convert.ToInt32(lblTotalItems.Text) <= 10)
                {
                    hnkMore.Visible = false;
                }
                else
                {
                    hnkMore.Visible = true;
                }

                GridView Grid = (GridView)e.Item.FindControl("gvDetailInvList");
                foreach (GridViewRow gvr in Grid.Rows)
                {
                    Label lblStockStatus = ((Label)gvr.FindControl("lblStockStatus"));


                    if (lblStockStatus.Text == "1")
                        lblStockStatus.Text = "Available";
                    else if (lblStockStatus.Text == "2")
                        lblStockStatus.Text = "In House";
                    else
                        lblStockStatus.Text = "OEM Excess";

                }
            }
        }

        /// <summary>
        /// Handles the RowCommand event of the gvDetailInvList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvDetailInvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                LinkButton lnkComponentName = (LinkButton)row.Cells[0].FindControl("lnkComponentName");
                LinkButton hnkMore = (LinkButton)row.Cells[0].FindControl("hnkMore");
                LinkButton lnkUserId = (LinkButton)row.Cells[0].FindControl("lnkUserId");

                if (lnkComponentName != null)
                {

                    lnkComponentName = row.FindControl("lnkComponentName") as LinkButton;
                    string ComponentName = lnkComponentName.Text.Replace("&nbsp;", "");
                    string Quantity = row.Cells[2].Text.Trim();
                    string BrandName = row.Cells[4].Text.Trim().Replace("&nbsp;", "");
                    string DateCode = row.Cells[5].Text.Trim().Replace("&nbsp;", "");
                    string Comment = row.Cells[7].Text.Trim().Replace("&nbsp;", "");
                    string PriceInUSD = row.Cells[8].Text.Trim().Replace("&nbsp;", "");
                    string Package = row.Cells[6].Text.Trim().Replace("&nbsp;", "");

                    if (PriceInUSD == "")
                    {
                        values.Add(new Common.Component
                        {
                            ComponentName = ComponentName,
                            Quantity = Convert.ToInt32(Quantity),
                            BrandName = BrandName,
                            datecode = DateCode,
                            //PriceInUSD = Convert.ToDecimal(PriceInUSD),
                            Description = Comment,
                            package = Package
                        });
                    }
                    else
                    {
                        values.Add(new Common.Component
                        {
                            ComponentName = ComponentName,
                            Quantity = Convert.ToInt32(Quantity),
                            BrandName = BrandName,
                            datecode = DateCode,
                            PriceInUSD = Convert.ToDecimal(PriceInUSD),
                            Description = Comment,
                            package = Package
                        });
                    }
                    


                }

                if (values.Count != 0)
                {
                    htMoreDetailsInfo.Add("UserId", lnkUserId.Text.Trim());
                    htMoreDetailsInfo.Add("RequestType", "Offers");
                    htMoreDetailsInfo.Add("PartNo", values[0].ComponentName);
                    htMoreDetailsInfo.Add("Page", "MoreDetails");
                    htMoreDetailsInfo.Add("Values", values);
                    Session["GetList"] = htMoreDetailsInfo;
                    Session["FileUpload1"] = "";
                    Response.Redirect("UserResponse.aspx", false);
                }

                //Label lblOffer = (Label)row.Cells[0].FindControl("lblOffer");
                //if (lblOffer != null)
                //{
                //    if (lblOffer.Text.Equals("1"))
                //    {
                //        Response.Redirect("OfferDetails.aspx?ComponentName=" + lnkComponentName.Text.Trim(), false);
                //    }
                //}
            }
        }

        public class Fields
        {
            public int TotalItems { get; set; }
        }

        /// <summary>
        /// Handles the ItemCommand event of the RepDetailed control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="e">The <see cref="RepeaterCommandEventArgs"/> instance containing the event data.</param>
        protected void RepDetailed_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "More")
            {
                pagerForRepeater.ItemCount = Convert.ToInt32(Session["itemCount"]);
                Guid userid = new Guid(e.CommandArgument.ToString());
                Hashtable htFullList = new Hashtable();
                htFullList.Add("UserId", userid);
                htFullList.Add("type", "Offer");
                Session["FullList"] = htFullList;
                //Response.Redirect("MoreDetails.aspx", false);
                ClientScript.RegisterStartupScript(this.GetType(), "ViewDetails", "<script>window.open('MoreDetails.aspx');</script>");
            }

            if (e.CommandName == "button")
            {
                loggedInUserId = (Guid)userToLogin.ProviderUserKey;

                SellerInventoryListing Offer = new SellerInventoryListing();
                List<ICBrowser.Common.Component> OfferDetails = new List<ICBrowser.Common.Component>();
                Guid userid = new Guid(e.CommandArgument.ToString());

                OfferDetails = Offer.UserOfferDetailsForMatch(userid, loggedInUserId);

                foreach (var i in OfferDetails)
                {
                    if (i.PriceInUSD == 0)
                    {
                        i.PriceInUSD = null;
                    }
                    values.Add(new Common.Component
                    {
                        ComponentName = i.ComponentName,
                        Quantity = i.Quantity,
                        BrandName = i.BrandName,
                        datecode = i.datecode,
                        PriceInUSD = i.PriceInUSD,
                        Description = i.Description,
                        package = i.package

                    });
                }

                htMoreDetailsInfo.Add("UserId", userid);
                htMoreDetailsInfo.Add("RequestType", "Offers");
                htMoreDetailsInfo.Add("PartNo", values[0].ComponentName);
                htMoreDetailsInfo.Add("Page", "MoreDetails");
                htMoreDetailsInfo.Add("Values", values);
                Session["GetList"] = htMoreDetailsInfo;
                Session["FileUpload1"] = "";
                //Response.Redirect("MoreDetails.aspx", false);
                Response.Redirect("UserResponse.aspx", false);
            }
        }

        /// <summary>
        /// Handles the RowDataBound event of the gvDetailInvList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvDetailInvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gvr = e.Row;
            if (gvr.RowType.Equals(DataControlRowType.DataRow))
                (gvr.FindControl("hlComponentName") as HyperLink).ToolTip = "Click to view Datasheet";
            //pdfLink.ToolTip = ;

            if ((e.Row.RowType == DataControlRowType.DataRow))
            {

                Label lblmodifedon = e.Row.FindControl("lblModifiedOn") as Label;
                string Modifiedon = String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(lblmodifedon.Text));
                if (lblmodifedon != null)
                {
                    //if (Modifiedon == DateTime.Now.ToString("dd-MMM-yyyy"))
                    //{
                    //    lblmodifedon.Text = String.Format("{0:HH:mm:ss}", Convert.ToDateTime(lblmodifedon.Text));
                    //}
                    //else
                    {
                        lblmodifedon.Text = String.Format("{0:dd-MMM-yyyy HH:mm:ss}", Convert.ToDateTime(lblmodifedon.Text));
                    }

                }
            }

        }
    }
}