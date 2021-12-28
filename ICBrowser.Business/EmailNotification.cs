using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using ICBrowser.DAL;

namespace ICBrowser.Business
{
    public class EmailNotifications
    {
        public IEnumerable<Component> LatestComponents()
        {
            ComponentRepository objEmailNotificationHelper = new ComponentRepository();
            return objEmailNotificationHelper.GetLatestComponentByHour();
        }

        public IEnumerable<EmailNotification> GetAllBuyersForComponent(string componentName, int quantity)
        {
            BuyersRepository objSellerHelper = new BuyersRepository();
            return objSellerHelper.GetAllBuyersForComponent(componentName, quantity);
        }

        public bool AddEmailNotification(EmailNotification obj)
        {
            EmailNotificationRepository emailNotificationHelper = new EmailNotificationRepository();
            return emailNotificationHelper.Create(obj);
        }

        public IEnumerable<BuyersRequirements> LatestRequirements()
        {
            BuyersRequirmentsRepository objEmailNotificationHelper = new BuyersRequirmentsRepository();
            return objEmailNotificationHelper.GetLatestRequirementsByHour();
        }

        public IEnumerable<EmailNotification> GetAllSellersForComponent(string componentName, int quantity)
        {
            SellersRepository objSellerHelper = new SellersRepository();
            return objSellerHelper.GetAllSellersForComponent(componentName, quantity);
        }

        public void UpdateRequirementNotificationStatus(BuyersRequirements obj)
        {
            BuyersRequirmentsRepository objEmailNotificationHelper = new BuyersRequirmentsRepository();
            objEmailNotificationHelper.UpdateNotificationSent(obj);
        }

        public void UpdateComponentNotificationStatus(Component objLatestComp)
        {
            ComponentRepository objEmailNotificationHelper = new ComponentRepository();
            objEmailNotificationHelper.UpdateNotificationSent(objLatestComp);
        }

        public IEnumerable<EmailNotification> GetNotificationEmailsForSeller(int emailPreference)
        {
            EmailNotificationRepository emailNotificationHelper = new EmailNotificationRepository();
            return emailNotificationHelper.GetNotificationEmailDataForSeller(emailPreference);
        }

        public IEnumerable<EmailNotification> GetNotificationEmailsForBuyer(int emailPreference)
        {
            EmailNotificationRepository emailNotificationHelper = new EmailNotificationRepository();
            return emailNotificationHelper.GetNotificationEmailDataForBuyer(emailPreference);
        }

        public ContactAndMail GetContactNameEmailId(Guid guid)
        {
            SellersRepository objSellerHelper = new SellersRepository();
            return objSellerHelper.GetContactEmail(guid);
        }

        public void UpdateEmailSentStatus(string sentNotifications)
        {
            EmailNotificationRepository emailNotificationHelper = new EmailNotificationRepository();
            emailNotificationHelper.UpdateEmailNotificationSentStatus(sentNotifications);
        }


        #region "NewEmailNotificationForUserOnMasterPage"
        public int getNewEmailNotificationForUser(Guid UserId)
        {
            int unreadMailCounts = 0;
            EmailNotificationRepository newEmailNotify = new EmailNotificationRepository();
            try
            {
                unreadMailCounts = newEmailNotify.getNewEmailNotificationForUser(UserId);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return unreadMailCounts;
        }
        #endregion

        public IEnumerable<Component> LatestOffers()
        {
            UserOfferDataRepository objUserOfferData = new UserOfferDataRepository();
            return objUserOfferData.GetLatestOfferByHour();
        }

        public void UpdateOfferNotificationStatus(Component objLatestOffer)
        {
            UserOfferDataRepository objUserOfferData = new UserOfferDataRepository();
            objUserOfferData.UpdateNotificationSent(objLatestOffer);
        }

        public IEnumerable<EmailNotification> GetAllBuyersForOffer(string componentName, int quantity, Guid userId)
        {
            BuyersRepository objSellerHelper = new BuyersRepository();
            return objSellerHelper.GetAllBuyersForOffer(componentName, quantity, userId);
        }
    }
}
