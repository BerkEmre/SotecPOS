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
    public partial class pos_masa_satis_finans_sil_duzenle : Form
    {
        int finans_hareket_id;

        public pos_masa_satis_finans_sil_duzenle(int finans_hareket_id)
        {
            InitializeComponent();

            this.finans_hareket_id = finans_hareket_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQL.set("UPDATE finans_hareket SET silindi = 1 WHERE finans_hareket_id = " + finans_hareket_id);
            SQL.set("UPDATE adisyon_kalem SET odendi = 0 WHERE odendi = " + finans_hareket_id);
            this.Close();
        }

        private void pos_masa_satis_finans_sil_duzenle_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT * FROM finans_hareket WHERE finans_hareket_id = " + finans_hareket_id);

            DataTable dt_cinsiyet = SQL.get("SELECT * FROM parametreler WHERE parametre_id IN (25, 26, 27)");
            cmb_hedef.Properties.DataSource = dt_cinsiyet;
            cmb_hedef.EditValue = dt.Rows[0]["hareket_tipi_parametre_id"];

            tb_miktar.Value = Convert.ToDecimal(dt.Rows[0]["miktar"]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQL.set("UPDATE finans_hareket SET hareket_tipi_parametre_id = " + cmb_hedef.EditValue + " WHERE finans_hareket_id = " + finans_hareket_id);
            this.Close();
        }
    }
}
