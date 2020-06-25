using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_fatura : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_fatura(int fatura_id)
        {
            InitializeComponent();

            DataTable dt_siparis = SQL.get("SELECT s.fatura_id, s.fatura_no, s.fatura_tarihi, c.cari_adi, p.deger FROM urunler_fatura s INNER JOIN cariler c ON c.cari_id = s.cari_id INNER JOIN parametreler p ON p.parametre_id = s.fatura_tipi_parametre_id WHERE s.fatura_id = " + fatura_id);

            lbl_cari_adi.Text = dt_siparis.Rows[0]["cari_adi"].ToString();
            lbl_siparis_tarihi.Text = dt_siparis.Rows[0]["fatura_tarihi"].ToString();
            xrLabel2.Text = dt_siparis.Rows[0]["deger"].ToString();
            lbl_siparis_no.Text = dt_siparis.Rows[0]["fatura_no"].ToString();

            DataTable dt_siparis_kalem = SQL.get("SELECT " +
                " s.siparis_id, i.irsaliye_no, fk.fatura_kalem_id, fk.referans_irsaliye_kalem_id, fk.urun_id, u.urun_adi, olcu_birim = p.deger, fk.miktar, fk.birim_fiyat, fk.iskonto_1, fk.iskonto_2, fk.kdv, " +
                " toplam = fk.miktar * (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) + (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) / 100 * fk.kdv)), " +
                " net_birim_fiyat = (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) + (((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) - ((fk.birim_fiyat - (fk.birim_fiyat / 100 * fk.iskonto_1)) / 100 * fk.iskonto_2)) / 100 * fk.kdv))" +
                " FROM " +
                "    urunler_fatura_kalem fk " +
                "    INNER JOIN urunler u ON u.urun_id = fk.urun_id " +
                "    INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id   " +
                "    LEFT OUTER JOIN urunler_irsaliye_kalem ik ON ik.irsaliye_kalem_id = fk.referans_irsaliye_kalem_id " +
                "    LEFT OUTER JOIN urunler_irsaliye i ON i.irsaliye_id = ik.irsaliye_id " +
                "    LEFT OUTER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = ik.referans_siparis_kalem_id " +
                "    LEFT OUTER JOIN urunler_siparis s ON s.siparis_id = sk.siparis_id " +
                " WHERE fk.silindi = 0 AND fk.fatura_id = " + fatura_id);
            this.DataSource = dt_siparis_kalem;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "urun_adi", "");
            xrTableCell11.DataBindings.Add(binding0);
            XRBinding binding9 = new XRBinding("Text", this.DataSource, "irsaliye_no", "{0:c2}");
            xrTableCell20.DataBindings.Add(binding9);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "olcu_birim", "");
            xrTableCell12.DataBindings.Add(binding1);
            XRBinding binding2 = new XRBinding("Text", this.DataSource, "miktar", "{0:n0}");
            xrTableCell13.DataBindings.Add(binding2);
            XRBinding binding3 = new XRBinding("Text", this.DataSource, "birim_fiyat", "{0:c2}");
            xrTableCell14.DataBindings.Add(binding3);
            XRBinding binding4 = new XRBinding("Text", this.DataSource, "iskonto_1", "{0:n0}");
            xrTableCell15.DataBindings.Add(binding4);
            XRBinding binding5 = new XRBinding("Text", this.DataSource, "iskonto_2", "{0:n0}");
            xrTableCell16.DataBindings.Add(binding5);
            XRBinding binding6 = new XRBinding("Text", this.DataSource, "kdv", "{0:n0}");
            xrTableCell17.DataBindings.Add(binding6);
            XRBinding binding7 = new XRBinding("Text", this.DataSource, "net_birim_fiyat", "{0:c2}");
            xrTableCell18.DataBindings.Add(binding7);
            XRBinding binding8 = new XRBinding("Text", this.DataSource, "toplam", "{0:c2}");
            xrTableCell19.DataBindings.Add(binding8);
        }

    }
}
