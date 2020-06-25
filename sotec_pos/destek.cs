using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sotec_pos
{
    public partial class destek : Form
    {
        public destek()
        {
            InitializeComponent();
        }

        private void destek_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            float x = (Convert.ToInt32(this.Width) - Convert.ToInt32(pnl_center.Width)) / 2;
            float y = (Convert.ToInt32(this.Height) - Convert.ToInt32(pnl_center.Height)) / 2;

            pnl_center.Location = new Point(x: Convert.ToInt32(x), y: Convert.ToInt32(y));

            try
            {
                label4.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.Major.ToString();
                label4.Text += ".";
                label4.Text += ApplicationDeployment.CurrentDeployment.CurrentVersion.Minor.ToString();
                label4.Text += ".";
                label4.Text += ApplicationDeployment.CurrentDeployment.CurrentVersion.Build.ToString();
                label4.Text += ".";
                label4.Text += ApplicationDeployment.CurrentDeployment.CurrentVersion.Revision.ToString();
            }
            catch { label4.Text = "DEBUG"; }
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
