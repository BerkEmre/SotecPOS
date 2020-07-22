using DevExpress.XtraGrid.Views.Tile;
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
    public partial class pos_masa_sicak_satis : Form
    {
        int secili_urun_id, adisyon_id, menu_id = 0;
        decimal secili_miktar, fiyat;
        public pos_masa_sicak_satis(int secili_urun_id, int adisyon_id, decimal secili_miktar, int menu_id, decimal fiyat)
        {
            this.secili_urun_id = secili_urun_id;
            this.adisyon_id = adisyon_id;
            this.secili_miktar = secili_miktar;
            this.menu_id = menu_id;
            this.fiyat = fiyat;

            InitializeComponent();
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pos_masa_sicak_satis_Load(object sender, EventArgs e)
        {
            DataTable dt_recete = SQL.get("SELECT u.urun_id, u.urun_adi, ur.miktar, olcu_birimi = p.deger, secim = 1 FROM urunler_recete ur INNER JOIN urunler u ON u.urun_id = ur.recete_urunu_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE ur.silindi = 0 AND ur.receteli_urun_id = " + secili_urun_id);
            grid_masalar.DataSource = dt_recete;
        }

        private void pos_masa_sicak_satis_Click(object sender, EventArgs e)
        {
            
        }

        private void grid_masalar_Click(object sender, EventArgs e)
        {
            int secim = Convert.ToInt32(tv_masalar.GetFocusedRowCellValue("secim"));
            tv_masalar.SetFocusedRowCellValue("secim", (secim == 1 ? 0 : 1));
        }

        private void btn_adisyona_ekle_Click(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("INSERT INTO adisyon_kalem (adisyon_id, urun_id, miktar, kaydeden_kullanici_id, menu_id, fiyat) VALUES (" + adisyon_id + ", " + secili_urun_id + ", " + secili_miktar.ToString().Replace(',', '.') + ", " + SQL.kullanici_id + ", " + menu_id + ", " + fiyat.ToString().Replace(',', '.') + "); SELECT SCOPE_IDENTITY();");
            SQL.set("INSERT INTO urunler_hareket (urun_id, hareket_tipi_parametre_id, miktar, referans_id, birim_fiyat) VALUES (" + secili_urun_id + ", 3, " + (secili_miktar * -1).ToString().Replace(',', '.') + ", " + adisyon_id + ", 0.0000)");

            DataRow dr;
            for (int i = 0; i < tv_masalar.RowCount; i++)
            {
                dr = tv_masalar.GetDataRow(i);
                if(dr["secim"].ToString() == "1")
                    SQL.set("INSERT INTO urunler_hareket (urun_id, hareket_tipi_parametre_id, miktar, referans_id, birim_fiyat) VALUES (" + dr["urun_id"] + ", 62, " + (secili_miktar * Convert.ToDecimal(dr["miktar"]) * -1).ToString().Replace(',', '.') + ", " + dt.Rows[0][0] + ", 0.0000)");
            }

            this.Close();
        }
    }
}
