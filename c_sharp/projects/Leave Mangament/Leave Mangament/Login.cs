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
    public partial class Login : Form
    {
        private bool loginFlag = false;
        public Login()
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

        public void setAdminLogin(bool x)
        {
            loginFlag = x;
            this.AdminLabel.Visible = true;
        }
        public bool getLogin()
        {
            return loginFlag;
        }

        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SingupButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile s = new Profile();
            s.Show();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure about exiting?",
                                     "Confirm Exit!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.LoginQuery();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeForm home = new HomeForm();
            home.Show();
        }
        private void LoginQuery()
        {
            string conn;
            //bool login = false;
            Connector c = new Connector();
            bool x = c.testConnection();
            if(x)
            {
                conn = c.getConnector();
                MySqlConnection newConnection = new MySqlConnection(conn);
                MySqlCommand newCommand;
                if (loginFlag == false)
                {
                    newCommand = new MySqlCommand("select * from leavedata.employee where userid='" + this.UsernameBox.Text + "' and password='" + this.PasswordBox.Text + "';", newConnection);
                }
                else
                {
                    newCommand = new MySqlCommand("select * from leavedata.employer where userid='" + this.UsernameBox.Text + "' and password='" + this.PasswordBox.Text + "';", newConnection);
                }
                MySqlDataReader newReader;
                newConnection.Open();
                newReader = newCommand.ExecuteReader();
                int count = 0;
                while(newReader.Read())
                {
                    count += 1;
                }
                if(count == 1)
                {
                    if (loginFlag == false)
                    {
                        MessageBox.Show("Logged in as " + this.UsernameBox.Text);
                        HomeForm h = new HomeForm();
                        h.setLabel(this.UsernameBox.Text);
                        this.Hide();
                        h.Show();
                    }
                    else
                    {
                        MessageBox.Show("Logged in as " + this.UsernameBox.Text);
                        AdminForm a = new AdminForm();
                        a.setLabel(this.UsernameBox.Text);
                        this.Hide();
                        a.Show();
                    }
                }
                else if(count > 1)
                {
                    MessageBox.Show("Duplicate Error");
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password");
                }
                newConnection.Close();
            }
           
        }
        
    }
}
