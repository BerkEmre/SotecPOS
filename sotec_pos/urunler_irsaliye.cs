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
    public partial class urunler_irsaliye : Form
    {
        int secili_irsaliye_id = 0;
        int kalem_adet = 0;
        int cari_id = 0;

        public urunler_irsaliye()
        {
            InitializeComponent();
        }

        private void urunler_irsaliye_Load(object sender, EventArgs e)
        {
            DataTable dt_cari = SQL.get("SELECT * FROM cariler WHERE [cari_tipi_parametre_id] IN (1, 43) AND silindi = 0"); if (dt_cari.Rows.Count <= 0)
            {
                new mesaj("Cari girmeden irsaliye giremezsiniz!").ShowDialog();
                this.Close();
                return;
            }
            cmb_cariler.Properties.DataSource = dt_cari;
            cmb_cariler.EditValue = dt_cari.Rows[0]["cari_id"];

            DataTable dt_irsaliye = SQL.get("SELECT i.irsaliye_no, i.irsaliye_id, i.kayit_tarihi, i.irsaliye_tarihi, kalem_adet = (SELECT COUNT(*) FROM urunler_irsaliye_kalem ik WHERE ik.silindi = 0 AND ik.irsaliye_id = i.irsaliye_id), c.cari_adi, c.cari_id FROM urunler_irsaliye i INNER JOIN cariler c ON c.cari_id = i.cari_id WHERE i.silindi = 0 ORDER by i.irsaliye_id DESC");
            grid_irsaliye.DataSource = dt_irsaliye;
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if(tb_no.Text.Length <= 0)
            {
                new mesaj("İrsaliye No Giriniz!").ShowDialog();
                return;
            }

            if (secili_irsaliye_id == 0)
                SQL.set("INSERT INTO urunler_irsaliye (kaydeden_kullanici_id, cari_id, irsaliye_tarihi, irsaliye_no, aciklama) VALUES (" + SQL.kullanici_id + ", " + cmb_cariler.EditValue + ", '" + dt_teslim_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', '" + tb_no.Text + "', '" + tb_aciklama.Text + "')");
            else
            {
                if(kalem_adet != 0)
                {
                    new mesaj("İrsaliyede kalem varken değiştirilemez!").ShowDialog();
                    return;
                }
                SQL.set("UPDATE urunler_irsaliye SET cari_id = " + cmb_cariler.EditValue + ", irsaliye_tarihi = '" + dt_teslim_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', irsaliye_no = '" + tb_no.Text + "', aciklama = '" + tb_aciklama.Text + "' WHERE irsaliye_id = " + secili_irsaliye_id);
            }

            DataTable dt_irsaliye = SQL.get("SELECT i.irsaliye_no, i.irsaliye_id, i.kayit_tarihi, i.irsaliye_tarihi, kalem_adet = (SELECT COUNT(*) FROM urunler_irsaliye_kalem ik WHERE ik.silindi = 0 AND ik.irsaliye_id = i.irsaliye_id), c.cari_adi, c.cari_id FROM urunler_irsaliye i INNER JOIN cariler c ON c.cari_id = i.cari_id WHERE i.silindi = 0 ORDER by i.irsaliye_id DESC");
            grid_irsaliye.DataSource = dt_irsaliye;
        }

        private void grid_irsaliye_Click(object sender, EventArgs e)
        {
            if (gv_irsaliye.SelectedRowsCount <= 0)
                return;

            if (!gv_irsaliye.IsDataRow(gv_irsaliye.GetSelectedRows()[0]))
                return;

            secili_irsaliye_id = Convert.ToInt32(gv_irsaliye.GetDataRow(gv_irsaliye.GetSelectedRows()[0])["irsaliye_id"]);
            kalem_adet = Convert.ToInt32(gv_irsaliye.GetDataRow(gv_irsaliye.GetSelectedRows()[0])["kalem_adet"]);
            cari_id = Convert.ToInt32(gv_irsaliye.GetDataRow(gv_irsaliye.GetSelectedRows()[0])["cari_id"]);
            btn_iptal.Visible = gb_irsaliye_kalem.Visible = true;
            btn_log_out.Text = "DÜZENLE";

            DataTable dt_ir = SQL.get("SELECT * FROM urunler_irsaliye WHERE irsaliye_id = " + secili_irsaliye_id);
            cmb_cariler.EditValue = dt_ir.Rows[0]["cari_id"];
            dt_teslim_tarihi.Value = Convert.ToDateTime(dt_ir.Rows[0]["irsaliye_tarihi"]);
            tb_no.Text = dt_ir.Rows[0]["irsaliye_no"].ToString();
            tb_aciklama.Text = dt_ir.Rows[0]["aciklama"].ToString();

            DataTable dt_siparis_kalem = SQL.get("SELECT s.siparis_id, sk.siparis_kalem_id, sk.urun_id, u.urun_adi, olcu_birimi = p.deger, sk.miktar, gelen_miktar = 0.0000, gelen_miktar1 = (SELECT SUM(miktar) FROM urunler_irsaliye_kalem ik WHERE ik.silindi = 0 AND ik.referans_siparis_kalem_id = sk.siparis_kalem_id) FROM urunler_siparis s INNER JOIN urunler_siparis_kalem sk ON sk.siparis_id = s.siparis_id AND sk.silindi = 0 AND sk.kapandi = 0 INNER JOIN urunler u ON u.urun_id = sk.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE s.silindi = 0 AND s.durum_parametre_id = 19 AND ISNULL((SELECT SUM(miktar) FROM urunler_irsaliye_kalem ik WHERE ik.silindi = 0 AND ik.referans_siparis_kalem_id = sk.siparis_kalem_id), 0.0000) < sk.miktar AND s.cari_id = " + cari_id);
            grid_irsaliye_kalem.DataSource = dt_siparis_kalem;

            DataTable dt_irsaliye_kalem = SQL.get("SELECT s.siparis_no, i.irsaliye_kalem_id, i.urun_id, u.urun_adi, i.miktar, i.referans_siparis_kalem_id, olcu_birimi = p.deger, fatura_kalem_id = ISNULL(fk.fatura_kalem_id, 0) FROM urunler_irsaliye_kalem i INNER JOIN urunler u ON u.urun_id = i.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = i.referans_siparis_kalem_id INNER JOIN urunler_siparis s ON s.siparis_id = sk.siparis_id LEFT OUTER JOIN urunler_fatura_kalem fk ON fk.silindi = 0 AND fk.referans_irsaliye_kalem_id = i.irsaliye_kalem_id WHERE i.silindi = 0 AND i.irsaliye_id = " + secili_irsaliye_id);
            grid_fatura_kalem.DataSource = dt_irsaliye_kalem;
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            secili_irsaliye_id = kalem_adet = cari_id = 0;
            btn_iptal.Visible = gb_irsaliye_kalem.Visible = false;
            btn_log_out.Text = "EKLE";
            tb_no.Text = "";
            tb_aciklama.Text = "";
        }

        private void grid_irsaliye_KeyDown(object sender, KeyEventArgs e)
        {
            if (gv_irsaliye.SelectedRowsCount <= 0)
                return;
            
            if (e.KeyCode == Keys.Delete)
            {
                if (kalem_adet != 0)
                {
                    new mesaj("İrsaliyede kalem varken silinemez!").ShowDialog();
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE urunler_irsaliye SET silindi = 1 WHERE irsaliye_id = " + gv_irsaliye.GetDataRow(gv_irsaliye.GetSelectedRows()[0])["irsaliye_id"].ToString());

                    DataTable dt_irsaliye = SQL.get("SELECT i.irsaliye_no, i.irsaliye_id, i.kayit_tarihi, i.irsaliye_tarihi, kalem_adet = (SELECT COUNT(*) FROM urunler_irsaliye_kalem ik WHERE ik.silindi = 0 AND ik.irsaliye_id = i.irsaliye_id), c.cari_adi, c.cari_id FROM urunler_irsaliye i INNER JOIN cariler c ON c.cari_id = i.cari_id WHERE i.silindi = 0 ORDER by i.irsaliye_id DESC");
                    grid_irsaliye.DataSource = dt_irsaliye;
                }
                gb_irsaliye_kalem.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_kalem_ekle_Click(object sender, EventArgs e)
        {
            if(gv_irsaliye_kalem.SelectedRowsCount <= 0)
            {
                new mesaj("Sipariş kalemi seçiniz!").ShowDialog();
                return;
            }

            DataRow dr;
            for (int i = 0; i < gv_irsaliye_kalem.SelectedRowsCount; i++)
            {
                dr = gv_irsaliye_kalem.GetDataRow(gv_irsaliye_kalem.GetSelectedRows()[i]);

                if(Convert.ToDecimal(dr["gelen_miktar"]) == 0)
                {
                    new mesaj("Gelen Miktar 0 olan sipariş kalemleri mevcut!").ShowDialog();
                    return;
                }
            }

            DataTable dt_ik;
            for (int i = 0; i < gv_irsaliye_kalem.SelectedRowsCount; i++)
            {
                dr = gv_irsaliye_kalem.GetDataRow(gv_irsaliye_kalem.GetSelectedRows()[i]);
                dt_ik = SQL.get("INSERT INTO urunler_irsaliye_kalem (urun_id, miktar, referans_siparis_kalem_id, irsaliye_id) VALUES (" + dr["urun_id"] + ", " + dr["gelen_miktar"].ToString().Replace(',', '.') + ", " + dr["siparis_kalem_id"] + ", " + secili_irsaliye_id + "); SELECT SCOPE_IDENTITY();");
                SQL.set("INSERT INTO urunler_hareket (urun_id, hareket_tipi_parametre_id, miktar, referans_id, birim_fiyat) VALUES (" + dr["urun_id"] + ", 4, " + dr["gelen_miktar"].ToString().Replace(',', '.') + ", " + dt_ik.Rows[0][0] + ", 0.0000)");
            }

            DataTable dt_siparis_kalem = SQL.get("SELECT s.siparis_id, sk.siparis_kalem_id, sk.urun_id, u.urun_adi, olcu_birimi = p.deger, sk.miktar, gelen_miktar = 0.0000, gelen_miktar1 = (SELECT SUM(miktar) FROM urunler_irsaliye_kalem ik WHERE ik.silindi = 0 AND ik.referans_siparis_kalem_id = sk.siparis_kalem_id) FROM urunler_siparis s INNER JOIN urunler_siparis_kalem sk ON sk.siparis_id = s.siparis_id AND sk.silindi = 0 AND sk.kapandi = 0 INNER JOIN urunler u ON u.urun_id = sk.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE s.silindi = 0 AND s.durum_parametre_id = 19 AND s.cari_id = " + cari_id);
            grid_irsaliye_kalem.DataSource = dt_siparis_kalem;
            DataTable dt_irsaliye_kalem = SQL.get("SELECT s.siparis_no, i.irsaliye_kalem_id, i.urun_id, u.urun_adi, i.miktar, i.referans_siparis_kalem_id, olcu_birimi = p.deger, fatura_kalem_id = ISNULL(fk.fatura_kalem_id, 0) FROM urunler_irsaliye_kalem i INNER JOIN urunler u ON u.urun_id = i.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = i.referans_siparis_kalem_id INNER JOIN urunler_siparis s ON s.siparis_id = sk.siparis_id LEFT OUTER JOIN urunler_fatura_kalem fk ON fk.silindi = 0 AND fk.referans_irsaliye_kalem_id = i.irsaliye_kalem_id WHERE i.silindi = 0 AND i.irsaliye_id = " + secili_irsaliye_id);
            grid_fatura_kalem.DataSource = dt_irsaliye_kalem;
        }

        private void grid_irsaliye_kalem_KeyDown(object sender, KeyEventArgs e)
        {
            if (gv_fatura_kalem.SelectedRowsCount <= 0)
                return;

            if(e.KeyCode == Keys.Delete)
            {
                DataRow dr = gv_fatura_kalem.GetDataRow(gv_fatura_kalem.GetSelectedRows()[0]);
                if(Convert.ToInt32(dr["fatura_kalem_id"]) != 0)
                {
                    new mesaj("Fatura girilmiş kalemleri silemezsiniz!").ShowDialog();
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE urunler_irsaliye_kalem SET silindi = 1 WHERE irsaliye_kalem_id = " + dr["irsaliye_kalem_id"]);
                    SQL.set("UPDATE urunler_hareket SET silindi = 1 WHERE hareket_tipi_parametre_id = 4 AND urun_id = " + dr["urun_id"] + " AND referans_id = " + dr["irsaliye_kalem_id"]);

                    DataTable dt_irsaliye_kalem = SQL.get("SELECT s.siparis_no, i.irsaliye_kalem_id, i.urun_id, u.urun_adi, i.miktar, i.referans_siparis_kalem_id, olcu_birimi = p.deger, fatura_kalem_id = ISNULL(fk.fatura_kalem_id, 0) FROM urunler_irsaliye_kalem i INNER JOIN urunler u ON u.urun_id = i.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = i.referans_siparis_kalem_id INNER JOIN urunler_siparis s ON s.siparis_id = sk.siparis_id LEFT OUTER JOIN urunler_fatura_kalem fk ON fk.silindi = 0 AND fk.referans_irsaliye_kalem_id = i.irsaliye_kalem_id WHERE i.silindi = 0 AND i.irsaliye_id = " + secili_irsaliye_id);
                    grid_fatura_kalem.DataSource = dt_irsaliye_kalem;
                }
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (gv_fatura_kalem.SelectedRowsCount <= 0)
                return;

            DataRow dr = gv_fatura_kalem.GetDataRow(gv_fatura_kalem.GetSelectedRows()[0]);
            if (Convert.ToInt32(dr["fatura_kalem_id"]) != 0)
            {
                new mesaj("Fatura girilmiş kalemleri silemezsiniz!").ShowDialog();
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SQL.set("UPDATE urunler_irsaliye_kalem SET silindi = 1 WHERE irsaliye_kalem_id = " + dr["irsaliye_kalem_id"]);
                SQL.set("UPDATE urunler_hareket SET silindi = 1 WHERE hareket_tipi_parametre_id = 4 AND urun_id = " + dr["urun_id"] + " AND referans_id = " + dr["irsaliye_kalem_id"]);

                DataTable dt_irsaliye_kalem = SQL.get("SELECT s.siparis_no, i.irsaliye_kalem_id, i.urun_id, u.urun_adi, i.miktar, i.referans_siparis_kalem_id, olcu_birimi = p.deger, fatura_kalem_id = ISNULL(fk.fatura_kalem_id, 0) FROM urunler_irsaliye_kalem i INNER JOIN urunler u ON u.urun_id = i.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = i.referans_siparis_kalem_id INNER JOIN urunler_siparis s ON s.siparis_id = sk.siparis_id LEFT OUTER JOIN urunler_fatura_kalem fk ON fk.silindi = 0 AND fk.referans_irsaliye_kalem_id = i.irsaliye_kalem_id WHERE i.silindi = 0 AND i.irsaliye_id = " + secili_irsaliye_id);
                grid_fatura_kalem.DataSource = dt_irsaliye_kalem;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gv_irsaliye.SelectedRowsCount <= 0)
                return;

            rp_irsaliye s = new rp_irsaliye(Convert.ToInt32(gv_irsaliye.GetDataRow(gv_irsaliye.GetSelectedRows()[0])["irsaliye_id"].ToString()));
            s.CreateDocument();
            disa_aktar d = new disa_aktar();
            d.rp_viewer.DocumentSource = s;
            d.ShowDialog();
        }
    }
}
