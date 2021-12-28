using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Collections;
using System.Net;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;

namespace ICBrowser.NotificationService
{
    public partial class NotificationService : ServiceBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationService"/> class.
        /// </summary>
        public NotificationService()
        {
            InitializeComponent();
        }

        private Timer notificationTimer = null;
        private Timer emailTimer = null;
        private Timer advertisementEmailTimer = null;
        private Timer MembershipEmailTimer = null;
        private Timer DeleteRecordOnMembershipExpiry = null;
        private Timer exchangeRateUpdater = null;
        //private Timer updateNotificationEmail = null;

        /// <summary>
        /// When implemented in a derived class, executes when a Start command is sent to the service by the Service Control Manager (SCM) or when the operating system starts (for a service that starts automatically). Specifies actions to take when the service starts.
        /// </summary>
        /// <param name="args">Data passed by the start command.</param>
        protected override void OnStart(string[] args)
        {
            System.Threading.Thread.Sleep(20000);

            notificationTimer = new System.Timers.Timer(TimeSpan.FromMinutes(60).TotalMilliseconds);
            notificationTimer.Enabled = true;
            notificationTimer.Elapsed += new System.Timers.ElapsedEventHandler(notificationTimer_Elapsed);

            int e = ICBrowser.NotificationService.Properties.Settings.Default.RefreshComponentTime;
            int notificationInterval = ICBrowser.NotificationService.Properties.Settings.Default.NotificationInterval;
            int dataInsertInterval = ICBrowser.NotificationService.Properties.Settings.Default.DataInsertInterval;
            emailTimer = new Timer(dataInsertInterval); // 14400000
            emailTimer.Enabled = true;
            emailTimer.Elapsed += new ElapsedEventHandler(emailTimer_Elapsed);

            advertisementEmailTimer = new Timer();
            advertisementEmailTimer.Interval = notificationInterval; // 86400000
            advertisementEmailTimer.Enabled = true;
            advertisementEmailTimer.Elapsed += new ElapsedEventHandler(advertisementEmailTimer_Elapsed);

            MembershipEmailTimer = new Timer();
            MembershipEmailTimer.Interval = notificationInterval; //86400000
            MembershipEmailTimer.Enabled = true;
            MembershipEmailTimer.Elapsed += new ElapsedEventHandler(MembershipEmailTimer_Elapsed);

            DeleteRecordOnMembershipExpiry = new Timer();
            DeleteRecordOnMembershipExpiry.Interval = notificationInterval; //86400000
            DeleteRecordOnMembershipExpiry.Enabled = true;
            DeleteRecordOnMembershipExpiry.Elapsed += new ElapsedEventHandler(DeleteRecordOnMembershipExpiry_Elapsed);

            //exchangeRateUpdater = new Timer();
            //exchangeRateUpdater.Interval = TimeSpan.FromMinutes(10).TotalMilliseconds;
            //exchangeRateUpdater.Enabled = true;
            //exchangeRateUpdater.Elapsed += new ElapsedEventHandler(exchangeRateUpdater_Elapsed);

            //updateNotificationEmail = new Timer();
            //updateNotificationEmail.Interval = TimeSpan.FromHours(24).Hours;
            //updateNotificationEmail.Enabled = true;
            //updateNotificationEmail.Elapsed += new ElapsedEventHandler(updateNotificationEmail_Elapsed);
        }

        /// <summary>
        /// Event for elapsing of Exchange Rate Updater Timer
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        //void exchangeRateUpdater_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    exchangeRateUpdater.Enabled = false;

        //    DataSet dsCurrencies = new DataSet();

        //    string dir = Directory.GetCurrentDirectory();
        //    string xmlFile = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + ICBrowser.NotificationService.Properties.Settings.Default.ForeignCurrenciesXmlPath + ICBrowser.NotificationService.Properties.Settings.Default.ForeignCurrenciesXmlFileName;

        //    dsCurrencies.ReadXml(xmlFile);

        //    // Get currency data from XML
        //    Dictionary<string, decimal> dictInitialCurrExRate = new Dictionary<string, decimal>();
        //    foreach (DataRow dr in dsCurrencies.Tables[0].Rows)
        //        dictInitialCurrExRate.Add(dr["CurrencyCode"].ToString(), Convert.ToDecimal(dr["ExchangeRate"]));

        //    Dictionary<string, decimal> dictFinalCurrExRate = new Dictionary<string, decimal>();

        //    // Get current exchange rate from webservice by providing currency code read from XML
        //    foreach (KeyValuePair<string, decimal> forCurrency in dictInitialCurrExRate)
        //    {
        //        try
        //        {
        //            string xmlResult = null;
        //            string url = "http://www.webservicex.net/CurrencyConvertor.asmx/ConversionRate?FromCurrency=" + forCurrency.Key + "&ToCurrency=INR";
        //            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //            StreamReader resStream = new StreamReader(response.GetResponseStream());
        //            XmlDocument doc = new XmlDocument();
        //            xmlResult = resStream.ReadToEnd();
        //            doc.LoadXml(xmlResult);
        //            // Check if result returned by webservice is valid or not, otherwise set existing exchange rate
        //            if (!doc.GetElementsByTagName("double").Item(0).InnerText.Contains("-1"))
        //                dictFinalCurrExRate.Add(forCurrency.Key, Convert.ToDecimal(doc.GetElementsByTagName("double").Item(0).InnerText));
        //            else
        //                dictFinalCurrExRate.Add(forCurrency.Key, forCurrency.Value);
        //        }
        //        catch (Exception ex)
        //        {
        //            IClogger.LogMessage(ex.Message);
        //        }
        //    }

        //    try
        //    {
        //        // Update the database with updated exchange rates
        //        SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ICBrowserConnectionString"].ConnectionString);
        //        db.Open();
        //        foreach (KeyValuePair<string, decimal> kvpFinalRate in dictFinalCurrExRate)
        //        {
        //            SqlCommand cmd = new SqlCommand("UpdateExchangeRate", db);

        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlParameter paramCurrency = new SqlParameter("@ForeignCurrency", SqlDbType.VarChar);
        //            paramCurrency.Direction = ParameterDirection.Input;
        //            paramCurrency.Value = kvpFinalRate.Key;
        //            cmd.Parameters.Add(paramCurrency);

        //            SqlParameter paramExRate = new SqlParameter("@ExchangeRate", SqlDbType.Decimal);
        //            paramExRate.Direction = ParameterDirection.Input;
        //            paramExRate.Value = kvpFinalRate.Value;
        //            cmd.Parameters.Add(paramExRate);

        //            cmd.ExecuteNonQuery();
        //        }
        //        db.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogMessage(ex.Message);
        //    }

        //    // Update dataset with updated exchange rates
        //    foreach (DataRow dr in dsCurrencies.Tables[0].Rows)
        //    {
        //        KeyValuePair<string, decimal> currency = dictFinalCurrExRate.First(aa => aa.Key == dr["CurrencyCode"].ToString());
        //        dr["ExchangeRate"] = currency.Value;
        //        dr.AcceptChanges();
        //    }
        //    dsCurrencies.AcceptChanges();

        //    // Update the XML with updated exchange rates
        //    dsCurrencies.WriteXml(xmlFile);

        //    // Set timer interval to 2 hours, if not set already
        //    //if (exchangeRateUpdater.Interval != TimeSpan.FromMinutes(ICBrowser.NotificationService.Properties.Settings.Default.ExchangeRateUpdateInterval).TotalMilliseconds)
        //    //    exchangeRateUpdater.Interval = TimeSpan.FromMinutes(ICBrowser.NotificationService.Properties.Settings.Default.ExchangeRateUpdateInterval).TotalMilliseconds;
        //    exchangeRateUpdater.Enabled = true;
        //}

        void DeleteRecordOnMembershipExpiry_Elapsed(object sender, ElapsedEventArgs e)
        {
            DeleteRecordOnMembershipExpiry.Enabled = false;
            try
            {
                ServiceDeleteRecordOnMembershipExpiryMethod();

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            DeleteRecordOnMembershipExpiry.Enabled = true;
        }

        /// <summary>
        /// Handles the Elapsed event of the MembershipEmailTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        void MembershipEmailTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

            MembershipEmailTimer.Enabled = false;
            try
            {
                ServiceMembershipEmailMethod();

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            MembershipEmailTimer.Enabled = true;
        }

        //void updateNotificationEmail_Elapsed(object sender, ElapsedEventArgs e)
        //{

        //    updateNotificationEmail.Enabled = false;
        //    try
        //    {
        //        ServiceupdateNotificationEmailMethod();

        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogError(ex.ToString());
        //    }
        //    updateNotificationEmail.Enabled = true;
        //}

        /// <summary>
        /// Handles the Elapsed event of the advertisementEmailTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        void advertisementEmailTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            advertisementEmailTimer.Enabled = false;
            try
            {
                ServiceAdvertiseEmailMethod();

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            advertisementEmailTimer.Enabled = true;
        }

        /// <summary>
        /// Handles the Elapsed event of the emailTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        void emailTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            emailTimer.Enabled = false;
            try
            {
                SendNotificationEmail();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            emailTimer.Enabled = true;
        }

        /// <summary>
        /// Sends the notification email.
        /// </summary>
        private void SendNotificationEmail()
        {
            try
            {
                int hour = System.DateTime.Now.Hour;
                sendNotificationMail(1);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Elapsed event of the notificationTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        void notificationTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            notificationTimer.Enabled = false;
            try
            {
                ComponentNotification();

                OfferNotification();

                RequirementNotification();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

            notificationTimer.Enabled = true;
        }

        /// <summary>
        /// Offers the notification.
        /// </summary>
        private void OfferNotification()
        {
            EmailNotifications objEmailNotification = new EmailNotifications();
            IEnumerable<ICBrowser.Common.Component> lstLatestOffer = objEmailNotification.LatestOffers();

            foreach (ICBrowser.Common.Component objLatestOffer in lstLatestOffer)
            {
                IEnumerable<EmailNotification> emailNotificationList = objEmailNotification.GetAllBuyersForOffer(objLatestOffer.ComponentName, objLatestOffer.Quantity, objLatestOffer.UserId);
                if (emailNotificationList.Count() > 0)
                {
                    foreach (EmailNotification obj in emailNotificationList)
                    {
                        obj.NotificationStatus = false;
                        obj.IsSeller = false;
                        obj.IsOffer = true;
                        objEmailNotification.AddEmailNotification(obj);
                    }
                    objLatestOffer.NotificationSent = true;
                    objEmailNotification.UpdateOfferNotificationStatus(objLatestOffer);
                }
            }
        }

        /// <summary>
        /// Notifications for Requirements.
        /// </summary>
        private void RequirementNotification()
        {
            EmailNotifications objEmailNotification = new EmailNotifications();
            IEnumerable<BuyersRequirements> lstLatestReq = objEmailNotification.LatestRequirements();

            foreach (BuyersRequirements objLatestReq in lstLatestReq)
            {
                IEnumerable<EmailNotification> emailNotificationList = objEmailNotification.GetAllSellersForComponent(objLatestReq.ComponentName, objLatestReq.Quantity);
                if (emailNotificationList.Count() > 0)
                {
                    foreach (EmailNotification obj in emailNotificationList)
                    {
                        obj.NotificationStatus = false;
                        obj.IsSeller = true;
                        obj.IsOffer = false;
                        objEmailNotification.AddEmailNotification(obj);
                    }
                    objLatestReq.NotificationSent = true;
                    objEmailNotification.UpdateRequirementNotificationStatus(objLatestReq);
                }
            }
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service stops running.
        /// </summary>
        protected override void OnStop()
        {

        }

        /// <summary>
        ///Notification for Components.
        /// </summary>
        private void ComponentNotification()
        {
            EmailNotifications objEmailNotification = new EmailNotifications();
            IEnumerable<ICBrowser.Common.Component> lstLatestComp = objEmailNotification.LatestComponents();

            foreach (ICBrowser.Common.Component objLatestComp in lstLatestComp)
            {
                IEnumerable<EmailNotification> emailNotificationList = objEmailNotification.GetAllBuyersForComponent(objLatestComp.ComponentName, objLatestComp.Quantity);
                if (emailNotificationList.Count() > 0)
                {
                    foreach (EmailNotification obj in emailNotificationList)
                    {
                        obj.NotificationStatus = false;
                        obj.IsSeller = false;
                        obj.IsOffer = false;
                        objEmailNotification.AddEmailNotification(obj);
                    }
                    objLatestComp.NotificationSent = true;
                    objEmailNotification.UpdateComponentNotificationStatus(objLatestComp);
                }
            }
        }

        /// <summary>
        /// Sends the notification mail.
        /// </summary>
        /// <param name="hour">The hour.</param>
        private void sendNotificationMail(int hour)
        {
            SendEmailToSeller(hour);
            SendEmailToBuyer(hour);
        }

        /// <summary>
        /// Sends the email to buyer.
        /// </summary>
        /// <param name="hour">The hour.</param>
        private void SendEmailToBuyer(int hour)
        {
            EmailNotifications objEmailNotification = new EmailNotifications();
            IEnumerable<EmailNotification> lstdata = objEmailNotification.GetNotificationEmailsForBuyer(hour);

            StringBuilder tableCompText = new StringBuilder();
            StringBuilder tableOfferText = new StringBuilder();
            string sentNotifications = "";
            Guid currentGuid = new Guid();
            Guid previousGuid = new Guid();
            for (int i = 0; i < lstdata.Count(); i++)
            {

                // Need to Sleep Process for 10 Seconds 
                // This configuration is need to be done because of 1and1webmail server has limitations
                int threadSleepTimeInterval = Convert.ToInt32(ICBrowser.NotificationService.Properties.Settings.Default.threadSleepTimeInterval);
                System.Threading.Thread.Sleep(10000);

                currentGuid = lstdata.ElementAt(i).ToUserId;
                if (currentGuid == previousGuid || i == 0)
                {
                    if (lstdata.ElementAt(i).IsOffer)
                    {
                        tableOfferText.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>", lstdata.ElementAt(i).ComponentName, lstdata.ElementAt(i).CompanyName, lstdata.ElementAt(i).ContactName, lstdata.ElementAt(i).Quantity, lstdata.ElementAt(i).PhoneNumber, lstdata.ElementAt(i).Email));
                        sentNotifications += lstdata.ElementAt(i).NotificationId.ToString();
                        sentNotifications = sentNotifications + (", ");
                    }
                    else
                    {
                        tableCompText.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>", lstdata.ElementAt(i).ComponentName, lstdata.ElementAt(i).CompanyName, lstdata.ElementAt(i).ContactName, lstdata.ElementAt(i).Quantity, lstdata.ElementAt(i).PhoneNumber, lstdata.ElementAt(i).Email));
                        sentNotifications += lstdata.ElementAt(i).NotificationId.ToString();
                        sentNotifications = sentNotifications + (", ");
                    }
                }
                else
                {
                    tableOfferText.Append("</table>");
                    tableCompText.Append("</table>");
                    ContactAndMail contactEMail = objEmailNotification.GetContactNameEmailId(previousGuid);
                    Hashtable hash = new Hashtable
                        {
                                         {"ToUserName", contactEMail.ContactName}, 
                                         {"TableComp", tableCompText}, 
                                         {"TableOffer", tableOfferText}
                        };
                    EmailFactory mailFactory = new EmailFactory(ICBrowser.NotificationService.Properties.Settings.Default.Host, ICBrowser.NotificationService.Properties.Settings.Default.Port, ICBrowser.NotificationService.Properties.Settings.Default.Username, ICBrowser.NotificationService.Properties.Settings.Default.Password);
                    Email mail = mailFactory.SentEmailNotificationToBuyer(contactEMail.Email, "support@icbrowser.com", "Notification Mail", hash);
                    if (mail.Send())
                    {
                        IClogger.LogMessage(string.Format("Notification Mail has been sent to {0} ", contactEMail.ContactName));
                        sentNotifications = sentNotifications.Remove(sentNotifications.LastIndexOf(","));
                        objEmailNotification.UpdateEmailSentStatus(sentNotifications);
                    }
                    else
                    {
                        IClogger.LogMessage("Error Occurred in sending mail.");
                    }
                    tableCompText.Clear();
                    tableOfferText.Clear();
                    sentNotifications = sentNotifications.Remove(0);
                    if (lstdata.ElementAt(i).IsOffer)
                    {
                        tableOfferText.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>", lstdata.ElementAt(i).ComponentName, lstdata.ElementAt(i).CompanyName, lstdata.ElementAt(i).ContactName, lstdata.ElementAt(i).Quantity, lstdata.ElementAt(i).PhoneNumber, lstdata.ElementAt(i).Email));
                        sentNotifications += lstdata.ElementAt(i).NotificationId.ToString();
                        sentNotifications = sentNotifications + (", ");
                    }
                    else
                    {
                        tableCompText.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>", lstdata.ElementAt(i).ComponentName, lstdata.ElementAt(i).CompanyName, lstdata.ElementAt(i).ContactName, lstdata.ElementAt(i).Quantity, lstdata.ElementAt(i).PhoneNumber, lstdata.ElementAt(i).Email));
                        sentNotifications += lstdata.ElementAt(i).NotificationId.ToString();
                        sentNotifications = sentNotifications + (", ");
                    }
                }
                previousGuid = currentGuid;
            }
            if (lstdata.Count() >= 1)
            {
                tableOfferText.Append("</table>");
                tableCompText.Append("</table>");
                ContactAndMail finalEMail = objEmailNotification.GetContactNameEmailId(previousGuid);
                Hashtable hashh = new Hashtable
                        {
                                         {"ToUserName", finalEMail.ContactName}, 
                                         {"TableComp", tableCompText}, 
                                         {"TableOffer", tableOfferText}
                        };
                ICBrowser.NotificationService.EmailFactory finalMailFactory = new ICBrowser.NotificationService.EmailFactory(ICBrowser.NotificationService.Properties.Settings.Default.Host, ICBrowser.NotificationService.Properties.Settings.Default.Port, ICBrowser.NotificationService.Properties.Settings.Default.Username, ICBrowser.NotificationService.Properties.Settings.Default.Password);
                ICBrowser.NotificationService.Email finalMail = finalMailFactory.SentEmailNotificationToBuyer(finalEMail.Email, "support@icbrowser.com", "Notification Mail", hashh);
                if (finalMail.Send())
                {
                    IClogger.LogMessage(string.Format("Notification Mail has been sent to {0} ", finalEMail.ContactName));
                    sentNotifications = sentNotifications.Remove(sentNotifications.LastIndexOf(","));
                    objEmailNotification.UpdateEmailSentStatus(sentNotifications);
                }
                else
                {
                    IClogger.LogMessage("Error Occurred in sending mail. Please try again later.");
                }
                tableCompText.Clear();
                tableOfferText.Clear();
            }
        }

        /// <summary>
        /// Sends the email to seller.
        /// </summary>
        /// <param name="hour">The hour.</param>
        private void SendEmailToSeller(int hour)
        {
            try
            {
                EmailNotifications objEmailNotification = new EmailNotifications();
                IEnumerable<EmailNotification> lstdata = objEmailNotification.GetNotificationEmailsForSeller(hour);

                StringBuilder tableText = new StringBuilder();
                string sentNotifications = "";
                Guid currentGuid = new Guid();
                Guid previousGuid = new Guid();
                for (int i = 0; i < lstdata.Count(); i++)
                {

                    // Need to Sleep Process for 10 Seconds 
                    // This configuration is need to be done because of 1and1webmail server has limitations
                    int threadSleepTimeInterval = Convert.ToInt32(ICBrowser.NotificationService.Properties.Settings.Default.threadSleepTimeInterval);
                    System.Threading.Thread.Sleep(10000);

                    currentGuid = lstdata.ElementAt(i).ToUserId;
                    if (currentGuid == previousGuid || i == 0)
                    {
                        tableText.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>", lstdata.ElementAt(i).ComponentName, lstdata.ElementAt(i).CompanyName, lstdata.ElementAt(i).ContactName, lstdata.ElementAt(i).Quantity, lstdata.ElementAt(i).PhoneNumber, lstdata.ElementAt(i).Email));
                        sentNotifications += lstdata.ElementAt(i).NotificationId.ToString();
                        sentNotifications = sentNotifications + (", ");
                    }
                    else
                    {
                        tableText.Append("</table>");
                        ContactAndMail contactEMail = objEmailNotification.GetContactNameEmailId(previousGuid);
                        Hashtable hash = new Hashtable
                        {
                                         {"ToUserName", contactEMail.ContactName}, 
                                         {"Table", tableText}
                        };
                        EmailFactory mailFactory = new EmailFactory(ICBrowser.NotificationService.Properties.Settings.Default.Host, ICBrowser.NotificationService.Properties.Settings.Default.Port, ICBrowser.NotificationService.Properties.Settings.Default.Username, ICBrowser.NotificationService.Properties.Settings.Default.Password);
                        Email mail = mailFactory.SentEmailNotificationToSeller(contactEMail.Email, "support@icbrowser.com", "Notification Mail", hash);
                        if (mail.Send())
                        {
                            IClogger.LogMessage(string.Format("Notification Mail has been sent to {0} ", contactEMail.ContactName));
                            sentNotifications = sentNotifications.Remove(sentNotifications.LastIndexOf(","));
                            objEmailNotification.UpdateEmailSentStatus(sentNotifications);
                        }
                        else
                        {
                            IClogger.LogMessage("Error Occurred in sending mail.");
                        }
                        tableText.Clear();
                        sentNotifications = sentNotifications.Remove(0);
                        tableText.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>", lstdata.ElementAt(i).ComponentName, lstdata.ElementAt(i).CompanyName, lstdata.ElementAt(i).ContactName, lstdata.ElementAt(i).Quantity, lstdata.ElementAt(i).PhoneNumber, lstdata.ElementAt(i).Email));
                        sentNotifications += lstdata.ElementAt(i).NotificationId.ToString();
                        sentNotifications = sentNotifications + (", ");
                    }
                    previousGuid = currentGuid;
                }
                if (lstdata.Count() >= 1)
                {
                    tableText.Append("</table>");
                    ContactAndMail finalEMail = objEmailNotification.GetContactNameEmailId(previousGuid);
                    Hashtable hashh = new Hashtable
                        {
                                         {"ToUserName", finalEMail.ContactName}, 
                                         {"Table", tableText}
                        };
                    ICBrowser.NotificationService.EmailFactory finalMailFactory = new ICBrowser.NotificationService.EmailFactory(ICBrowser.NotificationService.Properties.Settings.Default.Host, ICBrowser.NotificationService.Properties.Settings.Default.Port, ICBrowser.NotificationService.Properties.Settings.Default.Username, ICBrowser.NotificationService.Properties.Settings.Default.Password);
                    ICBrowser.NotificationService.Email finalMail = finalMailFactory.SentEmailNotificationToSeller(finalEMail.Email, "support@icbrowser.com", "Notification Mail", hashh);
                    if (finalMail.Send())
                    {
                        IClogger.LogMessage(string.Format("Notifiction Mail has been sent to {0} ", finalEMail.ContactName));
                        sentNotifications = sentNotifications.Remove(sentNotifications.LastIndexOf(","));
                        objEmailNotification.UpdateEmailSentStatus(sentNotifications);
                    }
                    else
                    {
                        IClogger.LogMessage("Error Occurred in sending mail. Please try again later.");
                    }
                    tableText.Clear();
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Services the advertise email method.
        /// </summary>
        private void ServiceAdvertiseEmailMethod()
        {
            EmailDetails details = new EmailDetails();
            List<EmailNotificationAdvertiser> AdvertiserDetails = new List<EmailNotificationAdvertiser>();
            AdvertiserDetails = details.getUserDetailOnAdvertisementExpiry();
            ICBrowser.NotificationService.EmailFactory mailFactory = new ICBrowser.NotificationService.EmailFactory(ICBrowser.NotificationService.Properties.Settings.Default.Host, ICBrowser.NotificationService.Properties.Settings.Default.Port, ICBrowser.NotificationService.Properties.Settings.Default.Username, ICBrowser.NotificationService.Properties.Settings.Default.Password);
            try
            {
                foreach (EmailNotificationAdvertiser detail in AdvertiserDetails)
                {
                    // Need to Sleep Process for 10 Seconds 
                    // This configuration is need to be done because of 1and1webmail server has limitations
                    int threadSleepTimeInterval = Convert.ToInt32(ICBrowser.NotificationService.Properties.Settings.Default.threadSleepTimeInterval);
                    System.Threading.Thread.Sleep(10000);

//Mail sends to Block  User
                    // string userName = "Administrator";
                    //   string txtSubject = "Your ICBrowser Account has been Blocked";
                    
                    string toEmailId = detail.Email;
                    string date = detail.EndDate.ToShortDateString();

                    // Hashtable hash = new Hashtable { { "date", date }, { "FromUserName", userName }, { "Subject", txtSubject }, { "Message", txtContent } };

                    Email mail = mailFactory.GetAdvertisementExpiryNotificationMail(toEmailId, "support@icbrowser.com", date);
                    mail.Send();
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        //private void ServiceupdateNotificationEmailMethod()
        //{
        //    EmailDetails details = new EmailDetails();
        //    List<EmailNotificationMembershipDetails> UserDetails = new List<EmailNotificationMembershipDetails>();
        //    UserDetails = details.getUserDetailForUpdateNotification();
        //    ICBrowser.NotificationService.EmailFactory mailFactory = new ICBrowser.NotificationService.EmailFactory(ICBrowser.NotificationService.Properties.Settings.Default.Host, ICBrowser.NotificationService.Properties.Settings.Default.Port, ICBrowser.NotificationService.Properties.Settings.Default.Username, ICBrowser.NotificationService.Properties.Settings.Default.Password);
        //    try
        //    {
        //        foreach (EmailNotificationMembershipDetails detail in UserDetails)
        //        {

        //            // Need to Sleep Process for 10 Seconds 
        //            // This configuration is need to be done because of 1and1webmail server has limitations
        //            int threadSleepTimeInterval = Convert.ToInt32(ICBrowser.NotificationService.Properties.Settings.Default.threadSleepTimeInterval);
        //            System.Threading.Thread.Sleep(10000);


        //            string toUserName = detail.UserName;
        //            string toEmailId = detail.Email;
        //            Email mail = mailFactory.GetUserDetailForUpdateNotificationMail(toEmailId, "support@icbrowser.com", toUserName);
        //            mail.Send();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogMessage(ex.Message);
        //    }
        //}

        /// <summary>
        /// Services the membership email method.
        /// </summary>
        private void ServiceMembershipEmailMethod()
        {
            EmailDetails details = new EmailDetails();
            List<EmailNotificationMembershipDetails> MembershipDetails = new List<EmailNotificationMembershipDetails>();
            MembershipDetails = details.getUserDetailOnMembershipExpiry();
            ICBrowser.NotificationService.EmailFactory mailFactory = new ICBrowser.NotificationService.EmailFactory(ICBrowser.NotificationService.Properties.Settings.Default.Host, ICBrowser.NotificationService.Properties.Settings.Default.Port, ICBrowser.NotificationService.Properties.Settings.Default.Username, ICBrowser.NotificationService.Properties.Settings.Default.Password);
            try
            {
                foreach (EmailNotificationMembershipDetails detail in MembershipDetails)
                {

                    // Need to Sleep Process for 10 Seconds 
                    // This configuration is need to be done because of 1and1webmail server has limitations
                    int threadSleepTimeInterval = Convert.ToInt32(ICBrowser.NotificationService.Properties.Settings.Default.threadSleepTimeInterval);
                    System.Threading.Thread.Sleep(10000);


                    //Mail sends to Block  User
                    // string userName = "Administrator";
                    //   string txtSubject = "Your ICBrowser Account has been Blocked";
                    string toUserName = detail.UserName;
                    string date = detail.MembershipExpiryDate.ToShortDateString();
                    string toEmailId = detail.Email;

                    // Hashtable hash = new Hashtable { { "date", date }, { "FromUserName", userName }, { "Subject", txtSubject }, { "Message", txtContent } };


                    Email mail = mailFactory.GetMembershipExpiryNotificationMail(toEmailId, "support@icbrowser.com", date, toUserName);
                    mail.Send();
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// Services the delete record on membership expiry method.
        /// </summary>
        private void ServiceDeleteRecordOnMembershipExpiryMethod()
        {
            EmailDetails details = new EmailDetails();
            try
            {
                details.DeleteRecordOnMembershipExpiry();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

    }
}
