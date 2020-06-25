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
    public partial class mesaj : Form
    {
        public mesaj(string mesaj)
        {
            InitializeComponent();
            label1.Text = mesaj;

            float x = (Convert.ToInt32(this.Width) - Convert.ToInt32(label1.Width)) / 2;
            float y = (Convert.ToInt32(this.Height) - Convert.ToInt32(label1.Height)) / 2;

            label1.Location = new Point(x: Convert.ToInt32(x), y: Convert.ToInt32(y));

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mesaj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
