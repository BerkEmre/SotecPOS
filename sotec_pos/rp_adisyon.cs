using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_adisyon : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_adisyon(int adisyon_id)
        {
            InitializeComponent();

            string text = "";
            try { text = System.IO.File.ReadAllText(@"firma_bilgi.txt"); } catch { text = ""; }
            xrLabel1.Text = text;

            DataTable dt_adisyon_kalem = SQL.get("SELECT u.fiyat, kullanici = k.ad + ' ' + k.soyad, a.kayit_tarihi, a.adisyon_id, adres_id = a.adres, masa_adi = CASE a.masa_id WHEN -1 THEN 'PAKET SERVİS' WHEN 0 THEN 'SELF SERVİS' ELSE ISNULL(m.masa_adi, '') END, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger, kurye = kurye.ad + ' ' + kurye.soyad, a.ad_soyad, mst.adres, mst.adres_2, mst.adres_3, mst.telefon FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id INNER JOIN adisyon a ON a.adisyon_id = ak.adisyon_id LEFT OUTER JOIN masalar m ON m.masa_id = a.masa_id INNER JOIN kullanicilar k ON k.kullanici_id = ak.kaydeden_kullanici_id LEFT OUTER JOIN kullanicilar kurye ON kurye.kullanici_id = a.kurye_kullanici_id LEFT OUTER JOIN musteri mst ON mst.musteri_id = a.musteri_id WHERE ak.silindi = 0 AND ak.odendi = 0 AND ak.adisyon_id = " + adisyon_id);
            if(dt_adisyon_kalem.Rows.Count <= 0)
            {
                dt_adisyon_kalem = SQL.get("SELECT u.fiyat, kullanici = k.ad + ' ' + k.soyad, a.kayit_tarihi, a.adisyon_id, adres_id = a.adres, masa_adi =  CASE a.masa_id WHEN -1 THEN 'PAKET SERVİS' WHEN 0 THEN 'SELF SERVİS' ELSE ISNULL(m.masa_adi, '') END, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger, kurye = kurye.ad + ' ' + kurye.soyad, a.ad_soyad, mst.adres, mst.adres_2, mst.adres_3, mst.telefon FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id INNER JOIN adisyon a ON a.adisyon_id = ak.adisyon_id LEFT OUTER JOIN masalar m ON m.masa_id = a.masa_id INNER JOIN kullanicilar k ON k.kullanici_id = ak.kaydeden_kullanici_id LEFT OUTER JOIN kullanicilar kurye ON kurye.kullanici_id = a.kurye_kullanici_id LEFT OUTER JOIN musteri mst ON mst.musteri_id = a.musteri_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + adisyon_id);
            }
            this.DataSource = dt_adisyon_kalem;

            DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = ISNULL(SUM((ak.miktar - ak.ikram_miktar) * u.fiyat), 0.0000) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + adisyon_id);
            DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);


            lbl_masa_adi.Text = dt_adisyon_kalem.Rows[0]["masa_adi"].ToString();
            lbl_acan_kullanici.Text = dt_adisyon_kalem.Rows[0]["kullanici"].ToString();
            lbl_fis_acilis_tarihi.Text = dt_adisyon_kalem.Rows[0]["kayit_tarihi"].ToString();

            lbl_adres_bilgileri.Text = 
                (dt_adisyon_kalem.Rows[0]["kurye"].ToString().Length > 2 ? "KURYE : " + dt_adisyon_kalem.Rows[0]["kurye"].ToString() + "\n" : "") +
                (dt_adisyon_kalem.Rows[0]["ad_soyad"].ToString().Length > 2 ? "İSİM : " + dt_adisyon_kalem.Rows[0]["ad_soyad"].ToString() + "\n" : "") +
                (dt_adisyon_kalem.Rows[0]["telefon"].ToString().Length > 2 ? "TEL : " + dt_adisyon_kalem.Rows[0]["telefon"].ToString() + "\n" : "") +
                (dt_adisyon_kalem.Rows[0][(dt_adisyon_kalem.Rows[0]["adres_id"].ToString() == "1" ? "adres" : "adres_" + dt_adisyon_kalem.Rows[0]["adres_id"].ToString())].ToString().Length > 0 ? "ADRES : " + dt_adisyon_kalem.Rows[0][(dt_adisyon_kalem.Rows[0]["adres_id"].ToString() == "1" ? "adres" : "adres_" + dt_adisyon_kalem.Rows[0]["adres_id"].ToString())].ToString() + "\n" : "");

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "urun_adi", "");
            tc_urun_adi.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "miktar", "x {0:0.##}");
            tc_miktar.DataBindings.Add(binding1);
            XRBinding binding4 = new XRBinding("Text", this.DataSource, "fiyat", "{0:c2}");
            tc_birim_fiyat.DataBindings.Add(binding4);
            XRBinding binding2 = new XRBinding("Text", this.DataSource, "tutar", "{0:c2}");
            tc_tutar.DataBindings.Add(binding2);
            /*XRBinding binding3 = new XRBinding("Text", this.DataSource, "tutar", "{0:c2}");
            lbl_toplam_tutar.DataBindings.Add(binding3);

            XRSummary sum1 = new XRSummary(SummaryRunning.Page, SummaryFunc.Sum, "{0:c2}");
            lbl_toplam_tutar.Summary = sum1;*/

            lbl_toplam_tutar.Text = (Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]) - Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"])).ToString("c2");
        }

    }
}
