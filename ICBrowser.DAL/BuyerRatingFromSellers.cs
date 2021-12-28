using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;


namespace ICBrowser.DAL
{
    public class BuyerRatingFromSellers : Repository
    {
        Ratings rates = new Ratings();

        public bool InsertRatingForBuyer(int sellerId, int quest1, int quest2, int quest3, int quest4, int buyerId, string comment) //insert and update Seller rating  by Buyers if buyerid is already present 
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[InsertBuyerRatingFromSellers]");

            db.AddInParameter(command, "@sellerid", DbType.Int32, sellerId);
            db.AddInParameter(command, "@question1rating", DbType.Int32, quest1);
            db.AddInParameter(command, "@question2rating", DbType.Int32, quest2);
            db.AddInParameter(command, "@question3rating", DbType.Int32, quest3);
            db.AddInParameter(command, "@question4rating", DbType.Int32, quest4);
            db.AddInParameter(command, "@buyerid", DbType.Int32, buyerId);
            db.AddInParameter(command, "@Comment", DbType.String, comment);

            try
            {
                db.ExecuteNonQuery(command);
                return true;
            }

            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
                return false;
            }
        }

        public Ratings SellersAverageRating(int buyerid) //gets Average Seller Rating for buyer
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[getAverageRatingofSeller]");
            db.AddInParameter(command, "@buyerid", DbType.Guid, buyerid);

            try
            {
                IDataReader reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    rates = fillAverageRatings(reader);
                }

            }
            catch (Exception ex)
            {

                IClogger.LogMessage(ex.Message);
            }

            return rates;
        }

        private Ratings fillAverageRatings(IDataReader reader)
        {
            try
            {
                //Ratings rats = new Ratings();
                rates.Question1rating = reader.GetValue<int>("Question1rating");
                rates.Question2rating = reader.GetValue<int>("Question2rating");
                rates.Question3rating = reader.GetValue<int>("Question3rating");
                rates.Question4rating = reader.GetValue<int>("Question4rating");
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return rates;
        }

        public int getBuyersAverageRate(Guid buyerid)//gets individual sellers rating while the logged in buyers View the SellerProfile 
        {

            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[getBuyerAverageRating]");
            db.AddInParameter(command, "@buyerid", DbType.Guid, buyerid);
            int rate = 0;

            try
            {
                rate = Convert.ToInt32(db.ExecuteScalar(command));

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

            return rate;
        }

    }
}
