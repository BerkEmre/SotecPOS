using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sotec_pos
{
    public partial class disa_aktar : Form
    {
        public disa_aktar()
        {
            InitializeComponent();
        }

        private void disa_aktar_Load(object sender, EventArgs e)
        {
            rp_viewer.PrintingSystem.ExecCommand(PrintingSystemCommand.ZoomToWholePage);
        }
    }
}
