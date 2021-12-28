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
using System.Data;


namespace ICBrowser.Web
{
    public partial class SellersRatingforBuyer : BasePage
    {

        #region "public Parameters"
        BuyerRatingBySeller BuyerRating = new BuyerRatingBySeller();
        Ratings rats = new Ratings();
        DataTable dtgetSellid = new DataTable();
        InventoryGridDetails invengrddetails = new InventoryGridDetails();
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                Guid userid = (Guid)userToLogin.ProviderUserKey;

                if (userToLogin != null)
                {
                    InventoryGridDetails sellersObj = new InventoryGridDetails();
                    int sellersCount = sellersObj.GetSellersCountByUserId(userid); //validates if the current user logged in is a seller or not

                    if (sellersCount > 0)
                    {
                        if (!IsPostBack)
                        {
                            listofQuestion();
                            calculateAverageRatings(Convert.ToInt32(Request.QueryString["BuyerId"]));
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
            lblQuestion1.Text = "Have you ever purchased a product or service from our website ?";
            lblQuestion2.Text = "How did you first hear about our web site?";
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
                int Buyerid = Convert.ToInt32(Request.QueryString["BuyerId"]);
                dtgetSellid = invengrddetails.getinventorylist();


                if (dtgetSellid.Rows.Count > 0)
                {
                    int sellerid = Convert.ToInt32(dtgetSellid.Rows[0]["SellerId"]);
                    //  BuyerRating.InsertBuyerRating(sellerid, getQuest1rating, getQuest2rating, getQuest3rating, getQuest4rating, Buyerid, txtComments.Text);
                    if (txtComments.Text != "")
                    {
                        BuyerRating.InsertBuyerRating(sellerid, getQuest1rating, getQuest2rating, getQuest3rating, getQuest4rating, Buyerid, txtComments.Text);
                    }
                    else
                    {
                        BuyerRating.InsertBuyerRating(sellerid, getQuest1rating, getQuest2rating, getQuest3rating, getQuest4rating, Buyerid, "");
                    }


                    calculateAverageRatings(Buyerid);
                    txtComments.Text = string.Empty; //clear textComment after Save
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        protected void calculateAverageRatings(int buyerid)
        {
            try
            {
                rats = BuyerRating.getAverageratingsOfSeller(buyerid);
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
            try
            {
                Response.Redirect("BuyerProfile.aspx?&Id=" + Convert.ToInt32(Request.QueryString["BuyerId"]));
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BuyerProfile.aspx?&Id=" + Convert.ToInt32(Request.QueryString["BuyerId"]));
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }
    }
}