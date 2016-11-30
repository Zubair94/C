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
    public partial class LeaveForm : Form
    {
        
        public LeaveForm()
        {
            
            InitializeComponent();

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

        private void HomeButton_Click(object sender, EventArgs e)
        {

            this.Hide();
            HomeForm home = new HomeForm();
            string u = HomeForm.getLabel();
            home.setLabel(u);
            home.Show();
        }

        private void updateLeaveData()
        {
            string conn;
            
            string uid = HomeForm.getLabel();
            Connector c = new Connector();
            bool x = c.testConnection();
            if (x)
            {
                
                    string fromdate = DateTimeFrom.Text;
                    string todate = DateTimeTo.Text;
                    string reason;
                    if (ReasonBox.Text == "Other")
                    {
                        reason = OtherBox.Text;
                    }
                    else
                    {
                        reason = ReasonBox.Text;
                    }
                    conn = c.getConnector();
                    MySqlConnection newConnection1 = new MySqlConnection(conn);
                    MySqlCommand newCommand1 = new MySqlCommand("INSERT INTO leavedata(`userid`,`name`,`contact`, `fromdate`, `todate`, `reason`,`status`) VALUES ('" + uid + "','"+ this.textBox1.Text +"','" + this.textBox2.Text + "', '" + this.DateTimeFrom.Text + "', '" + this.DateTimeTo.Text + "', '" + reason + "','pending')",newConnection1);
                    newConnection1.Open();
                    MySqlDataReader newReader1;
                    newReader1 = newCommand1.ExecuteReader();
                    MessageBox.Show("Submitted LeaveForm");
                    newConnection1.Close();
                     HomeForm h = new HomeForm();
                string u = HomeForm.getLabel();
                h.setLabel(u);
                this.Hide();
                h.Show();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.updateLeaveData();
        }
        private void checkBoxcheck()
        {
            string conn;
            
            string uid = HomeForm.getLabel();
            Connector c = new Connector();
            bool x = c.testConnection();
            if (x)
            {
                if (SameCheckBox.Checked == true)
                {
                    conn = c.getConnector();
                    MySqlConnection newConnection = new MySqlConnection(conn);
                    MySqlCommand newCommand = new MySqlCommand("select * from leavedata.employee where userid='" + uid + "';", newConnection);
                    MySqlDataReader newReader;
                    newConnection.Open();
                    newReader = newCommand.ExecuteReader();
                    string name = "", contact = "";
                    while (newReader.Read())
                    {
                        name = newReader.GetString(1);
                        contact = newReader.GetString(3);
                    }
                    this.textBox1.Text = name;
                    this.textBox2.Text = contact;
                    newConnection.Close();
                }
            }
        }

        private void SameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SameCheckBox.Checked == false)
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
            }
            else
            {
                this.checkBoxcheck();
            }
        }

        private void ReasonBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if(ReasonBox.Text=="Other")
            {
                OtherBox.ReadOnly = false;
            }
        }
    }
}
