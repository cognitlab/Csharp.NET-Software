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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GETDocData();
            GETPatData();
            GETIncomeData();
            
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Csharp(.NET)\PROJECT\WindowsFormsApp1\WindowsFormsApp1\DiagnostiDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
     
        private void GETDocData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select DocName from DoctorTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DocName", typeof(string));
            dt.Load(rdr);
            DocLbl.Text = dt.Rows.Count.ToString();
            con.Close();
        }
        private void GETPatData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select PatName from PatientTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PatName", typeof(string));
            dt.Load(rdr);
            PatLbl.Text = dt.Rows.Count.ToString();
            con.Close();
        }

        
        private void GETIncomeData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select TotCost from InvoiceTbl",con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TotCost", typeof(string));
            dt.Load(rdr);
            IncomeLbl.Text = dt.Rows.Count.ToString();            
            con.Close();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out");
            Login log = new Login();
            log.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient pat = new Patient();
            pat.Show();
            this.Hide();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Test te = new Test();
            te.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Test te = new Test();
            te.Show();
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

        private void label6_Click(object sender, EventArgs e)
        {
            Invoice i = new Invoice();
            i.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void DocLbl_Click(object sender, EventArgs e)
        {

        }

        public string PatId { get; set; }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
