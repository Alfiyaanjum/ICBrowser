using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.DAL;
using ICBrowser.Common;

namespace ICBrowser.Business
{
    public class BuyerRatingBySeller : BuyerRatingFromSellers
    {
        BuyerRatingFromSellers rating = new BuyerRatingFromSellers();
        Ratings rats = new Ratings();

        public void InsertBuyerRating(int sellerid, int rating1, int rating2, int rating3, int rating4, int buyerid, string Comment) //insert and update buyer rating  by Seller if sellerid is already present 
        {
            rating.InsertRatingForBuyer(sellerid, rating1, rating2, rating3, rating4, buyerid, Comment);
        }


        //public Ratings getAverageratingsOfSeller(Guid buyerid)//getAverage rating done by Seller on buyer
        //{
        //    rats = rating.SellersAverageRating(buyerid);
        //    return rats;
        //}
        //public int getBuyerAvgRating(Guid buyerid)
        //{
        //    int rate = rating.getBuyersAverageRate(buyerid);
        //    return rate;
        //}
    }
}
