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
    public partial class pos_masa_kalem_aciklama : Form
    {
        int adisyon_kalem_id;
        public pos_masa_kalem_aciklama(int adisyon_kalem_id)
        {
            InitializeComponent();

            this.adisyon_kalem_id = adisyon_kalem_id;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SQL.set("UPDATE adisyon_kalem SET aciklama = '" + richTextBox1.Text + "' WHERE adisyon_kalem_id = " + adisyon_kalem_id);
            this.Close();
        }

        private void pos_masa_kalem_aciklama_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT * FROM adisyon_kalem WHERE adisyon_kalem_id = " + adisyon_kalem_id);
            richTextBox1.Text = dt.Rows[0]["aciklama"].ToString();
        }
    }
}
