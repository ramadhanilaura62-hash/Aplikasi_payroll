using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pengkar_laura
{
    class KF
    {
        public static void untukFormLaura(Form formapa, Panel panelapa)
        {
            panelapa.Controls.Clear();
            formapa.FormBorderStyle = FormBorderStyle.None;
            formapa.Dock = DockStyle.Fill;
            panelapa.Controls.Add(formapa);
            formapa.Show();
        }
    }
}
