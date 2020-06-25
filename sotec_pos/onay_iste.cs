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
    public partial class onay_iste : Form
    {
        public onay_iste()
        {
            InitializeComponent();
        }

        private void onay_iste_Load(object sender, EventArgs e)
        {
            label3.Text = Program.GetMacAddress();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
