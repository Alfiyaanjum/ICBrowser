using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using ICBrowser.Web;


namespace ICBrowser.Web.Controls
{
    public partial class AddRequirement : System.Web.UI.UserControl
    {
        /// <summary>
        /// Sets a value indicating whether [show remove].
        /// </summary>
        /// <value><c>true</c> if [show remove]; otherwise, <c>false</c>.</value>
        public bool ShowRemove
        {
            set
            {
                btnRemove.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public ICBrowser.Common.BuyersRequirements Data
        {
            get
            {
                ICBrowser.Common.BuyersRequirements data = new ICBrowser.Common.BuyersRequirements();
                data.ComponentName = this.tbxPartNumber.Text;
                //if (this.tbxReqPopupQuantity.Text.Equals(""))
                //{
                //    data.Quantity = null;
                //}
                //else
                //{
                    data.Quantity = Convert.ToInt32(this.tbxReqPopupQuantity.Text);
                //}
                data.Description = this.tbxReqPopupDescription.Text;
                data.BrandName = this.tbxMake.Text;
                if (this.txtRequiredBefore.Text.Equals(""))
                {
                    data.RequiredBefore = null;
                }
                else
                {
                    data.RequiredBefore = Convert.ToDateTime(this.txtRequiredBefore.Text + " " + DateTime.Now.ToLongTimeString());
                }
                return data;
            }
            set
            {
                this.tbxPartNumber.Text = value.ComponentName;
                //if (value.Quantity.HasValue)
                //{
                    this.tbxReqPopupQuantity.Text = Convert.ToString(value.Quantity);
                //}
                this.tbxReqPopupDescription.Text = value.Description;
                this.tbxMake.Text = value.BrandName;
                if (value.RequiredBefore.HasValue)
                {
                    this.txtRequiredBefore.Text = value.RequiredBefore.Value.ToString("dd-MMM-yyyy");
                }
                //this.txtRequiredBefore.Text = Convert.ToString(value.RequiredBefore);
            }
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            txtRequiredBefore.Attributes.Add("readonly", "readonly");
        }

        /// <summary>
        /// Handles the Click event of the btnRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnRemove_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
        }
    }
}