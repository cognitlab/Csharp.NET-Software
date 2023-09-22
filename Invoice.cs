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
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
            GETPatId();
            GETDocId();
            GETTestId();
            
        }

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Csharp(.NET)\PROJECT\WindowsFormsApp1\WindowsFormsApp1\DiagnostiDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        private void GETPatId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select PatId from PatientTbl",con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PatId", typeof(int));
            dt.Load(rdr);
            PatId.ValueMember = "PatId";
            PatId.DataSource = dt;
            con.Close();
        }
        private void GETTestId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select TestId from TestTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TestId", typeof(int));
            dt.Load(rdr);
            TestId.ValueMember = "TestId";
            TestId.DataSource = dt;
            con.Close();
        }
        private void GETDocId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select DocName from DoctorTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DocName", typeof(string));
            dt.Load(rdr);
            RefBy.ValueMember = "DocName";
            RefBy.DataSource = dt;
            con.Close();
        }
        private void GETPatData()
        {
            con.Open();
            string sql = "select * from PatientTbl where PatId = "+PatId.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(sql,con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            { 
                PatName.Text = dr["PatName"].ToString();
                PatPhone.Text = dr["Phone"].ToString();
            }
            con.Close();
        }

        int Cost;
        private void GETTestData()
        {
            con.Open();
            string sql = "select * from TestTbl where TestId = " + TestId.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                TestName.Text = dr["TestDesc"].ToString();
                Cost = Convert.ToInt32(dr["TestCost"].ToString());
            }
            con.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Doctor doc = new Doctor();
            doc.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient pa = new Patient();
            pa.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Test tc = new Test();
            tc.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void Invoice_Load(object sender, EventArgs e)
        {

        }

        private void PatId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GETPatData();
        }

        private void TestId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GETTestData();
        }

        
        private void AddBtn_Click(object sender, EventArgs e)
        {
            
            if (TestName.Text == "")
            {
                MessageBox.Show("Select The Test");
            }
            else
            {
                DataGridViewRow dg = new DataGridViewRow();
                dg.CreateCells(InvDGV);
                dg.Cells[0].Value = n + 1;
                dg.Cells[1].Value = TestName.Text;
                dg.Cells[2].Value = Cost;
                InvDGV.Rows.Add(dg);
                n++;
                GrdTotal = GrdTotal + Cost;
                TotalLbl.Text = "Rs" + GrdTotal;
            }
            
        }
        int n = 0, GrdTotal = 0;
        int  TestCost, pos = 60;
        private void PriBtn_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm",285,600);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        
        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int TestId;
            string TestName;
            e.Graphics.DrawString("Diagnostic Centre", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID       TEST               COST", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(75, 40));
            foreach (DataGridViewRow row in InvDGV.Rows)
            {
                TestId = Convert.ToInt32(row.Cells["Column1"].Value);
                TestName = "" + row.Cells["Column2"].Value;
                TestCost = Convert.ToInt32(row.Cells["Column3"].Value);

                e.Graphics.DrawString("" + TestId, new Font("Century Gothic ", 8, FontStyle.Bold), Brushes.Blue, new Point(75, pos));
                e.Graphics.DrawString("" + TestName, new Font("Century Gothic ", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + TestCost, new Font("Century Gothic ", 8, FontStyle.Bold), Brushes.Blue, new Point(210, pos));

                pos = pos + 25;
            }
            e.Graphics.DrawString("Grand Total: Rs" + GrdTotal, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("************Diagnostic Centre*************", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(11, pos + 85));

            InvDGV.Rows.Clear();
            InvDGV.Refresh();
            pos = 100;
            GrdTotal = 0;
        }

        private void reset()
        {
            PatId.Text = "";
            PatName.Text = "";
            PatPhone.Text = "";
            TotalLbl.Text = "Total";
            GrdTotal = 0;
            TestId.Text = "";
            TestName.Text = "";
            InvDGV.Rows.Clear();
        
        }
        private void SaveInBtn_Click(object sender, EventArgs e)
        {
            if (PatId.Text == "" || RefBy.SelectedIndex == -1 || TotalLbl.Text == "Total")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into InvoiceTbl values('" + PatId.SelectedValue.ToString() + "','" + PatName.Text + "','" + PatPhone.Text + "','" +DeliDate.Value.Date + "','"+RefBy.SelectedValue.ToString()+"','"+GrdTotal+"')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Invoice Saved Successfully");
                    con.Close();
                    reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }









    }
}
