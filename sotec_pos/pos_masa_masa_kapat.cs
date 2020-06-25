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
    public partial class pos_masa_masa_kapat : Form
    {
        public pos_masa_masa_kapat(string text)
        {
            InitializeComponent();

            lbl_urun.Text = text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void pos_masa_masa_kapat_Load(object sender, EventArgs e)
        {
            DataTable dt_ikram = SQL.get("SELECT parametre_id, deger FROM parametreler WHERE silindi = 0 AND tip = 'masa_kapat'");
            cmb_ikram.Properties.DataSource = dt_ikram;
            cmb_ikram.EditValue = dt_ikram.Rows[0]["parametre_id"];
        }
    }
}
