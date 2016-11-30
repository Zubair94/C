using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Leave_Mangament
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void AcceptButton1_Click(object sender, EventArgs e)
        {
            this.checkAcceptReject("accepted");
        }

        private void RejectButton1_Click(object sender, EventArgs e)
        {
            this.checkAcceptReject("rejected");
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {

            this.Hide();
            AdminForm home = new AdminForm();
            string u = AdminForm.getLabel();
            home.setLabel(u);
            home.Show();
        }

        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure about exiting?",
                                     "Confirm Exit!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        private void checkDataTable()
        {
            string conn;
            string uid = HomeForm.getLabel();
            Connector c = new Connector();
            bool x = c.testConnection();
            if (x)
            {

                conn = c.getConnector();
                MySqlConnection newConnection = new MySqlConnection(conn);
                MySqlCommand newCommand = new MySqlCommand("select * from leavedata.leavedata;", newConnection);
                MySqlDataAdapter data = new MySqlDataAdapter();
                data.SelectCommand = newCommand;
                DataTable dataset = new DataTable();
                data.Fill(dataset);
                BindingSource b = new BindingSource();
                b.DataSource = dataset;
                DataView.DataSource = b;
                data.Update(dataset);
                newConnection.Close();
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.checkDataTable();
        }
        private void checkAcceptReject(string state)
        {
            string conn;
            
            string uid = this.UsernameBox.Text;
            Connector c = new Connector();
            bool x = c.testConnection();
            if (x)
            {

                conn = c.getConnector();
                MySqlConnection newConnection = new MySqlConnection(conn);
                MySqlCommand newCommand = new MySqlCommand("update leavedata.leavedata set status='"+ state +"' where userid='" + uid + "';", newConnection);
                MySqlDataReader newReader;
                newConnection.Open();
                newReader = newCommand.ExecuteReader();
                MessageBox.Show("Success");
                newConnection.Close();
            }
            this.checkDataTable();
        }
    }
}
