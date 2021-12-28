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
    public class UserMatchRequirement
    {
        public Guid userId { get; set; }
        public string ComponentName { get; set; }
        public string DateCode { get; set; }
        public decimal PriceInUSD { get; set; }
        public string Description { get; set; }
        public string package { get; set; }
        public int Quantity { get; set; }
        public string BrandName { get; set; }
        public string CompanyName { get; set; }
        public int Flag { get; set; }
        public List<ICBrowser.Common.Component> Components { get; set; }
    }

    public partial class MatchRequirments : BasePage
    {
        List<Common.Component> values = new List<Common.Component>();
        Hashtable htMoreDetailsInfo = new Hashtable();
        BuyersRequirement br = new BuyersRequirement();
        SellerInventoryListing sil = new SellerInventoryListing();
        GridView gvComponentsInRepeater = null;
        Guid userId;
        MembershipUser userToLogin = Membership.GetUser();

        /// <summary>
        /// Handles the PreRender event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_PreRender(object sender, EventArgs e)
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
                if (memTypeId >= 1)
                {
                    //to bind repeater on page load
                    if (!Page.IsPostBack)
                    {
                        UserdetailsMatchRequirement(1);
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
        /// method to bind grid with Inventories an offers
        /// </summary>
        protected void UserdetailsMatchRequirement(int currnetPage)
        {
            try
            {
                List<ICBrowser.Common.Component> lstComponent = sil.GetAllInventoryDetailsForMatch(userId, pagerForRepeater.PageSize, currnetPage);
                List<UserMatchRequirement> commonItems = new List<UserMatchRequirement>();

                foreach (var g in lstComponent)
                {
                    if (commonItems.Count(aa => aa.userId == g.UserId) == 0)
                    {
                        commonItems.Add(new UserMatchRequirement
                        {
                            userId = g.UserId,
                            CompanyName = g.CompanyName,
                            Components = new List<ICBrowser.Common.Component>()

                        });

                    }
                }

                foreach (var g in commonItems)
                {
                    foreach (var d in lstComponent.Where(aa => aa.UserId == g.userId))
                    {
                        if (d.PriceInUSD == 0)
                        {
                            d.PriceInUSD = null;
                        }
                        g.Components.Add(d);
                    }
                }


                pagerForRepeater.ItemCount = sil.TotalPages;
                if (lstComponent.Count() == 0 && pagerForRepeater.CurrentIndex > 1)
                    UserdetailsMatchRequirement(--pagerForRepeater.CurrentIndex);

                rptrRequirement.DataSource = commonItems;
                rptrRequirement.DataBind();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Handles the RowCommand event of the MatchRequirements control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void MatchRequirements_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            var LnkBtn = (LinkButton)row.FindControl("lnkUserId");
            try
            {
                Guid userid = new Guid(e.CommandArgument.ToString());
                //to check Part no is clicked
                if (e.CommandName == "btn")
                {

                    string UserId = LnkBtn.Text;
                    int rowindex = row.RowIndex;
                    if (Membership.GetUser() == null)
                    {
                        Response.Redirect("Register.aspx?Id=" + UserId, true);
                    }

                    else
                    {

                        //to get the values of respective items in row
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
                }


                if (values.Count != 0)
                {
                    htMoreDetailsInfo.Add("UserId", LnkBtn.Text.Trim());
                    htMoreDetailsInfo.Add("RequestType", "Offers");
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
                //to check send button click event
                if (e.CommandName == "Send")
                {

                    foreach (RepeaterItem item in rptrRequirement.Items)
                    {
                        Button btnSend = (Button)item.FindControl("btnSendMsg");

                        if (senduserid == Guid.Parse(btnSend.CommandArgument))
                        {
                            gvComponentsInRepeater = item.FindControl("MatchRequirements") as GridView;
                            if (gvComponentsInRepeater != null)
                            {
                                foreach (GridViewRow row in gvComponentsInRepeater.Rows)
                                {
                                    //to check respective checkbox of send button clicked
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

                                    Label lblDescription = row.FindControl("lbldescription") as Label;
                                    string test6 = lblDescription.Text.Replace("&nbsp;", "");



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
                    htMoreDetailsInfo.Add("RequestType", "Offers");
                    htMoreDetailsInfo.Add("Page", "MoreDetails");
                    htMoreDetailsInfo.Add("Values", values);
                    Session["GetList"] = htMoreDetailsInfo;
                    Session["FileUpload1"] = "";
                    Response.Redirect("UserResponse.aspx", false);

                }
                else
                {

                    UserdetailsMatchRequirement(pagerForRepeater.CurrentIndex);
                    lblErmsg.Visible = true;
                    lblErmsg.Text = "Please select Offer(s)";
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }

        }

        /// <summary>
        /// Method to distinguish offers from Inventories
        /// </summary>
        protected void rptrRequirement_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemIndex >= 0)
                {
                    GridView grd = new GridView();
                    grd = (GridView)e.Item.FindControl("MatchRequirements");


                    for (int i = 0; i <= grd.Rows.Count - 1; i++)
                    {

                        Label flag = (Label)grd.Rows[i].FindControl("lblflag");

                        if (flag.Text == "1")    //offer
                        {
                            Image imgflag = (Image)grd.Rows[i].FindControl("flag");
                            imgflag.Visible = true;
                        }
                        else
                        {
                            Image imgflag = (Image)grd.Rows[i].FindControl("flag");
                            imgflag.Visible = false;
                        }
                    }
                }
                //Repeater rptDemo = sender as Repeater; // Get the Repeater control object.

                // If the Repeater contains no data.
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
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }

        }

        /// <summary>
        /// to bind data from Current Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void pager_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
                pagerForRepeater.CurrentIndex = currnetPageIndx;
                UserdetailsMatchRequirement(currnetPageIndx);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }

        }

        /// <summary>
        /// To compare number of items to page size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



    }
}



