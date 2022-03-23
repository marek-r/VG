using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VG
{
    /// <summary>
    /// Okno zawierające skróty w programie.
    /// </summary>
    public partial class Klawiszologia : Form
    {
        public Klawiszologia()
        {
            InitializeComponent();
        }
        private void Klawiszologia_Load(object sender, EventArgs e)
        {
            richTextBox1.Rtf = Properties.Resources.Klawiszologia;
        }
    }
}
