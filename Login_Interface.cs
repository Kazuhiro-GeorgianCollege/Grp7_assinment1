using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grp7_assinment1
{
    public partial class Login_Interface : Form
    {
        public Login_Interface()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Text = "Faculty ID ";
            label1.Show();
            textBox1.Show();
            label2.Show();
            textBox2.Show();
            button4.Hide();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.label1.Text = "Student ID ";
            label1.Show();
            textBox1.Show();
            label2.Show();
            textBox2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.label1.Text = "Admin ID ";
            label1.Show();
            textBox1.Show();
            label2.Show();
            textBox2.Show();
            button4.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] inputIDarray = new string[] { };
            inputIDarray = textBox1.Lines;
            foreach (string line in inputIDarray) {
                if (label1.Text == "Student ID " && line == "200490882")
                {
                    
                    button4.Show();
                }
                else {
                    
                    button4.Hide();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string[] inputPASSWORDarray = new string[] { };
            inputPASSWORDarray = textBox2.Lines;
            foreach (string line in inputPASSWORDarray)
            {
                if (label1.Text == "Student ID " && line == "123456")
                {
                    
                    this.button4.Enabled = true;
                }
                else
                {
                   
                    this.button4.Enabled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Search_Interface searchInterface = new Search_Interface();
            searchInterface.Show();
        }

    }
}
