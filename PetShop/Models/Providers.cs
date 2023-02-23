using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace PetShop.Models
{
    public class Providers
    {
        // Variables //
        public SqlConnection connection;
        private string connectStr;

        // Connect method //
        public bool Connect()
        {
            connectStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Dev\ASP.NET\PetShop\PetShop\Database\PetHoush.mdf;Integrated Security=True;Connect Timeout=30";
            connection = new SqlConnection(connectStr);

            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
            {
                connection.Open();
                return true;
            }
            else return false;
        }

        // Disconnect method //
        public void Disconnect()
        {
            connection.Close();
            connection.Dispose();
        }

        // SqlCommand method //
        public SqlCommand Command(string queryOrSpName, string[] Parameters, object[] Values, bool isStored)
        {
            SqlCommand command = new SqlCommand(queryOrSpName, connection);

            // isStored != null -> init command
            if (isStored)
            {
                command.CommandText = queryOrSpName;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
            }

            // Parameters != null -> add values
            if (Parameters != null)
            {
                for (int i = 0; i < Parameters.Length; i++)
                    command.Parameters.AddWithValue(Parameters[i], Values[i]);
            }

            return command;
        }

        public int ExecuteScalar(string queryOrSpName, string[] Parameters, object[] Values)
        {
            int Scalar = (int)Command(queryOrSpName, Parameters, Values, false).ExecuteScalar();
            Disconnect();
            return Scalar;
        }

        public int ExecuteNonQuery(string queryOrSpName, string[] Parameters, object[] Values, bool isStored)
        {
            int rec = Command(queryOrSpName, Parameters, Values, isStored).ExecuteNonQuery();

            Disconnect();
            return rec;
        }
    }
}