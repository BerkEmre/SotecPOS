using DevExpress.XtraGrid.Views.Grid;
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
    public partial class urunler : Form
    {
        public urunler()
        {
            InitializeComponent();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(8))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            kategori k = new kategori();
            k.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(9))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            urun_ekle_duzenle u = new urun_ekle_duzenle(0);
            u.FormClosing += U_FormClosing;
            u.ShowDialog();
        }

        private void U_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt = SQL.get("SELECT u.sira, u.menu_aktif, u.stok_kodu, u.urun_id, u.urun_adi, resim = 'urun_resimleri/' + u.resim, olcu_birimi = p.deger, u.fiyat, k.kategori_adi, ust_kategori_adi = uk.kategori_adi, stok = ISNULL((SELECT SUM(uh.miktar) FROM urunler_hareket uh WHERE uh.silindi = 0 AND uh.urun_id = u.urun_id), 0.0000) FROM urunler u INNER JOIN kategoriler k ON k.kategori_id = u.kategori_id INNER JOIN kategoriler uk ON uk.kategori_id = k.ust_kategori_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE u.silindi = 0 ORDER by uk.kategori_adi, k.kategori_adi, u.urun_adi");
            grid_urunler.DataSource = dt;
        }

        private void urunler_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT u.sira, u.menu_aktif, u.stok_kodu, u.urun_id, u.urun_adi, resim = 'urun_resimleri/' + u.resim, olcu_birimi = p.deger, u.fiyat, k.kategori_adi, ust_kategori_adi = uk.kategori_adi, stok = ISNULL((SELECT SUM(uh.miktar) FROM urunler_hareket uh WHERE uh.silindi = 0 AND uh.urun_id = u.urun_id), 0.0000) FROM urunler u INNER JOIN kategoriler k ON k.kategori_id = u.kategori_id INNER JOIN kategoriler uk ON uk.kategori_id = k.ust_kategori_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE u.silindi = 0 ORDER by uk.kategori_adi, k.kategori_adi, u.urun_adi");
            grid_urunler.DataSource = dt;
        }

        Dictionary<int, Image> storage = new Dictionary<int, Image>();
        private void gv_urunler_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "resim")
            {
                if (e.IsGetData)
                    if (storage.ContainsKey(e.ListSourceRowIndex))
                        e.Value = storage[e.ListSourceRowIndex];
                    else
                    {
                        GridView view = sender as GridView;
                        e.Value = storage[e.ListSourceRowIndex] = Image.FromFile(view.GetDataRow(e.ListSourceRowIndex)["resim"].ToString());
                    }
                if (e.IsSetData)
                    storage[e.ListSourceRowIndex] = (Image)e.Value;
            }
        }

        private void grid_urunler_DoubleClick(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(9))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            if (gv_urunler.SelectedRowsCount <= 0)
                return;

            urun_ekle_duzenle u = new urun_ekle_duzenle(Convert.ToInt32(gv_urunler.GetDataRow(gv_urunler.GetSelectedRows()[0])["urun_id"]));
            u.FormClosing += U_FormClosing;
            u.ShowDialog();
        }

        private void grid_urunler_KeyDown(object sender, KeyEventArgs e)
        {
            if (!SQL.yetki_kontrol(9))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            if (gv_urunler.SelectedRowsCount <= 0)
                return;

            if(e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE urunler SET silindi = 1 WHERE urun_id = " + gv_urunler.GetDataRow(gv_urunler.GetSelectedRows()[0])["urun_id"].ToString());
                    DataTable dt = SQL.get("SELECT u.sira, u.menu_aktif, u.urun_id, u.urun_adi, resim = 'urun_resimleri/' + u.resim, olcu_birimi = p.deger, u.fiyat, k.kategori_adi, ust_kategori_adi = uk.kategori_adi, stok = ISNULL((SELECT SUM(uh.miktar) FROM urunler_hareket uh WHERE uh.silindi = 0 AND uh.urun_id = u.urun_id), 0.0000) FROM urunler u INNER JOIN kategoriler k ON k.kategori_id = u.kategori_id INNER JOIN kategoriler uk ON uk.kategori_id = k.ust_kategori_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE u.silindi = 0 ORDER by uk.kategori_adi, k.kategori_adi, u.urun_adi");
                    grid_urunler.DataSource = dt;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(10))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            urunler_receteli_uretim r = new urunler_receteli_uretim();
            r.FormClosing += U_FormClosing;
            r.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(12))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            urunler_stok_sayim s = new urunler_stok_sayim();
            s.FormClosing += U_FormClosing;
            s.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            urunler_siparis s = new urunler_siparis();
            s.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            urunler_irsaliye i = new urunler_irsaliye();
            i.FormClosing += U_FormClosing;
            i.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(11))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            urunler_receteli_uretimler u = new urunler_receteli_uretimler();
            u.FormClosing += U_FormClosing;
            u.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            urun_menu i = new urun_menu();
            i.FormClosing += U_FormClosing;
            i.ShowDialog();
        }
    }
}
