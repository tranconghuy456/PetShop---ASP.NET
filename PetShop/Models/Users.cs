using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace PetShop.Models
{
    public class Users
    {
        Providers providers = new Providers();

        public SqlConnection Connection()
        {
            return providers.connection;
        }

        public bool Connect()
        {
            return providers.Connect();
        }

        public void Disconnect()
        {
            providers.Disconnect();
        }

        public int UsersExecuteNonQuery(string queryOrSpName, string[] Parameters, object[] Values, bool isStored)
        {
            return providers.ExecuteNonQuery(queryOrSpName, Parameters, Values, isStored);
        }

        public int UserCheckPoint(string strUserName, string strPassword)
        {
            providers.Connect();
            string strSql = "SELECT COUNT(*) FROM USERS WHERE ((UserName=@UserName) and (Password=@Password));";

            string[] parameters = { "@UserName", "@Password" };
            string[] values = { strUserName, strPassword };

            return providers.ExecuteScalar(strSql, parameters, values);
        }
    }
}