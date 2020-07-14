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
    public partial class pos_masa_urun_iptal : Form
    {
        int adisyon_kalem_id;

        public pos_masa_urun_iptal(int adisyon_kalem_id)
        {
            this.adisyon_kalem_id = adisyon_kalem_id;

            InitializeComponent();
        }

        private void pos_masa_urun_iptal_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT ak.adisyon_kalem_id, u.urun_adi, ak.miktar, tutar = CASE ak.ikram WHEN 1 THEN 0.0000 ELSE ak.miktar * u.fiyat END, olcu_birimi = p.deger FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE ak.adisyon_kalem_id = " + adisyon_kalem_id);
            lbl_urun.Text = dt.Rows[0]["urun_adi"].ToString();
            lbl_miktar.Text = Convert.ToDecimal(dt.Rows[0]["miktar"]).ToString("N2") + " " + dt.Rows[0]["olcu_birimi"].ToString();
            tb_miktar.Value = Convert.ToDecimal(dt.Rows[0]["miktar"]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT ak.*, u.urun_adi FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.adisyon_kalem_id = " + adisyon_kalem_id);
            int urun_id = Convert.ToInt32(dt.Rows[0]["urun_id"]);
            int adisyon_id = Convert.ToInt32(dt.Rows[0]["adisyon_id"]);
            decimal miktar = Convert.ToDecimal(dt.Rows[0]["miktar"]);

            if (tb_miktar.Value >= miktar)
                SQL.set("UPDATE adisyon_kalem SET silindi = 1 WHERE adisyon_kalem_id = " + adisyon_kalem_id);
            else
                SQL.set("UPDATE adisyon_kalem SET miktar = miktar - " + tb_miktar.Value.ToString().Replace(',', '.') + " WHERE adisyon_kalem_id = " + adisyon_kalem_id);

            if(!cb_hazirlandi.Checked)
                SQL.set("INSERT INTO urunler_hareket (urun_id, hareket_tipi_parametre_id, miktar, referans_id, birim_fiyat) VALUES (" + urun_id + ", 2, " + tb_miktar.Value.ToString().Replace(',', '.') + ", " + adisyon_id + ", 0.0000)");
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
