using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ICBrowser.Common;
using ICBrowser.Business;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace ICBrowser.Web
{
    public partial class ComponentSearchFiltered : BasePage
    {
        List<Common.Component> values = new List<Common.Component>();
        Hashtable htMoreDetailsInfo = new Hashtable();
        public static string SelectedTabForSearch = string.Empty;
        MembershipUser userToLogin = Membership.GetUser();
        Guid userId;
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            userId = (Guid)userToLogin.ProviderUserKey;
            Common.UserProfile objuserpro = new Common.UserProfile();
            UserProfileDetails profiledetais = new UserProfileDetails();
            int memTypeId = 0;
            objuserpro = profiledetais.GetUserProfileDetails(userId);
            memTypeId = objuserpro.TypeOfMembership;
            if (memTypeId >= 1)
            {
                string RequestType = Request.QueryString["RequestType"];

                //if (!RequestType.Equals(if(string.IsNullOrEmpty(ViewState["CurrentPage"]) ? ViewState["CurrentPage"].ToString() : ))

                if (RequestType != null)
                {
                    if (RequestType.Equals("Requirements"))
                    {
                        pnlStockStatus.Visible = false;
                        grdRequirementSearchFilterResults.Visible = true;
                        grdComponentSearchFilterResults.Visible = false;
                        pnlPO.Visible = true;
                        lblComponentHeader.Visible = false;
                        lblRequirementHeader.Visible = true;
                    }
                    else
                    {
                        pnlStockStatus.Visible = true;
                        grdRequirementSearchFilterResults.Visible = false;
                        grdComponentSearchFilterResults.Visible = true;
                        pnlPO.Visible = false;

                        lblComponentHeader.Visible = true;
                        lblRequirementHeader.Visible = false;
                    }

                    if (!Page.IsPostBack)
                    {
                        ViewState["ActualPartNo"] = "";
                        btnClear_Click(null, null);
                        ViewState["CurrentPage"] = RequestType;

                        if (Session["SearchHistory"] != null && Session["MsgCancld"] != null)
                        {
                            if (Session["MsgCancld"].ToString().Equals("Yes"))
                            {
                                Hashtable htSrchHistory = Session["SearchHistory"] as Hashtable;
                                txtPartNumber.Text = htSrchHistory["PrtNo"].ToString();
                                txtQuantity.Text = htSrchHistory["Qty"].ToString(); ;
                                if (htSrchHistory["ExactMatch"].ToString().Equals("1"))
                                    cbxExactMatch.Checked = true;
                                else
                                    cbxExactMatch.Checked = false;
                                txtMake.Text = htSrchHistory["Make"].ToString();
                                txtPackage.Text = htSrchHistory["Package"].ToString();
                                txtDateCode.Text = htSrchHistory["DateCode"].ToString();
                                ddlLastUpdate.SelectedValue = htSrchHistory["LastUpdate"].ToString();

                                if (htSrchHistory["SearchType"].ToString().Equals("Requirements"))
                                {
                                    if (htSrchHistory["ReqStatus"].ToString().Equals("1,0"))
                                        ddlWithPO.SelectedValue = "2";
                                    else
                                        ddlWithPO.SelectedValue = htSrchHistory["ReqStatus"].ToString();
                                }
                                else
                                {
                                    string strStockStatus = htSrchHistory["StockStatus"].ToString();
                                    if (strStockStatus.Equals("1,2,3"))
                                    {
                                        cblStockStatus.Items.FindByText("Available").Selected = false;
                                        cblStockStatus.Items.FindByText("In House").Selected = false;
                                        cblStockStatus.Items.FindByText("OEM Excess").Selected = false;
                                    }
                                    else
                                    {
                                        string[] selectedVals = strStockStatus.Split(',');
                                        foreach (string val in selectedVals)
                                            cblStockStatus.Items.FindByValue(val).Selected = true;
                                    }
                                }
                                Session.Remove("SearchHistory");
                                btnSubmit_Click(null, null);
                            }
                        }
                    }
                    else
                    {
                        if (!RequestType.Equals(ViewState["CurrentPage"].ToString()))
                        {
                            btnClear_Click(null, null);
                            ViewState["CurrentPage"] = RequestType;
                        }
                        else
                        {
                            ViewState["CurrentPage"] = RequestType;
                        }
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }

        }

        /// <summary>
        /// Handles the OnClick event of the btnSearchString control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSearchString_OnClick(object sender, EventArgs e)
        {

            //BindResultGrid((sender as Button).Text.Trim());
            BindResultGrid((sender as LinkButton).Text.Trim());
            //SelectedTabForSearch = (sender as Button).Text.Trim();
            SelectedTabForSearch = (sender as LinkButton).Text.Trim();
            //BindResultGrid(btnse
        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //txtPartNumber.Text = 
            userId = (Guid)userToLogin.ProviderUserKey;
            if (txtPartNumber.Text != "" && txtPartNumber.Text != "\r\n")
            {
                ViewState["ActualPartNo"] = txtPartNumber.Text;
                txtPartNumber.Text = Regex.Replace(txtPartNumber.Text, @"( |\r?\n)\1+", "$1");
                rptSearchResult.Visible = true;
                lblPartMsg.Visible = true;
            }
            else
            {
                rptSearchResult.Visible = false;
                lblPartMsg.Visible = false;
            }

            int quantity = 0;
            if (!string.IsNullOrEmpty(txtQuantity.Text))
                quantity = Convert.ToInt32(txtQuantity.Text);

            if (Request.QueryString["RequestType"].Equals("Requirements"))
            {
                string reqStatus = string.Empty;
                if (int.Parse(ddlWithPO.SelectedValue) == 0)
                {
                    reqStatus = ddlWithPO.SelectedItem.Value;
                }
                else if (int.Parse(ddlWithPO.SelectedValue) == 1)
                {
                    reqStatus = ddlWithPO.SelectedItem.Value;
                }
                else
                {
                    reqStatus = "1,0";
                }

                string[] multipleComponentSearchText = txtPartNumber.Text.Trim().Split('\n');
                ///string finalSearchString = string.Join(",", multipleComponentSearchText);
                List<string> newMultipleComponentSearchText = new List<string>();
                foreach (string strTest in multipleComponentSearchText)
                {
                    if (string.Compare(strTest, " \r") != 0)
                    {
                        newMultipleComponentSearchText.Add(strTest);
                    }
                }
                SelectedTabForSearch = "";
                rptSearchResult.DataSource = newMultipleComponentSearchText;
                rptSearchResult.DataBind();
                grdRequirementSearchFilterResults.PageIndex = 0;
                int exMatch = 0;
                if (cbxExactMatch.Checked)
                    exMatch = 1;
                grdRequirementSearchFilterResults.DataSource = Master.PageController.SearchFilteredRequirement(newMultipleComponentSearchText[0].Trim(), quantity, txtMake.Text, txtPackage.Text, txtDateCode.Text, reqStatus, ddlLastUpdate.SelectedValue.ToString(), exMatch);
                grdRequirementSearchFilterResults.DataBind();

            }
            else
            {
                StringBuilder StockStatus = new StringBuilder();
                if (cblStockStatus.Items.FindByText("Available").Selected)
                {
                    StockStatus.Append(cblStockStatus.Items.FindByText("Available").Value.ToString());
                    StockStatus.Append(",");
                }

                if (cblStockStatus.Items.FindByText("In House").Selected)
                {
                    StockStatus.Append(cblStockStatus.Items.FindByText("In House").Value.ToString());
                    StockStatus.Append(",");
                }

                if (cblStockStatus.Items.FindByText("OEM Excess").Selected)
                {
                    StockStatus.Append(cblStockStatus.Items.FindByText("OEM Excess").Value.ToString());
                    StockStatus.Append(" ");
                }

                if (StockStatus.Length > 0)
                {
                    StockStatus.Remove(StockStatus.Length - 1, 1);
                }
                else
                {
                    StockStatus.Append("1,2,3");
                }

                string[] multipleComponentSearchText = txtPartNumber.Text.Trim().Split('\n');
                ///string finalSearchString = string.Join(",", multipleComponentSearchText);
                List<string> newMultipleComponentSearchText = new List<string>();
                foreach (string strTest in multipleComponentSearchText)
                {
                    if (string.Compare(strTest, " \r") != 0)
                    {
                        newMultipleComponentSearchText.Add(strTest);
                    }
                }
                SelectedTabForSearch = "";
                rptSearchResult.DataSource = newMultipleComponentSearchText;
                rptSearchResult.DataBind();

                int exMatch = 0;
                if (cbxExactMatch.Checked)
                    exMatch = 1;

                string strStockStatus = StockStatus.ToString();
                grdComponentSearchFilterResults.PageIndex = 0;
                grdComponentSearchFilterResults.DataSource =
                                    Master.PageController.SearchFilteredComponent(userId, newMultipleComponentSearchText[0].Trim(), quantity, txtMake.Text, txtPackage.Text, txtDateCode.Text, StockStatus.ToString(), ddlLastUpdate.SelectedValue.ToString(), exMatch);
                grdComponentSearchFilterResults.DataBind();

            }

        }

        /// <summary>
        /// Handles the RowDataBound event of the grdComponentSearchFilterResults control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void grdComponentSearchFilterResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStockStatus = ((Label)e.Row.FindControl("lblStockStatus"));

                if (lblStockStatus.Text == "1")
                    lblStockStatus.Text = "Available";
                else if (lblStockStatus.Text == "2")
                    lblStockStatus.Text = "In House";
                else
                    lblStockStatus.Text = "OEM Excess";

                Label lblIsOffer = ((Label)e.Row.FindControl("lblIsOffer"));
                Label lblUnitPrice = ((Label)e.Row.FindControl("lblPriceInUSD"));
                if (lblUnitPrice.Text == "0.000" || lblUnitPrice.Text == "0.0" || lblUnitPrice.Text == "0.00" || lblUnitPrice.Text == "0")
                {
                    lblUnitPrice.Text = null;
                }

                if (lblIsOffer != null)
                {
                    if (ddlLastUpdate.SelectedValue != "archived")
                    {
                        Image imgOffer = ((Image)e.Row.FindControl("imgOffer"));
                        if (lblIsOffer.Text.Equals("1"))
                        {
                            Label lblArchev = ((Label)e.Row.FindControl("lblArchev"));

                            if (lblArchev.Text.Equals("1"))
                            {
                                if (imgOffer != null)
                                {
                                    imgOffer.Visible = false;
                                }
                            }
                            else
                            {
                                if (imgOffer != null)
                                {
                                    imgOffer.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            if (imgOffer != null)
                            {
                                imgOffer.Visible = false;
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Handles the RowDataBound event of the grdRequirementSearchFilterResults control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void grdRequirementSearchFilterResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblWithPO = ((Label)e.Row.FindControl("lblWithPO"));
                Label lblUnitPrice = ((Label)e.Row.FindControl("lblPriceInUSD"));
                if (lblUnitPrice.Text == "0.000" || lblUnitPrice.Text == "0.0" || lblUnitPrice.Text == "0.00" || lblUnitPrice.Text == "0")
                {
                    lblUnitPrice.Text = null;
                }

                if (lblWithPO.Text == "True")
                    lblWithPO.Text = "PO";
                else
                    lblWithPO.Text = "RFQ";
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtDateCode.Text = "";
            txtMake.Text = "";
            txtPackage.Text = "";
            txtPartNumber.Text = "";
            txtQuantity.Text = "";
            lblPartMsg.Visible = false;
            //cbWithPO.Checked = false;
            grdComponentSearchFilterResults.DataSource = null;
            grdComponentSearchFilterResults.DataBind();
            grdRequirementSearchFilterResults.DataSource = null;
            grdRequirementSearchFilterResults.DataBind();
            rptSearchResult.DataSource = null;
            rptSearchResult.DataBind();
            ViewState["ActualPartNo"] = "";
            if (sender != null && e != null && Session["SearchHistory"] != null)
            {
                Session.Remove("SearchHistory");
                if (Session["MsgCancld"] != null)
                    Session.Remove("MsgCancld");
            }
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the grdComponentSearchFilterResults control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void grdComponentSearchFilterResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (txtPartNumber.Text != "" && txtPartNumber.Text != "\r\n")
            {
                txtPartNumber.Text = Regex.Replace(txtPartNumber.Text, @"( |\r?\n)\1+", "$1");
                rptSearchResult.Visible = true;
                lblPartMsg.Visible = true;
            }
            else
            {
                rptSearchResult.Visible = false;
                lblPartMsg.Visible = false;
            }
            string[] multipleComponentSearchText = txtPartNumber.Text.Trim().Split('\n');

            List<string> newMultipleComponentSearchText = new List<string>();
            foreach (string strTest in multipleComponentSearchText)
            {
                if (string.Compare(strTest, " \r") != 0)
                {
                    newMultipleComponentSearchText.Add(strTest);
                }
            }
            grdComponentSearchFilterResults.PageIndex = e.NewPageIndex;
            if (txtPartNumber.Text != "")
            {
                if (SelectedTabForSearch == "")
                {
                    SelectedTabForSearch = newMultipleComponentSearchText[0].Trim();
                    BindResultGrid(SelectedTabForSearch);
                }
                else
                {
                    BindResultGrid(SelectedTabForSearch);
                }
            }
            else
            {
                SelectedTabForSearch = newMultipleComponentSearchText[0].Trim();
                BindResultGrid(SelectedTabForSearch);
            }

        }

        /// <summary>
        /// Handles the PageIndexChanging event of the grdRequirementSearchFilterResults control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void grdRequirementSearchFilterResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            if (txtPartNumber.Text != "" && txtPartNumber.Text != "\r\n")
            {
                txtPartNumber.Text = Regex.Replace(txtPartNumber.Text, @"( |\r?\n)\1+", "$1");
                rptSearchResult.Visible = true;
                lblPartMsg.Visible = true;
            }
            else
            {
                rptSearchResult.Visible = false;
                lblPartMsg.Visible = false;
            }
            string[] multipleComponentSearchText = txtPartNumber.Text.Trim().Split('\n');

            List<string> newMultipleComponentSearchText = new List<string>();
            foreach (string strTest in multipleComponentSearchText)
            {
                if (string.Compare(strTest, " \r") != 0)
                {
                    newMultipleComponentSearchText.Add(strTest);
                }
            }
            grdRequirementSearchFilterResults.PageIndex = e.NewPageIndex;
            if (txtPartNumber.Text != "")
            {
                if (SelectedTabForSearch == "")
                {
                    SelectedTabForSearch = newMultipleComponentSearchText[0].Trim();
                    BindResultGrid(SelectedTabForSearch);
                }
                else
                {
                    BindResultGrid(SelectedTabForSearch);
                }
            }
            else
            {
                SelectedTabForSearch = newMultipleComponentSearchText[0].Trim();
                BindResultGrid(SelectedTabForSearch);
            }


        }

        /// <summary>
        /// Handles the RowCommand event of the grdComponentSearchFilterResults control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void grdComponentSearchFilterResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                LinkButton lnkSellerId = (LinkButton)row.Cells[0].FindControl("lnkSellerId");

                if (userToLogin != null)
                {
                    //decimal test5 = 0;
                    LinkButton lnkbtn = row.FindControl("lnkComponentName") as LinkButton;
                    string test1 = lnkbtn.Text.Replace("&nbsp;", "");
                    //((LinkButton)row.Cells[2].FindControl("lnk"));

                    Label lblQty = row.FindControl("LblQuantity") as Label;
                    string test2 = lblQty.Text.Replace("&nbsp;", "");

                    Label lblBrandName = row.FindControl("LblBrandName") as Label;
                    string test3 = lblBrandName.Text.Replace("&nbsp;", "");

                    Label lblDateCode = row.FindControl("lblDateCode") as Label;
                    string test4 = lblDateCode.Text.Replace("&nbsp;", "");

                    Label lblUnitPrice = row.FindControl("lblPriceInUSD") as Label;
                    string test5 =lblUnitPrice.Text.Replace("&nbsp;", "");

                    Label lblDescription = row.FindControl("lbldescription") as Label;
                    string test6 = lblDescription.Text.Replace("&nbsp;", "");

                    Label lblPackage = row.FindControl("lblPackage") as Label;

                    if (lnkbtn != null)
                    {
                        if (test5 != "")
                        {
                            values.Add(new Common.Component
                            {

                                ComponentName = lnkbtn.Text.Trim(),
                                Quantity = Convert.ToInt32(test2),
                                BrandName = test3,
                                datecode = test4,
                                PriceInUSD = Convert.ToDecimal(test5),
                                Description = test6,
                                package = lblPackage.Text
                            });
                        }
                        else
                        {
                            values.Add(new Common.Component
                            {

                                ComponentName = lnkbtn.Text.Trim(),
                                Quantity = Convert.ToInt32(test2),
                                BrandName = test3,
                                datecode = test4,
                                Description = test6,
                                package = lblPackage.Text
                            });
                        }

                    }
                }
                if (values.Count != 0)
                {
                    htMoreDetailsInfo.Add("UserId", lnkSellerId.Text.Trim());
                    htMoreDetailsInfo.Add("RequestType", "Offers");
                    htMoreDetailsInfo.Add("PartNo", values[0].ComponentName);
                    htMoreDetailsInfo.Add("Page", "MoreDetails");
                    htMoreDetailsInfo.Add("Values", values);
                    Session["GetList"] = htMoreDetailsInfo;
                    Session["FileUpload1"] = "";

                    // Search history inserted into session
                    Hashtable htSearchHistory = new Hashtable();
                    htSearchHistory.Add("PrtNo", ViewState["ActualPartNo"].ToString());
                    htSearchHistory.Add("Qty", txtQuantity.Text);
                    int exMatch = 0;
                    if (cbxExactMatch.Checked)
                        exMatch = 1;
                    htSearchHistory.Add("ExactMatch", exMatch);
                    htSearchHistory.Add("Make", txtMake.Text);
                    htSearchHistory.Add("Package", txtPackage.Text);
                    htSearchHistory.Add("DateCode", txtDateCode.Text);
                    htSearchHistory.Add("LastUpdate", ddlLastUpdate.SelectedValue.ToString());
                    htSearchHistory.Add("SearchType", "Offers");

                    StringBuilder StockStatus = new StringBuilder();
                    if (cblStockStatus.Items.FindByText("Available").Selected)
                    {
                        StockStatus.Append(cblStockStatus.Items.FindByText("Available").Value.ToString());
                        StockStatus.Append(",");
                    }

                    if (cblStockStatus.Items.FindByText("In House").Selected)
                    {
                        StockStatus.Append(cblStockStatus.Items.FindByText("In House").Value.ToString());
                        StockStatus.Append(",");
                    }

                    if (cblStockStatus.Items.FindByText("OEM Excess").Selected)
                    {
                        StockStatus.Append(cblStockStatus.Items.FindByText("OEM Excess").Value.ToString());
                        StockStatus.Append(" ");
                    }

                    if (StockStatus.Length > 0)
                    {
                        StockStatus.Remove(StockStatus.Length - 1, 1);
                    }
                    else
                    {
                        StockStatus.Append("1,2,3");
                    }
                    string strStockStatus = StockStatus.ToString();
                    htSearchHistory.Add("StockStatus", strStockStatus);
                    Session["SearchHistory"] = htSearchHistory;
                    if (Session["MsgCancld"] != null)
                        Session.Remove("MsgCancld");
                    Response.Redirect("UserResponse.aspx", false);
                }
                //GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                //LinkButton lnkComponentName = (LinkButton)grdComponentSearchFilterResults.Rows[row.RowIndex].FindControl("lnkComponentName");
                //Label lblIsOffer = (Label)grdComponentSearchFilterResults.Rows[row.RowIndex].FindControl("lblIsOffer");
                //if (lblIsOffer != null && lnkComponentName != null)
                //{
                //    if (lblIsOffer.Text.Equals("1"))
                //    {
                //        Response.Redirect("OfferDetails.aspx?ComponentName=" + lnkComponentName.Text.Trim(), false);
                //    }
                //    else
                //    {
                //        Response.Redirect("ComponentDetails.aspx?ComponentName=" + lnkComponentName.Text.Trim(), false);
                //    }
                //}
            }
        }

        /// <summary>
        /// Handles the RowCommand event of the grdRequirementSearchFilterResults control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void grdRequirementSearchFilterResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            if (e.CommandName == "Select")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                LinkButton lnkSellerId = (LinkButton)row.Cells[0].FindControl("lnkSellerId");

                if (userToLogin != null)
                {
                    //decimal test5 = 0;
                    LinkButton lnkbtn = row.FindControl("lnkComponentName") as LinkButton;
                    string test1 = lnkbtn.Text.Replace("&nbsp;", "");
                    //((LinkButton)row.Cells[2].FindControl("lnk"));

                    Label lblQty = row.FindControl("LblQuantity") as Label;
                    string test2 = lblQty.Text.Replace("&nbsp;", "");

                    Label lblBrandName = row.FindControl("LblBrandName") as Label;
                    string test3 = lblBrandName.Text.Replace("&nbsp;", "");

                    Label lblDateCode = row.FindControl("lblDateCode") as Label;
                    string test4 = lblDateCode.Text.Replace("&nbsp;", "");

                    Label lblUnitPrice = row.FindControl("lblPriceInUSD") as Label;
                    string test5 = lblUnitPrice.Text.Replace("&nbsp;", "");

                    Label lblDescription = row.FindControl("lbldescription") as Label;
                    string test6 = lblDescription.Text.Replace("&nbsp;", "");

                    Label lblPackage = row.FindControl("lblPackage") as Label;

                    if (lnkbtn != null)
                    {
                        if (test5 != "")
                        {
                            values.Add(new Common.Component
                            {

                                ComponentName = lnkbtn.Text.Trim(),
                                Quantity = Convert.ToInt32(test2),
                                BrandName = test3,
                                datecode = test4,
                                PriceInUSD = Convert.ToDecimal(test5),
                                Description = test6,
                                package = lblPackage.Text
                            });
                        }
                        else
                        {
                            values.Add(new Common.Component
                            {

                                ComponentName = lnkbtn.Text.Trim(),
                                Quantity = Convert.ToInt32(test2),
                                BrandName = test3,
                                datecode = test4,
                                Description = test6,
                                package = lblPackage.Text
                            });
                        }

                    }
                }
                if (values.Count != 0)
                {
                    htMoreDetailsInfo.Add("UserId", lnkSellerId.Text.Trim());
                    htMoreDetailsInfo.Add("RequestType", "Requirements");
                    htMoreDetailsInfo.Add("PartNo", values[0].ComponentName);
                    htMoreDetailsInfo.Add("Page", "MoreDetails");
                    htMoreDetailsInfo.Add("Values", values);
                    Session["GetList"] = htMoreDetailsInfo;

                    // Search history inserted into session
                    Hashtable htSearchHistory = new Hashtable();
                    htSearchHistory.Add("PrtNo", ViewState["ActualPartNo"].ToString());
                    htSearchHistory.Add("Qty", txtQuantity.Text);

                    string reqStatus = string.Empty;
                    if (int.Parse(ddlWithPO.SelectedValue) == 2)
                        reqStatus = "1,0";
                    else
                        reqStatus = ddlWithPO.SelectedItem.Value;

                    htSearchHistory.Add("ReqStatus", reqStatus);
                    int exMatch = 0;
                    if (cbxExactMatch.Checked)
                        exMatch = 1;
                    htSearchHistory.Add("ExactMatch", exMatch);
                    htSearchHistory.Add("Make", txtMake.Text);
                    htSearchHistory.Add("Package", txtPackage.Text);
                    htSearchHistory.Add("DateCode", txtDateCode.Text);
                    htSearchHistory.Add("LastUpdate", ddlLastUpdate.SelectedValue.ToString());
                    htSearchHistory.Add("SearchType", "Requirements");
                    Session["SearchHistory"] = htSearchHistory;
                    if (Session["MsgCancld"] != null)
                        Session.Remove("MsgCancld");
                    Session["FileUpload1"] = "";
                    Response.Redirect("UserResponse.aspx", false);
                }
            }
        }

        /// <summary>
        /// Handles the ItemDataBound event of the rptSearchResult control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RepeaterItemEventArgs"/> instance containing the event data.</param>
        protected void rptSearchResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                string[] multipleComponentSearchText = txtPartNumber.Text.Trim().Split('\n');
                List<string> newMultipleComponentSearchText = new List<string>();
                foreach (string strTest in multipleComponentSearchText)
                {
                    if (string.Compare(strTest, " \r") != 0)
                    {
                        newMultipleComponentSearchText.Add(strTest);
                    }
                }
                LinkButton btnSearchString1 = ((LinkButton)e.Item.FindControl("LinkButton1"));
                btnSearchString1.Text = newMultipleComponentSearchText[e.Item.ItemIndex].Trim();
                //Button btnSearchString = ((Button)e.Item.FindControl("btnSearchString"));
                //btnSearchString.Text = newMultipleComponentSearchText[e.Item.ItemIndex].Trim();
                //SelectedTabForSearch = btnSearchString.Text;
            }
        }

        /// <summary>
        /// Binds the result grid.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        private void BindResultGrid(string searchString)
        {
            userId = (Guid)userToLogin.ProviderUserKey;
            int quantity = 0;
            if (!string.IsNullOrEmpty(txtQuantity.Text))
                quantity = Convert.ToInt32(txtQuantity.Text);

            if (Request.QueryString["RequestType"].Equals("Requirements"))
            {
                string reqStatus = string.Empty;
                if (int.Parse(ddlWithPO.SelectedValue) == 0)
                {
                    reqStatus = ddlWithPO.SelectedItem.Value;
                }
                else if (int.Parse(ddlWithPO.SelectedValue) == 1)
                {
                    reqStatus = ddlWithPO.SelectedItem.Value;
                }
                else
                {
                    reqStatus = "1,0";
                }
                int exMatch = 0;
                if (cbxExactMatch.Checked)
                    exMatch = 1;
                grdRequirementSearchFilterResults.DataSource = Master.PageController.SearchFilteredRequirement(searchString, quantity, txtMake.Text, txtPackage.Text, txtDateCode.Text, reqStatus, ddlLastUpdate.SelectedValue.ToString(), exMatch);
                grdRequirementSearchFilterResults.DataBind();
            }
            else
            {
                StringBuilder StockStatus = new StringBuilder();
                if (cblStockStatus.Items.FindByText("Available").Selected)
                {
                    StockStatus.Append(cblStockStatus.Items.FindByText("Available").Value.ToString());
                    StockStatus.Append(",");
                }

                if (cblStockStatus.Items.FindByText("In House").Selected)
                {
                    StockStatus.Append(cblStockStatus.Items.FindByText("In House").Value.ToString());
                    StockStatus.Append(",");
                }

                if (cblStockStatus.Items.FindByText("OEM Excess").Selected)
                {
                    StockStatus.Append(cblStockStatus.Items.FindByText("OEM Excess").Value.ToString());
                    StockStatus.Append(" ");
                }

                if (StockStatus.Length > 0)
                {
                    StockStatus.Remove(StockStatus.Length - 1, 1);
                }
                else
                {
                    StockStatus.Append("1,2,3");
                }
                int exMatch = 0;
                if (cbxExactMatch.Checked)
                    exMatch = 1;

                string strStockStatus = StockStatus.ToString();
                grdComponentSearchFilterResults.DataSource =
                                    Master.PageController.SearchFilteredComponent(userId, searchString, quantity, txtMake.Text, txtPackage.Text, txtDateCode.Text, StockStatus.ToString(), ddlLastUpdate.SelectedValue.ToString(), exMatch);
                grdComponentSearchFilterResults.DataBind();
            }
        }

    }

}
