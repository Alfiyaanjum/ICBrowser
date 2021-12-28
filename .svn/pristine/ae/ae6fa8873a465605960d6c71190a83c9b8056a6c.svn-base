using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace ICBrowser.Business
{
  public  class ExcelService
    {

        #region Private Fields

        private readonly String _path;

        private readonly String _extension;

        private String[] _sheets;

        #endregion

        #region Public Property

        public String[] Sheets
        {
            get
            {
                return _sheets;
            }
        }

        #endregion

        #region Public Constructor

        public ExcelService(String pPath)
        {
            _path = pPath;
            _extension = System.IO.Path.GetExtension(_path).ToLower();

            fillSheetsName();
        }

        #endregion

        #region Public Methods

        public DataTable GetSheetData(String pSheetName)
        {
            if (_sheets.Contains(pSheetName))
            {
                string columnList = "*";// GetColumnListForQuery(pSheetName, 20);

                OleDbConnection conn = getConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    using (conn)
                    {
                        if (!string.IsNullOrEmpty(columnList))
                        {
                            using (OleDbDataAdapter da = new OleDbDataAdapter(String.Format("SELECT {1} FROM [{0}]", pSheetName, columnList), conn))
                            {
                                DataTable dt = new DataTable(pSheetName);

                                da.Fill(dt);

                                return dt;
                            }
                        }
                        else
                            return null;
                    }

                }
                else
                {
                    throw new System.Data.DataException("Sheet already open.");
                }

            }
            else
            {
                throw new System.ArgumentException("Sheet name not found.");
            }
        }

        #endregion

        #region Private Methods

        private void fillSheetsName()
        {
            OleDbConnection conn = getConnection();

            if (conn.State == ConnectionState.Closed)
            {
                using (conn)
                {
                    conn.Open();
                    DataTable dbSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables_Info, null);

                    if (dbSchema == null || dbSchema.Rows.Count == 0)
                    {
                        throw new DataException("No sheets found in excel.");
                    }

                    List<String> sheets = new List<String>(dbSchema.Rows.Count);
                    foreach (DataRow dr in dbSchema.Select("CARDINALITY = 0"))
                    {
                        sheets.Add((String)dr["TABLE_NAME"]);
                    }

                    _sheets = sheets.ToArray();
                }
            }
        }

        private OleDbConnection getConnection()
        {
            string provider = string.Empty;
            string extendedProperties = string.Empty;
            switch (_extension)
            {
                case ".xlsx":
                    provider = "Microsoft.ACE.OLEDB.12.0";
                    extendedProperties = "Excel 12.0";
                    break;
                case ".xlsm":
                    provider = "Microsoft.ACE.OLEDB.12.0";
                    extendedProperties = "Excel 12.0 Macro;HDR=YES";
                    break;
                default:
                    provider = "Microsoft.Jet.OLEDB.4.0";
                    extendedProperties = "Excel 8.0";
                    break;


                //case ".xlsx":
                //    provider = "Microsoft.Jet.OLEDB.4.0";
                //    extendedProperties = "Excel 8.0";
                //    break;
                //case ".xlsm":
                //    provider = "Microsoft.Jet.OLEDB.4.0";
                //    extendedProperties = "Excel 8.0";
                //    break;
                //default:
                //    provider = "Microsoft.Jet.OLEDB.4.0";
                //    extendedProperties = "Excel 8.0";
                //    break;
            }

            return new OleDbConnection(String.Format("Provider={0};Data Source={1};Extended Properties=\"{2};HDR=Yes;IMEX=1\"", provider, _path, extendedProperties));

        }


        private string GetColumnListForQuery(string fileName, int columnCount)
        {
            OleDbConnection conn = getConnection();

            if (conn.State == ConnectionState.Closed)
            {
                using (conn)
                {
                    conn.Open();
                    DataTable dbSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);

                    if (dbSchema == null || dbSchema.Select("TABLE_NAME = '" + fileName + "'").Count() == 0)
                    {
                        throw new DataException("No sheets found in excel.");
                    }
                    StringBuilder columnList = new StringBuilder();
                    List<String> sheets = new List<String>(dbSchema.Select("TABLE_NAME = '" + fileName + "'").Count());
                    int count = 0;
                    foreach (DataRow dr in dbSchema.Select("TABLE_NAME = '" + fileName + "'"))
                    {
                        if (count == columnCount)
                            break;

                        if (columnList.Length == 0)
                            columnList.Append(Convert.ToString(dr["COLUMN_NAME"]));
                        else
                        {
                            columnList.Append(",");
                            columnList.Append(Convert.ToString(dr["COLUMN_NAME"]));
                        }
                        count += 1;

                    }
                    return columnList.ToString();
                }
            }
            return string.Empty;
        }

        #endregion
    }
}
