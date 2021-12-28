﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Web.Security;
using System.Collections;

namespace ICBrowser.Web
{
    public class BuyerDetailsRevised
    {
        public Guid userId { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string LandLine { get; set; }
        public string EmaiId { get; set; }
        public string QQId { get; set; }
        public string SkypeId { get; set; }
        public string MSNId { get; set; }
        public int TotalItems { get; set; }
        public List<ICBrowser.Common.BuyersRequirements> BuyersRequirement { get; set; }
    }

    public partial class DetailedBuyersRequirements : BasePage
    {
        List<Common.Component> values = new List<Common.Component>();

        BuyersDetailedListing buy = new BuyersDetailedListing();

        Hashtable htMoreDetailsInfo = new Hashtable();

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindRepeater(1);
            }

        }

        /// <summary>
        /// Handles the PreRender event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

        }

        /// <summary>
        /// Binds the repeater.
        /// </summary>
        /// <param name="currentPage">The current page.</param>
        private void BindRepeater(int currentPage)
        {
            try
            {
                var listOfComponents = buy.BuyersDetailedRequirements(pagerForRepeater.PageSize, currentPage);

                List<BuyerDetailsRevised> listOfDistinctOrders = new List<BuyerDetailsRevised>();
                List<ICBrowser.Common.BuyersRequirements> buyersDetails = new List<BuyersRequirements>();
                UserRequirements UserData = new UserRequirements();


                var asd = listOfComponents.OrderByDescending(aa => aa.ModifiedDate).ToList();



                foreach (var g in asd)
                {
                    if (listOfDistinctOrders.Count(aa => aa.userId == g.userId) == 0)
                    {
                        buyersDetails = UserData.UserRequirementListingRFQByUserId(g.userId);
                        g.TotalItems = buyersDetails.Count;

                        listOfDistinctOrders.Add(new BuyerDetailsRevised
                        {
                            userId = g.userId,
                            CompanyName = g.CompanyName,
                            Country = g.Country,
                            City = g.City,
                            LandLine = g.LandLine,
                            EmaiId = g.EmailId,
                            QQId = g.QQId,
                            SkypeId = g.SkypeId,
                            MSNId = g.MSNId,
                            TotalItems = g.TotalItems,
                            BuyersRequirement = new List<ICBrowser.Common.BuyersRequirements>()
                        });
                    }
                }


                foreach (var g in listOfDistinctOrders)
                {
                    foreach (var d in listOfComponents.Where(aa => aa.userId == g.userId))
                    {
                        if (d.PriceInUSD == 0)
                        {
                            d.PriceInUSD = null;
                        }
                        g.BuyersRequirement.Add(d);

                    }
                }

                pagerForRepeater.ItemCount = buy.TotalPages;
                Session["itemCount"] = pagerForRepeater.ItemCount;
                if (listOfComponents.Count() == 0 && pagerForRepeater.CurrentIndex > 1)
                    BindRepeater(--pagerForRepeater.CurrentIndex);
                rptrBuyer.DataSource = listOfDistinctOrders;
                rptrBuyer.DataBind();

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

        }

        /// <summary>
        /// Handles the Command event of the pager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CommandEventArgs"/> instance containing the event data.</param>
        public void pager_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
                pagerForRepeater.CurrentIndex = currnetPageIndx;
                //Session["index"] = currnetPageIndx;
                BindRepeater(currnetPageIndx);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the PreRender event of the pagerForRepeater control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void pagerForRepeater_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (pagerForRepeater.ItemCount < pagerForRepeater.PageSize)
                {
                    pagerForRepeater.Visible = false;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the ItemDataBound event of the rptrBuyer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RepeaterItemEventArgs"/> instance containing the event data.</param>
        protected void rptrBuyer_ItemDataBound(object sender, RepeaterItemEventArgs e)
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


                //Repeater rptDemo = sender as Repeater; // Get the Repeater control object.

                // If the Repeater contains no data.
                if (rptrBuyer != null && rptrBuyer.Items.Count < 1)
                {
                    if (e.Item.ItemType == ListItemType.Footer)
                    {
                        // Show the Error Label (if no data is present).
                        Label lblErrorMsg = e.Item.FindControl("lblErrorMsg") as Label;
                        if (lblErrorMsg != null)
                        {
                            lblErrorMsg.Visible = true;
                        }
                    }
                }

                //GridView Grid = (GridView)e.Item.FindControl("gvBuyrListng");
                //if (Grid != null)
                //{
                //    foreach (GridViewRow row in Grid.Rows)
                //    {
                //        Label RequirementWithPO = (Label)row.FindControl("lblWithPO");
                //        if (RequirementWithPO != null)
                //        {
                //            if (RequirementWithPO.Text == "True")
                //            {
                //                RequirementWithPO.Text = "PO";
                //            }
                //            else
                //            {
                //                RequirementWithPO.Text = "RFQ";
                //            }
                //            // do stuff in here.
                //        }
                //    }
                //}
            }
        }

        /// <summary>
        /// Handles the RowCommand event of the gvBuyrListng control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvBuyrListng_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid userid = new Guid(userToLogin.ProviderUserKey.ToString());

            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            LinkButton lnkSellerId = (LinkButton)row.Cells[0].FindControl("lnkSellerId");
            if (e.CommandName == "Select")
            {


                if (userToLogin != null)
                {

                    LinkButton lnkbtn = row.FindControl("lnkComponentName") as LinkButton;
                    string test1 = lnkbtn.Text.Replace("&nbsp;", "");
                    //((LinkButton)row.Cells[2].FindControl("lnk"));

                    Label lblQty = row.FindControl("lblQuantity") as Label;
                    string test2 = lblQty.Text.Replace("&nbsp;", "");

                    Label lblBrandName = row.FindControl("lblBrandName") as Label;
                    string test3 = lblBrandName.Text.Replace("&nbsp;", "");

                    Label lblDateCode = row.FindControl("lblDateCode") as Label;
                    string test4 = lblDateCode.Text.Replace("&nbsp;", "");

                    Label lblUnitPrice = row.FindControl("lblPriceInUSD") as Label;
                    string test5 = lblUnitPrice.Text.Replace("&nbsp;", "");

                    Label lblDescription = row.FindControl("lbldescription") as Label;
                    string test6 = lblDescription.Text.Replace("&nbsp;", "");

                    Label lblPackage = row.FindControl("lblpackage") as Label;

                    //if (userid == senduserid)
                    //{

                    if (lnkbtn != null)
                    {
                        if (test5 == "")
                        {
                            values.Add(new Common.Component
                            {

                                ComponentName = lnkbtn.Text.Trim(),
                                Quantity = Convert.ToInt32(test2),
                                BrandName = test3,
                                datecode = test4,
                                //PriceInUSD = Convert.ToDecimal(test5),
                                package = lblPackage.Text,
                                Description = test6
                            });
                        }
                        else
                        {
                            values.Add(new Common.Component
                            {

                                ComponentName = lnkbtn.Text.Trim(),
                                Quantity = Convert.ToInt32(test2),
                                BrandName = test3,
                                datecode = test4,
                                PriceInUSD = Convert.ToDecimal(test5),
                                Description = test6,
                                package = lblPackage.Text
                            });
                        }
                        
                    }

                }
            }


            if (values.Count != 0)
            {
                htMoreDetailsInfo.Add("UserId", lnkSellerId.Text.Trim());
                htMoreDetailsInfo.Add("RequestType", "Requirements");
                htMoreDetailsInfo.Add("PartNo", values[0].ComponentName);
                htMoreDetailsInfo.Add("Page", "MoreDetails");
                htMoreDetailsInfo.Add("Values", values);
                Session["GetList"] = htMoreDetailsInfo;
                Session["FileUpload1"] = "";
                Response.Redirect("UserResponse.aspx", false);
            }
        }

        /// <summary>
        /// Handles the ItemCommand event of the rptrBuyer control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="e">The <see cref="RepeaterCommandEventArgs"/> instance containing the event data.</param>
        protected void rptrBuyer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            UserRequirements UserData = new UserRequirements();
            List<ICBrowser.Common.BuyersRequirements> buyersDetails = new List<BuyersRequirements>();
            if (e.CommandName == "More")
            {
                //int currnetPageIndx = Convert.ToInt32(Session["index"]);
                pagerForRepeater.ItemCount = Convert.ToInt32(Session["itemCount"]);
                //pagerForRepeater.CurrentIndex = currnetPageIndx;
                //BindRepeater(currnetPageIndx);
                Guid userid = new Guid(e.CommandArgument.ToString());
                Hashtable htFullList = new Hashtable();
                htFullList.Add("UserId", userid);
                htFullList.Add("type", "Requirement");
                Session["FullList"] = htFullList;
                //Response.Redirect("MoreDetails.aspx", false);
                ClientScript.RegisterStartupScript(this.GetType(), "ViewDetails", "<script>window.open('MoreDetails.aspx');</script>");
            }
            if (e.CommandName == "button")
            {
                Guid userid = new Guid(e.CommandArgument.ToString());
                //Hashtable htFullList = new Hashtable();
                //htFullList.Add("UserId", userid);
                //htFullList.Add("type", "Requirement");
                //Session["FullList"] = htFullList;

                buyersDetails = UserData.UserRequirementListingRFQByUserId(userid);

                foreach (var i in buyersDetails)
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
                        datecode = i.DateCode,
                        PriceInUSD = i.PriceInUSD,
                        Description = i.Description,
                        package = i.Package

                    });
                }


                htMoreDetailsInfo.Add("UserId", userid);
                htMoreDetailsInfo.Add("RequestType", "Requirements");
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
        /// Handles the RowDataBound event of the gvBuyrListng control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvBuyrListng_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gvr = e.Row;
            //if (gvr.RowType.Equals(DataControlRowType.DataRow))
            //    (gvr.FindControl("hlComponentName") as HyperLink).ToolTip = "Click to view Datasheet";

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


