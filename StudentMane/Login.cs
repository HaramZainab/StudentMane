using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentMane
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            if (Usertb.Text == "" || Passtb.Text == "")
            {
                MessageBox.Show("Missing Details");
            } else if (Usertb.Text == "Admin" && Passtb.Text == "Password")
            {
                Student obj = new Student();
                obj.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Wrong user name or password!!");
                Usertb.Text = "";
                Passtb.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
