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
    public partial class HomeForm : Form
    {
        private static string currentUser;
        private bool leave = false;
        private bool deleteflag = true;
        public HomeForm()
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

        private void LoginPicButton_Click(object sender, EventArgs e)
        {
            if (Username.Visible)
            {
                MessageBox.Show("Please Log Out");
            }
            else
            {
                Login l = new Login();
                this.Hide();
                l.Show();
            }
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            if (this.Username.Visible)
            {
                this.getProfileData();
            }
            else
            {
                MessageBox.Show("Please Log in");
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.LoginLabel.Visible = false;
            this.Username.Visible = false;
            HomeForm h = new HomeForm();
            this.Hide();
            h.Show();
        }

        private void LeaveFormButton_Click(object sender, EventArgs e)
        {
            this.checkLeaveForm();
            if(this.Username.Visible)
            {
                if (leave==false)
                {
                    if(deleteflag)
                    {
                        this.newLeaveRequest();
                    }
                    LeaveForm l = new LeaveForm();
                    this.Hide();
                    l.Show();
                }
                else
                {
                    MessageBox.Show("You have already a request pending");
                }
            }
            else
            {
                MessageBox.Show("Please Log in");
            }
        }

        private void UserEmployerButton_Click(object sender, EventArgs e)
        {
            if (Username.Visible == true)
            {
                MessageBox.Show("Please Logout");
            }
            else
            {
                Login l = new Login();
                l.setAdminLogin(true);
                this.Hide();
                l.Show();
            }

        }
        public void setLabel(string userlabel)
        {
            this.LoginLabel.Visible = true;
            this.Username.Visible = true;
            //loginlabel = this.LoginLabel.Text;
            this.Username.Text = userlabel;
            currentUser = userlabel;
        }
        public static string  getLabel()
        {
            return currentUser;
        }
        private void getProfileData()
        {
            string conn;
            Connector c = new Connector();
            bool x = c.testConnection();
            if (x)
            {
                conn = c.getConnector();
                MySqlConnection newConnection = new MySqlConnection(conn);
                MySqlCommand newCommand = new MySqlCommand("select * from leavedata.employee where userid='" + this.Username.Text + "';", newConnection);
                MySqlDataReader newReader;
                newConnection.Open();
                newReader = newCommand.ExecuteReader();
                
                string username = "", name = "", contact = "", address = "", city = "", postcode = "";
                while (newReader.Read())
                {
                     username = newReader.GetString(0);
                     name = newReader.GetString(1);
                     contact = newReader.GetString(3);
                     address = newReader.GetString(4);
                     city = newReader.GetString(5);
                     postcode = newReader.GetString(6);
                }
                newConnection.Close();
                Profile p = new Profile();
                p.setProfile(username, name, contact, address, city, postcode);
                this.Hide();
                p.Show();

            }
        }
        private void checkLeaveForm()
        {
            string conn;
            string s = "";
            string uid = getLabel();
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
                while (newReader.Read())
                {
                    s = newReader.GetString(0);
                }
                newConnection.Close();
            }
            if(s == "pending")
            {
                leave = true;
            }
            else if(s == "accepted" || s == "rejected")
            {
                leave = false;
                deleteflag = true; 
            }
            else
            {
                deleteflag = true;
                leave = false;
            }
        }
        private void newLeaveRequest()
        {
            string conn;
            
            string uid = getLabel();
            Connector c = new Connector();
            bool x = c.testConnection();
            if (x)
            {

                conn = c.getConnector();
                MySqlConnection newConnection = new MySqlConnection(conn);
                MySqlCommand newCommand = new MySqlCommand("delete from leavedata.leavedata where userid='" + uid + "';", newConnection);
                MySqlDataReader newReader;
                newConnection.Open();
                newReader = newCommand.ExecuteReader();
                newConnection.Close();
            }
        }
    }
}
