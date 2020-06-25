using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_siparis : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_siparis(int siparis_id)
        {
            InitializeComponent();

            DataTable dt_siparis = SQL.get("SELECT s.siparis_id, s.kayit_tarihi, s.tahmini_teslim_tarihi, c.cari_adi FROM urunler_siparis s INNER JOIN cariler c ON c.cari_id = s.cari_id WHERE s.siparis_id = " + siparis_id);

            lbl_cari_adi.Text = dt_siparis.Rows[0]["cari_adi"].ToString();
            lbl_siparis_tarihi.Text = dt_siparis.Rows[0]["kayit_tarihi"].ToString();
            lbl_teslim_tarihi.Text = dt_siparis.Rows[0]["tahmini_teslim_tarihi"].ToString();
            lbl_siparis_no.Text = dt_siparis.Rows[0]["siparis_id"].ToString();

            DataTable dt_siparis_kalem = SQL.get("SELECT sk.siparis_kalem_id, sk.urun_id, u.urun_adi, olcu_birimi = p.deger, sk.miktar, sk.kapandi, sk.birim_fiyat, sk.iskonto_1, sk.iskonto_2, u.kdv, " +
                " net_toplam = sk.miktar * (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)), " +
                " net_birim_fiyat = (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) + (((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) - ((sk.birim_fiyat - (sk.birim_fiyat / 100 * sk.iskonto_1)) / 100 * sk.iskonto_2)) / 100 * u.kdv)) " +
                " FROM urunler_siparis_kalem sk INNER JOIN urunler u ON u.urun_id = sk.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE sk.silindi = 0 AND sk.siparis_id = " + siparis_id);
            this.DataSource = dt_siparis_kalem;
            
            XRBinding binding0 = new XRBinding("Text", this.DataSource, "urun_adi", "");
            xrTableCell10.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "olcu_birimi", "");
            xrTableCell11.DataBindings.Add(binding1);
            XRBinding binding2 = new XRBinding("Text", this.DataSource, "miktar", "{0:n0}");
            xrTableCell12.DataBindings.Add(binding2);
            XRBinding binding3 = new XRBinding("Text", this.DataSource, "birim_fiyat", "{0:c2}");
            xrTableCell13.DataBindings.Add(binding3);
            XRBinding binding4 = new XRBinding("Text", this.DataSource, "iskonto_1", "{0:n0}");
            xrTableCell14.DataBindings.Add(binding4);
            XRBinding binding5 = new XRBinding("Text", this.DataSource, "iskonto_2", "{0:n0}");
            xrTableCell15.DataBindings.Add(binding5);
            XRBinding binding6 = new XRBinding("Text", this.DataSource, "kdv", "{0:n0}");
            xrTableCell16.DataBindings.Add(binding6);
            XRBinding binding7 = new XRBinding("Text", this.DataSource, "net_birim_fiyat", "{0:c2}");
            xrTableCell17.DataBindings.Add(binding7);
            XRBinding binding8 = new XRBinding("Text", this.DataSource, "net_toplam", "{0:c2}");
            xrTableCell18.DataBindings.Add(binding8);
        }

    }
}
