using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pengkar_laura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi.CRUD($"SELECT * FROM tusers WHERE Username = '{txtusername.Text}' && Password = MD5('{txtpass.Text}')");
            int CekBaris = koneksi.DS.Tables[0].Rows.Count;

            if (CekBaris == 1)
            {

                Dashboard Fmenu = new Dashboard();
                Fmenu.Show();
                this.Hide();
            }

            else
            {
                DialogResult Gagal = MessageBox.Show("Password atau Username Salah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
