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
    public partial class personel_gec_mesai : Form
    {
        int kullanici_id;

        public personel_gec_mesai(int kullanici_id)
        {
            this.kullanici_id = kullanici_id;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personel_gec_mesai_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT gm.gec_mesai_id, gm.dakika, gm.tarih, tip = p.deger FROM kullanicilar_gec_mesai gm INNER JOIN parametreler p ON p.parametre_id = gm.tip_parametre_id WHERE gm.silindi = 0 AND gm.kullanici_id = " + kullanici_id);
            grid_personeller.DataSource = dt;

            DataTable dt_kullanici = SQL.get("SELECT * FROM kullanicilar WHERE kullanici_id = " + kullanici_id);
            lbl_ad_soyad.Text = dt_kullanici.Rows[0]["ad"].ToString() + " " + dt_kullanici.Rows[0]["soyad"].ToString();

            DataTable dt_cari = SQL.get("SELECT * FROM parametreler WHERE silindi = 0 AND tip = 'gec_mesai'");
            cmb_tip.Properties.DataSource = dt_cari;
            cmb_tip.EditValue = dt_cari.Rows[0]["parametre_id"];
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            SQL.set("INSERT INTO kullanicilar_gec_mesai (kullanici_id, dakika, tarih, tip_parametre_id) VALUES (" + kullanici_id + ", " + tb_dakika.Value.ToString().Replace(',', '.') + ", '" + dt_tarih.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " + cmb_tip.EditValue + ")");
            DataTable dt = SQL.get("SELECT gm.gec_mesai_id, gm.dakika, gm.tarih, tip = p.deger FROM kullanicilar_gec_mesai gm INNER JOIN parametreler p ON p.parametre_id = gm.tip_parametre_id WHERE gm.silindi = 0 AND gm.kullanici_id = " + kullanici_id);
            grid_personeller.DataSource = dt;
        }

        private void grid_personeller_KeyDown(object sender, KeyEventArgs e)
        {
            if (gv_personeller.SelectedRowsCount <= 0)
                return;

            if(e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE kullanicilar_gec_mesai SET silindi = 1 WHERE gec_mesai_id = " + gv_personeller.GetDataRow(gv_personeller.GetSelectedRows()[0])["gec_mesai_id"].ToString());
                    DataTable dt = SQL.get("SELECT gm.gec_mesai_id, gm.dakika, gm.tarih, tip = p.deger FROM kullanicilar_gec_mesai gm INNER JOIN parametreler p ON p.parametre_id = gm.tip_parametre_id WHERE gm.silindi = 0 AND gm.kullanici_id = " + kullanici_id);
                    grid_personeller.DataSource = dt;
                }
            }
        }
    }
}
