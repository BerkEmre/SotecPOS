using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_cari_hesap_ekstresi : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_cari_hesap_ekstresi(int cari_id, DateTime ilk_tarih, DateTime son_tarih)
        {
            InitializeComponent();

            DataTable dt_cari = SQL.get("SELECT * FROM cariler WHERE cari_id = " + cari_id);

            lbl_cari_adi.Text = dt_cari.Rows[0]["cari_adi"].ToString();
            lbl_siparis_tarihi.Text = ilk_tarih.ToShortDateString() + " - " + son_tarih.ToShortDateString();

            DataTable dt = SQL.get("SELECT id = f.fatura_id, [no] =  f.fatura_no, c.cari_adi, tarih = f.fatura_tarihi, tip = p.deger, belge = 'Fatura', tutar = CASE f.fatura_tipi_parametre_id WHEN 29 THEN -1 WHEN 30 THEN 1 END * (SELECT SUM(fk.miktar * (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) + (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) / 100 * fk.kdv))) FROM urunler_fatura_kalem fk WHERE fk.silindi = 0 AND fk.fatura_id = f.fatura_id) FROM urunler_fatura f INNER JOIN cariler c ON c.cari_id = f.cari_id INNER JOIN parametreler p ON p.parametre_id = f.fatura_tipi_parametre_id WHERE f.silindi = 0 AND f.cari_id = " + cari_id + " AND f.fatura_tarihi BETWEEN '" + ilk_tarih.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND DATEADD(DAY, 0, '" + son_tarih.ToString("yyyy-MM-dd HH:mm:ss.fff") + "') " +
            " UNION ALL " +
            " SELECT id = t.tahsilat_id, [no] = t.tahsilat_no, c.cari_adi, tarih = t.tahsilat_tarihi, tip = p.deger, belge = 'Tahsilat Fişi', tutar = CASE t.tahsilat_tipi_parametre_id WHEN 37 THEN t.tutar WHEN 35 THEN t.tutar * -1 END FROM finans_tahsilat t INNER JOIN cariler c ON c.cari_id = t.cari_id INNER JOIN parametreler p ON p.parametre_id = t.tahsilat_tipi_parametre_id WHERE t.silindi = 0 AND t.cari_id = " + cari_id + " AND t.tahsilat_tarihi BETWEEN '" + ilk_tarih.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND DATEADD(DAY, 0, '" + son_tarih.ToString("yyyy-MM-dd HH:mm:ss.fff") + "') ");
            this.DataSource = dt;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "tarih", "");
            xrTableCell4.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "no", "");
            xrTableCell5.DataBindings.Add(binding1);
            XRBinding binding2 = new XRBinding("Text", this.DataSource, "belge", "");
            xrTableCell6.DataBindings.Add(binding2);
            XRBinding binding3 = new XRBinding("Text", this.DataSource, "tip", "");
            xrTableCell7.DataBindings.Add(binding3);
            XRBinding binding4 = new XRBinding("Text", this.DataSource, "tutar", "{0:c2}");
            xrTableCell10.DataBindings.Add(binding4);
            XRBinding binding5 = new XRBinding("Text", this.DataSource, "tutar", "");
            xrTableCell15.DataBindings.Add(binding5);

            XRSummary sum1 = new XRSummary(SummaryRunning.Page, SummaryFunc.Sum, "{0:c2}");
            xrTableCell15.Summary = sum1;
        }
    }
}
