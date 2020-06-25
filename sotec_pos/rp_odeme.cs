using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_odeme : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_odeme(int adisyon_id, DataTable dt, string odeme_tipi, decimal tutar)
        {
            InitializeComponent();

            string text = "";
            try { text = System.IO.File.ReadAllText(@"firma_bilgi.txt"); } catch { text = ""; }
            xrLabel1.Text = text;

            DataTable dt_adisyon_kalem = SQL.get("SELECT u.fiyat, kullanici = k.ad + ' ' + k.soyad, a.kayit_tarihi, a.adisyon_id, masa_adi = ISNULL(m.masa_adi, 'SELF SERVİS'), ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id INNER JOIN adisyon a ON a.adisyon_id = ak.adisyon_id LEFT OUTER JOIN masalar m ON m.masa_id = a.masa_id INNER JOIN kullanicilar k ON k.kullanici_id = ak.kaydeden_kullanici_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + adisyon_id);
            lbl_masa_adi.Text = dt_adisyon_kalem.Rows[0]["masa_adi"].ToString();
            lbl_acan_kullanici.Text = dt_adisyon_kalem.Rows[0]["kullanici"].ToString();
            lbl_fis_acilis_tarihi.Text = dt_adisyon_kalem.Rows[0]["kayit_tarihi"].ToString();
            lbl_odeme_tipi.Text = odeme_tipi;
            lbl_toplam_tutar.Text = tutar.ToString("c2");

            this.DataSource = dt;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "urun_adi", "");
            tc_urun_adi.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "miktar", "x {0:0.##}");
            tc_miktar.DataBindings.Add(binding1);
            XRBinding binding2 = new XRBinding("Text", this.DataSource, "tutar", "{0:c2}");
            tc_tutar.DataBindings.Add(binding2);
            XRBinding binding3 = new XRBinding("Text", this.DataSource, "fiyat", "{0:c2}");
            tc_birim_fiyat.DataBindings.Add(binding3);

            InitializeComponent();
        }

    }
}
