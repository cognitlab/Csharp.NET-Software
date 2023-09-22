using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            populate();
        }
       

        private void label4_Click(object sender, EventArgs e)
        {
            Patient pat = new Patient();
            pat.Show();
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Patient pat = new Patient();
            pat.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Doctor pat = new Doctor();
            pat.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Doctor pat = new Doctor();
            pat.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out");
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard das = new Dashboard();
            das.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Dashboard das = new Dashboard();
            das.Show();
            this.Hide();
        }

        private void TestDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DescTb.Text = TestDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            CostTb.Text = TestDGV.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (DescTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TestDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Csharp(.NET)\PROJECT\WindowsFormsApp1\WindowsFormsApp1\DiagnostiDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        private void populate()
        {
            con.Open();
            string Query = "select * from TestTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder build = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TestDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        int key = 0;
        private void reset()
        {
            DescTb.Text = "";
            CostTb.Text = "";
            key = 0;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (DescTb.Text == "" || CostTb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into TestTbl values('" + DescTb.Text + "','" + CostTb.Text + "');", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test Saved Successfully");
                    con.Close();
                    populate();
                    reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Test to delete");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from TestTbl where TestId = '" + key + "';", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test Deleted Successfully");
                    con.Close();
                    populate();
                    reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (DescTb.Text == "" || CostTb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string Query = "update TestTbl set TestDesc = '" + DescTb.Text + "',TestCost = '" + CostTb.Text + "'where TestId = '" + key + "'";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test Updated Successfully");
                    con.Close();
                    populate();
                    reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Invoice inv = new Invoice();
            inv.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }


    }
}
