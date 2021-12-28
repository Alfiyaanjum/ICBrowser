using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using ICBrowser.Common;
using System.Data.SqlClient;

namespace ICBrowser.DAL
{
    public class EmailNotificationRepository : Repository
    {
        public bool Create(EmailNotification obj)
        {

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("InsertEmailNotification");

            db.AddOutParameter(command, "@NotificationId", DbType.Int32, 0);
            db.AddInParameter(command, "@ToUserId", DbType.Guid, obj.ToUserId);
            db.AddInParameter(command, "@ComponentName", DbType.String, obj.ComponentName);
            db.AddInParameter(command, "@CompanyName", DbType.String, obj.CompanyName);
            db.AddInParameter(command, "@ContactName", DbType.String, obj.ContactName);
            db.AddInParameter(command, "@Quantity", DbType.Int32, obj.Quantity);
            db.AddInParameter(command, "@PhoneNumber", DbType.String, obj.PhoneNumber);
            db.AddInParameter(command, "@Email", DbType.String, obj.Email);
            db.AddInParameter(command, "@NotificationStatus", DbType.Boolean, obj.NotificationStatus);
            db.AddInParameter(command, "@IsSeller", DbType.Boolean, obj.IsSeller);
            db.AddInParameter(command, "@EmailPreference", DbType.Int32, obj.EmailPreference);
            db.AddInParameter(command, "@IsOffer", DbType.Boolean, obj.IsOffer);
            try
            {
                db.ExecuteNonQuery(command);

                obj.NotificationId = (int)command.Parameters["@NotificationId"].Value;

                return true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                return false;
            }
        }

        //public List<Guid> GetUserIdsForEmailNotification()
        //{
        //    List<Guid> lst = new List<Guid>();
        //    return lst;
        //}

        public IEnumerable<EmailNotification> GetNotificationEmailDataForSeller(int emailPreference)
        {
            List<EmailNotification> lst = new List<EmailNotification>();

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetEmailNotificationDataForSellerByPreference");
            db.AddInParameter(command, "@EmailPreference", DbType.Int32, emailPreference);
            try
            {
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    lst.Add(Fill(reader));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                throw;
            }
            return lst.AsEnumerable<EmailNotification>();
        }

        public IEnumerable<EmailNotification> GetNotificationEmailDataForBuyer(int emailPreference)
        {
            List<EmailNotification> lst = new List<EmailNotification>();

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetEmailNotificationDataForBuyerByPreference");
            db.AddInParameter(command, "@EmailPreference", DbType.Int32, emailPreference);
            try
            {
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    lst.Add(Fill(reader));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                throw;
            }
            return lst.AsEnumerable<EmailNotification>();
        }

        private EmailNotification Fill(IDataReader reader)
        {
            EmailNotification emailNotificationObj = new EmailNotification();

            emailNotificationObj.NotificationId = reader.GetValue<int>("NotificationId");
            emailNotificationObj.ToUserId = reader.GetValue<Guid>("ToUserId");
            emailNotificationObj.ComponentName = reader.GetValue<string>("ComponentName");
            emailNotificationObj.CompanyName = reader.GetValue<string>("CompanyName");
            emailNotificationObj.ContactName = reader.GetValue<string>("ContactName");
            emailNotificationObj.Quantity = reader.GetValue<int>("Quantity");
            emailNotificationObj.PhoneNumber = reader.GetValue<string>("PhoneNumber");
            emailNotificationObj.Email = reader.GetValue<string>("Email");
            emailNotificationObj.NotificationStatus = reader.GetBoolean(reader.GetOrdinal("NotificationStatus"));
            emailNotificationObj.EmailPreference = reader.GetValue<int>("EMailPreference");
            emailNotificationObj.IsSeller = reader.GetBoolean(reader.GetOrdinal("IsSeller"));
            emailNotificationObj.IsOffer = reader.GetBoolean(reader.GetOrdinal("IsOffer"));

            return emailNotificationObj;
        }

        public void UpdateEmailNotificationSentStatus(string sentNotificationsId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateEmailNotificationStatusById");

            try
            {
                db.AddInParameter(command, "@NotificationIds", DbType.String, sentNotificationsId);

                db.ExecuteNonQuery(command);

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                command.Dispose();
            }
        }

        public int getNewEmailNotificationForUser(Guid userId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("getNewEmailNotificationForUser");
            int unreadMailCounts = 0;
            try
            {
                db.AddInParameter(command, "@userId", DbType.Guid, userId);

                unreadMailCounts = Convert.ToInt32(db.ExecuteScalar(command));

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                command.Dispose();
            }
            return unreadMailCounts;
        }
    }
}
