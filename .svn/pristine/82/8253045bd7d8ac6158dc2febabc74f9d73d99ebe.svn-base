using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace ICBrowser.Web.Controls
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets or sets the absolute path.
        /// </summary>
        /// <value>The absolute path.</value>
        public string AbsolutePath { get; set; }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AbsolutePath = Request.UrlReferrer.AbsolutePath;
                Session["AbsolutePath"] = AbsolutePath;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser(txtUsrName.Text);
            bool validateuser = Membership.ValidateUser(txtUsrName.Text, txtPassWrd.Text);

            if (validateuser == true)
            {
                MembershipUser CurrentUser = Membership.GetUser(txtUsrName.Text);
                FormsAuthentication.SetAuthCookie(txtUsrName.Text, false);
               // string str = Session["AbsolutePath"].ToString();
                Response.Redirect("Default.aspx",true);
            }
            else
            {
                LblError.Visible = true;
                LblError.Text = "Please enter correct user name and password";
            }
        }
    }
}