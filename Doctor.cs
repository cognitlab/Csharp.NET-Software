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

namespace WindowsFormsApp1
{
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
            populate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out");
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //pictureBox6.Image = ("44");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Patient log = new Patient();
            log.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient log = new Patient();
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

        private void DocDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DocNameTb.Text = DocDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            DocDOB.Text = DocDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            DocPhone.Text = DocDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
            DocAdd.Text = DocDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
            DocDesiCb.SelectedItem = DocDGV.Rows[e.RowIndex].Cells[5].Value.ToString();
            DocJoin.Text = DocDGV.Rows[e.RowIndex].Cells[6].Value.ToString();

            if (DocNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DocDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void DocNameTb_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Csharp(.NET)\PROJECT\WindowsFormsApp1\WindowsFormsApp1\DiagnostiDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        private void populate()
        {
            con.Open();
            string Query = "select * from DoctorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder build = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DocDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        int key = 0;
        private void reset()
        {
            DocNameTb.Text = "";
            DocPhone.Text = "";
            DocDesiCb.SelectedIndex = -1;
            DocAdd.Text = "";
            key = 0;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (DocNameTb.Text == "" || DocPhone.Text == "" || DocDesiCb.SelectedIndex == -1 || DocAdd.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into DoctorTbl values('" + DocNameTb.Text + "','" + DocDOB.Value.Date + "','" + DocPhone.Text + "','" + DocAdd.Text + "','"+DocDesiCb.SelectedItem.ToString() +"','"+DocJoin.Value.Date+"'   )", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Saved Successfully");
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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Doctor to delete");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from DoctorTbl where DocId = '" + key + "';", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Deleted Successfully");
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
            if (DocNameTb.Text == "" || DocPhone.Text == "" || DocDesiCb.SelectedIndex == -1 || DocAdd.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string Query = "update DoctorTbl set DocName = '" + DocNameTb.Text + "',DocDOB = '" + DocDOB.Value.Date + "',DocPhone = '" + DocPhone.Text + "',DocAdd = '" + DocAdd.Text + "',Designation ='"+DocDesiCb.SelectedItem.ToString()+"',Joindate = '"+DocJoin.Value.Date+"'where DocId = '" + key + "'";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Updated Successfully");
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

        private void label5_Click_1(object sender, EventArgs e)
        {
            Test tc = new Test();
            tc.Show();
            this.Hide();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Invoice inv = new Invoice();
            inv.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Invoice inv = new Invoice();
            inv.Show();
            this.Hide();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {

        }


    }
}
