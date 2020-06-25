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
    public partial class urunler_stok_sayim : Form
    {
        public urunler_stok_sayim()
        {
            InitializeComponent();
        }

        private void urunler_stok_sayim_Load(object sender, EventArgs e)
        {
            lbl_ad_soyad.Text = SQL.ad + " " + SQL.soyad + " [" + DateTime.Now.ToShortDateString() + "]";

            DataTable dt = SQL.get("SELECT ust_kategori_adi = uk.kategori_adi, u.kategori_id, u.urun_id, u.urun_adi, olcu_birimi = p.deger, stok = ISNULL((SELECT SUM(uh.miktar) FROM urunler_hareket uh WHERE uh.silindi = 0 AND uh.urun_id = u.urun_id), 0.0000), sayim = ISNULL((SELECT SUM(uh.miktar) FROM urunler_hareket uh WHERE uh.silindi = 0 AND uh.urun_id = u.urun_id), 0.0000), fark = 0.0000 FROM urunler u INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN kategoriler k ON k.kategori_id = u.kategori_id INNER JOIN kategoriler uk ON uk.kategori_id = k.ust_kategori_id WHERE u.silindi = 0");
            grid_urunler.DataSource = dt;
        }

        private void gv_urunler_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            decimal stok, sayim, fark;

            DataRow dr = gv_urunler.GetDataRow(e.RowHandle);

            if(e.Column.FieldName == "sayim")
            {
                stok = Convert.ToDecimal(dr["stok"]);
                try { sayim = Convert.ToDecimal(e.Value); } catch { sayim = 0; }

                fark = sayim - stok;

                gv_urunler.SetRowCellValue(e.RowHandle, gv_urunler.Columns["fark"], fark);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            bool sayim_varmi = false;

            DataRow dr;
            for (int i = 0; i < gv_urunler.RowCount; i++)
            {
                dr = gv_urunler.GetDataRow(i);
                if(Convert.ToDecimal(dr["fark"]) != 0)
                {
                    sayim_varmi = true;
                    break;
                }
            }

            if(!sayim_varmi)
            {
                new mesaj("Sayımda fark bulunamadı!").ShowDialog();
                return;
            }

            DataTable dt_sayim = SQL.get("INSERT INTO urunler_stok_sayim (kaydeden_kullanici_id) VALUES (" + SQL.kullanici_id + "); SELECT SCOPE_IDENTITY()");
            for (int i = 0; i < gv_urunler.RowCount; i++)
            {
                dr = gv_urunler.GetDataRow(i);
                if (Convert.ToDecimal(dr["fark"]) != 0)
                {
                    SQL.set("INSERT INTO urunler_hareket (urun_id, hareket_tipi_parametre_id, miktar, referans_id, birim_fiyat) VALUES (" + dr["urun_id"] + ", 5, " + dr["fark"].ToString().Replace(',', '.') + ", " + dt_sayim.Rows[0][0] + ", 0.0000)");
                }
            }

            new mesaj("Sayımda Kaydedildi!").ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            urunler_stok_sayim_arsiv s = new urunler_stok_sayim_arsiv();
            s.ShowDialog();
        }
    }
}
