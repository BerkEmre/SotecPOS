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
    public partial class urunler_stok_sayim_arsiv : Form
    {
        public urunler_stok_sayim_arsiv()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void urunler_stok_sayim_arsiv_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT ss.stok_sayim_id, ss.kayit_tarihi, personel = k.ad + ' ' + k.soyad FROM urunler_stok_sayim ss INNER JOIN kullanicilar k ON k.kullanici_id = ss.kaydeden_kullanici_id WHERE ss.silindi = 0");
            gridControl1.DataSource = dt;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount <= 0)
                return;

            DataTable dt = SQL.get("SELECT uh.urun_id, u.urun_adi, uh.miktar, olcu_birimi = p.deger FROM urunler_hareket uh INNER JOIN urunler u ON u.urun_id = uh.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE uh.silindi = 0 AND uh.hareket_tipi_parametre_id = 5 AND uh.referans_id = " + gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["stok_sayim_id"]);
            grid_urunler.DataSource = dt;
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.SelectedRowsCount <= 0)
                return;

            if (e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE urunler_stok_sayim SET silindi = 1 WHERE stok_sayim_id = " + gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["stok_sayim_id"].ToString());
                    SQL.set("UPDATE urunler_hareket SET silindi = 1 WHERE hareket_tipi_parametre_id = 5 AND referans_id = " + gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["stok_sayim_id"].ToString());

                    DataTable dt = SQL.get("SELECT ss.stok_sayim_id, ss.kayit_tarihi, personel = k.ad + ' ' + k.soyad FROM urunler_stok_sayim ss INNER JOIN kullanicilar k ON k.kullanici_id = ss.kaydeden_kullanici_id WHERE ss.silindi = 0");
                    gridControl1.DataSource = dt;
                }
            }
        }
    }
}
