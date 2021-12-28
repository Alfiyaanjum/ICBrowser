using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using ICBrowser.Web;
using System.Web.Security;
using System.Threading;
using AjaxControlToolkit;

namespace ICBrowser.Web
{
    public partial class BuyersRatingforSeller : BasePage
    {
        #region "public Parameters"
        SellerRatingByBuyer SellerRating = new SellerRatingByBuyer();  //business class object
        CompanyDetails cmd = new CompanyDetails();
        Ratings rats = new Ratings();
        public int buyerid = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                string userid = userToLogin.ProviderUserKey.ToString();

                Guid loggedinid = (Guid)userToLogin.ProviderUserKey;

                if (userToLogin != null)
                {
                    BuyersDataRequirement buydata = new BuyersDataRequirement();
                    int buyercount = buydata.getCountBuyersRequirementDetailsByUserId(userid);

                    cmd = buydata.GetBuyersid(loggedinid);
                    buyerid = cmd.BuyerOrSellerId;

                    if (buyercount > 0)
                    {
                        if (!Page.IsPostBack)
                        {
                            listofQuestion();
                            calculateAverageRatings(Convert.ToInt32(Request.QueryString["sellerid"]));
                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", true);
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", true);
                }
            }

            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }



        }

        protected void listofQuestion()
        {
            lblQuestion1.Text = "Rate the Quality of Components ?";
            lblQuestion2.Text = "Delivery of Components on time ?";
            lblQuestion3.Text = "Is there a retention period for your records ?";
            lblQuestion4.Text = "Do you have a back-up & retrieval system for your records ?";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int getQuest1rating = ratingQuest1.CurrentRating;
                int getQuest2rating = ratingQuest2.CurrentRating;
                int getQuest3rating = ratingQuest3.CurrentRating;
                int getQuest4rating = ratingQuest4.CurrentRating;
                int Sellerid = Convert.ToInt32(Request.QueryString["SellerId"]);
                string comment = txtComments.Text;

                SellerRating.InsertSellerRating(buyerid, getQuest1rating, getQuest2rating, getQuest3rating, getQuest4rating, Sellerid, comment); //insert and update Seller rating  by Buyers if buyerid is already present 
                calculateAverageRatings(Sellerid);  //bind rating with Average ratings for respective  Question from all buyers
                txtComments.Text = string.Empty;
                //  ClientScriptManager.RegisterClientScriptBlock(this.GetType(), "Alert", "<script type=text/javascript>alert('hi')</script>");
            }

            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        protected void calculateAverageRatings(int sellerid) //bind rating with Average ratings for respective  Question from all buyers
        {
            try
            {
                //create method tocalculate  Avg   rating  
                rats = SellerRating.getAverageratingsOfBuyer(sellerid);
                ratingQuest1.CurrentRating = rats.Question1rating;
                ratingQuest2.CurrentRating = rats.Question2rating;
                ratingQuest3.CurrentRating = rats.Question3rating;
                ratingQuest4.CurrentRating = rats.Question4rating;

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        protected void lbkback_Click(object sender, EventArgs e)
        {
            Response.Redirect("SellerProfile.aspx?SellerId=" + Convert.ToInt32(Request.QueryString["SellerId"]));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SellerProfile.aspx?SellerId=" + Convert.ToInt32(Request.QueryString["SellerId"]));
        }
    }
}