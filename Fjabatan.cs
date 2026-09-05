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
    public partial class Fjabatan : Form
    {
        public Fjabatan()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtGJ.Text == "" || txTJ.Text == "" || cmbjabatan.Text == "")
            {
                MessageBox.Show("lengkapi data");
            }
            else
            {
                string NM = txtGJ.Text;
                string NT = txTJ.Text;
                string agm = cmbjabatan.Text;


                koneksi.CRUD($"INSERT INTO tjabatan VALUES(null,'{agm}','{NM}','{NT}')");
                bersih();
                tampilData();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string idp = label3.Text;
            string NM = txtGJ.Text;

            string AL = txTJ.Text;
            string agm = cmbjabatan.Text;



            koneksi.CRUD($"UPDATE tjabatan SET nama_jabatan = '{agm}', gaji_pokok = '{NM}', tunjangan_jabatan = '{AL}' where id_jabatan ='{idp}'");
            bersih();
            tampilData();
        }



        private void bersih()
        {
            txtGJ.Text = "";

            cmbjabatan.Text = " ";
            txTJ.Text = "";
        }

        private void tampilData()
        {
            guna2DataGridView1.Rows.Clear();


            if (koneksi.DS != null)
            {
                koneksi.DS.Clear();
            }

            koneksi.CRUD("SELECT * from tjabatan");
            foreach (DataRow baris in koneksi.DS.Tables[0].Rows)
            {
                String id = "" + baris["id_jabatan"];
                String nm = "" + baris["nama_jabatan"];

                String no = "" + baris["gaji_pokok"];
                String nj = "" + baris["tunjangan_jabatan"];

                // Disesuaikan urutan tambahnya: ID, Nama Jabatan, Gaji Pokok, Tunjangan
                guna2DataGridView1.Rows.Add(id, nm, no, nj);
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int baris = e.RowIndex;
                int kolom = e.ColumnIndex;
                if (kolom == 4)
                {
                    string idpt = guna2DataGridView1.Rows[baris].Cells[0].Value.ToString();

                    if (koneksi.DS != null) koneksi.DS.Clear();

                    koneksi.CRUD($"SELECT * FROM tjabatan WHERE id_jabatan = '{idpt}'");
                    foreach (DataRow brs in koneksi.DS.Tables[0].Rows)
                    {
                        String idpet = "" + brs["id_jabatan"];
                        String NM = "" + brs["nama_jabatan"];
                        String nt = "" + brs["gaji_pokok"];
                        String nj = "" + brs["tunjangan_jabatan"];
                        label3.Text = idpet;
                        txtGJ.Text = nt;
                        txTJ.Text = nj;
                        cmbjabatan.Text = NM;




                    }
                }
                if (kolom == 5)
                {
                    string idpt = guna2DataGridView1.Rows[baris].Cells[0].Value.ToString();
                    DialogResult setuju = MessageBox.Show("Hapus data?", "Pemberitahuan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (setuju == DialogResult.Yes)
                    {
                        koneksi.CRUD($"Delete from tjabatan where id_jabatan = '{idpt}'");
                        bersih();
                        tampilData();
                    }
                }
            }
        }

        private void cmbjabatan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (cmbjabatan.Text != "")
                {
                    txtGJ.Select();
                }
            }
        }
        private void txtGJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtGJ.Text != "")
                {
                    txTJ.Select();
                }
            }
        }

        private void txtTJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txTJ.Text != "")
                {
                    guna2Button1.Select();
                }
            }
        }
    }

}