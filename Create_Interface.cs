using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grp7_assinment1
{
    public partial class Create_Interface : Form
    {

        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Canada Georgian College\Course\course_dataProgramming\HW\Grp7_assinment1\Grp7_assinment1\db_GeorgianStudentDB.mdf;Integrated Security=True;Connect Timeout=30");

        public Create_Interface()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
                {
                    button1.Text = "Save";
                }
                else if(button1.Text == "Display")
                {
                    button1.Text = "Display";
                }
                else {
                    button1.Text = "Create";
                }

                if (button1.Text == "Save")
                {
                    SqlCommand sqlCmd = new SqlCommand("Procedure", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Create");
                    sqlCmd.Parameters.AddWithValue("@Id", 0);
                    sqlCmd.Parameters.AddWithValue("@StudentId", textBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Name", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Birth", textBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Nationality", textBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Course", textBox6.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Semester", textBox7.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Location", textBox8.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Create and Save Successfully");
                    button1.Text = "Create";
                    resetData();
                }
                                
                FillDataGridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");

            }
            finally {
                sqlCon.Close();
            }
        }

        public void FillDataGridView()
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                SqlDataAdapter sqlDa = new SqlDataAdapter("StudentDBView", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;                
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");

            }
            finally
            {
                sqlCon.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Text = "Create";
            resetData();
        }

        public void resetData() {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            label6.Show();
            label7.Show();
            label8.Show();
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            textBox4.Show();
            textBox5.Show();
            textBox6.Show();
            textBox7.Show();
            textBox8.Show();
            button2.Enabled = true;
            button1.Enabled = true;
            button1.Text = "Create";
           
        }


    }
}
