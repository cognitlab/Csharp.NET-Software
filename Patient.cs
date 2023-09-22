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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Csharp(.NET)\PROJECT\WindowsFormsApp1\WindowsFormsApp1\DiagnostiDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        private void label3_Click(object sender, EventArgs e)
        {
            Doctor doc = new Doctor();
            doc.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Doctor doc = new Doctor();
            doc.Show();
            this.Hide();
        }

        private void populate()
        {
            con.Open();
            string Query = "select * from PatientTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query,con);
            SqlCommandBuilder build = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PatientDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PatNameTb.Text == "" || PatAgeTb.Text == "" || PatPhoneTb.Text == "" || PatGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into PatientTbl values('" +PatNameTb.Text+ "','" +PatAgeTb.Text+ "','" +PatPhoneTb.Text+ "','"+PatGenCb.SelectedItem.ToString()+"')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Saved Successfully");
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

        private void label5_Click(object sender, EventArgs e)
        {
            Test tc = new Test();
            tc.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Test tc = new Test();
            tc.Show();
            this.Hide();
        }

         int key = 0;
        private void PatientDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatNameTb.Text = PatientDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            PatAgeTb.Text = PatientDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            PatPhoneTb.Text = PatientDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
            PatGenCb.SelectedItem = PatientDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
            
            if (PatNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void reset()
        {
            PatNameTb.Text = "";
            PatAgeTb.Text = "";
            PatPhoneTb.Text = "";
            PatGenCb.SelectedIndex = -1;
            key = 0;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Patient to delete");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from PatientTbl where PatId = '"+key+"';", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Deleted Successfully");
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

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PatNameTb.Text == "" || PatAgeTb.Text == "" || PatPhoneTb.Text == "" || PatGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string Query = "update PatientTbl set PatName = '"+PatNameTb.Text+"',Age = '"+PatAgeTb.Text+"',Phone = '"+PatPhoneTb.Text+"',Gender = '"+PatGenCb.SelectedItem.ToString()+"'where PatId = '"+key+"'";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Query,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Updated Successfully");
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

        private void Patient_Load(object sender, EventArgs e)
        {

        }


    }
}
