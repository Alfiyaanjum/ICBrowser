using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.DAL;
using ICBrowser.Common;

namespace ICBrowser.Business
{
    public class SellerRatingByBuyer
    {
        SellerRatingFromBuyers rating = new SellerRatingFromBuyers(); //DAL class  object
        Ratings rats = new Ratings();

        public void InsertSellerRating(int buyerId, int rating1, int rating2, int rating3, int rating4, int sellerId, string comment) //insert and update Seller rating  by Buyers if buyerid is already present 
        {
            try
            {
                rating.InsertRatingForSeller(buyerId, rating1, rating2, rating3, rating4, sellerId, comment);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        public Ratings getAverageratingsOfBuyer(int sellerid)//getAverage rating done by Buyer on Seller
        {
            try
            {
                rats = rating.BuyersAverageRating(sellerid);
                // return rats;
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return rats;
        }

        public int getSellerAvgRating(Guid userid)
        {
            int rate = 0;
            try
            {
                rate = rating.GetSellersAverageRate(userid);
                //  return rate;
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return rate;
        }
    }
}
