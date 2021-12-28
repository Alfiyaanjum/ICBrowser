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
using System.Collections;
using System.ComponentModel;

namespace ICBrowser.Web
{
    public partial class gvSellerInventoryListing : System.Web.UI.UserControl
    {
        List<Common.Component> values = new List<Common.Component>();
        Hashtable htMoreDetailsInfo = new Hashtable();

        SellerInventoryListing sil = new SellerInventoryListing();

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser usertologin = Membership.GetUser();
            if (usertologin != null)
            {
                gvSellerInvList.DataSource = BindGrid();
                gvSellerInvList.DataBind();
            }
            else
            {
                gvSellerInvList.DataSource = BindGrid();
                gvSellerInvList.DataBind();
            }
        }

        /// <summary>
        /// Binds the grid.
        /// </summary>
        /// <returns>DataTable.</returns>
        public DataTable BindGrid()
        {
            MembershipUser usertologin = Membership.GetUser();
            DataTable dtForGrid = new DataTable();
            dtForGrid.Columns.Add("UserId", typeof(Guid));
            dtForGrid.Columns.Add("ComponentName", typeof(string));
            dtForGrid.Columns.Add("Quantity", typeof(string));
            dtForGrid.Columns.Add("Datecode", typeof(string));
            dtForGrid.Columns.Add("Package", typeof(string));
            dtForGrid.Columns.Add("BrandName", typeof(string));
            dtForGrid.Columns.Add("Description", typeof(string));
            DataRow dr;
            if (usertologin != null)
            {
                Guid userid = (Guid)usertologin.ProviderUserKey;
                IEnumerable<ICBrowser.Common.Component> list = sil.SellerInventoryDetails(userid);
                foreach (ICBrowser.Common.Component compo in list)
                {
                    dr = dtForGrid.NewRow();
                    dr["UserId"] = compo.UserId;
                    dr["Description"] = compo.Description;
                    dr["ComponentName"] = compo.ComponentName;
                    dr["Quantity"] = compo.Quantity;
                    dr["Datecode"] = compo.datecode;
                    dr["package"] = compo.package;
                    dr["BrandName"] = compo.BrandName;
                    dtForGrid.Rows.Add(dr);
                }
                return dtForGrid;
            }
            else
            {
                Guid UserId = Guid.Empty;
                IEnumerable<ICBrowser.Common.Component> list = sil.SellerInventoryDetails(UserId);
                foreach (ICBrowser.Common.Component compo in list)
                {
                    dr = dtForGrid.NewRow();
                    dr["UserId"] = compo.UserId;
                    dr["Description"] = compo.Description;
                    dr["ComponentName"] = compo.ComponentName;
                    dr["Quantity"] = compo.Quantity;
                    dr["Datecode"] = compo.datecode;
                    dr["package"] = compo.package;
                    dr["BrandName"] = compo.BrandName;
                    dtForGrid.Rows.Add(dr);
                }
                return dtForGrid;
            }
            //return dtForGrid;
        }

        /// <summary>
        /// Handles the RowCommand event of the gvSellerInvList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvSellerInvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btn")
            {
                MembershipUser usertologin = Membership.GetUser();
                if (usertologin != null)
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    var LnkBtn = (LinkButton)row.Cells[0].FindControl("lnkSellerId");
                    LinkButton lnkComponentName = (LinkButton)row.Cells[0].FindControl("lnk");
                    string Id = LnkBtn.Text;
                    int rowindex = row.RowIndex;
                    decimal unitprice = 0;
                    string componentname = lnkComponentName.Text.Replace('#', '@');
                    if (Membership.GetUser() == null)
                    {
                        Response.Redirect("Register.aspx?UserId=" + Id, true);
                    }
                    else
                    {
                        MembershipUser userToLogin = Membership.GetUser();
                        Guid userid = new Guid(userToLogin.ProviderUserKey.ToString());
                        if (userToLogin != null)
                        {
                            LinkButton lnkUserId = (LinkButton)row.Cells[0].FindControl("lnkUserId");
                            if (e.CommandName == "btn")
                            {
                                if (userToLogin != null)
                                {
                                    LinkButton lnk = row.FindControl("lnk") as LinkButton;
                                    string test1 = lnk.Text.Replace("&nbsp;", "");
                                    //((LinkButton)row.Cells[2].FindControl("lnk"));

                                    Label lblQty = row.FindControl("lblQuantity") as Label;
                                    string test2 = lblQty.Text.Replace("&nbsp;", "");

                                    Label lblBrandName = row.FindControl("lblBrandName") as Label;
                                    string test3 = lblBrandName.Text.Replace("&nbsp;", "");

                                    Label lblDateCode = row.FindControl("lblDateCode") as Label;
                                    string test4 = lblDateCode.Text.Replace("&nbsp;", "");

                                    Label lblDescription = row.FindControl("lbldescription") as Label;
                                    string test6 = lblDescription.Text.Replace("&nbsp;", "");

                                    Label lblPackage = row.FindControl("lblPkg") as Label;

                                    if (lnk != null)
                                    {

                                        values.Add(new Common.Component
                                        {

                                            ComponentName = lnk.Text.Trim(),
                                            Quantity = Convert.ToInt32(lblQty.Text),
                                            BrandName = lblBrandName.Text,
                                            datecode = lblDateCode.Text,
                                            PriceInUSD = Convert.ToDecimal(unitprice),
                                            Description = lblDescription.Text,
                                            package = lblPackage.Text
                                        });
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
                            //Response.Redirect("DetailedBuyersRequirements.aspx", false);
                        }

                    }
                }
            }
        }


        /// <summary>
        /// Handles the RowDataBound event of the gvSellerInvList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvSellerInvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                MembershipUser usertologin = Membership.GetUser();
                LinkButton hyppart = e.Row.FindControl("lnk") as LinkButton;
                Label Lblpart = e.Row.FindControl("lblpartn") as Label;
                if (usertologin != null)
                {                    
                    Guid UserId = (Guid)usertologin.ProviderUserKey;
                    UserId = (Guid)usertologin.ProviderUserKey;
                    Common.UserProfile objuserpro = new Common.UserProfile();
                    UserProfileDetails profiledetais = new UserProfileDetails();
                    int memTypeId = 0;
                    objuserpro = profiledetais.GetUserProfileDetails(UserId);
                    memTypeId = objuserpro.TypeOfMembership;
                    //chk for Admin.......
                    Controller controlIsAdmin = new Controller();
                    Users Admin = controlIsAdmin.GetIsAdmin(UserId);

                    if (Admin.IsAdmin)
                    {
                        hyppart.Visible = false;
                        Lblpart.Visible = true;
                    }
                    else
                    {
                        hyppart.Visible = true;
                    }
                }
                else
                {
                    Lblpart.Visible = true;
                }
            }

        }
    }
}