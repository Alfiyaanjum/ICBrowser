using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Web.Security;
using System.Collections;
using System.Data;

namespace ICBrowser.Web.Controls
{
    public partial class BuyersRequirements : System.Web.UI.UserControl
    {
        public int typeOfMembershipId = 0;
        List<Common.Component> values = new List<Common.Component>();      
        Hashtable htMoreDetailsInfo = new Hashtable();
        BuyersRequirement br = new BuyersRequirement();
        MembershipUser usertologin = Membership.GetUser();
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                if (usertologin != null)
                {
                    GridView1.DataSource = BindGrid();
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = BindGrid();
                    GridView1.DataBind();
                }
            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Binds the grid.
        /// </summary>
        /// <returns>DataTable.</returns>
        public DataTable BindGrid()
        {
            IEnumerable<ICBrowser.Common.BuyersRequirements> list = br.GetRequirementsDetails();

            DataTable dtForGrid = new DataTable();
            dtForGrid.Columns.Add("componentName", typeof(string));
            dtForGrid.Columns.Add("userId", typeof(Guid));
            dtForGrid.Columns.Add("Quantity", typeof(string));
            dtForGrid.Columns.Add("brandName", typeof(string));
            dtForGrid.Columns.Add("DateCode", typeof(string));
            dtForGrid.Columns.Add("Package", typeof(string));
            dtForGrid.Columns.Add("Description", typeof(string));
            DataRow dr;

            foreach (ICBrowser.Common.BuyersRequirements compo in list)
            {
                dr = dtForGrid.NewRow();
                dr["componentName"] = compo.ComponentName;
                dr["userId"] = compo.userId;
                dr["Description"] = compo.Description;
                dr["Quantity"] = compo.Quantity;
                dr["brandName"] = compo.BrandName;
                dr["DateCode"] = compo.DateCode;
                dr["Package"] = compo.Package;
                dtForGrid.Rows.Add(dr);
            }
            return dtForGrid;
        }

        /// <summary>
        /// Handles the RowCommand event of the GridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "btn")
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    var LnkBtn = (LinkButton)row.Cells[0].FindControl("lnkUserId");
                    string UserId = LnkBtn.Text;
                    int rowindex = row.RowIndex;
                    decimal unitprice = 0;
                    if (Membership.GetUser() == null)
                    {
                        Response.Redirect("Register.aspx?Id=" + UserId, true);
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

                                        LinkButton lnkbtn = row.FindControl("lnk") as LinkButton;
                                        LinkButton lnk = row.FindControl("lnk") as LinkButton;
                                        string test1 = lnkbtn.Text.Replace("&nbsp;", "");
                                        //((LinkButton)row.Cells[2].FindControl("lnk"));
                                     
                                        string Quantity = row.Cells[2].Text.Trim();
                                        string BrandName = row.Cells[3].Text.Trim().Replace("&nbsp;", "");
                                        string DateCode = row.Cells[4].Text.Trim().Replace("&nbsp;", "");
                                        string Package = row.Cells[5].Text.Trim().Replace("&nbsp;", "");
                                        string Comment = row.Cells[6].Text.Trim().Replace("&nbsp;", "");
                                    

                                        //if (userid == senduserid)
                                        //{

                                        if (lnk != null)
                                        {

                                            values.Add(new Common.Component
                                            {

                                                ComponentName = lnkbtn.Text.Trim(),
                                                Quantity = Convert.ToInt32(Quantity),
                                                BrandName = BrandName,
                                                datecode = DateCode,
                                                PriceInUSD = Convert.ToDecimal(unitprice),
                                                Description = Comment,
                                                package = Package
                                            });
                                        }

                                    }
                                }


                                if (values.Count != 0)
                                {
                                    htMoreDetailsInfo.Add("UserId", lnkUserId.Text.Trim());
                                    htMoreDetailsInfo.Add("RequestType", "Requirements");
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
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the RowDataBound event of the GridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    MembershipUser usertologin = Membership.GetUser();
                    LinkButton lnk = e.Row.FindControl("lnk") as LinkButton;
                    Label lblpartn = e.Row.FindControl("lblpartn") as Label;
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

                        if (Admin.IsAdmin || memTypeId <= 1)
                        {
                            lnk.Visible = false;
                            lblpartn.Visible = true;
                        }
                        else
                        {
                            lnk.Visible = true;

                        }
                    }
                    else
                    {

                        lblpartn.Visible = true;
                    }
                }
            }

            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }

        }
    }
}