using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace ICBrowser.Web.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblError.Text = "";
            lblSuccess.Visible = false;
            lblSuccess.Text = "";

        }

        protected void btn_submt_Click(object sender, EventArgs e)
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
                lblError.Text = "Password Cannot be empty. Please try again.";
            }
        }



    }
}
