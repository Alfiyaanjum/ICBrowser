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
   public class EmailDetailsRepository:Repository
    {

        public void SaveMessageDetailsForUsers(Guid fromuserid, Guid touserid, string subject, string body, DateTime currentdatetime, int status, Boolean isInboxDelete, Boolean isSentitemsDelete, int messageid)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("SaveMessageDetailsForUsers");
            try
            {
                db.AddInParameter(command, "@ParentId", DbType.Int32, messageid);
                db.AddInParameter(command, "@fromUserId", DbType.Guid, fromuserid);
                db.AddInParameter(command, "@toUserId", DbType.Guid, touserid);
                db.AddInParameter(command, "@subject", DbType.String, subject);
                db.AddInParameter(command, "@messageDescription", DbType.String, body);
                db.AddInParameter(command, "@sentDate", DbType.DateTime, currentdatetime);
                db.AddInParameter(command, "@status", DbType.Int32, status);
                db.AddInParameter(command, "@IsInboxDelete", DbType.Boolean, isInboxDelete);
                db.AddInParameter(command, "@IsSentItemDelete", DbType.Boolean, isSentitemsDelete);
                IDataReader reader = db.ExecuteReader(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        public void SaveMessageDetailsForUsersFromBuyer(Guid fromuserid, Guid touserid, string subject, string body, DateTime currentdatetime, int status, Boolean isInboxDelete, Boolean isSentitemsDelete)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("SaveMessageDetailsForUsers");
            try
            {
                db.AddInParameter(command, "@ParentId", DbType.Int32, null);
                db.AddInParameter(command, "@fromUserId", DbType.Guid, fromuserid);
                db.AddInParameter(command, "@toUserId", DbType.Guid, touserid);
                db.AddInParameter(command, "@subject", DbType.String, subject);
                db.AddInParameter(command, "@messageDescription", DbType.String, body);
                db.AddInParameter(command, "@sentDate", DbType.DateTime, currentdatetime);
                db.AddInParameter(command, "@status", DbType.Int32, status);
                db.AddInParameter(command, "@IsInboxDelete", DbType.Boolean, isInboxDelete);
                db.AddInParameter(command, "@IsSentItemDelete", DbType.Boolean, isSentitemsDelete);
                IDataReader reader = db.ExecuteReader(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
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

        public List<EmailDetailsForUser> getEmailDetailLoginUsers(string touserid, string selectionType)
        {
            List<EmailDetailsForUser> lstUsersEmailDetails = new List<EmailDetailsForUser>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetEmailDetailsForUsers");
            Guid ToUserId = new Guid(touserid);
            try
            {
                db.AddInParameter(command, "@LogInUserId", DbType.Guid, ToUserId);
                db.AddInParameter(command, "@SelectionType", DbType.String, selectionType);
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
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lstUsersEmailDetails;
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
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lstUsersEmailDetails;
        }

        public void OnDeleteMailOnMessageId(bool isInboxDeleted, int MessageId, string deletetype)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("DeleteMessagDetailseOnMessageId");
            try
            {
                db.AddInParameter(command, "@IsDeleted", DbType.Boolean, isInboxDeleted);
                db.AddInParameter(command, "@MessageId", DbType.Int32, MessageId);
                db.AddInParameter(command, "@DeleteType", DbType.String, deletetype);
                db.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
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
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lstUsersEmailDetails;
        }
     
        public List<EmailDetailsForUser> GetUserNameForEmailDisplayOnUserId(Guid guid, string logintype)
        {
            List<EmailDetailsForUser> lstUsersEmailDetails = new List<EmailDetailsForUser>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetUserNameDetailsForEmailDisplayOnUserId");
            try
            {
                db.AddInParameter(command, "@UserLogin", DbType.Guid, guid);
                db.AddInParameter(command, "@LoginType", DbType.String, logintype);
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
                        ToUserName = reader.GetValue<string>("ToUserName"),
                        FromUserName = reader.GetValue<string>("FromUserName"),
                        toEmailAddress = reader.GetValue<string>("toEmailAddress"),
                        fromEmailAddress = reader.GetValue<string>("fromEmailAddress"),
                    });
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lstUsersEmailDetails;
        }

    }
}
