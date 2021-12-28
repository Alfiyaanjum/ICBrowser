using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Data;
using System.Collections;
using System.Web.Security;

namespace ICBrowser.Web
{
    public partial class AdminUsrDetails : BasePage
    {
        List<ICBrowser.Common.UserProfile> lstfreeUsrProfl = new List<ICBrowser.Common.UserProfile>();
        List<ICBrowser.Common.UserProfile> lstPaidUsrProfl = new List<ICBrowser.Common.UserProfile>();

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSucess.Visible = false;
            lblError.Visible = false;
            lblscs.Visible = false;
            lblerr.Visible = false;
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;
            if (!Page.IsPostBack)
            {
                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
                if (Admin.IsAdmin == true || currUserId != null)
                {
                    BindPaidUsrGrid();
                    BindFreeUsrGrid();
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }

            ClearContents();

        }

        /// <summary>
        /// Clears the contents.
        /// </summary>
        public void ClearContents()
        {
            lblError.Visible = false;
            lblSucess.Visible = false;
            lblscs.Visible = false;
            lblerr.Visible = false;
        }

        
    #region Paid User Events and Methods


        /// <summary>
        /// Binds the paid usr grid.
        /// </summary>
        private void BindPaidUsrGrid()
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;
            UserProfileDetails usrProfDetils = new UserProfileDetails();
            lstPaidUsrProfl = usrProfDetils.GetAllPaidUsrDetails(currUserId);
            gvPaidUsrDetails.DataSource = lstPaidUsrProfl;
            gvPaidUsrDetails.DataBind();
        }

        /// <summary>
        /// Handles the RowCancelingEdit event of the gvPaidUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
        protected void gvPaidUsrDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            gvPaidUsrDetails.EditIndex = -1;
            //Bind data to the GridView control.         
            BindPaidUsrGrid();
        }

        /// <summary>
        /// Handles the RowUpdating event of the gvPaidUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
        protected void gvPaidUsrDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;
            Controller controlIsAdmin = new Controller();
            Users Admin = controlIsAdmin.GetIsAdmin(currUserId);

            if (Admin.IsAdmin == true)
            {
                Button btnSendMail = (Button)gvPaidUsrDetails.Rows[e.RowIndex].FindControl("btnSendMail");
                Button btnStat = (Button)gvPaidUsrDetails.Rows[e.RowIndex].FindControl("btnStat");
                Button btnExclude = (Button)gvPaidUsrDetails.Rows[e.RowIndex].FindControl("btnExclude");
                TextBox tb = (TextBox)gvPaidUsrDetails.Rows[e.RowIndex].FindControl("tb");
                string txtContent = tb.Text;
                Label lblUsrId = (Label)gvPaidUsrDetails.Rows[e.RowIndex].FindControl("lblUsrId");
                Label lblEmail = (Label)gvPaidUsrDetails.Rows[e.RowIndex].FindControl("lblEmail");
                Label lblContactName = (Label)gvPaidUsrDetails.Rows[e.RowIndex].FindControl("lblContactName");

                string contactName = lblContactName.Text;
                Guid usrId = new Guid(lblUsrId.Text);


                if (btnStat.Text == "False")
                {
                    UserProfileDetails usrProflDetails = new UserProfileDetails();
                    Common.UserProfile Profile = new Common.UserProfile();
                    Profile.ReasonToBlock = txtContent;
                    Profile.UserId = usrId;
                    bool block = usrProflDetails.SetBlockUser(Profile);

                    if (block)
                    {
                        //Mail sends to Block  User
                        string userName = "Administrator";
                        string txtSubject = "Your ICBrowser Account has been Blocked";
                        string toEmailId = lblEmail.Text;

                        Hashtable hash = new Hashtable { { "ToUserName", contactName }, { "FromUserName", userName }, { "Subject", txtSubject }, { "Message", txtContent } };
                        EmailFactory mailFactory = new EmailFactory();
                        Email mail = mailFactory.SendEmailBySellerId(toEmailId, "support@icbrowser.com", txtSubject, txtContent, hash);

                        if (mail.Send())
                        {
                            lblSucess.Visible = true;
                            lblSucess.Text = "User blocked successfully. Mail sent to user.";
                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = "Error occurred in sending mail. Please try again later.";
                        }
                    }
                    else
                    {
                        lblError.Text = "Error occured during Operation. Please try again later.";
                    }
                }
                else
                {
                    UserProfileDetails usrProflDetails = new UserProfileDetails();
                    Common.UserProfile Profile = new Common.UserProfile();
                    Profile.ReasonToUnblock = txtContent;
                    Profile.UserId = usrId;
                    bool block = usrProflDetails.SetUnBlockUser(Profile);

                    if (block)
                    {
                        //Mail sends to UnBlock  User
                        string userName = "Administrator";
                        string txtSubject = "Your ICBrowser Account has been UnBlocked";
                        string toEmailId = lblEmail.Text;

                        Hashtable hash = new Hashtable { { "ToUserName", contactName }, { "FromUserName", userName }, { "Subject", txtSubject }, { "Message", txtContent } };
                        EmailFactory mailFactory = new EmailFactory();
                        Email mail = mailFactory.SendEmailBySellerId(toEmailId, "support@icbrowser.com", txtSubject, txtContent, hash);

                        if (mail.Send())
                        {
                            lblSucess.Visible = true;
                            lblSucess.Text = "User unblocked successfully. Mail sent to user.";
                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = "Error occurred in sending mail. Please try again later.";
                        }
                    }
                    else
                    {
                        lblError.Text = "Error occured during Operation. Please try again later.";
                    }
                }
            }
            //Reset the edit index.
            gvPaidUsrDetails.EditIndex = -1;
            //Bind data to the GridView control.            
            this.BindPaidUsrGrid();
        }

        /// <summary>
        /// Handles the RowEditing event of the gvPaidUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
        protected void gvPaidUsrDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //int pageIndex = gvPaidUsrDetails.PageIndex;

            if (Session["SearchResult"] != null)
            {
                gvPaidUsrDetails.EditIndex = e.NewEditIndex;
                gvPaidUsrDetails.DataSource = Session["SearchResult"];
                gvPaidUsrDetails.DataBind();
                Session["SearchResult"] = null;
            }
            else
            {
                gvPaidUsrDetails.EditIndex = e.NewEditIndex;
                BindPaidUsrGrid();
            }
        }

        /// <summary>
        /// Handles the Click event of the imgSearchFromGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void imgSearchFromGrid_Click(object sender, ImageClickEventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;
            List<ICBrowser.Common.UserProfile> lst = new List<Common.UserProfile>();
            string searchVal = txtSearchFromGrid.Text;
            UserProfileDetails usrProfDetils = new UserProfileDetails();
            lstPaidUsrProfl = usrProfDetils.GetAllPaidUsrDetails(currUserId);
            if (ddlUsrGridColumns.SelectedIndex == 1)
            {
                var searchedData = from s in lstPaidUsrProfl
                                   where s.UserName.ToLower().Contains(searchVal.ToLower())
                                   select s;
                gvPaidUsrDetails.DataSource = searchedData.ToList();
                gvPaidUsrDetails.DataBind();
                Session["SearchResult"] = gvPaidUsrDetails.DataSource;
            }
            else if (ddlUsrGridColumns.SelectedIndex == 2)
            {
                var searchedData = from s in lstPaidUsrProfl
                                   where s.CompanyName.ToLower().Contains(searchVal.ToLower())
                                   select s;
                gvPaidUsrDetails.DataSource = searchedData.ToList();
                gvPaidUsrDetails.DataBind();
                Session["SearchResult"] = gvPaidUsrDetails.DataSource;
            }
            else if (ddlUsrGridColumns.SelectedIndex == 3)
            {
                var searchedData = from s in lstPaidUsrProfl
                                   where s.ContactName.ToLower().Contains(searchVal.ToLower())
                                   select s;
                gvPaidUsrDetails.DataSource = searchedData.ToList();
                gvPaidUsrDetails.DataBind();
                Session["SearchResult"] = gvPaidUsrDetails.DataSource;
            }
            else if (ddlUsrGridColumns.SelectedIndex == 4)
            {
                var searchedData = from s in lstPaidUsrProfl
                                   where s.OwnerName.ToLower().Contains(searchVal.ToLower())
                                   select s;
                gvPaidUsrDetails.DataSource = searchedData.ToList();
                gvPaidUsrDetails.DataBind();
                Session["SearchResult"] = gvPaidUsrDetails.DataSource;
            }
        }

        /// <summary>
        /// Handles the Click event of the imgClearSearchSelection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void imgClearSearchSelection_Click(object sender, ImageClickEventArgs e)
        {
            txtSearchFromGrid.Text = string.Empty;
            ddlUsrGridColumns.SelectedIndex = 0;
            gvPaidUsrDetails.EditIndex = -1;
            BindPaidUsrGrid();
            lblSucess.Visible = false;
            lblError.Visible = false;
        }

        /// <summary>
        /// Handles the RowDataBound event of the gvPaidUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvPaidUsrDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;
            Controller controlIsAdmin = new Controller();
            Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
            if (Admin.IsAdmin == true)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Button btnStatus = row.FindControl("btnStat") as Button;
                    Button btn = row.FindControl("btnedit") as Button;
                    if (btn != null)
                    {
                        if ((btnStatus.Text != null && btnStatus.Text == "True"))
                        {
                            btn.Text = "UnBlock";
                        }
                        else if ((btnStatus.Text != null && btnStatus.Text == "False"))
                        {
                            btn.Text = "Block";
                        }

                    }

                    Label lblMemType = e.Row.FindControl("lblMemType") as Label;
                    if (lblMemType.Text == "2")
                    {
                        lblMemType.Text = "Trial User";
                    }
                    else
                    {
                        lblMemType.Text = "Paid User";
                    }
                    gvPaidUsrDetails.Columns[3].Visible = false;
                }
            }
            else
            {
                pnlFilter.Visible = false;
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Button btnExclude = row.FindControl("btnExclude") as Button;
                    Button btn = row.FindControl("btnedit") as Button;
                    if (btn != null)
                    {
                        if ((btnExclude.Text != null && btnExclude.Text == "True"))
                        {
                            btn.Text = "UnBlock";
                        }
                        else if ((btnExclude.Text != null && btnExclude.Text == "False"))
                        {
                            btn.Text = "Block";
                        }

                    }
                    Label lblMemType = e.Row.FindControl("lblMemType") as Label;
                    if (lblMemType.Text == "2")
                    {
                        lblMemType.Text = "Trial User";
                    }
                    else
                    {
                        lblMemType.Text = "Paid User";
                    }
                    gvPaidUsrDetails.Columns[1].Visible = false;
                    //gvPaidUsrDetails.Columns[2].Visible = false;
                    //gvPaidUsrDetails.Columns[3].Visible = false;
                    gvPaidUsrDetails.Columns[4].Visible = false;
                    gvPaidUsrDetails.Columns[5].Visible = false;
                    gvPaidUsrDetails.Columns[6].Visible = false;
                    gvPaidUsrDetails.Columns[7].Visible = false;
                    gvPaidUsrDetails.Columns[8].Visible = false;
                    gvPaidUsrDetails.Columns[9].Visible = false;
                    gvPaidUsrDetails.Columns[10].Visible = false;
                    gvPaidUsrDetails.Columns[11].Visible = false;
                    gvPaidUsrDetails.Columns[12].Visible = false;
                }
            }
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the gvPaidUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void gvPaidUsrDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPaidUsrDetails.PageIndex = e.NewPageIndex;
            BindPaidUsrGrid();
        }

        /// <summary>
        /// Handles the RowCommand event of the gvPaidUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvPaidUsrDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;
            Controller controlIsAdmin = new Controller();
            Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
            if (Admin.IsAdmin == false)
            {
                if (e.CommandName == "Update")
                {
                    GridViewRow gvRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    Button btnExclude = (Button)gvRow.FindControl("btnExclude");
                    Label lblUsrId = (Label)gvRow.FindControl("lblUsrId");
                    Guid usrId = new Guid(lblUsrId.Text);
                    if (btnExclude.Text == "False")
                    {
                        UserProfileDetails usrProflDetails = new UserProfileDetails();
                        Guid Userid = usrId;
                        bool block = usrProflDetails.SetExcludeUser(currUserId, Userid);
                        if (block)
                        {
                            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('User Excluded successfully.')</script>");
                            lblSucess.Text = "User Excluded successfully.";
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Error occured during Operation. Please try again later.')</script>");
                            lblError.Text = "Error occured during Operation. Please try again later.";
                        }
                    }
                    else
                    {
                        UserProfileDetails usrProflDetails = new UserProfileDetails();
                        Common.UserProfile Profile = new Common.UserProfile();
                        Guid Userid = usrId;
                        bool block = usrProflDetails.SetUnExludeUser(currUserId, Userid);
                        if (block)
                        {
                            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('User Un-Excluded successfully.')</script>");
                            lblSucess.Text = "User Un-Excluded successfully.";
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Error occured during Operation. Please try again later.')</script>");
                            lblError.Text = "Error occured during Operation. Please try again later.";
                        }
                    }
                }
                //Reset the edit index.
                gvPaidUsrDetails.EditIndex = -1;
                //Bind data to the GridView control.            
                this.BindPaidUsrGrid();
            }

        }

    #endregion

        
    #region Free User Events and Methods         
        
        /// <summary>
        /// Binds the free usr grid.
        /// </summary>
        private void BindFreeUsrGrid()
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;
            //List<UserDetails> lstUsrDetails = new List<UserDetails>();
            UserProfileDetails usrProfDetils = new UserProfileDetails();
            lstfreeUsrProfl = usrProfDetils.GetAllFreeUsrDetails(currUserId);
            gvFreeUsrDetails.DataSource = lstfreeUsrProfl;
            gvFreeUsrDetails.DataBind();
        }

        /// <summary>
        /// Handles the RowUpdating event of the gvFreeUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
        protected void gvFreeUsrDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;
            Controller controlIsAdmin = new Controller();
            Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
            if (Admin.IsAdmin == true)
            {
                Button btnSendMail = (Button)gvPaidUsrDetails.Rows[e.RowIndex].FindControl("btnSendEMail");
                Button btnStatus = (Button)gvFreeUsrDetails.Rows[e.RowIndex].FindControl("btnStatus");
                Button btnExclude = (Button)gvFreeUsrDetails.Rows[e.RowIndex].FindControl("btnExclude");
                TextBox tb = (TextBox)gvFreeUsrDetails.Rows[e.RowIndex].FindControl("txtBlock");
                string txtContent = tb.Text;
                Label lblUsrId = (Label)gvFreeUsrDetails.Rows[e.RowIndex].FindControl("lblUId");
                Label lblEmail = (Label)gvFreeUsrDetails.Rows[e.RowIndex].FindControl("lblEmailId");
                Label lblContactName = (Label)gvFreeUsrDetails.Rows[e.RowIndex].FindControl("lblCntName");
                string contactName = lblContactName.Text;
                Guid usrId = new Guid(lblUsrId.Text);

                if (btnStatus.Text == "False")
                {
                    UserProfileDetails usrProflDetails = new UserProfileDetails();
                    Common.UserProfile Profile = new Common.UserProfile();
                    Profile.ReasonToBlock = txtContent;
                    Profile.UserId = usrId;
                    bool block = usrProflDetails.SetBlockUser(Profile);


                    if (block)
                    {
                        //Mail sends to Block  User
                        string userName = "Administrator";
                        string txtSubject = "Your ICBrowser Account has been Blocked";
                        string toEmailId = lblEmail.Text;

                        Hashtable hash = new Hashtable { { "ToUserName", contactName }, { "FromUserName", userName }, { "Subject", txtSubject }, { "Message", txtContent } };
                        EmailFactory mailFactory = new EmailFactory();
                        Email mail = mailFactory.SendEmailBySellerId(toEmailId, "support@icbrowser.com", txtSubject, txtContent, hash);

                        if (mail.Send())
                        {
                            lblscs.Visible = true;
                            lblscs.Text = "User blocked successfully. Mail sent to user.";
                        }
                        else
                        {
                            lblerr.Visible = true;
                            lblerr.Text = "User Blocked. Error Occurred in sending mail. Please try again later.";
                        }
                    }
                    else
                    {
                        lblerr.Text = "Error occured during Operation. Please try again later.";
                    }
                }
                else
                {
                    UserProfileDetails usrProflDetails = new UserProfileDetails();
                    Common.UserProfile Profile = new Common.UserProfile();
                    Profile.ReasonToUnblock = txtContent;
                    Profile.UserId = usrId;
                    bool block = usrProflDetails.SetUnBlockUser(Profile);


                    if (block)
                    {
                        //Mail sends to UnBlock  User
                        string userName = "Administrator";
                        string txtSubject = "Your ICBrowser Account has been UnBlocked";
                        string toEmailId = lblEmail.Text;

                        Hashtable hash = new Hashtable { { "ToUserName", contactName }, { "FromUserName", userName }, { "Subject", txtSubject }, { "Message", txtContent } };
                        EmailFactory mailFactory = new EmailFactory();
                        Email mail = mailFactory.SendEmailBySellerId(toEmailId, "support@icbrowser.com", txtSubject, txtContent, hash);

                        if (mail.Send())
                        {
                            lblscs.Visible = true;
                            lblscs.Text = "User unblocked successfully. Mail sent to user.";
                        }
                        else
                        {
                            lblerr.Visible = true;
                            lblerr.Text = "User unblocked. Error Occurred in sending mail. Please try again later.";
                        }
                    }
                    else
                    {
                        lblerr.Text = "Error occured during Operation. Please try again later.";
                    }

                }
            }
            //Reset the edit index.
            gvFreeUsrDetails.EditIndex = -1;
            //Bind data to the GridView control.            
            this.BindFreeUsrGrid();
        }

        /// <summary>
        /// Handles the RowCancelingEdit event of the gvFreeUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
        protected void gvFreeUsrDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            gvFreeUsrDetails.EditIndex = -1;
            //Bind data to the GridView control.         
            BindFreeUsrGrid();
        }

        /// <summary>
        /// Handles the RowEditing event of the gvFreeUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
        protected void gvFreeUsrDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (Session["Search"] != null)
            {
                gvFreeUsrDetails.EditIndex = e.NewEditIndex;
                gvFreeUsrDetails.DataSource = Session["Search"];
                gvFreeUsrDetails.DataBind();
                Session["Search"] = null;
            }
            else
            {
                gvFreeUsrDetails.EditIndex = e.NewEditIndex;
                BindFreeUsrGrid();
            }
        }

        /// <summary>
        /// Handles the RowDataBound event of the gvFreeUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvFreeUsrDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;
            Controller controlIsAdmin = new Controller();
            Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
            if (Admin.IsAdmin == true)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnStatus = e.Row.FindControl("btnStatus") as Button;
                    Button btn = e.Row.FindControl("btnedt") as Button;
                    if (btn != null)
                    {
                        if ((btnStatus.Text != null && btnStatus.Text == "True"))
                        {
                            btn.Text = "UnBlock";
                        }
                        else if ((btnStatus.Text != null && btnStatus.Text == "False"))
                        {
                            btn.Text = "Block";
                        }
                    }
                    gvFreeUsrDetails.Columns[3].Visible = false;
                }
            }
            else
            {
                pnlFreeUserDetail.Visible = false;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnExclude = e.Row.FindControl("btnExclude") as Button;
                    Button btn = e.Row.FindControl("btnedt") as Button;
                    if (btn != null)
                    {
                        if ((btnExclude.Text != null && btnExclude.Text == "True"))
                        {
                            btn.Text = "UnBlock";
                        }
                        else if ((btnExclude.Text != null && btnExclude.Text == "False"))
                        {
                            btn.Text = "Block";
                        }

                    }
                    gvFreeUsrDetails.Columns[1].Visible = false;
                    //gvFreeUsrDetails.Columns[2].Visible = false;
                    //gvFreeUsrDetails.Columns[3].Visible = false;
                    gvFreeUsrDetails.Columns[4].Visible = false;
                    gvFreeUsrDetails.Columns[5].Visible = false;
                    gvFreeUsrDetails.Columns[6].Visible = false;
                    gvFreeUsrDetails.Columns[7].Visible = false;
                    gvFreeUsrDetails.Columns[8].Visible = false;
                    gvFreeUsrDetails.Columns[9].Visible = false;
                    gvFreeUsrDetails.Columns[10].Visible = false;
                }
            }

        }

        /// <summary>
        /// Handles the Click event of the imgbtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;
            string searchVal = txtSrchd.Text;
            UserProfileDetails usrProfDetils = new UserProfileDetails();
            lstfreeUsrProfl = usrProfDetils.GetAllFreeUsrDetails(currUserId);
            if (ddlFreeUsr.SelectedIndex == 1)
            {
                var searchedData = from s in lstfreeUsrProfl
                                   where s.UserName.ToLower().Contains(searchVal.ToLower())
                                   select s;
                gvFreeUsrDetails.DataSource = searchedData.ToList();
                gvFreeUsrDetails.DataBind();
                Session["Search"] = gvFreeUsrDetails.DataSource;
            }
            else if (ddlFreeUsr.SelectedIndex == 2)
            {
                var searchedData = from s in lstfreeUsrProfl
                                   where s.CompanyName.ToLower().Contains(searchVal.ToLower())
                                   select s;
                gvFreeUsrDetails.DataSource = searchedData.ToList();
                gvFreeUsrDetails.DataBind();
                Session["Search"] = gvFreeUsrDetails.DataSource;
            }
            else if (ddlFreeUsr.SelectedIndex == 3)
            {
                var searchedData = from s in lstfreeUsrProfl
                                   where s.ContactName.ToLower().Contains(searchVal.ToLower())
                                   select s;
                gvFreeUsrDetails.DataSource = searchedData.ToList();
                gvFreeUsrDetails.DataBind();
                Session["Search"] = gvFreeUsrDetails.DataSource;
            }
            else if (ddlFreeUsr.SelectedIndex == 4)
            {
                var searchedData = from s in lstfreeUsrProfl
                                   where s.OwnerName.ToLower().Contains(searchVal.ToLower())
                                   select s;
                gvFreeUsrDetails.DataSource = searchedData.ToList();
                gvFreeUsrDetails.DataBind();
                Session["Search"] = gvFreeUsrDetails.DataSource;
            }
        }

        /// <summary>
        /// Handles the Click event of the imgClr control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void imgClr_Click(object sender, ImageClickEventArgs e)
        {
            txtSrchd.Text = string.Empty;
            ddlFreeUsr.SelectedIndex = 0;
            gvPaidUsrDetails.EditIndex = -1;
            BindFreeUsrGrid();
            lblerr.Visible = false;
            lblscs.Visible = false;

        }

        /// <summary>
        /// Handles the PageIndexChanging event of the gvFreeUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void gvFreeUsrDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFreeUsrDetails.PageIndex = e.NewPageIndex;
            BindFreeUsrGrid();
        }

        /// <summary>
        /// Handles the Click event of the imgCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void imgCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderBlockUnblock.Hide();
        }

        /// <summary>
        /// Handles the Click event of the btnPreviewClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnPreviewClose_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderBlockUnblock.Hide();
        }

        /// <summary>
        /// Handles the Click event of the btnReasnPaid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnReasnPaid_Click(object sender, EventArgs e)
        {
            try
            {
                UserProfileDetails profiledetais = new UserProfileDetails();
                Common.UserProfile Profile = new Common.UserProfile();

                LinkButton btnReasn = sender as LinkButton;
                GridViewRow GVEmployeeRow = (GridViewRow)btnReasn.NamingContainer;

                string userId = (GVEmployeeRow.FindControl("lblUsrId") as Label).Text;
                Guid usrId = new Guid(userId);
                Profile = profiledetais.GetUserProfileDetails(usrId);
                lblReasntoblockValue.Text = Profile.ReasonToBlock;
                lblReasontoUnblckValue.Text = Profile.ReasonToUnblock;

                this.ModalPopupExtenderBlockUnblock.Show();

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the btnReasnFree control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnReasnFree_Click(object sender, EventArgs e)
        {
            try
            {

                UserProfileDetails profiledetais = new UserProfileDetails();
                Common.UserProfile Profile = new Common.UserProfile();

                LinkButton btnReason = sender as LinkButton;

                GridViewRow GVEmployeeRow = (GridViewRow)btnReason.NamingContainer;
                string userId = (GVEmployeeRow.FindControl("lblUId") as Label).Text;
                Guid usrId = new Guid(userId);
                Profile = profiledetais.GetUserProfileDetails(usrId);
                lblReasntoblockValue.Text = Profile.ReasonToBlock;
                lblReasontoUnblckValue.Text = Profile.ReasonToUnblock;
                //usrProfDetils.UpdateUsersMembershipExpiry(User);
                this.ModalPopupExtenderBlockUnblock.Show();

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the RowCommand event of the gvFreeUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvFreeUsrDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;
            Controller controlIsAdmin = new Controller();
            Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
            if (Admin.IsAdmin == false)
            {
                if (e.CommandName == "Update")
                {
                    GridViewRow gvRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    Button btnExclude = (Button)gvRow.FindControl("btnExclude");
                    Label lblUsrId = (Label)gvRow.FindControl("lblUId");
                    Guid usrId = new Guid(lblUsrId.Text);
                    if (btnExclude.Text == "False")
                    {
                        UserProfileDetails usrProflDetails = new UserProfileDetails();
                        Guid Userid = usrId;
                        bool block = usrProflDetails.SetExcludeUser(currUserId, Userid);
                        if (block)
                        {
                            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('User Excluded successfully.')</script>");
                            lblSucess.Text = "User Excluded successfully.";
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Error occured during Operation. Please try again later.')</script>");
                            lblError.Text = "Error occured during Operation. Please try again later.";
                        }
                    }
                    else
                    {
                        UserProfileDetails usrProflDetails = new UserProfileDetails();
                        Common.UserProfile Profile = new Common.UserProfile();
                        Guid Userid = usrId;
                        bool block = usrProflDetails.SetUnExludeUser(currUserId, Userid);
                        if (block)
                        {
                            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('User Un-Excluded successfully.')</script>");
                            lblSucess.Text = "User Un-Excluded successfully.";
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>alert('Error occured during Operation. Please try again later.')</script>");
                            lblError.Text = "Error occured during Operation. Please try again later.";
                        }
                    }
                }
            }
            //Reset the edit index.
            gvFreeUsrDetails.EditIndex = -1;
            //Bind data to the GridView control.            
            this.BindFreeUsrGrid();
        }

        #endregion
    }

}