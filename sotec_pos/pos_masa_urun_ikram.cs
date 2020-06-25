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
    public partial class pos_masa_urun_ikram : Form
    {
        int adisyon_kalem_id;

        public pos_masa_urun_ikram(int adisyon_kalem_id)
        {
            this.adisyon_kalem_id = adisyon_kalem_id;

            InitializeComponent();
        }

        private void pos_masa_urun_ikram_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT ak.adisyon_kalem_id, u.urun_adi, ak.miktar, tutar = CASE ak.ikram WHEN 1 THEN 0.0000 ELSE ak.miktar * u.fiyat END, olcu_birimi = p.deger, ak.ikram FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE ak.adisyon_kalem_id = " + adisyon_kalem_id);
            lbl_urun.Text = dt.Rows[0]["urun_adi"].ToString();
            lbl_miktar.Text = Convert.ToDecimal(dt.Rows[0]["miktar"]).ToString("N2") + " " + dt.Rows[0]["olcu_birimi"].ToString();

            tb_miktar.Maximum = Convert.ToDecimal(dt.Rows[0]["miktar"]);

            DataTable dt_ikram = SQL.get("SELECT parametre_id = 0, deger = 'İkram İptal' UNION ALL SELECT parametre_id, deger FROM parametreler WHERE silindi = 0 AND tip = 'ikram_sebep'");
            cmb_ikram.Properties.DataSource = dt_ikram;
            cmb_ikram.EditValue = dt_ikram.Rows[0]["parametre_id"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQL.set("UPDATE adisyon_kalem SET ikram = " + cmb_ikram.EditValue + ", ikram_miktar = " + (cmb_ikram.EditValue.ToString() == "0" ? "0" : tb_miktar.Value.ToString().Replace(',', '.')) + " WHERE adisyon_kalem_id = " + adisyon_kalem_id);

            this.Close();
        }

        private void tb_miktar_Click(object sender, EventArgs e)
        {
            using (var form = new num_pad())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tb_miktar.Value = form.tb_miktar.Value;
                }
            }
        }
    }
}
