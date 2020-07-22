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
    public partial class pos_masa_menu_urun_sec : Form
    {
        int menu_id = 0, urun_grubu_id = 0, adisyon_id = 0;
        decimal fiyat = 0;

        public pos_masa_menu_urun_sec(int menu_id, int urun_grubu_id, int adisyon_id, decimal fiyat)
        {
            this.menu_id = menu_id;
            this.urun_grubu_id = urun_grubu_id;
            this.adisyon_id = adisyon_id;
            this.fiyat = fiyat;

            InitializeComponent();
        }

        private void tv_urun_ItemDoubleClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            if (tv_urun.SelectedRowsCount <= 0)
                return;

            DataRow dr = tv_urun.GetFocusedDataRow();
            int urun_id = Convert.ToInt32(dr["urun_id"]);
            int sicak_satis = Convert.ToInt32(dr["sicak_satis"]);
            if (sicak_satis == 1)
            {
                pos_masa_sicak_satis dlg = new pos_masa_sicak_satis(urun_id, adisyon_id, 1, menu_id, fiyat);
                dlg.ShowDialog();
            }
            else
            {
                SQL.set("INSERT INTO adisyon_kalem (adisyon_id, urun_id, miktar, kaydeden_kullanici_id, menu_id, fiyat) VALUES (" + adisyon_id + ", " + urun_id + ", 1, " + SQL.kullanici_id + ", " + menu_id + ", " + fiyat.ToString().Replace(',', '.') + ")");
                SQL.set("INSERT INTO urunler_hareket (urun_id, hareket_tipi_parametre_id, miktar, referans_id, birim_fiyat) VALUES (" + urun_id + ", 3, -1, " + adisyon_id + ", 0.0000)");
            }

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pos_masa_menu_urun_sec_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT * FROM urun_gruplari WHERE urun_grubu_id = " + urun_grubu_id);
            lbl_urun_grubu.Text = dt.Rows[0]["urun_grubu"].ToString();

            DataTable dt_urun = SQL.get("SELECT u.urun_adi, u.urun_id, u.fiyat, u.sira, u.sicak_satis FROM urun_grubu_urunleri ugu INNER JOIN urunler u ON u.urun_id = ugu.urun_id AND u.silindi = 0 WHERE ugu.silindi = 0 AND ugu.urun_grubu_id = " + urun_grubu_id + " ORDER by u.sira");
            grid_urun.DataSource = dt_urun;
        }
    }
}
