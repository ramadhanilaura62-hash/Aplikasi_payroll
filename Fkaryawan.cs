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
    public partial class Fkaryawan : Form
    {
        public Fkaryawan()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bersih()
        {
            txtnik.Text = "";
            txtnm.Text = "";
            txtalamat.Text = "";
            txtNT.Text = "";

            cmbjabatan.SelectedIndex = -1;
            cmbjabatan.Text = "";
            cmbjk.SelectedIndex = -1;
            cmbjk.Text = "";
            cmbstatus.SelectedIndex = -1;
            cmbstatus.Text = "";

            date.Value = DateTime.Now;
            label3.Text = "";
        }

        private void tampilData()
        {
            guna2DataGridView1.Rows.Clear();

            if (koneksi.DS != null)
            {
                koneksi.DS.Clear();
            }

           
            koneksi.CRUD("SELECT k.*, j.nama_jabatan FROM tkaryawan k LEFT JOIN tjabatan j ON k.id_jabatan = j.id_jabatan");

            foreach (DataRow baris in koneksi.DS.Tables[0].Rows)
            {
                String id = "" + baris["id_karyawan"];
                String nik = "" + baris["nik"];
                String nm = "" + baris["nama_karyawan"];
                String jk = "" + baris["jenis_kelamin"];
                String al = "" + baris["alamat"];
                String no = "" + baris["nomor_telp"];
                String tgl = Convert.ToDateTime(baris["tanggal_masuk"]).ToString("yyyy-MM-dd");
                String nj = "" + baris["nama_jabatan"];
                String st = "" + baris["status"];

                guna2DataGridView1.Rows.Add(id, nik, nm, jk, al, no, tgl, nj, st);
            }
        }

       
        private string getIdJabatan(string namaJabatan)
        {
            string id = "0";
            if (koneksi.DS != null) koneksi.DS.Clear();
            koneksi.CRUD($"SELECT id_jabatan FROM tjabatan WHERE nama_jabatan = '{namaJabatan}'");
            if (koneksi.DS.Tables[0].Rows.Count > 0)
            {
                id = koneksi.DS.Tables[0].Rows[0]["id_jabatan"].ToString();
            }
            return id;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtnik.Text == "" || txtNT.Text == "" || cmbjabatan.SelectedIndex == -1 ||
                cmbjk.SelectedIndex == -1 || txtalamat.Text == "" || txtnm.Text == ""
                || cmbstatus.SelectedIndex == -1 || date.Text == "")
            {
                MessageBox.Show("lengkapi data");
            }
            else
            {
                string NM = txtnik.Text;
                string NT = txtNT.Text;
                string agm = "" + cmbjabatan.SelectedItem;
                string al = txtalamat.Text;
                string nm = txtnm.Text;
                string jk = "" + cmbjk.SelectedItem;
                string st = "" + cmbstatus.SelectedItem;
                string dt = date.Value.ToString("yyyy-MM-dd");

                string idJabatan = getIdJabatan(agm);

                
                koneksi.CRUD($"INSERT INTO tkaryawan VALUES(null,'{NM}','{nm}','{jk}','{al}','{NT}','{dt}','{idJabatan}','{st}')");

                bersih();
                tampilData();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string idp = label3.Text;
            string NM = txtnik.Text;
            string nm = txtnm.Text;
            string jk = "" + cmbjk.SelectedItem;
            string al = txtalamat.Text;
            string NT = txtNT.Text;
            string agm = "" + cmbjabatan.SelectedItem;
            string st = "" + cmbstatus.SelectedItem;
            string dt = date.Value.ToString("yyyy-MM-dd");

            string idJabatan = getIdJabatan(agm);

            koneksi.CRUD($"UPDATE tkaryawan SET nik = '{NM}', nama_karyawan = '{nm}', jenis_kelamin = '{jk}', alamat = '{al}', nomor_telp = '{NT}', tanggal_masuk = '{dt}', id_jabatan = '{idJabatan}', status = '{st}' WHERE id_karyawan = '{idp}'");
            bersih();
            tampilData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int baris = e.RowIndex;
                int kolom = e.ColumnIndex;

               
                if (kolom == 9 || kolom == 4)
                {
                    string idpt = guna2DataGridView1.Rows[baris].Cells[0].Value.ToString();

                    if (koneksi.DS != null) koneksi.DS.Clear();

                    koneksi.CRUD($"SELECT k.*, j.nama_jabatan FROM tkaryawan k LEFT JOIN tjabatan j ON k.id_jabatan = j.id_jabatan WHERE k.id_karyawan = '{idpt}'");
                    foreach (DataRow brs in koneksi.DS.Tables[0].Rows)
                    {
                        String idpet = "" + brs["id_karyawan"];
                        String NIK = "" + brs["nik"];
                        String NM = "" + brs["nama_karyawan"];
                        String JK = "" + brs["jenis_kelamin"];
                        String AL = "" + brs["alamat"];
                        String nt = "" + brs["nomor_telp"];
                        String nj = "" + brs["nama_jabatan"];
                        String ST = "" + brs["status"];

                        label3.Text = idpet;
                        txtnik.Text = NIK;
                        txtnm.Text = NM;
                        cmbjk.Text = JK;
                        txtalamat.Text = AL;
                        txtNT.Text = nt;
                        cmbjabatan.Text = nj;
                        cmbstatus.Text = ST;

                        if (DateTime.TryParse("" + brs["tanggal_masuk"], out DateTime dtMasuk))
                        {
                            date.Value = dtMasuk;
                        }
                    }
                }
                if (kolom == 10 || kolom == 5)
                {
                    string idpt = guna2DataGridView1.Rows[baris].Cells[0].Value.ToString();
                    DialogResult setuju = MessageBox.Show("Hapus data?", "Pemberitahuan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (setuju == DialogResult.Yes)
                    {
                        koneksi.CRUD($"Delete from tkaryawan where id_karyawan = '{idpt}'");
                        bersih();
                        tampilData();
                    }
                }
            }
        }

        private void cmbjabatan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbjabatan_DropDown(object sender, EventArgs e)
        {
            cmbjabatan.Items.Clear();

            koneksi.CRUD("SELECT * FROM tjabatan");

            foreach (DataRow baris in koneksi.DS.Tables[0].Rows)
            {
                string NM = "" + baris["nama_jabatan"];
                cmbjabatan.Items.Add(NM);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampilData();
        }

        private void txtNT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtNT.Text != "")
                {
                    cmbjabatan.Select();
                }
            }
        }

        private void txtnm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtnik.Text != "")
                {
                    txtNT.Select();
                }
            }
        }

        private void guna2Button1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbjabatan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (cmbjabatan.Text != "")
                {
                    guna2Button1.Select();
                }
            }
        }

        private void cmbstatus_DropDown(object sender, EventArgs e)
        {
            cmbstatus.Items.Clear();
            cmbstatus.Items.Add("Aktif");
            cmbstatus.Items.Add("Tidak Aktif");
        }

        private void cmbjk_DropDown(object sender, EventArgs e)
        {
            cmbjk.Items.Clear();
            cmbjk.Items.Add("Laki - Laki");
            cmbjk.Items.Add("Perempuan");
        }
    }
}