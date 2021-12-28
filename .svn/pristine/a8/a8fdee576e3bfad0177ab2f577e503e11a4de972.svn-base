using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICBrowser.Web.Controls
{
    public partial class SellerInventories : System.Web.UI.UserControl
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

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

                data.ComponentName = this.txtPartNumber.Text.Trim();
                data.BrandName = this.txtBrandname.Text.Trim();
                data.Description = this.txtDescription.Text.Trim();
                data.datecode = this.txtDateCode.Text.Trim();

                //if (!this.txtCountry.Text.Trim().Equals(""))
                //    data.country = this.txtCountry.Text.Trim();
                //else
                //    data.country = null;  ddlCountry

                //if (this.ddlCountry.SelectedIndex > 0)
                //{
                //    data.country = this.ddlCountry.SelectedItem.Text;
                //}
                //else
                //{
                //    data.country = null;
                //}
                data.country = null;
                data.stockstatus = Convert.ToInt32(ddlStockStatus.SelectedItem.Value);
                data.package = this.txtPackage.Text.Trim();

                //-------Stock In hand ----------//
                //if (this.txtStockInhand.Text.Equals(""))
                //{
                //    data.StockInHand = 0;
                //}
                //else
                //{
                //    data.StockInHand = Convert.ToInt32(this.txtStockInhand.Text.Trim());
                //}
                data.StockInHand = null;
                if (txtQuantity.Text != "")
                {
                    data.Quantity = Convert.ToInt32(this.txtQuantity.Text.Trim());
                }

                //-------Quantity ----------//
                //if (this.txtQuantity.Text.Equals(""))
                //{
                //    data.Quantity = null;
                //}
                //else
                //{
                //  data.Quantity = Convert.ToInt32(this.txtQuantity.Text);
                //}

                //-------Price In INR ----------//
                //if (this.txtPriceinINR.Text.Trim().Equals(""))
                //{
                //    data.PriceInINR = 0;
                //}
                //else
                //{
                //    data.PriceInINR = Convert.ToDecimal(this.txtPriceinINR.Text.Trim());
                //}

                //-------Price In USD----------//
                if (this.txtPriceInUSD.Text.Trim().Equals(""))
                {
                    data.PriceInUSD = 0;
                }
                else
                {
                    data.PriceInUSD = Convert.ToDecimal(this.txtPriceInUSD.Text.Trim());
                }
                data.PriceInINR = null;
                data.PriceInCNY = null;

                //-------Price In CNY----------//
                //if (this.txtPriceInCNY.Text.Trim().Equals(""))
                //{
                //    data.PriceInCNY = 0;
                //}
                //else
                //{
                //    data.PriceInCNY = Convert.ToDecimal(this.txtPriceInCNY.Text.Trim());
                //}

                //-------stock Status--------//
                if (this.ddlStockStatus.SelectedIndex == 0)
                {
                    data.stockstatus = 0;
                }
                else
                {
                    data.stockstatus = Convert.ToInt32(ddlStockStatus.SelectedItem.Value);
                }

                return data;
            }
            set
            {

                this.txtPartNumber.Text = value.ComponentName;
                this.txtBrandname.Text = value.BrandName;
                this.txtDescription.Text = value.Description;
                this.txtDateCode.Text = value.datecode;
                // this.txtCountry.Text = value.country;
                //this.ddlCountry.SelectedItem.Value = value.country.ToString();
                this.ddlStockStatus.SelectedItem.Value = value.stockstatus.ToString();
                this.txtPackage.Text = value.package;
                ddlStockStatus.SelectedValue = value.stockstatus.ToString();

                //if (value.StockInHand.HasValue)
                //{
                //this.txtStockInhand.Text = Convert.ToString(value.StockInHand);
                //}


                //if (value.Quantity.HasValue)
                //{
                this.txtQuantity.Text = Convert.ToString(value.Quantity);
                //}

                //if (value.PriceInINR.HasValue)
                //{
                //this.txtPriceinINR.Text = Convert.ToString(value.PriceInINR);
                //}

                //if (value.PriceInUSD.HasValue)
                //{
                this.txtPriceInUSD.Text = Convert.ToString(value.PriceInUSD);
                //}

                //if (value.PriceInCNY.HasValue)
                //{
                //this.txtPriceInCNY.Text = Convert.ToString(value.PriceInCNY);
                //}


            }
        }

        /// <summary>
        /// Gets or sets the buyer requirement data.
        /// </summary>
        /// <value>The buyer requirement data.</value>
        public ICBrowser.Common.BuyersRequirements BuyerRequirementData
        {
            get
            {
                ICBrowser.Common.BuyersRequirements data = new ICBrowser.Common.BuyersRequirements();
                data.ComponentName = this.txtPartNumber.Text.Trim();
                if (txtQuantity.Text.Trim() != "")
                {
                    data.Quantity = Convert.ToInt32(this.txtQuantity.Text.Trim());
                }
                data.BrandName = this.txtBrandname.Text.Trim();
                data.DateCode = this.txtDateCode.Text.Trim();
                data.Package = this.txtPackage.Text.Trim();
                data.Description = this.txtDescription.Text.Trim();
                if (ddlStockStatus.SelectedItem.Text.Trim().Equals("PO"))
                {
                    data.RequirementwithPO = true;
                }
                else
                {
                    data.RequirementwithPO = false;
                }
                if (this.txtPriceInUSD.Text.Trim() != "")
                {
                    data.PriceInUSD = Convert.ToDecimal(this.txtPriceInUSD.Text.Trim());
                }
                else
                {
                    data.PriceInUSD = null;
                }
                //  data.Country = this.txtCountry.Text.Trim();
                //   data.Country = this.ddlCountry.SelectedItem.Value.Trim();
                //if (this.ddlCountry.SelectedIndex > 0)
                //{
                //    data.Country = this.ddlCountry.SelectedItem.Text;
                //}
                //else
                //{
                //    data.Country = null;
                //}
                data.Country = null;
                return data;
            }
            set
            {
                this.txtPartNumber.Text = value.ComponentName;// Part Number
                this.txtQuantity.Text = Convert.ToString(value.Quantity);
                this.txtBrandname.Text = value.BrandName;// Make
                this.txtDateCode.Text = value.DateCode;
                this.txtPackage.Text = value.Package;
                this.txtDescription.Text = value.Description;
                this.ddlStockStatus.SelectedValue = Convert.ToString(value.RequirementwithPO);
                this.txtPriceInUSD.Text = Convert.ToString(value.PriceInUSD);
                //  this.txtCountry.Text = value.Country;
                //this.ddlCountry.SelectedValue = value.Country;
            }
        }
    }
}