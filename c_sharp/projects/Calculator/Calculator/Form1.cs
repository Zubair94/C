using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private bool clear = true;
        private double Result = 0;
        private double x;
        Button Clicked;

        public Form1()
        {
            InitializeComponent();
        }

        

        private void button_9_Click(object sender, EventArgs e)
        {
            if (!clear)
            {
                ResultBox.Clear();
                clear = true;
            }
            ResultBox.Text = ResultBox.Text + "9";
            
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            if (!clear)
            {
                ResultBox.Clear();
                clear = true;
            }
            ResultBox.Text = ResultBox.Text + "8";
            
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            if (!clear)
            {
                ResultBox.Clear();
                clear = true;
            }
            ResultBox.Text = ResultBox.Text + "7";
            
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            if (!clear)
            {
                ResultBox.Clear();
                clear = true;
            }
            ResultBox.Text = ResultBox.Text + "6";
            
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            if (!clear)
            {
                ResultBox.Clear();
                clear = true;
            }
            ResultBox.Text = ResultBox.Text + "5";
            
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            if (!clear)
            {
                ResultBox.Clear();
                clear = true;
            }
            ResultBox.Text = ResultBox.Text + "4";
            
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (!clear)
            {
                ResultBox.Clear();
                clear = true;
            }
            ResultBox.Text = ResultBox.Text + "3";
            
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            if(!clear)
            {
                ResultBox.Clear();
                clear = true;
            }
            ResultBox.Text = ResultBox.Text + "2";
            
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            if (!clear)
            {
                ResultBox.Clear();
                clear = true;
            }
            ResultBox.Text = ResultBox.Text + "1";
            
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            if (!clear)
            {
                ResultBox.Clear();
                clear = true;
            }
            ResultBox.Text = ResultBox.Text + "0";
            
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            Clicked = (Button)sender;
            
            button_equal.PerformClick();
        }

        private void button_sub_Click(object sender, EventArgs e)
        {
            Clicked = (Button)sender;
            
            button_equal.PerformClick();
            
        }

        private void button_mult_Click(object sender, EventArgs e)
        {
            Clicked = (Button)sender;
            button_equal.PerformClick();
        }

        private void button_div_Click(object sender, EventArgs e)
        {
            Clicked = (Button)sender;
            button_equal.PerformClick();
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            try
            {
                x = Convert.ToDouble(ResultBox.Text);
                ResultBox.Clear();
                if (Clicked == button_div)
                {
                    Result = Result / x;
                    ResultBox.Text = Result.ToString();
                    clear = false;
                }
                else if (Clicked == button_add)
                {
                    Result = Result + x;
                    ResultBox.Text = Result.ToString();
                    clear = false;
                }
                else if (Clicked == button_sub)
                {
                    Result = Result - x;
                    ResultBox.Text = Result.ToString();
                    clear = false;
                }
                else if (Clicked == button_mult)
                {
                    Result = Result * x;
                    ResultBox.Text = Result.ToString();
                    clear = false;
                }
                else
                {
                    ResultBox.Text = x.ToString();
                }
            }
            catch (Exception)
            {
                Result = 0;
                ResultBox.Clear();
            }
        }

        private void button_clr_Click(object sender, EventArgs e)
        {
            Result = 0;
            ResultBox.Clear();
            clear = true;
        }

        private void button_decimal_Click(object sender, EventArgs e)
        {
            string s = ResultBox.Text;
            if (!ResultBox.Text.Contains("."))
            {
                ResultBox.Text = ResultBox.Text + ".";
            }
            else
            {
                ResultBox.Text = s;
            }
        }
    }
}
