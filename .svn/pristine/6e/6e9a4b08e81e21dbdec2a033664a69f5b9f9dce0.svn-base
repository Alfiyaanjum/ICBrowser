using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Linq.Expressions;
using System.Collections;
using System.Data;
using System.ComponentModel;
using System.Web.Security;

namespace ICBrowser.Web
{
    public partial class DeclineUser : BasePage
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSucess.Visible = false;
            lblError.Visible = false;
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;

            Controller controlIsAdmin = new Controller();
            Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
            if (Admin.IsAdmin == true)
            {
                this.BindGrid();
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }


        }


        /// <summary>
        /// Binds the grid.
        /// </summary>
        private void BindGrid()
        {
            DeclineUserDetails dud = new DeclineUserDetails();
            gvDeclineUser.DataSource = dud.GetDeclineUserDetails();
            gvDeclineUser.DataBind();
        }

        /// <summary>
        /// Handles the RowDataBound event of the gvDeclineUser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvDeclineUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblMemType = e.Row.FindControl("lblMemType") as Label;
                    Label lblOffMemType = e.Row.FindControl("lblOffMemType") as Label;
                    int OffMemType = Convert.ToInt32(lblOffMemType.Text);
                    if (lblMemType.Text == "1")
                    {
                        if (OffMemType >= 3)
                        {
                            lblMemType.Text = "Offline Paid";
                        }
                        else
                        {
                            lblMemType.Text = "Free";
                        }

                    }
                    else if (lblMemType.Text == "2")
                    {
                        lblMemType.Text = "Trial";
                    }
                    else
                    {
                        lblMemType.Text = "Paid";
                    }
                }


            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the gvDeclineUser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void gvDeclineUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDeclineUser.PageIndex = e.NewPageIndex;
            gvDeclineUser.DataBind();
        }

        //protected void gvDeclineUser_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    IList<UserDetails> Ilist = gvDeclineUser.DataSource as IList<UserDetails>;
        //    DataTable dt = ToDataTable<UserDetails>(Ilist);
        //    if (dt != null)
        //    {
        //        DataView dataView = new DataView(dt);
        //        dataView.Sort = e.SortExpression + " " + ConvertSortDirection(e.SortDirection);

        //        gvDeclineUser.DataSource = dataView;
        //        gvDeclineUser.DataBind();
        //    }
        //}


        //private string ConvertSortDirection(SortDirection sortDirection)
        //{
        //    string newSortDirection = String.Empty;

        //    switch (sortDirection)
        //    {
        //        case SortDirection.Ascending:
        //            newSortDirection = "ASC";
        //            break;

        //        case SortDirection.Descending:
        //            newSortDirection = "DESC";
        //            break;
        //    }
        //    return newSortDirection;
        //}

        /// <summary>
        /// Handles the Click event of the btnReasnDecline control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnReasnDecline_Click(object sender, EventArgs e)
        {
            try
            {
                UserProfileDetails profiledetais = new UserProfileDetails();
                Common.UserProfile Profile = new Common.UserProfile();

                LinkButton btnReasn = sender as LinkButton;
                GridViewRow GVEmployeeRow = (GridViewRow)btnReasn.NamingContainer;

                string userId = (GVEmployeeRow.FindControl("lnkSellerId") as LinkButton).Text;
                Guid usrId = new Guid(userId);
                Profile = profiledetais.GetUserProfileDetails(usrId);
                lblReasntoDeclineValue.Text = Profile.ReasonToDecline;

                this.ModalPopupExtenderDeclineUser.Show();

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the imgCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void imgCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderDeclineUser.Hide();
        }

        /// <summary>
        /// Handles the Click event of the btnPreviewClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnPreviewClose_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderDeclineUser.Hide();
        }
    }
}