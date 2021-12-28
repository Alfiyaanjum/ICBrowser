using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using ICBrowser.Common;

namespace ICBrowser.DAL
{
    public static class DataReaderHelper
    {

        public static T GetValue<T>(this IDataReader reader, string column)
        {
            try
            {
                int index = 0;
                index = reader.GetOrdinal(column);

                if (!reader.IsDBNull(index))
                {
                    return (T)reader[index];
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                //return false;
                return default(T);
            }
        }
    }
}
