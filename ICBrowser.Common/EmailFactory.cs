using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Data;
using System.Net.Mail;
namespace ICBrowser.Common
{
    /// <summary>
    /// Enum that lists the email types
    /// </summary>
    public enum EmailType
    {
        AccountRequest,
        AccountActivation,
        ForgetPassword,
        AccountApproval,
        EmailSentTemplate,
        TrialsellerSentEmail,
        SellerNotificationMail,
        AdminApprovedMail
    }


    /// <summary>
    /// 
    /// </summary>
    public enum Status
    {
        Approved,
        Rejected
    }

    /// <summary>
    /// Class to get Email object for sending mail
    /// </summary>

    public class EmailFactory
    {
        #region Fields


        private Email m_email;
        private string m_templateFolderPath;
        private string m_mappingFileName;

        #endregion

        #region Properties
        #endregion

        #region Constants

        private const string CONST_SUBJECT = "Subject";
        private const string CONST_FILENAME = "FileName";

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public EmailFactory()
        {
            // reading SMTP setting from config file
            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(System.Web.HttpContext.Current.Request.ApplicationPath);
            System.Net.Configuration.MailSettingsSectionGroup settings = (System.Net.Configuration.MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

            // reading settings from config file
            try
            {
                m_templateFolderPath = ConfigurationManager.AppSettings["EMAIL_TEMPLATE_FOLDER_PATH"];
                m_mappingFileName = ConfigurationManager.AppSettings["EMAIL_MAPPING_XML_FILE"];

                m_email = new Email(settings.Smtp.Network.Host, settings.Smtp.Network.Port, settings.Smtp.Network.UserName, settings.Smtp.Network.Password);

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error");
            }
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="smtpHost">string</param>
        /// <param name="smtpPort">int</param>
        /// <param name="smtpUserName">string</param>
        /// <param name="smtpPassword">string</param>
        public EmailFactory(string smtpHost, int smtpPort, string smtpUserName, string smtpPassword)
        {
            // reading settings from config file
            try
            {
                m_templateFolderPath = ConfigurationManager.AppSettings["EMAIL_TEMPLATE_FOLDER_PATH"];
                m_mappingFileName = ConfigurationManager.AppSettings["EMAIL_MAPPING_XML_FILE"];

                m_email = new Email(smtpHost, smtpPort, smtpUserName, smtpPassword);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error");
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to get Email object
        /// </summary>
        /// <returns>Email</returns>
        public Email GetMail()
        {
            return m_email;
        }

        /// <summary>
        /// Method to get Email object for account activation 
        /// </summary>
        /// <param name="to">string</param>
        /// <param name="from">string</param>
        /// <param name="hashTemplateVars">Hashtable</param>
        /// <returns>Email</returns>
        public Email GetAccountActivationMail(string to, string from, Hashtable hashTemplateVars)
        {
            m_email.To = new string[] { to };
            m_email.From = from;

            ConstructMail(EmailType.AccountActivation);

            m_email.Message = m_email.Message.Replace("#Name#", hashTemplateVars["Name"].ToString());
            m_email.Message = m_email.Message.Replace("#ActivationLink#", hashTemplateVars["ActivationLink"].ToString());

            m_email.IsHTML = true;

            return m_email;
        }


        /// <summary>
        /// Method to get Email object for account request
        /// </summary>
        /// <param name="to">string</param>
        /// <param name="from">string</param>
        /// <param name="hashTemplateVars">Hashtable</param>
        /// <returns>Email</returns>
        public Email GetAccountRequestMail(string to, string from, Hashtable hashTemplateVars)
        {
            m_email.To = new string[] { to };
            m_email.From = from;

            ConstructMail(EmailType.AccountRequest);

            m_email.Message = m_email.Message.Replace("#UserName#", hashTemplateVars["UserName"].ToString());
            m_email.Message = m_email.Message.Replace("#AccountType#", hashTemplateVars["AccountType"].ToString());
            m_email.Message = m_email.Message.Replace("#Code#", hashTemplateVars["Password"].ToString());

            m_email.IsHTML = true;

            return m_email;
        }


        ///admin Account Approval Mail to Seller
        public Email GetAccountApprovalMailByAdmin(string to, string from, Hashtable hashTemplateVars)
        {
            m_email.To = new string[] { to };
            m_email.From = from;
            ConstructMail(EmailType.AdminApprovedMail);
            m_email.Message = m_email.Message.Replace("#ToUserName#", hashTemplateVars["ToUserName"].ToString());
            m_email.Message = m_email.Message.Replace("#FromUserName#", hashTemplateVars["FromUserName"].ToString());
            m_email.Message = m_email.Message.Replace("#ToContactName#", hashTemplateVars["ToContactName"].ToString());
            m_email.IsHTML = true;
            return m_email;
        }


        /// <summary>
        /// Method to get Email object for forgot password
        /// </summary>
        /// <param name="to">string</param>
        /// <param name="from">string</param>
        /// <param name="hashTemplateVars">Hashtable</param>
        /// <returns>Email</returns>
        public Email GetForgetPasswordMail(string to, string from, Hashtable hashTemplateVars)
        {

            m_email.To = new string[] { to };
            m_email.From = from;

            ConstructMail(EmailType.ForgetPassword);

            m_email.Message = m_email.Message.Replace("#Password#", hashTemplateVars["Password"].ToString());
            m_email.Message = m_email.Message.Replace("#AccountType#", hashTemplateVars["AccountType"].ToString());
            m_email.Message = m_email.Message.Replace("#UserId#", hashTemplateVars["UserId"].ToString());

            m_email.IsHTML = true;

            return m_email;
        }

        /// <summary>
        /// Method to get Email object for account approval/rejection
        /// </summary>
        /// <param name="to">string</param>
        /// <param name="from">string</param>
        /// <param name="hashTemplateVars">Hashtable</param>
        /// <returns>Email</returns>
        public Email GetAccountApprovalMail(string to, string from, Hashtable hashTemplateVars)
        {

            m_email.To = new string[] { to };
            m_email.From = from;
            m_email.Subject = "Account Approval";

            m_email.Message = m_email.Message.Replace("#UserId#", hashTemplateVars["UserId"].ToString());
            m_email.Message = m_email.Message.Replace("#Status#", hashTemplateVars["Status"].ToString());
            m_email.Message = m_email.Message.Replace("#ActivationLink#", hashTemplateVars["ActivationLink"].ToString());
            m_email.Message = m_email.Message.Replace("#ActivationMessage#", hashTemplateVars["ActivationMessage"].ToString());

            m_email.IsHTML = true;

            return m_email;
        }
     
        public Email SendEmail(string to, string from, string subject, string body, Hashtable hashTemplateVars)
        {
            string[] temp = to.Split(';');
            m_email.To = temp;
            m_email.From = from;
            m_email.Subject = subject;

            ConstructMail(EmailType.EmailSentTemplate);

            m_email.Message = m_email.Message.Replace("#ToUserName#", hashTemplateVars["ToUserName"].ToString());
            m_email.Message = m_email.Message.Replace("#FromUserName#", hashTemplateVars["FromUserName"].ToString());
            m_email.Message = m_email.Message.Replace("#Subject#", hashTemplateVars["Subject"].ToString());
            m_email.Message = m_email.Message.Replace("#Message#", hashTemplateVars["Message"].ToString());
            m_email.IsHTML = true;
            return m_email;
        }

        public Email SendBroadCastEmailByAdmin(string to, string from, string subject, string body, Hashtable hashTemplateVars)
        {
            string[] temp = to.Split(';');
            m_email.BCC = temp;
            m_email.From = from;
            m_email.Subject = subject;

            ConstructMail(EmailType.EmailSentTemplate);

            m_email.Message = m_email.Message.Replace("#ToUserName#", hashTemplateVars["ToUserName"].ToString());
            m_email.Message = m_email.Message.Replace("#FromUserName#", hashTemplateVars["FromUserName"].ToString());
            m_email.Message = m_email.Message.Replace("#Subject#", hashTemplateVars["Subject"].ToString());
            m_email.Message = m_email.Message.Replace("#Message#", hashTemplateVars["Message"].ToString());
            m_email.IsHTML = true;
            return m_email;
        }





        public Email SendEmailBySellerId(string to, string from, string subject, string body, Hashtable hashTemplateVars)
        {
            m_email.To = new string[] { to };
            m_email.From = from;
            m_email.Subject = subject;



            ConstructMail(EmailType.EmailSentTemplate);

            m_email.Message = m_email.Message.Replace("#ToUserName#", hashTemplateVars["ToUserName"].ToString());
            m_email.Message = m_email.Message.Replace("#FromUserName#", hashTemplateVars["FromUserName"].ToString());
            m_email.Message = m_email.Message.Replace("#Subject#", hashTemplateVars["Subject"].ToString());
            m_email.Message = m_email.Message.Replace("#Message#", hashTemplateVars["Message"].ToString());
            m_email.IsHTML = true;
            return m_email;
        }

        public Email SentDefaultTemplateToSeller(string to, string from, Hashtable hashTemplateVars)
        {
            string[] temp = to.Split(';');
            m_email.To = temp;
            m_email.From = from;
            //m_email.Subject = subject;

            ConstructMail(EmailType.TrialsellerSentEmail);

            m_email.Message = m_email.Message.Replace("#ToUserName#", hashTemplateVars["ToUserName"].ToString());
            m_email.Message = m_email.Message.Replace("#FromUserName#", hashTemplateVars["FromUserName"].ToString());
            //m_email.Message = m_email.Message.Replace("#Subject#", hashTemplateVars["Subject"].ToString());
            //m_email.Message = m_email.Message.Replace("#Message#", hashTemplateVars["Message"].ToString());
            m_email.IsHTML = true;
            return m_email;
        }

        public Email SentEmailNotificationToSeller(string to, string from, string subject, Hashtable hashTemplateVars)
        {
            string[] temp = to.Split(';');
            m_email.To = temp;
            m_email.From = from;
            m_email.Subject = subject;

            ConstructMail(EmailType.SellerNotificationMail);

            m_email.Message = m_email.Message.Replace("#ToUserName#", hashTemplateVars["ToUserName"].ToString());
            m_email.Message = m_email.Message.Replace("#Table#", hashTemplateVars["Table"].ToString());
            m_email.IsHTML = true;
            return m_email;
        }

        #endregion

        #region private Methods

        /// <summary>
        /// Method to construct mail body and mail subject
        /// </summary>
        /// <param name="emailType">EmailType</param>
        private void ConstructMail(EmailType emailType)
        {
            string emailMappingFile = string.Empty;
            string templateFile = string.Empty;
            StreamReader reader = null;

            try
            {
                //emailMappingFile = System.Web.HttpContext.Current.Server.MapPath("~" + m_templateFolderPath + m_mappingFileName);
                emailMappingFile = System.Web.HttpContext.Current.Server.MapPath("~" + m_templateFolderPath + m_mappingFileName);


                // reading the xml file into XmlDocument object
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(File.ReadAllText(emailMappingFile));

                // getting mail subject and mail template file name
                m_email.Subject = xml.SelectSingleNode("//" + emailType.ToString() + "/" + CONST_SUBJECT).FirstChild.Value;
                templateFile = xml.SelectSingleNode("//" + emailType.ToString() + "/" + CONST_FILENAME).FirstChild.Value;
                templateFile = System.Web.HttpContext.Current.Server.MapPath("~" + m_templateFolderPath + templateFile);

                reader = new StreamReader(templateFile);
                m_email.Message = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error");
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        #endregion
    }
}
