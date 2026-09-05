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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void pnlkonten_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trole_Click(object sender, EventArgs e)
        {

            Frole frole = new Frole() { TopMost = true, TopLevel = false };
            KF.untukFormLaura(frole, pnlkonten);
        }

        private void tuser_Click(object sender, EventArgs e)
        {
            Fuser fusers = new Fuser() { TopMost = true, TopLevel = false };
            KF.untukFormLaura(fusers, pnlkonten);
        }

        private void tkaryawan_Click(object sender, EventArgs e)
        {
            Fkaryawan fkaryawan = new Fkaryawan() { TopMost = true, TopLevel = false };
            KF.untukFormLaura(fkaryawan, pnlkonten);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Fabsen fabsen = new Fabsen() { TopMost = true, TopLevel = false };
            KF.untukFormLaura(fabsen, pnlkonten);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Fjabatan fjabatan = new Fjabatan() { TopMost = true, TopLevel = false };
            KF.untukFormLaura(fjabatan, pnlkonten);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
