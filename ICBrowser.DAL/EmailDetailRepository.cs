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
    public class EmailDetailRepository : Repository
    {
        //to retrieve login user message details
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
                        ToUserId = reader.GetValue<Guid>("ToUserId"),
                        AttachedFile = reader.GetValue<string>("AttachedFile")
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

        //To retrieve Advertiser Data for email notification
        public List<EmailNotificationAdvertiser> getEmailDetailOnAdvertisementExpiry()
        {
            List<EmailNotificationAdvertiser> AdvertiserDetails = new List<EmailNotificationAdvertiser>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetEmailNotificationDataForAdvertiser");
            try
            {
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    AdvertiserDetails.Add(new EmailNotificationAdvertiser
                    {
                        EndDate = reader.GetValue<DateTime>("EndDate"),
                        Email = reader.GetValue<string>("Email")
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return AdvertiserDetails;
        }


        //To retrieve Member Data for email notification
        public List<EmailNotificationMembershipDetails> getUserDetailOnMembershipExpiry()
        {
            List<EmailNotificationMembershipDetails> MembershipDetails = new List<EmailNotificationMembershipDetails>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetEmailNotificationDataoFMembershipDetails");
            try
            {
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    MembershipDetails.Add(new EmailNotificationMembershipDetails
                    {
                        UserName = reader.GetValue<string>("UserName"),
                        MembershipExpiryDate = reader.GetValue<DateTime>("MembershipExpiryDate"),
                        Email=reader.GetValue<string>("Email")
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return MembershipDetails;
        }


        //To retrieve Member Data for Update-notification email 
        //public List<EmailNotificationMembershipDetails> getUserDetailForUpdateNotification()
        //{
        //    List<EmailNotificationMembershipDetails> MembershipDetails = new List<EmailNotificationMembershipDetails>();
        //    SqlDatabase db = new SqlDatabase(ConnectionString);
        //    DbCommand command = db.GetStoredProcCommand("GetAllPaidUsrForUpdateNotification");
        //    try
        //    {
        //        IDataReader reader = db.ExecuteReader(command);
        //        while (reader.Read())
        //        {
        //            MembershipDetails.Add(new EmailNotificationMembershipDetails
        //            {
        //                UserName = reader.GetValue<string>("UserName"),                        
        //                Email = reader.GetValue<string>("Email")
        //            });
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogError(ex.ToString());
        //    }
        //    return MembershipDetails;
        //}



        //To Delete Record On MembershipExpiry
        public void DeleteRecordOnMembershipExpiry()
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("deleteSavedRecordsOnMembershipExpiry");
            try
            {
                db.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        //to retrieve user message details history
        public EmailDetailsForUser GetUserNameForEmailDisplayOnUserId(Guid userlogin, int MessageId, int logintype)
        {
            EmailDetailsForUser lstdata = new EmailDetailsForUser();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetUserDetailsOnMessageId");
            try
            {
                db.AddInParameter(command, "@UserLoginID", DbType.Guid, userlogin);
                db.AddInParameter(command, "@MessageId", DbType.Int32, MessageId);
                db.AddInParameter(command, "@loginType", DbType.Int32, logintype);
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {

                    lstdata.FromUserId = reader.GetValue<Guid>("FROMUSERID");
                    lstdata.fromEmailAddress = reader.GetValue<string>("FROMEMAILID");
                    lstdata.FromUserName = reader.GetValue<string>("FROMCONTACTNAME");
                    lstdata.ToUserId = reader.GetValue<Guid>("TOUSERID");
                    lstdata.toEmailAddress = reader.GetValue<string>("TOEMAILID");
                    lstdata.ToUserName = reader.GetValue<string>("TOCONTACTNAME");
                    lstdata.MessageDescription = reader.GetValue<string>("MESSAGE");
                    lstdata.Subject = reader.GetValue<string>("SUBJECT");
                    lstdata.SentDate = reader.GetValue<DateTime>("SENTDATE");
                    lstdata.Status = reader.GetValue<Boolean>("STATUS");
                    lstdata.ParentId = reader.GetValue<int>("ParentId");
                    lstdata.AttachedFile = reader.GetValue<string>("AttachedFile");


                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

            return lstdata;
        }

        //to retrieve user message details history on sent email
        public EmailDetailsForUser GetUserNameForEmailDisplayOnUserIdForReadingMails(Guid userlogin, int MessageId, int logintype)
        {
            EmailDetailsForUser UserEmailDetails = new EmailDetailsForUser();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetUserDetailsOnMessageIdForReadingMails");
            try
            {
                db.AddInParameter(command, "@UserLoginID", DbType.Guid, userlogin);
                db.AddInParameter(command, "@MessageId", DbType.Int32, MessageId);
                db.AddInParameter(command, "@loginType", DbType.Int32, logintype);
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {

                    UserEmailDetails.FromUserId = reader.GetValue<Guid>("FROMUSERID");
                    UserEmailDetails.fromEmailAddress = reader.GetValue<string>("FROMEMAILID");
                    UserEmailDetails.FromUserName = reader.GetValue<string>("FROMCONTACTNAME");
                    UserEmailDetails.ToUserId = reader.GetValue<Guid>("TOUSERID");
                    UserEmailDetails.toEmailAddress = reader.GetValue<string>("TOEMAILID");
                    UserEmailDetails.ToUserName = reader.GetValue<string>("TOCONTACTNAME");
                    UserEmailDetails.MessageDescription = reader.GetValue<string>("MESSAGE");
                    UserEmailDetails.Subject = reader.GetValue<string>("SUBJECT");
                    UserEmailDetails.SentDate = reader.GetValue<DateTime>("SENTDATE");
                    UserEmailDetails.Status = reader.GetValue<Boolean>("STATUS");
                    UserEmailDetails.ParentId = reader.GetValue<int>("ParentId");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return UserEmailDetails;
        }

        //to delete message details
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

        //to save mesessage details
        public int SaveMessageDetailsForUsers(Guid fromuserid, Guid touserid, string subject, string body, DateTime currentdatetime, int status, Boolean isInboxDelete, Boolean isSentitemsDelete, int messageid,string file)
        {
            int MessageId = 0;
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
                db.AddInParameter(command, "@AttachedFile", DbType.String, file);
                db.AddInParameter(command, "@IsInboxDelete", DbType.Boolean, isInboxDelete);
                db.AddInParameter(command, "@IsSentItemDelete", DbType.Boolean, isSentitemsDelete);
                db.AddOutParameter(command, "@MessageId", DbType.Int32, 0);
                IDataReader reader = db.ExecuteReader(command);
                MessageId = (int)command.Parameters["@MessageId"].Value;

               
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

            return MessageId;
        }
        // to set the status in table MessageDetails
        public void SetUpdateStatusForSelectedMessageId(int MessageId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("SetStausUpdateForSelectedMessageId");
            try
            {
                db.AddInParameter(command, "@messageid", DbType.Int32, MessageId);
                db.ExecuteScalar(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        //to save message details
        public int SaveMessageDetailsForUsersFromBuyer(Guid fromuserid, Guid touserid, string subject, string body, DateTime currentdatetime, int status, Boolean isInboxDelete, Boolean isSentitemsDelete, string fileName)
        {
            int MessageId = 0;
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
                db.AddInParameter(command, "@AttachedFile", DbType.String, fileName);
                db.AddOutParameter(command, "@MessageId", DbType.Int32, 0);
                IDataReader reader = db.ExecuteReader(command);

                MessageId = (int)command.Parameters["@MessageId"].Value;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return MessageId;
        }

    }
}
