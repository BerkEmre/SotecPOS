using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_irsaliye : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_irsaliye(int irsaliye_id)
        {
            InitializeComponent();

            DataTable dt_irsaliye = SQL.get("SELECT s.irsaliye_no, s.irsaliye_tarihi, c.cari_adi FROM urunler_irsaliye s INNER JOIN cariler c ON c.cari_id = s.cari_id WHERE s.irsaliye_id = " + irsaliye_id);

            lbl_cari_adi.Text = dt_irsaliye.Rows[0]["cari_adi"].ToString();
            lbl_siparis_tarihi.Text = dt_irsaliye.Rows[0]["irsaliye_tarihi"].ToString();
            lbl_siparis_no.Text = dt_irsaliye.Rows[0]["irsaliye_no"].ToString();

            DataTable dt_irsaliye_kalem = SQL.get("SELECT s.siparis_no, i.irsaliye_kalem_id, i.urun_id, u.urun_adi, i.miktar, i.referans_siparis_kalem_id, olcu_birimi = p.deger, fatura_kalem_id = ISNULL(fk.fatura_kalem_id, 0) " +
                " FROM urunler_irsaliye_kalem i INNER JOIN urunler u ON u.urun_id = i.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN urunler_siparis_kalem sk ON sk.siparis_kalem_id = i.referans_siparis_kalem_id INNER JOIN urunler_siparis s ON s.siparis_id = sk.siparis_id LEFT OUTER JOIN urunler_fatura_kalem fk ON fk.silindi = 0 AND fk.referans_irsaliye_kalem_id = i.irsaliye_kalem_id " +
                " WHERE i.silindi = 0 AND i.irsaliye_id = " + irsaliye_id);
            this.DataSource = dt_irsaliye_kalem;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "urun_adi", "");
            xrTableCell10.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "siparis_no", "");
            xrTableCell11.DataBindings.Add(binding1);
            XRBinding binding2 = new XRBinding("Text", this.DataSource, "olcu_birimi", "{0:n0}");
            xrTableCell12.DataBindings.Add(binding2);
            XRBinding binding3 = new XRBinding("Text", this.DataSource, "miktar", "{0:c2}");
            xrTableCell13.DataBindings.Add(binding3);
        }

    }
}
