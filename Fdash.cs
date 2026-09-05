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
    public partial class Fdash : Form
    {
        public Fdash()
        {
            InitializeComponent();
        }

        private void trole_Click(object sender, EventArgs e)
        {
            Frole frole = new Frole() { TopMost = true, TopLevel = false };
            KF.untukFormLaura(frole, pnlkonten);
        }
    }
}
