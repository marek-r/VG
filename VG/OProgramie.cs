using System;
using System.Windows.Forms;

namespace VG
{
    public partial class OProgramie : Form
    {
        public OProgramie()
        {
            InitializeComponent();
        }
        private void Oprogramie_Load(object sender, EventArgs e)
        {
            richTextBox1.Rtf = Properties.Resources.HistoriaZmian;
        }
    }
}
