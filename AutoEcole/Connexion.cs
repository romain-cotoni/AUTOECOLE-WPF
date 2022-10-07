using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEcole
{
    internal class Connexion
    {
        public string connectionString = @"Data Source=DESKTOP-LUERME7\SQL_2019;Initial Catalog=ECF_AEL;User ID=sa;Password=ssap";
        SqlConnection? connection;

        public SqlConnection? getConnection()
        {
            return connection;
        }
        public SqlConnection openConnection()
        {
            this.connection = new SqlConnection(this.connectionString);
            this.connection.Open();
            return this.connection;
        }

        public void closeConnection()
        {
            if (this.connection != null) this.connection.Close();
        }

        public void executeQueries(string query)
        {
            SqlCommand cmd = new SqlCommand(query, this.connection);
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader readData(string query)
        {
            SqlCommand cmd = new SqlCommand(query, this.connection);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}

