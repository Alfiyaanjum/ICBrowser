using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Web.Security;


namespace ICBrowser.Web
{
    public partial class AdminRating : BasePage
    {
        public Guid currUserId;
        DataTable dtablequestion = new DataTable();
        UserRatings objUserRatings = new UserRatings();

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            currUserId = (Guid)userToLogin.ProviderUserKey;

            Controller controlIsAdmin = new Controller();
            Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
            if (Admin.IsAdmin == true)
            {
                if (!IsPostBack)
                {
                    loadgrid();
                 
                }
                lblErrorMessage.Visible = false;
             
            }

            else
            {
                Response.Redirect("Default.aspx", true);
            }
        }


        /// <summary>
        /// bind the grid
        /// </summary>
        public void loadgrid()
        {
            //DataTable dtablequestion = new DataTable();
            Business.UserRatings objUserRatings = new Business.UserRatings();

            try
            {
                dtablequestion = objUserRatings.getRatingQuestion();
                if (dtablequestion.Rows.Count > 0)
                {
                    grdQuestion.DataSource = dtablequestion;
                    grdQuestion.DataBind();
                }
                else
                {
                    grdQuestion.DataSource = null;
                    grdQuestion.DataBind();
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// Handles the RowDataBound event of the grdQuestion control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void grdQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow && this.grdQuestion.EditIndex > -1 && e.Row.RowIndex == this.grdQuestion.EditIndex)
            {
                Label lblTypeMember = e.Row.FindControl("lbltype") as Label;
                if (lblTypeMember.Text == "False")
                {
                    lblTypeMember.Text = "Buyer";
                }
                else
                {
                    lblTypeMember.Text = "Seller";
                }

            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblTypeMember = e.Row.FindControl("lbltype") as Label;
                    if (lblTypeMember.Text == "False")
                    {
                        lblTypeMember.Text = "Buyer";
                    }
                    else
                    {
                        lblTypeMember.Text = "Seller";
                    }
                }
            }
        }

        /// <summary>
        /// Handles the RowEditing event of the grdQuestion control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
        protected void grdQuestion_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                grdQuestion.EditIndex = e.NewEditIndex;  //code that Edits the current row   
                loadgrid();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// Handles the RowDeleting event of the grdQuestion control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
        protected void grdQuestion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int questionId = Convert.ToInt32(((Label)grdQuestion.Rows[e.RowIndex].FindControl("lblQuestionId")).Text);
                string typename = ((Label)grdQuestion.Rows[e.RowIndex].FindControl("lbltype")).Text;
                bool type;
                int deletestatus = 0;
                if (typename == "Buyer")
                {
                    type = false;
                    deletestatus = objUserRatings.deleteRatingQuestion(questionId, type);
                    ShowMessage(deletestatus);
                }
                else
                {
                    type = true;
                    deletestatus = objUserRatings.deleteRatingQuestion(questionId, type);
                    ShowMessage(deletestatus);
                }
           
                loadgrid();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }
        /// <summary>
        /// method just to display message that atleast 1 question of a type is required
        /// </summary>
        /// <param name="deletestatus"></param>
        private void ShowMessage(int deletestatus)
        {
            try
            {
                if (deletestatus == 0)
                {
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Atleast 1 Question of a Type is Required.";
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        /// <summary>
        /// Handles the RowCommand event of the grdQuestion control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void grdQuestion_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        /// <summary>
        /// Handles the RowDeleted event of the grdQuestion control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewDeletedEventArgs"/> instance containing the event data.</param>
        protected void grdQuestion_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        /// <summary>
        /// Handles the RowUpdated event of the grdQuestion control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewUpdatedEventArgs"/> instance containing the event data.</param>
        protected void grdQuestion_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            e.KeepInEditMode = false;
        }

        /// <summary>
        /// Handles the RowUpdating event of the grdQuestion control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
        protected void grdQuestion_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string ratngQuestion = ((TextBox)grdQuestion.Rows[e.RowIndex].FindControl("txtgrdquestion")).Text;
             
                int questionId = Convert.ToInt32(((Label)grdQuestion.Rows[e.RowIndex].FindControl("lblQuestionId")).Text);
                int insertUpdateStatus = objUserRatings.UpdateRatingQuestions(ratngQuestion, questionId);
        
                grdQuestion.EditIndex = -1; //reset the edit index and then bind the grid
                loadgrid();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// Handles the RowCancelingEdit event of the grdQuestion control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
        protected void grdQuestion_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdQuestion.EditIndex = -1;
            loadgrid();


        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Business.UserRatings objUserRatings = new Business.UserRatings();
            int insertstatus = 0;
            try
            {
                string ratingQuestion = txtQuestion.Text;
                int typeRate = Convert.ToInt32(ddlTypeofMember.SelectedItem.Value);
                bool rateType;
                if (typeRate == 0)
                {
                    rateType = false; // Insert Type Of Question for Buyer
                }
                else
                {
                    rateType = true; // Insert Type Of Question for Seller
                }
                insertstatus = objUserRatings.InsertRatingQuestions(currUserId, ratingQuestion, rateType);

                if (insertstatus == 0)
                {
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Not more than 5 questions can be added for a Type.";
                }

                clearAll();
                loadgrid();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        /// <summary>
        /// Clears all.
        /// </summary>
        public void clearAll()
        {
            txtQuestion.Text = string.Empty;
            ddlTypeofMember.ClearSelection();
        }

    }
}