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
    public class FavouritesRepository : Repository
    {
        public List<FavouriteDetails> getfavouriteDeatilsonUserId(Guid userID, int typeoflogin)
        {
            List<FavouriteDetails> lstdata = new List<FavouriteDetails>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetFavouriteDetailsByUserId");
            db.AddInParameter(command, "@UserID", DbType.Guid, userID);
            db.AddInParameter(command, "@Typeoflogin", DbType.Int32, typeoflogin);
            try
            {
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    lstdata.Add(new FavouriteDetails()
                    {
                        AddedOn = reader.GetValue<DateTime>("AddedOn"),
                        FavouritesID = reader.GetValue<int>("FavouritesId"),
                        FavUserID = reader.GetValue<Guid>("favUserID"),
                        CompanyName = reader.GetValue<string>("temp"),
                        UserID = reader.GetValue<Guid>("userid"),
                        //BuyerId = reader.GetValue<Int32>("buyerId")
                    });
                }
                reader.Close();
                lstdata.TrimExcess();


            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error in GetFavouriteDetailsByUserId " + userID.ToString());
            }
            return lstdata;
        }

        // Insert Record to add favorite
        // User Profile page
        public bool AddToFavourite(Guid userlogin, Guid AddedFavouriteUserId, DateTime dateTime, int status)
        {
            bool flag = false;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("AddToFavoriteList");
            try
            {
                db.AddInParameter(command, "@UserLoginID", DbType.Guid, userlogin);
                db.AddInParameter(command, "@AddedFavoriteUserId", DbType.Guid, AddedFavouriteUserId);
                db.AddInParameter(command, "@DateOfModified", DbType.DateTime, dateTime);
                db.AddOutParameter(command, "@Status", DbType.Int32, status);
                db.ExecuteReader(command);
                status = (int)command.Parameters["@Status"].Value;
                if (status > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return flag;
        }

        // Check wheather user is all ready added to his fav list
        public bool CheckForAddedFavListForUser(Guid usertologin, Guid addedfavuserid)
        {
            bool flag = false;
            int status;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("CheckForAlreadyAddedFavoriteList");
            try
            {
                db.AddInParameter(command, "@UserLoginID", DbType.Guid, usertologin);
                db.AddInParameter(command, "@AddedFavoriteUserId", DbType.Guid, addedfavuserid);
                db.AddOutParameter(command, "@Status", DbType.Int32, 0);
                db.ExecuteReader(command);
                status = (int)command.Parameters["@Status"].Value;
                if (status == 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return flag;
        }
    }
}
