using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections;
using ICBrowser.Common;
using System.Net.Configuration;
using System.Web.Configuration;
using System.Configuration;


namespace ICBrowser.Web
{
    public partial class ForgotPassword : BasePage
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblSuccess.Visible = false;
        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            MembershipUser userToLogin = Membership.GetUser(txtUserNameForgotPassword.Text);

            if (userToLogin != null)
            {
                if (userToLogin.IsLockedOut)
                {
                    userToLogin.UnlockUser();
                }
                string resetpassword = userToLogin.ResetPassword();

                string temp = string.Empty;

                string newpassword = Pinpassword();

                string toEmailId = userToLogin.Email;

                string fromEmailId = GetFromMailId();

                userToLogin.ChangePassword(resetpassword, newpassword);

                // string from = mailSettings.From;

                Hashtable hash = new Hashtable
                                     {
                                         {"UserId", txtUserNameForgotPassword.Text},
                                         {"AccountType", "Forgot Password"},
                                         {"Password", newpassword}
                                     };

                EmailFactory mailFactory = new EmailFactory();
                Email mail = mailFactory.GetForgetPasswordMail(toEmailId, fromEmailId, hash);

                if (mail.Send())
                {
                    lblSuccess.Visible = true;
                    lblSuccess.Text = "Password sent to your Email Account successfully.";
                    // "Account Activation Link is sent to you Email ID"
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Error occured in sending mail. Please try again later.";
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = string.Format("No record found for {0}. Please check the Username and try again", txtUserNameForgotPassword.Text);
            }
            txtUserNameForgotPassword.Text = string.Empty;
        }

        /// <summary>
        /// Pinpasswords this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        private string Pinpassword()
        {
            string pinPwd = string.Empty;
            int j = 0;      //for Upper Case because it will generate the Character same as like ch[i] doing.

            Random rnd = new Random();    // random class for random generate the numbers using .Next()

            for (int i = 0; i <= 2; i++) // For loop
            {
                j = j + 1;      //increment the J variable for Random Characters.

                // Create nums Array.
                int[] nums = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                // create an characters Array for it.
                char[] ch = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

                char[] spc = new[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };

                nums[i] = nums[rnd.Next(0, 9)];
                ch[i] = ch[rnd.Next(0, 20)];
                ch[j] = ch[rnd.Next(0, 25)];
                spc[i] = spc[rnd.Next(0, 9)];

                pinPwd += nums[i].ToString() + ch[i].ToString() + ch[j].ToString().ToUpper() + spc[i].ToString();

                // just add/append the nums and ch in pin_pwd.
                //pin_pwd will store the string of random generated password.
            }
            return pinPwd;
        }

        /// <summary>
        /// Gets from mail identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetFromMailId()
        {
            string emailFrom = string.Empty; ;
            foreach (ConfigurationSectionGroup csg in WebConfigurationManager.OpenWebConfiguration("~/web.config").SectionGroups)
            {
                if (csg.Name == "system.net")
                {
                    foreach (ConfigurationSectionGroup csg2 in csg.SectionGroups)
                    {
                        if (csg2.Name == "mailSettings")
                        {
                            var mailSettings = (MailSettingsSectionGroup)csg2;
                            emailFrom = mailSettings.Smtp.Network.UserName;
                        }
                    }
                }
            }

            return emailFrom;
        }
    }
}