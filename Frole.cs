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
    public partial class Frole : Form
    {
        public Frole()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void bersih()
        {
            txtnama_role.Text = "";
            label3.Text = "";
        }
        private void tampilData()
        {
            guna2DataGridView1.Rows.Clear();

           
            if (koneksi.DS != null)
            {
                koneksi.DS.Clear();
            }

            koneksi.CRUD("SELECT * from trole");
            foreach (DataRow baris in koneksi.DS.Tables[0].Rows)
            {
                String IDP = "" + baris["role_id"];
                String NM = "" + baris["role_name"];

                guna2DataGridView1.Rows.Add(IDP, NM);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtnama_role.Text == "")
            {
                MessageBox.Show("lengkapi data");
            }
            else
            {
                string NM = txtnama_role.Text;

                koneksi.CRUD($"INSERT INTO trole VALUES(null,'{NM}')");
                bersih();
                tampilData();
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string idp = label3.Text;
            string NM = txtnama_role.Text;

            koneksi.CRUD($"UPDATE trole SET role_name = '{NM}' where role_id='{idp}'");
            bersih();
            tampilData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                int baris = e.RowIndex;
                int kolom = e.ColumnIndex;
                if (kolom == 2)
                {
                    string idpt = guna2DataGridView1.Rows[baris].Cells[0].Value.ToString();

                    if (koneksi.DS != null) koneksi.DS.Clear();

                    koneksi.CRUD($"SELECT * FROM trole WHERE role_id = '{idpt}'");
                    foreach (DataRow brs in koneksi.DS.Tables[0].Rows)
                    {
                        string idpet = "" + brs["role_id"];
                        label3.Text = idpet;
                        string nama = "" + brs["role_name"];

                        txtnama_role.Text = nama;
                    }
                }
                if (kolom == 3)
                {
                    string idpt = guna2DataGridView1.Rows[baris].Cells[0].Value.ToString();
                    DialogResult setuju = MessageBox.Show("Hapus data?", "Pemberitahuan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (setuju == DialogResult.Yes)
                    {
                        koneksi.CRUD($"Delete from trole where role_id = '{idpt}'");
                        bersih();
                        tampilData(); 
                    }
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampilData();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtnama_role_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    if (txtnama_role.Text != "")
                    {
                        guna2Button1.Select();
                    }
                }
            
        }
    }
}