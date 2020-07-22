using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sotec_pos
{
    public partial class urun_menu: Form
    {
        int secili_urun_grubu_id = 0, secili_menu_id = 0;

        public urun_menu()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            tb_urun_grubu.Text = tb_menu.Text = "";
            tb_iskonto_2.Value = 0;

            DataTable dt_urun_gruplari = SQL.get("SELECT * FROM urun_gruplari WHERE silindi = 0");
            grid_urun_gruplari.DataSource = dt_urun_gruplari;
            cmb_urun_grubu.Properties.DataSource = dt_urun_gruplari;

            DataTable dt_menu = SQL.get("SELECT * FROM menuler WHERE silindi = 0");
            grid_menu.DataSource = dt_menu;
        }

        private void urun_menu_Load(object sender, EventArgs e)
        {
            loadData();

            DataTable dt_urunler = SQL.get("SELECT * FROM urunler WHERE silindi = 0 AND menu_aktif = 1");
            cmb_urun.Properties.DataSource = dt_urunler;

            if(dt_urunler.Rows.Count <= 0)
            {
                new mesaj("Önce ürün giriniz!").ShowDialog();
                this.Close();
            }
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if(tb_urun_grubu.Text.Length <= 0)
            {
                new mesaj("Ürün grubu giriniz!").ShowDialog();
                return;
            }

            SQL.set("INSERT INTO urun_gruplari (kaydeden_kullanici_id, urun_grubu) VALUES (" + SQL.kullanici_id + ", '" + tb_urun_grubu.Text + "')");
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(secili_urun_grubu_id == 0)
            {
                new mesaj("Ürün grubu seçiniz!").ShowDialog();
                return;
            }
            if (cmb_urun.EditValue == null)
            {
                new mesaj("Ürün seçiniz!").ShowDialog();
                return;
            }

            DataTable dt = SQL.get("SELECT * FROM urun_grubu_urunleri WHERE silindi = 0 AND urun_grubu_id = " + secili_urun_grubu_id + " AND urun_id = " + cmb_urun.EditValue);
            if (dt.Rows.Count > 0)
            {
                new mesaj("Bu ürün daha önce eklenmiş!").ShowDialog();
                return;
            }

            SQL.set("INSERT INTO urun_grubu_urunleri (kaydeden_kullanici_id, urun_grubu_id, urun_id) VALUES (" + SQL.kullanici_id + ", " + secili_urun_grubu_id + ", " + cmb_urun.EditValue + ")"); 
            
            DataTable dt_urun_grubu_urunler = SQL.get("SELECT ugu.urun_grubu_urun_id, u.urun_adi, u.urun_id FROM urun_grubu_urunleri ugu INNER JOIN urunler u ON u.urun_id = ugu.urun_id WHERE ugu.silindi = 0 AND ugu.urun_grubu_id = " + secili_urun_grubu_id);
            grid_urunler.DataSource = dt_urun_grubu_urunler;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tb_menu.Text.Length <= 0)
            {
                new mesaj("Menü giriniz!").ShowDialog();
                return;
            }

            SQL.set("INSERT INTO menuler (kaydeden_kullanici_id, menu, fiyat) VALUES (" + SQL.kullanici_id + ", '" + tb_menu.Text + "', " + tb_iskonto_2.Value.ToString().Replace(',', '.') + ")");
            loadData();
        }

        private void gv_menu_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gv_menu.SelectedRowsCount <= 0)
                return;

            secili_menu_id = Convert.ToInt32(gv_menu.GetDataRow(gv_menu.GetSelectedRows()[0])["menu_id"]);

            DataTable dt_menu_urun_gruplari = SQL.get("SELECT mug.menu_urun_grubu_id, ug.urun_grubu, ug.urun_grubu_id, mug.miktar FROM menu_urun_gruplari mug INNER JOIN urun_gruplari ug ON ug.urun_grubu_id = mug.urun_grubu_id AND ug.silindi = 0 WHERE mug.silindi = 0 AND mug.menu_id = " + secili_menu_id);
            grid_menu_urun_grubu.DataSource = dt_menu_urun_gruplari;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (secili_menu_id == 0)
            {
                new mesaj("Menü seçiniz!").ShowDialog();
                return;
            }
            if (tb_miktar.Value <= 0)
            {
                new mesaj("Miktar giriniz!").ShowDialog();
                return;
            }
            if (cmb_urun_grubu.EditValue == null)
            {
                new mesaj("Ürün grubu seçiniz!").ShowDialog();
                return;
            }

            DataTable dt = SQL.get("SELECT * FROM menu_urun_gruplari WHERE silindi = 0 AND menu_id = " + secili_menu_id + " AND urun_grubu_id = " + cmb_urun_grubu.EditValue);
            if (dt.Rows.Count > 0)
            {
                new mesaj("Bu ürün grubu daha önce eklenmiş!").ShowDialog();
                return;
            }

            SQL.set("INSERT INTO menu_urun_gruplari (kaydeden_kullanici_id, urun_grubu_id, menu_id, miktar) VALUES (" + SQL.kullanici_id + ", " + cmb_urun_grubu.EditValue + ", " + secili_menu_id + ", " + tb_miktar.Value + ")");

            DataTable dt_menu_urun_gruplari = SQL.get("SELECT mug.menu_urun_grubu_id, ug.urun_grubu, ug.urun_grubu_id, mug.miktar FROM menu_urun_gruplari mug INNER JOIN urun_gruplari ug ON ug.urun_grubu_id = mug.urun_grubu_id AND ug.silindi = 0 WHERE mug.silindi = 0 AND mug.menu_id = " + secili_menu_id);
            grid_menu_urun_grubu.DataSource = dt_menu_urun_gruplari;
        }

        private void grid_urun_gruplari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (secili_urun_grubu_id == 0)
                {
                    new mesaj("Ürün grubu seçiniz!").ShowDialog();
                    return;
                }

                SQL.set("UPDATE urun_gruplari SET silindi = 1, guncelleyen_kullanici_id = " + SQL.kullanici_id + ", guncelleme_tarihi = GETDATE() WHERE urun_grubu_id = " + secili_urun_grubu_id);

                loadData();
            }
        }

        private void grid_urunler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int secili_urun_grubu_urun_id = Convert.ToInt32(gv_urunler.GetDataRow(gv_urunler.GetSelectedRows()[0])["urun_grubu_urun_id"]);

                if (secili_urun_grubu_urun_id == 0)
                {
                    new mesaj("Ürün seçiniz!").ShowDialog();
                    return;
                }

                SQL.set("UPDATE urun_grubu_urunleri SET silindi = 1, guncelleyen_kullanici_id = " + SQL.kullanici_id + ", guncelleme_tarihi = GETDATE() WHERE urun_grubu_urun_id = " + secili_urun_grubu_urun_id);

                DataTable dt_urun_grubu_urunler = SQL.get("SELECT ugu.urun_grubu_urun_id, u.urun_adi, u.urun_id FROM urun_grubu_urunleri ugu INNER JOIN urunler u ON u.urun_id = ugu.urun_id WHERE ugu.silindi = 0 AND ugu.urun_grubu_id = " + secili_urun_grubu_id);
                grid_urunler.DataSource = dt_urun_grubu_urunler;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void grid_menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (secili_menu_id == 0)
                {
                    new mesaj("Menü seçiniz!").ShowDialog();
                    return;
                }

                SQL.set("UPDATE menuler SET silindi = 1, guncelleyen_kullanici_id = " + SQL.kullanici_id + ", guncelleme_tarihi = GETDATE() WHERE menu_id = " + secili_menu_id);

                loadData();
            }
        }

        private void grid_menu_urun_grubu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int secili_menu_urun_grubu_id = Convert.ToInt32(gv_menu_urun_grubu.GetDataRow(gv_menu_urun_grubu.GetSelectedRows()[0])["menu_urun_grubu_id"]);

                if (secili_menu_urun_grubu_id == 0)
                {
                    new mesaj("Ürün grubu seçiniz!").ShowDialog();
                    return;
                }

                SQL.set("UPDATE menu_urun_gruplari SET silindi = 1, guncelleyen_kullanici_id = " + SQL.kullanici_id + ", guncelleme_tarihi = GETDATE() WHERE menu_urun_grubu_id = " + secili_menu_urun_grubu_id);

                DataTable dt_menu_urun_gruplari = SQL.get("SELECT mug.menu_urun_grubu_id, ug.urun_grubu, ug.urun_grubu_id, mug.miktar FROM menu_urun_gruplari mug INNER JOIN urun_gruplari ug ON ug.urun_grubu_id = mug.urun_grubu_id AND ug.silindi = 0 WHERE mug.silindi = 0 AND mug.menu_id = " + secili_menu_id);
                grid_menu_urun_grubu.DataSource = dt_menu_urun_gruplari;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gv_urun_gruplari_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gv_urun_gruplari.SelectedRowsCount <= 0)
                return;

            secili_urun_grubu_id = Convert.ToInt32(gv_urun_gruplari.GetDataRow(gv_urun_gruplari.GetSelectedRows()[0])["urun_grubu_id"]);

            DataTable dt_urun_grubu_urunler = SQL.get("SELECT ugu.urun_grubu_urun_id, u.urun_adi, u.urun_id FROM urun_grubu_urunleri ugu INNER JOIN urunler u ON u.urun_id = ugu.urun_id WHERE ugu.silindi = 0 AND ugu.urun_grubu_id = " + secili_urun_grubu_id);
            grid_urunler.DataSource = dt_urun_grubu_urunler;
        }
    }
}
