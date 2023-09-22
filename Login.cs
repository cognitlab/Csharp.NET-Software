using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
     

        public Point mouseLocation;
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
              

        }
        private const int dp = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= dp;
                return cp;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

                if (textBox1.Text == "Admin" && textBox2.Text == "admin")
                {
                    MessageBox.Show("Login Successfully Done");
                    Dashboard log = new Dashboard();
                    log.Show();
                    this.Hide();
                  
                }
                else if(textBox1.Text == "" && textBox2.Text == "")
                {
                    MessageBox.Show("Fill Details for Login");
                }
                else if (textBox1.Text != "Admin" && textBox2.Text != "admin")
                {
                    MessageBox.Show("Incorrect Username or Password");

                }
                
               
            

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            pictureBox1.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.AntiqueWhite;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DeepSkyBlue;
            button1.ForeColor = Color.GhostWhite;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            //label5.BackColor = Color.Black;
            label5.ForeColor = Color.Red;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.DeepSkyBlue;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.GhostWhite;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
        }

    

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            pictureBox1.Show();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
         
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "Admin")
            {
                pictureBox4.Show();
            }
            else if (textBox1.Text == "Admin")
            {
                pictureBox4.Hide();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "admin")
            {
                pictureBox5.Show();
            }
            else if (textBox2.Text == "admin")
            {
                pictureBox5.Hide();
            }
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            label6.Show();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            label6.Hide();
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            label7.Show();
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            label7.Hide();
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point( -e.Y,-e.X);
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X,mouseLocation.Y);
                Location = mousePose; 
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

      

     

     
       

       
    }
}