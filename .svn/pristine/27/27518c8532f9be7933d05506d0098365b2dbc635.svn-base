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
    public partial class AddInventory : System.Web.UI.UserControl
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
        public ICBrowser.Common.Component Data
        {
            get
            {
                ICBrowser.Common.Component data = new ICBrowser.Common.Component();

                data.ComponentName = this.TxtComponentName.Text;
                data.BrandName = this.TxtBrandName.Text;
                data.Description = this.TxtDescription.Text;

                if (this.txtpriceinCNY.Text.Equals(""))
                {
                    data.PriceInCNY = null;
                }
                else
                {
                    data.PriceInCNY = Convert.ToDecimal(this.txtpriceinCNY.Text);
                }


                if (this.txtAvailfrom.Text.Equals(""))
                {
                    data.AvailableFrom = null;
                }
                else
                {
                    // data.AvailableFrom = Convert.ToDateTime(this.txtAvailfrom.Text);
                    data.AvailableFrom = Convert.ToDateTime(this.txtAvailfrom.Text + " " + DateTime.Now.ToLongTimeString());
                }


                //if (this.TxtStockInHand.Text.Equals(""))
                //{
                //    data.StockInHand = null;
                //}
                //else
                //{
                    data.StockInHand = Convert.ToInt32(this.TxtStockInHand.Text);
                //}


                //if (this.TxtQuantity.Text.ToString().Equals(""))
                //{
                //    data.Quantity = null;
                //}
                //else
                //{
                    data.Quantity = Convert.ToInt32(this.TxtQuantity.Text);
                //}


                if (this.TxtPriceInINR.Text.ToString().Equals(""))
                {
                    data.PriceInINR = null;
                }
                else
                {
                    data.PriceInINR = Convert.ToDecimal(this.TxtPriceInINR.Text);
                }


                if (this.TxtPriceInUSD.Text.ToString().Equals(""))
                {
                    data.PriceInUSD = null;
                }
                else
                {
                    data.PriceInUSD = Convert.ToDecimal(this.TxtPriceInUSD.Text);
                }

                //data.DataSheetFileName = "";
                //data.DataSheetURL = "";

                if (this.FuploadAdd.HasFile)
                {
                    data.DataSheetFileName = this.FuploadAdd.FileName;
                    data.DataSheetURL = "";
                }
                else
                {
                    if (this.txtDatasheetlink.Text != "")
                    {
                        data.DataSheetURL = this.txtDatasheetlink.Text;
                        data.DataSheetFileName = "";
                    }

                    else
                    {
                        data.DataSheetFileName = "";
                        data.DataSheetURL = "";
                    }
                }

                return data;
            }
            set
            {
                this.TxtComponentName.Text = value.ComponentName;
                this.TxtBrandName.Text = value.BrandName;
                this.TxtDescription.Text = value.Description;
                this.txtDatasheetlink.Text = value.DataSheetURL;


                if (value.AvailableFrom.HasValue)
                {
                    this.txtAvailfrom.Text = Convert.ToString(value.AvailableFrom);
                }

                //if (value.StockInHand)
                //{
                    this.TxtStockInHand.Text = Convert.ToString(value.StockInHand);
                //}

                //if (value.Quantity.HasValue)
                //{
                    this.TxtQuantity.Text = Convert.ToString(value.Quantity);
                //}

                if (value.PriceInINR.HasValue)
                {
                    this.TxtPriceInINR.Text = Convert.ToString(value.PriceInINR);
                }

                if (value.PriceInUSD.HasValue)
                {
                    this.TxtPriceInUSD.Text = Convert.ToString(value.PriceInUSD);
                }

                if (value.PriceInCNY.HasValue)
                {
                    this.txtpriceinCNY.Text = Convert.ToString(value.PriceInCNY);
                }
            }
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            txtAvailfrom.Attributes.Add("readonly", "readonly");
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