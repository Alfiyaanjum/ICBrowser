using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using ICBrowser.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;


namespace ICBrowser.DAL
{
    public class SellerRatingFromBuyers : Repository
    {

        public bool InsertRatingForSeller(int buyerId, int quest1, int quest2, int quest3, int quest4, int sellerId, string comment) //insert and update Seller rating  by Buyers if buyerid is already present 
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("InsertSellerRatingFromBuyers");

            db.AddInParameter(command, "@buyerid", DbType.Int32, buyerId);
            db.AddInParameter(command, "@question1rating", DbType.Int32, quest1);
            db.AddInParameter(command, "@question2rating", DbType.Int32, quest2);
            db.AddInParameter(command, "@question3rating", DbType.Int32, quest3);
            db.AddInParameter(command, "@question4rating", DbType.Int32, quest4);
            db.AddInParameter(command, "@Sellerid", DbType.Int32, sellerId);
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

        public Ratings BuyersAverageRating(int sellerid) //gets Average Buyers Rating for Seller
        {
            Ratings rats = new Ratings();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("getAverageRatingofBuyer");
            db.AddInParameter(command, "@Sellerid", DbType.Int32, sellerid);

            try
            {
                IDataReader reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    rats = FillAverageRatings(reader);
                }

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

            return rats;
        }

        private Ratings FillAverageRatings(IDataReader reader)
        {
            Ratings avgrats = new Ratings();
            try
            {
                avgrats.Question1rating = reader.GetValue<int>("Question1rating");
                avgrats.Question2rating = reader.GetValue<int>("Question2rating");
                avgrats.Question3rating = reader.GetValue<int>("Question3rating");
                avgrats.Question4rating = reader.GetValue<int>("Question4rating");
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }


            return avgrats;
        }

        public int GetSellersAverageRate(Guid userid)//gets individual sellers rating while the logged in buyers View the SellerProfile 
        {

            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[getSellerAverageRating]");
            db.AddInParameter(command, "@UserId", DbType.Guid, userid);
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
