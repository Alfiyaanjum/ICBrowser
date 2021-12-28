using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Xml;
using ICBrowser.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web;
using System.Collections;

namespace ICBrowser.DAL
{
    public class BuyerCompanyDetailsRepository : Repository
    {
        #region IRepository<CompanyDetails> Members

        /// <summary>
        /// Creates new database entry for Buyer's Address Details
        /// </summary>
        /// <param name="newBuyerAddressDetails"></param>
        public bool CreateBuyerAddressDetailsEntry(AddressDetails newUserAddressDetails)
        {
            try
            {
                // Connect to database
                SqlDatabase db = new SqlDatabase(ConnectionString);
                DbCommand command = db.GetStoredProcCommand("UserAddressDetailsCreate");

                // Create parameters required for stored proc
                db.AddInParameter(command, "@UserId", DbType.Guid, newUserAddressDetails.UserId);
                db.AddInParameter(command, "@PrimaryAddress", DbType.String, newUserAddressDetails.PrimaryAddress);
                db.AddInParameter(command, "@PrimaryCountry", DbType.String, newUserAddressDetails.PrimaryCountry);
                db.AddInParameter(command, "@PrimaryCity", DbType.String, newUserAddressDetails.PrimaryCity);
                db.AddInParameter(command, "@PrimaryState", DbType.String, newUserAddressDetails.PrimaryState);
                db.AddInParameter(command, "@PrimaryZip", DbType.String, newUserAddressDetails.PrimaryZip);


                db.AddInParameter(command, "@SecondaryAddress", DbType.String, newUserAddressDetails.SecondaryAddress);
                db.AddInParameter(command, "@SecondaryCity", DbType.String, newUserAddressDetails.SecondaryCity);
                db.AddInParameter(command, "@SecondaryState", DbType.String, newUserAddressDetails.SecondaryState);
                db.AddInParameter(command, "@SecondaryZip", DbType.String, newUserAddressDetails.SecondaryZip);
                db.AddInParameter(command, "@SecondaryCountry", DbType.String, newUserAddressDetails.SecondaryCountry);

                db.AddInParameter(command, "@LandLine", DbType.String, newUserAddressDetails.LandLine);
                db.AddInParameter(command, "@Mobile", DbType.String, newUserAddressDetails.Mobile);
                db.AddInParameter(command, "@Extension", DbType.String, newUserAddressDetails.Extension);
                db.AddInParameter(command, "@Website", DbType.String, newUserAddressDetails.Website);
                db.AddInParameter(command, "@FaxNumber", DbType.String, newUserAddressDetails.FaxNumber);

                db.AddInParameter(command, "@QQId", DbType.String, newUserAddressDetails.QQId);
                db.AddInParameter(command, "@SkypeId", DbType.String, newUserAddressDetails.SkypeId);
                db.AddInParameter(command, "@MSNId", DbType.String, newUserAddressDetails.MSNId);

                // Execute stored proc
                int temp = db.ExecuteNonQuery(command);
                if (temp > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Log the exception message.
                IClogger.LogError(ex.Message);
            }
            return false;
        }

        public CompanyDetails GetBuyerCompanyDetailsByID(int ID, string username)
        {
            CompanyDetails requestsForUser = new CompanyDetails();

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetBuyerCompanyDetailsByID");

            db.AddInParameter(command, "@BuyerID", DbType.Int32, ID);
            db.AddInParameter(command, "@UserName", DbType.String, username);

            try
            {
                IDataReader reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    requestsForUser = fill(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error in GetBuyerCompanyDetailsByID for ID: " + ID.ToString());
            }
            return requestsForUser;
        }

      

        #endregion

        #region PrivateFunctions

        private CompanyDetails fill(IDataReader reader)
        {
            CompanyDetails CompanyDetailsEntity = new CompanyDetails();

            CompanyDetailsEntity.CompanyName = reader.GetValue<String>("BuyerName");
            CompanyDetailsEntity.ContactName = reader.GetValue<String>("ContactName");
            CompanyDetailsEntity.PhoneNumber = reader.GetValue<String>("PhoneNumber");
            CompanyDetailsEntity.FaxNumber = reader.GetValue<String>("FaxNumber");
            CompanyDetailsEntity.Email = reader.GetValue<String>("Email");
            CompanyDetailsEntity.Website = reader.GetValue<String>("Website");
            CompanyDetailsEntity.PrimaryAddress = reader.GetValue<String>("PrimaryAddress");
            CompanyDetailsEntity.PrimaryCity = reader.GetValue<String>("City");
            CompanyDetailsEntity.PrimaryState = reader.GetValue<String>("State");
            CompanyDetailsEntity.PrimaryZip = reader.GetValue<String>("Zip");
            CompanyDetailsEntity.PrimaryCountry = reader.GetValue<String>("Country");
            CompanyDetailsEntity.Description = reader.GetValue<String>("Description");

            return CompanyDetailsEntity;

        }

        #endregion

      

        public List<BuyerDetailsRevised> getBuyerDetailOnBuyerId(int buyerid)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("getBuyerDetailFromBuyerId1");
            List<BuyerDetailsRevised> objBuyerDetails = new List<BuyerDetailsRevised>();
            try
            {
                db.AddInParameter(command, "@BuyerID", DbType.Int32, buyerid);
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    objBuyerDetails.Add(new BuyerDetailsRevised
                    {
                        BuyerID = reader.GetValue<int>("BuyerId"),
                        CompanyName = reader.GetValue<string>("BuyerName"),
                        ContactName = reader.GetValue<string>("ContactName"),
                        Currency = reader.GetValue<string>("Currency"),
                        UserId = reader.GetValue<Guid>("UserId"),
                        OwnerName = reader.GetValue<string>("OwnerName")
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return objBuyerDetails;
        }



        private EmailDetailsForUser getmessageid(IDataReader reader)
        {
            EmailDetailsForUser emaildet = new EmailDetailsForUser();
            try
            {

                emaildet.MessageId = reader.GetValue<int>("MessageId");

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }

            return emaildet;
        }



        public List<EmailDetailsForUser> getSentEmailDetailLoginUsers(string fromuserid)
        {
            List<EmailDetailsForUser> lstUsersEmailDetails = new List<EmailDetailsForUser>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetSentEmailDetailsForUsers");
            Guid FromUserId = new Guid(fromuserid);
            try
            {
                db.AddInParameter(command, "@fromUserId", DbType.Guid, FromUserId);
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    lstUsersEmailDetails.Add(new EmailDetailsForUser
                    {
                        FromUserId = reader.GetValue<Guid>("FromUserId"),
                        MessageDescription = reader.GetValue<string>("MessageDescription"),
                        MessageId = reader.GetValue<int>("MessageId"),
                        SentDate = reader.GetValue<DateTime>("SentDate"),
                        Status = reader.GetValue<Boolean>("Status"),
                        Subject = reader.GetValue<string>("Subject"),
                        ToUserId = reader.GetValue<Guid>("ToUserId")
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lstUsersEmailDetails;
        }

        public List<EmailDetailsForUser> getEmailDetailsForModalPopuu(int MessageId)
        {
            List<EmailDetailsForUser> lstUsersEmailDetails = new List<EmailDetailsForUser>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetEmailDetailsForUsersOnMessageId");
            try
            {
                db.AddInParameter(command, "@MessageId", DbType.Int32, MessageId);
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    lstUsersEmailDetails.Add(new EmailDetailsForUser
                    {
                        FromUserId = reader.GetValue<Guid>("FromUserId"),
                        MessageDescription = reader.GetValue<string>("MessageDescription"),
                        MessageId = reader.GetValue<int>("MessageId"),
                        SentDate = reader.GetValue<DateTime>("SentDate"),
                        Status = reader.GetValue<Boolean>("Status"),
                        Subject = reader.GetValue<string>("Subject"),
                        ToUserId = reader.GetValue<Guid>("ToUserId"),
                        toEmailAddress = reader.GetValue<string>("ToMail"),
                        fromEmailAddress = reader.GetValue<string>("FromMail")
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lstUsersEmailDetails;
        }


        public List<EmailDetailsForUser> BindGridonForDeleteItems(string usertologin)
        {
            List<EmailDetailsForUser> lstUsersEmailDetails = new List<EmailDetailsForUser>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("BindGridForDeleteMailItems");
            Guid UserId = new Guid(usertologin);
            try
            {
                db.AddInParameter(command, "@usertologin", DbType.Guid, UserId);
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    lstUsersEmailDetails.Add(new EmailDetailsForUser
                    {
                        FromUserId = reader.GetValue<Guid>("FromUserId"),
                        MessageDescription = reader.GetValue<string>("MessageDescription"),
                        MessageId = reader.GetValue<int>("MessageId"),
                        SentDate = reader.GetValue<DateTime>("SentDate"),
                        Status = reader.GetValue<Boolean>("Status"),
                        Subject = reader.GetValue<string>("Subject"),
                        ToUserId = reader.GetValue<Guid>("ToUserId")
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lstUsersEmailDetails;
        }


       

        public void DeleteFavoriteOnId(string userlogin, string FavId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("DeleteFavouriteBasedOnIdAndLoginInUser");
            try
            {
                db.AddInParameter(command, "@UserLoginID", DbType.String, userlogin);
                db.AddInParameter(command, "@FavouriteID", DbType.Int32, FavId);
                db.ExecuteReader(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

     

        public bool IsAdminCheckForUserLogin(Guid userid)
        {
            int status;
            bool flag = false;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("CheckIsAdminUserLoggeInUser");
            try
            {
                db.AddInParameter(command, "@UserLoginID", DbType.Guid, userid);
                db.AddOutParameter(command, "@Status", DbType.Int32, 0);
                db.ExecuteReader(command);
                status = (int)command.Parameters["@Status"].Value;
                if (status == 1) // user is admin
                {
                    flag = true;
                }
                else // user is not admin
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
