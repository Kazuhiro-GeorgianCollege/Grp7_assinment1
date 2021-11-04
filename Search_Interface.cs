using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Grp7_assinment1
{
    
    public partial class Search_Interface : Form
    {
        int Id = 0;
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Canada Georgian College\Course\course_dataProgramming\HW\Grp7_assinment1\Grp7_assinment1\db_GeorgianStudentDB.mdf;Integrated Security=True;Connect Timeout=30");

        public Search_Interface()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (textBox1.Text !="") {
                this.label2.Text = "Search ID: ";
                FillDataGridSearch("StudentDBViewOrSearchID", "SearchByID", "@SearchId", textBox1.Text.Trim());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (textBox1.Text != "")
            {
                this.label2.Text = "Search Name: ";
                FillDataGridSearch("StudentDBViewOrSearchName", "SearchByName", "@SearchName", textBox1.Text.Trim());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (textBox1.Text != "")
            {
                this.label2.Text = "Search Email: ";
                FillDataGridSearch("StudentDBViewOrSearchEmail", "SearchByEmail", "@SearchEmail", textBox1.Text.Trim());

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (textBox1.Text != "")
            {
                this.label2.Text = "Search Birth: ";
                FillDataGridSearch("StudentDBViewOrSearchBirth", "SearchByBirth", "@SearchBirth", textBox1.Text.Trim());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (textBox1.Text != "")
            {
                this.label2.Text = "Search Nationality: ";
                FillDataGridSearch("StudentDBViewOrSearchNatinality", "SearchByNationality", "@SearchNationality", textBox1.Text.Trim());

            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (textBox1.Text != "")
            {
                this.label2.Text = "Search Course: ";
                FillDataGridSearch("StudentDBViewOrSearchCourseProgram", "SearchByCourseProgram", "@SearchCourseProgram", textBox1.Text.Trim());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (textBox1.Text != "")
            {
                this.label2.Text = "Search Semester: ";
                FillDataGridSearch("StudentDBViewOrSearchSemester", "SearchBySemester", "@SearchSemester", textBox1.Text.Trim());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (textBox1.Text != "")
            {
                this.label2.Text = "Search Location: ";
                FillDataGridSearch("StudentDBViewOrSearchLocation", "SearchByLocation", "@SearchLocation", textBox1.Text.Trim());

            }
        }
        /* //for future possible using
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] inputSEARCHarray = new string[] { };
            inputSEARCHarray = textBox1.Lines;
            foreach (string line in inputSEARCHarray)
            {
               
            }
        }
        */
        private void button11_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Create_Interface create_Interface = new Create_Interface();
            create_Interface.Show();
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
        
        public void FillDataGridSearch(string searchProcedure, string SearchMode, string SearchBy, string searchInput)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open(); 
                }
               
                SqlDataAdapter sqlDa = new SqlDataAdapter(searchProcedure, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@mode", SearchMode);
                sqlDa.SelectCommand.Parameters.AddWithValue(SearchBy, searchInput);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
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

        private void button12_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.label2.Text = "Search: ";
            FillDataGridView();
        }
      
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1) {

                panel1.Visible = true;
                textBox1.Enabled = false;
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

                this.button9.Enabled = true;
                this.button10.Enabled = true;

            }
        }
      
      
        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.Text == "Replace") {

                button9.Text = "Reset";
                button10.Text = "Update";
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;

            } else if (button10.Text == "Update") {

                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "") {

                    try
                    {
                        if (sqlCon.State == ConnectionState.Closed)
                        {
                        sqlCon.Open();
                        }

                        SqlCommand sqlCmd = new SqlCommand("Procedure", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@mode", "Replace");
                        sqlCmd.Parameters.AddWithValue("@Id", Id);
                        sqlCmd.Parameters.AddWithValue("@StudentId", textBox2.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Name", textBox3.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email", textBox4.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Birth", textBox5.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Nationality", textBox6.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Course", textBox7.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Semester", textBox8.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Location", textBox9.Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Replace data Successfully");
                        button9.Text = "Delete";
                        button10.Text = "Replace";
                        readData();
                        textBox1.Enabled = true;
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
            }            
        }

        public void readData()
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;

        }

        public void resetData()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "Reset")
            {
                resetData();

            }
            else if (button9.Text == "Delete")
            {
                
               try
               {
                   if (sqlCon.State == ConnectionState.Closed)
                   {
                       sqlCon.Open();
                   }

                   SqlCommand sqlCmd = new SqlCommand("StudetnDBDelete", sqlCon);
                   sqlCmd.CommandType = CommandType.StoredProcedure;
                   sqlCmd.Parameters.AddWithValue("@Id", Id);
                   sqlCmd.ExecuteNonQuery();
                   MessageBox.Show("Deleted successfully");
                   panel1.Visible = false;
                   textBox1.Enabled = true;
                   FillDataGridView();                   

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
        }
    }
}
