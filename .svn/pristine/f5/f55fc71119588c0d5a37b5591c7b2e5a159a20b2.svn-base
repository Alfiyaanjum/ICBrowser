using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace ICBrowser.DAL
{
    public class SellersRepository : Repository
    {
        public UserProfile GetSellerProfileDetails(Guid userid)
        {
            UserProfile User = new UserProfile();

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetUserProfileDetailsById");
            db.AddInParameter(command, "@UserId", DbType.Guid, userid);

            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    User = FillSellerProfile(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return User;
        }

        private UserProfile FillSellerProfile(IDataReader reader)
        {
            UserProfile user = new UserProfile();
            try
            {


                //cmpdet.BuyerOrSellerId = Convert.ToInt32(reader.GetValue<int>("SellerId"));

                user.CompanyName = reader.GetValue<string>("CompanyName");
                user.ContactName = reader.GetValue<string>("ContactName");
                user.OwnerName = reader.GetValue<string>("OwnerName");
                user.EmailPreference = reader.GetValue<Int32>("EMailPreference");
                user.ModifiedDate = reader.GetValue<DateTime>("ModifiedDate");
                user.Currency = reader.GetValue<string>("Currency");
                user.Specialization = reader.GetValue<string>("Specialization");

                user.PrimaryAddress = reader.GetValue<string>("PrimaryAddress");
                user.SecondaryAddress = reader.GetValue<string>("SecondaryAddress");
                user.PrimaryState = reader.GetValue<string>("PrimaryState");
                user.SecondaryState = reader.GetValue<string>("SecondaryState");
                user.PrimaryCountry = reader.GetValue<string>("PrimaryCountry");
                user.SecondaryCountry = reader.GetValue<string>("SecondaryCountry");
                user.PrimaryCity = reader.GetValue<string>("PrimaryCity");
                user.SecondaryCity = reader.GetValue<string>("SecondaryCity");
                user.PrimaryZip = reader.GetValue<string>("PrimaryZip");
                user.SecondaryZip = reader.GetValue<string>("SecondaryZip");
                user.LandLine = reader.GetValue<string>("Landline");
                user.Mobile = reader.GetValue<string>("Mobile");
                user.Extension = reader.GetValue<string>("Extension");
                user.FaxNumber = reader.GetValue<string>("FaxNumber");
                user.PanNumber = reader.GetValue<string>("PanNumber");
                user.Website = reader.GetValue<string>("Website");

                user.TypeOfMembership = reader.GetValue<int>("TypeOfMembership");
                //usermemberdetails.MembershipTypeName = reader.GetValue<string>("MembershipTypeName");
                //usermemberdetails.Duration = reader.GetValue<int>("Duration");

                user.PaymentOption = reader.GetValue<int>("PaymentOption");
                user.PaymentStatus = reader.GetValue<bool>("PaymentStatus");
                user.MembershipExpiryDate = reader.GetValue<DateTime>("MembershipExpiryDate");


                user.email = reader.GetValue<string>("Email");

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }

            return user;
        }

        /// <summary>
        /// Retrieves 'Trial' membership's details from database
        /// </summary>
        /// <returns></returns>
        public TypeOfMembership GetTrialMembershipDetails()
        {
            TypeOfMembership trial = new TypeOfMembership();

            try
            {
                // Connect to database
                SqlDatabase db = new SqlDatabase(ConnectionString);
                DbCommand command = db.GetStoredProcCommand("GetTrialMembershipDetails");

                // Execute stored proc with reader
                IDataReader reader = db.ExecuteReader(command);

                // Read membership details into 'trial' object
                if (reader.Read())
                {
                    trial.MembershipTypeId = reader.GetValue<int>("MembershipTypeId");
                    trial.Duration = reader.GetValue<int>("Duration");
                }
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.ToString());
            }
            return trial;
        }

        public UserDetails GetSellerDetailsById(string UserId)
        {
            UserDetails obj = new UserDetails();
            SqlDatabase db = new SqlDatabase(ConnectionString);


            Guid userId = new Guid(UserId);

            DbCommand command = db.GetStoredProcCommand("GetSellerDetailsById");


            db.AddInParameter(command, "@UserID", DbType.Guid, userId);
            try
            {
                IDataReader reader = db.ExecuteReader(command);


                if (reader.Read())
                {
                    obj = fillWithEmail(reader);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
                return null;
            }

            return obj;
        }

        private UserDetails fillWithEmail(IDataReader reader)
        {
            UserDetails userDetailsObj = new UserDetails();

            userDetailsObj.CompanyName = reader.GetValue<string>("CompanyName");
            userDetailsObj.ContactName = reader.GetValue<string>("ContactName");
            userDetailsObj.Currency = reader.GetValue<string>("Currency");
            userDetailsObj.UserID = reader.GetValue<Guid>("UserId");
            userDetailsObj.EmailPreference = reader.GetValue<int>("EmailPreference");
            userDetailsObj.UserName = reader.GetValue<String>("UserName");
            userDetailsObj.OwnerName = reader.GetValue<String>("OwnerName");
            userDetailsObj.Specialization = reader.GetValue<String>("Specialization");
            userDetailsObj.PanNumber = reader.GetValue<String>("PanNumber");
            userDetailsObj.CreateDate = reader.GetValue<DateTime>("CreateDate");
            userDetailsObj.ModifiedDate = reader.GetValue<DateTime>("ModifiedDate");
            userDetailsObj.EmailId = reader.GetValue<String>("Email");

            return userDetailsObj;
        }

        /// <summary>
        /// Retrieves types of membership packages from database
        /// </summary>
        /// <returns></returns>
        public List<TypeOfMembership> GetMembershipPackages()
        {
            List<TypeOfMembership> membershipTypes = new List<TypeOfMembership>();

            try
            {
                // Connect to database
                SqlDatabase db = new SqlDatabase(ConnectionString);
                DbCommand command = db.GetStoredProcCommand("GetMembershipPackages");

                // Execute stored proc with reader
                IDataReader membershipReader = (IDataReader)db.ExecuteReader(command);

                // Update list of membership packages
                while (membershipReader.Read())
                    membershipTypes.Add(ReadMembershipDetails(membershipReader));
                membershipReader.Close();
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return membershipTypes;
        }

        /// <summary>
        /// Reads membership details for each row in reader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private TypeOfMembership ReadMembershipDetails(IDataReader reader)
        {
            TypeOfMembership membership = new TypeOfMembership();

            try
            {
                // Get required column values for current row     
                membership.ListingCount = reader.GetValue<int>("ListingCount");
                membership.OfferLimit = reader.GetValue<int>("OfferLimit");
                membership.Duration = reader.GetValue<int>("Duration");
                membership.Amount = reader.GetValue<decimal>("Amount");
                membership.AmountUSD = reader.GetValue<decimal>("AmountUSD");
                membership.MembershipTypeName = reader.GetValue<string>("MembershipTypeName");
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return membership;
        }

        public void createSellerEmailDetails(int sellerid, int buyerid, string txtSubject, string txtContent, DateTime dateTime, int status)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("CreateSellerEmailDetails");
            try
            {
                db.AddInParameter(command, "@SellerId", DbType.Int32, sellerid);
                db.AddInParameter(command, "@BuyerId", DbType.String, buyerid);
                db.AddInParameter(command, "@Subject", DbType.String, txtSubject);
                db.AddInParameter(command, "@Content", DbType.String, txtContent);
                db.AddInParameter(command, "@SentDate", DbType.DateTime, dateTime);
                db.AddInParameter(command, "@Status", DbType.Boolean, status);
                db.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        public void CreateBuyerSentEmailDetails(int buyerid, string sellerid, string txtSubject, string txtContent, DateTime dateTime, int status)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("CreateBuyerEmailDetails");
            //string flag = "";
            try
            {
                db.AddInParameter(command, "@SellerId", DbType.Int32, sellerid);
                db.AddInParameter(command, "@BuyerId", DbType.String, buyerid);
                db.AddInParameter(command, "@Subject", DbType.String, txtSubject);
                db.AddInParameter(command, "@Content", DbType.String, txtContent);
                db.AddInParameter(command, "@SentDate", DbType.DateTime, dateTime);
                db.AddInParameter(command, "@Status", DbType.Boolean, status);
                db.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        public IEnumerable<EmailNotification> GetAllSellersForComponent(string componentName, int quantity)
        {
            List<EmailNotification> lst = new List<EmailNotification>();
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetSellersForComponent");

            db.AddInParameter(command, "@ComponentName", DbType.String, componentName);
            db.AddInParameter(command, "@Quantity", DbType.Int32, quantity);
            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    lst.Add(fill(reader));
                }

                reader.Close();
                lst.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
                return null;
            }

            return lst;
        }

        private EmailNotification fill(IDataReader reader)
        {
            EmailNotification emailNotificationObj = new EmailNotification();

            //emailNotificationObj.NotificationId = reader.GetValue<int>("NotificationId");
            emailNotificationObj.ToUserId = reader.GetValue<Guid>("UserId");
            emailNotificationObj.ComponentName = reader.GetValue<string>("ComponentName");
            emailNotificationObj.CompanyName = reader.GetValue<string>("CompanyName");
            emailNotificationObj.ContactName = reader.GetValue<string>("ContactName");
            emailNotificationObj.Quantity = reader.GetValue<int>("Quantity");
            emailNotificationObj.PhoneNumber = reader.GetValue<string>("Landline");
            emailNotificationObj.Email = reader.GetValue<string>("Email");
            //emailNotificationObj.NotificationStatus = reader.GetBoolean(reader.GetOrdinal("NotificationStatus"));
            emailNotificationObj.EmailPreference = reader.GetValue<int>("EMailPreference");

            return emailNotificationObj;
        }

        public ContactAndMail GetContactEmail(Guid guid)
        {
            ContactAndMail obj = new ContactAndMail();
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetContactByGUId");

            db.AddInParameter(command, "@USERID", DbType.Guid, guid);
            try
            {
                IDataReader reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    obj = fillContactEmail(reader);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
                return null;
            }

            return obj;
        }

        private ContactAndMail fillContactEmail(System.Data.IDataReader reader)
        {
            ContactAndMail obj = new ContactAndMail();

            obj.ContactName = reader.GetValue<string>("ContactName");
            obj.Email = reader.GetValue<string>("Email");

            return obj;
        }

        public UserMembershipDetails GetUserMembershipDetailsById(string UserID)
        {
            UserMembershipDetails obj = new UserMembershipDetails();
            SqlDatabase db = new SqlDatabase(ConnectionString);

            Guid userId = new Guid(UserID);

            DbCommand command = db.GetStoredProcCommand("GetUserMembershipDetailsById");

            db.AddInParameter(command, "@UserID", DbType.Guid, userId);
            try
            {
                IDataReader reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    obj = fillUserMembership(reader);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
                return null;
            }

            return obj;
        }

        private UserMembershipDetails fillUserMembership(System.Data.IDataReader reader)
        {
            UserMembershipDetails UserMembershipObj = new UserMembershipDetails();

            UserMembershipObj.UserId = reader.GetValue<Guid>("UserId");
            UserMembershipObj.TypeOfMembership = reader.GetValue<int>("TypeOfMembership");
            UserMembershipObj.MembershipExpiryDate = reader.GetValue<DateTime>("MembershipExpiryDate");
            UserMembershipObj.PaymentOption = reader.GetValue<int>("PaymentOption");
            UserMembershipObj.PaymentStatus = reader.GetValue<bool>("PaymentStatus");
            UserMembershipObj.OfflineMembership = reader.GetValue<int>("OfflineMembership");

            return UserMembershipObj;
        }

        public void UpdateUserMembershipDetails(UserMembershipDetails obj)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateUserMembershipbyUserId");

            try
            {
                db.AddInParameter(command, "@UserId", DbType.Guid, obj.UserId);
                db.AddInParameter(command, "@TypeOfMembership", DbType.Int32, obj.TypeOfMembership);
                db.AddInParameter(command, "@PaymentStatus", DbType.Boolean, obj.PaymentStatus);
                db.AddInParameter(command, "@PaymentOption", DbType.Int32, obj.PaymentOption);
                db.AddInParameter(command, "@OfflineMembership", DbType.Int32, obj.OfflineMembership);
                db.AddInParameter(command, "@MembershipExpiryDate", DbType.DateTime, obj.MembershipExpiryDate);

                db.ExecuteNonQuery(command);

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }
    }
}
