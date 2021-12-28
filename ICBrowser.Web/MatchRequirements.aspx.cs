using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ICBrowser.Business;
using System.Web.Security;
using System.Data;
using ICBrowser.Common;
using System.ComponentModel;
using System.Collections;
using System.Text;


namespace ICBrowser.Web
{

    [Serializable]
    public class UserMatchOffers
    {
        public Guid userId { get; set; }
        public string ComponentName { get; set; }
        public string DateCode { get; set; }
        public string package { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string BrandName { get; set; }
        public DateTime modifiedDate { get; set; }
        public DateTime creationDate { get; set; }
        public string CompanyName { get; set; }
        public List<ICBrowser.Common.BuyersRequirements> Requirements { get; set; }

    }
    public partial class MatchOffers : BasePage
    {
        Guid userId;
        List<Common.Component> values = new List<Common.Component>();
        Hashtable htMoreDetailsInfo = new Hashtable();
        MembershipUser userToLogin = Membership.GetUser();
        BuyersRequirement br = new BuyersRequirement();
        SellerInventoryListing sil = new SellerInventoryListing();
        GridView gvRequirementsInRepeater = null;
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                userId = (Guid)userToLogin.ProviderUserKey;
                Common.UserProfile objuserpro = new Common.UserProfile();
                UserProfileDetails profiledetais = new UserProfileDetails();
                int memTypeId = 0;
                objuserpro = profiledetais.GetUserProfileDetails(userId);
                memTypeId = objuserpro.TypeOfMembership;
                if (memTypeId > 1)
                {
                    if (!Page.IsPostBack)
                    {

                        UserDetailsMatchOffers(1);
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Method to bind Requirements Matching to offers/inventories
        /// </summary>
        /// <param name="currentPage">The current page.</param>
        protected void UserDetailsMatchOffers(int currentPage)
        {
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                Guid UserId = (Guid)userToLogin.ProviderUserKey;

                List<ICBrowser.Common.BuyersRequirements> lstrequirement = br.GetAllRequirementsDetailsForMatch(UserId, pagerForRepeater.PageSize, currentPage);

                List<UserMatchOffers> commonItems = new List<UserMatchOffers>();


                foreach (var g in lstrequirement)
                {
                    if (commonItems.Count(aa => aa.userId == g.userId) == 0)
                    {
                        commonItems.Add(new UserMatchOffers
                        {
                            userId = g.userId,
                            CompanyName = g.CompanyName,
                            Requirements = new List<ICBrowser.Common.BuyersRequirements>()

                        });

                    }
                }


                foreach (var g in commonItems)
                {
                    foreach (var d in lstrequirement.Where(aa => aa.userId == g.userId))
                    {
                        if (d.PriceInUSD == 0)
                        {
                            d.PriceInUSD = null;
                        }
                        g.Requirements.Add(d);
                    }
                }


                pagerForRepeater.ItemCount = br.TotalPages;
                if (lstrequirement.Count() == 0 && pagerForRepeater.CurrentIndex > 1)
                    UserDetailsMatchOffers(--pagerForRepeater.CurrentIndex);

                rptrRequirement.DataSource = commonItems;
                rptrRequirement.DataBind();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }

        }

        /// <summary>
        /// Method to get values of clicked part nos rows
        /// </summary>
        protected void MatchOffer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            var LnkBtn = (LinkButton)row.Cells[0].FindControl("lnkUserId");

            try
            {
                Guid userid = new Guid(e.CommandArgument.ToString());
                if (e.CommandName == "btn")
                {

                    string UserId = LnkBtn.Text;
                    int rowindex = row.RowIndex;
                    if (Membership.GetUser() == null)
                    {
                        Response.Redirect("Register.aspx?Id=" + UserId, true);
                    }

                    LinkButton lnkbtn = row.FindControl("lnk") as LinkButton;
                    string test1 = lnkbtn.Text.Replace("&nbsp;", "");

                    Label lblQty = row.FindControl("lblQuantity") as Label;
                    string test2 = lblQty.Text.Replace("&nbsp;", "");

                    Label lblBrandName = row.FindControl("lblBrandName") as Label;
                    string test3 = lblBrandName.Text.Replace("&nbsp;", "");

                    Label lblDateCode = row.FindControl("lblDateCode") as Label;
                    string test4 = lblDateCode.Text.Replace("&nbsp;", "");

                    Label lblUnitPrice = row.FindControl("lblPriceInUSD") as Label;
                    string test5 = lblUnitPrice.Text.Replace("&nbsp;", "");

                    Label lbldescription = row.FindControl("lbldescription") as Label;
                    string test6 = lbldescription.Text.Replace("&nbsp;", "");

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
                    htMoreDetailsInfo.Add("UserId", LnkBtn.Text.Trim());
                    htMoreDetailsInfo.Add("RequestType", "Requirements");
                    htMoreDetailsInfo.Add("PartNo", values[0].ComponentName);
                    htMoreDetailsInfo.Add("Page", "MoreDetails");
                    htMoreDetailsInfo.Add("Values", values);

                    Session["GetList"] = htMoreDetailsInfo;
                    Session["FileUpload1"] = "";
                    Response.Redirect("UserResponse.aspx", false);
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Method to get values of checked part nos rows
        /// </summary>
        protected void rptrRequirement_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            lblErmsg.Visible = false;
            lblErmsg.Text = "";

            try
            {
                Guid userId = (Guid)userToLogin.ProviderUserKey;
                Guid senduserid = new Guid(e.CommandArgument.ToString());


                if (e.CommandName == "Send")
                {


                    foreach (RepeaterItem item in rptrRequirement.Items)
                    {
                        Button btnSend = (Button)item.FindControl("btnSendMsg");

                        if (senduserid == Guid.Parse(btnSend.CommandArgument))
                        {
                            gvRequirementsInRepeater = item.FindControl("MatchOffer") as GridView;
                            if (gvRequirementsInRepeater != null)
                            {
                                foreach (GridViewRow row in gvRequirementsInRepeater.Rows)
                                {

                                    CheckBox cb = row.FindControl("chkbx") as CheckBox;
                                    LinkButton lnkbtn = row.FindControl("lnk") as LinkButton;
                                    string test1 = lnkbtn.Text.Replace("&nbsp;", "");


                                    Label lblQty = row.FindControl("lblQuantity") as Label;
                                    string test2 = lblQty.Text.Replace("&nbsp;", "");

                                    Label lblBrandName = row.FindControl("lblBrandName") as Label;
                                    string test3 = lblBrandName.Text.Replace("&nbsp;", "");

                                    Label lblDateCode = row.FindControl("lblDateCode") as Label;
                                    string test4 = lblDateCode.Text.Replace("&nbsp;", "");

                                    Label lblUnitPrice = row.FindControl("lblPriceInUSD") as Label;
                                    string test5 = lblUnitPrice.Text.Replace("&nbsp;", "");

                                    Label lbldescription = row.FindControl("lbldescription") as Label;
                                    string test6 = lbldescription.Text.Replace("&nbsp;", "");


                                    Guid userid = new Guid(e.CommandArgument.ToString());


                                    if (cb != null && lnkbtn != null)
                                    {
                                        if (cb.Checked)
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
                                                    Description = test6
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
                                                    Description = test6
                                                });
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (values.Count != 0)
                {
                    htMoreDetailsInfo.Add("UserId", senduserid);
                    htMoreDetailsInfo.Add("RequestType", "Requirements");
                    htMoreDetailsInfo.Add("Page", "MoreDetails");
                    htMoreDetailsInfo.Add("Values", values);
                    Session["GetList"] = htMoreDetailsInfo;
                    Session["FileUpload1"] = "";
                    Response.Redirect("UserResponse.aspx", false);
                }
                else
                {
                    UserDetailsMatchOffers(pagerForRepeater.CurrentIndex);
                    lblErmsg.Visible = true;
                    lblErmsg.Text = "Please select Part(s)";
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }

        }

        /// <summary>
        /// Handles the ItemDataBound event of the rptrRequirement control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RepeaterItemEventArgs"/> instance containing the event data.</param>
        protected void rptrRequirement_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (rptrRequirement != null && rptrRequirement.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    // Show the Error Label (if no data is present).
                    Label lblErrorMsg = e.Item.FindControl("lblErrorMsg") as Label;
                    if (lblErrorMsg != null)
                    {
                        lblErrorMsg.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Command event of the pager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CommandEventArgs"/> instance containing the event data.</param>
        protected void pager_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
                pagerForRepeater.CurrentIndex = currnetPageIndx;
                UserDetailsMatchOffers(currnetPageIndx);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Handles the PreRender event of the pagerForRepeater control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void pagerForRepeater_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (pagerForRepeater.ItemCount <= pagerForRepeater.PageSize)
                {
                    pagerForRepeater.Visible = false;
                }
                else
                    pagerForRepeater.Visible = true;
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }

        }

        /// <summary>
        /// Handles the Click event of the btnSendMsg control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSendMsg_Click(object sender, EventArgs e)
        {

        }


    }
}
