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
    
    public partial class Profile : Form
    {
        //private static string user;
        public Profile()
        {
            InitializeComponent();
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

        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {

            this.Hide();
            HomeForm home = new HomeForm();
            string u = HomeForm.getLabel();
            home.setLabel(u);
            home.Show();
        }
        public void setProfile(string u,string n,string c,string a,string city,string p)
        {
            
            this.UsernameBox.Text = u;
            this.NameBox.Text = n;
            this.AddressBox.Text = a;
            this.ContactBox.Text = c;
            this.CityBox.Text = city;
            this.PostCodeBox.Text = p;
        }

        private void StatusButton_Click(object sender, EventArgs e)
        {
            string conn;
            string s ="";
            string uid = HomeForm.getLabel();
            Connector c = new Connector();
            bool x = c.testConnection();
            if (x)
            {
                
                conn = c.getConnector();
                MySqlConnection newConnection = new MySqlConnection(conn);
                MySqlCommand newCommand = new MySqlCommand("select status from leavedata.leavedata where userid='" + uid + "';", newConnection);
                MySqlDataReader newReader;
                newConnection.Open();
                newReader = newCommand.ExecuteReader();
                while(newReader.Read())
                {
                   s = newReader.GetString(0);
                }
                newConnection.Close();
            }
            if(s == "pending")
            {
                MessageBox.Show("Your current request is pending");
            }
            else if(s == "rejected")
            {
                MessageBox.Show("Your request was rejected");
            }
            else if(s == "accepted")
            {
                MessageBox.Show("Your request was accepted");
            }
            else
            {
                MessageBox.Show("No leave request found");
            }
        }
    }
}
