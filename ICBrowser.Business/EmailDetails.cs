using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Security;
using System.Web.Security;
using System.IO;
using ICBrowser.Business;
using System.Collections.Generic;
using ICBrowser.Common;
using ICBrowser.DAL;

namespace ICBrowser.Business
{
    public class EmailDetails
    {
        //to retrieve login user message details
        public List<EmailDetailsForUser> getLoginUsersEmailDetails(MembershipUser touserid, string selectionType)
        {
            List<EmailDetailsForUser> lst = new List<EmailDetailsForUser>();
            EmailDetailRepository emaildetrepo = new EmailDetailRepository();
            try
            {
                lst = emaildetrepo.getEmailDetailLoginUsers(Convert.ToString(touserid.ProviderUserKey), selectionType);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lst;
        }

        //to retrieve user message details history
        public EmailDetailsForUser getUserDetailsOnMessageId(Guid userlogin, int MessageId, int logintype)
        {

            EmailDetailRepository emaildetrepo = new EmailDetailRepository();
            EmailDetailsForUser lst = new EmailDetailsForUser();
            try
            {
                lst = emaildetrepo.GetUserNameForEmailDisplayOnUserId(userlogin, MessageId, logintype);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lst;
        }
        //to retrieve user message details history on sent email
        public EmailDetailsForUser getUserDetailsOnMessageIdForReadingMails(Guid userlogin, int MessageId, int logintype)
        {
            EmailDetailRepository emaildetrepo = new EmailDetailRepository();
            BuyerCompanyDetailsRepository bcdr = new BuyerCompanyDetailsRepository();
            EmailDetailsForUser UserEmailDetails = new EmailDetailsForUser();
            try
            {
                UserEmailDetails = emaildetrepo.GetUserNameForEmailDisplayOnUserIdForReadingMails(userlogin, MessageId, logintype);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return UserEmailDetails;
        }

        //to delete message details
        public void OnDeleteMailsOnMessageId(bool isInboxDeleted, int MessageId, string Deletetype)
        {

            EmailDetailRepository emaildetrepo = new EmailDetailRepository();
            try
            {
                emaildetrepo.OnDeleteMailOnMessageId(isInboxDeleted, MessageId, Deletetype);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        //to save message details
        public int SaveMessageDetails(Guid fromuserid, Guid touserid, string subject, string body, DateTime currentdatetime, int status, Boolean isInboxDelete, Boolean isSentitemsDelete, int messageid, string file)
        {
            int returnmessageid = 0;
            EmailDetailRepository emaildetrepo = new EmailDetailRepository();
            try
            {
                
                returnmessageid = emaildetrepo.SaveMessageDetailsForUsers(fromuserid, touserid, subject, body, currentdatetime, status, isInboxDelete, isSentitemsDelete, messageid, file);
                
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return returnmessageid;
        }
        // to set the status in table MessageDetails
        public void SetUpdateStatusForSelectedMessageId(int MessageId)
        {

            EmailDetailRepository emaildetrepo = new EmailDetailRepository();
            try
            {
                emaildetrepo.SetUpdateStatusForSelectedMessageId(MessageId);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        //to save message details
        public int SaveMessageDetailsFromUsers(Guid fromuserid, Guid touserid, string subject, string body, DateTime currentdatetime, int status, Boolean isInboxDelete, Boolean isSentitemsDelete, string fileName)
        {
            int Messageid = 0;
            EmailDetailRepository emaildetrepo = new EmailDetailRepository();
            try
            {
                Messageid = emaildetrepo.SaveMessageDetailsForUsersFromBuyer(fromuserid, touserid, subject, body, currentdatetime, status, isInboxDelete, isSentitemsDelete, fileName);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

            return Messageid;
        }

        //To retrieve Advertiser Data for email notification
        public List<EmailNotificationAdvertiser> getUserDetailOnAdvertisementExpiry()
        {
            List<EmailNotificationAdvertiser> AdvertiserDetails = new List<EmailNotificationAdvertiser>();
            EmailDetailRepository emaildetrepo = new EmailDetailRepository();
            try
            {
                AdvertiserDetails = emaildetrepo.getEmailDetailOnAdvertisementExpiry();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return AdvertiserDetails;
        }

        //To retrieve Mebership Data for email notification
        public List<EmailNotificationMembershipDetails> getUserDetailOnMembershipExpiry()
        {
            List<EmailNotificationMembershipDetails> MembershipDetails = new List<EmailNotificationMembershipDetails>();
            EmailDetailRepository emaildetrepo = new EmailDetailRepository();
            try
            {
                MembershipDetails = emaildetrepo.getUserDetailOnMembershipExpiry();
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
        //    List<EmailNotificationMembershipDetails> UserDetails = new List<EmailNotificationMembershipDetails>();
        //    EmailDetailRepository emaildetrepo = new EmailDetailRepository();
        //    try
        //    {
        //        UserDetails = emaildetrepo.getUserDetailForUpdateNotification();
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogError(ex.ToString());
        //    }
        //    return UserDetails;
        //}



        //To Delete Record On Membership Expiry
        public void DeleteRecordOnMembershipExpiry()
        {
            EmailDetailRepository emaildetrepo = new EmailDetailRepository();
            try
            {
                emaildetrepo.DeleteRecordOnMembershipExpiry();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
    }
}
