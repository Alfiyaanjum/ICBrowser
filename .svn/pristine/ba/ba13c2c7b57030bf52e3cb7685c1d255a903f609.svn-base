using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ICBrowser.Web
{
    public partial class ChangePassword :BasePage
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblError.Text = "";
            lblSuccess.Visible = false;
            lblSuccess.Text = "";
        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            if (txtOldPassword.Text != "" && txtPassword.Text != "" && txtVerifyPassword.Text != "")
            {
                if (txtPassword.Text == txtVerifyPassword.Text)
                {
                    if (userToLogin.ChangePassword(txtOldPassword.Text.Trim(), txtPassword.Text.Trim()))
                    {
                        lblSuccess.Visible = true;
                        lblSuccess.Text = "Password has been changed successfully.";
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Password is not change. Please try again.";
                    }
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Your Password is incorrect. Please try again.";
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Password cannot be empty. Please try again.";
            }

        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtOldPassword.Text = "";
            txtPassword.Text = "";
            txtVerifyPassword.Text = "";
        }
    }
}