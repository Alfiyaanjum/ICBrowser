using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Security;
using ICBrowser.Common;
using ICBrowser.Business;

namespace ICBrowser.Web
{
    public partial class TransactionResponse : BasePage
    {
        //int SellerID;
        int typeOfMembership;
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack && Session["MerchantOrder"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Params["responseparams"]) && !Request.Params["responseparams"].Contains("|FAIL|"))
                    {
                        HandleValidResponse();
                    }
                    else if (!string.IsNullOrEmpty(Request.Params["responseparams"]) &&
                             Request.Params["responseparams"].Contains("|FAIL|"))
                    {
                        HandleErrorResponse();
                    }
                    Session["MerchantOrder"] = null;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the error response.
        /// </summary>
        private void HandleErrorResponse()
        {
            try
            {
                string[] data = Request.Params["responseparams"].Split('|');

                TransactionReponse.Direcpayreferenceid = data[0];
                TransactionReponse.Flag = (TransactionState)Enum.Parse(typeof(TransactionState), Convert.ToString(data[1]));
                TransactionReponse.Description = data[2];

                UpdateTransactionStatus();

                lblReferenceId.Text = TransactionReponse.Direcpayreferenceid;
                lblError.Text = "Transaction Failed";
                divStatus.Visible = false;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the valid response.
        /// </summary>
        private void HandleValidResponse()
        {
            try
            {
                string[] data = Request.Params["responseparams"].Split('|');
                TransactionReponse.Direcpayreferenceid = data[0];
                TransactionReponse.Flag = (TransactionState)Enum.Parse(typeof(TransactionState), Convert.ToString(data[1]));
                TransactionReponse.Country = data[2];
                TransactionReponse.Currency = data[3];
                TransactionReponse.Otherdetails = (MembershipType)Enum.Parse(typeof(MembershipType), Convert.ToString(data[4]));
                TransactionReponse.Merchantorderno = data[5];
                TransactionReponse.Amount = Convert.ToDecimal(data[6]);

                UpdateTransactionStatus();

                UpdateUserMembershipDetails();

                lblOrderId.Text = data[5];
                lblStatus.Text = TransactionReponse.Flag.ToString();
                lblAmount.Text = TransactionReponse.Amount.ToString();
                grid.Visible = false;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Updates the transaction status.
        /// </summary>
        private void UpdateTransactionStatus()
        {
            try
            {
                string merchantOrderId = Convert.ToString(Session["MerchantOrder"]);

                TransactionDetails transaction = Master.PageController.GetTranscationDetailById(merchantOrderId);

                //SellerID = transaction.SellerID;
                typeOfMembership = Convert.ToInt32(TransactionReponse.Otherdetails);

                transaction.DirectPayReferenceID = Convert.ToInt64(TransactionReponse.Direcpayreferenceid);
                transaction.MerchantOrderNo = TransactionReponse.Merchantorderno;
                transaction.TransactionDate = DateTime.Now;
                transaction.Status = Convert.ToInt32(TransactionReponse.Flag);
                transaction.Amount = TransactionReponse.Amount;
                transaction.MembershipType = Convert.ToInt32(TransactionReponse.Otherdetails);
                transaction.Description = TransactionReponse.Description;

                Master.PageController.UpdateTransaction(transaction);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Updates the user membership details.
        /// </summary>
        private void UpdateUserMembershipDetails()
        {
            try
            {
                UserMembershipDetails obj = Master.PageController.GetUserMembershipDetailById(Membership.GetUser().ProviderUserKey.ToString());

                InventoryGridDetails igd = new InventoryGridDetails();

                TypeOfMembership objMembershipType = igd.GetMembershipDetails(typeOfMembership);
                obj.MembershipExpiryDate = DateTime.Now.AddDays(objMembershipType.Duration);
                obj.TypeOfMembership = typeOfMembership;
                obj.PaymentStatus = true;

                Master.PageController.UpdateUserMembershipDetails(obj);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOkay control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnOkay_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SellerUploadedInventory.aspx", true);
        }
    }
}