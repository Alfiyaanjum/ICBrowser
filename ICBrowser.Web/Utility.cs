using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using ICBrowser.DAL;

namespace ICBrowser.Web
{
    public static class Utility
    {

        public static void ProcessLogin(string userId, string sessionId, DataSet multipleLogindata)
        {

            DataRow dr = multipleLogindata.Tables[0].Rows.Find(userId);

            if (dr == null)
            {
                dr = multipleLogindata.Tables[0].NewRow();
                dr[0] = userId;
                dr[1] = sessionId;
                multipleLogindata.Tables[0].Rows.Add(dr);
            }
            else
            {
                dr[1] = sessionId;
            }
        }
        public static bool CheckUserForMultipleLogins(string userId, string sessionId, DataSet multipleLogindata)
        {
            DataRow row = multipleLogindata.Tables[0].Rows.Find(userId);
            if (row == null)
                return true;
            else if (string.Compare(Convert.ToString(row[NewConstant.NewSessionId]), sessionId, true) == 0)
                return true;
            else
                return false;
        }

        
        public static DataSet GetMultipleSigninsData()
        {
            DataSet usersLoggedInFromDifferentNodes = new DataSet();
            DataTable usersToBeSignedOut = new DataTable();
            DataColumn[] key = new DataColumn[1];
            usersToBeSignedOut.Columns.Add(NewConstant.UserName, Type.GetType("System.String"));
            usersToBeSignedOut.Columns.Add(NewConstant.NewSessionId, Type.GetType("System.String"));
            key[0] = usersToBeSignedOut.Columns[NewConstant.UserName];
            usersToBeSignedOut.PrimaryKey = key;
            usersLoggedInFromDifferentNodes.Tables.Add(usersToBeSignedOut);
            return usersLoggedInFromDifferentNodes;
        }


    }
}