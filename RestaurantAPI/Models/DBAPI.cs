using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace DatabaseSQL
{
   public class DBAPI
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;email=;database=finalproject_users_db;SSL Mode=None");

        //open connection to my sql server
        public void OpenConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        //close connection
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        //return the connection
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
