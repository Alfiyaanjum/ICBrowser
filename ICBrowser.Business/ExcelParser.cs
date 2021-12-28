using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using ICBrowser.Common;

namespace ICBrowser.Business
{
    class ExcelParser
    {
      
        protected ArrayList workbookArray;
        protected ArrayList worksheetArray;
        //protected DataSet fileToDataset;

        /// <summary>
        /// filename required here is the pathof the file uploaded on the server.
        /// </summary>
        /// <param name="fileName"></param>
        public void Parse(string fileName)
        {
            string[] fileNameSplitted;
            try
            {
                fileNameSplitted = fileName.Split('.');
                string fileExtension = fileNameSplitted[1].ToString();

                OleDbConnection dbConnection = new OleDbConnection();

                switch (fileExtension)
                {
                    case "xls":
                        {
                            dbConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + @";Extended Properties=""Excel 8.0;HDR=No;IMEX=1;ImportMixedTypes=Text;TypeGuessRows=0""";
                        }
                        break;
                    case "xlsx":
                        {
                            dbConnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + @";Extended Properties=""Excel 12.0 Xml;HDR=No;IMEX=1;ImportMixedTypes=Text;TypeGuessRows=0""";
                        }
                        break;
                    default:
                        break;
                }

                dbConnection.Open();
                DataTable dbSchema = dbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dbSchema == null || dbSchema.Rows.Count < 1)
                {
                    throw new Exception("Error:Could not determine the name of the first worksheet");
                }
                string firstSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();

                worksheetArray = new ArrayList();
                workbookArray = new ArrayList();

              
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                //XbrlLogger.LogError(ex.ToString());
            }
        }


    }
}
