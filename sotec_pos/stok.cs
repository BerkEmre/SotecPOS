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
    public partial class stok : Form
    {
        public stok()
        {
            InitializeComponent();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stok_Load(object sender, EventArgs e)
        {
            DataTable dt_cari = SQL.get("SELECT c.cari_id, c.cari_adi, bakiye = ISNULL((SELECT SUM(cb.miktar) FROM cari_bakiye cb WHERE cb.silindi = 0 AND cb.cari_id = c.cari_id), 0.0000) FROM cariler c WHERE c.silindi = 0");
            gridControl1.DataSource = dt_cari;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(24))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            cariler c = new cariler();
            c.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(26))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            personel_maas_odeme p = new personel_maas_odeme();
            p.FormClosing += P_FormClosing;
            p.Show();
        }

        private void P_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt_cari = SQL.get("SELECT c.cari_id, c.cari_adi, bakiye = ISNULL((SELECT SUM(cb.miktar) FROM cari_bakiye cb WHERE cb.silindi = 0 AND cb.cari_id = c.cari_id), 0.0000) FROM cariler c WHERE c.silindi = 0");
            gridControl1.DataSource = dt_cari;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            finans_satin_alma_fatura f = new finans_satin_alma_fatura();
            f.FormClosing += P_FormClosing;
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(27))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            finans_satis_fatura f = new finans_satis_fatura();
            f.FormClosing += P_FormClosing;
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(25))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            finans_tahsilat_fisi f = new finans_tahsilat_fisi();
            f.FormClosing += P_FormClosing;
            f.ShowDialog();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount <= 0)
                return;
            if (!gridView1.IsDataRow(gridView1.GetSelectedRows()[0])) return;

            int cari_id = Convert.ToInt32(gridView1.GetDataRow(gridView1.GetSelectedRows()[0])["cari_id"]);

            DataTable dt = SQL.get("SELECT id = f.fatura_id, [no] =  f.fatura_no, c.cari_adi, tarih = f.fatura_tarihi, tip = p.deger, belge = 'Fatura', tutar = CASE f.fatura_tipi_parametre_id WHEN 29 THEN -1 WHEN 30 THEN 1 END * (SELECT SUM(fk.miktar * (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) + (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) / 100 * fk.kdv))) FROM urunler_fatura_kalem fk WHERE fk.silindi = 0 AND fk.fatura_id = f.fatura_id) FROM urunler_fatura f INNER JOIN cariler c ON c.cari_id = f.cari_id INNER JOIN parametreler p ON p.parametre_id = f.fatura_tipi_parametre_id WHERE f.silindi = 0 AND f.cari_id = " + cari_id + " " +
            " UNION ALL " +
            " SELECT id = t.tahsilat_id, [no] = t.tahsilat_no, c.cari_adi, tarih = t.tahsilat_tarihi, tip = p.deger, belge = 'Tahsilat Fişi', tutar = CASE t.tahsilat_tipi_parametre_id WHEN 37 THEN t.tutar WHEN 35 THEN t.tutar * -1 END FROM finans_tahsilat t INNER JOIN cariler c ON c.cari_id = t.cari_id INNER JOIN parametreler p ON p.parametre_id = t.tahsilat_tipi_parametre_id WHERE t.silindi = 0 AND t.cari_id = " + cari_id + " ");
            grid_faturalar.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(33))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            finans_genel_gider f = new finans_genel_gider();
            f.ShowDialog();
        }
    }
}
