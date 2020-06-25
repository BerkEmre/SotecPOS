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
    public partial class finans_genel_gider : Form
    {
        public finans_genel_gider()
        {
            InitializeComponent();
        }

        private void finans_genel_gider_Load(object sender, EventArgs e)
        {
            DataTable dt_cari = SQL.get("SELECT * FROM cariler WHERE silindi = 0");
            if (dt_cari.Rows.Count <= 0)
            {
                new mesaj("Cari girmeden tahsilat fişi giremezsiniz!").ShowDialog();
                this.Close();
                return;
            }
            cmb_cariler.Properties.DataSource = dt_cari;
            cmb_cariler.EditValue = dt_cari.Rows[0]["cari_id"];

            DataTable dt_p = SQL.get("SELECT * FROM parametreler WHERE silindi = 0 AND parametre_id IN (60, 61)");
            cmb_tahsilat_tipi.Properties.DataSource = dt_p;
            cmb_tahsilat_tipi.EditValue = dt_p.Rows[0]["parametre_id"];

            DataTable dt_tahsilatlar = SQL.get("SELECT fh.finans_aciklama, fh.finans_hareket_id, fh.kayit_tarihi, fh.miktar, c.cari_adi, p.deger FROM finans_hareket fh INNER JOIN cariler c ON c.cari_id = fh.referans_id INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (60, 61)");
            grid_tahsilat.DataSource = dt_tahsilatlar;
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if (tb_tutar.Value <= 0)
            {
                new mesaj("Tutar 0 girilemez!").Show();
                return;
            }

            SQL.set("INSERT INTO finans_hareket (hareket_tipi_parametre_id, miktar, referans_id, finans_aciklama) VALUES (" + cmb_tahsilat_tipi.EditValue + ", " + (tb_tutar.Value * -1).ToString().Replace(',', '.') + ", " + cmb_cariler.EditValue + ", '" + tb_aciklama.Text + "')");

            DataTable dt_tahsilatlar = SQL.get("SELECT fh.finans_aciklama, fh.finans_hareket_id, fh.kayit_tarihi, fh.miktar, c.cari_adi, p.deger FROM finans_hareket fh INNER JOIN cariler c ON c.cari_id = fh.referans_id INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (60, 61)");
            grid_tahsilat.DataSource = dt_tahsilatlar;

            tb_tutar.Value = 0;
            tb_aciklama.Text = "";
        }

        private void grid_tahsilat_KeyDown(object sender, KeyEventArgs e)
        {
            if (gv_tahsilat.SelectedRowsCount <= 0)
                return;

            if(e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE finans_hareket SET silindi = 1 WHERE finans_hareket_id = " + gv_tahsilat.GetDataRow(gv_tahsilat.GetSelectedRows()[0])["finans_hareket_id"]);

                    DataTable dt_tahsilatlar = SQL.get("SELECT fh.finans_aciklama, fh.finans_hareket_id, fh.kayit_tarihi, fh.miktar, c.cari_adi, p.deger FROM finans_hareket fh INNER JOIN cariler c ON c.cari_id = fh.referans_id INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (60, 61)");
                    grid_tahsilat.DataSource = dt_tahsilatlar;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
