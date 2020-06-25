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
    public partial class finans_satin_alma_fatura : Form
    {
        int secili_fatura_id = 0;
        int cari_id = 0;
        int kalem_adet = 0;

        public finans_satin_alma_fatura()
        {
            InitializeComponent();
        }

        private void finans_satin_alma_fatura_Load(object sender, EventArgs e)
        {
            DataTable dt_cari = SQL.get("SELECT * FROM cariler WHERE [cari_tipi_parametre_id] IN (1, 43) AND silindi = 0"); if (dt_cari.Rows.Count <= 0)
            {
                new mesaj("Cari girmeden fatura giremezsiniz!").ShowDialog();
                this.Close();
                return;
            }
            cmb_cariler.Properties.DataSource = dt_cari;
            cmb_cariler.EditValue = dt_cari.Rows[0]["cari_id"];

            DataTable dt_fatura = SQL.get("SELECT f.fatura_no, f.fatura_id, f.kayit_tarihi, f.fatura_tarihi, f.vade_tarihi, kalem_adet = (SELECT COUNT(*) FROM urunler_fatura_kalem fk WHERE fk.silindi = 0 AND fk.fatura_id = f.fatura_id), c.cari_adi, c.cari_id FROM urunler_fatura f INNER JOIN cariler c ON c.cari_id = f.cari_id WHERE f.silindi = 0 AND f.fatura_tipi_parametre_id = 29 ORDER by f.fatura_id DESC");
            grid_fatura.DataSource = dt_fatura;
        }

        private void grid_fatura_Click(object sender, EventArgs e)
        {
            if (gv_fatura.SelectedRowsCount <= 0)
                return;

            if (!gv_fatura.IsDataRow(gv_fatura.GetSelectedRows()[0]))
                return;

            secili_fatura_id = Convert.ToInt32(gv_fatura.GetDataRow(gv_fatura.GetSelectedRows()[0])["fatura_id"]);
            kalem_adet = Convert.ToInt32(gv_fatura.GetDataRow(gv_fatura.GetSelectedRows()[0])["kalem_adet"]);
            cari_id = Convert.ToInt32(gv_fatura.GetDataRow(gv_fatura.GetSelectedRows()[0])["cari_id"]);
            btn_iptal.Visible = gb_fatura_kalem.Visible = true;
            btn_log_out.Text = "DÜZENLE";

            DataTable dt_ft = SQL.get("SELECT * FROM urunler_fatura WHERE fatura_id = " + secili_fatura_id);

            cmb_cariler.EditValue = dt_ft.Rows[0]["cari_id"];
            dt_teslim_tarihi.Value = Convert.ToDateTime(dt_ft.Rows[0]["vade_tarihi"]);
            dt_fatura_tarihi.Value = Convert.ToDateTime(dt_ft.Rows[0]["fatura_tarihi"]);
            tb_no.Text = dt_ft.Rows[0]["fatura_no"].ToString();
            tb_aciklama.Text = dt_ft.Rows[0]["aciklama"].ToString();

            DataTable dt_irsaliye_kalem = SQL.get("SELECT i.irsaliye_no, i.irsaliye_id, ik.irsaliye_kalem_id, ik.urun_id, u.urun_adi, olcu_birimi = p.deger, ik.miktar, sk.birim_fiyat, sk.iskonto_1, sk.iskonto_2, u.kdv, ik.referans_siparis_kalem_id, " +
                " toplam = ik.miktar * (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)) " +
                " FROM urunler_irsaliye i INNER JOIN urunler_irsaliye_kalem ik ON ik.silindi = 0 AND ik.irsaliye_id = i.irsaliye_id INNER JOIN urunler u ON u.urun_id = ik.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = ik.referans_siparis_kalem_id LEFT OUTER JOIN urunler_fatura_kalem fk ON fk.silindi = 0 AND fk.referans_irsaliye_kalem_id = ik.irsaliye_kalem_id WHERE i.silindi = 0 AND fk.fatura_kalem_id IS NULL AND i.cari_id = " + cari_id);
            grid_irsaliye_kalem.DataSource = dt_irsaliye_kalem;

            DataTable dt_fatura_kalem = SQL.get("SELECT s.siparis_id, i.irsaliye_no, fk.fatura_kalem_id, fk.referans_irsaliye_kalem_id, fk.urun_id, u.urun_adi, olcu_birim = p.deger, ik.miktar, fk.birim_fiyat, fk.iskonto_1, fk.iskonto_2, fk.kdv, " +
                " toplam = ik.miktar * (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) + (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) / 100 * fk.kdv)), " +
                " net_birim_fiyat = (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) + (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) / 100 * fk.kdv))" +
                " FROM urunler_fatura_kalem fk INNER JOIN urunler u ON u.urun_id = fk.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN urunler_irsaliye_kalem ik ON ik.irsaliye_kalem_id = fk.referans_irsaliye_kalem_id INNER JOIN urunler_irsaliye i ON i.irsaliye_id = ik.irsaliye_id INNER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = ik.referans_siparis_kalem_id INNER JOIN urunler_siparis s ON s.siparis_id = sk.siparis_id WHERE fk.silindi = 0 AND fk.fatura_id = " + secili_fatura_id);
            grid_fatura_kalem.DataSource = dt_fatura_kalem;
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            secili_fatura_id = kalem_adet = cari_id = 0;
            btn_iptal.Visible = gb_fatura_kalem.Visible = false;
            btn_log_out.Text = "EKLE";
            tb_no.Text = "";
            tb_aciklama.Text = "";
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if (tb_no.Text.Length <= 0)
            {
                new mesaj("Fatura No Giriniz!").ShowDialog();
                return;
            }

            if (secili_fatura_id == 0)
                SQL.set("INSERT INTO urunler_fatura (kaydeden_kullanici_id, cari_id, fatura_tipi_parametre_id, vade_tarihi, fatura_tarihi, fatura_no, aciklama) VALUES (" + SQL.kullanici_id + ", " + cmb_cariler.EditValue + ", 29, '" + dt_teslim_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', '" + dt_fatura_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', '" + tb_no.Text + "', '" + tb_aciklama.Text + "')");
            else
            {
                if (kalem_adet != 0)
                {
                    new mesaj("Faturada kalem varken değiştirilemez!").ShowDialog();
                    return;
                }
                SQL.set("UPDATE urunler_fatura SET cari_id = " + cmb_cariler.EditValue + ", vade_tarihi = '" + dt_teslim_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', fatura_tarihi = '" + dt_fatura_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', fatura_no = '" + tb_no.Text + "', aciklama = '" + tb_aciklama.Text + "' WHERE fatura_id = " + secili_fatura_id);
            }

            DataTable dt_fatura = SQL.get("SELECT f.fatura_no, f.fatura_id, f.kayit_tarihi, f.fatura_tarihi, f.vade_tarihi, kalem_adet = (SELECT COUNT(*) FROM urunler_fatura_kalem fk WHERE fk.silindi = 0 AND fk.fatura_id = f.fatura_id), c.cari_adi, c.cari_id FROM urunler_fatura f INNER JOIN cariler c ON c.cari_id = f.cari_id WHERE f.silindi = 0 AND f.fatura_tipi_parametre_id = 29 ORDER by f.fatura_id DESC");
            grid_fatura.DataSource = dt_fatura;
        }

        private void grid_fatura_KeyDown(object sender, KeyEventArgs e)
        {
            if (gv_fatura.SelectedRowsCount <= 0)
                return;

            if (e.KeyCode == Keys.Delete)
            {
                if (kalem_adet != 0)
                {
                    new mesaj("Faturada kalem varken silinemez!").ShowDialog();
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE urunler_fatura SET silindi = 1 WHERE fatura_id = " + gv_fatura.GetDataRow(gv_fatura.GetSelectedRows()[0])["fatura_id"].ToString());
                    
                    DataTable dt_fatura = SQL.get("SELECT f.fatura_no, f.fatura_id, f.kayit_tarihi, f.fatura_tarihi, f.vade_tarihi, kalem_adet = (SELECT COUNT(*) FROM urunler_fatura_kalem fk WHERE fk.silindi = 0 AND fk.fatura_id = f.fatura_id), c.cari_adi, c.cari_id FROM urunler_fatura f INNER JOIN cariler c ON c.cari_id = f.cari_id WHERE f.silindi = 0 AND f.fatura_tipi_parametre_id = 29 ORDER by f.fatura_id DESC");
                    grid_fatura.DataSource = dt_fatura;
                }
                gb_fatura_kalem.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_kalem_ekle_Click(object sender, EventArgs e)
        {
            if (gv_irsaliye_kalem.SelectedRowsCount <= 0)
            {
                new mesaj("İrsaliye kalemi seçiniz!").ShowDialog();
                return;
            }

            DataRow dr;
            for (int i = 0; i < gv_irsaliye_kalem.SelectedRowsCount; i++)
            {
                dr = gv_irsaliye_kalem.GetDataRow(gv_irsaliye_kalem.GetSelectedRows()[i]);

                if (Convert.ToDecimal(dr["birim_fiyat"]) == 0)
                {
                    new mesaj("Birim Fiyat 0 olan sipariş kalemleri mevcut!").ShowDialog();
                    return;
                }
            }

            DataTable dt_ik;
            for (int i = 0; i < gv_irsaliye_kalem.SelectedRowsCount; i++)
            {
                dr = gv_irsaliye_kalem.GetDataRow(gv_irsaliye_kalem.GetSelectedRows()[i]);
                dt_ik = SQL.get("INSERT INTO urunler_fatura_kalem (urun_id, birim_fiyat, iskonto_1, iskonto_2, kdv, referans_irsaliye_kalem_id, fatura_id, miktar) VALUES (" + dr["urun_id"] + ", " + dr["birim_fiyat"].ToString().Replace(',', '.') + ", " + dr["iskonto_1"].ToString().Replace(',', '.') + ", " + dr["iskonto_2"].ToString().Replace(',', '.') + ", " + dr["kdv"].ToString().Replace(',', '.') + ", " + dr["irsaliye_kalem_id"] + ", " + secili_fatura_id + ", " + dr["miktar"].ToString().Replace(',', '.') + "); SELECT SCOPE_IDENTITY();");
                SQL.set("INSERT INTO cari_bakiye (cari_id, miktar, cari_bakiye_tipi, referans_id) VALUES (" + cari_id + ", " + (Convert.ToDecimal(dr["toplam"]) * -1).ToString().Replace(',', '.') + ", 32, " + dt_ik.Rows[0][0] + ")");
                SQL.set("UPDATE urunler_siparis_kalem SET kapandi = 1 WHERE siparis_kalem_id = " + dr["referans_siparis_kalem_id"]);
            }

            DataTable dt_irsaliye_kalem = SQL.get("SELECT i.irsaliye_no, i.irsaliye_id, ik.irsaliye_kalem_id, ik.urun_id, u.urun_adi, olcu_birimi = p.deger, ik.miktar, sk.birim_fiyat, sk.iskonto_1, sk.iskonto_2, u.kdv, ik.referans_siparis_kalem_id, " +
                " toplam = ik.miktar * (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)) " +
                " FROM urunler_irsaliye i INNER JOIN urunler_irsaliye_kalem ik ON ik.silindi = 0 AND ik.irsaliye_id = i.irsaliye_id INNER JOIN urunler u ON u.urun_id = ik.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = ik.referans_siparis_kalem_id LEFT OUTER JOIN urunler_fatura_kalem fk ON fk.silindi = 0 AND fk.referans_irsaliye_kalem_id = ik.irsaliye_kalem_id WHERE i.silindi = 0 AND fk.fatura_kalem_id IS NULL AND i.cari_id = " + cari_id);
            grid_irsaliye_kalem.DataSource = dt_irsaliye_kalem;

            DataTable dt_fatura_kalem = SQL.get("SELECT s.siparis_id, i.irsaliye_no, fk.fatura_kalem_id, fk.referans_irsaliye_kalem_id, fk.urun_id, u.urun_adi, olcu_birim = p.deger, ik.miktar, fk.birim_fiyat, fk.iskonto_1, fk.iskonto_2, fk.kdv, " +
                " toplam = ik.miktar * (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) + (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) / 100 * fk.kdv)), " +
                " net_birim_fiyat = (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) + (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) / 100 * fk.kdv))" +
                " FROM urunler_fatura_kalem fk INNER JOIN urunler u ON u.urun_id = fk.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN urunler_irsaliye_kalem ik ON ik.irsaliye_kalem_id = fk.referans_irsaliye_kalem_id INNER JOIN urunler_irsaliye i ON i.irsaliye_id = ik.irsaliye_id INNER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = ik.referans_siparis_kalem_id INNER JOIN urunler_siparis s ON s.siparis_id = sk.siparis_id WHERE fk.silindi = 0 AND fk.fatura_id = " + secili_fatura_id);
            grid_fatura_kalem.DataSource = dt_fatura_kalem;
        }

        private void gv_irsaliye_kalem_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            decimal birim_fiyat = 0, iskonto_1 = 0, iskonto_2 = 0, kdv = 0, miktar = 0, toplam = 0;

            DataRow dr = gv_irsaliye_kalem.GetDataRow(e.RowHandle);

            if (e.Column.FieldName == "birim_fiyat")
            {
                miktar = Convert.ToDecimal(dr["miktar"]);
                iskonto_1 = Convert.ToDecimal(dr["iskonto_1"]);
                iskonto_2 = Convert.ToDecimal(dr["iskonto_2"]);
                kdv = Convert.ToDecimal(dr["kdv"]);
                try { birim_fiyat = Convert.ToDecimal(e.Value); } catch { birim_fiyat = 0; }
            }
            else if (e.Column.FieldName == "iskonto_1")
            {
                miktar = Convert.ToDecimal(dr["miktar"]);
                birim_fiyat = Convert.ToDecimal(dr["birim_fiyat"]);
                iskonto_2 = Convert.ToDecimal(dr["iskonto_2"]);
                kdv = Convert.ToDecimal(dr["kdv"]);
                try { iskonto_1 = Convert.ToDecimal(e.Value); } catch { iskonto_1 = 0; }
            }
            else if (e.Column.FieldName == "iskonto_2")
            {
                miktar = Convert.ToDecimal(dr["miktar"]);
                iskonto_1 = Convert.ToDecimal(dr["iskonto_1"]);
                birim_fiyat = Convert.ToDecimal(dr["birim_fiyat"]);
                kdv = Convert.ToDecimal(dr["kdv"]);
                try { iskonto_2 = Convert.ToDecimal(e.Value); } catch { iskonto_2 = 0; }
            }
            else if (e.Column.FieldName == "kdv")
            {
                miktar = Convert.ToDecimal(dr["miktar"]);
                iskonto_1 = Convert.ToDecimal(dr["iskonto_1"]);
                iskonto_2 = Convert.ToDecimal(dr["iskonto_2"]);
                birim_fiyat = Convert.ToDecimal(dr["birim_fiyat"]);
                try { kdv = Convert.ToDecimal(e.Value); } catch { kdv = 0; }
            }

            toplam = miktar * (((birim_fiyat - (birim_fiyat / 100 * iskonto_1)) - ((birim_fiyat - (birim_fiyat / 100 * iskonto_1)) / 100 * iskonto_2)) + (((birim_fiyat - (birim_fiyat / 100 * iskonto_1)) - ((birim_fiyat - (birim_fiyat / 100 * iskonto_1)) / 100 * iskonto_2)) / 100 * kdv));
            gv_irsaliye_kalem.SetRowCellValue(e.RowHandle, gv_irsaliye_kalem.Columns["toplam"], toplam);
        }

        private void grid_fatura_kalem_KeyDown(object sender, KeyEventArgs e)
        {
            if (gv_fatura_kalem.SelectedRowsCount <= 0)
                return;

            if (e.KeyCode == Keys.Delete)
            {
                DataRow dr = gv_fatura_kalem.GetDataRow(gv_fatura_kalem.GetSelectedRows()[0]);

                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE urunler_fatura_kalem SET silindi = 1 WHERE fatura_kalem_id = " + dr["fatura_kalem_id"]);
                    SQL.set("UPDATE cari_bakiye SET silindi = 1 WHERE cari_bakiye_tipi = 32 AND cari_id = " + cari_id + " AND referans_id = " + dr["fatura_kalem_id"]);

                    DataTable dt_irsaliye_kalem = SQL.get("SELECT i.irsaliye_no, i.irsaliye_id, ik.irsaliye_kalem_id, ik.urun_id, u.urun_adi, olcu_birimi = p.deger, ik.miktar, sk.birim_fiyat, sk.iskonto_1, sk.iskonto_2, u.kdv, ik.referans_siparis_kalem_id, " +
                        " toplam = ik.miktar * (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)) " +
                        " FROM urunler_irsaliye i INNER JOIN urunler_irsaliye_kalem ik ON ik.silindi = 0 AND ik.irsaliye_id = i.irsaliye_id INNER JOIN urunler u ON u.urun_id = ik.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = ik.referans_siparis_kalem_id LEFT OUTER JOIN urunler_fatura_kalem fk ON fk.silindi = 0 AND fk.referans_irsaliye_kalem_id = ik.irsaliye_kalem_id WHERE i.silindi = 0 AND fk.fatura_kalem_id IS NULL AND i.cari_id = " + cari_id);
                    grid_irsaliye_kalem.DataSource = dt_irsaliye_kalem;

                    DataTable dt_fatura_kalem = SQL.get("SELECT s.siparis_id, i.irsaliye_no, fk.fatura_kalem_id, fk.referans_irsaliye_kalem_id, fk.urun_id, u.urun_adi, olcu_birim = p.deger, ik.miktar, fk.birim_fiyat, fk.iskonto_1, fk.iskonto_2, fk.kdv, " +
                        " toplam = ik.miktar * (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) + (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) / 100 * fk.kdv)), " +
                        " net_birim_fiyat = (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) + (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) / 100 * fk.kdv))" +
                        " FROM urunler_fatura_kalem fk INNER JOIN urunler u ON u.urun_id = fk.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN urunler_irsaliye_kalem ik ON ik.irsaliye_kalem_id = fk.referans_irsaliye_kalem_id INNER JOIN urunler_irsaliye i ON i.irsaliye_id = ik.irsaliye_id INNER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = ik.referans_siparis_kalem_id INNER JOIN urunler_siparis s ON s.siparis_id = sk.siparis_id WHERE fk.silindi = 0 AND fk.fatura_id = " + secili_fatura_id);
                    grid_fatura_kalem.DataSource = dt_fatura_kalem;
                }
            }
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            DataRow dr;
            for (int i = 0; i < gv_fatura_kalem.RowCount; i++)
            {
                dr = gv_fatura_kalem.GetDataRow(i);

                SQL.set("UPDATE urunler_fatura_kalem SET birim_fiyat = " + dr["birim_fiyat"].ToString().Replace(',', '.') + ", iskonto_1 = " + dr["iskonto_1"].ToString().Replace(',', '.') + ", iskonto_2 = " + dr["iskonto_2"].ToString().Replace(',', '.') + ", kdv = " + dr["kdv"].ToString().Replace(',', '.') + " WHERE fatura_kalem_id = " + dr["fatura_kalem_id"]);
                SQL.set("UPDATE cari_bakiye SET miktar = " + (Convert.ToDecimal(dr["toplam"]) * -1).ToString().Replace(',', '.') + " WHERE cari_bakiye_tipi = 32 AND cari_id = " + cari_id + " AND referans_id = " + dr["fatura_kalem_id"]);
            }
            DataTable dt_irsaliye_kalem = SQL.get("SELECT i.irsaliye_no, i.irsaliye_id, ik.irsaliye_kalem_id, ik.urun_id, u.urun_adi, olcu_birimi = p.deger, ik.miktar, sk.birim_fiyat, sk.iskonto_1, sk.iskonto_2, u.kdv, ik.referans_siparis_kalem_id, " +
                " toplam = ik.miktar * (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)) " +
                " FROM urunler_irsaliye i INNER JOIN urunler_irsaliye_kalem ik ON ik.silindi = 0 AND ik.irsaliye_id = i.irsaliye_id INNER JOIN urunler u ON u.urun_id = ik.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = ik.referans_siparis_kalem_id LEFT OUTER JOIN urunler_fatura_kalem fk ON fk.silindi = 0 AND fk.referans_irsaliye_kalem_id = ik.irsaliye_kalem_id WHERE i.silindi = 0 AND fk.fatura_kalem_id IS NULL AND i.cari_id = " + cari_id);
            grid_irsaliye_kalem.DataSource = dt_irsaliye_kalem;

            DataTable dt_fatura_kalem = SQL.get("SELECT s.siparis_id, i.irsaliye_no, fk.fatura_kalem_id, fk.referans_irsaliye_kalem_id, fk.urun_id, u.urun_adi, olcu_birim = p.deger, ik.miktar, fk.birim_fiyat, fk.iskonto_1, fk.iskonto_2, fk.kdv, " +
                " toplam = ik.miktar * (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) + (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) / 100 * fk.kdv)), " +
                " net_birim_fiyat = (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) + (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) / 100 * fk.kdv))" +
                " FROM urunler_fatura_kalem fk INNER JOIN urunler u ON u.urun_id = fk.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN urunler_irsaliye_kalem ik ON ik.irsaliye_kalem_id = fk.referans_irsaliye_kalem_id INNER JOIN urunler_irsaliye i ON i.irsaliye_id = ik.irsaliye_id INNER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = ik.referans_siparis_kalem_id INNER JOIN urunler_siparis s ON s.siparis_id = sk.siparis_id WHERE fk.silindi = 0 AND fk.fatura_id = " + secili_fatura_id);
            grid_fatura_kalem.DataSource = dt_fatura_kalem;
        }

        private void gb_fatura_kalem_Enter(object sender, EventArgs e)
        {

        }

        private void gv_fatura_kalem_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            decimal birim_fiyat = 0, iskonto_1 = 0, iskonto_2 = 0, kdv = 0, miktar = 0, toplam = 0;

            DataRow dr = gv_fatura_kalem.GetDataRow(e.RowHandle);

            if (e.Column.FieldName == "birim_fiyat")
            {
                miktar = Convert.ToDecimal(dr["miktar"]);
                iskonto_1 = Convert.ToDecimal(dr["iskonto_1"]);
                iskonto_2 = Convert.ToDecimal(dr["iskonto_2"]);
                kdv = Convert.ToDecimal(dr["kdv"]);
                try { birim_fiyat = Convert.ToDecimal(e.Value); } catch { birim_fiyat = 0; }
            }
            else if (e.Column.FieldName == "iskonto_1")
            {
                miktar = Convert.ToDecimal(dr["miktar"]);
                birim_fiyat = Convert.ToDecimal(dr["birim_fiyat"]);
                iskonto_2 = Convert.ToDecimal(dr["iskonto_2"]);
                kdv = Convert.ToDecimal(dr["kdv"]);
                try { iskonto_1 = Convert.ToDecimal(e.Value); } catch { iskonto_1 = 0; }
            }
            else if (e.Column.FieldName == "iskonto_2")
            {
                miktar = Convert.ToDecimal(dr["miktar"]);
                iskonto_1 = Convert.ToDecimal(dr["iskonto_1"]);
                birim_fiyat = Convert.ToDecimal(dr["birim_fiyat"]);
                kdv = Convert.ToDecimal(dr["kdv"]);
                try { iskonto_2 = Convert.ToDecimal(e.Value); } catch { iskonto_2 = 0; }
            }
            else if (e.Column.FieldName == "kdv")
            {
                miktar = Convert.ToDecimal(dr["miktar"]);
                iskonto_1 = Convert.ToDecimal(dr["iskonto_1"]);
                iskonto_2 = Convert.ToDecimal(dr["iskonto_2"]);
                birim_fiyat = Convert.ToDecimal(dr["birim_fiyat"]);
                try { kdv = Convert.ToDecimal(e.Value); } catch { kdv = 0; }
            }

            toplam = miktar * (((birim_fiyat - (birim_fiyat / 100 * iskonto_1)) - ((birim_fiyat - (birim_fiyat / 100 * iskonto_1)) / 100 * iskonto_2)) + (((birim_fiyat - (birim_fiyat / 100 * iskonto_1)) - ((birim_fiyat - (birim_fiyat / 100 * iskonto_1)) / 100 * iskonto_2)) / 100 * kdv));
            gv_fatura_kalem.SetRowCellValue(e.RowHandle, gv_fatura_kalem.Columns["toplam"], toplam);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gv_fatura.SelectedRowsCount <= 0)
                return;

            rp_fatura s = new rp_fatura(Convert.ToInt32(gv_fatura.GetDataRow(gv_fatura.GetSelectedRows()[0])["fatura_id"].ToString()));
            s.CreateDocument();
            disa_aktar d = new disa_aktar();
            d.rp_viewer.DocumentSource = s;
            d.ShowDialog();
        }
    }
}
