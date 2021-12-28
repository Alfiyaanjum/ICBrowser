using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;


namespace ICBrowser.DAL
{
    public class SellerInventoryRepository : Repository
    {
        public List<SellerInventory> GetSellerInventoryDetails()
        {
            List<SellerInventory> lst = new List<SellerInventory>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("sp_SellersInventoryListing");
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lst.Add(new SellerInventory()
                    {
                        ComponentName = Convert.ToString(reader.GetValue<string>("componentName")),
                        Quantity = reader.GetValue<int>("quantity"),
                        BrandName = reader.GetValue<string>("brandName"),
                        StockInHand = reader.GetValue<int>("stockInHand"),
                        AvailFrom = reader.GetValue<DateTime>("availFrom"),
                    });
                }
                lst.TrimExcess();
            }
            catch (Exception ex)
            {

            }
            return lst;
        }
    }
}
