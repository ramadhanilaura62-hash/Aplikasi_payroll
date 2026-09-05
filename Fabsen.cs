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
    public partial class Fabsen : Form
    {
        public Fabsen()
        {
            InitializeComponent();
        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2NumericUpDown1_Click(object sender, EventArgs e)
        {

        }

        private void bersih()
        {
            txtnm.Text = "";
            txtTM.Text = "";
            txtTH.Text = "";

          
            bt.Value = DateTime.Now;
            nuJL.Value = 0;
        }

        private void tampilData()
        {
            guna2DataGridView1.Rows.Clear();

            if (koneksi.DS != null)
            {
                koneksi.DS.Clear();
            }

            koneksi.CRUD("SELECT * from tabsensi");
            foreach (DataRow baris in koneksi.DS.Tables[0].Rows)
            {
                String id = "" + baris["id_absensi"];
                String nm = "" + baris["id_karyawan"];
                String bt_val = "" + baris["bulan_tahun"];
                String th = "" + baris["total_hadir"];
                String nj = "" + baris["total_mangkir"];
                String jl = "" + baris["jam_lembur"];

                guna2DataGridView1.Rows.Add(id, nm, bt_val, th, nj, jl);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtnm.Text == "" || txtTH.Text == "" || txtTM.Text == "" || nuJL.Value == 0)
            {
                MessageBox.Show("lengkapi data");
            }
            else
            {
                string NM = txtnm.Text;
                string NT = bt.Value.ToString("yyyy-MM-01 00:00:00");
                string th = txtTH.Text;
                string TM = txtTM.Text;
                string nu = TimeSpan.FromHours((double)nuJL.Value).ToString(@"hh\:mm\:ss");

                koneksi.CRUD($"INSERT INTO tabsensi VALUES(null,'{NM}','{NT}','{th}','{TM}','{nu}')");
                bersih();
                tampilData();
            }
        }

        private void guna2DataGridView1_DefaultCellStyleChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string idp = label3.Text;
            string NM = txtnm.Text;
            string NT = bt.Value.ToString("yyyy-MM-01 00:00:00");
            string th = txtTH.Text;
            string TM = txtTM.Text;
            string nu = TimeSpan.FromHours((double)nuJL.Value).ToString(@"hh\:mm\:ss");

            
            koneksi.CRUD($"UPDATE tabsensi SET id_karyawan ='{NM}', bulan_tahun = '{NT}', total_hadir = '{th}', total_mangkir ='{TM}', jam_lembur = '{nu}' WHERE id_absensi ='{idp}'");
            bersih();
            tampilData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int baris = e.RowIndex;
                int kolom = e.ColumnIndex;

                
                if (kolom == 6)
                {
                    string idpt = guna2DataGridView1.Rows[baris].Cells[0].Value.ToString();

                    if (koneksi.DS != null) koneksi.DS.Clear();

                    koneksi.CRUD($"SELECT * FROM tabsensi WHERE id_absensi = '{idpt}'");
                    foreach (DataRow brs in koneksi.DS.Tables[0].Rows)
                    {
                        String idpet = "" + brs["id_absensi"];
                        String NM = "" + brs["id_karyawan"];
                        String bu = "" + brs["bulan_tahun"];
                        String nt = "" + brs["total_hadir"];
                        String nj = "" + brs["total_mangkir"];
                        String nl = "" + brs["jam_lembur"];

                        label3.Text = idpet;
                        txtnm.Text = NM;
                        txtTH.Text = nt;
                        txtTM.Text = nj;

                       
                        if (DateTime.TryParse(bu, out DateTime parsedDate))
                        {
                            bt.Value = parsedDate;
                        }

                      
                        if (TimeSpan.TryParse(nl, out TimeSpan parsedTime))
                        {
                            nuJL.Value = (decimal)parsedTime.TotalHours;
                        }
                    }
                }

                if (kolom == 7)
                {
                    string idpt = guna2DataGridView1.Rows[baris].Cells[0].Value.ToString();
                    DialogResult setuju = MessageBox.Show("Hapus data?", "Pemberitahuan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (setuju == DialogResult.Yes)
                    {
                        koneksi.CRUD($"DELETE FROM tabsensi WHERE id_absensi = '{idpt}'");
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

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}