using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leave_Mangament
{
    public partial class AdminForm : Form
    {
        private static string current;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            this.Hide();
            a.Show();
        }

        private void UserEmployerButton_Click(object sender, EventArgs e)
        {
            if(Username.Visible)
            {
                MessageBox.Show("Please Log Out");
            }
            else
            {
                Login l = new Login();
                l.setAdminLogin(true);
                this.Hide();
                l.Show();
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
        public void setLabel(string userlabel)
        {
            this.LoginLabel.Visible = true;
            this.Username.Visible = true;
            
            this.Username.Text = userlabel;
            current = userlabel;
        }
        public static string getLabel()
        {
            return current;
        }
        
    }
}
