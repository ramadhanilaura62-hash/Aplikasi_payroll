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
    public partial class Fuser : Form
    {
        public Fuser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Fungsi helper untuk mengambil id_role berdasarkan role_name
        private string getRoleId(string roleName)
        {
            string id = "0";
            if (koneksi.DS != null) koneksi.DS.Clear();
            koneksi.CRUD($"SELECT id_role FROM trole WHERE role_name = '{roleName}'");
            if (koneksi.DS.Tables[0].Rows.Count > 0)
            {
                id = koneksi.DS.Tables[0].Rows[0]["id_role"].ToString();
            }
            return id;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "" || txtpass.Text == "" || cmbrole.SelectedIndex == -1)
            {
                MessageBox.Show("lengkapi data");
            }
            else
            {
                string NM = txtuser.Text;
                string AL = txtpass.Text;
                string agm = "" + cmbrole.SelectedItem;

                // Mengambil id_role berdasarkan role_name yang dipilih
                string roleId = getRoleId(agm);

                // Disertai nama kolom agar INSERT aman dan tidak bentrok dengan jumlah kolom di database
                koneksi.CRUD($"INSERT INTO tusers (username, password, nama_karyawan, id_role) VALUES ('{NM}', '{AL}', '{NM}', '{roleId}')");
                bersih();
                tampilData();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string idp = label3.Text;
            string NM = txtuser.Text;
            string AL = txtpass.Text;
            string agm = "" + cmbrole.SelectedItem;

            string roleId = getRoleId(agm);

            // Perbaikan id_role
            koneksi.CRUD($"UPDATE tusers SET username = '{NM}', password = '{AL}', nama_karyawan = '{NM}', id_role = '{roleId}' WHERE id_user = '{idp}'");
            bersih();
            tampilData();
        }

        private void bersih()
        {
            txtuser.Text = "";
            txtpass.Text = "";
            cmbrole.Text = " ";
            cmbrole.SelectedIndex = -1;
            label3.Text = "";
        }

        private void tampilData()
        {
            guna2DataGridView1.Rows.Clear();

            if (koneksi.DS != null)
            {
                koneksi.DS.Clear();
            }

            // PERBAIKAN: Menggunakan id_role bukan role_id
            koneksi.CRUD("SELECT u.*, r.role_name FROM tusers u LEFT JOIN trole r ON u.id_role = r.id_role");

            if (koneksi.DS != null && koneksi.DS.Tables.Count > 0)
            {
                foreach (DataRow baris in koneksi.DS.Tables[0].Rows)
                {
                    String IDP = "" + baris["id_user"];
                    String NM = "" + baris["username"];
                    String PS = "" + baris["password"];
                    String R = "" + baris["role_name"];

                    guna2DataGridView1.Rows.Add(IDP, NM, PS, R);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampilData();
        }

        private void cmbrole_DropDown(object sender, EventArgs e)
        {
            cmbrole.Items.Clear();

            koneksi.CRUD("SELECT * FROM trole");

            if (koneksi.DS != null && koneksi.DS.Tables.Count > 0)
            {
                foreach (DataRow baris in koneksi.DS.Tables[0].Rows)
                {
                    string NM = "" + baris["role_name"];
                    cmbrole.Items.Add(NM);
                }
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

                    // PERBAIKAN: JOIN menggunakan u.id_role = r.id_role
                    koneksi.CRUD($"SELECT u.*, r.role_name FROM tusers u LEFT JOIN trole r ON u.id_role = r.id_role WHERE u.id_user = '{idpt}'");
                    foreach (DataRow brs in koneksi.DS.Tables[0].Rows)
                    {
                        String idpet = "" + brs["id_user"];
                        String NM = "" + brs["username"];
                        String PS = "" + brs["password"];
                        String R = "" + brs["role_name"];

                        label3.Text = idpet;
                        txtuser.Text = NM;
                        txtpass.Text = PS;
                        cmbrole.Text = R;
                    }
                }
                if (kolom == 5)
                {
                    string idpt = guna2DataGridView1.Rows[baris].Cells[0].Value.ToString();
                    DialogResult setuju = MessageBox.Show("Hapus data?", "Pemberitahuan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (setuju == DialogResult.Yes)
                    {
                        koneksi.CRUD($"DELETE FROM tusers WHERE id_user = '{idpt}'");
                        bersih();
                        tampilData();
                    }
                }
            }
        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtuser.Text != "")
                {
                    txtpass.Select();
                }
            }
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtpass.Text != "")
                {
                    cmbrole.Select();
                }
            }
        }

        private void cmbrole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}