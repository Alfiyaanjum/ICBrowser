using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using ICBrowser.Common;

namespace ICBrowser.DAL
{
    public class UserOfferDataRepository : Repository
    {
        /// <summary>
        /// Insert Offer Data
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        /// 

        public int SaveOfferUploadedByUserManually(Common.Component dir)
        {
            int count = 0;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("InsertOfferUploadedByUserIdManually");
            //db.AddInParameter(command, "@OfferId", DbType.Int32, dir.Componentid); // OfferID
            db.AddInParameter(command, "@UserId", DbType.Guid, dir.UserId);
            db.AddInParameter(command, "@Quantity", DbType.Int32, dir.Quantity);
            db.AddInParameter(command, "@ComponentName", DbType.String, dir.ComponentName); // Part Number
            db.AddInParameter(command, "@Description", DbType.String, dir.Description);
            db.AddInParameter(command, "@BrandName", DbType.String, dir.BrandName); // Make
            db.AddInParameter(command, "@StockInHand", DbType.Int32, dir.StockInHand);
            db.AddInParameter(command, "@StockStatus", DbType.Int32, dir.stockstatus);
            db.AddInParameter(command, "@Status", DbType.Int32, null); // By Default value of status is 1 "Open"
            db.AddInParameter(command, "@DateCode", DbType.String, dir.datecode);
            db.AddInParameter(command, "@Package", DbType.String, dir.package);
            db.AddInParameter(command, "@Country", DbType.String, dir.country);
            db.AddInParameter(command, "@PriceInINR", DbType.Int32, null);
            db.AddInParameter(command, "@PriceInUSD", DbType.Decimal, dir.PriceInUSD);
            db.AddInParameter(command, "@PriceInCNY", DbType.Int32, null);
            db.AddInParameter(command, "@ModifiedOn", DbType.DateTime, DateTime.Now);
            db.AddInParameter(command, "@CreatedOn", DbType.DateTime, DateTime.Now);
            db.AddInParameter(command, "@NotificationSent", DbType.Int32, 0);
            db.AddInParameter(command, "@Archiv", DbType.Int32, 0);
            db.AddOutParameter(command, "@Count", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(command);
                count = (int)command.Parameters["@Count"].Value;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return count;
        }

        public bool SaveOfferUploadedByUser(Common.Component dir)
        {
            bool result = false;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("InsertOfferUploadedByUserId");
            //db.AddInParameter(command, "@OfferId", DbType.Int32, dir.Componentid); // OfferID
            db.AddInParameter(command, "@UserId", DbType.Guid, dir.UserId);
            db.AddInParameter(command, "@Quantity", DbType.Int32, dir.Quantity);
            db.AddInParameter(command, "@ComponentName", DbType.String, dir.ComponentName); // Part Number
            db.AddInParameter(command, "@Description", DbType.String, dir.Description);
            db.AddInParameter(command, "@BrandName", DbType.String, dir.BrandName); // Make
            db.AddInParameter(command, "@StockInHand", DbType.Int32, dir.StockInHand);
            db.AddInParameter(command, "@StockStatus", DbType.Int32, dir.stockstatus);
            db.AddInParameter(command, "@Status", DbType.Int32, null); // By Default value of status is 1 "Open"
            db.AddInParameter(command, "@DateCode", DbType.String, dir.datecode);
            db.AddInParameter(command, "@Package", DbType.String, dir.package);
            db.AddInParameter(command, "@Country", DbType.String, dir.country);
            db.AddInParameter(command, "@PriceInINR", DbType.Int32, null);
            db.AddInParameter(command, "@PriceInUSD", DbType.Decimal, dir.PriceInUSD);
            db.AddInParameter(command, "@PriceInCNY", DbType.Int32, null);
            db.AddInParameter(command, "@ModifiedOn", DbType.DateTime, DateTime.Now);
            db.AddInParameter(command, "@CreatedOn", DbType.DateTime, DateTime.Now);
            db.AddInParameter(command, "@NotificationSent", DbType.Int32, 0);
            db.AddInParameter(command, "@Archiv", DbType.Int32, 0);
            //db.AddOutParameter(command, "@Count", DbType.Int32, 0);

            try
            {
                int count = db.ExecuteNonQuery(command);
                if (count == 1)
                    result = true;
                // count = (int)command.Parameters["@Count"].Value;
            }
            catch (Exception ex)
            {
                result = false;
                IClogger.LogError(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Delete Offer as per Membership type
        /// </summary>
        /// <param name="noOfRowsToBeSave"></param>
        /// <param name="UserId"></param>
        /// 


        public void DeleteExtraUploadedInventories(int noOfRowsToBeSave, Guid UserId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[DeleteExtraUploadedInventoriesAsPerModifiedDate]");
            db.AddInParameter(command, "@NoOfAllowedItems", DbType.Int32, noOfRowsToBeSave);
            db.AddInParameter(command, "@UserId", DbType.Guid, UserId);
            db.ExecuteNonQuery(command);
        }

        public void DeleteExtraUploadedOffer(int noOfRowsToBeSave, Guid UserId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("DeleteExtraUploadedOffersAsPerModifiedDate");
            db.AddInParameter(command, "@NoOfAllowedItems", DbType.Int32, noOfRowsToBeSave);
            db.AddInParameter(command, "@UserId", DbType.Guid, UserId);
            db.ExecuteNonQuery(command);
        }

        /// <summary>
        /// Get All Offer Data For Binding Grid
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable getAllOfferDetailsByUserID(Guid UserId)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            try
            {

                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "GetAllOfferDetailsByUserId";
                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@UserId";
                p1.Value = UserId;
                p1.DbType = DbType.Guid;
                cmd.Parameters.Add(p1);
                da.SelectCommand = cmd;
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return dt;

        }

        public List<Component> GetSearchedData(Guid UserId, string searchtext, int SelectType)
        {
            List<Component> lst = new List<Component>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("[getOfferDetailsForSearch]");
            db.AddInParameter(command, "@UserId", DbType.Guid, UserId);
            db.AddInParameter(command, "@SearchText", DbType.String, searchtext);
            db.AddInParameter(command, "@SelectType", DbType.Int32, SelectType);
            try
            {
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    string brndname = reader.GetValue<string>("brandname");
                    if (!string.IsNullOrEmpty(brndname))
                    {
                        brndname = reader.GetValue<string>("brandname");
                    }
                    else
                    {
                        // brndname = "---";
                    }

                    int stkInHnd = reader.GetValue<int>("stockinhand");
                    if (!string.IsNullOrEmpty(stkInHnd.ToString()))
                    {
                        stkInHnd = reader.GetValue<int>("stockinhand");
                    }
                    else
                    {
                        stkInHnd = 0;
                    }

                    decimal prcINR = reader.GetValue<decimal>("priceininr");
                    if (!string.IsNullOrEmpty(prcINR.ToString()))
                    {
                        prcINR = reader.GetValue<decimal>("priceininr");
                    }
                    else
                    {
                        prcINR = 0;
                    }


                    decimal prcinUSD = reader.GetValue<decimal>("priceinusd");
                    if (!string.IsNullOrEmpty(prcinUSD.ToString()))
                    {
                        prcinUSD = reader.GetValue<decimal>("priceinusd");
                    }
                    else
                    {
                        prcinUSD = 0;
                    }

                    decimal prcinCNY = reader.GetValue<decimal>("priceincny");
                    if (!string.IsNullOrEmpty(prcinCNY.ToString()))
                    {
                        prcinCNY = reader.GetValue<decimal>("priceincny");
                    }
                    else
                    {
                        prcinCNY = 0;
                    }

                    int stkstatus = reader.GetValue<int>("StockStatus");
                    if (!string.IsNullOrEmpty(stkstatus.ToString()))
                    {
                        stkstatus = reader.GetValue<int>("StockStatus");
                    }
                    else
                    {
                        stkstatus = 0;
                    }

                    //string cntry = "";
                    //if (reader.GetValue<string>("Country") == System.DBNull.Value.ToString())
                    //{
                    //    cntry = "";
                    //}
                    //else
                    //{
                    //    cntry = reader.GetValue<string>("Country");
                    //}

                    string cntry = reader.GetValue<string>("Country");
                    if (!string.IsNullOrEmpty(cntry))
                    {
                        cntry = reader.GetValue<string>("Country");
                    }
                    else
                    {
                        cntry = "";
                    }



                    //string cntry = reader.GetValue<string>("Country");
                    //if (!cntry.ToString().Equals(""))
                    //{
                    //    cntry = reader.GetValue<string>("Country");
                    //}
                    //else
                    //{
                    //    //  cntry = "---";
                    //}

                    string packge = reader.GetValue<string>("Package");
                    if (!string.IsNullOrEmpty(packge))
                    {
                        packge = reader.GetValue<string>("Package");
                    }
                    else
                    {
                        // packge = "---";
                    }

                    string datecde = reader.GetValue<string>("DateCode");
                    if (!string.IsNullOrEmpty(datecde))
                    {
                        datecde = reader.GetValue<string>("DateCode");
                    }
                    else
                    {
                        //  datecde = "---";
                    }


                    lst.Add(new Component
                    {
                        OfferId = reader.GetValue<int>("OfferId"),
                        Status = reader.GetValue<int>("Status"),
                        ComponentName = reader.GetValue<string>("componentName"),
                        Quantity = reader.GetValue<int>("quantity"),
                        BrandName = brndname,
                        StockInHand = stkInHnd,
                        Description = reader.GetValue<string>("Description"),
                        CompanyName = reader.GetValue<string>("companyname"),
                        //DataSheetURL = reader.GetValue<string>("DataSheetURL"),
                        //DataSheetFileName = reader.GetValue<string>("DataSheetURL"),
                        PriceInINR = prcINR,
                        PriceInUSD = prcinUSD,
                        PriceInCNY = prcinCNY,
                        stockstatus = stkstatus,
                        country = cntry,
                        package = packge,
                        datecode = datecde

                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                throw;
            }
            return lst;
        }

        /// <summary>
        /// Delete Offer on Row Deleting From Offer Grid
        /// </summary>
        /// <param name="OfferId"></param>
        /// <param name="guid"></param>
        public void DeleteOfferOnRowDeleting(int OfferId, Guid UserId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("DeleteOffersOfUserByOfferId");
            db.AddInParameter(command, "@OfferId", DbType.Int32, OfferId);
            db.AddInParameter(command, "@UserId", DbType.Guid, UserId);
            db.ExecuteNonQuery(command);
        }

        /// <summary>
        /// Search Result for Master Page Search of Offers
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public IEnumerable<Component> SearchOffers(string searchText)
        {
            List<Component> requestsForUser = new List<Component>();

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("OfferSearch");

            db.AddInParameter(command, "@StringToSearch", DbType.String, searchText);

            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    requestsForUser.Add(fill(reader));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error in RequirementSearch for text: " + searchText);
            }
            return requestsForUser;
        }

        private Component fill(IDataReader reader)
        {
            Component dir = new Component();
            dir.CompanyName = reader.GetValue<string>("CompanyName");
            dir.Componentid = Convert.ToInt32(reader.GetValue<int>("OfferId"));
            dir.ComponentName = reader.GetValue<string>("ComponentName");
            dir.Quantity = reader.GetValue<int>("Quantity");
            dir.UserId = reader.GetValue<Guid>("UserId");
            dir.BrandName = reader.GetValue<string>("BrandName");
            dir.Description = reader.GetValue<string>("Description");
            dir.StockInHand = reader.GetValue<int>("StockInHand");
            dir.PriceInINR = reader.GetValue<int>("PriceInINR");
            dir.PriceInUSD = reader.GetValue<decimal>("PriceInUSD");
            dir.PriceInCNY = reader.GetValue<int>("PriceInCNY");
            dir.CreatedOn = reader.GetValue<DateTime>("CreatedOn");
            dir.ModifiedOn = reader.GetValue<DateTime>("ModifiedOn");
            dir.Status = reader.GetValue<int>("Status");
            dir.NotificationSent = reader.GetValue<bool>("NotificationSent");
            dir.datecode = reader.GetValue<string>("Datecode");
            dir.package = reader.GetValue<string>("Package");
            dir.country = reader.GetValue<string>("Country");
            dir.stockstatus = reader.GetValue<int>("StockStatus");
            dir.Archived = reader.GetValue<bool>("Archived");
            return dir;
        }

        /// <summary>
        /// New Method to Update offers takes object of Type Component 
        /// </summary>
        /// <param name="lstInventory"></param>
        public void updateOffersDAL(Component objOffers)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("UpdateOffers");
            DateTime modifieddate = DateTime.Now;

            db.AddInParameter(command, "@OfferId", DbType.Int32, objOffers.OfferId);
            db.AddInParameter(command, "@ComponentName", DbType.String, objOffers.ComponentName);
            db.AddInParameter(command, "@Quantity", DbType.Int32, objOffers.Quantity);
            db.AddInParameter(command, "@BrandName", DbType.String, objOffers.BrandName);
            db.AddInParameter(command, "@StockInHand", DbType.Int32, objOffers.StockInHand);
            db.AddInParameter(command, "@PriceInINR", DbType.Decimal, null);
            db.AddInParameter(command, "@PriceinUSD", DbType.Decimal, objOffers.PriceInUSD);
            db.AddInParameter(command, "@PriceinCNY", DbType.Decimal, null);
            db.AddInParameter(command, "@status", DbType.Int32, null);
            db.AddInParameter(command, "@ModifiedOn", DbType.DateTime, DateTime.Now);
            db.AddInParameter(command, "@Country", DbType.String, objOffers.country);
            db.AddInParameter(command, "@datecode", DbType.String, objOffers.datecode);
            db.AddInParameter(command, "@Package", DbType.String, objOffers.package);
            db.AddInParameter(command, "@StockStatus", DbType.Int32, objOffers.stockstatus);
            db.AddInParameter(command, "@Description", DbType.String, objOffers.Description);
            //db.AddInParameter(command, "@Archiv", DbType.Int32, 0);  //plz chk this is temp adjustment for Archv at the time of Update

            try
            {
                db.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

        /// <summary>
        /// Get Offer Details for OfferDetails.aspx page. User Get all offer details based on offerName 
        /// </summary>
        /// <param name="offerName"></param>
        /// <returns></returns>
        public List<Component> getOfferDetailsByOfferName(string offerName)
        {

            List<Component> requestsForUser = new List<Component>();

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("OfferDetailsByOfferName");

            db.AddInParameter(command, "@offerName", DbType.String, offerName);

            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    requestsForUser.Add(fill(reader));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error in OfferSearch for text: " + offerName);
            }
            return requestsForUser;
        }

        /// <summary>
        /// Get Offer Uploading Limit as per membership of the Users
        /// </summary>
        /// <param name="membershiptype"></param>
        /// <returns></returns>
        /// 



      
        public int GetOfferUploadingLimitAsPerMembershipType(int membershiptype)
        {

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetOfferUploadingLimitAsPerMembershipType");

            db.AddInParameter(command, "@membershiptype", DbType.String, membershiptype);

            db.AddOutParameter(command, "@Count", DbType.Int32, 0);

            int limit = 0;

            try
            {
                db.ExecuteNonQuery(command);

                limit = (int)command.Parameters["@Count"].Value;

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

            return limit;
        }

        public IEnumerable<Component> GetLatestOfferByHour()
        {
            List<Component> lst = new List<Component>();
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetLatestOffer");

            //db.AddInParameter(command, "@Hour", DbType.Int32, hour);
            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    lst.Add(fill(reader));
                }

                reader.Close();
                lst.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                return null;
            }

            return lst.AsEnumerable();
        }

        public void UpdateNotificationSent(Component objLatestOffer)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateNotificationSentByOfferId");

            try
            {
                db.AddInParameter(command, "@OfferId", DbType.Int32, objLatestOffer.Componentid);
                db.AddInParameter(command, "@NotificationSent", DbType.Boolean, objLatestOffer.NotificationSent);
                db.ExecuteNonQuery(command);

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                command.Dispose();
            }
        }
    }
}
