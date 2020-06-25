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
    public partial class urunler_siparis : Form
    {
        int secili_siparis_id = 0, durum_parametre_id = 0;

        public urunler_siparis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if (secili_siparis_id == 0)
                SQL.set("INSERT INTO urunler_siparis (kaydeden_kullanici_id, cari_id, tahmini_teslim_tarihi, durum_parametre_id, siparis_no, aciklama) VALUES (" + SQL.kullanici_id + ", " + cmb_cariler.EditValue + ", '" + dt_teslim_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', 18, '" + tb_no.Text + "', '" + tb_aciklama.Text + "')");
            else
                SQL.set("UPDATE urunler_siparis SET cari_id = " + cmb_cariler.EditValue + ", tahmini_teslim_tarihi = '" + dt_teslim_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', siparis_no = '" + tb_no.Text + "', aciklama = '" + tb_aciklama.Text + "' WHERE siparis_id = " + secili_siparis_id);

            DataTable dt_siparisler = SQL.get("SELECT s.siparis_id, durum = p.deger, s.tahmini_teslim_tarihi, s.kayit_tarihi, c.cari_adi, s.durum_parametre_id FROM urunler_siparis s INNER JOIN parametreler p ON p.parametre_id = s.durum_parametre_id INNER JOIN cariler c ON c.cari_id = s.cari_id WHERE s.silindi = 0 AND s.durum_parametre_id <> 20 ORDER by s.siparis_id DESC");
            grid_siparis.DataSource = dt_siparisler;
        }

        private void urunler_siparis_Load(object sender, EventArgs e)
        {
            DataTable dt_cari = SQL.get("SELECT * FROM cariler WHERE [cari_tipi_parametre_id] IN (1, 43) AND silindi = 0");

            if(dt_cari.Rows.Count <= 0)
            {
                new mesaj("Cari girmeden sipariş giremezsiniz!").ShowDialog();
                this.Close();
                return;
            }

            cmb_cariler.Properties.DataSource = dt_cari;
            cmb_cariler.EditValue = dt_cari.Rows[0]["cari_id"];

            DataTable dt_urunler = SQL.get("SELECT u.urun_id, u.urun_adi, olcu_birimi = p.deger FROM urunler u INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE u.silindi = 0 AND u.receteli_urun = 0");
            if(dt_urunler.Rows.Count <= 0)
            {
                new mesaj("Sipariş girilecek ürün bulunamadı!").ShowDialog();
                this.Close();
                return;
            }
            cmb_urun.Properties.DataSource = dt_urunler;
            cmb_urun.EditValue = dt_urunler.Rows[0]["urun_id"];

            DataTable dt_siparisler = SQL.get("SELECT s.siparis_id, durum = p.deger, s.tahmini_teslim_tarihi, s.kayit_tarihi, c.cari_adi, s.durum_parametre_id FROM urunler_siparis s INNER JOIN parametreler p ON p.parametre_id = s.durum_parametre_id INNER JOIN cariler c ON c.cari_id = s.cari_id WHERE s.silindi = 0 ORDER by s.siparis_id DESC");
            grid_siparis.DataSource = dt_siparisler;
        }

        private void grid_siparis_Click(object sender, EventArgs e)
        {
            if (gv_siparis.SelectedRowsCount <= 0)
                return;

            if (!gv_siparis.IsDataRow(gv_siparis.GetSelectedRows()[0]))
                return;

            secili_siparis_id = Convert.ToInt32(gv_siparis.GetDataRow(gv_siparis.GetSelectedRows()[0])["siparis_id"]);
            durum_parametre_id = Convert.ToInt32(gv_siparis.GetDataRow(gv_siparis.GetSelectedRows()[0])["durum_parametre_id"]);
            btn_iptal.Visible = gb_sipais_kalem.Visible = true;
            gb_sipais_kalem.Text = "Sipariş Kalem (" + secili_siparis_id + ")";
            btn_log_out.Text = "DÜZENLE";

            DataTable dt_sip = SQL.get("SELECT * FROM urunler_siparis WHERE siparis_id = " + secili_siparis_id);
            cmb_cariler.EditValue = dt_sip.Rows[0]["cari_id"];
            dt_teslim_tarihi.Value = Convert.ToDateTime(dt_sip.Rows[0]["tahmini_teslim_tarihi"]);
            tb_no.Text = dt_sip.Rows[0]["siparis_no"].ToString();
            tb_aciklama.Text = dt_sip.Rows[0]["aciklama"].ToString();

            switch (durum_parametre_id)
            {
                case 18:
                    btn_durum_degistir.Text = "TEDARİKÇİYE GÖNDER";
                    btn_siparisi_geri_cek.Text = "KAYDET";
                    btn_kalem_ekle.Visible = true;
                    btn_kalem_kapat.Visible = false;
                    break;
                case 19:
                    btn_durum_degistir.Text = "SİPARİŞİ KAPAT";
                    btn_siparisi_geri_cek.Text = "GERİ ÇEK";
                    btn_kalem_ekle.Visible = false;
                    btn_kalem_kapat.Visible = true;
                    break;
                case 20:
                    btn_durum_degistir.Text = "SİPARİŞİ AÇ";
                    btn_siparisi_geri_cek.Text = "GERİ ÇEK";
                    btn_kalem_ekle.Visible = false;
                    btn_kalem_kapat.Visible = true;
                    break;
            }

            DataTable dt_siparis_kalem = SQL.get("SELECT sk.siparis_kalem_id, sk.urun_id, u.urun_adi, olcu_birimi = p.deger, sk.miktar, sk.kapandi, sk.birim_fiyat, sk.iskonto_1, sk.iskonto_2, u.kdv, gelen_miktar = (SELECT SUM(miktar) FROM urunler_irsaliye_kalem ik WHERE ik.silindi = 0 AND ik.referans_siparis_kalem_id = sk.siparis_kalem_id), " +
                " net_toplam = sk.miktar * (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)), " +
                " net_birim_fiyat = (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)) " +
                " FROM urunler_siparis_kalem sk INNER JOIN urunler u ON u.urun_id = sk.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE sk.silindi = 0 AND sk.siparis_id = " + secili_siparis_id);
            grid_siparis_kalem.DataSource = dt_siparis_kalem;
        }

        private void btn_kalem_ekle_Click(object sender, EventArgs e)
        {
            if(tb_miktar.Value <= 0)
            {
                new mesaj("Miktar giriniz!").ShowDialog();
                return;
            }

            SQL.set("INSERT INTO urunler_siparis_kalem (siparis_id, urun_id, miktar, birim_fiyat, iskonto_1, iskonto_2) VALUES (" + secili_siparis_id + ", " + cmb_urun.EditValue + ", " + tb_miktar.Value.ToString().Replace(',', '.') + ", " + tb_birim_fiyat.Value.ToString().Replace(',', '.') + ",  " + tb_iskonto_1.Value.ToString().Replace(',', '.') + ", " + tb_iskonto_2.Value.ToString().Replace(',', '.') + ")");

            DataTable dt_siparis_kalem = SQL.get("SELECT sk.siparis_kalem_id, sk.urun_id, u.urun_adi, olcu_birimi = p.deger, sk.miktar, sk.kapandi, sk.birim_fiyat, sk.iskonto_1, sk.iskonto_2, u.kdv, gelen_miktar = (SELECT SUM(miktar) FROM urunler_irsaliye_kalem ik WHERE ik.silindi = 0 AND ik.referans_siparis_kalem_id = sk.siparis_kalem_id), " +
                " net_toplam = sk.miktar * (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)) " +
                " FROM urunler_siparis_kalem sk INNER JOIN urunler u ON u.urun_id = sk.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE sk.silindi = 0 AND sk.siparis_id = " + secili_siparis_id);
            grid_siparis_kalem.DataSource = dt_siparis_kalem;

            tb_iskonto_1.Value = tb_iskonto_2.Value = tb_miktar.Value = 0;
        }

        private void btn_durum_degistir_Click(object sender, EventArgs e)
        {
            if (durum_parametre_id == 18)
                SQL.set("UPDATE urunler_siparis SET durum_parametre_id = 19 WHERE siparis_id = " + secili_siparis_id);
            else if (durum_parametre_id == 19)
                SQL.set("UPDATE urunler_siparis SET durum_parametre_id = 20 WHERE siparis_id = " + secili_siparis_id);
            else if (durum_parametre_id == 20)
                SQL.set("UPDATE urunler_siparis SET durum_parametre_id = 19 WHERE siparis_id = " + secili_siparis_id);

            DataTable dt_siparisler = SQL.get("SELECT s.siparis_id, durum = p.deger, s.tahmini_teslim_tarihi, s.kayit_tarihi, c.cari_adi, s.durum_parametre_id FROM urunler_siparis s INNER JOIN parametreler p ON p.parametre_id = s.durum_parametre_id INNER JOIN cariler c ON c.cari_id = s.cari_id WHERE s.silindi = 0 ORDER by s.siparis_id DESC");
            grid_siparis.DataSource = dt_siparisler;

            secili_siparis_id = 0;
            btn_iptal.Visible = gb_sipais_kalem.Visible = false;
            btn_log_out.Text = "EKLE";
        }

        private void cmb_urun_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT * FROM urunler WHERE urun_id = " + cmb_urun.EditValue);
            tb_birim_fiyat.Value = Convert.ToDecimal(dt.Rows[0]["alis_fiyat"]);
        }

        private void grid_siparis_kalem_KeyDown(object sender, KeyEventArgs e)
        {
            if (gv_siapris_kalem.SelectedRowsCount <= 0)
                return;

            if (durum_parametre_id != 18)
                return;

            if (e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE urunler_siparis_kalem SET silindi = 1 WHERE siparis_kalem_id = " + gv_siapris_kalem.GetDataRow(gv_siapris_kalem.GetSelectedRows()[0])["siparis_kalem_id"].ToString());

                    DataTable dt_siparis_kalem = SQL.get("SELECT sk.siparis_kalem_id, sk.urun_id, u.urun_adi, olcu_birimi = p.deger, sk.miktar, sk.kapandi, sk.birim_fiyat, sk.iskonto_1, sk.iskonto_2, u.kdv, gelen_miktar = (SELECT SUM(miktar) FROM urunler_irsaliye_kalem ik WHERE ik.silindi = 0 AND ik.referans_siparis_kalem_id = sk.siparis_kalem_id), " +
                        " net_toplam = sk.miktar * (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)), " +
                " net_birim_fiyat = (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)) " +
                        " FROM urunler_siparis_kalem sk INNER JOIN urunler u ON u.urun_id = sk.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE sk.silindi = 0 AND sk.siparis_id = " + secili_siparis_id);
                    grid_siparis_kalem.DataSource = dt_siparis_kalem;
                }
            }
        }

        private void btn_kalem_kapat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gv_siapris_kalem.SelectedRowsCount; i++)
            {
                if (!gv_siapris_kalem.IsDataRow(gv_siapris_kalem.GetSelectedRows()[0]))
                    continue;

                if(Convert.ToInt32(gv_siapris_kalem.GetDataRow(gv_siapris_kalem.GetSelectedRows()[i])["kapandi"]) == 0)
                    SQL.set("UPDATE urunler_siparis_kalem SET kapandi = 1 WHERE siparis_kalem_id = " + gv_siapris_kalem.GetDataRow(gv_siapris_kalem.GetSelectedRows()[i])["siparis_kalem_id"]);
                else
                    SQL.set("UPDATE urunler_siparis_kalem SET kapandi = 0 WHERE siparis_kalem_id = " + gv_siapris_kalem.GetDataRow(gv_siapris_kalem.GetSelectedRows()[i])["siparis_kalem_id"]);
            }

            DataTable dt_siparis_kalem = SQL.get("SELECT sk.siparis_kalem_id, sk.urun_id, u.urun_adi, olcu_birimi = p.deger, sk.miktar, sk.kapandi, sk.birim_fiyat, sk.iskonto_1, sk.iskonto_2, u.kdv, gelen_miktar = (SELECT SUM(miktar) FROM urunler_irsaliye_kalem ik WHERE ik.silindi = 0 AND ik.referans_siparis_kalem_id = sk.siparis_kalem_id), " +
                " net_toplam = sk.miktar * (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)), " +
                " net_birim_fiyat = (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)) " +
                " FROM urunler_siparis_kalem sk INNER JOIN urunler u ON u.urun_id = sk.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE sk.silindi = 0 AND sk.siparis_id = " + secili_siparis_id);
            grid_siparis_kalem.DataSource = dt_siparis_kalem;
        }

        private void grid_siparis_KeyDown(object sender, KeyEventArgs e)
        {
            if (gv_siparis.SelectedRowsCount <= 0)
                return;

            if (durum_parametre_id != 18)
                return;

            if (e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE urunler_siparis SET silindi = 1 WHERE siparis_id = " + gv_siparis.GetDataRow(gv_siparis.GetSelectedRows()[0])["siparis_id"].ToString());

                    DataTable dt_siparisler = SQL.get("SELECT s.siparis_id, durum = p.deger, s.tahmini_teslim_tarihi, s.kayit_tarihi, c.cari_adi, s.durum_parametre_id FROM urunler_siparis s INNER JOIN parametreler p ON p.parametre_id = s.durum_parametre_id INNER JOIN cariler c ON c.cari_id = s.cari_id WHERE s.silindi = 0 ORDER by s.siparis_id DESC");
                    grid_siparis.DataSource = dt_siparisler;
                }
            }
        }

        private void btn_siparisi_geri_cek_Click(object sender, EventArgs e)
        {
            if (durum_parametre_id == 19)
                SQL.set("UPDATE urunler_siparis SET durum_parametre_id = 18 WHERE siparis_id = " + secili_siparis_id);
            if (durum_parametre_id == 18)
            {
                DataRow dr;
                for (int i = 0; i < gv_siapris_kalem.RowCount; i++)
                {
                    dr = gv_siapris_kalem.GetDataRow(i);
                    SQL.set("UPDATE urunler_siparis_kalem SET " +
                        " miktar = " + dr["miktar"].ToString().Replace(',', '.') + ", " +
                        " birim_fiyat = " + dr["birim_fiyat"].ToString().Replace(',', '.') + ", " +
                        " iskonto_1 = " + dr["iskonto_1"].ToString().Replace(',', '.') + ", " +
                        " iskonto_2 = " + dr["iskonto_2"].ToString().Replace(',', '.') + " " +
                        " WHERE siparis_kalem_id = " + dr["siparis_kalem_id"]);
                }
            }

            DataTable dt_siparisler = SQL.get("SELECT s.siparis_id, durum = p.deger, s.tahmini_teslim_tarihi, s.kayit_tarihi, c.cari_adi, s.durum_parametre_id FROM urunler_siparis s INNER JOIN parametreler p ON p.parametre_id = s.durum_parametre_id INNER JOIN cariler c ON c.cari_id = s.cari_id WHERE s.silindi = 0 ORDER by s.siparis_id DESC");
            grid_siparis.DataSource = dt_siparisler;

            secili_siparis_id = 0;
            btn_iptal.Visible = gb_sipais_kalem.Visible = false;
            btn_log_out.Text = "EKLE";
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (gv_siapris_kalem.SelectedRowsCount <= 0)
                return;

            if (durum_parametre_id != 18)
                return;

            DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SQL.set("UPDATE urunler_siparis_kalem SET silindi = 1 WHERE siparis_kalem_id = " + gv_siapris_kalem.GetDataRow(gv_siapris_kalem.GetSelectedRows()[0])["siparis_kalem_id"].ToString());

                DataTable dt_siparis_kalem = SQL.get("SELECT sk.siparis_kalem_id, sk.urun_id, u.urun_adi, olcu_birimi = p.deger, sk.miktar, sk.kapandi, sk.birim_fiyat, sk.iskonto_1, sk.iskonto_2, u.kdv, gelen_miktar = (SELECT SUM(miktar) FROM urunler_irsaliye_kalem ik WHERE ik.silindi = 0 AND ik.referans_siparis_kalem_id = sk.siparis_kalem_id), " +
                    " net_toplam = sk.miktar * (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)), " +
            " net_birim_fiyat = (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)) " +
                    " FROM urunler_siparis_kalem sk INNER JOIN urunler u ON u.urun_id = sk.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE sk.silindi = 0 AND sk.siparis_id = " + secili_siparis_id);
                grid_siparis_kalem.DataSource = dt_siparis_kalem;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gv_siparis.SelectedRowsCount <= 0)
                return;

            rp_siparis s = new rp_siparis(Convert.ToInt32(gv_siparis.GetDataRow(gv_siparis.GetSelectedRows()[0])["siparis_id"].ToString()));
            s.CreateDocument();
            disa_aktar d = new disa_aktar();
            d.rp_viewer.DocumentSource = s;
            d.ShowDialog();
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            secili_siparis_id = 0;
            btn_iptal.Visible = gb_sipais_kalem.Visible = false;
            btn_log_out.Text = "EKLE";

            tb_no.Text = "";
            tb_aciklama.Text = "";
        }
    }
}
