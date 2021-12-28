using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using ICBrowser.DAL;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ICBrowser.DAL
{
    public class AdvertisementRepository : Repository
    {
        public List<AdvertPanel> GetAdvertisementDetail(string position)
        {
            List<AdvertPanel> lst = new List<AdvertPanel>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("AdvertisementPanel");
            db.AddInParameter(command, "@Position", DbType.String, position);
            //db.AddInParameter(command, "@RequestId", DbType.Int32, thisRequest.RequestID);
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lst.Add(new AdvertPanel()
                    {
                        AdvertisementID = reader.GetValue<int>("AdvertisementID"),
                        UserID = reader.GetValue<Guid>("UserID"),
                        StartDate = reader.GetValue<DateTime>("StartDate"),
                        EndDate = reader.GetValue<DateTime>("EndDate"),
                        Text = reader.GetValue<String>("Text"),
                        ImageUrl = reader.GetValue<String>("ImageUrl"),
                        RedirectUrl = reader.GetValue<String>("RedirectUrl"),
                        Position = reader.GetValue<String>("Position"),
                    });
                }
                reader.Close();
                lst.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return lst;
        }

        /// <summary>
        /// Method to Insert new entry of Advertisement
        /// </summary>
        /// <param name="newAd"></param>
        /// <returns></returns>
        public DateTime InsertNewAd(AdvertPanel newAd)
        {
            // Use sample end date for reference
            DateTime currentEndDate = Convert.ToDateTime("01-Jan-2012");

            try
            {
                // Connect to database
                SqlDatabase db = new SqlDatabase(ConnectionString);
                DbCommand command = db.GetStoredProcCommand("InsertNewAdTest");

                // Create parameters required for stored proc
                db.AddInParameter(command, "@UserId", DbType.Guid, newAd.UserID);
                db.AddInParameter(command, "@StartDate", DbType.DateTime, newAd.StartDate);
                db.AddInParameter(command, "@EndDate", DbType.DateTime, newAd.EndDate);
                db.AddInParameter(command, "@Text", DbType.String, newAd.Text);
                db.AddInParameter(command, "@ImageUrl", DbType.String, newAd.ImageUrl);
                db.AddInParameter(command, "@RedirectUrl", DbType.String, newAd.RedirectUrl);
                db.AddInParameter(command, "@Position", DbType.String, newAd.Position);
                db.AddInParameter(command, "@Email", DbType.String, newAd.Email);
                db.AddOutParameter(command, "@AdId", DbType.Int32, 0);

                // Execute stored proc with reader
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    // Retrieve end date after execution of stored proc
                    currentEndDate = reader.GetValue<DateTime>("EndDate");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return currentEndDate;
        }

        /// <summary>
        /// Get previously uploaded ads from database
        /// </summary>
        /// <returns></returns>
        public List<AdvertPanel> GetUploadedAds()
        {
            List<AdvertPanel> lstAds = new List<AdvertPanel>();

            try
            {
                // Connect to database
                SqlDatabase db = new SqlDatabase(ConnectionString);
                DbCommand command = db.GetStoredProcCommand("GetAllUploadedAds");

                // Execute stored proc with reader
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                // Update list of advertisements retrieved from database
                while (reader.Read())
                {
                    lstAds.Add(new AdvertPanel()
                    {
                        AdvertisementID = reader.GetValue<int>("AdvertisementID"),
                        UserID = reader.GetValue<Guid>("UserID"),
                        StartDate = reader.GetValue<DateTime>("StartDate"),
                        EndDate = reader.GetValue<DateTime>("EndDate"),
                        Text = reader.GetValue<String>("Text"),
                        ImageUrl = reader.GetValue<String>("ImageUrl"),
                        RedirectUrl = reader.GetValue<String>("RedirectUrl"),
                        Position = reader.GetValue<String>("Position"),
                        Email=reader.GetValue<string>("Email"),
                    });
                }
                reader.Close();
                lstAds.TrimExcess();
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return lstAds;
        }

        /// <summary>
        /// Method to update particular entry of Ad in database
        /// </summary>
        /// <param name="updatedAd"></param>
        /// <returns></returns>
        public DateTime UpdateAd(AdvertPanel updatedAd)
        {
            // Use sample end date for reference
            DateTime currentEndDate = Convert.ToDateTime("01-Jan-2012");

            try
            {
                // Connect to database
                SqlDatabase db = new SqlDatabase(ConnectionString);
                DbCommand command = db.GetStoredProcCommand("UpdateAd");

                // Create parameters required for stored proc
                db.AddInParameter(command, "@StartDate", DbType.DateTime, updatedAd.StartDate);
                db.AddInParameter(command, "@EndDate", DbType.DateTime, updatedAd.EndDate);
                db.AddInParameter(command, "@Text", DbType.String, updatedAd.Text);
                db.AddInParameter(command, "@ImageUrl", DbType.String, updatedAd.ImageUrl);
                db.AddInParameter(command, "@RedirectUrl", DbType.String, updatedAd.RedirectUrl);
                db.AddInParameter(command, "@Position", DbType.String, updatedAd.Position);
                db.AddInParameter(command, "@AdId", DbType.Int32, updatedAd.AdvertisementID);
                db.AddInParameter(command, "@Email", DbType.String, updatedAd.Email);
                // Execute stored proc with reader
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    // Retrieve end date after execution of stored proc
                    currentEndDate = reader.GetValue<DateTime>("EndDate");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return currentEndDate;
        }

        /// <summary>
        /// Method to Delete an entry of Ad from database
        /// </summary>
        /// <param name="delAdId"></param>
        public void DeleteAd(int delAdId)
        {
            try
            {
                // Connect to database
                SqlDatabase db = new SqlDatabase(ConnectionString);
                DbCommand command = db.GetStoredProcCommand("DeleteAd");
                // Pass ID of the Ad to be deleted
                db.AddInParameter(command, "@AdId", DbType.Int32, delAdId);
                // Execute stored proc
                db.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
        }
    }
}
