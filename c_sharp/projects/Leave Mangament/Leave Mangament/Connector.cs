using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Leave_Mangament
{
    class Connector
    {
        private string connectionString;
        public Connector()
        {
            connectionString = "datasource=127.0.0.1;port=3306;username=root;password=zubair1234;database=leavedata;";
        }
        public string getConnector()
        {
            return connectionString;
        }
        public bool testConnection()
        {
            //string query = "SELECT * FROM user";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            //MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            //commandDatabase.CommandTimeout = 60;
            //MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                //reader = commandDatabase.ExecuteReader();
                //MessageBox.Show("Successful");
                databaseConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
