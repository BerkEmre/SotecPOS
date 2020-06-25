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
    public partial class personel_maas_odeme : Form
    {
        public personel_maas_odeme()
        {
            InitializeComponent();
        }

        private void personel_maas_odeme_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT * FROM kullanicilar WHERE silindi = 0");
            grid_personeller.DataSource = dt;

            DataTable dt_odemeler = SQL.get("SELECT mo.maas_odeme_id, mo.kullanici_id, mo.maas, mo.tarih, k.ad, k.soyad, odeme_tipi = p.deger, yil = YEAR(mo.tarih), ay = MONTH(mo.tarih) FROM kullanicilar_maas_odeme mo INNER JOIN kullanicilar k ON k.kullanici_id = mo.kullanici_id INNER JOIN parametreler p ON p.parametre_id = mo.odeme_tipi_parametre_id WHERE mo.silindi = 0");
            grid_maas_odeme.DataSource = dt_odemeler;

            DataTable dt_p = SQL.get("SELECT * FROM parametreler WHERE silindi = 0 AND tip = 'personel_odeme'");
            cmb_odeme_tipi.Properties.DataSource = dt_p;
            cmb_odeme_tipi.EditValue = dt_p.Rows[0]["parametre_id"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if(gv_personeller.SelectedRowsCount <= 0)
            {
                new mesaj("Personel Seçiniz!").ShowDialog();
                return;
            }

            DataRow dr;
            DataTable dt_ps;
            for (int i = 0; i < gv_personeller.SelectedRowsCount; i++)
            {
                dr = gv_personeller.GetDataRow(gv_personeller.GetSelectedRows()[i]);

                if (Convert.ToDecimal(dr["maas"]) == 0)
                    continue;

                dt_ps = SQL.get("INSERT INTO kullanicilar_maas_odeme (kullanici_id, maas, tarih, odeme_tipi_parametre_id) VALUES (" + dr["kullanici_id"] + ", " + dr["maas"].ToString().Replace(',', '.') + ", '" + dt_tarih.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " + cmb_odeme_tipi.EditValue + "); SELECT SCOPE_IDENTITY();");
                SQL.set("INSERT INTO finans_hareket (hareket_tipi_parametre_id, miktar, referans_id) VALUES (23, " + (Convert.ToDecimal(dr["maas"]) * -1).ToString().Replace(',', '.') + ", " + dt_ps.Rows[0][0] + ")");
            }

            DataTable dt = SQL.get("SELECT * FROM kullanicilar WHERE silindi = 0");
            grid_personeller.DataSource = dt;

            DataTable dt_odemeler = SQL.get("SELECT mo.maas_odeme_id, mo.kullanici_id, mo.maas, mo.tarih, k.ad, k.soyad, odeme_tipi = p.deger, yil = YEAR(mo.tarih), ay = MONTH(mo.tarih) FROM kullanicilar_maas_odeme mo INNER JOIN kullanicilar k ON k.kullanici_id = mo.kullanici_id INNER JOIN parametreler p ON p.parametre_id = mo.odeme_tipi_parametre_id WHERE mo.silindi = 0");
            grid_maas_odeme.DataSource = dt_odemeler;
        }

        private void grid_maas_odeme_KeyDown(object sender, KeyEventArgs e)
        {
            if (gv_maas_odeme.SelectedRowsCount <= 0)
                return;

            if (e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE kullanicilar_maas_odeme SET silindi = 1 WHERE maas_odeme_id = " + gv_maas_odeme.GetDataRow(gv_maas_odeme.GetSelectedRows()[0])["maas_odeme_id"].ToString());
                    SQL.set("UPDATE finans_hareket SET silindi = 1 WHERE hareket_tipi_parametre_id = 23 AND referans_id = " + gv_maas_odeme.GetDataRow(gv_maas_odeme.GetSelectedRows()[0])["maas_odeme_id"].ToString());

                    DataTable dt_odemeler = SQL.get("SELECT mo.maas_odeme_id, mo.kullanici_id, mo.maas, mo.tarih, k.ad, k.soyad, odeme_tipi = p.deger, yil = YEAR(mo.tarih), ay = MONTH(mo.tarih) FROM kullanicilar_maas_odeme mo INNER JOIN kullanicilar k ON k.kullanici_id = mo.kullanici_id INNER JOIN parametreler p ON p.parametre_id = mo.odeme_tipi_parametre_id WHERE mo.silindi = 0");
                    grid_maas_odeme.DataSource = dt_odemeler;
                }
            }
        }
    }
}
