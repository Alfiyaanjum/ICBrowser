using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ICBrowser.Common;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data.OleDb;


namespace ICBrowser.DAL
{
    public class ComponentRepository : Repository
    {

        #region PrivateFunctions
        private Component fill(IDataReader reader)
        {
            Component inventoryEntity = new Component();

            //inventoryEntity.Componentid = reader.GetValue<int>("ComponentId");
            inventoryEntity.ComponentName = reader.GetValue<String>("ComponentName");
            inventoryEntity.UserId = reader.GetValue<Guid>("UserId");
            inventoryEntity.Quantity = reader.GetValue<int>("Quantity");
            inventoryEntity.BrandName = reader.GetValue<String>("BrandName");
            inventoryEntity.Description = reader.GetValue<String>("Description");
            //inventoryEntity.StockInHand = reader.GetValue<int>("StockInHand");
            //inventoryEntity.PriceInINR = reader.GetValue<decimal>("PriceInINR");
            inventoryEntity.PriceInUSD = reader.GetValue<decimal>("PriceInUSD");
            //inventoryEntity.DataSheetURL = reader.GetValue<String>("DatasheetURl");
            inventoryEntity.CreatedOn = reader.GetValue<DateTime>("CreatedOn");
            inventoryEntity.CompanyName = reader.GetValue<String>("CompanyName");
            //inventoryEntity.AvailableFrom = reader.GetValue<DateTime>("AvailableFrom");
            inventoryEntity.ModifiedOn = reader.GetValue<DateTime>("ModifiedOn");
            //inventoryEntity.Status = reader.GetValue<int>("Status");
            //inventoryEntity.PriceInCNY = reader.GetValue<decimal>("PriceInCNY");
            inventoryEntity.datecode = reader.GetValue<string>("DateCode");
            inventoryEntity.stockstatus = reader.GetValue<int>("StockStatus");
            inventoryEntity.package = reader.GetValue<string>("Package");
            //inventoryEntity.country = reader.GetValue<string>("country");
            //inventoryEntity.NotificationSent = reader.GetValue<bool>("NotificationSent");
            inventoryEntity.isOffer = reader.GetValue<int>("Flag");
            inventoryEntity.Archev = reader.GetValue<int>("Arch");
            return inventoryEntity;


        }

        #endregion

        #region PublicFunctions

        public List<UserDetails> GetEmailIds(string UserIds)
        {
            List<UserDetails> lstEmail = new List<UserDetails>();
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("[GetEmailIdByUserIds]");

            db.AddInParameter(command, "@UserIds", DbType.String, UserIds);
            //db.AddInParameter(command, "@Uid", DbType.Guid, uid);

            IDataReader reader = (IDataReader)db.ExecuteReader(command);
            try
            {
                db.ExecuteNonQuery(command);
                while (reader.Read())
                {
                    lstEmail.Add(new UserDetails()
                    {
                        EmailId = reader.GetValue<string>("email"),
                        UserID = reader.GetValue<Guid>("userid"),
                        ContactName = reader.GetValue<string>("ContactName"),
                    });

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());

            }
            return lstEmail;

        }

        /// <summary>
        /// deletes records i.e Component,Offers of Members who have degraded their membership
        /// </summary>
        /// <param name="userId"></param>

        public void deleteDegradedMembersData(Guid userId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[DeleteDegradedUsersRecord]");

            db.AddInParameter(command, "@UserId", DbType.Guid, userId);

            try
            {
                db.ExecuteNonQuery(command);
                //return true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                //  return false;
            }

        }

        public bool UpdateOfflineSubscription(UserDetails ud)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[UpdateOfflineSubscription]");

            db.AddInParameter(command, "@UserId", DbType.Guid, ud.UserID);

            try
            {
                db.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                return false;
            }
        }

        public List<UserDetails> GetOfflineSubscriDetails()
        {
            List<UserDetails> lstOffSubDetail = new List<UserDetails>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetOfflineSubscriptDetails");
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lstOffSubDetail.Add(new UserDetails()
                    {
                        UserID = reader.GetValue<Guid>("UserID"),
                        UserName = reader.GetValue<string>("UserName"),
                        CompanyName = reader.GetValue<string>("CompanyName"),
                        ContactName = reader.GetValue<string>("ContactName"),
                        CreateDate = reader.GetValue<DateTime>("CreateDate"),
                        EmailId = reader.GetValue<string>("Email"),
                    });
                }

                reader.Close();
                lstOffSubDetail.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);

            }
            return lstOffSubDetail;
        }

        /// <summary>
        /// gets membership Expiry date
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int MembershipExpiredDate(Guid userid)
        {

            string usertologin = userid.ToString();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("getMembershipExpiredDate");
            db.AddInParameter(command, "@UserId", DbType.String, usertologin);
            db.AddOutParameter(command, "@temp", DbType.Int32, 0);
            db.ExecuteNonQuery(command);
            int Membershipstatus = 0;
            Membershipstatus = Convert.ToInt32(command.Parameters["@temp"].Value);
            return Membershipstatus;
        }



        /// <param name="curruserId"></param>
        /// <returns></returns>
        public DataTable getSellerId(Guid curruserId)  //gets sellerId ,company Name ,Membership type
        {
            DataTable dtgetSellid = new DataTable();
            SqlConnection cn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "GetUserId";
                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@UserId";
                p1.Value = curruserId;
                p1.DbType = DbType.Guid;
                cmd.Parameters.Add(p1);
                da.SelectCommand = cmd;
                da.Fill(dtgetSellid);


            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

            finally
            {
                cn.Close();
            }
            return dtgetSellid;

        }



        public IEnumerable<Component> SearchComponents(string searchText, Guid loggedinUserId)
        {
            List<Component> requestsForUser = new List<Component>();

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("SearchComponentOffer");

            db.AddInParameter(command, "@StringToSearch", DbType.String, searchText);
            db.AddInParameter(command, "@LoggedInUserId", DbType.Guid, loggedinUserId);

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
                IClogger.LogError(ex, "Error in SearchComponents for text: " + searchText);
            }
            return requestsForUser;

        }

        public List<Component> GetSellerInventoryDetails(Guid loggedinUserId) //gets list of SellerId ,company Name,Data
        {
            List<Component> lst = new List<Component>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[SellerInventoryListing]");
            db.AddInParameter(command, "@loggedinUserId", DbType.Guid, loggedinUserId);
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lst.Add(new Component()
                    {
                        CompanyName = reader.GetValue<string>("CompanyName"),
                        UserId = reader.GetValue<Guid>("UserId"),
                        BrandName = reader.GetValue<string>("BrandName"),
                        Description = reader.GetValue<string>("description"),
                        datecode = reader.GetValue<string>("DateCode"),
                        package = reader.GetValue<string>("Package"),
                        Quantity = reader.GetValue<int>("Quantity"),
                        ComponentName = reader.GetValue<string>("ComponentName")
                    });
                }
                reader.Close();
                lst.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);

            }
            return lst;
        }

        /// <summary>
        /// gets the saved Components count of a seller
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        /// 
        public int getComponentCountBySellerId(Guid UserId)
        {

            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[GetSellerComponentCount]");

            db.AddInParameter(command, "@UserId", DbType.Guid, UserId);

            try
            {
                int cnt = 0;
                //db.ExecuteNonQuery(command);
                cnt = Convert.ToInt32(db.ExecuteScalar(command));
                return cnt;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
                return 0;
            }


        }

        public int getOfferCountBySellerId(Guid UserId)
        {

            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[GetSellerOfferCount]");

            db.AddInParameter(command, "@UserId", DbType.Guid, UserId);

            try
            {
                int cnt = 0;
                //db.ExecuteNonQuery(command);
                cnt = Convert.ToInt32(db.ExecuteScalar(command));
                return cnt;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
                return 0;
            }


        }

        public List<TypeOfMembership> GetSellersMemberShipDetails(int membershiptype) //gets all  details of seller from Membership table 
        {
            List<TypeOfMembership> lstMembersipType = new List<TypeOfMembership>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetMembershipDetails");
            db.AddInParameter(command, "@Membershiptype", DbType.Int32, membershiptype);

            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lstMembersipType.Add(new TypeOfMembership()
                    {
                        MembershipTypeId = reader.GetValue<int>("MembershipTypeId"),
                        MembershipTypeName = Convert.ToString(reader.GetValue<string>("MembershipTypeName")),
                        ListingCount = reader.GetValue<int>("ListingCount"),
                        Duration = reader.GetValue<int>("Duration"),
                    });
                }
                reader.Close();
                lstMembersipType.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);

            }
            return lstMembersipType;
        }

        public List<Component> GetComponentDetailsByComponentName(string componentName)
        {
            List<Component> lst = new List<Component>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[ComponentDetailsByComponentName]");
            db.AddInParameter(command, "@ComponentName", DbType.String, componentName);
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lst.Add(new Component()
                    {
                        UserId = reader.GetValue<Guid>("UserId"),
                        Quantity = reader.GetValue<int>("quantity"),
                        BrandName = reader.GetValue<string>("brandName"),
                        StockInHand = reader.GetValue<int>("stockInHand"),
                        stockstatus = reader.GetValue<int>("StockStatus"),
                        CompanyName = reader.GetValue<string>("companyName"),
                        PriceInINR = reader.GetValue<decimal>("priceInINR"),
                        PriceInUSD = reader.GetValue<decimal>("priceInUSD"),
                        PriceInCNY = reader.GetValue<decimal>("PriceInCNY"),
                        Description = reader.GetValue<string>("Description"),
                        //TypeOfMembership = reader.GetValue<int>("typeOfMembership"),
                    });
                }
                reader.Close();
                lst.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);

            }
            return lst;
        }



        public List<Component> GetDetailedInventory(int pageSize, int pageIndex)
        {
            List<Component> lstId = new List<Component>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetCompanyNameByComponentId");
            db.AddInParameter(command, "@PageSize", DbType.Int32, pageSize);
            db.AddInParameter(command, "@PageIndex", DbType.Int32, pageIndex);
            db.AddOutParameter(command, "@temp", DbType.Int32, 0);

            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lstId.Add(new Component()
                    {
                        CompanyName = reader.GetValue<string>("companyName"),
                        UserId = reader.GetValue<Guid>("UserId"),
                        ComponentName = Convert.ToString(reader.GetValue<string>("componentName")),
                        Quantity = reader.GetValue<int>("quantity"),
                        BrandName = reader.GetValue<string>("brandName"),
                        Description = Convert.ToString(reader.GetValue<string>("Description")),
                        Status = reader.GetValue<int>("Status"),
                        datecode = reader.GetValue<string>("DateCode"),
                        package = reader.GetValue<string>("Package"),
                        country = reader.GetValue<string>("PrimaryCountry"),
                        PriceInUSD = reader.GetValue<decimal>("PriceInUSD"),
                        isOffer = reader.GetValue<int>("flag"),
                        stockstatus = reader.GetValue<int>("stockstatus"),
                        ModifiedOn = reader.GetValue<DateTime>("ModifiedOn"),
                        City = reader.GetValue<string>("PrimaryCity"),
                        LandLine = reader.GetValue<string>("Landline"),
                        EmailId = reader.GetValue<string>("Email"),
                        QQId = reader.GetValue<string>("QQId"),
                        SkypeId = reader.GetValue<string>("SkypeId"),
                        MSNId = reader.GetValue<string>("MSNId")
                    });
                }

                reader.Close();
                TotalPages = Convert.ToInt32(command.Parameters["@temp"].Value);
                lstId.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return lstId;
        }

        /// <summary>
        /// New Method to Update Inventories takes List of Type Component 
        /// </summary>
        /// <param name="lstInventory"></param>
        public void updateInventoriesDAL(Component ObjInventory)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("UpdateBulkInventories");
            DateTime modifieddate = DateTime.Now;

            db.AddInParameter(command, "@ComponentId", DbType.Int32, ObjInventory.Componentid);
            db.AddInParameter(command, "@ComponentName", DbType.String, ObjInventory.ComponentName);
            db.AddInParameter(command, "@Quantity", DbType.Int32, ObjInventory.Quantity);
            db.AddInParameter(command, "@BrandName", DbType.String, ObjInventory.BrandName);
            db.AddInParameter(command, "@StockInHand", DbType.Int32, ObjInventory.StockInHand);
            db.AddInParameter(command, "@PriceInINR", DbType.Decimal, null);
            db.AddInParameter(command, "@PriceinUSD", DbType.Decimal, ObjInventory.PriceInUSD);
            db.AddInParameter(command, "@PriceinCNY", DbType.Decimal, null);
            db.AddInParameter(command, "@status", DbType.Int32, null);
            db.AddInParameter(command, "@ModifiedOn", DbType.DateTime, modifieddate);
            db.AddInParameter(command, "@Country", DbType.String, ObjInventory.country);
            db.AddInParameter(command, "@datecode", DbType.String, ObjInventory.datecode);
            db.AddInParameter(command, "@Package", DbType.String, ObjInventory.package);
            db.AddInParameter(command, "@Description", DbType.String, ObjInventory.Description);
            db.AddInParameter(command, "@StockStatus", DbType.Int32, ObjInventory.stockstatus);

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
        /// new method to insert inventory in list
        /// </summary>
        /// 

    
        public bool InsertInventoryManually(Common.Component lstInventory)
        {
            bool result = false;
            int count = 0;
            Common.Component objComponent = new Common.Component();
            //Insert inventory details from Excel sheet to database 
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("InsertInventoriesManually");

            db.AddInParameter(command, "@UserId", DbType.Guid, lstInventory.UserId);

            if (!string.IsNullOrEmpty(lstInventory.ComponentName))
                db.AddInParameter(command, "@ComponentName", DbType.String, lstInventory.ComponentName);
            else
                db.AddInParameter(command, "@ComponentName", DbType.String, null);

            if (!string.IsNullOrEmpty(lstInventory.Quantity.ToString()))
                db.AddInParameter(command, "@Quantity", DbType.Int32, lstInventory.Quantity);
            else
                db.AddInParameter(command, "@Quantity", DbType.Int32, null);

            if (!string.IsNullOrEmpty(lstInventory.BrandName))
                db.AddInParameter(command, "@BrandName", DbType.String, lstInventory.BrandName);
            else
                db.AddInParameter(command, "@BrandName", DbType.String, null);


            if (!string.IsNullOrEmpty(lstInventory.Description))
                db.AddInParameter(command, "@Description", DbType.String, lstInventory.Description);
            else
                db.AddInParameter(command, "@Description", DbType.String, null);



            if (!string.IsNullOrEmpty(lstInventory.PriceInUSD.ToString()))
                db.AddInParameter(command, "@PriceinUSD", DbType.Decimal, lstInventory.PriceInUSD);
            else
                db.AddInParameter(command, "@PriceinUSD", DbType.Decimal, null);


            db.AddInParameter(command, "@CreatedOn", DbType.DateTime, DateTime.Now);


            if (!string.IsNullOrEmpty(lstInventory.NotificationSent.ToString()))
                db.AddInParameter(command, "@NotiifcationSent", DbType.Boolean, lstInventory.NotificationSent);
            else
                db.AddInParameter(command, "@NotiifcationSent", DbType.Boolean, null);


            //if (!string.IsNullOrEmpty(lstInventory.ModifiedOn.ToString()))
            db.AddInParameter(command, "@ModifiedOn", DbType.DateTime, DateTime.Now);


            if (!string.IsNullOrEmpty(lstInventory.datecode))
                db.AddInParameter(command, "@datecode", DbType.String, lstInventory.datecode);
            else
                db.AddInParameter(command, "@datecode", DbType.String, null);


            if (!string.IsNullOrEmpty(lstInventory.package))
                db.AddInParameter(command, "@Package", DbType.String, lstInventory.package);
            else
                db.AddInParameter(command, "@Package", DbType.String, null);


            if (!string.IsNullOrEmpty(lstInventory.stockstatus.ToString()))
                db.AddInParameter(command, "@StockStatus", DbType.Int32, lstInventory.stockstatus);
            else
                db.AddInParameter(command, "@StockStatus", DbType.Int32, null);

            db.AddOutParameter(command, "@Count", DbType.Int32, 0);

            try
            {
                objComponent.UserId = (Guid)command.Parameters["@UserId"].Value;
                count=db.ExecuteNonQuery(command);
                if (count == 1)
                    result = true;
               // count = (int)command.Parameters["@Count"].Value;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);

            }
            return result;
        }

        public bool InsertInventory(Common.Component lstInventory)
        {
            bool result = false;
            Common.Component objComponent = new Common.Component();
            //Insert inventory details from Excel sheet to database 
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("InsertInventories");

            db.AddInParameter(command, "@UserId", DbType.Guid, lstInventory.UserId);

            if (!string.IsNullOrEmpty(lstInventory.ComponentName))
                db.AddInParameter(command, "@ComponentName", DbType.String, lstInventory.ComponentName);
            else
                db.AddInParameter(command, "@ComponentName", DbType.String, null);

            if (!string.IsNullOrEmpty(lstInventory.Quantity.ToString()))
                db.AddInParameter(command, "@Quantity", DbType.Int32, lstInventory.Quantity);
            else
                db.AddInParameter(command, "@Quantity", DbType.Int32, null);

            if (!string.IsNullOrEmpty(lstInventory.BrandName))
                db.AddInParameter(command, "@BrandName", DbType.String, lstInventory.BrandName);
            else
                db.AddInParameter(command, "@BrandName", DbType.String, null);


            if (!string.IsNullOrEmpty(lstInventory.Description))
                db.AddInParameter(command, "@Description", DbType.String, lstInventory.Description);
            else
                db.AddInParameter(command, "@Description", DbType.String, null);



            if (!string.IsNullOrEmpty(lstInventory.PriceInUSD.ToString()))
                db.AddInParameter(command, "@PriceinUSD", DbType.Decimal, lstInventory.PriceInUSD);
            else
                db.AddInParameter(command, "@PriceinUSD", DbType.Decimal, null);


            db.AddInParameter(command, "@CreatedOn", DbType.DateTime, DateTime.Now);


            if (!string.IsNullOrEmpty(lstInventory.NotificationSent.ToString()))
                db.AddInParameter(command, "@NotiifcationSent", DbType.Boolean, lstInventory.NotificationSent);
            else
                db.AddInParameter(command, "@NotiifcationSent", DbType.Boolean, null);


            //if (!string.IsNullOrEmpty(lstInventory.ModifiedOn.ToString()))
            db.AddInParameter(command, "@ModifiedOn", DbType.DateTime, DateTime.Now);


            if (!string.IsNullOrEmpty(lstInventory.datecode))
                db.AddInParameter(command, "@datecode", DbType.String, lstInventory.datecode);
            else
                db.AddInParameter(command, "@datecode", DbType.String, null);


            if (!string.IsNullOrEmpty(lstInventory.package))
                db.AddInParameter(command, "@Package", DbType.String, lstInventory.package);
            else
                db.AddInParameter(command, "@Package", DbType.String, null);


            if (!string.IsNullOrEmpty(lstInventory.stockstatus.ToString()))
                db.AddInParameter(command, "@StockStatus", DbType.Int32, lstInventory.stockstatus);
            else
                db.AddInParameter(command, "@StockStatus", DbType.Int32, null);

            //  db.AddOutParameter(command, "@Count", DbType.Int32, 0);

            try
            {
                objComponent.UserId = (Guid)command.Parameters["@UserId"].Value;
                int count = db.ExecuteNonQuery(command);
                if (count == 1)
                    result = true;
                //count = (int)command.Parameters["@Count"].Value;
            }
            catch (Exception ex)
            {
                result = false;
                IClogger.LogError(ex.Message);

            }
            return result;
        }

        public int DeleteOffers(int stockstatus, Guid Userid)
        {
            int count = 0;
            SqlDatabase db = new SqlDatabase(ConnectionString);

            List<Component> list = new List<Component>();
            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand("OverwriteOffers", con);

            db.AddInParameter(cmd, "@UserId", DbType.Guid, Userid);

            db.AddInParameter(cmd, "@StockStatus", DbType.Int32, stockstatus);
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = (IDataReader)db.ExecuteReader(cmd);

            while (reader.Read())
            {
                list.Add(new Component()
                {
                    UserId = reader.GetValue<Guid>("UserId"),
                    ComponentName = reader.GetValue<string>("ComponentName"),
                    Quantity = reader.GetValue<int>("Quantity"),
                    BrandName = reader.GetValue<string>("BrandName"),
                    Description = reader.GetValue<string>("Description"),
                    PriceInUSD = reader.GetValue<decimal>("PriceinUSD"),
                    CreatedOn = reader.GetValue<DateTime>("CreatedOn"),
                    NotificationSent = reader.GetValue<bool>("NotiifcationSent"),
                    ModifiedOn = reader.GetValue<DateTime>("ModifiedOn"),
                    datecode = reader.GetValue<string>("datecode"),
                    package = reader.GetValue<string>("Package"),
                    stockstatus = reader.GetValue<int>("StockStatus")
                });
                count++;
            }

            reader.Close();

            // // List<DataRow> list = dt.AsEnumerable().ToList();
            return count;
        }


        public int DeleteInventory(int stockstatus, Guid Userid)
        {
            int count = 0;
            bool result = false;
            SqlDatabase db = new SqlDatabase(ConnectionString);

            List<Component> list = new List<Component>();
            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand("OverwriteInventories", con);

            db.AddInParameter(cmd, "@UserId", DbType.Guid, Userid);

            db.AddInParameter(cmd, "@StockStatus", DbType.Int32, stockstatus);
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = (IDataReader)db.ExecuteReader(cmd);

            while (reader.Read())
            {
                list.Add(new Component()
                {
                    UserId = reader.GetValue<Guid>("UserId"),
                    ComponentName = reader.GetValue<string>("ComponentName"),
                    Quantity = reader.GetValue<int>("Quantity"),
                    BrandName = reader.GetValue<string>("BrandName"),
                    Description = reader.GetValue<string>("Description"),
                    PriceInUSD = reader.GetValue<decimal>("PriceinUSD"),
                    CreatedOn = reader.GetValue<DateTime>("CreatedOn"),
                    NotificationSent = reader.GetValue<bool>("NotiifcationSent"),
                    ModifiedOn = reader.GetValue<DateTime>("ModifiedOn"),
                    datecode = reader.GetValue<string>("datecode"),
                    package = reader.GetValue<string>("Package"),
                    stockstatus = reader.GetValue<int>("StockStatus")

                });
                count++;

            }

            reader.Close();

            // // List<DataRow> list = dt.AsEnumerable().ToList();
            return count;
        }
        public int OverWriteInventory(Common.Component lstInventory)
        {
            int count = 0;
            int Deleted = 0;
            Common.Component objComponent = new Common.Component();
            //Insert inventory details from Excel sheet to database 
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("OverwriteInventories");

            db.AddInParameter(command, "@UserId", DbType.Guid, lstInventory.UserId);

            if (!string.IsNullOrEmpty(lstInventory.ComponentName))
                db.AddInParameter(command, "@ComponentName", DbType.String, lstInventory.ComponentName);
            else
                db.AddInParameter(command, "@ComponentName", DbType.String, null);

            if (!string.IsNullOrEmpty(lstInventory.Quantity.ToString()))
                db.AddInParameter(command, "@Quantity", DbType.Int32, lstInventory.Quantity);
            else
                db.AddInParameter(command, "@Quantity", DbType.Int32, null);

            if (!string.IsNullOrEmpty(lstInventory.BrandName))
                db.AddInParameter(command, "@BrandName", DbType.String, lstInventory.BrandName);
            else
                db.AddInParameter(command, "@BrandName", DbType.String, null);


            if (!string.IsNullOrEmpty(lstInventory.Description))
                db.AddInParameter(command, "@Description", DbType.String, lstInventory.Description);
            else
                db.AddInParameter(command, "@Description", DbType.String, null);



            if (!string.IsNullOrEmpty(lstInventory.PriceInUSD.ToString()))
                db.AddInParameter(command, "@PriceinUSD", DbType.Decimal, lstInventory.PriceInUSD);
            else
                db.AddInParameter(command, "@PriceinUSD", DbType.Decimal, null);


            db.AddInParameter(command, "@CreatedOn", DbType.DateTime, DateTime.Now);


            if (!string.IsNullOrEmpty(lstInventory.NotificationSent.ToString()))
                db.AddInParameter(command, "@NotiifcationSent", DbType.Boolean, lstInventory.NotificationSent);
            else
                db.AddInParameter(command, "@NotiifcationSent", DbType.Boolean, null);


            //if (!string.IsNullOrEmpty(lstInventory.ModifiedOn.ToString()))
            db.AddInParameter(command, "@ModifiedOn", DbType.DateTime, DateTime.Now);


            if (!string.IsNullOrEmpty(lstInventory.datecode))
                db.AddInParameter(command, "@datecode", DbType.String, lstInventory.datecode);
            else
                db.AddInParameter(command, "@datecode", DbType.String, null);


            if (!string.IsNullOrEmpty(lstInventory.package))
                db.AddInParameter(command, "@Package", DbType.String, lstInventory.package);
            else
                db.AddInParameter(command, "@Package", DbType.String, null);


            if (!string.IsNullOrEmpty(lstInventory.stockstatus.ToString()))
                db.AddInParameter(command, "@StockStatus", DbType.Int32, lstInventory.stockstatus);
            else
                db.AddInParameter(command, "@StockStatus", DbType.Int32, null);

            db.AddOutParameter(command, "@Count", DbType.Int32, 0);
            db.AddOutParameter(command, "@Deleted", DbType.Int32, 0);

            try
            {
                objComponent.UserId = (Guid)command.Parameters["@UserId"].Value;
                db.ExecuteNonQuery(command);
                count = (int)command.Parameters["@Count"].Value;

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);

            }
            return count;
        }


        /// <summary>
        /// delete's the Selected Component from  list in grid
        /// </summary>
        /// <param name="ComponentId"></param>
        /// <returns></returns>
        public bool delete(int ComponentId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("deleteComponent");

            db.AddInParameter(command, "@ComponentId", DbType.Int32, ComponentId);

            try
            {
                db.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// gets the result of Search in grid
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable SelectInventoryDetailsforGrid(Guid UserId)
        {
            DataTable dtgetdetailsbyId = new DataTable();

            SqlConnection cn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = "SelectInventoryDetailsOnlyById";
                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@UserId";
                p1.Value = UserId;
                p1.DbType = DbType.Guid;
                cmd.Parameters.Add(p1);

                da.SelectCommand = cmd;
                da.Fill(dtgetdetailsbyId);

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

            finally
            {
                cn.Close();
            }
            return dtgetdetailsbyId;

        }


        /// <summary>
        /// This method validates if the current user who is logged in is a Seller or not and return TypeMembershipId Compoanyname UserId
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public UserProfile GetSellersCount(Guid userID)
        {
            UserProfile objUserProfile = new UserProfile();

            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            //  int count = 0;
            try
            {
                DbCommand command = db.GetStoredProcCommand("[GetUserId]");
                db.AddInParameter(command, "@UserId", DbType.Guid, userID);

                IDataReader DataReader = (IDataReader)db.ExecuteReader(command);
                objUserProfile = GetUserDetails(DataReader);

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return objUserProfile;
        }

        private UserProfile GetUserDetails(IDataReader reader)
        {
            //CompanyDetails usersDetails = new CompanyDetails();
            UserProfile Obj = new UserProfile();
            try
            {
                while (reader.Read())
                {
                    //  Obj.objUserDetails.UserID = reader.GetValue<Guid>("UserId");

                    Obj.UserID = reader.GetValue<Guid>("UserId");
                    Obj.CompanyName = reader.GetValue<string>("CompanyName");
                    Obj.TypeOfMembership = reader.GetValue<int>("TypeOfMembership");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

            return Obj;
        }




        public List<Component> GetSearchedData(Guid UserId, string searchtext, int SelectType)
        {
            List<Component> lst = new List<Component>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("getSellerInventoryDetailsForSearch");
            db.AddInParameter(command, "@UserId", DbType.Guid, UserId);
            db.AddInParameter(command, "@SearchText", DbType.String, searchtext);
            db.AddInParameter(command, "@SelectType", DbType.Int32, SelectType);
            try
            {
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    // !string.IsNullOrEmpty(lstInventory.ComponentName)
                    string brndname = reader.GetValue<string>("brandname");
                    if (!string.IsNullOrEmpty(brndname))
                    {
                        brndname = reader.GetValue<string>("brandname");
                    }
                    else
                    {
                        brndname = "";
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

                    string cntry = reader.GetValue<string>("Country");
                    if (!string.IsNullOrEmpty(cntry))
                    {
                        cntry = reader.GetValue<string>("Country");
                    }
                    else
                    {
                        cntry = "";
                    }

                    string packge = reader.GetValue<string>("Package");
                    if (!string.IsNullOrEmpty(packge))
                    {
                        packge = reader.GetValue<string>("Package");
                    }
                    else
                    {
                        packge = "";
                    }

                    string datecde = reader.GetValue<string>("DateCode");
                    if (!string.IsNullOrEmpty(datecde))
                    {
                        datecde = reader.GetValue<string>("DateCode");
                    }
                    else
                    {
                        datecde = "";
                    }

                    string description = reader.GetValue<string>("Description");
                    if (!string.IsNullOrEmpty(description))
                    {
                        description = reader.GetValue<string>("Description");
                    }
                    else
                    {
                        description = "";
                    }


                    lst.Add(new Component
                    {
                        Componentid = reader.GetValue<int>("Componentid"),
                        Status = reader.GetValue<int>("Status"),
                        ComponentName = reader.GetValue<string>("componentName"),
                        Quantity = reader.GetValue<int>("quantity"),
                        BrandName = brndname,
                        StockInHand = stkInHnd,
                        CompanyName = reader.GetValue<string>("companyname"),
                        //DataSheetURL = reader.GetValue<string>("DataSheetURL"),
                        //DataSheetFileName = reader.GetValue<string>("DataSheetURL"),
                        PriceInINR = prcINR,
                        PriceInUSD = prcinUSD,
                        PriceInCNY = prcinCNY,
                        stockstatus = stkstatus,
                        Description = description,
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

        public TypeOfMembership getMembershipDetails(int typeOfMembership)
        {

            TypeOfMembership obj = new TypeOfMembership();
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetMembershipDetails");

            db.AddInParameter(command, "@MembershipType", DbType.Int32, typeOfMembership);
            try
            {
                IDataReader reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    obj = fillMembershipDetails(reader);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                return null;
            }

            return obj;
        }

        private TypeOfMembership fillMembershipDetails(IDataReader reader)
        {
            TypeOfMembership membershipDetailsObj = new TypeOfMembership();

            membershipDetailsObj.MembershipTypeId = reader.GetValue<int>("MembershipTypeId");
            membershipDetailsObj.MembershipTypeName = reader.GetValue<string>("MembershipTypeName");
            membershipDetailsObj.ListingCount = reader.GetValue<int>("ListingCount");
            membershipDetailsObj.Duration = reader.GetValue<int>("Duration");
            membershipDetailsObj.Amount = reader.GetValue<decimal>("Amount");

            return membershipDetailsObj;
        }

        public IEnumerable<Component> GetLatestComponentByHour()
        {
            List<Component> lst = new List<Component>();
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetLatestComponent");

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


        #endregion

        public int TotalPages { get; set; }

        public List<ICBrowser.Common.Component> filterSearchComponent(Guid userId, string partNumber, int quantity, string make, string package, string dateCode, string stockStatus, string lastupdated, int exMatch)
        {
            List<ICBrowser.Common.Component> requestsForUser = new List<Component>();

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("[FILTER_COMPONENT_OFFER_SEARCH]");

            db.AddInParameter(command, "@LoggedInUserId", DbType.Guid, userId);

            if (!string.IsNullOrEmpty(partNumber))
                db.AddInParameter(command, "@PartNumber", DbType.String, partNumber);
            else
                db.AddInParameter(command, "@PartNumber", DbType.String, null);
            db.AddInParameter(command, "@Quantity", DbType.String, quantity);
            if (!string.IsNullOrEmpty(make))
                db.AddInParameter(command, "@Make", DbType.String, make);
            else
                db.AddInParameter(command, "@Make", DbType.String, null);
            if (!string.IsNullOrEmpty(package))
                db.AddInParameter(command, "@Package", DbType.String, package);
            else
                db.AddInParameter(command, "@Package", DbType.String, null);
            if (!string.IsNullOrEmpty(dateCode))
                db.AddInParameter(command, "@DateCode", DbType.String, dateCode);
            else
                db.AddInParameter(command, "@DateCode", DbType.String, null);
            db.AddInParameter(command, "@StockStatus", DbType.String, stockStatus);
            db.AddInParameter(command, "@LastUpdated", DbType.String, lastupdated);
            db.AddInParameter(command, "@exMatch", DbType.Int32, exMatch);

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
                IClogger.LogError(ex, "Error in SearchComponents for text ");
            }
            return requestsForUser;
        }

        public void UpdateNotificationSent(Component objLatestComp)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateNotificationSentByComponentId");

            try
            {
                db.AddInParameter(command, "@ComponentId", DbType.Int32, objLatestComp.Componentid);
                db.AddInParameter(command, "@NotificationSent", DbType.Boolean, objLatestComp.NotificationSent);
                db.ExecuteNonQuery(command);

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            finally
            {

            }
        }

        public List<Component> GetUserOfferDetailsForMatch(Guid userId, Guid loggedInUserId)
        {
            List<Component> lst = new List<Component>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[UserOfferDetailsForMatch]");
            db.AddInParameter(command, "@UserId", DbType.Guid, userId);
            db.AddInParameter(command, "@loggedInUserId", DbType.Guid, loggedInUserId);
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lst.Add(new Component()
                    {
                        UserId = reader.GetValue<Guid>("UserId"),
                        CompanyName = reader.GetValue<string>("CompanyName"),
                        ComponentName = reader.GetValue<string>("ComponentName"),
                        Quantity = reader.GetValue<Int32>("Quantity"),
                        datecode = reader.GetValue<string>("datecode"),
                        BrandName = reader.GetValue<string>("BrandName"),
                        package = reader.GetValue<string>("package"),
                        stockstatus = reader.GetValue<Int32>("stockstatus"),
                        PriceInUSD = reader.GetValue<decimal>("PriceInUSD"),
                        Description = reader.GetValue<string>("Description"),
                        ModifiedOn = reader.GetValue<DateTime>("ModifiedOn"),
                        CreatedOn = reader.GetValue<DateTime>("CreatedOn")


                    });
                }
                reader.Close();
                lst.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);

            }
            return lst;
        }

        public List<Component> GetAllInventoryDetailsForMatch(Guid userId, int pageSize, int pageIndex)
        {

            List<Component> lst = new List<Component>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[GetAllInventoryDetailsForMatch]");
            db.AddInParameter(command, "@UserId", DbType.Guid, userId);
            db.AddInParameter(command, "@PageSize", DbType.Int32, pageSize);
            db.AddInParameter(command, "@PageIndex", DbType.Int32, pageIndex);
            db.AddOutParameter(command, "@returnValue", DbType.Int32, 0);
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lst.Add(new Component()
                    {
                        ComponentName = reader.GetValue<string>("ComponentName"),
                        UserId = reader.GetValue<Guid>("UserId"),
                        datecode = reader.GetValue<string>("datecode"),
                        BrandName = reader.GetValue<string>("BrandName"),
                        package = reader.GetValue<string>("package"),
                        Quantity = reader.GetValue<int>("Quantity"),
                        CompanyName = reader.GetValue<string>("CompanyName"),
                        Description = reader.GetValue<string>("Description"),
                        PriceInUSD = reader.GetValue<decimal>("PriceInUSD"),
                        Flag = reader.GetValue<int>("Flag"),
                        CreatedOn = reader.GetValue<DateTime>("CreatedOn")
                    });
                }

                reader.Close();
                TotalPages = Convert.ToInt32(command.Parameters["@returnValue"].Value);
                lst.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);

            }
            return lst;
        }

        public List<Component> GetAllInventoryDetailsForMatchSearchDAL(Guid userId, string searchtext)
        {

            List<Component> lst = new List<Component>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[GetAllInventoryDetailsForSearchMatch]");
            db.AddInParameter(command, "@UserId", DbType.Guid, userId);
            db.AddInParameter(command, "@searchtext", DbType.String, searchtext);
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lst.Add(new Component()
                    {
                        ComponentName = reader.GetValue<string>("ComponentName"),
                        UserId = reader.GetValue<Guid>("UserId"),
                        datecode = reader.GetValue<string>("datecode"),
                        BrandName = reader.GetValue<string>("BrandName"),
                        package = reader.GetValue<string>("package"),
                        Quantity = reader.GetValue<int>("Quantity"),
                        CompanyName = reader.GetValue<string>("CompanyName"),
                        Flag = reader.GetValue<int>("Flag")
                    });
                }
                reader.Close();
                lst.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);

            }
            return lst;
        }

        public List<UserDetails> GetDeclineUserDetails()
        {
            List<UserDetails> lstDeclineUsrDetail = new List<UserDetails>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetDeclineUserDetails");
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lstDeclineUsrDetail.Add(new UserDetails()
                    {
                        UserID = reader.GetValue<Guid>("UserID"),
                        UserName = reader.GetValue<string>("UserName"),
                        CompanyName = reader.GetValue<string>("CompanyName"),
                        ContactName = reader.GetValue<string>("ContactName"),
                        CreateDate = reader.GetValue<DateTime>("CreateDate"),
                        EmailId = reader.GetValue<string>("Email"),
                        ReasonToDecline = reader.GetValue<string>("ReasonToDecline"),
                        TypeOfMembership = reader.GetValue<Int32>("TypeOfMembership"),
                        OfflineMembership = reader.GetValue<Int32>("OfflineMembership"),
                    });
                }

                reader.Close();
                lstDeclineUsrDetail.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);

            }
            return lstDeclineUsrDetail;
        }
    }
}
