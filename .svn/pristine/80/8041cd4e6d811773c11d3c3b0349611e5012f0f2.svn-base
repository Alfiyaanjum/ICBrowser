using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections;
using ICBrowser.Common;


namespace ICBrowser.Web.Account
{
    public partial class ForgetPassword :Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {      
            
            lblError.Visible = false;
            lblSuccess.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser(txtUserNameForgetPassword.Text);

            if (userToLogin != null)
            {
                if (userToLogin.IsLockedOut)
                {
                    userToLogin.UnlockUser();
                }
                string resetpassword = userToLogin.ResetPassword();

                string temp = string.Empty;

                string newpassword = Pinpassword();

                userToLogin.ChangePassword(resetpassword, newpassword);


                Hashtable hash = new Hashtable
                                     {
                                         {"UserId", txtUserNameForgetPassword.Text},
                                         {"AccountType", "Forgot Password"},
                                         {"Password", newpassword}
                                     };

                EmailFactory mailFactory = new EmailFactory();
                Email mail = mailFactory.GetForgetPasswordMail(txtUserNameForgetPassword.Text, txtUserNameForgetPassword.Text, hash);

                if (mail.Send())
                {
                    lblSuccess.Visible = true;
                    lblSuccess.Text = "Password has been send successfully";
                    // "Account Activation Link is sent to you Email ID"
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Error Occured in sending mail. Please try again later.";
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = string.Format("No record found for {0}. Please check the user name and try again", txtUserNameForgetPassword.Text);
            }
        }

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
    }
}