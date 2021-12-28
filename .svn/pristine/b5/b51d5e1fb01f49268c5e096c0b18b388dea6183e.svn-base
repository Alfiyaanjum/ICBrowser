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

namespace ICBrowser.Web
{
    public partial class BuyersRequirements : System.Web.UI.UserControl
    {
        public int typeOfMembershipId = 0;
        BuyersRequirement br = new BuyersRequirement();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MembershipUser usertologin = Membership.GetUser();
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

        public DataTable BindGrid()
        {
            IEnumerable<ICBrowser.Common.BuyersRequirements> list = br.GetRequirementsDetails();

            DataTable dtForGrid = new DataTable();
            dtForGrid.Columns.Add("componentName", typeof(string));
            dtForGrid.Columns.Add("userId", typeof(Guid));
            dtForGrid.Columns.Add("conc_cat", typeof(string));
            dtForGrid.Columns.Add("Quantity", typeof(string));
            dtForGrid.Columns.Add("brandName", typeof(string));
            dtForGrid.Columns.Add("DateCode", typeof(string));
            dtForGrid.Columns.Add("Package", typeof(string));
            dtForGrid.Columns.Add("modifiedDate", typeof(DateTime));
            dtForGrid.Columns.Add("Description", typeof(string));
            DataRow dr;

            foreach (ICBrowser.Common.BuyersRequirements compo in list)
            {
                if (compo.conc_cat != null)
                {
                    dr = dtForGrid.NewRow();
                    dr["componentName"] = compo.ComponentName;
                    dr["userId"] = compo.userId;
                    dr["Description"] = compo.Description;
                    dr["conc_cat"] = compo.conc_cat;
                    string Data = dr["conc_cat"].ToString();
                    string[] ConCatn = Data.Split('!');
                    dr["componentName"] = ConCatn[0];
                    dr["Quantity"] = ConCatn[1];
                    dr["brandName"] = ConCatn[2];
                    dr["DateCode"] = ConCatn[3];
                    dr["Package"] = ConCatn[4];
                    dr["modifiedDate"] = ConCatn[5];
                    dtForGrid.Rows.Add(dr);
                }
            }
            return dtForGrid;
        }

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
                            UserRequirements userdata = new UserRequirements();
                            int usercount = userdata.GetUserCountByUserId(userid);
                            if (usercount > 0)
                            {
                                LnkBtn.Visible = false;
                            }
                            else
                            {
                                Response.Redirect("DetailedBuyersRequirements.aspx?UserId=" + UserId, false);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    MembershipUser usertologin = Membership.GetUser();
                    if (usertologin != null)
                    {
                        LinkButton lnk = e.Row.FindControl("lnk") as LinkButton;
                        lnk.Visible = true;
                    }
                    else
                    {
                        Label lblpartn = e.Row.FindControl("lblpartn") as Label;
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