using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Web;

namespace ICBrowser.Common
{
    public class Email
    {
        #region Fields

        private string[] m_emailTo;
        private string m_emailFrom;
        private string m_message;
        private string m_subject;
        private bool m_isHTML;
        private string[] m_cc;
        private string[] m_bcc;
        private SmtpClient m_client;

        #endregion

        #region Properties

        public string[] To
        {
            get { return m_emailTo; }
            set { m_emailTo = value; }
        }

        public string From
        {
            get { return m_emailFrom; }
            set { m_emailFrom = value; }
        }

        public string Message
        {
            get { return m_message; }
            set { m_message = value; }
        }

        public string Subject
        {
            get { return m_subject; }
            set { m_subject = value; }
        }

        public string[] CC
        {
            get { return m_cc; }
            set { m_cc = value; }
        }

        public string[] BCC
        {
            get { return m_bcc; }
            set { m_bcc = value; }
        }

        public bool IsHTML
        {
            get { return m_isHTML; }
            set { m_isHTML = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="smtpHost">string</param>
        /// <param name="smtpPort">int</param>
        /// <param name="smtpUserName">string</param>
        /// <param name="smtpPassword">string</param>
        public Email(string smtpHost, int smtpPort, string smtpUserName, string smtpPassword)
        {
            m_client = new SmtpClient();
            m_client.EnableSsl = true;
            m_client.Host = smtpHost;
            m_client.Port = smtpPort;
            //m_client.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPassword);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to send the email
        /// </summary>
        /// <returns>bool</returns>
        public bool Send()
        {
            return Send(m_emailTo, m_cc, m_bcc, m_emailFrom, m_message, m_subject);
        }

        /// <summary>
        /// Method to send the email
        /// </summary>
        /// <param name="to">string[]</param>
        /// <param name="cc">string[]</param>
        /// <param name="bcc">string[]</param>
        /// <param name="from">string</param>
        /// <param name="message">string</param>
        /// <param name="subject">string</param>
        /// <returns>bool</returns>
        public bool Send(string[] to, string[] cc, string[] bcc, string from, string message, string subject)
        {
            bool isSuccess = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = m_isHTML;

                #region message initialization
                if (to != null && to.Length > 0)
                {
                    foreach (string toAddress in to)
                    {
                        mail.To.Add(toAddress);
                    }
                }
                if (cc != null && cc.Length > 0)
                {
                    foreach (string ccAddress in cc)
                    {
                        mail.CC.Add(ccAddress);
                    }
                }
                if (bcc != null && bcc.Length > 0)
                {
                    foreach (string bccAddress in bcc)
                    {
                        mail.Bcc.Add(bccAddress);
                    }
                }
                if (from != null && from.Trim().Length > 0)
                {
                    mail.From = new MailAddress(from);
                }
                if (message != null && message.Trim().Length > 0)
                {
                    mail.Body = message;
                }
                else
                {
                    mail.Body = "No message specified.";
                }
                if (subject != null && subject.Trim().Length > 0)
                {
                    mail.Subject = subject;
                }
                else
                {
                    mail.Subject = "No subject specified.";
                }

                #endregion
                //#region Embed Image.
                ////first we create the Plain Text part
                //AlternateView plainView = AlternateView.CreateAlternateViewFromString("This is my plain text content, viewable by those clients that don't support html", null, "text/plain");
                ////then we create the Html part
                ////to embed images, we need to use the prefix 'cid' in the img src value
                ////the cid value will map to the Content-Id of a Linked resource.
                ////thus <img src='cid:companylogo'> will map to a LinkedResource with a ContentId of 'companylogo'
                //AlternateView htmlView = AlternateView.CreateAlternateViewFromString("Here is an embedded image.<img src=cid:Circuitboard>", null, "text/html");
                ////create the LinkedResource (embedded image)
                //LinkedResource logo = new LinkedResource("E:\\work\\work\\ICBrowser.Web\\data\\EmailTemplates\\Circuitboard.jpg");
                //logo.ContentId = "Circuitboard";
                ////add the LinkedResource to the appropriate view
                //htmlView.LinkedResources.Add(logo);
                ////add the views
                //mail.AlternateViews.Add(plainView);
                //mail.AlternateViews.Add(htmlView);
                //#endregion


                //AlternateView htmlview = default(AlternateView);
                //htmlview = AlternateView.CreateAlternateViewFromString(mail.Body, null, "text/html");
                //LinkedResource imageResourceEs = new LinkedResource("E:\\work\\ICBrowser\\ICBrowser.Web\\data\\EmailTemplates\\Circuitboard.jpg");
                //imageResourceEs.ContentId = "Circuitboard";
                //imageResourceEs.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                //htmlview.LinkedResources.Add(imageResourceEs);
                //mail.AlternateViews.Add(htmlview);

                string path = HttpContext.Current.Server.MapPath("~/Images/icb_logo.jpg");
                mail.Attachments.Add(new Attachment(path));
                mail.Attachments[0].ContentId = "icb_logo.jpg";
                mail.Attachments[0].ContentDisposition.Inline = true;
                mail.Attachments[0].ContentDisposition.FileName = "icb_logo.jpg"; 
                

                // sending email
                m_client.EnableSsl = true;
                m_client.Host = "smtp.1and1.com";
                m_client.Port = 587;
                m_client.Send(mail);
                isSuccess = true;
            }
            catch (Exception ex)
            {
               IClogger.LogError(ex, "Error");
            }

            return isSuccess;
        }

        #endregion
    }
}
